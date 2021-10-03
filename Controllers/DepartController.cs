using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpMngSys.Models;
using EmpMngSys.DBAccess;
using System.Data;

namespace EmpMngSys.Controllers
{
    public class DepartController : Controller
    {
        DepartmentDBAccess db = new DBAccess.DepartmentDBAccess();
        EmployeeDBAccess empdb = new EmployeeDBAccess();
        // GET: Depart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DepartModel depart)
        {
            if (ModelState.IsValid)
            {
               
                int result = db.AddDepartment(depart);
                if (result > 0)
                {
                    TempData["Message"] = "<script>alert('Department Added')</script>";
                    ModelState.Clear();
                }

            }
            return View();
        }


        [HttpGet]
        //Update Department
        public ActionResult Update()
        {
           
            DepartModel departlist = new DepartModel();
            departlist.DepartmentList = empdb.PopulateDepartment();
            return View(departlist);
        }


        [HttpPost]
        public JsonResult UpdateDept(string deptid)
        {
            DataSet ds = new DataSet();
            int did = Convert.ToInt32(deptid);
            ds = db.GetDepartmentDetails(did);
            List<DepartModel> departmentlist = new List<Models.DepartModel>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DepartModel deptobj = new DepartModel();
                    deptobj.Department = dr["Department"].ToString();
                    deptobj.Contact = dr["Contact"].ToString();
                    deptobj.Manager = dr["Manager"].ToString();
                    departmentlist.Add(deptobj);
                }

            }
            return Json(departmentlist, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Update(DepartModel departmentmodel)
        {
            int r = db.UpdateDepartment(departmentmodel);
            if (r > 0)
            {
                TempData["Message"] = "<script>alert('Department Updated')</script>";
                DepartModel departlist = new DepartModel();
                departlist.DepartmentList = empdb.PopulateDepartment();
                return View(departlist);
            }
            return View();
        }


        //Select Index changed of dropdown to get detail of employee
        //[HttpPost]
        //public ActionResult Update(DepartModel depart)
        //{
        //    EmployeeDBAccess empdb = new EmployeeDBAccess();
        //    DepartModel department = new Models.DepartModel();
        //    DataSet ds = new DataSet();
        //    ds = db.GetDepartmentDetails(depart.DeptId);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {   department.DepartmentList = empdb.PopulateDepartment();
        //        department.Department = ds.Tables[0].Rows[0]["Department"].ToString();
        //        department.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
        //        department.Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
        //        //return RedirectToAction("Update", "Depart", department);
        //       // return View(department);
        //        TempData["Depatment"] = department;
        //    }

        //    return View();

       // }
    }
}