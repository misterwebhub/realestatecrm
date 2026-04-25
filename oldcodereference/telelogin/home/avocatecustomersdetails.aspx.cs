using System;
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


public partial class ragistry_customersdetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindl();
            //demo();

        }
    }
    public void bindl()
    {
        DropDownList1.Items.Clear();

        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();

    }
    public void bind2()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select CID,date,name1,name2,name3,plotno,plotsize,SUBSTRING(path,69,len(path)) AS 'path',LEFT(deedno,5) AS 'deedno' from customerdeed where arazi='" + DropDownList1.Text + "' order by date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select count(plotsize) from customerdeed where arazi='" + DropDownList1.Text + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Label8.Text = ds1.Tables[0].Rows[0][0].ToString();


    }
    public void bind()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select CID,date,name1,name2,name3,plotno,plotsize,SUBSTRING(path,69,len(path)) AS 'path',LEFT(deedno,5) AS 'deedno' from customerdeed where arazi='" + DropDownList1.Text + "' AND deedno='" + DropDownList2.Text + "' order by date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select count(plotsize) from customerdeed where arazi='" + DropDownList1.Text + "' AND deedno='" + DropDownList2.Text + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Label8.Text = ds1.Tables[0].Rows[0][0].ToString();


    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Double tot = 0, sol = 0, bal = 0,road=0,balance=0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT buyby,date ,total,saleby,roadland from ragistrydetails where arazi='" + DropDownList1.Text + "' AND deedno='" + DropDownList2.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Label1.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label1.Text = "";
            }
            if (ds.Tables[0].Rows[0][4].ToString() != "")
            {
                Label9.Text = ds.Tables[0].Rows[0][4].ToString();
                road = Convert.ToDouble(Label9.Text);
            }
            else
            {
                Label9.Text = "0";
            }
            if (ds.Tables[0].Rows[0][2].ToString() != "")
            {
                Label3.Text = ds.Tables[0].Rows[0][2].ToString();
                tot = Convert.ToDouble(Label3.Text);
            }
            else
            {
                Label3.Text = "0";
            }
            if (ds.Tables[0].Rows[0][3].ToString() != "")
            {
                Label7.Text = ds.Tables[0].Rows[0][3].ToString();

            }
            else
            {
                Label7.Text = "0";
            }
            string dr = "";
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                dr = ds.Tables[0].Rows[0][1].ToString();
                dr = dr.Substring(0, 10);
                Label2.Text = dr;

            }
            else
            {
                Label2.Text = "0";
            }
        }
        else
        {
            Label6.Text = "Buyer Name Not Find";
        }
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(plotsize) from customerdeed where arazi='" + DropDownList1.Text + "' AND deedno='" + DropDownList2.Text + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label4.Text = ds1.Tables[0].Rows[0][0].ToString();
                sol = Convert.ToDouble(Label4.Text);
            }
            else
            {
                Label4.Text = "0";
            }

        }
        else
        {
            Label6.Text = "No Plot Booked";
        }
        balance = tot - road;
        bal = balance - sol;
        Label10.Text = balance.ToString();
        Label5.Text = bal.ToString();
        bind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT deedno from ragistrydetails where arazi='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList2.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       

        e.Row.Cells[6].ForeColor = System.Drawing.Color.Blue;
 e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
		e.Row.Cells[1].Font.Bold = true;
        e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string customerId = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string constr = ConfigurationManager.ConnectionStrings["amar"].ConnectionString;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT path from customerdeed where CID='" + customerId + "'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        string path = ds.Tables[0].Rows[0][0].ToString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM customerdeed WHERE CID = @CustomerId"))
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
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string customerId = GridView1.DataKeys[e.RowIndex].Values[0].ToString();

        string n1 = (row.Cells[3].Controls[0] as TextBox).Text;
        string n2 = (row.Cells[4].Controls[0] as TextBox).Text;
        string n3 = (row.Cells[5].Controls[0] as TextBox).Text;

        string date = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].FindControl("txtDOB")).Text;
        string plotno = (row.Cells[6].Controls[0] as TextBox).Text;
        string plotsize = (row.Cells[7].Controls[0] as TextBox).Text;
        string constr = ConfigurationManager.ConnectionStrings["amar"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE customerdeed SET date=@date,name1=@name1,name2=@name2 ,name3=@name3,plotno=@plotno,plotsize=@plotsize  WHERE CID = @CustomerId"))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@name1", n1);
                cmd.Parameters.AddWithValue("@name2", n2);
                cmd.Parameters.AddWithValue("@name3", n3);
                cmd.Parameters.AddWithValue("@plotno", plotno);
                cmd.Parameters.AddWithValue("@plotsize", plotsize);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        GridView1.EditIndex = -1;
        bind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/ragistry/customerdeed/") + e.CommandArgument);
            Response.End();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        Double tot = 0, sol = 0, bal = 0;
        
       
                Label1.Text ="0";
           
            
                Label3.Text ="0";
               
            
                Label7.Text ="0";

            
           
                Label2.Text = "0";

            
        
       
            
       
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(plotsize) from customerdeed where arazi='" + DropDownList1.Text + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label4.Text = ds1.Tables[0].Rows[0][0].ToString();
                sol = Convert.ToDouble(Label4.Text);
            }
            else
            {
                Label4.Text = "0";
            }

        }
        else
        {
            Label6.Text = "No Plot Booked";
        }
        bal = tot - sol;
        Label5.Text = bal.ToString();
        bind2();
    }
}