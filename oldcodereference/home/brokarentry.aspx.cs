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

public partial class kishan_brokarentry : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            add();
        }
    }
    public void add()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from brokarpage", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Label2.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into brokarpage(name,aadhar,mobile)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')", con1);
            int i = cmd.ExecuteNonQuery();
            con1.Close();
           

            if (i == 1)
            {
                Label1.Text = "Record added Sucessfully";
                add();
               
            }
            else
            {
                Label1.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Label2.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("delete from brokarpage where ID="+TextBox4.Text+"", con1);
            int i = cmd.ExecuteNonQuery();
            con1.Close();


            if (i == 1)
            {
                Label2.Text = "Record Deleted Sucessfully";
                add();

            }
            else
            {
                Label2.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label2.Text = "internal problem";
        }
    }
}