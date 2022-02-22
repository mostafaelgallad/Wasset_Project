using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WassetPortal.Models.ViewModels;
using WassetPortal_DAL.Repositories;

namespace WassetPortal.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserRepository _userRepository;
        public LoginController()
        {
            _userRepository = new UserRepository();
        }
        // GET: Login
        public ActionResult StuffLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM login)
        {
            if (login != null)
            {
                var user = _userRepository.GetUserByLogin(login.UserName, login.PassWord);
                if (user !=null)
                {
                    return RedirectToAction("Index", "User");

                }
                else
                {
                    TempData["message"] = "worng Account or Password please enter a valid credantil ";
                    return RedirectToAction("StuffLogin", "Login");
                }
            }
            else
            {
                TempData["message"] = "worng Account or Password please enter a valid credantil ";
                return RedirectToAction("StuffLogin", "Login");
            }
        }
    }
}