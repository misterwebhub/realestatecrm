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

using System.IO;
public partial class admin_approval : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar9"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select ID,protype  ,prosize  ,prorate  ,prolocation  ,proremark  ,promobile  ,proname  ,proaddress  , '~/propertyimage/'+proimage1 AS proimage1, '~/propertyimage/'+proimage2 AS proimage2,status from propertypost", con);
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
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bind();
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
       
        DropDownList status = GridView1.Rows[e.RowIndex].FindControl("ddlprice") as DropDownList;
       
        SqlConnection con;
        con = new SqlConnection(s);

        //updating the record  

        if (status.Text == "ACTIVE")
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update propertypost set status='" + status.Text + "' where ID=" + Convert.ToInt32(id.Text), con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            SqlDataAdapter da = new SqlDataAdapter("select proimage1,proimage2 from propertypost where ID=" + Convert.ToInt32(id.Text), con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            string he1 = "", he2 = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    he1 = "'~/propertyimage/'" + ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    he1 = "";
                }

                if (ds.Tables[0].Rows[0][1].ToString() != "")
                {
                    he2 = "'~/propertyimage/'" + ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    he2 = "";
                }
            }
            string path = Server.MapPath(he1);
            FileInfo file = new FileInfo(path);
            if (file.Exists)//check file exsit or not  
            {
                file.Delete();
                string message = "File Deleted ";
            }
            string path1 = Server.MapPath(he2);
            FileInfo file1 = new FileInfo(path1);
            if (file1.Exists)//check file exsit or not  
            {
                file1.Delete();
                string message1 = "File Deleted ";
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("Update propertypost set proimage1=null,proimage2=null,status='" + status.Text + "' where ID=" + Convert.ToInt32(id.Text), con);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
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
        SqlCommand cmd = new SqlCommand("delete from  propertypost where ID=" + Convert.ToInt32(id.Text) + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        //GridView1.EditIndex = -1;
        //Call ShowData method for displaying updated data  
       bind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                con.Open();
                DropDownList ddlprod = (DropDownList)e.Row.FindControl("ddlprice");
                HiddenField hdnval = (HiddenField)e.Row.FindControl("hdnprice");
                

                ddlprod.Items.Add("--select--");
                ddlprod.Items.Add("ACTIVE");
                ddlprod.Items.Add("INACTIVE");
               


            }
        }
    }
}