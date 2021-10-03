using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpMngSys.DBAccess;
using EmpMngSys.Models;

namespace EmpMngSys.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDBAccess db = new EmployeeDBAccess();
        EmployeeModal emp = new Models.EmployeeModal();
       

        // GET: Employee
        public ActionResult Create()
        {
            emp.Departments = db.PopulateDepartment();
            return View(emp);
        }

        //Add New Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase ImageData, EmployeeModal employee)
        {
            if (ImageData != null)
            {
                int result = db.InsertEmployee(ImageData, employee);
                if (result > 0)
                {
                    TempData["Message"] = "<script>alert('Employee Added Successfully')</script>";

                    ModelState.Clear();
                }
            }
            else
            {
                TempData["Message"] = "<script>alert('Please Select Image')</script>";

            }

            emp.Departments = db.PopulateDepartment();
            return View(emp);
        }
    }
}