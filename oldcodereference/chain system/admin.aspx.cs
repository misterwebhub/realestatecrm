﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Globalization;
using System.Drawing;

public partial class admin : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select formid,password from agent where formid='"+username.Text+"' AND password='"+password.Text+"' ", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
       if(ds.Tables[0].Rows.Count>0)
       {
           if (ds.Tables[0].Rows[0][0].ToString() != "" && ds.Tables[0].Rows[0][1].ToString() != "")
           {
               if (ds.Tables[0].Rows[0][0].ToString() == "CHK001")
               {
                   Session["ID"] = username.Text;
                   Response.Redirect("~/chain system/admin/adminhome.aspx");
                   Session.RemoveAll();
               }
               else
               {
                   Session["ID"] = username.Text;
                   Response.Redirect("~/chain system/admin/agenthome/AgentHome.aspx");
              
                   Session.RemoveAll();
               }
           }
           else
           {
               Label1.Text = "PLease Enter Correct Details";

           }
        }
        else
        {
            Label1.Text = "PLease Enter Correct Details";
            
        }
    }
}