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

public partial class chequebounce : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from chequebounce where CUSTREGNO='" + TextBox1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,LEFT(NAMEDOBADDRESS,20) AS NAME,APPNO,PLOTSIZE,plotno from wjstar1.customerreg1 where CUSTREGNO='"+TextBox1.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "";
            Label2.Text = ds.Tables[0].Rows[0][0].ToString();
            Label3.Text = ds.Tables[0].Rows[0][1].ToString();
            Label4.Text = ds.Tables[0].Rows[0][2].ToString();
            if (ds.Tables[0].Rows[0][4].ToString() != "")
            {
                Label5.Text = ds.Tables[0].Rows[0][4].ToString();
            }
            else
            {
                Label5.Text = "0";
            }
            if (ds.Tables[0].Rows[0][3].ToString() != "")
            {
                Label6.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            else
            {
                Label6.Text = "0";
            }
            bind();
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox6.Text = "";
        }
        else
        {
            Label1.Text = "Reg No. Not Found";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string s3 = TextBox2.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string ck = mm1 + "/" + dd1 + "/" + yy1;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO from chequebounce where CUSTREGNO='" + TextBox1.Text + "' AND chequeno='" + TextBox3.Text + "' AND srno="+TextBox6.Text+"", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "Cheque Already Exist";
        }
        else
        {
            Label1.Text = "";
            SqlCommand cmd = new SqlCommand("insert into chequebounce(CUSTREGNO,name,arazi,plotno,plotsize,chequedate,chequeno,chequeamt,status,srno)values('" + Label2.Text + "','" + Label3.Text + "','" + Label4.Text + "','" + Label5.Text + "','" + Label6.Text + "','" + ck + "','" + TextBox3.Text + "'," + TextBox4.Text + ",'" + TextBox5.Text + "',"+TextBox6.Text+")", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                Label1.Text = "Record Added";
                SqlCommand cmd1 = new SqlCommand("update chequedetails set BSTATUS='BOUNCE',BDATE='"+ck+ "' where CHEQUENO='"+ TextBox3.Text + "' AND CUSTREGNO='"+TextBox1.Text+"'", con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                bind();
            }
            else
            {
                Label1.Text = "Error";
            }
        }
       
    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select CHEQUENO,CAMOUNT from  chequedetails where CUSTREGNO='" + TextBox1.Text + "'  AND STATUS='UNPAID'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        int rty = 0, amtcheck = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (TextBox3.Text == ds.Tables[0].Rows[i][0].ToString())
                {
                    rty = 1;
                    amtcheck = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    break;
                }
            }
            if (rty == 0)
            {
                Label1.Text = "CHEQUE NOT FOUND";
                Label1.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                Label1.Text = "CHEQUE FOUND";
                Label1.ForeColor = System.Drawing.Color.Green;
                TextBox4.Text = amtcheck.ToString();
                //text(Convert.ToInt32(amtcheck));
            }
        }
        else
        {
            Label1.Text = "CHEQUE NOT FOUND";
            Label1.ForeColor = System.Drawing.Color.Red;
        }
    }
}