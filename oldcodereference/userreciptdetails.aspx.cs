﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Services;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;

public partial class userreciptdetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
	
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label2.Text = Session["ID"].ToString(); 
        Label2.Text = "amar";
        if (!IsPostBack)
        {
            bind();
            Label5.Visible = false;
            Label6.Visible = false;
            Label4.Visible = false;
            TextBox3.Visible = false;
            Label7.Visible = false;
            TextBox4.Visible = false;
            Button5.Visible = false;
        }
    }
    public void bind()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT username FROM logininfo", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                // DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                DropDownList1.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
            }
            con1.Close();
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
            Label8.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label4.Visible = true;
            TextBox3.Visible = true;
            Label7.Visible = true;
            TextBox4.Visible = true;
            Button5.Visible = true;
            Label1.Text = "";
            Label3.Text = "";
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


            SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO,SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.INSTNO,r.AMOUNTR AS 'AMOUNT',r.checkby AS 'CHECKBY',r.usertype AS 'USER',u.APPNO AS 'ARAZI',u.plotno AS 'PLOT',u.PLOTSIZE AS 'SIZE',r.userstatus,r.paidamount,r.deldate,u.date3 from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.usertype='" + DropDownList1.Text + "' ", con1);
            DataSet ds = new DataSet();
           da.Fill(ds);
           con1.Close();
           con1.Open();
           SqlDataAdapter da2 = new SqlDataAdapter("select r.CUSTREGNO,SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.INSTNO,r.AMOUNTR AS 'AMOUNT',r.checkby AS 'CHECKBY',r.usertype AS 'USER',u.APPNO AS 'ARAZI',u.plotno AS 'PLOT',u.PLOTSIZE AS 'SIZE',r.userstatus,r.paidamount,r.deldate,u.date3 from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.deldate BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.usertype='" + DropDownList1.Text + "' AND r.CUSTREGNO NOT IN(select CUSTREGNO from  wjstar1.recipt1 where r.deldate=r.DATE1)", con1);
           DataSet ds2 = new DataSet();
           da2.Fill(ds2);
           con1.Close();
           con1.Open();
           SqlDataAdapter da22 = new SqlDataAdapter("select sum(r.paidamount) from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.deldate BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.usertype='" + DropDownList1.Text + "' AND r.CUSTREGNO NOT IN(select CUSTREGNO from  wjstar1.recipt1 where r.deldate=r.DATE1)", con1);
           DataSet ds22 = new DataSet();
           da22.Fill(ds22);
           con1.Close();
           Double backamount = 0;
           if (ds22.Tables[0].Rows[0][0].ToString() != "")
           {
               backamount = Convert.ToDouble(ds22.Tables[0].Rows[0][0].ToString());
               Label9.Text = backamount.ToString();
           }
           else
           {
               backamount = 0;
               Label9.Text = backamount.ToString();
           }
           con1.Open();
           SqlDataAdapter da223 = new SqlDataAdapter("select sum(r.paidamount) from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.usertype='" + DropDownList1.Text + "' AND r.userstatus='Inactive'", con1);
           DataSet ds223 = new DataSet();
           da223.Fill(ds223);
           con1.Close();
           Double curamount = 0;
           if (ds223.Tables[0].Rows[0][0].ToString() != "")
           {
              curamount = Convert.ToDouble(ds223.Tables[0].Rows[0][0].ToString());
              Label8.Text = curamount.ToString();
           }
           else
           {
               curamount = 0;
               Label8.Text = curamount.ToString();
           }
           con1.Open();


           SqlDataAdapter da1 = new SqlDataAdapter("select sum(r.AMOUNTR) AS 'AMOUNT' from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.usertype='" + DropDownList1.Text + "'", con1);
           DataSet ds1 = new DataSet();
           da1.Fill(ds1);
           con1.Close();
          
             Double d4=0;
           // Label3.Text = ds2.Tables[0].Rows[0][0].ToString();
            Double d2 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
           /* if (ds4.Tables[0].Rows[0][0].ToString()!="")
            {
                d4 = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                d4 = 0;
            }*/
            Double d5 = d2 + d4;
            Label3.Text = d5.ToString();
	
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
            GridView2.DataSource = ds2;
            GridView2.DataBind();

            bal();
           /* string ddd6 = DateTime.Now.ToString("MM/dd/yyyy");
            string mm5 = ddd6.Substring(0, 2);
            string dd5 = ddd6.Substring(3, 2);
            string yy5 = ddd6.Substring(6, 4);
            string date7 = mm5 + "/" + dd5 + "/" + yy5;
            if (date7 == date1)
            {
                cancel0();
            }
            else
            {
                cancel();
            }*/
        
        }
        catch (Exception t)
        {
            Label1.Text = "error"+t;
        }

    }
   
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Label5.Visible = false;
            Label6.Visible = false;
            Label4.Visible = false;
            TextBox3.Visible = false;
            Label7.Visible = false;
            TextBox4.Visible = false;
            Button5.Visible = false;
            Label1.Text = "";
            Label3.Text = "";
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


            SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO,SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.INSTNO,r.AMOUNTR AS 'AMOUNT',r.checkby AS 'CHECKBY',r.usertype AS 'USER',u.APPNO AS 'ARAZI',u.plotno AS 'PLOT',u.PLOTSIZE AS 'SIZE',r.userstatus,r.paidamount,r.deldate,u.date3 from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "')", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select r.CUSTREGNO,SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.INSTNO,r.AMOUNTR AS 'AMOUNT',r.checkby AS 'CHECKBY',r.usertype AS 'USER',u.APPNO AS 'ARAZI',u.plotno AS 'PLOT',u.PLOTSIZE AS 'SIZE',r.userstatus,r.paidamount,r.deldate,u.date3 from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.deldate BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.CUSTREGNO NOT IN(select CUSTREGNO from  wjstar1.recipt1 where r.deldate=r.DATE1)", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter da22 = new SqlDataAdapter("select sum(r.paidamount) from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.deldate BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.CUSTREGNO NOT IN(select CUSTREGNO from  wjstar1.recipt1 where r.deldate=r.DATE1)", con1);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            con1.Close();
            Double backamount = 0;
            if (ds22.Tables[0].Rows[0][0].ToString() != "")
            {
                backamount = Convert.ToDouble(ds22.Tables[0].Rows[0][0].ToString());
                Label9.Text = backamount.ToString();
            }
            else
            {
                backamount = 0;
                Label9.Text = backamount.ToString();
            }
            con1.Open();
            SqlDataAdapter da223 = new SqlDataAdapter("select sum(r.paidamount) from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.userstatus='Inactive'", con1);
            DataSet ds223 = new DataSet();
            da223.Fill(ds223);
            con1.Close();
            Double curamount = 0;
            if (ds223.Tables[0].Rows[0][0].ToString() != "")
            {
                curamount = Convert.ToDouble(ds223.Tables[0].Rows[0][0].ToString());
                Label8.Text = curamount.ToString();
            }
            else
            {
                curamount = 0;
                Label8.Text = curamount.ToString();
            }
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("select sum(r.AMOUNTR) AS 'AMOUNT' from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "')", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();

            Double d4 = 0;
            // Label3.Text = ds2.Tables[0].Rows[0][0].ToString();
            Double d2 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            /* if (ds4.Tables[0].Rows[0][0].ToString()!="")
             {
                 d4 = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
             }
             else
             {
                 d4 = 0;
             }*/
            Double d5 = d2 + d4;
            Label3.Text = d5.ToString();

            GridView1.DataSource = ds;
            GridView1.DataBind();

            GridView2.DataSource = ds2;
            GridView2.DataBind();

            //  bal();
            /* string ddd6 = DateTime.Now.ToString("MM/dd/yyyy");
             string mm5 = ddd6.Substring(0, 2);
             string dd5 = ddd6.Substring(3, 2);
             string yy5 = ddd6.Substring(6, 4);
             string date7 = mm5 + "/" + dd5 + "/" + yy5;
             if (date7 == date1)
             {
                 cancel0();
             }
             else
             {
                 cancel();
             }*/

        }
        catch (Exception t)
        {
            Label1.Text = "error" + t;
        }

    }
   public static int d = 0;
    protected void Button3_Click(object sender, EventArgs e)
    {
       
       
        try
        {
            Label5.Visible = false;
            Label6.Visible = false;
            Label4.Visible = false;
            TextBox3.Visible = false;
            Label7.Visible = false;
            TextBox4.Visible = false;
            Button5.Visible = false;
            Label1.Text = "";
            Label3.Text = "";
            string s2 = TextBox1.Text;
            d = d - 1;
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + d + "/" + yy;
            
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO,SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.INSTNO,r.AMOUNTR AS 'AMOUNT',r.checkby AS 'CHECKBY',r.usertype AS 'USER',u.APPNO AS 'ARAZI',u.plotno AS 'PLOT',u.PLOTSIZE AS 'SIZE',r.userstatus,r.paidamount,r.deldate,u.date3 from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.DATE1 = '" + date1 + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("select sum(r.AMOUNTR) AS 'AMOUNT' from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.DATE1='" + date1 + "'", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            Label3.Text = ds1.Tables[0].Rows[0][0].ToString();
            con1.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch (Exception t)
        {
            Label1.Text = "error" + t;
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        d = Convert.ToInt32(dd);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            Label5.Visible = false;
            Label6.Visible = false;
            Label4.Visible = false;
            TextBox3.Visible = false;
            Label7.Visible = false;
            TextBox4.Visible = false;
            Button5.Visible = false;
            Label1.Text = "";
            Label3.Text = "";
            string s2 = TextBox1.Text;
            d = d + 1;
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + d + "/" + yy;

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO,SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.AMOUNTR AS 'AMOUNT',r.checkby AS 'CHECKBY',r.usertype AS 'USER',u.APPNO AS 'ARAZI',u.plotno AS 'PLOT',u.PLOTSIZE AS 'SIZE',r.userstatus,r.paidamount,r.deldate,u.date3 from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.DATE1 = '" + date1 + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("select sum(r.AMOUNTR) AS 'AMOUNT' from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.DATE1='" + date1 + "'", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            Label3.Text = ds1.Tables[0].Rows[0][0].ToString();
            con1.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch (Exception t)
        {
            Label1.Text = "error" + t;
        }
    }
    public void bal()
    {
        try
        {
            
            //Label1.Text = "";
           // Label3.Text = "";
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


            SqlDataAdapter da = new SqlDataAdapter("select sum(recamount) from userreciveamount where username='" + DropDownList1.Text + "' AND recdate BETWEEN '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();

            Double recamt,total,bal ;
            total = Convert.ToDouble(Label3.Text);
            if (ds.Tables[0].Rows[0][0].ToString() == "")
            {
                recamt = 0;
            }
            else
            {
                recamt = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            bal = total - recamt;
            Label4.Text = bal.ToString();
        }
        catch (Exception t)
        {
            Label1.Text = "error" + t;
        }

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
           
            Label1.Text = "";
           // Label3.Text = "";
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
            string s4 = TextBox4.Text;
            string dd2 = s4.Substring(0, 2);
            string mm2 = s4.Substring(3, 2);
            string yy2 = s4.Substring(6, 4);
            string date3 = mm2 + "/" + dd2 + "/" + yy2;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into userreciveamount(username,datefrom,dateto,recamount,recdate)values('"+DropDownList1.Text+"','"+date1+"','"+date2+"',"+TextBox3.Text+",'"+date3+"')", con1);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                Label1.Text = "Record Added";
                bal();
            }
            else
            {
                Label1.Text = "error";
            }
            
            con1.Close();
            

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
            string f = e.Row.Cells[14].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "Inactive")
                {
                    cell.BackColor = Color.Red;
                }
                

            }
        }
    }
}