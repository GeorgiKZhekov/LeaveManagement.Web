using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly ILeaveTypeRepository _leaveTypeRepo;

        public EmployeesController(UserManager<Employee> userManager
                                    ,IMapper mapper
                                    ,ILeaveAllocationRepository leaveAllocationRepo
                                    ,ILeaveTypeRepository leaveTypeRepo)
        {
            _userManager = userManager;
            _mapper = mapper;
            _leaveAllocationRepo = leaveAllocationRepo;
            _leaveTypeRepo = leaveTypeRepo;
        }

        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var employeesView = _mapper.Map<List<EmployeeViewModel>>(employees);
            return View(employeesView);
        }

        // GET: EmployeesController/ViewAllocations/employeeId
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var allocations = await _leaveAllocationRepo.GetEmployeeAllocations(id); 
            return View(allocations);
        }

        // GET: EmployeesController/EditAllocation/5
        public async Task<IActionResult> EditAllocation(int id)
        {
            var model = await _leaveAllocationRepo.GetEmployeeAllocation(id);

            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: EmployeesController/EditAllocation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(int id, LeaveAllocationEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(await _leaveAllocationRepo.EditEmployeeAllocation(model))
                        return RedirectToAction(nameof(ViewAllocations), new { id = model.EmployeeId });
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An error has occuerred. Please try againg later.");
            }
            model.Employee = _mapper.Map<EmployeeViewModel>(await _userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = _mapper.Map<LeaveTypeViewModel>(await _leaveTypeRepo.GetAsync(model.LeaveTypeId));
            return View(model);
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
