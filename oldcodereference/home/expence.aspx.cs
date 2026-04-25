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

public partial class expence : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
        {
            Label1.Text = "";
            bind();
            DropDownList8.Visible = false;
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
                result.Add(dr["name"].ToString());
            }
            return result;

        }
    }
    public void fud1()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select debitype from debittype", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("---Select---");
        DropDownList1.Items.Add("Customer Payment");
        // DropDownList5.Items.Add("Invester Payment");
        DropDownList1.Items.Add("Other Payment");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fud1();
        Panel2.Visible = false;
        Panel5.Visible = false;
        Panel4.Visible = false;
        DateTime now = DateTime.Now;
        TextBox2.Text = now.ToShortDateString();
        Panel1.Visible = true;
        Panel3.Visible = false;
        
        GridView2.Visible = true;
       // GridView4.Visible = false;
    }
    public void debittype()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select debitype from debittype", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("---Select---");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <ds.Tables[0].Rows.Count; i++)
            {
               
                DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        debittype();
        LinkButton2.Visible = false;
        DropDownList4.Visible = false;
        Panel5.Visible = false;
        Panel1.Visible = false;
        Panel4.Visible = false;
        Panel6.Visible = false;
        DateTime now = DateTime.Now;
        TextBox6.Text = now.ToShortDateString();
        Panel2.Visible = true;
        Panel3.Visible = false;
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

            SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where date IN(select TOP 5 date from bill order by date DESC) order by date DESC", con);
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
        catch(Exception r)
        {
            
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            String mode1="",chkn="";
            if (RadioButton1.Checked)
            {
                mode1 = RadioButton1.Text;
                chkn = "0";
            }
            
                if (RadioButton2.Checked)
            {
                mode1 = RadioButton2.Text;
                chkn =TextBox23.Text;
            }
            SqlConnection con = new SqlConnection(s);
            con.Open();
            int debibamt = 0;
            string dateString = TextBox2.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            string strdate = dateTime.ToString("mm/dd/yyyy");

            SqlCommand cmd2 = new SqlCommand("insert into bill(name,date,damount,camount,creson,cstatus,type,regno,arazino,upname,plotno,mode,chequeno)values('" + Label13.Text + "','" + strdate + "'," + debibamt + "," + TextBox3.Text + ",'" + TextBox4.Text + "','Cr','"+DropDownList1.Text+"','"+TextBox22.Text+"','"+Label11.Text+"','"+Label10.Text+"','"+Label12.Text+"','"+mode1+"','"+chkn+"')", con);
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
                Double y =Convert.ToDouble(p);
                Double u = am + y;

                if (h != "0")
                {
                    SqlCommand cmd3 = new SqlCommand("update balance set amount='" + u + "'  where id=1", con);
                    con.Open();
                    int i2 = cmd3.ExecuteNonQuery();
                    con.Close();
			Label13.Text="";
					TextBox3.Text="";
					TextBox4.Text="";
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("update balance set amount='" + y+ "' where id=1", con);
                    con.Open();
                    int i2 = cmd3.ExecuteNonQuery();
                    con.Close();
			Label13.Text="";
					TextBox3.Text="";
					TextBox4.Text="";
                }
               
                bind();

            }
        }
        catch(Exception r)
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
            String mode1 = "", chkn = "";
            if (RadioButton3.Checked)
            {
                mode1 = RadioButton3.Text;
                chkn = "0";
            }

            if (RadioButton4.Checked)
            {
                mode1 = RadioButton4.Text;
                chkn = TextBox24.Text;
            }
            SqlConnection con = new SqlConnection(s);
            con.Open();
            int creditamt = 0;
            string dateString = TextBox6.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            string strdate = dateTime.ToString("mm/dd/yyyy");
            //SqlCommand cmd2 = new SqlCommand("insert into bill(name,date,damount,camount,creson,cstatus,type,regno,arazino,upname,plotno,mode,chequeno)values('" + Label13.Text + "','" + strdate + "'," + debibamt + "," + TextBox3.Text + ",'" + TextBox4.Text + "','Cr','" + DropDownList1.Text + "','" + TextBox22.Text + "','" + Label11.Text + "','" + Label10.Text + "','" + Label12.Text + "','" + mode1 + "','" + chkn + "')", con);
           // int i = cmd2.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("insert into bill(name,date,damount,camount,creson,cstatus,type,regno,arazino,upname,plotno,mode,chequeno)values('" + Label18.Text + "','" + strdate + "'," + TextBox7.Text + "," + creditamt + ",'" + TextBox8.Text + "','Dr','"+DropDownList2.Text+"','"+TextBox26.Text+"','"+Label15.Text+"','"+Label16.Text+"','"+Label17.Text+"','"+mode1+"','"+chkn+"')", con);
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
                Double y =Convert.ToDouble(p);
                Double u = am - y;

                if (h != "0")
                {
                    SqlCommand cmd3 = new SqlCommand("update balance set amount='" + u + "'  where id=1", con);
                    con.Open();
                    int i2 = cmd3.ExecuteNonQuery();
                    con.Close();
					//TextBox5.Text="";
					TextBox7.Text="";
					TextBox8.Text="";
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("update balance set amount='" + u + "' where id=1", con);
                    con.Open();
                    int i2 = cmd3.ExecuteNonQuery();
                    con.Close();
					//TextBox5.Text="";
					TextBox7.Text="";
					TextBox8.Text="";
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
            SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill ORDER BY date ASC", con);
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
    protected void Button8_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel4.Visible = false;
        Panel3.Visible = true;
        TextBox14.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox13.Text = "";
        Label7.Text = "";
        
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        try
        {
            Panel4.Visible = false;
            Panel2.Visible = false;
            Panel1.Visible = false;
            // GridView3.Visible = false;
            GridView2.Visible = true;
            // GridView4.Visible = true;
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select name,date,camount,damount,cstatus,creson from bill where ID=" + TextBox13.Text + " ORDER BY date ASC", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox9.Text = ds.Tables[0].Rows[0][0].ToString();
                TextBox10.Text = ds.Tables[0].Rows[0][1].ToString();
                TextBox14.Text = ds.Tables[0].Rows[0][2].ToString();
                TextBox11.Text = ds.Tables[0].Rows[0][3].ToString();
                Label7.Text = ds.Tables[0].Rows[0][4].ToString();
                                    TextBox12.Text = ds.Tables[0].Rows[0][5].ToString();
            }
            else
            {
                Label6.Text = "Record not found";
            }
        }
        catch (Exception r)
        {
            Label6.Text = "error";
        }
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        try
        {
            
            // GridView3.Visible = false;
            GridView2.Visible = true;
            // GridView4.Visible = true;
            SqlConnection con = new SqlConnection(s);
            
            Double cr=0, dr=0,i=0;
            Double balamt=Convert.ToDouble(Label2.Text);
            if (Label7.Text == "Cr")
            {
                cr = Convert.ToDouble(TextBox14.Text);
                balamt = balamt - cr;
                con.Open();
                SqlCommand cmd = new SqlCommand("update balance set amount='" + balamt + "' where id=1", con);
                SqlCommand cmd1 = new SqlCommand("delete from bill where ID="+TextBox13.Text+"", con);
                i = cmd.ExecuteNonQuery();
                i = cmd1.ExecuteNonQuery();
                con.Close();
                bind();
            }
            if (Label7.Text == "Dr")
            {
                dr = Convert.ToInt32(TextBox11.Text);
                balamt = balamt+dr;
                con.Open();
                SqlCommand cmd = new SqlCommand("update balance set amount='" + balamt + "' where id=1", con);
                SqlCommand cmd1 = new SqlCommand("delete from bill where ID=" + TextBox13.Text + "", con);
                i = cmd.ExecuteNonQuery();
                i = cmd1.ExecuteNonQuery();
                con.Close();
                bind();
            }
            if (i != 0)
            {
                Label6.Text = "Record deleted Successfully";
                
            }
            else
            {
                Label6.Text = "Record Not deleted Successfully";
            }
           
            
        }
        catch (Exception r)
        {
            Label6.Text = "error";
        }
    }

    protected void Button11_Click1(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = true;

        DropDownList10.Visible =false;
        fud();
    }
    public void fud()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select debitype from debittype", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList5.Items.Clear();
        DropDownList9.Items.Clear();
        DropDownList5.Items.Add("---Select---");
        DropDownList5.Items.Add("Customer Payment");
       // DropDownList5.Items.Add("Invester Payment");
        DropDownList5.Items.Add("Other Payment");
        DropDownList9.Items.Add("---Select---");
        DropDownList9.Items.Add("Customer Payment");
        // DropDownList5.Items.Add("Invester Payment");
        DropDownList9.Items.Add("Other Payment");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                DropDownList5.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                DropDownList9.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = true;
            Panel3.Visible = false;
            // GridView3.Visible = false;
            GridView2.Visible = true;
            string dateString1 = TextBox15.Text;
            string dateString2 = TextBox16.Text;
            string format= "dd/mm/yyyy";
            DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
            string ddd1 = dateTime1.ToString("mm/dd/yyyy");
            DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            string ddd2 = dateTime2.ToString("mm/dd/yyyy");
            // GridView4.Visible = true;
            if (DropDownList5.Text == "KISHAN PAYMENT" || DropDownList5.Text == "INVESTER PAYMENT")
            {
                Label8.Text = "";
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where regno='" + DropDownList7.Text + "'  AND type='" + DropDownList5.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                con.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill where regno='" + DropDownList7.Text + "'  AND type='" + DropDownList5.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' ", con);
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
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
            }
            else
            {
                if (DropDownList5.Text == "ARAZI PAYMENT" || DropDownList5.Text == "OFFICE SALARY")
                {
                    Label8.Text = "";
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where upname='" + DropDownList7.Text + "'   AND  regno='" + DropDownList6.Text + "'  AND type='" + DropDownList5.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill where upname='" + DropDownList7.Text + "'   AND  regno='" + DropDownList6.Text + "'  AND type='" + DropDownList5.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' ", con);
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
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
                else
                {
                    Label8.Text = "";
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where type='" + DropDownList5.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill where type='" + DropDownList5.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' ", con);
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
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
            }





        }
        catch (Exception r)
        {

        }
    }
   
    protected void Button14_Click(object sender, EventArgs e)
    {
        try
        {

            // GridView3.Visible = false;
            GridView2.Visible = true;
            // GridView4.Visible = true;
            Double cramt=0, dramt=0;
            SqlConnection con = new SqlConnection(s);
            con.Open();
            string dateString = TextBox10.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            string ddd = dateTime.ToString("mm/dd/yyyy");
           
            
            SqlDataAdapter da = new SqlDataAdapter("select camount,damount from bill where ID=" + TextBox13.Text + "", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cramt =Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                dramt =Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                
            }

            Double cr = 0, dr = 0, i = 0;
           //Double balamt = Convert.ToInt32(Label2.Text);
con.Open();
            SqlDataAdapter da6 = new SqlDataAdapter("select amount from balance", con);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            con.Close();
			Double balamt=Convert.ToDouble(ds6.Tables[0].Rows[0][0].ToString());
			if (Label7.Text == "Cr")
            {
                Double rcramt = 0;
                cr = Convert.ToDouble(TextBox14.Text);
                rcramt = cramt - cr;
                balamt = balamt - rcramt;
                
                con.Open();
                SqlCommand cmd = new SqlCommand("update balance set amount='" + balamt + "' where id=1", con);
                SqlCommand cmd1 = new SqlCommand("update bill set name='" + TextBox9.Text + "',date='" + ddd + "',camount=" + cr + ",damount=" + dramt + ",creson='" + TextBox12.Text + "'  where ID=" + TextBox13.Text + "", con);
                i = cmd.ExecuteNonQuery();
                i = cmd1.ExecuteNonQuery();
                con.Close();
                bind();
            }
            if (Label7.Text == "Dr")
            {
                Double rdramt=0;
                dr = Convert.ToDouble(TextBox11.Text);
                rdramt = dramt - dr;
                balamt = balamt + rdramt;
                con.Open();
                SqlCommand cmd = new SqlCommand("update balance set amount='" + balamt + "' where id=1", con);
                SqlCommand cmd1 = new SqlCommand("update bill set name='"+TextBox9.Text+"',date='"+ddd+"',camount="+cramt+",damount="+dr+",creson='"+TextBox12.Text+"' where ID=" + TextBox13.Text + "", con);
                i = cmd.ExecuteNonQuery();
                i = cmd1.ExecuteNonQuery();
                con.Close();
                bind();
            }
            if (i != 0)
            {
                Label6.Text = "Record updated Successfully";

            }
            else
            {
                Label6.Text = "Record Not updated Successfully";
            }


        }
        catch (Exception r)
        {
            Label6.Text = "error";
        }
    }
    
   
    String mode,chkno;
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {
            mode = RadioButton1.Text;
            Label14.Text = mode;
            TextBox23.Text = "CASH";
        }
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
         if (RadioButton2.Checked)
        {
            mode = RadioButton2.Text;
            Label14.Text = mode;
            TextBox23.Text = "0";
        }
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "Customer Payment")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Left(NAMEDOBADDRESS,25),APPNO,CHECKBY,plotno FROM wjstar1.customerreg1 where CUSTREGNO='" + TextBox22.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {

                    Label10.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                if (ds.Tables[0].Rows[0][1].ToString() != "")
                {
                    Label11.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                if (ds.Tables[0].Rows[0][2].ToString() != "")
                {
                    Label13.Text = ds.Tables[0].Rows[0][2].ToString();
                }
                if (ds.Tables[0].Rows[0][3].ToString() != "")
                {
                    Label12.Text = ds.Tables[0].Rows[0][3].ToString();
                }

            }
            else
            {
                Label1.Text = "Record Not Found";
            }
        }
        else
        {
            if (DropDownList1.Text == "INVESTER PAYMENT")
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select invid,ivname FROM newinvester where invid='" + TextBox22.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {

                        Label13.Text = ds.Tables[0].Rows[0][0].ToString();
                    }
                    if (ds.Tables[0].Rows[0][1].ToString() != "")
                    {
                        Label10.Text = ds.Tables[0].Rows[0][1].ToString();
                    }
                    Label11.Text = "0"; Label12.Text = "0";

                }
                else
                {
                    Label1.Text = "Record Not Found";
                }
            }
            else
            {
                Label11.Text = "0";
                Label12.Text = "0";
                Label10.Text = DropDownList1.Text;
                Label13.Text = DropDownList1.Text;
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel5.Visible = true;
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
         SqlConnection con = new SqlConnection(s);
            con.Open();
            
            SqlCommand cmd2 = new SqlCommand("insert into debittype(debitype)values('"+TextBox25.Text+"')", con);
            int i = cmd2.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                Label20.Text = "Added";
                Panel5.Visible = false;
                debittype();

            }
            else
            {
                Label20.Text = "Error";
            }
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton3.Checked)
        {
          
            Label19.Text = RadioButton3.Text;
            TextBox24.Text = "CASH";
        }
    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton4.Checked)
        {
           
            Label19.Text = RadioButton4.Text;
            TextBox24.Text = "0";
        }
    }
    public void bindl()
    {

        DropDownList3.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList3.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }

    public void bindl3()
    {

        DropDownList3.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid,ivname from newinvester", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList3.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString() + "---" + ds.Tables[0].Rows[i][1].ToString());
        }

    }

    public void bind2()
    {

        DropDownList3.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select id,arazi,kname from newkishan", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList3.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString()+"-----"+ds.Tables[0].Rows[i][1].ToString() + "---" + ds.Tables[0].Rows[i][2].ToString());
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox26.Text = "";
        if (DropDownList2.Text == "ARAZI PAYMENT")
        {
            bindl();

            Label21.Text = "Value";
            DropDownList4.Visible = true;
            TextBox26.Visible = false;
            LinkButton2.Visible = true;
            Panel6.Visible =false;
            staff();
            
        }
        else
        {
            if (DropDownList2.Text == "KISHAN PAYMENT")
            {
                bind2();
                Label21.Text = "ID";
                DropDownList4.Visible =false;
                TextBox26.Visible = true;
                LinkButton2.Visible = false;
                Panel6.Visible = false;
               
            }
            else
            {
                if (DropDownList2.Text == "INVESTER PAYMENT" || DropDownList2.Text=="INVESTER BROKER PAYMENT")
                {
                    bindl3();
                    Label21.Text = "ID";
                    DropDownList4.Visible = false;
                   
                    TextBox26.Visible = true;
                    LinkButton2.Visible = false;
                    Panel6.Visible = false;
                }
                else
                {
                    if (DropDownList2.Text == "IQRA ART PAYMENT")
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("--SELECT--");
                        DropDownList3.Items.Add(DropDownList2.Text);
                       
                        Label21.Text = "Value";
                        DropDownList4.Visible = false;
                        Panel6.Visible = false;

                        TextBox26.Visible = true;
                        LinkButton2.Visible = false;
                    }
                    else
                    {
                        if (DropDownList2.Text == "OFFICE SALARY")
                        {
                            DropDownList3.Items.Clear();
                            DropDownList3.Items.Add("--SELECT--");
                            DropDownList3.Items.Add(DropDownList2.Text);
                            DropDownList4.Visible = true;
                            staff();
                            TextBox26.Visible =false;
                            Label21.Text = "Value";
                            LinkButton2.Visible =true;
                            Panel6.Visible = false;
                        }
                        else
                        {
                            DropDownList3.Items.Clear();
                            DropDownList3.Items.Add("--SELECT--");
                            DropDownList3.Items.Add(DropDownList2.Text);
                            DropDownList4.Visible = false;
                            LinkButton2.Visible = false;
                            TextBox26.Visible = true;
                            Panel6.Visible = false;

                        }
                        
                    }
                }
            }
        }
        
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox26.Text = "";
        if (DropDownList3.Text == "PLOT CANCEL" || DropDownList3.Text == "BROKARI" || DropDownList3.Text == "FREE RAGISTRY")
        {
            Label21.Text = "Reg.No";
            TextBox26.Text = "";
            DropDownList4.Visible = false;
            TextBox26.Visible = true;
        }
        else
        {
            if (DropDownList2.Text == "KISHAN PAYMENT" || DropDownList2.Text == "INVESTER PAYMENT" || DropDownList2.Text=="INVESTER BROKER PAYMENT")
            {
               
                TextBox26.Text = "";
                DropDownList4.Visible = false;
                TextBox26.Visible = true;
            }
            else
            {
                TextBox26.Text = DropDownList3.Text;
            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel6.Visible = true;
    }
    public void staff()
    {
        DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select  name from staffarazi where type1='"+DropDownList2.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList4.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList4.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }
    protected void Button20_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("insert into staffarazi(type1,name)values('" + DropDownList2.Text + "','" + TextBox27.Text + "')", con);
        int i = cmd2.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label22.Text = "Added";
            Panel6.Visible = false;
            staff();

        }
        else
        {
            Label22.Text = "Error";
        }
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        if (DropDownList2.Text == "PLOT CANCEL" || DropDownList2.Text == "FREE RAGISTRY")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Left(NAMEDOBADDRESS,25),APPNO,plotno FROM wjstar1.customerreg1 where CUSTREGNO='" + TextBox26.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {

                    Label16.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                if (ds.Tables[0].Rows[0][1].ToString() != "")
                {
                    Label15.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                if (ds.Tables[0].Rows[0][2].ToString() != "")
                {
                    Label17.Text = ds.Tables[0].Rows[0][2].ToString();
                }

                Label18.Text = DropDownList3.Text;


            }
            else
            {
                Label3.Text = "Record Not Found";
            }
        }
        else
        {
            if (DropDownList2.Text == "BROKARI")
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select Left(NAMEDOBADDRESS,25),APPNO,plotno,CHECKBY FROM wjstar1.customerreg1 where CUSTREGNO='" + TextBox26.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {

                        Label16.Text = ds.Tables[0].Rows[0][0].ToString();
                    }
                    if (ds.Tables[0].Rows[0][1].ToString() != "")
                    {
                        Label15.Text = ds.Tables[0].Rows[0][1].ToString();
                    }
                    if (ds.Tables[0].Rows[0][2].ToString() != "")
                    {
                        Label17.Text = ds.Tables[0].Rows[0][2].ToString();
                    }
                    if (ds.Tables[0].Rows[0][3].ToString() != "")
                    {
                        Label18.Text = ds.Tables[0].Rows[0][3].ToString();
                    }



                }
                else
                {
                    Label3.Text = "Record Not Found";
                }
            }
            else
            {
                if (DropDownList2.Text == "ARAZI PAYMENT")
            {
                
                

                        Label16.Text =DropDownList4.Text;
                   
                        Label15.Text =DropDownList3.Text;
                   
                        Label17.Text ="0";
                   
                    
                        Label18.Text = DropDownList3.Text;
                


                }
                else
                {
                    if (DropDownList2.Text == "OFFICE SALARY")
                    {



                        Label16.Text = DropDownList4.Text;

                        Label15.Text = "0";

                        Label17.Text = "0";


                        Label18.Text = DropDownList2.Text;



                    }
                    else
                    {
                        if (DropDownList2.Text == "IQRA ART PAYMENT")
                        {



                            Label16.Text = DropDownList3.Text;

                            Label15.Text = "0";

                            Label17.Text = "0";


                            Label18.Text = DropDownList2.Text;



                        }
                        else
                        {

                            if (DropDownList2.Text == "KISHAN PAYMENT")
                            {


                                SqlConnection con = new SqlConnection(s);
                                con.Open();
                                SqlDataAdapter da = new SqlDataAdapter("select kname,arazi FROM newkishan where id='" + TextBox26.Text + "'", con);
                               DataSet ds = new DataSet();
                                da.Fill(ds);
                                con.Close();
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                                    {

                                        Label16.Text = ds.Tables[0].Rows[0][0].ToString();
                                    }
                                    if (ds.Tables[0].Rows[0][1].ToString() != "")
                                    {
                                        Label15.Text = ds.Tables[0].Rows[0][1].ToString();
                                    }

                                    Label17.Text = "0";


                                    Label18.Text = TextBox26.Text;




                                }
                                else
                                {
                                    Label3.Text = "Record Not Found";
                                }



                            }
                            else
                            {
                                if (DropDownList2.Text == "INVESTER PAYMENT")
                                {


                                    SqlConnection con = new SqlConnection(s);
                                    con.Open();
                                    SqlDataAdapter da = new SqlDataAdapter("select ivname FROM newinvester where invid='" + TextBox26.Text + "'", con);
                                    DataSet ds = new DataSet();
                                    da.Fill(ds);
                                    con.Close();
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                                        {

                                            Label16.Text = ds.Tables[0].Rows[0][0].ToString();
                                        }


                                        Label15.Text = "0";
                                        Label17.Text = "0";


                                        Label18.Text = TextBox26.Text;




                                    }
                                    else
                                    {
                                        Label3.Text = "Record Not Found";
                                    }
                                }
                                else
                                {
                                    if (DropDownList2.Text == "INVESTER BROKER PAYMENT")
                                    {


                                        SqlConnection con = new SqlConnection(s);
                                        con.Open();
                                        SqlDataAdapter da = new SqlDataAdapter("select ivname,brokername FROM newinvester where invid='" + TextBox26.Text + "'", con);
                                        DataSet ds = new DataSet();
                                        da.Fill(ds);
                                        con.Close();
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            if (ds.Tables[0].Rows[0][0].ToString() != "")
                                            {

                                                Label16.Text = ds.Tables[0].Rows[0][0].ToString();
                                            }
                                            if (ds.Tables[0].Rows[0][0].ToString() != "")
                                            {

                                                Label18.Text = ds.Tables[0].Rows[0][1].ToString();
                                            }

                                            Label15.Text = "0";
                                            Label17.Text = "0";


                                           




                                        }
                                        else
                                        {
                                            Label3.Text = "Record Not Found";
                                        }
                                    }
                                    else
                                    {
                                        Label15.Text = "0";
                                        Label17.Text = "0";
                                        Label16.Text = DropDownList2.Text;
                                        Label18.Text = DropDownList2.Text;
                                    }
                                }
                            }
                            
                        }
                    }
                    
                }
            }
        }

    }
   

    public void bindl33()
    {

        DropDownList6.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid,ivname from newinvester", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList6.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList6.Items.Add(ds.Tables[0].Rows[i][0].ToString() + "---" + ds.Tables[0].Rows[i][1].ToString());
        }

    }

    public void bind22()
    {

        DropDownList6.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select id,arazi,kname from newkishan", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList6.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList6.Items.Add(ds.Tables[0].Rows[i][0].ToString() + "-----" + ds.Tables[0].Rows[i][1].ToString() + "---" + ds.Tables[0].Rows[i][2].ToString());
        }

    }
    public void staff1()
    {
        DropDownList7.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select  name from staffarazi where type1='" + DropDownList5.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList7.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList7.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }
    public void bindl1()
    {
        DropDownList10.Items.Clear();
        DropDownList6.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList6.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList6.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList10.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
    public void bindl11()
    {
        DropDownList10.Items.Clear();
        //DropDownList6.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList6.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

           // DropDownList6.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList10.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList5.Text == "ARAZI PAYMENT")
        {
            bindl1();

           
            DropDownList6.Visible = true;
           
            staff1();

        }
        else
        {
            if (DropDownList5.Text == "KISHAN PAYMENT")
            {
                bind22();
               
               

            }
            else
            {
                if (DropDownList5.Text == "INVESTER PAYMENT" || DropDownList5.Text == "INVESTER BROKER PAYMENT")
                {
                    bindl33();
                    
                }
                else
                {
                    if (DropDownList5.Text == "IQRA ART PAYMENT")
                    {
                        DropDownList6.Items.Clear();
                        DropDownList6.Items.Add("--SELECT--");
                        DropDownList6.Items.Add(DropDownList5.Text);
                     
                       
                    }
                    else
                    {
                        if (DropDownList5.Text == "OFFICE SALARY")
                        {
                            DropDownList6.Items.Clear();
                            DropDownList6.Items.Add("--SELECT--");
                            DropDownList6.Items.Add(DropDownList5.Text);
                            DropDownList6.Visible = true;
                            staff1();
                          
                        }
                        else
                        {
                            DropDownList6.Items.Clear();
                            DropDownList6.Items.Add("--SELECT--");
                            DropDownList6.Items.Add(DropDownList5.Text);
                            

                        }

                    }
                }
            }
        }
    }
    public void bindl333()
    {

        DropDownList7.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid from newinvester", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList7.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList7.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
    public void bindl3333()
    {

        DropDownList7.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select id from newkishan", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList7.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList7.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList6.Text == "PLOT CANCEL" || DropDownList6.Text == "BROKARI" || DropDownList6.Text == "FREE RAGISTRY")
        {
            DropDownList7.Items.Clear();
            DropDownList7.Items.Add("----select----");
            DropDownList7.Items.Add(DropDownList6.Text);
        }
        else
        {
            if (DropDownList5.Text == "KISHAN PAYMENT" || DropDownList5.Text == "INVESTER PAYMENT" || DropDownList5.Text == "INVESTER BROKER PAYMENT")
            {
                if (DropDownList5.Text == "KISHAN PAYMENT")
                {
                    bindl3333();
                }
                if (DropDownList5.Text == "INVESTER PAYMENT" || DropDownList5.Text == "INVESTER BROKER PAYMENT")
                {
                    bindl333();
                }
               
            }
            else
            {
                if (DropDownList5.Text == "ARAZI PAYMENT" || DropDownList5.Text == "OFFICE SALARY")
                {

                    staff1();
                }
                else
                {
                    DropDownList7.Items.Clear();
                    DropDownList7.Items.Add("----select----");
                    DropDownList7.Items.Add(DropDownList6.Text);
                }
            }
            
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "Customer Payment" || DropDownList1.Text == "INVESTER PAYMENT")
        {
            TextBox22.Text = "";
            if (DropDownList1.Text == "INVESTER PAYMENT")
            {
                DropDownList8.Visible = true;
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select invid,ivname from newinvester", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                DropDownList8.Items.Add("--SELECT--");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    DropDownList8.Items.Add(ds.Tables[0].Rows[i][0].ToString() + "---" + ds.Tables[0].Rows[i][1].ToString());
                }
            }
            else
            {
                DropDownList8.Visible = false;
            }
        }
        else
        {
            TextBox22.Text = DropDownList1.Text;
            DropDownList8.Visible = false;
        }
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = true;
            Panel3.Visible = false;
            // GridView3.Visible = false;
            GridView2.Visible = true;
            string dateString1 = TextBox28.Text;
            string dateString2 = TextBox29.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
            string ddd1 = dateTime1.ToString("mm/dd/yyyy");
            DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            string ddd2 = dateTime2.ToString("mm/dd/yyyy");
            // GridView4.Visible = true;
            if (DropDownList9.Text == "KISHAN PAYMENT" || DropDownList9.Text == "INVESTER PAYMENT")
            {
                Label23.Text = "";
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where type='" + DropDownList9.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                con.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill where type='" + DropDownList9.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' ", con);
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
                    Label23.Text = "error";
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
            }
            else
            {
                if (DropDownList9.Text == "ARAZI PAYMENT" || DropDownList9.Text == "OFFICE SALARY")
                {
                    if (DropDownList9.Text == "ARAZI PAYMENT")
                    {
                        Label23.Text = "";
                        SqlConnection con = new SqlConnection(s);
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where type='" + DropDownList9.Text + "' AND regno='" + DropDownList10.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        con.Open();
                        SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill where type='" + DropDownList9.Text + "'  AND regno='" + DropDownList10.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' ", con);
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
                            Label23.Text = "error";
                            GridView2.DataSource = null;
                            GridView2.DataBind();
                        }
                    }
                    else
                    {
                        Label23.Text = "";
                        SqlConnection con = new SqlConnection(s);
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where type='" + DropDownList9.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        con.Open();
                        SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill where type='" + DropDownList9.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' ", con);
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
                            Label23.Text = "error";
                            GridView2.DataSource = null;
                            GridView2.DataBind();
                        }
                    }
                }
                else
                {
                    Label23.Text = "";
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where type='" + DropDownList9.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select sum(camount),sum(damount) from bill where type='" + DropDownList9.Text + "' AND date between '" + ddd1 + "' AND '" + ddd2 + "' ", con);
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
                        Label23.Text = "error";
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
            }





        }
        catch (Exception r)
        {

        }
    }
    protected void Button22_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = true;
            Panel3.Visible = false;
            // GridView3.Visible = false;
            GridView2.Visible = true;
            string dateString1 = TextBox28.Text;
            string dateString2 = TextBox29.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
            string ddd1 = dateTime1.ToString("mm/dd/yyyy");
            DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            string ddd2 = dateTime2.ToString("mm/dd/yyyy");
            // GridView4.Visible = true;
            if (DropDownList9.Text == "KISHAN PAYMENT" || DropDownList9.Text == "INVESTER PAYMENT")
            {
                Label23.Text = "";
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
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
                    Label23.Text = "error";
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
            }
            else
            {
                if (DropDownList9.Text == "ARAZI PAYMENT" || DropDownList9.Text == "OFFICE SALARY")
                {
                    Label23.Text = "";
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
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
                        Label23.Text = "error";
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
                else
                {
                    Label23.Text = "";
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select id,type,regno,upname,arazino,plotno,name,date,mode,chequeno,camount,damount,cstatus,creson from bill where date between '" + ddd1 + "' AND '" + ddd2 + "' order by date ASC", con);
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
                        Label23.Text = "error";
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
            }





        }
        catch (Exception r)
        {

        }
    }
    protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList9.Text == "ARAZI PAYMENT")
        {
            bindl11();


            DropDownList10.Visible = true;



        }
        else
        {
            DropDownList10.Visible = false;
        }
    }
}