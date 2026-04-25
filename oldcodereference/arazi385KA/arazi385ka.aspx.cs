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

public partial class arazi385KA_arazi385ka : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='385KA' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='385KA' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='385KA' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select arazi,plotno,status from arazimap where  arazi='385KA' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='385KA' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazimap where   arazi='385KA' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='385KA' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
			 SqlDataAdapter da5 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='385KA' AND CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='385KA') ", con);
           
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();


//arazi 356 map


 con.Open();
            SqlDataAdapter da356 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='356' ", con);
            DataSet ds356 = new DataSet();
            da356.Fill(ds356);
            con.Close();
            con.Open();
            SqlDataAdapter da1356 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='356' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='356' AND regstatus IN('Registry'))", con);
            DataSet ds1356 = new DataSet();
            da1356.Fill(ds1356);
            con.Close();
            con.Open();
            SqlDataAdapter da2356 = new SqlDataAdapter("select arazi,plotno,status from arazimap where  arazi='356' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='356' AND regstatus IN('completed'))", con);
            DataSet ds2356 = new DataSet();
            da2356.Fill(ds2356);
            con.Close();
            con.Open();
            SqlDataAdapter da3356 = new SqlDataAdapter("select count(plotno) from arazimap where   arazi='356' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='356' AND regstatus IN('completed'))", con);
            DataSet ds3356 = new DataSet();
            da3356.Fill(ds3356);
            con.Close();
			 SqlDataAdapter da5356 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='356' AND CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='356') ", con);
           
            DataSet ds5356 = new DataSet();
            da5356.Fill(ds5356);
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
                         if (ds.Tables[0].Rows[i][1].ToString() == "1")
                             p1.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "2")
                             p2.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "3")
                             p3.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "4")
                             p4.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "5")
                             p5.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "6")
                             p6.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "7")
                             p7.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "8")
                             p8.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "9")
                             p9.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "10")
                             p10.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "11")
                             p11.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "12")
                             p12.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "13")
                             p13.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "14")
                             p14.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "15")
                             p15.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "16")
                             p16.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "17")
                             p17.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "18")
                             p18.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "19")
                             p19.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "20")
                             p20.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "21")
                             p21.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "22")
                             p22.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "23")
                             p23.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "24")
                             p24.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "25")
                             p25.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "26")
                             p26.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "27")
                             p27.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "28")
                             p28.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "29")
                             p29.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "30")
                             p30.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "31")
                             p31.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "32")
                             p32.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "33")
                             p33.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "34")
                             p34.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "35")
                             p35.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "36")
                             p36.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "37")
                             p37.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "38")
                             p38.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "39")
                             p39.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "40")
                             p40.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "41")
                             p41.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "42")
                             p42.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "43")
                             p43.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "44")
                             p44.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "45")
                             p45.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "46")
                             p46.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "47")
                             p47.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "48")
                             p48.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "49")
                             p49.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "50")
                             p50.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "51")
                             p51.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "52")
                             p52.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "53")
                             p53.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "54")
                             p54.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "55")
                             p55.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "56")
                             p56.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "57")
                             p57.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "58")
                             p58.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "59")
                             p59.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "60")
                             p60.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "61")
                             p61.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "62")
                             p62.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "63")
                             p63.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "64")
                             p64.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "65")
                             p65.BackImageUrl = "amar.gif";
                          if (ds.Tables[0].Rows[i][1].ToString() == "66")
                             p66.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "67")
                             p67.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "68")
                             p68.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "69")
                             p69.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "70")
                             p70.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "71")
                             p71.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "72")
                             p72.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "73")
                             p73.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "74")
                             p74.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "75")
                             p75.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "76")
                             p76.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "77")
                             p77.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "78")
                             p78.BackImageUrl = "amar.gif";
						 if (ds.Tables[0].Rows[i][1].ToString() == "79")
                             p79.BackImageUrl = "amar.gif";
						 if (ds.Tables[0].Rows[i][1].ToString() == "80")
                             p80.BackImageUrl = "amar.gif";
						 if (ds.Tables[0].Rows[i][1].ToString() == "81")
                             p81.BackImageUrl = "amar.gif";
						 if (ds.Tables[0].Rows[i][1].ToString() == "82")
                             p82.BackImageUrl = "amar.gif";
						 if (ds.Tables[0].Rows[i][1].ToString() == "83")
                             p83.BackImageUrl = "amar.gif";
                    
                    

                    }
                    if (ds.Tables[0].Rows[i][2].ToString() == "book")
                    {
                       if (ds.Tables[0].Rows[i][1].ToString() == "1")
                            p1.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "2")
                            p2.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "3")
                            p3.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "4")
                            p4.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "5")
                            p5.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "6")
                            p6.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "7")
                            p7.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "8")
                            p8.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "9")
                            p9.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "10")
                            p10.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "11")
                            p11.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "12")
                            p12.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "13")
                            p13.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "14")
                            p14.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "15")
                            p15.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "16")
                            p16.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "17")
                            p17.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "18")
                            p18.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "19")
                            p19.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "20")
                            p20.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "21")
                            p21.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "22")
                            p22.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "23")
                            p23.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "24")
                            p24.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "25")
                            p25.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "26")
                            p26.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "27")
                            p27.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "28")
                            p28.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "29")
                            p29.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "30")
                            p30.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "31")
                            p31.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "32")
                            p32.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "33")
                            p33.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "34")
                            p34.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "35")
                            p35.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "36")
                            p36.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "37")
                            p37.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "38")
                            p38.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "39")
                            p39.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "40")
                            p40.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "41")
                            p41.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "42")
                            p42.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "43")
                            p43.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "44")
                            p44.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "45")
                            p45.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "46")
                            p46.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "47")
                            p47.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "48")
                            p48.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "49")
                            p49.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "50")
                            p50.BackColor = Color.Green;
                         if (ds.Tables[0].Rows[i][1].ToString() == "50")
                            p50.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "51")
                            p51.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "52")
                            p52.BackColor = Color.Green;
                    if (ds.Tables[0].Rows[i][1].ToString() == "53")
                         p53.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "54")
                            p54.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "55")
                            p55.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "56")
                            p56.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "57")
                            p57.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "58")
                            p58.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "59")
                            p59.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "60")
                            p60.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "61")
                            p61.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "62")
                            p62.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "63")
                            p63.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "64")
                            p64.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "65")
                            p65.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "66")
                            p66.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "67")
                            p67.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "68")
                            p68.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "69")
                            p69.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "70")
                            p70.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "71")
                            p71.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "72")
                            p72.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "73")
                            p73.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "74")
                            p74.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "75")
                            p75.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "76")
                            p76.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "77")
                            p77.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "78")
                            p78.BackColor = Color.Green;
						 if (ds.Tables[0].Rows[i][1].ToString() == "79")
                             p79.BackColor = Color.Green;
						 if (ds.Tables[0].Rows[i][1].ToString() == "80")
                             p80.BackColor = Color.Green;
						 if (ds.Tables[0].Rows[i][1].ToString() == "81")
                             p81.BackColor = Color.Green;
						 if (ds.Tables[0].Rows[i][1].ToString() == "82")
                             p82.BackColor = Color.Green;
						 if (ds.Tables[0].Rows[i][1].ToString() == "83")
                             p83.BackColor = Color.Green;
						
                      


                    }
                }
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (ds1.Tables[0].Rows[i][1].ToString() == "1")
                         p1.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "2")
                         p2.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "3")
                         p3.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "4")
                         p4.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "5")
                         p5.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "6")
                         p6.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "7")
                         p7.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "8")
                         p8.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "9")
                         p9.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "10")
                         p10.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "11")
                         p11.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "12")
                         p12.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "13")
                         p13.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "14")
                         p14.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "15")
                         p15.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "16")
                         p16.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "17")
                         p17.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "18")
                         p18.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "19")
                         p19.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "20")
                         p20.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "21")
                         p21.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "22")
                         p22.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "23")
                         p23.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "24")
                         p24.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "25")
                         p25.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "26")
                         p26.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "27")
                         p27.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "28")
                         p28.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "29")
                         p29.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "30")
                         p30.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "31")
                         p31.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "32")
                         p32.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "33")
                         p33.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "34")
                         p34.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "35")
                         p35.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "36")
                         p36.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "37")
                         p37.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "38")
                         p38.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "39")
                         p39.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "40")
                         p40.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "41")
                         p41.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "42")
                         p42.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "43")
                         p43.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "44")
                         p44.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "45")
                         p45.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "46")
                         p46.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "47")
                         p47.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "48")
                         p48.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "49")
                         p49.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "50")
                         p50.BackColor = Color.Red;
                      if (ds1.Tables[0].Rows[i][1].ToString() == "51")
                         p51.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "52")
                         p52.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "53")
                       p53.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "54")
                         p54.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "55")
                         p55.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "56")
                         p56.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "57")
                         p57.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "58")
                         p58.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "59")
                         p59.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "60")
                         p60.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "61")
                         p61.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "62")
                         p62.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "63")
                         p63.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "64")
                         p64.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "65")
                         p65.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "66")
                         p66.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "67")
                         p67.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "68")
                         p68.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "69")
                         p69.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "70")
                         p70.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "71")
                         p71.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "72")
                         p72.BackColor = Color.Red;
                    //p72.BackColor = Color.Green;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "73")
                         p73.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "74")
                         p74.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "75")
                         p75.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "76")
                         p76.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "77")
                         p77.BackColor = Color.Red;
                     if (ds1.Tables[0].Rows[i][1].ToString() == "78")
                         p78.BackColor = Color.Red;
                      if (ds1.Tables[0].Rows[i][1].ToString() == "79")
                             p79.BackColor = Color.Red;
						 if (ds1.Tables[0].Rows[i][1].ToString() == "80")
                             p80.BackColor = Color.Red;
						 if (ds1.Tables[0].Rows[i][1].ToString() == "81")
                             p81.BackColor = Color.Red;
						 if (ds1.Tables[0].Rows[i][1].ToString() == "82")
                             p82.BackColor = Color.Red;
					 if (ds1.Tables[0].Rows[i][1].ToString() == "83")
                             p83.BackColor = Color.Red;
					

                }

            }
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (ds2.Tables[0].Rows[i][1].ToString() == "1")
                         p1.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "2")
                         p2.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "3")
                         p3.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "4")
                         p4.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "5")
                         p5.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "6")
                         p6.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "7")
                         p7.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "8")
                         p8.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "9")
                         p9.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "10")
                         p10.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "11")
                         p11.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "12")
                         p12.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "13")
                         p13.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "14")
                         p14.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "15")
                         p15.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "16")
                         p16.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "17")
                         p17.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "18")
                         p18.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "19")
                         p19.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "20")
                         p20.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "21")
                         p21.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "22")
                         p22.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "23")
                         p23.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "24")
                         p24.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "25")
                         p25.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "26")
                         p26.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "27")
                         p27.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "28")
                         p28.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "29")
                         p29.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "30")
                         p30.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "31")
                         p31.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "32")
                         p32.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "33")
                         p33.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "34")
                         p34.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "35")
                         p35.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "36")
                         p36.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "37")
                         p37.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "38")
                         p38.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "39")
                         p39.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "40")
                         p40.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "41")
                         p41.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "42")
                         p42.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "43")
                         p43.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "44")
                         p44.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "45")
                         p45.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "46")
                         p46.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "47")
                         p47.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "48")
                         p48.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "49")
                         p49.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "50")
                         p50.BackImageUrl = "blue.gif";
                      if (ds2.Tables[0].Rows[i][1].ToString() == "51")
                         p51.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "52")
                         p52.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "53")
                        p53.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "54")
                         p54.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "55")
                         p55.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "56")
                         p56.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "57")
                         p57.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "58")
                         p58.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "59")
                         p59.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "60")
                         p60.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "61")
                         p61.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "62")
                         p62.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "63")
                         p63.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "64")
                         p64.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "65")
                         p65.BackImageUrl = "blue.gif";
                      if (ds2.Tables[0].Rows[i][1].ToString() == "66")
                         p66.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "67")
                         p67.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "68")
                         p68.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "69")
                         p69.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "70")
                         p70.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "71")
                         p71.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "72")
                         p72.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "73")
                         p73.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "74")
                         p74.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "75")
                         p75.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "76")
                         p76.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "77")
                         p77.BackImageUrl = "blue.gif";
                     if (ds2.Tables[0].Rows[i][1].ToString() == "78")
                         p78.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "79")
                             p79.BackImageUrl = "blue.gif";
						 if (ds2.Tables[0].Rows[i][1].ToString() == "80")
                             p80.BackImageUrl = "blue.gif";
						 if (ds2.Tables[0].Rows[i][1].ToString() == "81")
                             p81.BackImageUrl = "blue.gif";
						 if (ds2.Tables[0].Rows[i][1].ToString() == "82")
                             p82.BackImageUrl = "blue.gif";
					 if (ds2.Tables[0].Rows[i][1].ToString() == "83")
                             p83.BackImageUrl = "blue.gif";
					 
                    
                }
            }
			if (ds5.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                {
                    if (ds5.Tables[0].Rows[i][1].ToString() == "1")
                         p1.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "2")
                         p2.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "3")
                         p3.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "4")
                         p4.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "5")
                         p5.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "6")
                         p6.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "7")
                         p7.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "8")
                         p8.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "9")
                         p9.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "10")
                         p10.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "11")
                         p11.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "12")
                         p12.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "13")
                         p13.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "14")
                         p14.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "15")
                         p15.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "16")
                         p16.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "17")
                         p17.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "18")
                         p18.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "19")
                         p19.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "20")
                         p20.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "21")
                         p21.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "22")
                         p22.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "23")
                         p23.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "24")
                         p24.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "25")
                         p25.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "26")
                         p26.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "27")
                         p27.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "28")
                         p28.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "29")
                         p29.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "30")
                         p30.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "31")
                         p31.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "32")
                         p32.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "33")
                         p33.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "34")
                         p34.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "35")
                         p35.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "36")
                         p36.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "37")
                         p37.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "38")
                         p38.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "39")
                         p39.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "40")
                         p40.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "41")
                         p41.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "42")
                         p42.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "43")
                         p43.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "44")
                         p44.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "45")
                         p45.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "46")
                         p46.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "47")
                         p47.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "48")
                         p48.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "49")
                         p49.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "50")
                         p50.BackImageUrl = "notsale.jpg";
                      if (ds5.Tables[0].Rows[i][1].ToString() == "51")
                         p51.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "52")
                         p52.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "53")
                       p53.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "54")
                         p54.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "55")
                         p55.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "56")
                         p56.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "57")
                         p57.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "58")
                         p58.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "59")
                         p59.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "60")
                         p60.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "61")
                         p61.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "62")
                         p62.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "63")
                         p63.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "64")
                         p64.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "65")
                         p65.BackImageUrl = "notsale.jpg";
                      if (ds5.Tables[0].Rows[i][1].ToString() == "66")
                         p66.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "67")
                         p67.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "68")
                         p68.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "69")
                         p69.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "70")
                         p70.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "71")
                         p71.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "72")
                         p72.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "73")
                         p73.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "74")
                         p74.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "75")
                         p75.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "76")
                         p76.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "77")
                         p77.BackImageUrl = "notsale.jpg";
                     if (ds5.Tables[0].Rows[i][1].ToString() == "78")
                         p78.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "79")
                             p79.BackImageUrl ="notsale.jpg";
						 if (ds5.Tables[0].Rows[i][1].ToString() == "80")
                             p80.BackImageUrl = "notsale.jpg";
						 if (ds5.Tables[0].Rows[i][1].ToString() == "81")
                             p81.BackImageUrl = "notsale.jpg";
						 if (ds5.Tables[0].Rows[i][1].ToString() == "82")
                             p82.BackImageUrl ="notsale.jpg";
					if (ds5.Tables[0].Rows[i][1].ToString() == "83")
                             p83.BackImageUrl ="notsale.jpg";
					
                }
            }

