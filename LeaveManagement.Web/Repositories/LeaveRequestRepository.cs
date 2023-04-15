using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContext;
    private readonly UserManager<Employee> _userManager;

    public LeaveRequestRepository(ApplicationDbContext dbContext
        , IMapper mapper
        , IHttpContextAccessor httpContext
        , UserManager<Employee> userManager) : base(dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _httpContext = httpContext;
        _userManager = userManager;
    }

    public async Task<bool> CreateLeaveReequest(LeaveRequestCreateViewModel request)
    {
        var user = await _userManager.GetUserAsync(_httpContext?.HttpContext?.User);

        var leaveRequest = _mapper.Map<LeaveRequest>(request);
        leaveRequest.DateRequested = DateTime.Now;
        leaveRequest.RequestingEmployeeId = user.Id;

        await AddAsync(leaveRequest);
        return true;
    }
}
