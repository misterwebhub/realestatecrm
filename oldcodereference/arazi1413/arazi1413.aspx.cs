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

public partial class arazi1414_arazi1413 : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='1413' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='1413' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1413' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select arazi,plotno,status from arazimap where  arazi='1413' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1413' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazimap where   arazi='1413' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1413' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();

            SqlDataAdapter da5 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='1413' AND CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='1413') ", con);

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


                    
                }
            }
        }
        catch (Exception r)
        {

        }
    }
}