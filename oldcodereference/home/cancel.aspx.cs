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
using System.Drawing;
public partial class cancel : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            con.Close();


        }
    }
    public void bind()
    {

        GridView2.Visible = true;

        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,PLOTSIZE,plotno,date3,LEFT(NAMEDOBADDRESS,25) AS 'NAME',CHECKBY,mobile,regstatus,deletedate from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND regstatus='Cancel'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView2.DataSource = ds;
        GridView2.DataBind();

        con.Close();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView2.Visible = true;

        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,PLOTSIZE,plotno,date3,LEFT(NAMEDOBADDRESS,25) AS 'NAME',CHECKBY,mobile,regstatus,deletedate from wjstar1.customerreg1 where  regstatus='Cancel'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView2.DataSource = ds;
        GridView2.DataBind();

        con.Close();
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gr = GridView2.SelectedRow;
        String id = gr.Cells[1].Text;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO AS 'REGNO',LEFT(r.ASSADDRESS,20) AS 'ADDRESS',r.PLANTERM AS 'PLAN',r.EXPLANDVALUE AS 'VALUE',r.RECIPT,r.DATE,r.INSTNO,r.AMOUNTR,CONCAT(r.mobile,' , ',u.mobile2) AS 'Mobile No',u.APPNO AS 'ARAZI NO' from returnrecipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" +id+ "'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        GridView3.DataSource = ds;
        GridView3.DataBind();
        con1.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(AMOUNTR) from returnrecipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + id + "'", con1);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        Label1.Text = ds2.Tables[0].Rows[0][0].ToString();
        con1.Close();

    }
   
}