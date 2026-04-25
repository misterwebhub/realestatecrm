﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Globalization;
using System.Drawing;
public partial class admin_adminhome1 : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*string id = "";
            if (Session["ID"] != null)
            {
                id= Session["ID"].ToString();
                //Label13.Text = "heedrealestate";
            }
            else
            {
                Response.Redirect("../admin.aspx");
            }
           // id = "CK001";*/
           // bind();

            // gridbind();
        }
    }
   /* public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1 where arazino not in(select DISTINCT arazino from softploted1)", con);
        DataSet ds1 = new DataSet();
        da.Fill(ds1);
        con.Close();
        DropDownList2.Items.Add("--select--");
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds1.Tables[0].Rows[i][0].ToString());
        }



    }
    */

    protected void Button1_Click(object sender, EventArgs e)
    {
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string s3 = TextBox2.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        string date2 = mm1 + "/" + dd1 + "/" + yy1;
        SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select c.date3 AS 'DATE',c.CUSTREGNO as 'CUSTREGNO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.CONSAMOUNT AS 'TOTALAMOUNT',r.PAID AS 'PA',(c.CONSAMOUNT-r.PAID) AS 'BALANCE',c.APPNO,c.PLOTSIZE AS 'PLOTSIZE',c.plotno AS 'PLOTNO',c.regstatus AS 'STATUS',c.mobile AS 'MOBILE',c.booktype AS 'MODE',c.agentid AS 'AGENTID' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 between '" + date1 + "' AND '" + date2 + "' AND agentid IS NOT NULL  AND APPNO in(select arazi from chainarazi) )  ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
           // SqlDataAdapter da = new SqlDataAdapter("select date3,CUSTREGNO,CONSAMOUNT,APPNO,plotno,PLOTSIZE,mobile,booktype,agentid from wjstar1.customerreg1 where date3 between '" + date1 + "' AND '" + date2 + "' AND agentid IS NOT NULL  AND APPNO in(select arazi from chainarazi)", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // bind1();
    }
    public void bind1()
    {
        /*SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select ID,formid,name,agentid,location,	block,	plotno,area,secondstatus,	booktype,date from booking where  secondstatus IN('Book','Hold')", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }*/
    }

   
   
    
    
}