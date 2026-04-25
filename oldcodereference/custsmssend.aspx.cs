﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

public partial class smssend : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
       DateTime r = DateTime.Now;
       string m = r.Month.ToString() ;
       string y = r.Year.ToString();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,ARAZI,PLOTNO,CDATE,CHEQUENO,CAMOUNT from chequedetails where STATUS='UNPAID' AND month(CDATE)=" +m + " AND year(CDATE)=" + y + "", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        String data = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            data = data + ds.Tables[0].Rows[i][0].ToString()+" * ";
            data = data + ds.Tables[0].Rows[i][1].ToString() + " * ";
            data = data + ds.Tables[0].Rows[i][2].ToString() + " * ";
           
            data = data + ds.Tables[0].Rows[i][3].ToString() + " * ";
            data = data + ds.Tables[0].Rows[i][4].ToString() + " *";
            data = data + ds.Tables[0].Rows[i][5].ToString() + " * ";
			
        }
        Label1.Text = data;
            
       // Response.Redirect("http://sms.webguard.in/api/sendhttp.php?authkey=330026A7runOjvu5f533531P1&mobiles=9129822343&message=REMINDER SMS'"+data +"'HEED REAL ESTATE&sender=HEEDKP&route=4&DLT_TE_ID=1207162356605424724");
      
    }
}