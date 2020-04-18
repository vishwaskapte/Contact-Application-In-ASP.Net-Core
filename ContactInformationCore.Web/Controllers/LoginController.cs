using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ContactInformationCore.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApplicationCore.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login loginViewModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(loginViewModel.Username) && !string.IsNullOrEmpty(loginViewModel.Password))
                {
                    var Username = loginViewModel.Username;
                    var password = loginViewModel.Password;

                    bool result = ValidateUser(Username, password);

                    if (result)
                    {
                        return RedirectToAction("Index", "Contact", "Main");
                    }
                    else
                    {
                        ViewBag.errormessage = "Entered Invalid Username and Password";
                        return View();
                    }
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
            catch (Exception)
            {
                throw;
            }

        }

        [NonAction]
        public void remove_Anonymous_Cookies()
        {
            if (Request.Cookies["EventChannel"] != null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append("EventChannel", "", option);
            }
        }

        [NonAction]
        public bool ValidateUser(string Username, string password)
        {
            bool IsValidate = false;
            if((Username.Equals("Admin") || Username.Equals("admin")) && ((password.Equals("Admin")) || password.Equals("admin")))
            {
                HttpContext.Session.SetString("Username", Convert.ToString(Username));
                IsValidate = true;
            }

            return IsValidate;
        }

    }
}
