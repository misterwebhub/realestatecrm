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
using System.Drawing;

public partial class partner : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            find();

        }
    }
    public void find()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT APPNO FROM wjstar1.customerreg1", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                // DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                if (ds1.Tables[0].Rows[j][0].ToString() == "519")
                {
                    continue;
                }
                else
                {
                    DropDownList1.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
                }

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

            SqlDataAdapter cmd = new SqlDataAdapter("select r.CUSTREGNO,r.NAME,r.AMOUNT,r.AMOUNT AS 'AMOUNT1',r.DATE,c.plotno,c.PLOTSIZE,c.CHECKBY from (select DISTINCT CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',AMOUNTR AS 'AMOUNT',DATE1 AS 'DATE' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO='" + DropDownList1.Text + "' AND CHECKBY IN ('office','TAUDHAKPUR OFFICE'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO ORDER BY DATE ASC", con1);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            con1.Close();
            con1.Open();

            SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO='" + DropDownList1.Text + "' AND CHECKBY IN ('office','TAUDHAKPUR OFFICE'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds1 = new DataSet();
            cmd1.Fill(ds1);
            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
            con1.Close();
            con1.Open();
            SqlDataAdapter cmd22 = new SqlDataAdapter("select r.CUSTREGNO,r.NAME,(r.AMOUNT) AS 'AMOUNT',(r.AMOUNT-r.AMOUNT*0.10) AS 'AMOUNT1',r.DATE,c.plotno,c.PLOTSIZE,c.CHECKBY from (select DISTINCT CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',AMOUNTR AS 'AMOUNT',DATE1 AS 'DATE' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO='" + DropDownList1.Text + "' AND CHECKBY NOT IN ('office','Satya prakas tiwari','TAUDHAKPUR OFFICE'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO ORDER BY DATE ASC", con1);
            DataSet ds22 = new DataSet();
            cmd22.Fill(ds22);
            GridView3.DataSource = ds22;
            GridView3.DataBind();
            con1.Close();
            con1.Open();

            SqlDataAdapter cmd2 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO='" + DropDownList1.Text + "' AND CHECKBY NOT IN ('office','Satya prakas tiwari','TAUDHAKPUR OFFICE'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds2 = new DataSet();
            cmd2.Fill(ds2);
            Label4.Text = ds2.Tables[0].Rows[0][0].ToString();
            con1.Close();
            Double r = Convert.ToDouble(Label2.Text);
            Label6.Text = r.ToString();




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

            //  SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',AMOUNTR AS 'AMOUNT',DATE1 AS 'DATE' from recipt1 where CUSTREGNO IN (select CUSTREGNO from customerreg1 where date3>='6/1/2020 12:00:00 AM') AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            SqlDataAdapter cmd = new SqlDataAdapter("select r.CUSTREGNO,r.NAME,r.AMOUNT,r.AMOUNT AS 'AMOUNT1',r.DATE,c.plotno,c.PLOTSIZE,c.CHECKBY from (select DISTINCT CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',AMOUNTR AS 'AMOUNT',DATE1 AS 'DATE' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND CHECKBY='office'  OR CHECKBY='TAUDHAKPUR OFFICE' AND APPNO NOT IN ('519'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO ORDER BY DATE ASC", con1);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            con1.Close();
            con1.Open();
SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020' AND '12/31/2020' AND APPNO NOT IN ('519') AND CHECKBY IN ('office','TAUDHAKPUR OFFICE'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
           /* SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO NOT IN ('519') AND  CHECKBY='office'  OR CHECKBY='TAUDHAKPUR OFFICE') AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);*/
            DataSet ds1 = new DataSet();
            cmd1.Fill(ds1);
            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
            con1.Close();
            con1.Open();
            SqlDataAdapter cmd22 = new SqlDataAdapter("select r.CUSTREGNO,r.NAME,(r.AMOUNT) AS 'AMOUNT',(r.AMOUNT-r.AMOUNT*0.10) AS 'AMOUNT1',r.DATE,c.plotno,c.PLOTSIZE,c.CHECKBY from (select DISTINCT CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',AMOUNTR AS 'AMOUNT',DATE1 AS 'DATE' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari','TAUDHAKPUR OFFICE'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO ORDER BY DATE ASC", con1);
            DataSet ds22 = new DataSet();
            cmd22.Fill(ds22);
            GridView3.DataSource = ds22;
            GridView3.DataBind();
            con1.Close();
            con1.Open();

            SqlDataAdapter cmd2 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari','TAUDHAKPUR OFFICE'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds2 = new DataSet();
            cmd2.Fill(ds2);
            Label4.Text = ds2.Tables[0].Rows[0][0].ToString();
            con1.Close();
            Double r = Convert.ToDouble(Label2.Text);
            Label6.Text = r.ToString();




        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            string s2 = TextBox3.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox4.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string date2 = mm1 + "/" + dd1 + "/" + yy1;


            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            //  SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',AMOUNTR AS 'AMOUNT',DATE1 AS 'DATE' from recipt1 where CUSTREGNO IN (select CUSTREGNO from customerreg1 where date3>='6/1/2020 12:00:00 AM') AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            SqlDataAdapter cmd = new SqlDataAdapter("select r.CUSTREGNO,r.NAME,(r.AMOUNT) AS 'AMOUNT',(r.AMOUNT*0.05) AS 'AMOUNT1',r.DATE,c.plotno,c.PLOTSIZE,c.CHECKBY from (select DISTINCT CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',AMOUNTR AS 'AMOUNT',DATE1 AS 'DATE' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND CHECKBY IN ('office','TAUDHAKPUR OFFICE') AND APPNO IN ('519'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO ORDER BY DATE ASC", con1);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            con1.Close();
            con1.Open();

            SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR*0.05) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO IN ('519') AND  CHECKBY IN ('office','TAUDHAKPUR OFFICE'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds1 = new DataSet();
            cmd1.Fill(ds1);
            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
            con1.Close();
            con1.Open();
            SqlDataAdapter cmd22 = new SqlDataAdapter("select r.CUSTREGNO,r.NAME,(r.AMOUNT) AS 'AMOUNT',(r.AMOUNT*0.06) AS 'AMOUNT1',r.DATE,c.plotno,c.PLOTSIZE,c.CHECKBY from (select DISTINCT CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',AMOUNTR AS 'AMOUNT',DATE1 AS 'DATE' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO ORDER BY DATE ASC", con1);
            DataSet ds22 = new DataSet();
            cmd22.Fill(ds22);
            GridView3.DataSource = ds22;
            GridView3.DataBind();
            con1.Close();
            con1.Open();

            SqlDataAdapter cmd2 = new SqlDataAdapter("select SUM(AMOUNTR*0.06) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020 12:00:00 AM' AND '12/31/2020' AND APPNO IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari'))  AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds2 = new DataSet();
            cmd2.Fill(ds2);
            Label4.Text = ds2.Tables[0].Rows[0][0].ToString();
            con1.Close();
            Double r = Convert.ToDouble(Label2.Text);
            Label6.Text = r.ToString();




        }
        catch (Exception t)
        {
            Label7.Text = "internal problem"+t;
        }
    }
}
