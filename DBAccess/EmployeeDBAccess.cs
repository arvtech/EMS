using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using EmpMngSys.Models;
using System.Web.Mvc;
using System.IO;

namespace EmpMngSys.DBAccess
{
    public class EmployeeDBAccess
    {
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand cmd;
        DataSet ds;

        public EmployeeDBAccess()
        {

            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        
         }

        //Select Department Name and Department ID
       

        public  List<SelectListItem> PopulateDepartment()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.StoredProcedure;
            cmd.Parameters.AddWithValue("@checktype", 4);
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                items.Add(new SelectListItem
                {
                    Text = dr["Department"].ToString(),
                    Value = dr["DeptID"].ToString()
                });
            }
            con.Close();
            return items;

        }


        //Insert Employee
        public int InsertEmployee(HttpPostedFileBase file, EmployeeModal employee)
        { 
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@department", employee.DeptId);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);

            cmd.Parameters.AddWithValue("@email", employee.Email);
            cmd.Parameters.AddWithValue("@contact", employee.Contact);

            // employee._Image = ConvertToBytes(file);

            //Upload Iamge to the File folder
            string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/File");

            string filename = Path.GetFileName(file.FileName);
            string fullpath = Path.Combine(path, filename);
            file.SaveAs(fullpath);




            cmd.Parameters.AddWithValue("@address", employee.Address);




            cmd.Parameters.AddWithValue("@image", "~\\App_Data\\File\\"+filename);
          
            cmd.Parameters.AddWithValue("@checktype", 3);
            int result = cmd.ExecuteNonQuery();
            return result;
           
        }

        //private byte[] ConvertToBytes(HttpPostedFileBase image)
        //{
        //    byte[] imageBytes = null;
        //    BinaryReader reader = new BinaryReader(image.InputStream);
        //    imageBytes = reader.ReadBytes((int)image.ContentLength);
        //    return imageBytes;
        //}
    }
}