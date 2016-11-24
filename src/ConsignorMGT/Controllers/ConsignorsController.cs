using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsignorMGT.Data;
using ConsignorMGT.Models;

namespace ConsignorMGT.Controllers
{
    public class ConsignorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsignorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Consignors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consignor.ToListAsync());
        }

        // GET: Consignors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignor = await _context.Consignor.SingleOrDefaultAsync(m => m.ConsignorID == id);
            if (consignor == null)
            {
                return NotFound();
            }

            return View(consignor);
        }

        // GET: Consignors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consignors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsignorID,City,FirstName,LastName")] Consignor consignor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consignor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consignor);
        }

        // GET: Consignors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignor = await _context.Consignor.SingleOrDefaultAsync(m => m.ConsignorID == id);
            if (consignor == null)
            {
                return NotFound();
            }
            return View(consignor);
        }

        // POST: Consignors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsignorID,City,FirstName,LastName")] Consignor consignor)
        {
            if (id != consignor.ConsignorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consignor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsignorExists(consignor.ConsignorID))
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
            return View(consignor);
        }

        // GET: Consignors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignor = await _context.Consignor.SingleOrDefaultAsync(m => m.ConsignorID == id);
            if (consignor == null)
            {
                return NotFound();
            }

            return View(consignor);
        }

        // POST: Consignors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consignor = await _context.Consignor.SingleOrDefaultAsync(m => m.ConsignorID == id);
            _context.Consignor.Remove(consignor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ConsignorExists(int id)
        {
            return _context.Consignor.Any(e => e.ConsignorID == id);
        }
    }
}
