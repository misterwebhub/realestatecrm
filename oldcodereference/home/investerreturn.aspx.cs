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

public partial class investerreturn : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
        bind();
        bid();
	   }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "CASH")
        {
            TextBox7.Text = "CASH";
            TextBox4.Text = "No DATE";
        }
        if (DropDownList1.Text == "CHEQUE")
        {
            TextBox7.Text = "";
            TextBox4.Text = "";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel3.Visible = false;
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        Panel1.Visible = false;
        TextBox16.Text = "";
        Label6.Text = "";
        Label5.Text = "";
        Label3.Text = "";
    }
    public void bind()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter cmd1 = new SqlDataAdapter("select id,date,name,reason,type,damount,status,cdate,arazi,status1  from  wjstar1.invester  where status='Dr' ORDER BY date ASC", con1);
        DataSet ds1 = new DataSet();
        cmd1.Fill(ds1);
        con1.Close();
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con1.Open();
        SqlDataAdapter cmd2 = new SqlDataAdapter("select sum(amount),sum(damount) from   wjstar1.invester where status='Dr' ", con1);
        DataSet ds2 = new DataSet();
        cmd2.Fill(ds2);
        con1.Close();
        Label4.Text = ds2.Tables[0].Rows[0][0].ToString();
        Label7.Text = ds2.Tables[0].Rows[0][1].ToString();
        
    }
    public void bid()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from chequekishan", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());


        }
        con.Close();



    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);

        con.Open();
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        SqlCommand cmd = new SqlCommand("insert into wjstar1.invester(date,name,type,amount,damount,cdate,arazi,status,status1,reason)values('" + date1 + "','" + TextBox2.Text + "','" + TextBox7.Text + "',0," + TextBox3.Text + ",'" + TextBox4.Text + "','"+DropDownList2.Text+"','Dr','"+DropDownList3.Text+"','"+TextBox17.Text+"')", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label1.Text = "Record Added Successfully";
            bind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            //TextBox5.Text = "";
            // TextBox6.Text = "";
            TextBox7.Text = "";
        }
        else
        {
            Label1.Text = "due to internal problem";
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Label4.Text = "";
		 Label7.Text = "";
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter cmd1 = new SqlDataAdapter("select id,date,name,reason,type,amount,damount,status,cdate,arazi,status1 from wjstar1.invester  where name LIKE '" + TextBox16.Text + "%' AND status='Dr' ORDER BY date ASC", con1);
        DataSet ds1 = new DataSet();
        cmd1.Fill(ds1);
        con1.Close();
        con1.Open();
        SqlDataAdapter cmd2 = new SqlDataAdapter("select sum(damount) from wjstar1.invester where name LIKE'" + TextBox16.Text + "%' AND status='Dr'", con1);
        DataSet ds2 = new DataSet();
        cmd2.Fill(ds2);
        con1.Close();
        con1.Open();
       
        SqlDataAdapter cmd3 = new SqlDataAdapter("select sum(amount) from wjstar1.invester where name LIKE'" + TextBox16.Text + "%'", con1);
        DataSet ds3 = new DataSet();
        cmd3.Fill(ds3);
        con1.Close();
        Label3.Text = ds2.Tables[0].Rows[0][0].ToString();
        Label5.Text = ds3.Tables[0].Rows[0][0].ToString();
        Double d = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString()) - Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        Label6.Text = d.ToString();
        GridView1.DataSource = ds1;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblstatus = (Label)e.Row.FindControl("st1");
            


            if (lblstatus.Text == "UNPAID")
            {

                lblstatus.Style.Add("color", "red");

            }
           
        }
    }
}