//arazi 356


            if (ds356.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds356.Tables[0].Rows.Count; i++)
                {
                    if (ds356.Tables[0].Rows[i][2].ToString() == "empty")
                    {
                         if (ds356.Tables[0].Rows[i][1].ToString() == "1")
                             sp1.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "2")
                             sp2.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "3")
                             sp3.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "4")
                             sp4.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "5")
                             sp5.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "6")
                             sp6.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "7")
                             sp7.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "8")
                             sp8.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "9")
                             sp9.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "10")
                             sp10.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "11")
                             sp11.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "12")
                             sp12.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "13")
                             sp13.BackImageUrl = "amar.gif";
                         if (ds356.Tables[0].Rows[i][1].ToString() == "14")
                             sp14.BackImageUrl = "amar.gif";
						 if (ds356.Tables[0].Rows[i][1].ToString() == "15")
                             sp15.BackImageUrl = "amar.gif";
						 if (ds356.Tables[0].Rows[i][1].ToString() == "16")
                             sp16.BackImageUrl = "amar.gif";
        
                     /*    if (ds356.Tables[0].Rows[i][1].ToString() == "53")
                             sp53.BackImageUrl = "amar.gif";*/
          
                    

                    }
                    if (ds356.Tables[0].Rows[i][2].ToString() == "book")
                    {
                       if (ds356.Tables[0].Rows[i][1].ToString() == "1")
                            sp1.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "2")
                            sp2.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "3")
                            sp3.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "4")
                            sp4.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "5")
                            sp5.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "6")
                            sp6.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "7")
                            sp7.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "8")
                            sp8.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "9")
                            sp9.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "10")
                            sp10.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "11")
                            sp11.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "12")
                            sp12.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "13")
                            sp13.BackColor = Color.Green;
                        if (ds356.Tables[0].Rows[i][1].ToString() == "14")
                            sp14.BackColor = Color.Green;
						if (ds356.Tables[0].Rows[i][1].ToString() == "15")
                            sp15.BackColor = Color.Green;
						if (ds356.Tables[0].Rows[i][1].ToString() == "16")
                            sp16.BackColor = Color.Green;
                      
                       /* if (ds356.Tables[0].Rows[i][1].ToString() == "53")
                           sp53.BackColor = Color.Green;*/
     
                      


                    }
                }
            }
            if (ds1356.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1356.Tables[0].Rows.Count; i++)
                {
                    if (ds1356.Tables[0].Rows[i][1].ToString() == "1")
                         sp1.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "2")
                         sp2.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "3")
                         sp3.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "4")
                         sp4.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "5")
                         sp5.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "6")
                         sp6.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "7")
                         sp7.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "8")
                         sp8.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "9")
                         sp9.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "10")
                         sp10.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "11")
                         sp11.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "12")
                         sp12.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "13")
                         sp13.BackColor = Color.Red;
                     if (ds1356.Tables[0].Rows[i][1].ToString() == "14")
                         sp14.BackColor = Color.Red;
 if (ds1356.Tables[0].Rows[i][1].ToString() == "15")
                         sp15.BackColor = Color.Red;
					 if (ds1356.Tables[0].Rows[i][1].ToString() == "16")
                         sp16.BackColor = Color.Red;


              /*    if (ds1356.Tables[0].Rows[i][1].ToString() == "53")
                       sp53.BackColor = Color.Red;*/
    
                    

                }

            }
            if (ds2356.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2356.Tables[0].Rows.Count; i++)
                {
                    if (ds2356.Tables[0].Rows[i][1].ToString() == "1")
                         sp1.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "2")
                         sp2.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "3")
                         sp3.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "4")
                         sp4.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "5")
                         sp5.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "6")
                         sp6.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "7")
                         sp7.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "8")
                         sp8.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "9")
                         sp9.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "10")
                         sp10.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "11")
                         sp11.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "12")
                         sp12.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "13")
                         sp13.BackImageUrl = "blue.gif";
                     if (ds2356.Tables[0].Rows[i][1].ToString() == "14")
                         sp14.BackImageUrl = "blue.gif";
					 if (ds2356.Tables[0].Rows[i][1].ToString() == "15")
                         sp15.BackImageUrl = "blue.gif";
					 if (ds2356.Tables[0].Rows[i][1].ToString() == "16")
                         sp16.BackImageUrl = "blue.gif";
   
                  /*  if (ds2356.Tables[0].Rows[i][1].ToString() == "53")
                         sp53.BackImageUrl = "blue.gif";*/
  
                    
                }
            } 
			if (ds5356.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds5356.Tables[0].Rows.Count; i++)
                {
                    if (ds5356.Tables[0].Rows[i][1].ToString() == "1")
                         sp1.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "2")
                         sp2.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "3")
                         sp3.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "4")
                         sp4.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "5")
                         sp5.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "6")
                         sp6.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "7")
                         sp7.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "8")
                         sp8.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "9")
                         sp9.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "10")
                         sp10.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "11")
                         sp11.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "12")
                         sp12.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "13")
                         sp13.BackImageUrl = "notsale.jpg";
                     if (ds5356.Tables[0].Rows[i][1].ToString() == "14")
                         sp14.BackImageUrl = "notsale.jpg";
					if (ds5356.Tables[0].Rows[i][1].ToString() == "15")
                         sp15.BackImageUrl = "notsale.jspg";
					if (ds5356.Tables[0].Rows[i][1].ToString() == "16")
                         sp16.BackImageUrl = "notsale.jspg";
                   
               /*  if (ds5356.Tables[0].Rows[i][1].ToString() == "53")
                      sp53.BackImageUrl = "notsale.jspg";*/
             
                }
            }




















        }
        catch (Exception r)
        {

        }
    }
}


