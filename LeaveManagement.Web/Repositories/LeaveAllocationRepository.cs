using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LeaveManagement.Web.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<Employee> _userManager;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public LeaveAllocationRepository(ApplicationDbContext dbContext,
        UserManager<Employee> userManager,
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper) : base(dbContext)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
    {
        return await _dbContext.LeaveAllocations.AnyAsync(la => la.EmployeeId == employeeId 
                                                        && la.LeaveType.Id == leaveTypeId 
                                                        && la.Period == period);
    }

    public async Task<EmployeeAllocationsViewModel> GetEmployeeAllocations(string employeeId)
    {
        var allocations = await _dbContext.LeaveAllocations
            .Include(la => la.LeaveType)
            .Where(la => la.EmployeeId == employeeId)
            .ToListAsync();

        var employee = await _userManager.FindByIdAsync(employeeId);

        var employeeAllocations = _mapper.Map<EmployeeAllocationsViewModel>(employee);
        employeeAllocations.LeaveAllocations = _mapper.Map<List<LeaveAllocationViewModel>>(allocations);
        return employeeAllocations;
    
    }

    public async Task<LeaveAllocationEditViewModel> GetEmployeeAllocation(int id)
    {
        var allocation = await _dbContext.LeaveAllocations
            .Include(la => la.LeaveType)
            .FirstOrDefaultAsync(la => la.Id == id);

        if(allocation == null)
        {
            return null;
        }

        var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);

        var model = _mapper.Map<LeaveAllocationEditViewModel>(allocation);
        model.Employee = _mapper.Map<EmployeeViewModel>(await _userManager.FindByIdAsync(allocation.EmployeeId));

        return model;

    }

    public async Task LeaveAllocation(int leaveTypeId)
    {
        var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
        var period = DateTime.Now.Year;
        var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);
        var allocations = new List<LeaveAllocation>();

        foreach (var employee in employees)
        {
            if (await AllocationExists(employee.Id, leaveTypeId, period))
                continue;

            allocations.Add(new LeaveAllocation
            {
                EmployeeId = employee.Id,
                LeaveTypeId = leaveTypeId,
                Period = period,
                NumberOfDays = leaveType.DefaultDays
            });
        }

        await AddRangeAsync(allocations);
    }

    public async Task<bool> EditEmployeeAllocation(LeaveAllocationEditViewModel model)
    {
        var leaveAllocation = await GetAsync(model.Id);

        if (leaveAllocation == null)
        {
            return false;
        }

        leaveAllocation.Period = model.Period;
        leaveAllocation.NumberOfDays = model.NumberOfDays;

        await UpdateAsync(leaveAllocation);
        return true;
    }

    public async Task<LeaveAllocation> GetEmployeeAllocation(string employeeId, int leaveTypeId)
    {
        var leaveAllocation = await _dbContext.LeaveAllocations.FirstOrDefaultAsync(la => 
        la.EmployeeId == employeeId && la.LeaveTypeId == leaveTypeId);

        return leaveAllocation;
    }
}
