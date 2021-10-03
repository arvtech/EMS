using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EmpMngSys.Models
{   
    public class EmployeeModal
    {
        [Required(ErrorMessage ="Enter Name")]
        public string Name { get; set; }
        // public int Department { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        public string Salary { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Contact Number")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

       // [Required(ErrorMessage = "Select Image")]
        public string Image { get; set; }

        public bool IsActive { get; set; }
        public int Checktype { get; set; }


        public List<SelectListItem> Departments { get; set; }

     //   [Required(ErrorMessage = "Select Department")]
        public int DeptId { get; set; }
        public string Department { get; set; }

        //Image
    

    }
}