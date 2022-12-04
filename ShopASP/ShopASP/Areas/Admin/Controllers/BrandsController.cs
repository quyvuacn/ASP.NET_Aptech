using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Versioning;
using ShopASP.Areas.Admin.Models;
using ShopASP.Data;
using ShopASP.Extensions;
using ShopASP.Models;

namespace ShopASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly ShopASPContext _context;

        public BrandsController(ShopASPContext context)
        {
            _context = context;
            
        }

        // GET: Admin/Brands
        public async Task<IActionResult> Index(string search)
        {
            if (_context.Brand==null)
            {
                return NotFound();
            }

            var brands = from b in _context.Brand select b;

			if (!String.IsNullOrEmpty(search))
			{
				brands = brands.Where(s => s.Name!.Contains(search));
			}

            var brandVM = new BrandViewModel
            {
                Brands = await brands.ToListAsync()
            };
            return View(brandVM);
        }

        // GET: Admin/Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Admin/Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedDate,UpdatedDate")] Brand brand)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(brand);
                    await _context.SaveChangesAsync();
                    TempData["notification"] = new NOTIFICATION().SUCCESS;
                    return RedirectToAction(nameof(Index));
                }

            }
            catch(Exception ex) {
                TempData["notification"] =  new NOTIFICATION().ERROR;
            }
            
            return View(brand);
        }

        // GET: Admin/Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedDate,UpdatedDate")] Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                    TempData["notification"] = new NOTIFICATION().SUCCESS;
                }
                catch (DbUpdateConcurrencyException)
                {
					TempData["notification"] = new NOTIFICATION().ERROR;
					if (!BrandExists(brand.Id))
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
            return View(brand);
        }

        // POST: Admin/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brand == null)
            {
                return Problem("Entity set 'ShopASPContext.Brand'  is null.");
            }
            var brand = await _context.Brand.FindAsync(id);
            if (brand != null)
            {
                _context.Brand.Remove(brand);
            }
            
            await _context.SaveChangesAsync();

			TempData["notification"] = new NOTIFICATION().SUCCESS;

			return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
          return (_context.Brand?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
