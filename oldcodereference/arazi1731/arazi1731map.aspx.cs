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

public partial class arazi137ramipur_arazi137map : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='1731' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1731' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1731' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1731' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            SqlDataAdapter da5 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='1731' AND CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='1731') ", con);

            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            


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
                        if (ds.Tables[0].Rows[i][1].ToString() == "84")
                            p84.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "85")
                            p85.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "86")
                            p86.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "87")
                            p87.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "88")
                            p88.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "89")
                            p89.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "90")
                            p90.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "91")
                            p91.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "92")
                            p92.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "93")
                            p93.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "94")
                            p94.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "95")
                            p95.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "96")
                             p96.BackImageUrl = "amar.gif";
                         if (ds.Tables[0].Rows[i][1].ToString() == "97")
                             p97.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "98")
                            p98.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "99")
                            p99.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "100")
                            p100.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "101")
                            p101.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "102")
                            p102.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "103")
                            p103.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "104")
                            p104.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "105")
                            p105.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "106")
                            p106.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "107")
                            p107.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "108")
                            p108.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "109")
                            p109.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "110")
                            p110.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "111")
                            p111.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "112")
                            p112.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "113")
                            p113.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "114")
                            p114.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "115")
                            p115.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "116")
                            p116.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "117")
                            p117.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "118")
                            p118.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "119")
                            p119.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "120")
                            p120.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "121")
                            p121.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "122")
                            p122.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "123")
                            p123.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "124")
                            p124.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "125")
                            p125.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "126")
                            p126.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "127")
                            p127.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "128")
                            p128.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "129")
                            p129.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "130")
                            p130.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "131")
                            p131.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "132")
                            p132.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "133")
                            p133.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "134")
                            p134.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "135")
                            p135.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "136")
                            p136.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "137")
                            p137.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "138")
                            p138.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "139")
                            p139.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "140")
                            p140.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "141")
                            p141.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "142")
                            p142.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "143")
                            p143.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "144")
                            p144.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "145")
                            p145.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "146")
                            p146.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "147")
                            p147.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "148")
                            p148.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "149")
                            p149.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "150")
                            p150.BackImageUrl = "amar.gif";
                        
                        if (ds.Tables[0].Rows[i][1].ToString() == "164")
                            p164.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "165")
                            p165.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "166")
                            p166.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "167")
                            p167.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "168")
                            p168.BackImageUrl = "amar.gif";
                        
                        if (ds.Tables[0].Rows[i][1].ToString() == "170")
                            p170.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "171")
                            p171.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "172")
                            p172.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "173")
                            p173.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "174")
                            p174.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "175")
                            p175.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "176")
                            p176.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "177")
                            p177.BackImageUrl = "amar.gif";
                       
                        if (ds.Tables[0].Rows[i][1].ToString() == "182")
                            p182.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "183")
                            p183.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "184")
                            p184.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "185")
                            p185.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "186")
                            p186.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "187")
                            p187.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "188")
                            p188.BackImageUrl = "amar.gif";
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
                        if (ds.Tables[0].Rows[i][1].ToString() == "235")
                            p235.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "236")
                            p236.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "237")
                            p237.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "238")
                            p238.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "239")
                            p239.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "240")
                            p240.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "241")
                            p241.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "242")
                            p242.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "243")
                            p243.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "244")
                            p244.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "245")
                            p245.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "246")
                            p246.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "247")
                            p247.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "248")
                            p248.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "249")
                            p249.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "250")
                            p250.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "251")
                            p251.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "252")
                            p252.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "253")
                            p253.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "254")
                            p254.BackImageUrl = "amar.gif";
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
                        if (ds.Tables[0].Rows[i][1].ToString() == "84")
                            p84.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "85")
                            p85.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "86")
                            p86.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "87")
                            p87.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "88")
                            p88.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "89")
                            p89.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "90")
                            p90.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "91")
                            p91.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "92")
                            p92.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "93")
                            p93.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "94")
                            p94.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "95")
                            p95.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "96")
                            p96.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "97")
                            p97.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "98")
                            p98.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "99")
                            p99.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "100")
                            p100.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "101")
                            p101.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "102")
                            p102.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "103")
                            p103.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "104")
                            p104.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "105")
                            p105.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "106")
                            p106.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "107")
                            p107.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "108")
                            p108.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "109")
                            p109.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "110")
                            p110.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "111")
                            p111.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "112")
                            p112.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "113")
                            p113.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "114")
                            p114.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "115")
                            p115.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "116")
                            p116.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "117")
                            p117.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "118")
                            p118.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "119")
                            p119.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "120")
                            p120.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "121")
                            p121.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "122")
                            p122.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "123")
                            p123.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "124")
                            p124.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "125")
                            p125.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "126")
                            p126.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "127")
                            p127.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "128")
                            p128.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "129")
                            p129.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "130")
                            p130.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "131")
                            p131.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "132")
                            p132.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "133")
                            p133.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "134")
                            p134.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "135")
                            p135.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "136")
                            p136.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "137")
                            p137.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "138")
                            p138.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "139")
                            p139.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "140")
                            p140.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "141")
                            p141.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "142")
                            p142.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "143")
                            p143.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "144")
                            p144.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "145")
                            p145.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "146")
                            p146.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "147")
                            p147.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "148")
                            p148.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "149")
                            p149.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "150")
                            p150.BackColor = Color.Green;

                        if (ds.Tables[0].Rows[i][1].ToString() == "164")
                            p164.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "165")
                            p165.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "166")
                            p166.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "167")
                            p167.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "168")
                            p168.BackColor = Color.Green;

                        if (ds.Tables[0].Rows[i][1].ToString() == "170")
                            p170.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "171")
                            p171.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "172")
                            p172.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "173")
                            p173.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "174")
                            p174.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "175")
                            p175.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "176")
                            p176.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "177")
                            p177.BackColor = Color.Green;

                        if (ds.Tables[0].Rows[i][1].ToString() == "182")
                            p182.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "183")
                            p183.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "184")
                            p184.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "185")
                            p185.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "186")
                            p186.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "187")
                            p187.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "188")
                            p188.BackColor = Color.Green;
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
                        if (ds.Tables[0].Rows[i][1].ToString() == "235")
                            p235.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "236")
                            p236.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "237")
                            p237.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "238")
                            p238.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "239")
                            p239.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "240")
                            p240.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "241")
                            p241.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "242")
                            p242.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "243")
                            p243.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "244")
                            p244.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "245")
                            p245.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "246")
                            p246.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "247")
                            p247.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "248")
                            p248.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "249")
                            p249.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "250")
                            p250.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "251")
                            p251.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "252")
                            p252.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "253")
                            p253.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "254")
                            p254.BackColor = Color.Green;

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
                    if (ds1.Tables[0].Rows[i][1].ToString() == "84")
                        p84.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "85")
                        p85.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "86")
                        p86.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "87")
                        p87.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "88")
                        p88.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "89")
                        p89.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "90")
                        p90.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "91")
                        p91.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "92")
                        p92.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "93")
                        p93.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "94")
                        p94.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "95")
                        p95.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "96")
                        p96.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "97")
                        p97.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "98")
                        p98.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "99")
                        p99.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "100")
                        p100.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "101")
                        p101.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "102")
                        p102.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "103")
                        p103.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "104")
                        p104.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "105")
                        p105.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "106")
                        p106.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "107")
                        p107.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "108")
                        p108.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "109")
                        p109.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "110")
                        p110.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "111")
                        p111.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "112")
                        p112.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "113")
                        p113.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "114")
                        p114.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "115")
                        p115.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "116")
                        p116.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "117")
                        p117.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "118")
                        p118.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "119")
                        p119.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "120")
                        p120.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "121")
                        p121.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "122")
                        p122.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "123")
                        p123.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "124")
                        p124.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "125")
                        p125.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "126")
                        p126.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "127")
                        p127.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "128")
                        p128.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "129")
                        p129.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "130")
                        p130.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "131")
                        p131.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "132")
                        p132.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "133")
                        p133.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "134")
                        p134.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "135")
                        p135.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "136")
                        p136.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "137")
                        p137.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "138")
                        p138.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "139")
                        p139.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "140")
                        p140.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "141")
                        p141.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "142")
                        p142.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "143")
                        p143.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "144")
                        p144.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "145")
                        p145.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "146")
                        p146.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "147")
                        p147.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "148")
                        p148.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "149")
                        p149.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "150")
                        p150.BackColor = Color.Red;

                    if (ds1.Tables[0].Rows[i][1].ToString() == "164")
                        p164.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "165")
                        p165.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "166")
                        p166.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "167")
                        p167.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "168")
                        p168.BackColor = Color.Red;

                    if (ds1.Tables[0].Rows[i][1].ToString() == "170")
                        p170.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "171")
                        p171.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "172")
                        p172.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "173")
                        p173.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "174")
                        p174.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "175")
                        p175.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "176")
                        p176.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "177")
                        p177.BackColor = Color.Red;

                    if (ds1.Tables[0].Rows[i][1].ToString() == "182")
                        p182.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "183")
                        p183.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "184")
                        p184.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "185")
                        p185.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "186")
                        p186.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "187")
                        p187.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "188")
                        p188.BackColor = Color.Red;
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
                    if (ds1.Tables[0].Rows[i][1].ToString() == "235")
                        p235.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "236")
                        p236.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "237")
                        p237.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "238")
                        p238.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "239")
                        p239.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "240")
                        p240.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "241")
                        p241.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "242")
                        p242.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "243")
                        p243.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "244")
                        p244.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "245")
                        p245.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "246")
                        p246.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "247")
                        p247.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "248")
                        p248.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "249")
                        p249.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "250")
                        p250.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "251")
                        p251.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "252")
                        p252.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "253")
                        p253.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "254")
                        p254.BackColor = Color.Red;
                    
                   
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
                    if (ds2.Tables[0].Rows[i][1].ToString() == "84")
                        p84.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "85")
                        p85.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "86")
                        p86.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "87")
                        p87.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "88")
                        p88.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "89")
                        p89.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "90")
                        p90.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "91")
                        p91.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "92")
                        p92.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "93")
                        p93.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "94")
                        p94.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "95")
                        p95.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "96")
                        p96.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "97")
                        p97.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "98")
                        p98.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "99")
                        p99.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "100")
                        p100.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "101")
                        p101.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "102")
                        p102.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "103")
                        p103.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "104")
                        p104.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "105")
                        p105.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "106")
                        p106.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "107")
                        p107.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "108")
                        p108.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "109")
                        p109.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "110")
                        p110.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "111")
                        p111.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "112")
                        p112.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "113")
                        p113.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "114")
                        p114.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "115")
                        p115.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "116")
                        p116.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "117")
                        p117.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "118")
                        p118.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "119")
                        p119.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "120")
                        p120.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "121")
                        p121.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "122")
                        p122.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "123")
                        p123.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "124")
                        p124.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "125")
                        p125.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "126")
                        p126.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "127")
                        p127.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "128")
                        p128.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "129")
                        p129.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "130")
                        p130.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "131")
                        p131.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "132")
                        p132.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "133")
                        p133.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "134")
                        p134.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "135")
                        p135.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "136")
                        p136.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "137")
                        p137.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "138")
                        p138.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "139")
                        p139.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "140")
                        p140.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "141")
                        p141.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "142")
                        p142.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "143")
                        p143.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "144")
                        p144.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "145")
                        p145.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "146")
                        p146.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "147")
                        p147.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "148")
                        p148.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "149")
                        p149.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "150")
                        p150.BackImageUrl = "blue.gif";

                    if (ds2.Tables[0].Rows[i][1].ToString() == "164")
                        p164.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "165")
                        p165.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "166")
                        p166.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "167")
                        p167.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "168")
                        p168.BackImageUrl = "blue.gif";

                    if (ds2.Tables[0].Rows[i][1].ToString() == "170")
                        p170.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "171")
                        p171.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "172")
                        p172.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "173")
                        p173.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "174")
                        p174.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "175")
                        p175.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "176")
                        p176.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "177")
                        p177.BackImageUrl = "blue.gif";

                    if (ds2.Tables[0].Rows[i][1].ToString() == "182")
                        p182.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "183")
                        p183.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "184")
                        p184.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "185")
                        p185.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "186")
                        p186.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "187")
                        p187.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "188")
                        p188.BackImageUrl = "blue.gif";
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
                    if (ds2.Tables[0].Rows[i][1].ToString() == "235")
                        p235.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "236")
                        p236.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "237")
                        p237.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "238")
                        p238.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "239")
                        p239.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "240")
                        p240.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "241")
                        p241.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "242")
                        p242.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "243")
                        p243.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "244")
                        p244.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "245")
                        p245.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "246")
                        p246.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "247")
                        p247.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "248")
                        p248.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "249")
                        p249.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "250")
                        p250.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "251")
                        p251.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "252")
                        p252.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "253")
                        p253.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "254")
                        p254.BackImageUrl = "blue.gif";
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
                            p79.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "80")
                            p80.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "81")
                            p81.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "82")
                            p82.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "83")
                            p83.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "84")
                            p84.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "85")
                            p85.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "86")
                            p86.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "87")
                            p87.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "88")
                            p88.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "89")
                            p89.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "90")
                            p90.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "91")
                            p91.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "92")
                            p92.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "93")
                            p93.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "94")
                            p94.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "95")
                            p95.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "96")
                            p96.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "97")
                            p97.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "98")
                            p98.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "99")
                            p99.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "100")
                            p100.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "101")
                            p101.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "102")
                            p102.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "103")
                            p103.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "104")
                            p104.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "105")
                            p105.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "106")
                            p106.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "107")
                            p107.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "108")
                            p108.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "109")
                            p109.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "110")
                            p110.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "111")
                            p111.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "112")
                            p112.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "113")
                            p113.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "114")
                            p114.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "115")
                            p115.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "116")
                            p116.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "117")
                            p117.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "118")
                            p118.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "119")
                            p119.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "120")
                            p120.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "121")
                            p121.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "122")
                            p122.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "123")
                            p123.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "124")
                            p124.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "125")
                            p125.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "126")
                            p126.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "127")
                            p127.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "128")
                            p128.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "129")
                            p129.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "130")
                            p130.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "131")
                            p131.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "132")
                            p132.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "133")
                            p133.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "134")
                            p134.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "135")
                            p135.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "136")
                            p136.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "137")
                            p137.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "138")
                            p138.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "139")
                            p139.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "140")
                            p140.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "141")
                            p141.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "142")
                            p142.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "143")
                            p143.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "144")
                            p144.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "145")
                            p145.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "146")
                            p146.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "147")
                            p147.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "148")
                            p148.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "149")
                            p149.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "150")
                            p150.BackImageUrl = "notsale.jpg";

                        if (ds5.Tables[0].Rows[i][1].ToString() == "164")
                            p164.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "165")
                            p165.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "166")
                            p166.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "167")
                            p167.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "168")
                            p168.BackImageUrl = "notsale.jpg";

                        if (ds5.Tables[0].Rows[i][1].ToString() == "170")
                            p170.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "171")
                            p171.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "172")
                            p172.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "173")
                            p173.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "174")
                            p174.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "175")
                            p175.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "176")
                            p176.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "177")
                            p177.BackImageUrl = "notsale.jpg";

                        if (ds5.Tables[0].Rows[i][1].ToString() == "182")
                            p182.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "183")
                            p183.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "184")
                            p184.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "185")
                            p185.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "186")
                            p186.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "187")
                            p187.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "188")
                            p188.BackImageUrl = "notsale.jpg";
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
                        if (ds5.Tables[0].Rows[i][1].ToString() == "235")
                            p235.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "236")
                            p236.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "237")
                            p237.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "238")
                            p238.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "239")
                            p239.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "240")
                            p240.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "241")
                            p241.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "242")
                            p242.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "243")
                            p243.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "244")
                            p244.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "245")
                            p245.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "246")
                            p246.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "247")
                            p247.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "248")
                            p248.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "249")
                            p249.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "250")
                            p250.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "251")
                            p251.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "252")
                            p252.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "253")
                            p253.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "254")
                            p254.BackImageUrl = "notsale.jpg";
                    }
                }
            }
        }
        catch (Exception r)
        {

        }
    }
}