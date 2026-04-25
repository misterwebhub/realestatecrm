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

public partial class admin_agenthome_changepass : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
   public static string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            if (Session["ID"] != null)
            {

                id = Session["ID"].ToString();
                // bind2();
               
            }

            // bind2();
          


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        if (TextBox1.Text == TextBox2.Text)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update agent set password='" + TextBox1.Text + "' where formid='" + id + "'", con);
            int t = cmd.ExecuteNonQuery();
            if (t != 0)
            {
                string message = "Password has been updated";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
				   TextBox1.Text = ""; TextBox2.Text = "";
            }
        }
        else
        {
            string message = "Password does not mached";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }
    }
}