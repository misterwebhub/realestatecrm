using System;
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
using System.Globalization;

public partial class arazi186map_arazi186map : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = true;
       // arazi186map();
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='186MI'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='186MI' AND  CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='186MI' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='186MI' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='186MI' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazimap where  arazi='186MI' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='186MI' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            SqlDataAdapter da5 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='186MI' AND CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='186MI') ", con);
           
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
                }
                    

                }
        }
        catch (Exception r)
        {

        }
    }
   /* public void arazi186map()
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='185' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='185' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='185' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='185' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
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
                            pp1.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "2")
                            pp2.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "3")
                            pp3.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "4")
                            pp4.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "5")
                            pp5.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "6")
                            pp6.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "7")
                            pp7.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "8")
                            pp8.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "9")
                            pp9.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "10")
                            pp10.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "11")
                            pp11.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "12")
                            pp12.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "13")
                            pp13.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "14")
                            pp14.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "15")
                            pp15.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "16")
                            pp16.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "17")
                            pp17.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "18")
                            pp18.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "19")
                            pp19.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "20")
                            pp20.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "21")
                            pp21.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "22")
                            pp22.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "23")
                            pp23.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "24")
                            pp24.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "25")
                            pp25.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "26")
                            pp26.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "27")
                            pp27.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "28")
                            pp28.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "29")
                            pp29.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "30")
                            pp30.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "31")
                            pp31.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "32")
                            pp32.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "33")
                            pp33.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "34")
                            pp34.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "35")
                            pp35.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "36")
                            pp36.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "37")
                            pp37.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "38")
                            pp38.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "39")
                            pp39.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "40")
                            pp40.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "41")
                            pp41.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "42")
                            pp42.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "43")
                            pp43.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "44")
                            pp44.BackImageUrl = "amar.gif";


                    }
                    if (ds.Tables[0].Rows[i][2].ToString() == "book")
                    {
                        if (ds.Tables[0].Rows[i][1].ToString() == "1")
                            pp1.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "2")
                            pp2.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "3")
                            pp3.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "4")
                            pp4.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "5")
                            pp5.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "6")
                            pp6.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "7")
                            pp7.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "8")
                            pp8.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "9")
                            pp9.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "10")
                            pp10.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "11")
                            pp11.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "12")
                            pp12.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "13")
                            pp13.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "14")
                            pp14.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "15")
                            pp15.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "16")
                            pp16.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "17")
                            pp17.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "18")
                            pp18.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "19")
                            pp19.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "20")
                            pp20.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "21")
                            pp21.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "22")
                            pp22.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "23")
                            pp23.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "24")
                            pp24.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "25")
                            pp25.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "26")
                            pp26.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "27")
                            pp27.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "28")
                            pp28.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "29")
                            pp29.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "30")
                            pp30.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "31")
                            pp31.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "32")
                            pp32.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "33")
                            pp33.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "34")
                            pp34.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "35")
                            pp35.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "36")
                            pp36.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "37")
                            pp37.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "38")
                            pp38.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "39")
                            pp39.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "40")
                            pp40.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "41")
                            pp41.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "42")
                            pp42.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "43")
                            pp43.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "44")
                            pp44.BackColor = Color.Green;

                    }
                }
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (ds1.Tables[0].Rows[i][1].ToString() == "1")
                        pp1.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "2")
                        pp2.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "3")
                        pp3.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "4")
                        pp4.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "5")
                        pp5.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "6")
                        pp6.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "7")
                        pp7.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "8")
                        pp8.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "9")
                        pp9.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "10")
                        pp10.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "11")
                        pp11.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "12")
                        pp12.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "13")
                        pp13.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "14")
                        pp14.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "15")
                        pp15.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "16")
                        pp16.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "17")
                        pp17.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "18")
                        pp18.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "19")
                        pp19.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "20")
                        pp20.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "21")
                        pp21.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "22")
                        pp22.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "23")
                        pp23.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "24")
                        pp24.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "25")
                        pp25.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "26")
                        pp26.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "27")
                        pp27.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "28")
                        pp28.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "29")
                        pp29.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "30")
                        pp30.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "31")
                        pp31.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "32")
                        pp32.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "33")
                        pp33.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "34")
                        pp34.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "35")
                        pp35.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "36")
                        pp36.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "37")
                        pp37.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "38")
                        pp38.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "39")
                        pp39.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "40")
                        pp40.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "41")
                        pp41.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "42")
                        pp42.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "43")
                        pp43.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "44")
                        pp44.BackColor = Color.Red;


                }

            }
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (ds2.Tables[0].Rows[i][1].ToString() == "1")
                        pp1.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "2")
                        pp2.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "3")
                        pp3.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "4")
                        pp4.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "5")
                        pp5.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "6")
                        pp6.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "7")
                        pp7.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "8")
                        pp8.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "9")
                        pp9.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "10")
                        pp10.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "11")
                        pp11.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "12")
                        pp12.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "13")
                        pp13.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "14")
                        pp14.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "15")
                        pp15.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "16")
                        pp16.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "17")
                        pp17.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "18")
                        pp18.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "19")
                        pp19.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "20")
                        pp20.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "21")
                        pp21.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "22")
                        pp22.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "23")
                        pp23.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "24")
                        pp24.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "25")
                        pp25.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "26")
                        pp26.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "27")
                        pp27.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "28")
                        pp28.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "29")
                        pp29.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "30")
                        pp30.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "31")
                        pp31.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "32")
                        pp32.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "33")
                        pp33.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "34")
                        pp34.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "35")
                        pp35.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "36")
                        pp36.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "37")
                        pp37.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "38")
                        pp38.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "39")
                        pp39.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "40")
                        pp40.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "41")
                        pp41.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "42")
                        pp42.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "43")
                        pp43.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "44")
                        pp44.BackImageUrl = "blue.gif";


                }
            }
        }
        catch (Exception r)
        {

        }
    }*/
}


