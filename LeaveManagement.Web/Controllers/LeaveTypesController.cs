using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public LeaveTypesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this._mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = _mapper.Map<List<LeaveTypeViewModel>>( await _dbContext.LeaveTypes.ToListAsync(cancellationToken));
            return View(result);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id, CancellationToken cancellationToken)
        {
            if (id == null || _dbContext.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _dbContext.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        // returns the view for the create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeViewModel leaveTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeViewModel);
                _dbContext.Add(leaveType);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _dbContext.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _dbContext.LeaveTypes.FindAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,DefaultDays,Id,DateCreated,DateModified")] LeaveType leaveType)
        {
            if (id != leaveType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(leaveType);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveType);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _dbContext.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _dbContext.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dbContext.LeaveTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
            }
            var leaveType = await _dbContext.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _dbContext.LeaveTypes.Remove(leaveType);
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
            return _dbContext.LeaveTypes.Any(e => e.Id == id);
        }
    }
}
