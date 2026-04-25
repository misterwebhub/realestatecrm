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


public partial class arazi187kha_arazi187kha : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='187-KHA' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='187-KHA' AND  CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='187-KHA' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='187-KHA' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='187-KHA' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazimap where arazi='187-KHA' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='187-KHA' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            SqlDataAdapter da5 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='187-KHA' AND CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='187-KHA') ", con);

            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds3.Tables[0].Rows[0][0].ToString() != "")
            {
                Label1.Text = ds3.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label1.Text = "0";
            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][2].ToString() == "empty")
                    {
                        if (ds.Tables[0].Rows[i][1].ToString() == "189")
                            p189.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "190")
                            p190.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "191")
                            p191.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "192")
                            p192.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "193")
                            p193.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "194")
                            p194.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "195")
                            p195.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "196")
                            p196.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "197")
                            p197.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "198")
                            p198.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "199")
                            p199.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "200")
                            p200.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "201")
                            p201.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "202")
                            p202.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "203")
                            p203.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "204")
                            p204.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "205")
                            p205.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "206")
                            p206.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "207")
                            p207.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "208")
                            p208.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "209")
                            p209.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "210")
                            p210.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "211")
                            p211.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "212")
                            p212.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "213")
                            p213.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "214")
                            p214.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "215")
                            p215.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "216")
                            p216.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "217")
                            p217.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "218")
                            p218.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "219")
                            p219.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "220")
                            p220.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "221")
                            p221.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "222")
                            p222.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "223")
                            p223.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "224")
                            p224.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "225")
                            p225.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "226")
                            p226.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "227")
                            p227.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "228")
                            p228.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "229")
                            p229.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "230")
                            p230.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "231")
                            p231.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "232")
                            p232.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "233")
                            p233.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "234")
                            p234.BackImageUrl = "amar.gif";
                       



                    }
                    if (ds.Tables[0].Rows[i][2].ToString() == "book")
                    {
                        if (ds.Tables[0].Rows[i][1].ToString() == "189")
                            p189.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "190")
                            p190.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "191")
                            p191.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "192")
                            p192.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "193")
                            p193.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "194")
                            p194.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "195")
                            p195.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "196")
                            p196.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "197")
                            p197.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "198")
                            p198.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "199")
                            p199.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "200")
                            p200.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "201")
                            p201.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "202")
                            p202.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "203")
                            p203.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "204")
                            p204.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "205")
                            p205.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "206")
                            p206.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "207")
                            p207.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "208")
                            p208.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "209")
                            p209.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "210")
                            p210.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "211")
                            p211.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "212")
                            p212.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "213")
                            p213.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "214")
                            p214.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "215")
                            p215.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "216")
                            p216.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "217")
                            p217.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "218")
                            p218.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "219")
                            p219.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "220")
                            p220.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "221")
                            p221.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "222")
                            p222.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "223")
                            p223.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "224")
                            p224.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "225")
                            p225.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "226")
                            p226.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "227")
                            p227.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "228")
                            p228.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "229")
                            p229.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "230")
                            p230.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "231")
                            p231.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "232")
                            p232.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "233")
                            p233.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "234")
                            p234.BackColor = Color.Green;




                    }
                }
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (ds1.Tables[0].Rows[i][1].ToString() == "189")
                        p189.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "190")
                        p190.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "191")
                        p191.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "192")
                        p192.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "193")
                        p193.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "194")
                        p194.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "195")
                        p195.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "196")
                        p196.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "197")
                        p197.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "198")
                        p198.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "199")
                        p199.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "200")
                        p200.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "201")
                        p201.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "202")
                        p202.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "203")
                        p203.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "204")
                        p204.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "205")
                        p205.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "206")
                        p206.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "207")
                        p207.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "208")
                        p208.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "209")
                        p209.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "210")
                        p210.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "211")
                        p211.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "212")
                        p212.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "213")
                        p213.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "214")
                        p214.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "215")
                        p215.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "216")
                        p216.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "217")
                        p217.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "218")
                        p218.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "219")
                        p219.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "220")
                        p220.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "221")
                        p221.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "222")
                        p222.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "223")
                        p223.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "224")
                        p224.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "225")
                        p225.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "226")
                        p226.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "227")
                        p227.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "228")
                        p228.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "229")
                        p229.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "230")
                        p230.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "231")
                        p231.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "232")
                        p232.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "233")
                        p233.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "234")
                        p234.BackColor = Color.Red;


                }

            }
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (ds2.Tables[0].Rows[i][1].ToString() == "189")
                        p189.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "190")
                        p190.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "191")
                        p191.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "192")
                        p192.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "193")
                        p193.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "194")
                        p194.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "195")
                        p195.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "196")
                        p196.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "197")
                        p197.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "198")
                        p198.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "199")
                        p199.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "200")
                        p200.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "201")
                        p201.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "202")
                        p202.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "203")
                        p203.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "204")
                        p204.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "205")
                        p205.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "206")
                        p206.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "207")
                        p207.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "208")
                        p208.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "209")
                        p209.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "210")
                        p210.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "211")
                        p211.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "212")
                        p212.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "213")
                        p213.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "214")
                        p214.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "215")
                        p215.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "216")
                        p216.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "217")
                        p217.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "218")
                        p218.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "219")
                        p219.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "220")
                        p220.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "221")
                        p221.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "222")
                        p222.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "223")
                        p223.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "224")
                        p224.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "225")
                        p225.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "226")
                        p226.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "227")
                        p227.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "228")
                        p228.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "229")
                        p229.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "230")
                        p230.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "231")
                        p231.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "232")
                        p232.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "233")
                        p233.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "234")
                        p234.BackImageUrl = "blue.gif";


                }
            }
            if (ds5.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                {
                    if (ds5.Tables[0].Rows[i][1].ToString() == "189")
                        p189.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "190")
                        p190.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "191")
                        p191.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "192")
                        p192.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "193")
                        p193.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "194")
                        p194.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "195")
                        p195.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "196")
                        p196.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "197")
                        p197.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "198")
                        p198.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "199")
                        p199.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "200")
                        p200.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "201")
                        p201.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "202")
                        p202.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "203")
                        p203.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "204")
                        p204.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "205")
                        p205.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "206")
                        p206.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "207")
                        p207.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "208")
                        p208.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "209")
                        p209.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "210")
                        p210.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "211")
                        p211.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "212")
                        p212.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "213")
                        p213.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "214")
                        p214.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "215")
                        p215.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "216")
                        p216.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "217")
                        p217.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "218")
                        p218.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "219")
                        p219.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "220")
                        p220.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "221")
                        p221.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "222")
                        p222.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "223")
                        p223.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "224")
                        p224.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "225")
                        p225.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "226")
                        p226.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "227")
                        p227.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "228")
                        p228.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "229")
                        p229.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "230")
                        p230.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "231")
                        p231.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "232")
                        p232.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "233")
                        p233.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "234")
                        p234.BackImageUrl = "notsale.jpg";


                }
            }
        }
        catch (Exception r)
        {
            Label1.Text = r.ToString();
        }
    }
}