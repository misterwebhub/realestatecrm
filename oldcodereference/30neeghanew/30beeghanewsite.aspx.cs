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
using System.Drawing;

public partial class _30beeghanewsite : System.Web.UI.Page
{
     string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select block,plotno,status from arazi30beegha",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select block,plotno,status from arazi30beegha where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
			con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select block,plotno,status from arazi30beegha where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
			 con.Close();
			 SqlDataAdapter da5 = new SqlDataAdapter("select block,plotno,status from arazi30beegha where  CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='152') ", con);
           
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
			con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazi30beegha where block='D' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
			Label1.Text=ds3.Tables[0].Rows[0][0].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                        if (ds.Tables[0].Rows[i][0].ToString() == "D")
                    {
                        if (ds.Tables[0].Rows[i][2].ToString() == "empty")
                        { if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                D49.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                D50.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                D51.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                D52.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                D53.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                D54.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                D55.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                D56.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                D57.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                D58.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "71")
                               D71.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "72")
                               D72.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "73")
                               D73.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "74")
                               D74.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "75")
                               D75.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "76")
                               D76.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "77")
                               D77.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "78")
                               D78.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "79")
                               D79.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "80")
                               D80.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "81")
                               D81.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "82")
                               D82.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "83")
                               D83.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "84")
                               D84.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "85")
                               D85.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "86")
                               D86.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "87")
                               D87.BackImageUrl = "amar.gif";
                          /* if (ds.Tables[0].Rows[i][1].ToString() == "88")
                               D88.BackImageUrl = "amar.gif";
                          if (ds.Tables[0].Rows[i][1].ToString() == "89")
                               D89.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "90")
                               D90.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "91")
                               D91.BackImageUrl = "amar.gif";*/
                           if (ds.Tables[0].Rows[i][1].ToString() == "92")
                               D92.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "93")
                               D93.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "94")
                               D94.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "95")
                               D95.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "96")
                               D96.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "97")
                               D97.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "98")
                               D98.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "99")
                               D99.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "100")
                               D100.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "101")
                               D101.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "102")
                               D102.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "103")
                               D103.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "104")
                               D104.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "105")
                               D105.BackImageUrl = "amar.gif";
                           
                           if (ds.Tables[0].Rows[i][1].ToString() == "108")
                               D108.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "109")
                               D109.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "110")
                               D110.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "111")
                               D111.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "112")
                               D112.BackImageUrl = "amar.gif";
                         /*  if (ds.Tables[0].Rows[i][1].ToString() == "113")
                               D113.BackImageUrl = "amar.gif";*/
                           if (ds.Tables[0].Rows[i][1].ToString() == "114")
                               D114.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "115")
                               D115.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "116")
                               D116.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "117")
                               D117.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "118")
                               D118.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "119")
                               D119.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "120")
                               D120.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "121")
                               D121.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "122")
                               D122.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "123")
                               D123.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "124")
                               D124.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "125")
                               D125.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "126")
                               D126.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "127")
                               D127.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "128")
                                 D128.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "129")
                                 D129.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "130")
                                 D130.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "131")
                                 D131.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "132")
                                 D132.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "133")
                                 D133.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "134")
                                 D134.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "135")
                                 D135.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "136")
                                 D136.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "137")
                                 D137.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "138")
                                 D138.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "139")
                                 D139.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "140")
                                 D140.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "141")
                                 D141.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "142")
                                 D142.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "143")
                                 D143.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "144")
                                 D144.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "145")
                                 D145.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "146")
                                 D146.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "147")
                                 D147.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "148")
                                 D148.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "149")
                                 D149.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "150")
                                 D150.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "151")
                                 D151.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "152")
                                 D152.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "153")
                                 D153.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "154")
                                 D154.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "155")
                                 D155.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "156")
                                 D156.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "157")
                                 D157.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "158")
                                 D158.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "159")
                                 D159.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "160")
                                 D160.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "161")
                                 D161.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "162")
                                 D162.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "163")
                                 D163.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "164")
                                 D164.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "165")
                                 D165.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "166")
                                 D166.BackImageUrl = "amar.gif";
                            /* if (ds.Tables[0].Rows[i][1].ToString() == "167")
                                 D167.BackImageUrl = "amar.gif";*/
                             if (ds.Tables[0].Rows[i][1].ToString() == "168")
                                 D168.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "169")
                                 D169.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "170")
                                 D170.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "171")
                                 D171.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "172")
                                 D172.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "173")
                                 D173.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "174")
                                 D174.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "175")
                                 D175.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "176")
                                 D176.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "177")
                                 D177.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "178")
                                 D178.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "179")
                                 D179.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "180")
                                 D180.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "181")
                                 D181.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "182")
                                 D182.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "183")
                                 D183.BackImageUrl = "amar.gif";
	if (ds.Tables[0].Rows[i][1].ToString() == "184")
                                 D184.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "185")
                                 D185.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "186")
                                 D186.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "187")
                                 D187.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "188")
                                 D188.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "189")
                                 D189.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "190")
                                 D190.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "191")
                                 D191.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "192")
                                 D192.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "193")
                                 D193.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "194")
                                 D194.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "195")
                                 D195.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "196")
                                 D196.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "197")
                                 D197.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "198")
                                 D198.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "199")
                                 D199.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "200")
                                 D200.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "201")
                                 D201.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "202")
                                 D202.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "203")
                                 D203.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "204")
                                 D204.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "205")
                                 D205.BackImageUrl = "amar.gif";
						 if (ds.Tables[0].Rows[i][1].ToString() == "206")
                                 D206.BackImageUrl = "amar.gif";
