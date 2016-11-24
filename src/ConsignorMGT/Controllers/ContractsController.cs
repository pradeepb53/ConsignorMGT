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
    public class ContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Contract.Include(c => c.Consignors).Include(c => c.Events);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.SingleOrDefaultAsync(m => m.ContractID == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["ConsignorID"] = new SelectList(_context.Consignor, "ConsignorID", "ConsignorID");
            ViewData["EventID"] = new SelectList(_context.Set<Event>(), "EventID", "EventID");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractID,ConsignorID,EventID,OwnerCode,Type")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ConsignorID"] = new SelectList(_context.Consignor, "ConsignorID", "ConsignorID", contract.ConsignorID);
            ViewData["EventID"] = new SelectList(_context.Set<Event>(), "EventID", "EventID", contract.EventID);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.SingleOrDefaultAsync(m => m.ContractID == id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["ConsignorID"] = new SelectList(_context.Consignor, "ConsignorID", "ConsignorID", contract.ConsignorID);
            ViewData["EventID"] = new SelectList(_context.Set<Event>(), "EventID", "EventID", contract.EventID);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractID,ConsignorID,EventID,OwnerCode,Type")] Contract contract)
        {
            if (id != contract.ContractID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.ContractID))
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
            ViewData["ConsignorID"] = new SelectList(_context.Consignor, "ConsignorID", "ConsignorID", contract.ConsignorID);
            ViewData["EventID"] = new SelectList(_context.Set<Event>(), "EventID", "EventID", contract.EventID);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.SingleOrDefaultAsync(m => m.ContractID == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contract.SingleOrDefaultAsync(m => m.ContractID == id);
            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.ContractID == id);
        }
    }
}
