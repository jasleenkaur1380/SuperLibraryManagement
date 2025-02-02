using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.DAL.Context;
using Library.DTO.DBModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime;
using System.Runtime.Caching;

namespace SuperLibraryManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account


        private void AssignRolesAndSecurity(User user)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                    // Check cache for role existence to reduce DB calls
                    var cache = MemoryCache.Default;
                    bool roleExists = cache.Contains(user.Role) || roleManager.RoleExists(user.Role);

                    if (!roleExists)
                    {
                        var role = new IdentityRole(user.Role);
                        roleManager.Create(role);

                        // Store role in cache for future requests (expires in 10 minutes)
                        cache.Add(user.Role, true, DateTimeOffset.UtcNow.AddMinutes(10));
                    }

                    // Create user only if they do not exist
                    var existingUser = userManager.FindByName(user.Username);
                    if (existingUser == null)
                    {
                        var newUser = new ApplicationUser { UserName = user.Username, Email = user.Email, Id = user.Id.ToString() };
                        var result = userManager.Create(newUser, user.Password);

                        if (result.Succeeded)
                        {
                            userManager.AddToRole(newUser.Id, user.Role);

                            // Store user information in session
                            Session["UserId"] = newUser.Id;
                            Session["Username"] = newUser.UserName;
                            Session["UserRole"] = user.Role;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error (optional)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public ActionResult Index()
        {
            try
            {
                var ex = DapperContext.ExeQueryList<Student>("select *from student");
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }

    }
}