﻿﻿using System;
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
public partial class arazi385KA_raghunathdeedadd : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public static double final = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind4();
            demo3();
        }
    }
    public void bind4()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazi from addarazidemo where name='RAGHUNATH'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        con.Close();
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select deedno from ragistrydetails where arazi='" + DropDownList1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select distinct deedcombine from ragistrydetails where arazi='" + DropDownList1.Text + "'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            con.Close();
            List<string> AuthorList = new List<string>();
            DropDownList2.Items.Clear();
            AuthorList.Add("---select---");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AuthorList.Add(ds.Tables[0].Rows[i][0].ToString());
                // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                AuthorList.Add(ds1.Tables[0].Rows[i][0].ToString());
                // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            con.Close();
            
            DropDownList2.DataSource = AuthorList;
            DropDownList2.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
                     con.Open();
                     SqlCommand cmd = new SqlCommand("insert into raghunathdeed(arazi,deedno)values('"+DropDownList1.Text+"','"+DropDownList2.Text+"')", con);
                     int i = cmd.ExecuteNonQuery();
                     if (i != 0)
                     {
                         Label1.Text = "Record Added";
                         demo3();
                     }
                     else
                     {
                         Label1.Text = "Error";
                     }
                 }
    public void demo3()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from raghunathdeed", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from raghunathdeed where id="+TextBox1.Text+"", con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            Label1.Text = "Record Delete";
            demo3();
        }
        else
        {
            Label1.Text = "Error";
        }
    }
}