/*if (ds.Tables[0].Rows[i][1].ToString() == "207")
                                 D207.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "208")
                                 D208.BackImageUrl = "amar.gif";*/
if (ds.Tables[0].Rows[i][1].ToString() == "209")
                                 D209.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "210")
                                 D210.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "211")
                                 D211.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "212")
                                 D212.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "213")
                                 D213.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "214")
                                 D214.BackImageUrl = "amar.gif";
if (ds.Tables[0].Rows[i][1].ToString() == "215")
                                 D215.BackImageUrl = "amar.gif";
                          
                        }
                        if (ds.Tables[0].Rows[i][2].ToString() == "book")
                        {
                           if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                D49.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                D50.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                D51.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                D52.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                D53.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                D54.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                D55.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                D56.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                D57.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                D58.BackColor = Color.Green;
                           
                            if (ds.Tables[0].Rows[i][1].ToString() == "71")
                                D71.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "72")
                                D72.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "73")
                                D73.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "74")
                                D74.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "75")
                                D75.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "76")
                                D76.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "77")
                                D77.BackColor = Color.Green;

                            if (ds.Tables[0].Rows[i][1].ToString() == "78")
                                D78.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "79")
                                D79.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "80")
                                D80.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "81")
                                D81.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "82")
                                D82.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "83")
                                D83.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "84")
                                D84.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "85")
                                D85.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "86")
                                D86.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "87")
                                D87.BackColor = Color.Green;
                          /*  if (ds.Tables[0].Rows[i][1].ToString() == "88")
                                D88.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "89")
                                                           D89.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "90")
                                                           D90.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "91")
                                D91.BackColor = Color.Green;*/
                            if (ds.Tables[0].Rows[i][1].ToString() == "92")
                                D92.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "93")
                                D93.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "94")
                                D94.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "95")
                                D95.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "96")
                                D96.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "97")
                                D97.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "98")
                                D98.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "99")
                                D99.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "100")
                                D100.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "101")
                                D101.BackColor = Color.Green;

                            if (ds.Tables[0].Rows[i][1].ToString() == "102")
                                D102.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "103")
                                D103.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "104")
                                D104.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "105")
                                D105.BackColor = Color.Green;
                            
                            if (ds.Tables[0].Rows[i][1].ToString() == "108")
                                D108.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "109")
                                D109.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "110")
                                D110.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "111")
                                D111.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "112")
                                D112.BackColor = Color.Green;
                           /* if (ds.Tables[0].Rows[i][1].ToString() == "113")
                                D113.BackColor = Color.Green;*/
                            if (ds.Tables[0].Rows[i][1].ToString() == "114")
                                D114.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "115")
                                D115.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "116")
                                D116.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "117")
                                D117.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "118")
                                D118.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "119")
                                D119.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "120")
                                D120.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "121")
                                D121.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "122")
                                D122.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "123")
                                D123.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "124")
                                D124.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "125")
                                D125.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "126")
                                D126.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "127")
                                D127.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "128")
                                D128.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "129")
                                D129.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "130")
                                D130.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "131")
                                D131.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "132")
                                D132.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "133")
                                D133.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "134")
                                D134.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "135")
                                D135.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "136")
                                D136.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "137")
                                D137.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "138")
                                D138.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "139")
                                D139.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "140")
                                D140.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "141")
                                D141.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "142")
                                D142.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "143")
                                D143.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "144")
                                D144.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "145")
                                D145.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "146")
                                D146.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "147")
                                D147.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "148")
                                D148.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "149")
                                D149.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "150")
                                D150.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "151")
                                D151.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "152")
                                D152.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "153")
                                D153.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "154")
                                D154.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "155")
                                D155.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "156")
                                D156.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "157")
                                D157.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "158")
                                D158.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "159")
                                D159.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "160")
                                D160.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "161")
                                D161.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "162")
                                D162.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "163")
                                D163.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "164")
                                D164.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "165")
                                D165.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "166")
                                D166.BackColor = Color.Green;
                           /* if (ds.Tables[0].Rows[i][1].ToString() == "167")
                                D167.BackColor = Color.Green;*/
                            if (ds.Tables[0].Rows[i][1].ToString() == "168")
                                D168.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "169")
                                D169.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "170")
                                D170.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "171")
                                D171.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "172")
                                D172.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "173")
                                D173.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "174")
                                D174.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "175")
                                D175.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "176")
                                D176.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "177")
                                D177.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "178")
                                D178.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "179")
                                D179.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "180")
                                D180.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "181")
                                D181.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "182")
                                D182.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "183")
                                D183.BackColor = Color.Green;
      
	if (ds.Tables[0].Rows[i][1].ToString() == "184")
                                 D184.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "185")
                                 D185.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "186")
                                 D186.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "187")
                                 D187.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "188")
                                 D188.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "189")
                                 D189.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "190")
                                 D190.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "191")
                                 D191.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "192")
                                 D192.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "193")
                                 D193.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "194")
                                 D194.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "195")
                                 D195.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "196")
                                 D196.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "197")
                                 D197.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "198")
                                 D198.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "199")
                                 D199.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "200")
                                 D200.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "201")
                                 D201.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "202")
                                 D202.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "203")
                                 D203.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "204")
                                 D204.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "205")
                                 D205.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "206")
                                 D206.BackColor = Color.Green;
