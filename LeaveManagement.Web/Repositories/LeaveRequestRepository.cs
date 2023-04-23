using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace LeaveManagement.Web.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContext;
    private readonly UserManager<Employee> _userManager;
    private readonly ILeaveAllocationRepository _leaveAllocationRepo;

    public LeaveRequestRepository(ApplicationDbContext dbContext
        , IMapper mapper
        , IHttpContextAccessor httpContext
        , UserManager<Employee> userManager,
ILeaveAllocationRepository leaveAllocationRepo) : base(dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _httpContext = httpContext;
        _userManager = userManager;
        _leaveAllocationRepo = leaveAllocationRepo;
    }

    public async Task ChangeApprovalStatus(int leaveRequestId, bool approvalStatus)
    {
        var leaveRequest = await GetAsync(leaveRequestId);

        leaveRequest.Approved = approvalStatus;

        if(approvalStatus)
        {
            var allocation = await _leaveAllocationRepo.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequestId);
            int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
            allocation.NumberOfDays -= daysRequested;

            await _leaveAllocationRepo.UpdateAsync(allocation);
        }

        await UpdateAsync(leaveRequest);
    }

    public async Task CreateLeaveReequest(LeaveRequestCreateViewModel request)
    {
        var user = await _userManager.GetUserAsync(_httpContext?.HttpContext?.User);

        var leaveRequest = _mapper.Map<LeaveRequest>(request);
        leaveRequest.DateRequested = DateTime.Now;
        leaveRequest.RequestingEmployeeId = user.Id;

        await AddAsync(leaveRequest);
    }

    public async Task<AdminLeaveRequestViewModel> GetAdminLeaveRequestsList()
    {
        var leaveRequests = await _dbContext.LeaveRequests
            .Include(lr => lr.LeaveType)
            .Select(lr => new LeaveRequestViewModel
            {
                Id = lr.Id,
                Approved = lr.Approved,
                Cancelled = lr.Cancelled,
                DateRequested = lr.DateRequested,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                LeaveType = _mapper.Map<LeaveTypeViewModel>(lr.LeaveType),
                RequestingEmployeeId = lr.RequestingEmployeeId
            })
            .ToListAsync();

        foreach (var leaveRequest in leaveRequests)
        {
            var employee = _mapper.Map<EmployeeViewModel>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            leaveRequest.Employee = employee;
        }

        var model = new AdminLeaveRequestViewModel
        {
            TotalRequests = leaveRequests.Count,
            ApprovedRequests = leaveRequests.Count(lr => lr.Approved == true),
            PendingRequests = leaveRequests.Count(lr => lr.Approved == null),
            RejectedRequests = leaveRequests.Count(lr => lr.Approved == false),
            LeaveRequests = leaveRequests
        };

        return model;
    }

    public async Task<LeaveRequestViewModel> GetLeaveRequestsDetails(int id)
    {
        var leaveRequest = _mapper.Map<LeaveRequestViewModel>(await _dbContext.LeaveRequests
            .Include(lr => lr.LeaveType)
            .FirstOrDefaultAsync(lr => lr.Id == id));

        leaveRequest.Employee = _mapper.Map<EmployeeViewModel>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));

        return leaveRequest;
    }

    public async Task<EmployeeLeaveRequestViewModel> GetMyLeaveDetails()
    {
        var user = await _userManager.GetUserAsync(_httpContext?.HttpContext?.User);
        var leaveRequests = _mapper.Map<List<LeaveRequestViewModel>>(await _dbContext.LeaveRequests
            .Include(lr => lr.LeaveType)
            .Where(lr => lr.RequestingEmployeeId == user.Id)
            .ToListAsync());
        var leaveAllocations = (await _leaveAllocationRepo.GetEmployeeAllocations(user.Id)).LeaveAllocations;

        var model = new EmployeeLeaveRequestViewModel
        {
            LeaveRequests = leaveRequests,
            LeaveAllocations = leaveAllocations
        };

        return model;
    }
}
