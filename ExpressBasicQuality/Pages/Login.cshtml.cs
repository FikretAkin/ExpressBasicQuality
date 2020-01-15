using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Data.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace ExpressBasicQuality
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public Int64 Id { get; set; }
            [Required]
            public string EMail { get; set; }

            [Required]
            public string Password1 { get; set; }

            public string Role1 { get; set; }
        }

        public IActionResult OnPost()
        {
            //ClaimsIdentity identity = null;
            //bool isAuthenticated = false;
            if (ModelState.IsValid)
            {
                xUser user = _userService.GetByFilter(x => x.EMail == Input.EMail && x.Password1 == Input.Password1);
                if (user == null)
                {
                    ModelState.AddModelError("", "Giriş Yapılamadı!");
                }
                else if (user.Role1 == "DAdmin")
                {

                    HttpContext.Session.SetString("Id", user.Id.ToString());
                    HttpContext.Session.SetString("EMail", user.EMail);
                    HttpContext.Session.SetString("Role1", user.Role1);
                    return RedirectToPage("./DAdmin/Anasayfa");
                    //identity = new ClaimsIdentity(new[] {
                    //    new Claim(ClaimTypes.Email, Input.EMail),
                    //    new Claim(ClaimTypes.Role, "DAdmin")
                    //}, CookieAuthenticationDefaults.AuthenticationScheme);
                    //isAuthenticated = true;

                    //if (isAuthenticated)
                    //{
                    //    var principal = new ClaimsPrincipal(identity);

                    //    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    //    return RedirectToPage("./DAdmin/Anasayfa");
                    //}
                }
                else if (user.Role1 == "Admin")
                {
                    HttpContext.Session.SetString("Id", user.Id.ToString());
                    HttpContext.Session.SetString("EMail", user.EMail);
                    HttpContext.Session.SetString("Role1", user.Role1);
                    return RedirectToPage("./Admin/AdminAnasayfa");
                }
                ModelState.AddModelError("", "Giriş Yapılamadı!");
            }
            return RedirectToPage();
        }
    }
}