/*if (ds.Tables[0].Rows[i][1].ToString() == "207")
                                 D207.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "208")
                                 D208.BackColor = Color.Green;*/
if (ds.Tables[0].Rows[i][1].ToString() == "209")
                                 D209.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "210")
                                 D210.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "211")
                                 D211.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "212")
                                 D212.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "213")
                                 D213.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "214")
                                 D214.BackColor = Color.Green;
if (ds.Tables[0].Rows[i][1].ToString() == "215")
                                 D215.BackColor = Color.Green;
                           

                        }
                    }

                }
            }
            
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {

                    if (ds1.Tables[0].Rows[i][0].ToString() == "D")
                    {
 if (ds1.Tables[0].Rows[i][1].ToString() == "49")
                            D49.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "50")
                            D50.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "51")
                            D51.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "52")
                            D52.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "53")
                            D53.BackColor = Color.Red;
                       
                        if (ds1.Tables[0].Rows[i][1].ToString() == "54")
                            D54.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "55")
                            D55.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "56")
                            D56.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "57")
                            D57.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "58")
                            D58.BackColor = Color.Red;
                       
                        if (ds1.Tables[0].Rows[i][1].ToString() == "71")
                            D71.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "72")
                            D72.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "73")
                            D73.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "74")
                            D74.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "75")
                            D75.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "76")
                            D76.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "77")
                            D77.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "78")
                            D78.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "79")
                            D79.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "80")
                            D80.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "81")
                            D81.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "82")
                            D82.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "83")
                            D83.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "84")
                            D84.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "85")
                            D85.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "86")
                            D86.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "87")
                            D87.BackColor = Color.Red;
                      /*  if (ds1.Tables[0].Rows[i][1].ToString() == "88")
                            D88.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "89")
                                                       D89.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "90")
                                                       D90.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "91")
                            D91.BackColor = Color.Red;*/
                        if (ds1.Tables[0].Rows[i][1].ToString() == "92")
                            D92.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "93")
                            D93.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "94")
                            D94.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "95")
                            D95.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "96")
                            D96.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "97")
                            D97.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "98")
                            D98.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "99")
                            D99.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "100")
                            D100.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "101")
                            D101.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "102")
                            D102.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "103")
                            D103.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "104")
                            D104.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "105")
                            D105.BackColor = Color.Red;
                        
                        if (ds1.Tables[0].Rows[i][1].ToString() == "108")
                            D108.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "109")
                            D109.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "110")
                            D110.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "111")
                            D111.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "112")
                            D112.BackColor = Color.Red;
                     /*   if (ds1.Tables[0].Rows[i][1].ToString() == "113")
                            D113.BackColor = Color.Red;*/
                        if (ds1.Tables[0].Rows[i][1].ToString() == "114")
                            D114.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "115")
                            D115.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "116")
                            D116.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "117")
                            D117.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "118")
                            D118.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "119")
                            D119.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "120")
                            D120.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "121")
                            D121.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "122")
                            D122.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "123")
                            D123.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "124")
                            D124.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "125")
                            D125.BackColor = Color.Red;
                       if (ds1.Tables[0].Rows[i][1].ToString() == "126")
                            D126.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "127")
                            D127.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "128")
                            D128.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "129")
                            D129.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "130")
                            D130.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "131")
                            D131.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "132")
                            D132.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "133")
                            D133.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "134")
                            D134.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "135")
                            D135.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "136")
                            D136.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "137")
                            D137.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "138")
                            D138.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "139")
                            D139.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "140")
                            D140.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "141")
                            D141.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "142")
                            D142.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "143")
                            D143.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "144")
                            D144.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "145")
                            D145.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "146")
                            D146.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "147")
                            D147.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "148")
                            D148.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "149")
                            D149.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "150")
                            D150.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "151")
                            D151.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "152")
                            D152.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "153")
                            D153.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "154")
                            D154.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "155")
                            D155.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "156")
                            D156.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "157")
                            D157.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "158")
                            D158.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "159")
                            D159.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "160")
                            D160.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "161")
                            D161.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "162")
                            D162.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "163")
                            D163.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "164")
                            D164.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "165")
                            D165.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "166")
                            D166.BackColor = Color.Red;
                     /*   if (ds1.Tables[0].Rows[i][1].ToString() == "167")
                            D167.BackColor = Color.Red;*/
                        if (ds1.Tables[0].Rows[i][1].ToString() == "168")
                            D168.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "169")
                            D169.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "170")
                            D170.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "171")
                            D171.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "172")
                            D172.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "173")
                            D173.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "174")
                            D174.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "175")
                            D175.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "176")
                            D176.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "177")
                            D177.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "178")
                            D178.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "179")
                            D179.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "180")
                            D180.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "181")
                            D181.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "182")
                            D182.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "183")
                            D183.BackColor = Color.Red;
      
	if (ds1.Tables[0].Rows[i][1].ToString() == "184")
                                 D184.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "185")
                                 D185.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "186")
                                 D186.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "187")
                                 D187.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "188")
                                 D188.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "189")
                                 D189.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "190")
                                 D190.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "191")
                                 D191.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "192")
                                 D192.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "193")
                                 D193.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "194")
                                 D194.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "195")
                                 D195.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "196")
                                 D196.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "197")
                                 D197.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "198")
                                 D198.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "199")
                                 D199.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "200")
                                 D200.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "201")
                                 D201.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "202")
                                 D202.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "203")
                                 D203.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "204")
                                 D204.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "205")
                                 D205.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "206")
                                 D206.BackColor = Color.Red;
