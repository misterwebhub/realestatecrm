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

           
        }
    }
    public void newbind(String cheq)
    {
        SqlConnection con = new SqlConnection(s);


        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazi,name AS 'name',date,amount,cheqno,refno,status,reason from kishanrecipt where paymode='CHEQUE' AND cheqno='"+cheq+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                GridView3.DataSource = ds;
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
        }
        else
        {
            GridView3.DataSource = null;
            GridView3.DataBind();
        }

        
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select invid AS 'id',date,name,reason,type,amount,chkno,refby,status,reason from investerrecipt where paymode='CHEQUE' AND chkno='" + cheq + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();

        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                GridView4.DataSource = ds1;
                GridView4.DataBind();
            }
            else
            {
                GridView4.DataSource = null;
                GridView4.DataBind();
            }
        }
        else
        {
            GridView4.DataSource = null;
            GridView4.DataBind();
        }

     
    }
    public void oldbind(String cheq)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
           
              
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select arazi,kname,date,name,amount,chequeno,status from chequetrans where chequeno='"+cheq+"'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
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
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            
            
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("select id,date,name,reason,type,amount,damount,status1 from wjstar1.invester where type='"+cheq+"' ", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close(); 
                GridView2.DataSource = ds1;
                GridView2.DataBind();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][0].ToString() != "")
                    {
                        GridView2.DataSource = ds1;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
           
            
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cheq;
        if (TextBox1.Text != "")
        {
            cheq = TextBox1.Text;
            oldbind(cheq);
            newbind(cheq);
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
            GridView3.DataSource = null;
            GridView3.DataBind();
            GridView4.DataSource = null;
            GridView4.DataBind();
        }
      

    }
}