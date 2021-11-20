using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMP1005_AuthenticatedWebAppAssignment2_A00236910.Data;
using CMP1005_AuthenticatedWebAppAssignment2_A00236910.Models;

namespace CMP1005_AuthenticatedWebAppAssignment2_A00236910
{
    public class MyScaffold : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyScaffold(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyScaffold
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUserDetail.ToListAsync());
        }

        // GET: MyScaffold/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserDetail = await _context.ApplicationUserDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUserDetail == null)
            {
                return NotFound();
            }

            return View(applicationUserDetail);
        }

        // GET: MyScaffold/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyScaffold/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,DateOfBirth,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUserDetail applicationUserDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUserDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUserDetail);
        }

        // GET: MyScaffold/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserDetail = await _context.ApplicationUserDetail.FindAsync(id);
            if (applicationUserDetail == null)
            {
                return NotFound();
            }
            return View(applicationUserDetail);
        }

        // POST: MyScaffold/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,DateOfBirth,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUserDetail applicationUserDetail)
        {
            if (id != applicationUserDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUserDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserDetailExists(applicationUserDetail.Id))
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
            return View(applicationUserDetail);
        }

        // GET: MyScaffold/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserDetail = await _context.ApplicationUserDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUserDetail == null)
            {
                return NotFound();
            }

            return View(applicationUserDetail);
        }

        // POST: MyScaffold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUserDetail = await _context.ApplicationUserDetail.FindAsync(id);
            _context.ApplicationUserDetail.Remove(applicationUserDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserDetailExists(string id)
        {
            return _context.ApplicationUserDetail.Any(e => e.Id == id);
        }
    }
}