/*if (ds1.Tables[0].Rows[i][1].ToString() == "207")
                                 D207.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "208")
                                 D208.BackColor = Color.Red;*/
if (ds1.Tables[0].Rows[i][1].ToString() == "209")
                                 D209.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "210")
                                 D210.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "211")
                                 D211.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "212")
                                 D212.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "213")
                                 D213.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "214")
                                 D214.BackColor = Color.Red;
if (ds1.Tables[0].Rows[i][1].ToString() == "215")
                                 D215.BackColor = Color.Red;

                    }
                }
            }
			
 if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                   
                    if (ds2.Tables[0].Rows[i][0].ToString() == "D")
                    {
 if (ds2.Tables[0].Rows[i][1].ToString() == "49")
                            D49.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "50")
                            D50.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "51")
                            D51.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "52")
                            D52.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "53")
                            D53.BackImageUrl = "blue.gif";
                        
                       
                        if (ds2.Tables[0].Rows[i][1].ToString() == "54")
                            D54.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "55")
                            D55.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "56")
                            D56.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "57")
                            D57.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "58")
                            D58.BackImageUrl = "blue.gif";
                        
                        if (ds2.Tables[0].Rows[i][1].ToString() == "71")
                            D71.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "72")
                            D72.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "73")
                            D73.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "74")
                            D74.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "75")
                            D75.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "76")
                            D76.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "77")
                            D77.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "78")
                            D78.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "79")
                            D79.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "80")
                            D80.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "81")
                            D81.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "82")
                            D82.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "83")
                            D83.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "84")
                            D84.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "85")
                            D85.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "86")
                            D86.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "87")
                            D87.BackImageUrl = "blue.gif";
                       /* if (ds2.Tables[0].Rows[i][1].ToString() == "88")
                            D88.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "89")
                                                       D89.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "90")
                                                       D90.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "91")
                            D91.BackImageUrl = "blue.gif";*/
                        if (ds2.Tables[0].Rows[i][1].ToString() == "92")
                            D92.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "93")
                            D93.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "94")
                            D94.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "95")
                            D95.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "96")
                            D96.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "97")
                            D97.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "98")
                            D98.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "99")
                            D99.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "100")
                            D100.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "101")
                            D101.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "102")
                            D102.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "103")
                            D103.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "104")
                            D104.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "105")
                            D105.BackImageUrl = "blue.gif";
                        
                        if (ds2.Tables[0].Rows[i][1].ToString() == "108")
                            D108.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "109")
                            D109.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "110")
                            D110.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "111")
                            D111.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "112")
                            D112.BackImageUrl = "blue.gif";
                     /*   if (ds2.Tables[0].Rows[i][1].ToString() == "113")
                            D113.BackImageUrl = "blue.gif";*/
                        if (ds2.Tables[0].Rows[i][1].ToString() == "114")
                            D114.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "115")
                            D115.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "116")
                            D116.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "117")
                            D117.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "118")
                            D118.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "119")
                            D119.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "120")
                            D120.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "121")
                            D121.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "122")
                            D122.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "123")
                            D123.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "124")
                            D124.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "125")
                            D125.BackImageUrl = "blue.gif";
                       if (ds2.Tables[0].Rows[i][1].ToString() == "126")
                            D126.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "127")
                            D127.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "128")
                            D128.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "129")
                            D129.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "130")
                            D130.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "131")
                            D131.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "132")
                            D132.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "133")
                            D133.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "134")
                            D134.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "135")
                            D135.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "136")
                            D136.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "137")
                            D137.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "138")
                            D138.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "139")
                            D139.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "140")
                            D140.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "141")
                            D141.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "142")
                            D142.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "143")
                            D143.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "144")
                            D144.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "145")
                            D145.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "146")
                            D146.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "147")
                            D147.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "148")
                            D148.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "149")
                            D149.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "150")
                            D150.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "151")
                            D151.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "152")
                            D152.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "153")
                            D153.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "154")
                            D154.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "155")
                            D155.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "156")
                            D156.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "157")
                            D157.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "158")
                            D158.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "159")
                            D159.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "160")
                            D160.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "161")
                            D161.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "162")
                            D162.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "163")
                            D163.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "164")
                            D164.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "165")
                            D165.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "166")
                            D166.BackImageUrl = "blue.gif";
                     /*   if (ds2.Tables[0].Rows[i][1].ToString() == "167")
                            D167.BackImageUrl = "blue.gif";*/
                        if (ds2.Tables[0].Rows[i][1].ToString() == "168")
                            D168.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "169")
                            D169.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "170")
                            D170.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "171")
                            D171.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "172")
                            D172.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "173")
                            D173.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "174")
                            D174.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "175")
                            D175.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "176")
                            D176.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "177")
                            D177.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "178")
                            D178.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "179")
                            D179.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "180")
                            D180.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "181")
                            D181.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "182")
                            D182.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "183")
                            D183.BackImageUrl = "blue.gif";
      
	if (ds2.Tables[0].Rows[i][1].ToString() == "184")
                                 D184.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "185")
                                 D185.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "186")
                                 D186.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "187")
                                 D187.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "188")
                                 D188.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "189")
                                 D189.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "190")
                                 D190.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "191")
                                 D191.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "192")
                                 D192.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "193")
                                 D193.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "194")
                                 D194.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "195")
                                 D195.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "196")
                                 D196.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "197")
                                 D197.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "198")
                                 D198.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "199")
                                 D199.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "200")
                                 D200.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "201")
                                 D201.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "202")
                                 D202.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "203")
                                 D203.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "204")
                                 D204.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "205")
                                 D205.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "206")
                                 D206.BackImageUrl = "blue.gif";
