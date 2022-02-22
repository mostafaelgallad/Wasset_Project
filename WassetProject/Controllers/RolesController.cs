using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WassetPortal_DAL.Models;
using WassetPortal_DAL.Repositories;

namespace WassetPortal.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserRepository _userRepository;
        public RolesController()
        {
            _userRepository = new UserRepository();
        }
        // GET: Roles
        public ActionResult Index()
        {
            // var cookie_orgID = Request.Cookies["orgID"]?.Value;
            // if (!string.IsNullOrEmpty(cookie_orgID) && int.TryParse(cookie_orgID, out int orgID))
            //{
            try
            {
                var roles = _userRepository.GetRolesList();
                return View("Index", roles);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //  }
            //  return RedirectToAction("LogIn", "login", new { area = "" });
           
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Role role)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
