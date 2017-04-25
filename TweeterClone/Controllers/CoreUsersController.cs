using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TweeterClone.App.Entities;
using TweeterClone.Plugins;

namespace TweeterClone.Controllers
{
    public class CoreUsersController : Controller
    {
        private readonly TweeterDb _context;

        public CoreUsersController(TweeterDb context)
        {
            _context = context;    
        }

        // GET: CoreUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: CoreUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coreUser = await _context.Users
                .SingleOrDefaultAsync(m => m.Username == id);
            if (coreUser == null)
            {
                return NotFound();
            }

            return View(coreUser);
        }

        // GET: CoreUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoreUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username")] CoreUser coreUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coreUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coreUser);
        }

        // GET: CoreUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coreUser = await _context.Users.SingleOrDefaultAsync(m => m.Username == id);
            if (coreUser == null)
            {
                return NotFound();
            }
            return View(coreUser);
        }

        // POST: CoreUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username")] CoreUser coreUser)
        {
            if (id != coreUser.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coreUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreUserExists(coreUser.Username))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(coreUser);
        }

        // GET: CoreUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coreUser = await _context.Users
                .SingleOrDefaultAsync(m => m.Username == id);
            if (coreUser == null)
            {
                return NotFound();
            }

            return View(coreUser);
        }

        // POST: CoreUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var coreUser = await _context.Users.SingleOrDefaultAsync(m => m.Username == id);
            _context.Users.Remove(coreUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CoreUserExists(string id)
        {
            return _context.Users.Any(e => e.Username == id);
        }
    }
}