/*if (ds2.Tables[0].Rows[i][1].ToString() == "207")
                                 D207.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "208")
                                 D208.BackImageUrl = "blue.gif";*/
if (ds2.Tables[0].Rows[i][1].ToString() == "209")
                                 D209.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "210")
                                 D210.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "211")
                                 D211.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "212")
                                 D212.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "213")
                                 D213.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "214")
                                 D214.BackImageUrl = "blue.gif";
if (ds2.Tables[0].Rows[i][1].ToString() == "215")
                                 D215.BackImageUrl = "blue.gif";
                    
                    
                

                    }
                }
            }
			if (ds5.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                {
                   
                    if (ds5.Tables[0].Rows[i][0].ToString() == "D")
                    {
if (ds5.Tables[0].Rows[i][1].ToString() == "49")
                            D49.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "50")
                            D50.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "51")
                            D51.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "52")
                            D52.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "53")
                            D53.BackImageUrl = "notsale.jpg";
                       
                        if (ds5.Tables[0].Rows[i][1].ToString() == "54")
                            D54.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "55")
                            D55.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "56")
                            D56.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "57")
                            D57.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "58")
                            D58.BackImageUrl = "notsale.jpg";
                        
                        if (ds5.Tables[0].Rows[i][1].ToString() == "71")
                            D71.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "72")
                            D72.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "73")
                            D73.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "74")
                            D74.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "75")
                            D75.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "76")
                            D76.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "77")
                            D77.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "78")
                            D78.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "79")
                            D79.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "80")
                            D80.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "81")
                            D81.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "82")
                            D82.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "83")
                            D83.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "84")
                            D84.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "85")
                            D85.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "86")
                            D86.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "87")
                            D87.BackImageUrl = "notsale.jpg";
                      /*  if (ds5.Tables[0].Rows[i][1].ToString() == "88")
                            D88.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "89")
                                                       D89.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "90")
                                                       D90.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "91")
                            D91.BackImageUrl = "notsale.jpg";*/
                        if (ds5.Tables[0].Rows[i][1].ToString() == "92")
                            D92.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "93")
                            D93.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "94")
                            D94.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "95")
                            D95.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "96")
                            D96.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "97")
                            D97.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "98")
                            D98.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "99")
                            D99.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "100")
                            D100.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "101")
                            D101.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "102")
                            D102.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "103")
                            D103.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "104")
                            D104.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "105")
                            D105.BackImageUrl = "notsale.jpg";
                        
                        if (ds5.Tables[0].Rows[i][1].ToString() == "108")
                            D108.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "109")
                            D109.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "110")
                            D110.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "111")
                            D111.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "112")
                            D112.BackImageUrl = "notsale.jpg";
                   /*     if (ds5.Tables[0].Rows[i][1].ToString() == "113")
                            D113.BackImageUrl = "notsale.jpg";*/
                        if (ds5.Tables[0].Rows[i][1].ToString() == "114")
                            D114.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "115")
                            D115.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "116")
                            D116.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "117")
                            D117.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "118")
                            D118.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "119")
                            D119.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "120")
                            D120.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "121")
                            D121.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "122")
                            D122.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "123")
                            D123.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "124")
                            D124.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "125")
                            D125.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "126")
                            D126.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "127")
                            D127.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "128")
                            D128.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "129")
                            D129.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "130")
                            D130.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "131")
                            D131.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "132")
                            D132.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "133")
                            D133.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "134")
                            D134.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "135")
                            D135.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "136")
                            D136.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "137")
                            D137.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "138")
                            D138.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "139")
                            D139.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "140")
                            D140.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "141")
                            D141.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "142")
                            D142.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "143")
                            D143.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "144")
                            D144.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "145")
                            D145.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "146")
                            D146.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "147")
                            D147.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "148")
                            D148.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "149")
                            D149.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "150")
                            D150.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "151")
                            D151.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "152")
                            D152.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "153")
                            D153.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "154")
                            D154.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "155")
                            D155.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "156")
                            D156.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "157")
                            D157.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "158")
                            D158.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "159")
                            D159.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "160")
                            D160.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "161")
                            D161.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "162")
                            D162.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "163")
                            D163.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "164")
                            D164.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "165")
                            D165.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "166")
                            D166.BackImageUrl = "notsale.jpg";
                      /*  if (ds5.Tables[0].Rows[i][1].ToString() == "167")
                            D167.BackImageUrl = "notsale.jpg";*/
                        if (ds5.Tables[0].Rows[i][1].ToString() == "168")
                            D168.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "169")
                            D169.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "170")
                            D170.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "171")
                            D171.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "172")
                            D172.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "173")
                            D173.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "174")
                            D174.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "175")
                            D175.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "176")
                            D176.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "177")
                            D177.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "178")
                            D178.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "179")
                            D179.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "180")
                            D180.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "181")
                            D181.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "182")
                            D182.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "183")
                            D183.BackImageUrl = "notsale.jpg";
      
	if (ds5.Tables[0].Rows[i][1].ToString() == "184")
                                 D184.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "185")
                                 D185.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "186")
                                 D186.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "187")
                                 D187.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "188")
                                 D188.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "189")
                                 D189.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "190")
                                 D190.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "191")
                                 D191.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "192")
                                 D192.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "193")
                                 D193.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "194")
                                 D194.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "195")
                                 D195.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "196")
                                 D196.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "197")
                                 D197.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "198")
                                 D198.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "199")
                                 D199.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "200")
                                 D200.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "201")
                                 D201.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "202")
                                 D202.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "203")
                                 D203.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "204")
                                 D204.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "205")
                                 D205.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "206")
                                 D206.BackImageUrl = "notsale.jpg";
/*if (ds5.Tables[0].Rows[i][1].ToString() == "207")
                                 D207.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "208")
                                 D208.BackImageUrl = "notsale.jpg";*/
if (ds5.Tables[0].Rows[i][1].ToString() == "209")
                                 D209.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "210")
                                 D210.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "211")
                                 D211.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "212")
                                 D212.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "213")
                                 D213.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "214")
                                 D214.BackImageUrl = "notsale.jpg";
if (ds5.Tables[0].Rows[i][1].ToString() == "215")
                                 D215.BackImageUrl = "notsale.jpg";
                    
                    
                

                    }
                }
            }
        }
        catch (Exception rt)
        {
        }
    }

    
}