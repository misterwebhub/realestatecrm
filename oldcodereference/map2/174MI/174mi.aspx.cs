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

public partial class kishan_Bin_map2_174mi_174mi : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='174MI'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='174MI' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
			 con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='174MI' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
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
                    }
            }
        }
        catch (Exception t)
        {
        }
    }
}