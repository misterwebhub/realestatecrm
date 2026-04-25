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
public partial class admin_adminhome1 : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*string id = "";
            if (Session["ID"] != null)
            {
                id= Session["ID"].ToString();
                //Label13.Text = "heedrealestate";
            }
            else
            {
                Response.Redirect("../admin.aspx");
            }
           // id = "CK001";*/
            bind();
            bind1();

            // gridbind();
        }
    }
    public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1 where arazino not in(select DISTINCT arazino from softploted1)", con);
        DataSet ds1 = new DataSet();
        da.Fill(ds1);
        con.Close();
        DropDownList2.Items.Add("--select--");
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds1.Tables[0].Rows[i][0].ToString());
        }



    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi from chainarazi where arazi='"+DropDownList2.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            int r = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                   
                   r = 1;
                }
                else
                {
                    r = 0;
                }
            }
            else
            {
                r = 0;
            }
            if (r == 0)
            {
               
                con.Open();
               
                SqlCommand cmd1 = new SqlCommand("insert into chainarazi (arazi)values('"+DropDownList2.Text+"')", con);
                cmd1.ExecuteNonQuery();
                string message = "Arazi Added";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                bind1();
            }
            else
            {
                string message = "Arazi Already Exist";
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        // bind1();
    }
    public void bind1()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select ID,arazi from chainarazi", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
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

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("formid") as Label;
        // TextBox name = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
        //TextBox city = GridView1.Rows[e.RowIndex].FindControl("txt_City") as TextBox;
        SqlConnection con;
        con = new SqlConnection(s);
        con.Open();
        //updating the record  
        SqlCommand cmd = new SqlCommand("delete from  chainarazi where ID=" + id.Text + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        //GridView1.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        bind1();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bind1();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

       

    }
    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {


        string formid = (GridView1.SelectedRow.FindControl("formid") as Label).Text;
        //string formid = GridView1.SelectedRow.Cells[1].Text;

        //Accessing TemplateField Column controls.

      

    }
    
}