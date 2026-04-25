﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Web.Services;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;

public partial class kishan_totalcheque : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            oldbind();
            newbind();
        }
    }
    public void newbind()
    {
        SqlConnection con = new SqlConnection(s);


        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazi,name AS 'name',date,amount,cheqno,status,reason from kishanrecipt where paymode='CHEQUE'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();


        GridView3.DataSource = ds;
        GridView3.DataBind();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select invid AS 'id',date,name,reason,type,amount,chkno,status from investerrecipt where chkno IS NOT NULL", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();



        GridView4.DataSource = ds1;
        GridView4.DataBind();
    }
  public void oldbind()
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
           
              
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select arazi,kname,date,name,amount,chequeno,status from chequetrans where type='CHEQUE'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
              
               
                GridView1.DataSource = ds;
                GridView1.DataBind();
            
            
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("select id,date,name,reason,type,amount,damount,status1 from wjstar1.invester where type NOT IN ('CASH','RTGS','NEFT','TRGS','a/c.trancfer')", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close(); 
                GridView2.DataSource = ds1;
                GridView2.DataBind();
           
            
        }
        catch (Exception r)
        {
            //Label1.Text = "Internal server error";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("date6");



            if (lblname.Text == "PAID")
            {

                lblname.Style.Add("color", "green");

            }
            if (lblname.Text == "UNPAID")
            {

                lblname.Style.Add("color", "red");

            }

        }

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("d8");



            if (lblname.Text == "PAID")
            {

                lblname.Style.Add("color", "green");

            }
            if (lblname.Text == "UNPAID")
            {

                lblname.Style.Add("color", "red");

            }

        }
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("d16");



            if (lblname.Text == "PAID")
            {

                lblname.Style.Add("color", "green");

            }
            if (lblname.Text == "UNPAID")
            {

                lblname.Style.Add("color", "red");

            }

        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("date19");



            if (lblname.Text == "PAID")
            {

                lblname.Style.Add("color", "green");

            }
            if (lblname.Text == "UNPAID")
            {

                lblname.Style.Add("color", "red");

            }

        }
    }
}