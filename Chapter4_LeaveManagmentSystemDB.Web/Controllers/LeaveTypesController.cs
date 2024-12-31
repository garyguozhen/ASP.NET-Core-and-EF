using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chapter4_LeaveManagementSystem.Web.Data;
using Chapter4_LeaveManagmentSystemDB.Web.Data;
using Chapter4_LeaveManagmentSystemDB.Web.Models.ViewModels;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Chapter4_LeaveManagmentSystemDB.Web.Services;

namespace Chapter4_LeaveManagmentSystemDB.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeServices _leaveTypeServices;
        public LeaveTypesController(ILeaveTypeServices leaveTypeServices)
        {
            this._leaveTypeServices = leaveTypeServices;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var viewData= await _leaveTypeServices.GetLeaveTypesAsync();
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewData=await _leaveTypeServices.Get<LeaveTypeViewModel>(id.Value);
            if (viewData == null)
            {
                return NotFound();
            }
            return View(viewData);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateView leaveTypeCreate)
        {
            if (ModelState.IsValid)
            {
                await _leaveTypeServices.Create(leaveTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _leaveTypeServices.Get<LeaveTypeViewModel>(id.Value);

            return View(data);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeViewModel leaveTypeView)
        {
            if (id != leaveTypeView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypeServices.Edit(leaveTypeView);
                }
                catch (DbUpdateConcurrencyException)
                {
                    _leaveTypeServices.LeaveTypeExists(leaveTypeView.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeView);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeServices.Get<LeaveTypeViewModel>(id.Value);
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
            await  _leaveTypeServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
