using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmpMngSys.Models
{
    public class LoginModel
    {
        //Properties 
        [Required(ErrorMessage ="Please Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Checktype { get; set; }

    }
}