using AutoMapper;
using KeremCvTemplate.Entites.Concrete;
using KeremCvTemplate.Entites.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System;

namespace KeremCvTemplate.Mvc.Mvc.Areas.Admin.Controllers
{
  
        [Area("Admin")]

        public class AuthController : Controller
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;
            private readonly SignInManager<User> _signInManager;

            private readonly IWebHostEnvironment _env;




            public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager, IWebHostEnvironment env)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _roleManager = roleManager;
                _env = env;
            }

            [HttpGet]

            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(UserLoginDto userLoginDto)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
                    if (user != null)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password,
                            userLoginDto.RememberMe, false);

                        if (result.Succeeded)
                        {

                            var roles = await _userManager.GetRolesAsync(user);

                          
                            if (await _signInManager.UserManager.IsInRoleAsync(user, "Admin"))
                            {
                                return RedirectToAction("Index", "Home", new { area = "Admin" });
                            }
                          
                            else
                            {
                                return RedirectToAction("Login", "Auth");
                            }


                        }
                        else
                        {
                            ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                        return View();
                    }
                }
                else
                {
                    return View();
                }

            }

            //[HttpGet]
            //public IActionResult Register()
            //{
            //    return View();
            //}

            //[HttpPost]
            //public async Task<IActionResult> Register(UserAddDto userAddDto)
            //{
              
            //    if (ModelState.IsValid)
            //    {
            //        var user = new User
            //        {
            //            UserName = userAddDto.UserName,
            //            Email = userAddDto.Email,
            //            About = userAddDto.About,
            //            FirstName = userAddDto.FirstName,
            //            LastName = userAddDto.LastName,
                   
            //            EmailConfirmed = true
            //        };


            //        var identityResult = await _userManager.CreateAsync(user, userAddDto.Password);
            //        if (identityResult.Succeeded)
            //        {
            //            TempData["SuccessMessageLogin"] = $"{userAddDto.FirstName} Başarıyla kayıt oldunuz. Lütfen giriş yapınız.";
            //            await _userManager.AddToRoleAsync(user, "Users");
            //            return RedirectToAction("Login", "Auth", new { area = "Admin" });
            //        }
            //        else
            //        {
                      
                        

            //            foreach (var error in identityResult.Errors)
            //            {
            //                ModelState.AddModelError("", error.Description);
            //            }
            //        }
            //    }
            //    return View(userAddDto);
            //}




            [Authorize]
            [HttpGet]
            public ViewResult AccessDenied()
            {
                return View();
            }
            [Authorize]
            [HttpGet]
            public async Task<IActionResult> LogOut()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
        }
    }

