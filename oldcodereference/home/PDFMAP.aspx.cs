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

public partial class arazi137ramipur_PDFMAP : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            ARAZIBIND();
            demo();
        }
    }
    public void demo()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select max(ID) from pdfmap", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        Double d = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
        d = d + 1;
        Label3.Text = "PDF00" + d.ToString();

    }
    public void ARAZIBIND()
    {
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("---SELECT----");
        DropDownList2.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
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
        Panel2.Visible =false;
        Panel1.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select PID from pdfmap where PID='" + Label1.Text + "'", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);


        con1.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "ID is Already Exist";
        }
        else
        {
            string s3 = TextBox1.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string ck = mm1 + "/" + dd1 + "/" + yy1;
            string folderPath = Server.MapPath("~/pdfmap/");

            //Check whether Directory (Folder) exists.
            String Path = "";
            if (FileUpload1.HasFile)
            {

                FileUpload1.SaveAs(folderPath + FileUpload1.FileName);

                Path = folderPath + FileUpload1.FileName;
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into pdfmap(PID,arazi,date,path)values('" + Label3.Text + "','" + DropDownList1.Text + "','" + ck + "','" + Path + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    Label1.Text = "Record Added";
                   // demo3();
                }
                else
                {
                    Label1.Text = "Error";
                }
            }
            else
            {
                Label1.Text = "No File Uploaded.";

            }
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        demo();
        Label1.Text = "";
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
   
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }
    }
    protected void GridView1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
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
    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        string customerId = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string constr = ConfigurationManager.ConnectionStrings["amar"].ConnectionString;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT path from pdfmap where PID='" + customerId + "'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        string path = ds.Tables[0].Rows[0][0].ToString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM pdfmap WHERE PID = @CustomerId"))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();

                }
                con.Close();
            }
        }
        bind();
    }
    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }
    protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string customerId = GridView1.DataKeys[e.RowIndex].Values[0].ToString();



        string date = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].FindControl("txtDOB")).Text;

        string constr = ConfigurationManager.ConnectionStrings["amar"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE pdfmap SET date=@date  WHERE PID = @CustomerId"))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@date", date);

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        GridView1.EditIndex = -1;
        bind();
    }
}