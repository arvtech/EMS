using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpMngSys.DBAccess;
using EmpMngSys.Models;
using System.Data;

namespace EmpMngSys.Controllers
{
    public class LoginController : Controller
    {
        LoginDBAccess db = new LoginDBAccess();
        //Get Login View
        public ActionResult Login()
        {
            return View();
        }
        //Post Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                DataSet ds = new DataSet();
                ds = db.LoginUser(login);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Session["Username"] = login.Username;
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    TempData["Message"] = "<script>alert('Username and Password Incorrect')</script>";
                    return View();
                }
            }
            return View();
        }
    }
}