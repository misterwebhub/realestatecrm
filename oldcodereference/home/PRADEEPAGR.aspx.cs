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

public partial class arazi187kha_PRADEEPAGR : System.Web.UI.Page
{
     string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public static double final = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
   
    public void bind2()
    {
        if (DropDownList1.Text == "Arazi 137")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select sum(expstamp+expfees+expkhasra+expcomm) AS 'TOTAL',sum(expbr) from ragistrydetails WHERE deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP')", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label134.Text = ds1.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Label134.Text = "0";
                }

                if (ds1.Tables[0].Rows[0][1].ToString() != "")
                {
                    Label135.Text = ds1.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    Label135.Text = "0";
                }
            }
            else
            {
                Label134.Text = "0";
                Label135.Text = "0";
            }
        }
        else
        {
            if (DropDownList1.Text == "161 'D Block'")
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("select sum(expstamp+expfees+expkhasra+expcomm) AS 'TOTAL',sum(expbr) from ragistrydetails WHERE deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE')", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][0].ToString() != "")
                    {
                        Label134.Text = ds1.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        Label134.Text = "0";
                    }

                    if (ds1.Tables[0].Rows[0][1].ToString() != "")
                    {
                        Label135.Text = ds1.Tables[0].Rows[0][1].ToString();
                    }
                    else
                    {
                        Label135.Text = "0";
                    }
                }
                else
                {
                    Label134.Text = "0";
                    Label135.Text = "0";
                }
            }
			else
			{
                if (DropDownList1.Text == "190")
                {
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("select sum(expstamp+expfees+expkhasra+expcomm) AS 'TOTAL',sum(expbr) from ragistrydetails WHERE deedno in('2932_PRADEEP')", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows[0][0].ToString() != "")
                        {
                            Label134.Text = ds1.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            Label134.Text = "0";
                        }

                        if (ds1.Tables[0].Rows[0][1].ToString() != "")
                        {
                            Label135.Text = ds1.Tables[0].Rows[0][1].ToString();
                        }
                        else
                        {
                            Label135.Text = "0";
                        }
                    }
                    else
                    {
                        Label134.Text = "0";
                        Label135.Text = "0";
                    }
                }
                else
                {
                    if (DropDownList1.Text == "397")
                    {
                        SqlConnection con = new SqlConnection(s);
                        con.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter("select sum(expstamp+expfees+expkhasra+expcomm) AS 'TOTAL',sum(expbr) from ragistrydetails WHERE deedno in('8866_HEED','11295 MAHENDR SINGH')", con);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        con.Close();
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            if (ds1.Tables[0].Rows[0][0].ToString() != "")
                            {
                                Label134.Text = ds1.Tables[0].Rows[0][0].ToString();
                            }
                            else
                            {
                                Label134.Text = "0";
                            }

                            if (ds1.Tables[0].Rows[0][1].ToString() != "")
                            {
                                Label135.Text = ds1.Tables[0].Rows[0][1].ToString();
                            }
                            else
                            {
                                Label135.Text = "0";
                            }
                        }
                        else
                        {
                            Label134.Text = "0";
                            Label135.Text = "0";
                        }
                    }
                }
			}
        }
        
    }
    public void bind()
    {
        DropDownList1.Items.Add("---Select---");
        DropDownList1.Items.Add("161 'D Block'");
        DropDownList1.Items.Add("Arazi 137");
		 DropDownList1.Items.Add("190");
         DropDownList1.Items.Add("397");
    }
    public void ragbind()
    {
        if (DropDownList1.Text == "Arazi 137")
        {
            SqlConnection con = new SqlConnection(s);
        Double tot = 0, sol = 0, bal = 0;
               

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
            con.Open();
           // SqlDataAdapter da1 = new SqlDataAdapter(" select gt.CID,gt.CUSTREGNO,gt.date,gt.name1,rc.sum(AMOUNTR) AS 'pmt',gt.plotno,gt.plotsize,LEFT(gt.deedno,5) AS 'deedno' from wjstar1.recipt1 as rc inner join customerdeed as gt on gt.CUSTREGNO=rc.CUSTREGNO where rc.DATE1 not between '" + date1 + "' AND '" + date2 + "' AND gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER') AND gt.date between '" + date1 + "' AND '" + date2 + "' order by rc.CUSTREGNO ", con);
            SqlDataAdapter da1 = new SqlDataAdapter("select  gt.CID,gt.CUSTREGNO,gt.date,gt.name1,c.total,rc.pmt,c.total-rc.pmt AS 'bal',c.regamt,rc.discp,gt.plotno,gt.plotsize,LEFT(gt.deedno,8) AS 'deedno' from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP') AND gt.date between '" + date1 + "' AND '" + date2 + "' order By gt.date ASC", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
	con.Open();
			SqlDataAdapter da123 = new SqlDataAdapter("select  count(gt.CUSTREGNO),sum(gt.plotsize) from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
            DataSet ds123 = new DataSet();
            da123.Fill(ds123);
            con.Close();
			Double deedcount=0,deedsize=0;
                if (ds123.Tables[0].Rows[0][0].ToString() != "")
                {
                    //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    deedcount = Convert.ToDouble(ds123.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    // Label11.Text = "0";
                   deedcount = 0;
                }
			if (ds123.Tables[0].Rows[0][1].ToString() != "")
                {
                    //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    deedsize = Convert.ToDouble(ds123.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    // Label11.Text = "0";
                   deedsize = 0;
                }
            Label123.Text="No.Of Deed = "+deedcount.ToString();
			 Label1234.Text="Total Size = "+deedsize.ToString();
            con.Open();
          //  SqlDataAdapter da111 = new SqlDataAdapter("select  sum(rc.pmt) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + date2 + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
            SqlDataAdapter da111 = new SqlDataAdapter("select  sum(rc.pmt) from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
            DataSet ds111 = new DataSet();
            da111.Fill(ds111);
            con.Close();
            Double back = 0;
            if (ds111.Tables[0].Rows[0][0].ToString() != "")
            {
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    back = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    // Label11.Text = "0";
                   back = 0;
                }
            }
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select sum(c.total),sum(rc.pmt),sum(c.total)-sum(rc.pmt),SUM(c.regamt),SUM(rc.discp) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1  WHERE DATE1 <='" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from customerdeed  where arazi='RAMAI137' AND deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP') AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP') AND gt.date<='" + date2 + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
			 con.Close();
			con.Open();
            SqlDataAdapter da556 = new SqlDataAdapter("select SUM(c.regamt),SUM(rc.discp) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1  WHERE DATE1 between '"+date1+"' AND  '" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from customerdeed  where arazi='RAMAI137' AND deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP') AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP') AND gt.date between '"+date1+"' AND '" + date2 + "'", con);
            DataSet ds556 = new DataSet();
            da556.Fill(ds556);
            con.Close();
            Double total = 0, dis = 0, free = 0, bal4 = 0, finalbal = 0, paid = 0,fr=0,disc=0;
			if (ds556.Tables[0].Rows[0][0].ToString() != "")
            {
                if (ds556.Tables[0].Rows[0][0].ToString() != "")
                {
                  //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    fr = Convert.ToDouble(ds556.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                   // Label11.Text = "0";
                    fr = 0;
                }
				if (ds556.Tables[0].Rows[0][1].ToString() != "")
                {
                  //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    disc = Convert.ToDouble(ds556.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                   // Label11.Text = "0";
                    disc = 0;
                }
				Label133.Text = (disc+fr).ToString();
			}
			else
				
			{
				
				Label133.Text = "0";
            
			}
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                  //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    total = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                   // Label11.Text = "0";
                    total = 0;
                }
                if (ds.Tables[0].Rows[0][1].ToString() != "")
                {

                    paid = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    Label12.Text = "0";
                    paid = 0;
                }
                if (ds.Tables[0].Rows[0][3].ToString() != "")
                {
                  //  Label14.Text = ds.Tables[0].Rows[0][3].ToString();
                    dis = Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                }
                else
                {
                   // Label14.Text = "0";
                    dis = 0;
                }
                if (ds.Tables[0].Rows[0][4].ToString() != "")
                {
                   // Label15.Text = ds.Tables[0].Rows[0][4].ToString();
                    free = Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
                }
                else
                {
                   // Label15.Text = "0";
                    free = 0;
                }
                Double r111 = paid - dis - free;
                Label12.Text = r111.ToString();
 
                bal4 = total - dis - free;
                Label16.Text = bal4.ToString();
                finalbal = bal4 - r111;
                Label13.Text = finalbal.ToString();
                Label17.Text = back.ToString() ;
            }
            else
            {
               // Label11.Text = "0";
                Label12.Text = "0";
                Label13.Text = "0";
               // Label14.Text = "0";
               // Label15.Text = "0";
                Label16.Text = "0";
                Label17.Text = "0";
				//Label133.Text = "0";
            }

       
      }
        else
        {
            if (DropDownList1.Text == "161 'D Block'")
            {
                SqlConnection con = new SqlConnection(s);
                Double tot = 0, sol = 0, bal = 0;


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
                con.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select  gt.CID,gt.CUSTREGNO,gt.date,gt.name1,c.total,rc.pmt,c.total-rc.pmt AS 'bal',c.regamt,rc.discp,gt.plotno,gt.plotsize,LEFT(gt.deedno,5) AS 'deedno' from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where  CUSTREGNO NOT IN('REG004362') AND arazi='152' AND deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE')  AND date between '" + date1 + "' AND '" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='152' AND gt.deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE')  AND gt.date between '" + date1 + "' AND '" + date2 + "' AND gt.CUSTREGNO NOT IN('REG004362') order By gt.date ASC", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                con.Close();
                con.Open();
                SqlDataAdapter da123 = new SqlDataAdapter("select  count(gt.CUSTREGNO),sum(gt.plotsize) from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where  CUSTREGNO NOT IN('REG004362') AND arazi='152' AND deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE')  AND date between '" + date1 + "' AND '" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='152' AND gt.deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE')  AND gt.date between '" + date1 + "' AND '" + date2 + "' AND gt.CUSTREGNO NOT IN('REG004362')", con);
                DataSet ds123 = new DataSet();
                da123.Fill(ds123);
                con.Close();
                Double deedcount = 0, deedsize = 0;
                if (ds123.Tables[0].Rows[0][0].ToString() != "")
                {
                    //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    deedcount = Convert.ToDouble(ds123.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    // Label11.Text = "0";
                    deedcount = 0;
                }
                if (ds123.Tables[0].Rows[0][1].ToString() != "")
                {
                    //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    deedsize = Convert.ToDouble(ds123.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    // Label11.Text = "0";
                    deedsize = 0;
                }
                Label123.Text = "No.Of Deed = " + deedcount.ToString();
                Label1234.Text = "Total Size = " + deedsize.ToString();
                con.Open();
               
                SqlDataAdapter da1111 = new SqlDataAdapter("select  sum(rc.pmt) from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where  CUSTREGNO NOT IN('REG004362') AND arazi='152' AND deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE')  AND date between '" + date1 + "' AND '" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='152' AND gt.deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE')  AND gt.date between '" + date1 + "' AND '" + date2 + "'  AND gt.CUSTREGNO NOT IN('REG004362')", con);
                DataSet ds1111 = new DataSet();
                da1111.Fill(ds1111);
                con.Close();
                Double back = 0;
                if (ds1111.Tables[0].Rows[0][0].ToString() != "")
                {
                    if (ds1111.Tables[0].Rows[0][0].ToString() != "")
                    {
                        //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                        back = Convert.ToDouble(ds1111.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        // Label11.Text = "0";
                        back = 0;
                    }
                }
                GridView1.DataSource = ds2;
                GridView1.DataBind();
                con.Open();
				// SqlDataAdapter da = new SqlDataAdapter("select sum(c.total),sum(rc.pmt),sum(c.total)-sum(rc.pmt),SUM(c.regamt),SUM(rc.discp) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1  WHERE DATE1 <='" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from customerdeed  where arazi='RAMAI137' AND deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER') AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER') AND gt.date<='" + date2 + "'", con);
				
                SqlDataAdapter da = new SqlDataAdapter("select sum(c.total),sum(rc.pmt),sum(c.total)-sum(rc.pmt),SUM(c.regamt),SUM(rc.discp) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 WHERE DATE1 <='" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from customerdeed  where arazi='152' AND deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE') AND date<='" + date2 + "'  AND CUSTREGNO NOT IN('REG004362')) group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='152' AND gt.deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE') AND gt.date<='"+date2+"'  AND gt.CUSTREGNO NOT IN('REG004362')", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
				con.Open();
            SqlDataAdapter da5567 = new SqlDataAdapter("select SUM(c.regamt),SUM(rc.discp) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 WHERE DATE1 between '"+date1+"' AND '" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from customerdeed  where arazi='152' AND deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE') AND date<='" + date2 + "' AND CUSTREGNO NOT IN('REG004362') ) group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO left join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='152' AND gt.deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE') AND gt.date <'" + date2 + "' AND gt.CUSTREGNO NOT IN('REG004362')", con);
            DataSet ds5567 = new DataSet();
            da5567.Fill(ds5567);
            con.Close();
            Double total = 0, dis = 0, free = 0, bal4 = 0, finalbal = 0, paid = 0,fr=0,disc=0;
			if (ds5567.Tables[0].Rows[0][0].ToString() != "")
            {
                if (ds5567.Tables[0].Rows[0][0].ToString() != "")
                {
                  //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    fr = Convert.ToDouble(ds5567.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                   // Label11.Text = "0";
                    fr = 0;
                }
				if (ds5567.Tables[0].Rows[0][1].ToString() != "")
                {
                  //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                    disc = Convert.ToDouble(ds5567.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                   // Label11.Text = "0";
                    disc = 0;
                }
				Label133.Text = (disc+fr).ToString();
			}
			else
				
			{
				
				Label133.Text = "0";
            
			}
              
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                       // Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                        total = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                       // Label11.Text = "0";
                        total = 0;
                    }
                    if (ds.Tables[0].Rows[0][1].ToString() != "")
                    {

                        paid = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                    }
                    else
                    {
                        Label12.Text = "0";
                        paid = 0;
                    }
                    if (ds.Tables[0].Rows[0][3].ToString() != "")
                    {
                       // Label14.Text = ds.Tables[0].Rows[0][3].ToString();
                        dis = Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                    }
                    else
                    {
                       // Label14.Text = "0";
                        dis = 0;
                    }
                    if (ds.Tables[0].Rows[0][4].ToString() != "")
                    {
                       // Label15.Text = ds.Tables[0].Rows[0][4].ToString();
                        free = Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
                    }
                    else
                    {
                      //  Label15.Text = "0";
                        free = 0;
                    }
                    Double r111 = paid - dis - free;
                    Label12.Text = r111.ToString();

                    bal4 = total - dis - free;
                    Label16.Text = bal4.ToString();
                    finalbal = bal4 - r111;
                    Label13.Text = finalbal.ToString();
                    Label17.Text = back.ToString();
                }
                else
                {
                   // Label11.Text = "0";
                    Label12.Text = "0";
                    Label13.Text = "0";
                   // Label14.Text = "0";
                   // Label15.Text = "0";
                    Label16.Text = "0";
                    Label17.Text = "0";
					// Label133.Text = "0";
                }

            }
            else
            {
                if (DropDownList1.Text == "190")
                {
                    SqlConnection con = new SqlConnection(s);
                    Double tot = 0, sol = 0, bal = 0;


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
                    con.Open();
                    // SqlDataAdapter da1 = new SqlDataAdapter(" select gt.CID,gt.CUSTREGNO,gt.date,gt.name1,rc.sum(AMOUNTR) AS 'pmt',gt.plotno,gt.plotsize,LEFT(gt.deedno,5) AS 'deedno' from wjstar1.recipt1 as rc inner join customerdeed as gt on gt.CUSTREGNO=rc.CUSTREGNO where rc.DATE1 not between '" + date1 + "' AND '" + date2 + "' AND gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER') AND gt.date between '" + date1 + "' AND '" + date2 + "' order by rc.CUSTREGNO ", con);
                    SqlDataAdapter da1 = new SqlDataAdapter("select  gt.CID,gt.CUSTREGNO,gt.date,gt.name1,c.total,rc.pmt,c.total-rc.pmt AS 'bal',c.regamt,rc.discp,gt.plotno,gt.plotsize,LEFT(gt.deedno,8) AS 'deedno' from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='190' AND gt.deedno in('2932_PRADEEP') AND gt.date between '" + date1 + "' AND '" + date2 + "' order By gt.date ASC", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    con.Open();
                    SqlDataAdapter da123 = new SqlDataAdapter("select  count(gt.CUSTREGNO),sum(gt.plotsize) from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='190' AND gt.deedno in('2932_PRADEEP') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
                    DataSet ds123 = new DataSet();
                    da123.Fill(ds123);
                    con.Close();
                    Double deedcount = 0, deedsize = 0;
                    if (ds123.Tables[0].Rows[0][0].ToString() != "")
                    {
                        //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                        deedcount = Convert.ToDouble(ds123.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        // Label11.Text = "0";
                        deedcount = 0;
                    }
                    if (ds123.Tables[0].Rows[0][1].ToString() != "")
                    {
                        //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                        deedsize = Convert.ToDouble(ds123.Tables[0].Rows[0][1].ToString());
                    }
                    else
                    {
                        // Label11.Text = "0";
                        deedsize = 0;
                    }
                    Label123.Text = "No.Of Deed = " + deedcount.ToString();
                    Label1234.Text = "Total Size = " + deedsize.ToString();
                    con.Open();
                    //  SqlDataAdapter da111 = new SqlDataAdapter("select  sum(rc.pmt) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + date2 + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
                    SqlDataAdapter da111 = new SqlDataAdapter("select  sum(rc.pmt) from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='190' AND gt.deedno in('2932_PRADEEP') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
                    DataSet ds111 = new DataSet();
                    da111.Fill(ds111);
                    con.Close();
                    Double back = 0;
                    if (ds111.Tables[0].Rows[0][0].ToString() != "")
                    {
                        if (ds111.Tables[0].Rows[0][0].ToString() != "")
                        {
                            //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                            back = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            // Label11.Text = "0";
                            back = 0;
                        }
                    }
                    GridView1.DataSource = ds1;
                    GridView1.DataBind();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select sum(c.total),sum(rc.pmt),sum(c.total)-sum(rc.pmt),SUM(c.regamt),SUM(rc.discp) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1  WHERE DATE1 <='" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from customerdeed  where arazi='190' AND deedno in('2932_PRADEEP') AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='190' AND gt.deedno in('2932_PRADEEP') AND gt.date<='" + date2 + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    con.Open();
                    SqlDataAdapter da556 = new SqlDataAdapter("select SUM(c.regamt),SUM(rc.discp) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1  WHERE DATE1 between '" + date1 + "' AND  '" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from customerdeed  where arazi='190' AND deedno in('2932_PRADEEP') AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='190' AND gt.deedno in('2932_PRADEEP') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
                    DataSet ds556 = new DataSet();
                    da556.Fill(ds556);
                    con.Close();
                    Double total = 0, dis = 0, free = 0, bal4 = 0, finalbal = 0, paid = 0, fr = 0, disc = 0;
                    if (ds556.Tables[0].Rows[0][0].ToString() != "")
                    {
                        if (ds556.Tables[0].Rows[0][0].ToString() != "")
                        {
                            //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                            fr = Convert.ToDouble(ds556.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            // Label11.Text = "0";
                            fr = 0;
                        }
                        if (ds556.Tables[0].Rows[0][1].ToString() != "")
                        {
                            //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                            disc = Convert.ToDouble(ds556.Tables[0].Rows[0][1].ToString());
                        }
                        else
                        {
                            // Label11.Text = "0";
                            disc = 0;
                        }
                        Label133.Text = (disc + fr).ToString();
                    }
                    else
                    {

                        Label133.Text = "0";

                    }
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                            total = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            // Label11.Text = "0";
                            total = 0;
                        }
                        if (ds.Tables[0].Rows[0][1].ToString() != "")
                        {

                            paid = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                        }
                        else
                        {
                            Label12.Text = "0";
                            paid = 0;
                        }
                        if (ds.Tables[0].Rows[0][3].ToString() != "")
                        {
                            //  Label14.Text = ds.Tables[0].Rows[0][3].ToString();
                            dis = Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                        }
                        else
                        {
                            // Label14.Text = "0";
                            dis = 0;
                        }
                        if (ds.Tables[0].Rows[0][4].ToString() != "")
                        {
                            // Label15.Text = ds.Tables[0].Rows[0][4].ToString();
                            free = Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
                        }
                        else
                        {
                            // Label15.Text = "0";
                            free = 0;
                        }
                        Double r111 = paid - dis - free;
                        Label12.Text = r111.ToString();

                        bal4 = total - dis - free;
                        Label16.Text = bal4.ToString();
                        finalbal = bal4 - r111;
                        Label13.Text = finalbal.ToString();
                        Label17.Text = back.ToString();
                    }
                    else
                    {
                        // Label11.Text = "0";
                        Label12.Text = "0";
                        Label13.Text = "0";
                        // Label14.Text = "0";
                        // Label15.Text = "0";
                        Label16.Text = "0";
                        Label17.Text = "0";
                        //Label133.Text = "0";
                    }


                }
                else
                {
                    if (DropDownList1.Text == "397")
                    {
                        SqlConnection con = new SqlConnection(s);
                        Double tot = 0, sol = 0, bal = 0;


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
                        con.Open();
                        // SqlDataAdapter da1 = new SqlDataAdapter(" select gt.CID,gt.CUSTREGNO,gt.date,gt.name1,rc.sum(AMOUNTR) AS 'pmt',gt.plotno,gt.plotsize,LEFT(gt.deedno,5) AS 'deedno' from wjstar1.recipt1 as rc inner join customerdeed as gt on gt.CUSTREGNO=rc.CUSTREGNO where rc.DATE1 not between '" + date1 + "' AND '" + date2 + "' AND gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER') AND gt.date between '" + date1 + "' AND '" + date2 + "' order by rc.CUSTREGNO ", con);
                        SqlDataAdapter da1 = new SqlDataAdapter("select  gt.CID,gt.CUSTREGNO,gt.date,gt.name1,c.total,rc.pmt,c.total-rc.pmt AS 'bal',c.regamt,rc.discp,gt.plotno,gt.plotsize,LEFT(gt.deedno,8) AS 'deedno' from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='397'  OR gt.arazi='505' AND gt.deedno in('8866_HEED','11295 MAHENDR SINGH') AND gt.date between '" + date1 + "' AND '" + date2 + "' order By gt.date ASC", con);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        con.Close();
                        con.Open();
                        SqlDataAdapter da123 = new SqlDataAdapter("select  count(gt.CUSTREGNO),sum(gt.plotsize) from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='397'  OR gt.arazi='505' AND gt.deedno in('8866_HEED','11295 MAHENDR SINGH') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
                        DataSet ds123 = new DataSet();
                        da123.Fill(ds123);
                        con.Close();
                        Double deedcount = 0, deedsize = 0;
                        if (ds123.Tables[0].Rows[0][0].ToString() != "")
                        {
                            //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                            deedcount = Convert.ToDouble(ds123.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            // Label11.Text = "0";
                            deedcount = 0;
                        }
                        if (ds123.Tables[0].Rows[0][1].ToString() != "")
                        {
                            //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                            deedsize = Convert.ToDouble(ds123.Tables[0].Rows[0][1].ToString());
                        }
                        else
                        {
                            // Label11.Text = "0";
                            deedsize = 0;
                        }
                        Label123.Text = "No.Of Deed = " + deedcount.ToString();
                        Label1234.Text = "Total Size = " + deedsize.ToString();
                        con.Open();
                        //  SqlDataAdapter da111 = new SqlDataAdapter("select  sum(rc.pmt) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + date2 + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
                        SqlDataAdapter da111 = new SqlDataAdapter("select  sum(rc.pmt) from customerdeed AS gt left join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 where DATE1 not between '" + date1 + "' AND '" + DateTime.Now + "'  group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='397'  OR gt.arazi='505' AND gt.deedno in('2932_PRADEEP','11295 MAHENDR SINGH') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
                        DataSet ds111 = new DataSet();
                        da111.Fill(ds111);
                        con.Close();
                        Double back = 0;
                        if (ds111.Tables[0].Rows[0][0].ToString() != "")
                        {
                            if (ds111.Tables[0].Rows[0][0].ToString() != "")
                            {
                                //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                                back = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                            }
                            else
                            {
                                // Label11.Text = "0";
                                back = 0;
                            }
                        }
                        GridView1.DataSource = ds1;
                        GridView1.DataBind();
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("select sum(c.total),sum(rc.pmt),sum(c.total)-sum(rc.pmt),SUM(c.regamt),SUM(rc.discp) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1  WHERE DATE1 <='" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from customerdeed  where arazi='397'  OR arazi='505' AND deedno in('8866_HEED','11295 MAHENDR SINGH') AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='397'  OR gt.arazi='505' AND gt.deedno in('8866_HEED','11295 MAHENDR SINGH') AND gt.date<='" + date2 + "'", con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        con.Open();
                        SqlDataAdapter da556 = new SqlDataAdapter("select SUM(c.regamt),SUM(rc.discp) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1  WHERE DATE1 between '" + date1 + "' AND  '" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from customerdeed  where arazi='397'  OR arazi='505' AND deedno in('8866_HEED','11295 MAHENDR SINGH') AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO  where gt.arazi='397'  OR gt.arazi='505' AND gt.deedno in('8866_HEED','11295 MAHENDR SINGH') AND gt.date between '" + date1 + "' AND '" + date2 + "'", con);
                        DataSet ds556 = new DataSet();
                        da556.Fill(ds556);
                        con.Close();
                        Double total = 0, dis = 0, free = 0, bal4 = 0, finalbal = 0, paid = 0, fr = 0, disc = 0;
                        if (ds556.Tables[0].Rows[0][0].ToString() != "")
                        {
                            if (ds556.Tables[0].Rows[0][0].ToString() != "")
                            {
                                //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                                fr = Convert.ToDouble(ds556.Tables[0].Rows[0][0].ToString());
                            }
                            else
                            {
                                // Label11.Text = "0";
                                fr = 0;
                            }
                            if (ds556.Tables[0].Rows[0][1].ToString() != "")
                            {
                                //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                                disc = Convert.ToDouble(ds556.Tables[0].Rows[0][1].ToString());
                            }
                            else
                            {
                                // Label11.Text = "0";
                                disc = 0;
                            }
                            Label133.Text = (disc + fr).ToString();
                        }
                        else
                        {

                            Label133.Text = "0";

                        }
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            if (ds.Tables[0].Rows[0][0].ToString() != "")
                            {
                                //  Label11.Text = ds.Tables[0].Rows[0][0].ToString();
                                total = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                            }
                            else
                            {
                                // Label11.Text = "0";
                                total = 0;
                            }
                            if (ds.Tables[0].Rows[0][1].ToString() != "")
                            {

                                paid = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                            }
                            else
                            {
                                Label12.Text = "0";
                                paid = 0;
                            }
                            if (ds.Tables[0].Rows[0][3].ToString() != "")
                            {
                                //  Label14.Text = ds.Tables[0].Rows[0][3].ToString();
                                dis = Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                            }
                            else
                            {
                                // Label14.Text = "0";
                                dis = 0;
                            }
                            if (ds.Tables[0].Rows[0][4].ToString() != "")
                            {
                                // Label15.Text = ds.Tables[0].Rows[0][4].ToString();
                                free = Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
                            }
                            else
                            {
                                // Label15.Text = "0";
                                free = 0;
                            }
                            Double r111 = paid - dis - free;
                            Label12.Text = r111.ToString();

                            bal4 = total - dis - free;
                            Label16.Text = bal4.ToString();
                            finalbal = bal4 - r111;
                            Label13.Text = finalbal.ToString();
                            Label17.Text = back.ToString();
                        }
                        else
                        {
                            // Label11.Text = "0";
                            Label12.Text = "0";
                            Label13.Text = "0";
                            // Label14.Text = "0";
                            // Label15.Text = "0";
                            Label16.Text = "0";
                            Label17.Text = "0";
                            //Label133.Text = "0";
                        }


                    }
                }
            }
        }
    }
    public void ragbind1()
    {
        if (DropDownList1.Text == "Arazi 137")
        {
            SqlConnection con = new SqlConnection(s);
            Double tot = 0, sol = 0, bal = 0;


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
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select  gt.CID,gt.CUSTREGNO,gt.date,left(gt.name1,25) as name1,c.total,rc.pmt,c.total-rc.pmt AS 'bal',c.regamt,rc.discp,rc1.recv,gt.plotno,gt.plotsize,LEFT(gt.deedno,8) AS 'deedno' from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 WHERE DATE1 <='"+date2+"' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where arazi='RAMAI137' AND deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP')  AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(AMOUNTR) AS recv from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' group By CUSTREGNO) as rc1 ON gt.CUSTREGNO=rc1.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO   where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP') AND gt.date <='" + date2 + "'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            GridView2.DataSource = ds1;
            GridView2.DataBind();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(rc1.recv) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(AMOUNTR) AS recv from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where arazi='RAMAI137' AND deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP')  AND date<='" + date2 + "') group By CUSTREGNO) as rc1 ON gt.CUSTREGNO=rc1.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO where gt.arazi='RAMAI137' AND gt.deedno in('2324 Pradeep','2741 ASHOK','2741 ZAHEER','4781 ASHOK','4781 ZAHEER','2324 Gopal','2324 Lov','2228 PRADEEP') AND gt.date <='" + date2 + "'", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label1.Text = ds2.Tables[0].Rows[0][0].ToString();

                }
                else
                {
                    Label1.Text = "0";

                }
            }
            else
            {
                Label1.Text = "0";

            }
     


        }
        else
        {
            if (DropDownList1.Text == "161 'D Block'")
            {
                SqlConnection con = new SqlConnection(s);
                Double tot = 0, sol = 0, bal = 0;


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
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("select  gt.CID,gt.CUSTREGNO,gt.date,left(gt.name1,25) as name1,c.total,rc.pmt,c.total-rc.pmt AS 'bal',c.regamt,rc.discp,rc1.recv,gt.plotno,gt.plotsize,LEFT(gt.deedno,5) AS 'deedno' from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 WHERE DATE1 <='" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where arazi='152' AND deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE')  AND date<='" + date2 + "' AND CUSTREGNO NOT IN('REG004362')) group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(AMOUNTR) AS recv from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' group By CUSTREGNO) as rc1 ON gt.CUSTREGNO=rc1.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO   where gt.arazi='152' AND gt.deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE') AND gt.date <='" + date2 + "' AND gt.CUSTREGNO NOT IN('REG004362')", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                GridView2.DataSource = ds1;
                GridView2.DataBind();
                con.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select sum(rc1.recv) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(AMOUNTR) AS recv from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where arazi='152' AND deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE')  AND date <='" + date2 + "' AND CUSTREGNO NOT IN('REG004362')) group By CUSTREGNO) as rc1 ON gt.CUSTREGNO=rc1.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO   where gt.arazi='152' AND gt.deedno in('15463,BHADORIYA','2993  ASHOK NUKUL','2993  ZAHEER NUKUL','6473 ASHOK NUKUL','6473 ZAHEER NUKUL','HOARASHOKNUKUL_COMBINE','HOARZAHEERNUKUL_COMBINE') AND gt.date <='" + date2 + "' AND gt.CUSTREGNO NOT IN('REG004362')", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                con.Close();
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    {
                        Label1.Text = ds2.Tables[0].Rows[0][0].ToString();
                       
                    }
                    else
                    {
                        Label1.Text = "0";
                       
                    }
                }
                else
                {
                    Label1.Text = "0";

                }

            }
            else
            {
                if (DropDownList1.Text == "190")
                {
                    SqlConnection con = new SqlConnection(s);
                    Double tot = 0, sol = 0, bal = 0;


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
                    con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("select  gt.CID,gt.CUSTREGNO,gt.date,left(gt.name1,25) as name1,c.total,rc.pmt,c.total-rc.pmt AS 'bal',c.regamt,rc.discp,rc1.recv,gt.plotno,gt.plotsize,LEFT(gt.deedno,8) AS 'deedno' from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 WHERE DATE1 <='" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where arazi='190' AND deedno in('2932_PRADEEP')  AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(AMOUNTR) AS recv from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' group By CUSTREGNO) as rc1 ON gt.CUSTREGNO=rc1.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO   where gt.arazi='190' AND gt.deedno in('2932_PRADEEP') AND gt.date <='" + date2 + "'", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    GridView2.DataSource = ds1;
                    GridView2.DataBind();
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select sum(rc1.recv) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(AMOUNTR) AS recv from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where arazi='190' AND deedno in('2932_PRADEEP')  AND date<='" + date2 + "') group By CUSTREGNO) as rc1 ON gt.CUSTREGNO=rc1.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO where gt.arazi='190' AND gt.deedno in('2932_PRADEEP') AND gt.date <='" + date2 + "'", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    con.Close();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        if (ds2.Tables[0].Rows[0][0].ToString() != "")
                        {
                            Label1.Text = ds2.Tables[0].Rows[0][0].ToString();

                        }
                        else
                        {
                            Label1.Text = "0";

                        }
                    }
                    else
                    {
                        Label1.Text = "0";

                    }



                }
                else
                {
                    if (DropDownList1.Text == "397")
                    {
                        SqlConnection con = new SqlConnection(s);
                        Double tot = 0, sol = 0, bal = 0;


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
                        con.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter("select  gt.CID,gt.CUSTREGNO,gt.date,left(gt.name1,25) as name1,c.total,rc.pmt,c.total-rc.pmt AS 'bal',c.regamt,rc.discp,rc1.recv,gt.plotno,gt.plotsize,LEFT(gt.deedno,8) AS 'deedno' from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 WHERE DATE1 <='" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where arazi='397'  OR arazi='505' AND deedno in('8866_HEED','11295 MAHENDR SINGH')  AND date<='" + date2 + "') group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(AMOUNTR) AS recv from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' group By CUSTREGNO) as rc1 ON gt.CUSTREGNO=rc1.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO   where gt.arazi='397'  OR gt.arazi='505' AND gt.deedno in('8866_HEED','11295 MAHENDR SINGH') AND gt.date <='" + date2 + "'", con);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        con.Close();
                        GridView2.DataSource = ds1;
                        GridView2.DataBind();
                        con.Open();
                        SqlDataAdapter da2 = new SqlDataAdapter("select sum(rc1.recv) from customerdeed AS gt inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt,sum(discountprice) AS discp from wjstar1.recipt1 group By CUSTREGNO) as rc ON gt.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(AMOUNTR) AS recv from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where arazi='397' OR arazi='505'  AND deedno in('8866_HEED','11295 MAHENDR SINGH')  AND date<='" + date2 + "') group By CUSTREGNO) as rc1 ON gt.CUSTREGNO=rc1.CUSTREGNO inner join (select CUSTREGNO,sum(CONSAMOUNT) AS total,case when sum(ragistryamt) > 0 then sum(ragistryamt)+5000 else 0 end AS regamt from wjstar1.customerreg1 group By CUSTREGNO) as c ON gt.CUSTREGNO=c.CUSTREGNO where gt.arazi='397'  OR gt.arazi='505' AND gt.deedno in('8866_HEED','11295 MAHENDR SINGH') AND gt.date <='" + date2 + "'", con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        con.Close();
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            if (ds2.Tables[0].Rows[0][0].ToString() != "")
                            {
                                Label1.Text = ds2.Tables[0].Rows[0][0].ToString();

                            }
                            else
                            {
                                Label1.Text = "0";

                            }
                        }
                        else
                        {
                            Label1.Text = "0";

                        }



                    }
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ragbind();
        ragbind1();
        bind2();
        Double cur = 0, back = 0, rec = 0;
        if (Label1.Text != "")
        {
            cur = Convert.ToDouble(Label1.Text);
        }
        else
        {
            cur = 0;
        }
        if (Label17.Text != "")
        {
            back = Convert.ToDouble(Label17.Text);
        }
        else
        {
            back = 0;
        }
        rec = back + cur;
        Label18.Text = rec.ToString();
    }
}