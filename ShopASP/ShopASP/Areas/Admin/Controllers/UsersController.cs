using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopASP.Areas.Admin.Models;
using ShopASP.Data;
using ShopASP.Extensions;
using ShopASP.Features;
using ShopASP.Features.Models;
using ShopASP.Models;

namespace ShopASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly ShopASPContext _context;
        public UsersController(ShopASPContext context)
        {
            _context = context;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Index(string search)
        {
            if (_context.User==null)
            {
                return Problem("Entity set 'ShopASPContext.User'  is null.");
			}
            var userContext =_context.User
                .Include(u => u.Orders)
                    .ThenInclude(o => o.OrderDetails);

		    var users = await userContext
		    .Where(user =>
			    user.Name!.Contains(search??"") ||
			    user.Email!.Contains(search??"")
		    )
		    .ToListAsync();

            UserViewModel userViewModel = new UserViewModel
            {
                Users = users,
            };
            return View(userViewModel);
        }

        // GET: Admin/Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
			
            User user = userViewModel.User;
            UserAddress userAddress = userViewModel.UserAddress;
            IFormFile file = userViewModel.userAvatar;
            if (user.Password==userViewModel.rePassword)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                if (file!=null)
                {
                    var image = new FileModel {
                        FileData = file,
                        FileName = "userAvatar"
                    };
					var ActionUpload = FileAction.Upload(image, "wwwroot/front/images/users");

					if (ActionUpload.Completed)
                    {
                        user.Avatar = ActionUpload.Result;
                    }
                    else
                    {
						TempData["notification"] = new NOTIFICATION().ERROR;
                        return View(userViewModel);
					}
                }
				_context.Add(user);
				await _context.SaveChangesAsync();

                userAddress.UserId = user.Id;
                _context.Add(userAddress);
                await _context.SaveChangesAsync();
                TempData["notification"] = new NOTIFICATION().SUCCESS;
			}
            else
            {
                TempData["notification"] = new NOTIFICATION().ERROR;
            }
			return RedirectToAction("Index");

		}

        // GET: Admin/Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }
            var userContext = _context.User
                .Include(user => user.UserAddress);

			var user = await userContext.FirstOrDefaultAsync(user => user.Id == id);
			var userViewModel = new UserViewModel
			{
				User = user,
                UserAddress = user.UserAddress.Count()>0 ? user.UserAddress.First() : null
			};

            if (user == null)
            {
                return NotFound();
            }
            return View(userViewModel);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,UserViewModel userViewModel)
        {
            User User = userViewModel.User;
            UserAddress UserAddress = userViewModel.UserAddress;
            try
            {
				User UserContext = await _context.User.FindAsync(id);

                if (UserContext == null)
                {
                    return NotFound();
                }

				UserContext.Name = User.Name;
				UserContext.Email = User.Email;
				UserContext.Phone = User.Phone;
                UserContext.Level = User.Level;

                Console.WriteLine(UserAddress.Id);

                _context.User.Update(UserContext);
                _context.UserAddresses.Update(UserAddress);

				await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
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
        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ShopASPContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
