﻿using System;
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

public partial class invester : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
        {
        bind();
        bid();
		}
    }
    [WebMethod]
    public static List<string> GetAutoCompleteData(string username)
    {
        string s3 = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
        List<string> result = new List<string>();

        using (SqlConnection con = new SqlConnection(s3))
        {

            SqlCommand cmd = new SqlCommand("select DISTINCT name from wjstar1.invester where name like '" + username + "%'", con);
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "CASH")
        {
            TextBox7.Text = "CASH";
            TextBox4.Text = "No DATE";
        }
        if (DropDownList1.Text == "CHEQUE")
        {
            TextBox7.Text = "";
            TextBox4.Text = "";
        }

    }
    public void bind()
    {
         SqlConnection con1 = new SqlConnection(s);
           con1.Open();
           SqlDataAdapter cmd1 = new SqlDataAdapter("select id,date,name,type,amount,damount,status,cdate,arazi,status1,reason from wjstar1.invester where status1='PAID' ORDER BY date ASC", con1);
            DataSet ds1 = new DataSet();
            cmd1.Fill(ds1);
            con1.Close();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            con1.Open();
            SqlDataAdapter cmd2 = new SqlDataAdapter("select sum(amount),sum(damount) from wjstar1.invester where status1='PAID'", con1);
            DataSet ds2 = new DataSet();
            cmd2.Fill(ds2);
            con1.Close();
            Label4.Text = ds2.Tables[0].Rows[0][0].ToString() ;
        Label6.Text=ds2.Tables[0].Rows[0][1].ToString();
           
    }
    public void bid()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from chequekishan", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
           

        }
        con.Close();



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        //TextBox5.Text = "";
       // TextBox6.Text = "";
        TextBox7.Text = "";
        Label1.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
       // TextBox13.Text = "";
        //TextBox14.Text = "";
        Label2.Text = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);

        con.Open();
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        SqlCommand cmd = new SqlCommand("insert into wjstar1.invester(date,name,type,amount,damount,cdate,arazi,status,status1,reason)values('" + date1 + "','" + TextBox2.Text + "','" + TextBox7.Text + "'," + TextBox3.Text + ",0,'" + TextBox4.Text + "','"+DropDownList3.Text+"','Cr','PAID',NULL)", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label1.Text = "Record Added Successfully";
            bind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            //TextBox5.Text = "";
           // TextBox6.Text = "";
            TextBox7.Text = "";
        }
        else
        {
            Label1.Text = "due to internal problem";
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);

        con.Open();
        
        SqlCommand cmd = new SqlCommand("delete from  wjstar1.invester where id="+TextBox15.Text+"", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label2.Text = "Record deleted Successfully";
            bind();
        }
        else
        {
            Label2.Text = "due to internal problem";
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.Text == "CASH")
        {
            TextBox10.Text = "CASH";
            TextBox12.Text = "No DATE";
        }
       
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter cmd1 = new SqlDataAdapter("select date,name,type,amount,damount,cdate,status,status1 from wjstar1.invester where id="+TextBox15.Text+"", con1);
        DataSet ds1 = new DataSet();
        cmd1.Fill(ds1);
        con1.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            TextBox8.Text = ds1.Tables[0].Rows[0][0].ToString();
            TextBox9.Text = ds1.Tables[0].Rows[0][1].ToString();
            TextBox10.Text = ds1.Tables[0].Rows[0][2].ToString();
            if (ds1.Tables[0].Rows[0][6].ToString() == "Cr")
            {
                TextBox11.Text = ds1.Tables[0].Rows[0][3].ToString();
            }
            if (ds1.Tables[0].Rows[0][6].ToString() == "Dr")
            {
                TextBox11.Text = ds1.Tables[0].Rows[0][4].ToString();
            }
            TextBox12.Text = ds1.Tables[0].Rows[0][5].ToString();
           Label7.Text= ds1.Tables[0].Rows[0][6].ToString();
           DropDownList4.Text = ds1.Tables[0].Rows[0][7].ToString();
            //TextBox14.Text = ds1.Tables[0].Rows[0][6].ToString();
        }
        else
        {
            Label2.Text = "Record not found";
        }

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        string d="";
        con.Open();
        string s2 = TextBox8.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        if (Label7.Text == "Cr")
        {
         d ="update wjstar1.invester set date='" + date1 + "',name='" + TextBox9.Text + "',type='" + TextBox10.Text + "',amount=" + TextBox11.Text + ",cdate='" + TextBox12.Text + "',status1='"+DropDownList4.Text+"' where id=" + TextBox15.Text + " ";
        }
        if (Label7.Text == "Dr")
        {
            d = "update wjstar1.invester set date='" + date1 + "',name='" + TextBox9.Text + "',type='" + TextBox10.Text + "',damount=" + TextBox11.Text + ",cdate='" + TextBox12.Text + "',status1='" + DropDownList4.Text + "' where id=" + TextBox15.Text + " ";
        }
        SqlCommand cmd = new SqlCommand(d,con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label1.Text = "Record Updated Successfully";
            bind();
        }
        else
        {
            Label1.Text = "due to internal problem";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        bind();
        Panel3.Visible = false;

    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
		Double cr=0,dr=0,bl=0;
        Label4.Text = "";
		 Label6.Text = "";
         Label52.Text = "";
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter cmd1 = new SqlDataAdapter("select id,date,name,type,amount,damount,status,cdate,arazi,status1,reason from wjstar1.invester where name LIKE'" + TextBox16.Text + "%'  ORDER BY date ASC", con1);
        DataSet ds1 = new DataSet();
        cmd1.Fill(ds1);
        con1.Close();
        con1.Open();
        SqlDataAdapter cmd2 = new SqlDataAdapter("select sum(amount),sum(damount) from wjstar1.invester where name LIKE'" + TextBox16.Text + "%' AND status1='PAID'", con1);
        DataSet ds2 = new DataSet();
        cmd2.Fill(ds2);
        con1.Close();
        con1.Open();
        SqlDataAdapter cmd21 = new SqlDataAdapter("select sum(damount) from wjstar1.invester where name LIKE'" + TextBox16.Text + "%' AND status1='UNPAID'", con1);
        DataSet ds21 = new DataSet();
        cmd21.Fill(ds21);
        con1.Close();
        Label3.Text = ds2.Tables[0].Rows[0][0].ToString();
        Label5.Text=ds2.Tables[0].Rows[0][1].ToString();
        Label52.Text = ds21.Tables[0].Rows[0][0].ToString();
		cr=Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
		dr=Convert.ToDouble(ds2.Tables[0].Rows[0][1].ToString());
							bl=cr-dr;
				Label51.Text=bl.ToString();	
		
        GridView1.DataSource = ds1;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            Label lbldamt = (Label)e.Row.FindControl("db1");
            Label lblcamt = (Label)e.Row.FindControl("cr1");
            Label lblstatus = (Label)e.Row.FindControl("st1");
            Label lblstatus1 = (Label)e.Row.FindControl("st51");


            if (lblstatus.Text == "Dr")
            {

                lbldamt.Style.Add("color", "red");

            }
            if (lblstatus.Text == "Cr")
            {

                lblcamt.Style.Add("color", "Green");

            }
            if (lblstatus1.Text == "UNPAID")
            {

                lblstatus1.Style.Add("color", "red");

            }
        }
    }
}