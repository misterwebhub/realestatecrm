﻿﻿
using System;
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

public partial class arazi137ramipur_paymentdpdetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        String id = "";

        if (!IsPostBack)
        {
            id = Session["ID"].ToString();
            Button2.Visible = false;
            //id = "Ashok8396";
            // id = "heedrealestate";
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
                Button2.Visible = true;
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                   
                        DropDownList1.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
                  

                }
            }
            else
            {
                Button2.Visible = false;
                DropDownList1.Items.Add(id);


            }


        }
        catch (Exception t)
        {
            Label1.Text = "internal problem" + t;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        SqlConnection con1 = new SqlConnection(s);
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
        if (DropDownList1.Text == "heedrealestate")
        {
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,floor(DATEDIFF(DAY,c.date3,getdate())/30.46) AS 'MONTH',c.CONSAMOUNT,c.downpay,'PAID' = CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END,  'BALANCEDP' = CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END,c.CHECKBY,c.regstatus,CONCAT(c.mobile,' , ',c.mobile2,',',c.mobile3) AS 'mobile' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype='heedrealestate' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter(" select sum(c.CONSAMOUNT),sum(c.downpay),sum(CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END) AS PAID, SUM(CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END) AS BALANCEDP from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype='heedrealestate' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')) )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();

            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label5.Text = ds2.Tables[0].Rows[0][0].ToString();
                }
                if (ds2.Tables[0].Rows[0][1].ToString() != "")
                {
                    Label3.Text = ds2.Tables[0].Rows[0][1].ToString();
                }
                if (ds2.Tables[0].Rows[0][2].ToString() != "")
                {
                    Label2.Text = ds2.Tables[0].Rows[0][2].ToString();
                }
                if (ds2.Tables[0].Rows[0][3].ToString() != "")
                {
                    Label4.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
            }
        }
        if (DropDownList1.Text == "Ashok8396")
        {


            con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,floor(DATEDIFF(DAY,c.date3,getdate())/30.46) AS 'MONTH',c.CONSAMOUNT,c.downpay,'PAID' = CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END,  'BALANCEDP' = CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END,c.CHECKBY,c.regstatus,CONCAT(c.mobile,' , ',c.mobile2,',',c.mobile3) AS 'mobile' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype='Ashok8396'  GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con1.Close();
            GridView1.DataSource = ds3;
            GridView1.DataBind();
            con1.Open();
            SqlDataAdapter da4 = new SqlDataAdapter(" select sum(c.CONSAMOUNT),sum(c.downpay),sum(CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END) AS PAID, SUM(CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END) AS BALANCEDP from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype='Ashok8396' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con1.Close();

            if (ds4.Tables[0].Rows.Count > 0)
            {
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label5.Text = ds4.Tables[0].Rows[0][0].ToString();
                }
                if (ds4.Tables[0].Rows[0][1].ToString() != "")
                {
                    Label3.Text = ds4.Tables[0].Rows[0][1].ToString();
                }
                if (ds4.Tables[0].Rows[0][2].ToString() != "")
                {
                    Label2.Text = ds4.Tables[0].Rows[0][2].ToString();
                }
                if (ds4.Tables[0].Rows[0][3].ToString() != "")
                {
                    Label4.Text = ds4.Tables[0].Rows[0][3].ToString();
                }
            }
        }
        if (DropDownList1.Text == "RAMAIPUROFFICE")
        {
            con1.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,floor(DATEDIFF(DAY,c.date3,getdate())/30.46) AS 'MONTH',c.CONSAMOUNT,c.downpay,'PAID' = CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END,  'BALANCEDP' = CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END,c.CHECKBY,c.regstatus,CONCAT(c.mobile,' , ',c.mobile2,',',c.mobile3) AS 'mobile' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype='RAMAIPUROFFICE'  GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con1.Close();
            GridView1.DataSource = ds5;
            GridView1.DataBind();
            con1.Open();
            SqlDataAdapter da6 = new SqlDataAdapter(" select sum(c.CONSAMOUNT),sum(c.downpay),sum(CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END) AS PAID, SUM(CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END) AS BALANCEDP from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype='RAMAIPUROFFICE' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            con1.Close();

            if (ds6.Tables[0].Rows.Count > 0)
            {
                if (ds6.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label5.Text = ds6.Tables[0].Rows[0][0].ToString();
                }
                if (ds6.Tables[0].Rows[0][1].ToString() != "")
                {
                    Label3.Text = ds6.Tables[0].Rows[0][1].ToString();
                }
                if (ds6.Tables[0].Rows[0][2].ToString() != "")
                {
                    Label2.Text = ds6.Tables[0].Rows[0][2].ToString();
                }
                if (ds6.Tables[0].Rows[0][3].ToString() != "")
                {
                    Label4.Text = ds6.Tables[0].Rows[0][3].ToString();
                }
            }
        }
        if (DropDownList1.Text == "MACHHARIYAOFFICE")
        {
            con1.Open();
            SqlDataAdapter da7 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,floor(DATEDIFF(DAY,c.date3,getdate())/30.46) AS 'MONTH',c.CONSAMOUNT,c.downpay,'PAID' = CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END,  'BALANCEDP' = CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END,c.CHECKBY,c.regstatus,CONCAT(c.mobile,' , ',c.mobile2,',',c.mobile3) AS 'mobile' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1  where usertype='MACHHARIYAOFFICE' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
            con1.Close();
            GridView1.DataSource = ds7;
            GridView1.DataBind();
            con1.Open();
            SqlDataAdapter da8 = new SqlDataAdapter(" select sum(c.CONSAMOUNT),sum(c.downpay),sum(CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END) AS PAID, SUM(CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END) AS BALANCEDP from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype='MACHHARIYAOFFICE'  GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            con1.Close();

            if (ds8.Tables[0].Rows.Count > 0)
            {
                if (ds8.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label5.Text = ds8.Tables[0].Rows[0][0].ToString();
                }
                if (ds8.Tables[0].Rows[0][1].ToString() != "")
                {
                    Label3.Text = ds8.Tables[0].Rows[0][1].ToString();
                }
                if (ds8.Tables[0].Rows[0][2].ToString() != "")
                {
                    Label2.Text = ds8.Tables[0].Rows[0][2].ToString();
                }
                if (ds8.Tables[0].Rows[0][3].ToString() != "")
                {
                    Label4.Text = ds8.Tables[0].Rows[0][3].ToString();
                }
            }

        }
        if (DropDownList1.Text == "IMRAN7905")
        {
            con1.Open();
            SqlDataAdapter da7 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,floor(DATEDIFF(DAY,c.date3,getdate())/30.46) AS 'MONTH',c.CONSAMOUNT,c.downpay,'PAID' = CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END,  'BALANCEDP' = CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END,c.CHECKBY,c.regstatus,CONCAT(c.mobile,' , ',c.mobile2) AS 'mobile' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype='IMRAN7905' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
            con1.Close();
            GridView1.DataSource = ds7;
            GridView1.DataBind();
            con1.Open();
            SqlDataAdapter da8 = new SqlDataAdapter("select sum(c.CONSAMOUNT),sum(c.downpay),sum(CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END) AS PAID, SUM(CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END) AS BALANCEDP from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype='IMRAN7905' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            con1.Close();

            if (ds8.Tables[0].Rows.Count > 0)
            {
                if (ds8.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label5.Text = ds8.Tables[0].Rows[0][0].ToString();
                }
                if (ds8.Tables[0].Rows[0][1].ToString() != "")
                {
                    Label3.Text = ds8.Tables[0].Rows[0][1].ToString();
                }
                if (ds8.Tables[0].Rows[0][2].ToString() != "")
                {
                    Label2.Text = ds8.Tables[0].Rows[0][2].ToString();
                }
                if (ds8.Tables[0].Rows[0][3].ToString() != "")
                {
                    Label4.Text = ds8.Tables[0].Rows[0][3].ToString();
                }
            }
        }




    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        SqlConnection con1 = new SqlConnection(s);
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
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,floor(DATEDIFF(DAY,c.date3,getdate())/30.46) AS 'MONTH',c.CONSAMOUNT,c.downpay,'PAID' = CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END,  'BALANCEDP' = CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END,c.CHECKBY,c.regstatus,CONCAT(c.mobile,' , ',c.mobile2,',',c.mobile3) AS 'mobile' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype IN('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') GROUP BY  CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')) ) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con1.Close();
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con1.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(c.CONSAMOUNT),sum(c.downpay),sum(CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END) AS PAID, SUM(CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END) AS BALANCEDP from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') GROUP BY   CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))  ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con1.Close();
       /* con1.Open();
        SqlDataAdapter da9 = new SqlDataAdapter("select sum(CASE WHEN r.paid<c.downpay THEN r.paid ELSE c.downpay END) AS PAID, SUM(CASE  when (c.downpay-r.PAID)<0 THEN '0' ELSE (c.downpay-r.PAID) END) AS BALANCEDP  from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') GROUP BY   CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))  ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds9 = new DataSet();
        da9.Fill(ds9);
        con1.Close();*/

        if (ds2.Tables[0].Rows.Count > 0)
        {
            if (ds2.Tables[0].Rows[0][0].ToString() != "")
            {
                Label5.Text = ds2.Tables[0].Rows[0][0].ToString();
            }
            if (ds2.Tables[0].Rows[0][1].ToString() != "")
            {
                Label3.Text = ds2.Tables[0].Rows[0][1].ToString();
            }
            if (ds2.Tables[0].Rows[0][2].ToString() != "")
            {
                Label2.Text = ds2.Tables[0].Rows[0][2].ToString();
            }
            if (ds2.Tables[0].Rows[0][3].ToString() != "")
            {
                Label4.Text = ds2.Tables[0].Rows[0][3].ToString();
            }
        }
    }
}