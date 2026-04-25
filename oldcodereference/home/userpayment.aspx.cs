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

public partial class kishan_userpayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        String id="";
       
        if (!IsPostBack)
        {
           // id = Session["ID"].ToString();
          id = "Ashok8396";
            bind(id);
           
        }
    }
    public void bind(String id)
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT username FROM logininfo", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
              if (id == "heedrealestate")
            {
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                     DropDownList1.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
                }
            }
            else
            {
                DropDownList1.Items.Add(id);

            }
           
        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
           
            string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox2.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string date2 = mm1 + "/" + dd1 + "/" + yy1;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da = new SqlDataAdapter("select ID,username,datefrom,dateto,recdate,recamount,reason from userreciveamount where username='" + DropDownList1.Text + "' AND recdate BETWEEN '" + date1 + "' AND '" + date2 + "' ORDER BY recdate ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.AMOUNTR) AS 'AMOUNT' from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.usertype='" + DropDownList1.Text + "'", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            
             Double d4=0,fil=0,d7=0;
           // Label3.Text = ds2.Tables[0].Rows[0][0].ToString();
           // Double d2 = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            if (ds2.Tables[0].Rows[0][0].ToString()!="")
            {
                d4 = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                d4 = 0;
            }
            Double d5 =d4;
            Label3.Text = d5.ToString();
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("select sum(recamount) from userreciveamount where username='" + DropDownList1.Text + "' AND recdate BETWEEN '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            Double d3 = d5 - d;
            Label4.Text = d3.ToString();
            Label2.Text = d.ToString();
            Label7.Text = Label2.Text;
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con1.Open();

     SqlDataAdapter da3 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' AND chequenopay NOT IN('0') AND usertype='" + DropDownList1.Text + "'", con1);
           
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con1.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                Label5.Text = ds3.Tables[0].Rows[0][0].ToString();
                d7 = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
            }
            fil = d5-d7;
            Label6.Text = fil.ToString();
            Double restamt = fil - d;
            Label8.Text = restamt.ToString();
        }
        catch (Exception t)
        {
            Label1.Text = "error" + t;
        }

    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("id20");
            Label lblname1 = (Label)e.Row.FindControl("id21");
            lblname.Style.Add("color", "red");
            lblname1.Style.Add("color", "green");
        }
    }
}