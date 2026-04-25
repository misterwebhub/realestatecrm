﻿﻿using System;
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


public partial class userexpense : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = "";
            bind();
        }
    }
    [WebMethod]
    public static List<string> GetAutoCompleteData(string username)
    {
        string s3 = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
        List<string> result = new List<string>();

        using (SqlConnection con = new SqlConnection(s3))
        {

            SqlCommand cmd = new SqlCommand("select DISTINCT name from bill where name like '" + username + "%'", con);
            con.Open();
            // cmd.Parameters.AddWithValue("@SearchText", username);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(dr["Name"].ToString());
            }
            return result;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel4.Visible = false;
        DateTime now = DateTime.Now;
        TextBox2.Text = now.ToShortDateString();
        Panel1.Visible = true;
       

        GridView2.Visible = true;
        // GridView4.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel4.Visible = false;
        DateTime now = DateTime.Now;
        TextBox6.Text = now.ToShortDateString();
        Panel2.Visible = true;

        GridView2.Visible = true;

        // GridView4.Visible = false;
    }
    public void bind()
    {
        try
        {
            GridView2.Visible = true;
            // DateTime now = DateTime.Today;
            // String s2= now.ToShortDateString();
            SqlConnection con = new SqlConnection(s);
            con.Open();
            DateTime d = DateTime.Today;

            SqlDataAdapter da = new SqlDataAdapter("select id,name,date,camount,damount,cstatus,creson from bill where date='" + d.ToString() + "' order by date ASC", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill ", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select amount from balance", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                Label9.Text = ds2.Tables[0].Rows[0][1].ToString();
                Label5.Text = ds2.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label2.Text = "0";
            }

            GridView2.DataSource = ds;
            GridView2.DataBind();


        }
        catch (Exception r)
        {

        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            int debibamt = 0;
            string dateString = TextBox2.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            string strdate = dateTime.ToString("mm/dd/yyyy");

            SqlCommand cmd2 = new SqlCommand("insert into bill(name,date,damount,camount,creson,cstatus)values('" + TextBox1.Text + "','" + strdate + "'," + debibamt + "," + TextBox3.Text + ",'" + TextBox4.Text + "','Cr')", con);
            int i = cmd2.ExecuteNonQuery();
            con.Close();
            if (i == 0)
            {
                Label1.Text = "internal problam";

            }
            else
            {
                Label1.Text = "Amount receive successfully added";
                SqlConnection con1 = new SqlConnection(s);

                String h = Label2.Text;
                string p = TextBox3.Text;
                Double am = Convert.ToDouble(h);
                Double y = Convert.ToDouble(p);
                Double u = am + y;

                if (h != "0")
                {
                    SqlCommand cmd3 = new SqlCommand("update balance set amount='" + u + "'  where id=1", con);
                    con.Open();
                    int i2 = cmd3.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("update balance set amount='" + y + "' where id=1", con);
                    con.Open();
                    int i2 = cmd3.ExecuteNonQuery();
                    con.Close();
                }

                bind();

            }
        }
        catch (Exception r)
        {
            Label1.Text = "internal problam";
        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            int creditamt = 0;
            string dateString = TextBox6.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            string strdate = dateTime.ToString("mm/dd/yyyy");
            SqlCommand cmd2 = new SqlCommand("insert into bill(name,date,damount,camount,creson,cstatus)values('" + TextBox5.Text + "','" + strdate + "'," + TextBox7.Text + "," + creditamt + ",'" + TextBox8.Text + "','Dr')", con);
            int i = cmd2.ExecuteNonQuery();
            con.Close();
            if (i == 0)
            {
                Label3.Text = "internal problam";

            }
            else
            {
                Label3.Text = "Amount Paid successfully added";
                SqlConnection con1 = new SqlConnection(s);

                String h = Label2.Text;
                string p = TextBox7.Text;
                Double am = Convert.ToDouble(h);
                Double y = Convert.ToDouble(p);
                Double u = am - y;

                if (h != "0")
                {
                    SqlCommand cmd3 = new SqlCommand("update balance set amount='" + u + "'  where id=1", con);
                    con.Open();
                    int i2 = cmd3.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("update balance set amount='" + u + "' where id=1", con);
                    con.Open();
                    int i2 = cmd3.ExecuteNonQuery();
                    con.Close();
                }

                bind();

            }
        }
        catch (Exception r)
        {
            Label3.Text = "internal problam";
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = false;
            // GridView3.Visible = false;
            GridView2.Visible = true;
            // GridView4.Visible = true;
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id,name,date,camount,damount,cstatus,creson from bill ORDER BY date ASC", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill ", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
                Label9.Text = ds2.Tables[0].Rows[0][1].ToString();
                Label5.Text = ds2.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                Label2.Text = "error";
            }





        }
        catch (Exception r)
        {

        }

    }

    protected void GridView2_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("name1");
            Label lbldate = (Label)e.Row.FindControl("date1");
            Label lbldamt = (Label)e.Row.FindControl("damount1");
            Label lblcamt = (Label)e.Row.FindControl("camount1");
            Label lblstatus = (Label)e.Row.FindControl("cstatus1");
            Label lblreson = (Label)e.Row.FindControl("creson1");


            if (lblstatus.Text == "Dr")
            {

                lbldamt.Style.Add("color", "red");

            }
            if (lblstatus.Text == "Cr")
            {

                lblcamt.Style.Add("color", "Green");

            }
        }
    }
  
    
   
    protected void Button11_Click1(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;

        Panel4.Visible = true;
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = true;
          
            // GridView3.Visible = false;
            GridView2.Visible = true;
            string dateString1 = TextBox15.Text;
            string dateString2 = TextBox16.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
            string ddd1 = dateTime1.ToString("mm/dd/yyyy");
            DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            string ddd2 = dateTime2.ToString("mm/dd/yyyy");
            // GridView4.Visible = true;
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id,name,date,camount,damount,cstatus,creson from bill where date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill where date between '" + ddd1 + "' AND '" + ddd2 + "' ", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
                Label9.Text = ds2.Tables[0].Rows[0][1].ToString();
                Label5.Text = ds2.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                Label8.Text = "error";
            }





        }
        catch (Exception r)
        {

        }
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = true;
            
            // GridView3.Visible = false;
            GridView2.Visible = true;
            // GridView4.Visible = true;
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id,name,date,camount,damount,cstatus,creson from bill where name like '" + TextBox17.Text + "%' order by date ASC", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill  where name like '" + TextBox17.Text + "%'", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
                Label9.Text = ds2.Tables[0].Rows[0][1].ToString();
                Label5.Text = ds2.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                Label8.Text = "error";
            }





        }
        catch (Exception r)
        {

        }
    }
   
    protected void Button15_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = true;
          
            // GridView3.Visible = false;
            GridView2.Visible = true;
            // GridView4.Visible = true;
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id,name,date,camount,damount,cstatus,creson from bill where creson like '" + TextBox18.Text + "%' order by date ASC", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill  where creson like '" + TextBox18.Text + "%'", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
                Label9.Text = ds2.Tables[0].Rows[0][1].ToString();
                Label5.Text = ds2.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                Label8.Text = "error";
            }





        }
        catch (Exception r)
        {

        }
    }
   
}