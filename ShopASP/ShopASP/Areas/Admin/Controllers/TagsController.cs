using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopASP.Data;
using ShopASP.Models;

namespace ShopASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        private readonly ShopASPContext _context;

        public TagsController(ShopASPContext context)
        {
            _context = context;
        }

        // GET: Admin/Tags
        public async Task<IActionResult> Index()
        {
            var shopASPContext = _context.ProductTag.Include(p => p.Product).Include(p => p.Tag);
            return View(await shopASPContext.ToListAsync());
        }

        // GET: Admin/Tags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductTag == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductTag
                .Include(p => p.Product)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productTag == null)
            {
                return NotFound();
            }

            return View(productTag);
        }

        // GET: Admin/Tags/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            ViewData["TagId"] = new SelectList(_context.Tag, "Id", "Id");
            return View();
        }

        // POST: Admin/Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagId,ProductId")] ProductTag productTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productTag.ProductId);
            ViewData["TagId"] = new SelectList(_context.Tag, "Id", "Id", productTag.TagId);
            return View(productTag);
        }

        // GET: Admin/Tags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductTag == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductTag.FindAsync(id);
            if (productTag == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productTag.ProductId);
            ViewData["TagId"] = new SelectList(_context.Tag, "Id", "Id", productTag.TagId);
            return View(productTag);
        }

        // POST: Admin/Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TagId,ProductId")] ProductTag productTag)
        {
            if (id != productTag.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTagExists(productTag.ProductId))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productTag.ProductId);
            ViewData["TagId"] = new SelectList(_context.Tag, "Id", "Id", productTag.TagId);
            return View(productTag);
        }

        // GET: Admin/Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductTag == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductTag
                .Include(p => p.Product)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productTag == null)
            {
                return NotFound();
            }

            return View(productTag);
        }

        // POST: Admin/Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductTag == null)
            {
                return Problem("Entity set 'ShopASPContext.ProductTag'  is null.");
            }
            var productTag = await _context.ProductTag.FindAsync(id);
            if (productTag != null)
            {
                _context.ProductTag.Remove(productTag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTagExists(int id)
        {
          return (_context.ProductTag?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
