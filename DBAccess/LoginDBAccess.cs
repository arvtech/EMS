using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpMngSys.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using EmpMngSys.DBAccess;

namespace EmpMngSys.DBAccess
{
    
    public class LoginDBAccess
    {
        //sql object declaration

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataSet ds;
     public   LoginDBAccess()
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }

        //Login - Select Username and Password
        public DataSet LoginUser(LoginModel loginmodel)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.StoredProcedure;
            cmd.Connection = con;
            
            cmd.Parameters.AddWithValue("@username", loginmodel.Username);
            cmd.Parameters.AddWithValue("@password", loginmodel.Password);
            cmd.Parameters.AddWithValue("@checktype", 1);
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            ds = new DataSet();
            adpt.Fill(ds);
           
            return ds;
            
          

        }
        
    }
}