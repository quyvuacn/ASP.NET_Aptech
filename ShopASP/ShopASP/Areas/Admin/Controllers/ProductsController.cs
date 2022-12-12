using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopASP.Areas.Admin.Models;
using ShopASP.Data;
using ShopASP.Features;
using ShopASP.Features.Models;
using ShopASP.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ShopASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ShopASPContext _context;

		public ProductsController(ShopASPContext context)
        {
            _context = context;
        }
        
        // GET: Admin/Products
        public async Task<IActionResult> Index(string search)
        {
            var shopASPContext = _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p=>p.ProductImages);
            var products = await shopASPContext
                    .Where(product=>product.Name.Contains(search??""))
                    .ToListAsync();

			ProductViewModel productViewModel = new ProductViewModel
            {
                Products = products
			};
            return View(productViewModel);
        }

        // GET: Admin/Products/Create
        public async Task<IActionResult> Create()
        {
			ProductViewModel productViewModel = new ProductViewModel
			{
				Categories = await _context.Category.ToListAsync(),
				Brands = await _context.Brand.ToListAsync(),
				Tags = await _context.Tag.ToListAsync()
			};
			return View(productViewModel);
		}

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            var product = productViewModel.Product;
            try
            {
                _context.Product.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new {id=product.Id});
            }
            catch
            {
                return View(productViewModel);
            }
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
			if (id == null || _context.Product == null)
			{
				return NotFound();
			}
			var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductDetails.OrderByDescending(pd=>pd.CreatedDate))
                .Include(p => p.Tags)
                    .ThenInclude(tag=>tag.Tag)
				.FirstOrDefaultAsync(m => m.Id == id);

			ProductViewModel productViewModel = new ProductViewModel
			{
				Product = product,
				Categories = await _context.Category.ToListAsync(),
				Brands = await _context.Brand.ToListAsync(),
				Tags = await _context.Tag.ToListAsync()
			};


			if (product == null)
			{
				return NotFound();
			}

			return View(productViewModel);
		}

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            var product = productViewModel.Product;

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                TempData["tab"]= "product";
            }
            catch (DbUpdateConcurrencyException)
            {
				return View(productViewModel);
			}
            return RedirectToAction("Edit", new {id= product.Id});
            
            
            
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ShopASPContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            TempData["tab"]= "product";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

		// POST: Admin/Products/Upload/5
		[HttpPost, ActionName("Upload")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UploadProductImage(int ProductId,IFormFile file)
		{
			if (file!=null)
			{
                var fileModel = new FileModel
                {
                    FileData = file,
                    FileName = "product_"
                };
                try
                {
                    var fileAction = FileAction.Upload(fileModel, "wwwroot/front/images/products");
                    if (fileAction.Completed)
                    {
                        var newProductImage = new ProductImage
                        {
                            ProductId = ProductId,
                            Path = fileAction.Result
                        };
						_context.Add(newProductImage);
                        await _context.SaveChangesAsync();
						TempData["tab"]= "medias";
						return RedirectToAction("Edit", new {id= ProductId});
					}
					return BadRequest();
				}
				catch
                {
					return BadRequest();
				}
			}
            else
            {
                return BadRequest();
            }
		}

		[HttpPost, ActionName("DeleteImage")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteImageConfirmed(int id)
		{
			if (_context.ProductImage == null)
			{
				return Problem("Entity set 'ShopASPContext.ProductImage'  is null.");
			}
			var productImage = await _context.ProductImage.FindAsync(id);
            var productId = productImage.ProductId;
            var productImageName = productImage.Path;
			if (productImage != null)
			{
                var fileAction =  FileAction.Remove("wwwroot/front/images/products/"+productImageName);
                Console.WriteLine(fileAction.Result);
				_context.ProductImage.Remove(productImage);
                await _context.SaveChangesAsync();
			}
			TempData["tab"]= "medias";
			return RedirectToAction("Edit", new {id=productId});
		}

		[HttpPost, ActionName("CreateProductDetail")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateProductDetail(ProductViewModel productViewModel)
        {
            try
            {
				var productDetail = productViewModel.ProductDetail;
                Console.WriteLine(productDetail.ProductId);
				_context.Add(productDetail);    
				await _context.SaveChangesAsync();
				TempData["tab"]= "variants";
				return RedirectToAction("Edit", new { id = productDetail.ProductId });
			}
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
			
		}

		[HttpPost, ActionName("EditProductDetail")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditProductDetail(ProductDetail productDetail)
		{
			if(ModelState.IsValid)
            {
                _context.Update(productDetail);
                await _context.SaveChangesAsync();
                TempData["tab"] = "variants";
                return RedirectToAction("Edit", new {id= productDetail.ProductId});
            }
            else
            {
                return BadRequest("Lỗi");
            }

		}

		[HttpPost, ActionName("DeleteProductDetail")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteProductDetail(int id)
		{
			var productDetail = await _context.ProductDetail.FindAsync(id);
            var productId = productDetail.ProductId;
            if(productDetail!=null)
            {
                _context.ProductDetail.Remove(productDetail);
            }
			await _context.SaveChangesAsync();

            TempData["tab"] = "variants";

			return RedirectToAction("Edit", new {id= productId });
		}



		private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
