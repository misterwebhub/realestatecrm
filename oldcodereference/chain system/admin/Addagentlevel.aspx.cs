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
public partial class admin_Addagentlevel : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // bind2();
            bind();
        }
    }
       public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select ID,name,percentage  from agnettype", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
	protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);


        SqlCommand cmd = new SqlCommand("insert into agnettype (name,percentage)values('" + TextBox1.Text + "','" + TextBox2.Text + "')", con);

        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            TextBox1.Text = "";
            //  TextBox2.Text = "";
            bind();
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
        TextBox name = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
        TextBox par = GridView1.Rows[e.RowIndex].FindControl("txt_Par") as TextBox;
       // DropDownList drpgender = GridView1.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList;
        SqlConnection con;
        con = new SqlConnection(s);
        con.Open();
        //updating the record  
        SqlCommand cmd = new SqlCommand("Update agnettype set name ='" + name.Text + "',percentage='" +par.Text + "' where ID=" + Convert.ToInt32(id.Text), con);
        cmd.ExecuteNonQuery();
        con.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView1.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
        // TextBox name = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
        //TextBox city = GridView1.Rows[e.RowIndex].FindControl("txt_City") as TextBox;
        SqlConnection con;
        con = new SqlConnection(s);
        con.Open();
        //updating the record  
        SqlCommand cmd = new SqlCommand("delete from  agnettype  where ID=" + Convert.ToInt32(id.Text), con);
        cmd.ExecuteNonQuery();
        con.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        //GridView1.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        bind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }

}