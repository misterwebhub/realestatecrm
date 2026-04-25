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

public partial class admin_agenthome_selfbusin : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar9"].ConnectionString.ToString();
   public static  string idrt5="";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["ID"] != null)
        {
            idrt5 = Session["ID"].ToString();
            bind6();
        
        }
   }

    public void bind6()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
           SqlDataAdapter da = new SqlDataAdapter("select formid,name,agentid,spname,mobile,aletrmobile,email,address,father,gender,dob,pan,noname,bankname,branch,ifsc,account,adharpath,panpath,chequepath from agent where formid='"+idrt5+"'",con);
           DataSet ds = new DataSet();
           da.Fill(ds);
           con.Close();
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0][1].ToString() != "")
               {
                   Label1.Text = ds.Tables[0].Rows[0][1].ToString();
               }
               if (ds.Tables[0].Rows[0][0].ToString() != "")
               {
                   Label2.Text = ds.Tables[0].Rows[0][0].ToString();
               }
               if (ds.Tables[0].Rows[0][2].ToString() != "")
               {
                   Label3.Text = ds.Tables[0].Rows[0][2].ToString();
               }
               if (ds.Tables[0].Rows[0][3].ToString() != "")
               {
                   Label4.Text = ds.Tables[0].Rows[0][3].ToString();
               }
               if (ds.Tables[0].Rows[0][4].ToString() != "")
               {
                   Label5.Text = ds.Tables[0].Rows[0][4].ToString() + "," + ds.Tables[0].Rows[0][5].ToString();
               }
               if (ds.Tables[0].Rows[0][6].ToString() != "")
               {
                   Label6.Text = ds.Tables[0].Rows[0][6].ToString();
               }
               if (ds.Tables[0].Rows[0][7].ToString() != "")
               {
                   Label7.Text = ds.Tables[0].Rows[0][7].ToString();
               }
               if (ds.Tables[0].Rows[0][8].ToString() != "")
               {
                   Label12.Text = ds.Tables[0].Rows[0][8].ToString();
               }
               if (ds.Tables[0].Rows[0][9].ToString() != "")
               {
                   Label13.Text = ds.Tables[0].Rows[0][9].ToString();
               }
              
               if (ds.Tables[0].Rows[0][10].ToString() != "")
               {
                   DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0][10].ToString());
                   //string date222 = "";
                   if (dt != null)
                   {
                       Label14.Text = dt.ToString("dd/MM/yyyy");
                   }  
               }
               if (ds.Tables[0].Rows[0][11].ToString() != "")
               {
                   Label15.Text = ds.Tables[0].Rows[0][11].ToString();
               }
               if (ds.Tables[0].Rows[0][12].ToString() != "")
               {
                   Label16.Text = ds.Tables[0].Rows[0][12].ToString();
               }
               if (ds.Tables[0].Rows[0][13].ToString() != "")
               {
                   Label8.Text = ds.Tables[0].Rows[0][13].ToString();
               }
               if (ds.Tables[0].Rows[0][14].ToString() != "")
               {
                   Label9.Text = ds.Tables[0].Rows[0][14].ToString();
               }
               if (ds.Tables[0].Rows[0][15].ToString() != "")
               {
                   Label10.Text = ds.Tables[0].Rows[0][15].ToString();
               }
               if (ds.Tables[0].Rows[0][16].ToString() != "")
               {
                   Label11.Text = ds.Tables[0].Rows[0][16].ToString();
               }
               if (ds.Tables[0].Rows[0][17].ToString() != "")
               {
                   Image1.ImageUrl = ds.Tables[0].Rows[0][17].ToString();
               }
               if (ds.Tables[0].Rows[0][18].ToString() != "")
               {
                   Image2.ImageUrl = ds.Tables[0].Rows[0][18].ToString();
               }
               if (ds.Tables[0].Rows[0][19].ToString() != "")
               {
                   Image3.ImageUrl = ds.Tables[0].Rows[0][19].ToString();
               }
           }
          
        
    }
 
   
}