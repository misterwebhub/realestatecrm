﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;
using System.IO;
using System.Drawing;

public partial class chain_system_admin_agenthome_mappdf : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            ARAZIBIND();
           
        }
    }
   
    public void ARAZIBIND()
    {
      
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1 where arazino in(select arazi from chainarazi)", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
      //  con.Close();
      
        DropDownList2.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
           
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = true;
    }
 
   
    protected void Button4_Click(object sender, EventArgs e)
    {
        bind();
    }
    public void bind()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select PID,date,SUBSTRING(path,54,len(path)) AS 'path' from pdfmap where arazi='" + DropDownList2.Text + "' order by date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }



    }

  protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/pdfmap/") + e.CommandArgument);
            Response.End();
        }
    }
    
}