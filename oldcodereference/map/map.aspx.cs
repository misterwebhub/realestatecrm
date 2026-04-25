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
public partial class kishan_Bin_map : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
   /* public Double arazi159()
    {
        
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='159' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='159' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='159' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='159' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            SqlDataAdapter da5 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='159' AND CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='159') ", con);

            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
Double fpt=0;
            if (ds3.Tables[0].Rows[0][0].ToString() != "")
            {
                fpt =Convert.ToDouble( ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
               fpt=0;
            }


            if (ds.Tables[0].Rows.Count > 0)
            {
               
          
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][2].ToString() == "empty")
                    {
                        if (ds.Tables[0].Rows[i][1].ToString() == "1")
                            FP1.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "2")
                            FP2.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "3")
                            FP3.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "4")
                            FP4.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "5")
                            FP5.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "6")
                            FP6.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "7")
                            FP7.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "8")
                            FP8.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "9")
                            FP9.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "10")
                            FP10.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "11")
                            FP11.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "12")
                            FP12.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "13")
                            FP13.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "14")
                            FP14.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "15")
                            FP15.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "16")
                            FP16.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "17")
                            FP17.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "18")
                            FP18.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "19")
                            FP19.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "20")
                            FP20.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "21")
                            FP21.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "22")
                            FP22.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "23")
                            FP23.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "24")
                            FP24.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "25")
                            FP25.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "26")
                            FP26.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "27")
                            FP27.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "28")
                            FP28.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "29")
                            FP29.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "30")
                            FP30.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "31")
                            FP31.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "32")
                            FP32.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "33")
                            FP33.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "34")
                            FP34.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "35")
                            FP35.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "36")
                            FP36.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "37")
                            FP37.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "38")
                            FP38.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "39")
                            FP39.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "40")
                            FP40.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "41")
                            FP41.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "42")
                            FP42.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "43")
                            FP43.BackImageUrl = "amar.gif";
                       
                     


                    }
                    if (ds.Tables[0].Rows[i][2].ToString() == "book")
                    {
                        if (ds.Tables[0].Rows[i][1].ToString() == "1")
                            FP1.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "2")
                            FP2.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "3")
                            FP3.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "4")
                            FP4.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "5")
                            FP5.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "6")
                            FP6.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "7")
                            FP7.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "8")
                            FP8.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "9")
                            FP9.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "10")
                            FP10.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "11")
                            FP11.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "12")
                            FP12.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "13")
                            FP13.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "14")
                            FP14.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "15")
                            FP15.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "16")
                            FP16.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "17")
                            FP17.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "18")
                            FP18.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "19")
                            FP19.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "20")
                            FP20.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "21")
                            FP21.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "22")
                            FP22.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "23")
                            FP23.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "24")
                            FP24.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "25")
                            FP25.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "26")
                            FP26.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "27")
                            FP27.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "28")
                            FP28.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "29")
                            FP29.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "30")
                            FP30.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "31")
                            FP31.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "32")
                            FP32.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "33")
                            FP33.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "34")
                            FP34.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "35")
                            FP35.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "36")
                            FP36.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "37")
                            FP37.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "38")
                            FP38.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "39")
                            FP39.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "40")
                            FP40.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "41")
                            FP41.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "42")
                            FP42.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "43")
                            FP43.BackColor = Color.Green;
                     
                        



                    }
                }
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (ds1.Tables[0].Rows[i][1].ToString() == "1")
                        FP1.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "2")
                        FP2.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "3")
                        FP3.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "4")
                        FP4.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "5")
                        FP5.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "6")
                        FP6.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "7")
                        FP7.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "8")
                        FP8.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "9")
                        FP9.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "10")
                        FP10.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "11")
                        FP11.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "12")
                        FP12.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "13")
                        FP13.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "14")
                        FP14.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "15")
                        FP15.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "16")
                        FP16.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "17")
                        FP17.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "18")
                        FP18.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "19")
                        FP19.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "20")
                        FP20.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "21")
                        FP21.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "22")
                        FP22.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "23")
                        FP23.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "24")
                        FP24.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "25")
                        FP25.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "26")
                        FP26.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "27")
                        FP27.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "28")
                        FP28.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "29")
                        FP29.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "30")
                        FP30.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "31")
                        FP31.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "32")
                        FP32.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "33")
                        FP33.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "34")
                        FP34.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "35")
                        FP35.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "36")
                        FP36.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "37")
                        FP37.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "38")
                        FP38.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "39")
                        FP39.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "40")
                        FP40.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "41")
                        FP41.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "42")
                        FP42.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "43")
                        FP43.BackColor = Color.Red;
                    



                }

            }
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (ds2.Tables[0].Rows[i][1].ToString() == "1")
                        FP1.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "2")
                        FP2.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "3")
                        FP3.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "4")
                        FP4.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "5")
                        FP5.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "6")
                        FP6.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "7")
                        FP7.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "8")
                        FP8.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "9")
                        FP9.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "10")
                        FP10.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "11")
                        FP11.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "12")
                        FP12.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "13")
                        FP13.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "14")
                        FP14.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "15")
                        FP15.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "16")
                        FP16.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "17")
                        FP17.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "18")
                        FP18.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "19")
                        FP19.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "20")
                        FP20.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "21")
                        FP21.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "22")
                        FP22.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "23")
                        FP23.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "24")
                        FP24.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "25")
                        FP25.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "26")
                        FP26.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "27")
                        FP27.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "28")
                        FP28.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "29")
                        FP29.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "30")
                        FP30.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "31")
                        FP31.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "32")
                        FP32.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "33")
                        FP33.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "34")
                        FP34.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "35")
                        FP35.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "36")
                        FP36.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "37")
                        FP37.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "38")
                        FP38.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "39")
                        FP39.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "40")
                        FP40.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "41")
                        FP41.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "42")
                        FP42.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "43")
                        FP43.BackImageUrl = "blue.gif";
                    

                }
            }
            if (ds5.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                {
                    if (ds5.Tables[0].Rows[i][1].ToString() == "1")
                        FP1.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "2")
                        FP2.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "3")
                        FP3.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "4")
                        FP4.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "5")
                        FP5.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "6")
                        FP6.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "7")
                        FP7.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "8")
                        FP8.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "9")
                        FP9.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "10")
                        FP10.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "11")
                        FP11.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "12")
                        FP12.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "13")
                        FP13.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "14")
                        FP14.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "15")
                        FP15.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "16")
                        FP16.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "17")
                        FP17.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "18")
                        FP18.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "19")
                        FP19.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "20")
                        FP20.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "21")
                        FP21.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "22")
                        FP22.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "23")
                        FP23.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "24")
                        FP24.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "25")
                        FP25.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "26")
                        FP26.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "27")
                        FP27.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "28")
                        FP28.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "29")
                        FP29.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "30")
                        FP30.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "31")
                        FP31.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "32")
                        FP32.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "33")
                        FP33.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "34")
                        FP34.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "35")
                        FP35.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "36")
                        FP36.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "37")
                        FP37.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "38")
                        FP38.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "39")
                        FP39.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "40")
                        FP40.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "41")
                        FP41.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "42")
                        FP42.BackImageUrl = "notsale.jpg";
                    if (ds5.Tables[0].Rows[i][1].ToString() == "43")
                        FP43.BackImageUrl = "notsale.jpg";
             
                   

                }
            }
            return fpt;
        
       
    }*/
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
			 SqlDataAdapter da5 = new SqlDataAdapter("select block,plotno,status from arazi30beegha where  CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='152') ", con);
           
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
			con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazi30beegha where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            Double fplot = 0,beegha=0;
           // fplot = arazi159();
            beegha=Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
            Label2.Text = (beegha + fplot).ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][0].ToString() == "A")
                    {
                        if (ds.Tables[0].Rows[i][2].ToString() == "empty")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                A11.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                A2.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                A3.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                A4.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                A5.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                A6.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                A7.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                A8.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                A9.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                A10.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                A111.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                A12.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                A13.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                A14.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                A15.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                A16.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                A17.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                A18.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                A19.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                A20.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                A21.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                A22.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                A23.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                A24.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                A25.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                A26.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                A27.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                A28.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                A29.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                A30.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                A31.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                A32.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                A33.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                A34.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                A35.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                A36.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "37")
                                A37.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "38")
                                A38.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "39")
                                A39.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "40")
                                A40.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "41")
                                A41.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "42")
                                A42.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "43")
                                A43.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "44")
                                A44.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "45")
                                A45.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "46")
                                A46.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "47")
                                A47.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "48")
                                A48.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                A49.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                A50.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                A51.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                A52.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                 A53.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                 A54.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                 A55.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                 A56.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                 A57.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                 A58.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "59")
                                 A59.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "60")
                                 A60.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "61")
                                 A61.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "62")
                                 A62.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "63")
                                 A63.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "64")
                                 A64.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "65")
                                 A65.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "66")
                                 A66.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "67")
                                 A67.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "68")
                                 A68.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "69")
                                 A69.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "70")
                                 A70.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "71")
                                 A71.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "72")
                                 A72.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "73")
                                 A73.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "74")
                                 A74.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "75")
                                 A75.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "76")
                                 A76.BackImageUrl = "amar.gif";
							
							/*if (ds.Tables[0].Rows[i][1].ToString() == "77")
                                 A77.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "78")
                                 A78.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "79")
                                 A79.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "80")
                                 A80.BackImageUrl = "amar.gif";*/
							if (ds.Tables[0].Rows[i][1].ToString() == "81")
                                 A81.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "82")
                                 A82.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "83")
                                 A83.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "84")
                                 A84.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "85")
                                 A85.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "86")
                                 A86.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "87")
                                 A87.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "88")
                                 A88.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "89")
                                 A89.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "90")
                                 A90.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "91")
                                 A91.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "92")
                                 A92.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "93")
                                 A93.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "94")
                                 A94.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "95")
                                 A95.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "96")
                                 A96.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "97")
                                 A97.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "98")
                                 A98.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "99")
                                 A99.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "100")
                                 A100.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "101")
                                 A101.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "102")
                                 A102.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "103")
                                 A103.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "104")
                                 A104.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "105")
                                 A105.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "106")
                                 A106.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "107")
                                 A107.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "108")
                                 A108.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "109")
                                 A109.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "110")
                                 A110.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "111")
                                 A1111.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "112")
                                 A112.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "113")
                                 A113.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "114")
                                 A114.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "115")
                                 A115.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "116")
                                 A116.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "117")
                                 A117.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "118")
                                 A118.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "119")
                                 A119.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "120")
                                 A120.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "121")
                                 A121.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "122")
                                 A122.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "123")
                                 A123.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "124")
                                 A124.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "125")
                                 A125.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "126")
                                 A126.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "127")
                                 A127.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "128")
                                 A128.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "129")
                                 A129.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "130")
                                 A130.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "131")
                                 A131.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "132")
                                 A132.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "133")
                                 A133.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "134")
                                 A134.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "135")
                                 A135.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "136")
                                 A136.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "137")
                                 A137.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "138")
                                 A138.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "139")
                                 A139.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "140")
                                 A140.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "141")
                                 A141.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "142")
                                 A142.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "143")
                                 A143.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "144")
                                 A144.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "145")
                                 A145.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "146")
                                 A146.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "147")
                                 A147.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "148")
                                 A148.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "149")
                                 A149.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "150")
                                 A150.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "151")
                                 A151.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "152")
                                 A152.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "153")
                                 A153.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "154")
                                 A154.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "155")
                                 A155.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "156")
                                 A156.BackImageUrl = "amar.gif";
							
                        }
                        if (ds.Tables[0].Rows[i][2].ToString() == "book")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                A11.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                A2.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                A3.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                A4.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                A5.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                A6.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                A7.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                A8.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                A9.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                A10.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                A111.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                A12.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                A13.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                A14.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                A15.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                A16.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                A17.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                A18.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                A19.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                A20.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                A21.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                A22.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                A23.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                A24.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                A25.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                A26.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                A27.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                A28.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                A29.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                A30.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                A31.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                A32.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                A33.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                A34.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                A35.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                A36.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "37")
                                A37.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "38")
                                A38.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "39")
                                A39.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "40")
                                A40.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "41")
                                A41.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "42")
                                A42.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "43")
                                A43.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "44")
                                A44.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "45")
                                A45.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "46")
                                A46.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "47")
                                A47.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "48")
                                A48.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                A49.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                A50.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                A51.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                A52.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                A53.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                A54.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                A55.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                A56.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                A57.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                A58.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "59")
                                A59.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "60")
                                A60.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "61")
                                A61.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "62")
                                A62.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "63")
                                A63.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "64")
                                A64.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "65")
                                A65.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "66")
                                A66.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "67")
                                A67.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "68")
                                A68.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "69")
                                A69.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "70")
                                A70.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "71")
                                A71.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "72")
                                A72.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "73")
                                A73.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "74")
                                A74.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "75")
                                A75.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "76")
                                A76.BackColor = Color.Green;
							/*if (ds.Tables[0].Rows[i][1].ToString() == "77")
                                 A77.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "78")
                                 A78.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "79")
                                 A79.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "80")
                                 A80.BackColor = Color.Green;*/
							if (ds.Tables[0].Rows[i][1].ToString() == "81")
                                 A81.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "82")
                                 A82.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "83")
                                 A83.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "84")
                                 A84.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "85")
                                 A85.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "86")
                                 A86.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "87")
                                 A87.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "88")
                                 A88.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "89")
                                 A89.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "90")
                                 A90.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "91")
                                 A91.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "92")
                                 A92.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "93")
                                 A93.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "94")
                                 A94.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "95")
                                 A95.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "96")
                                 A96.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "97")
                                 A97.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "98")
                                 A98.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "99")
                                 A99.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "100")
                                 A100.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "101")
                                 A101.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "102")
                                 A102.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "103")
                                 A103.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "104")
                                 A104.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "105")
                                 A105.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "106")
                                 A106.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "107")
                                 A107.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "108")
                                 A108.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "109")
                                 A109.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "110")
                                 A110.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "111")
                                 A1111.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "112")
                                 A112.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "113")
                                 A113.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "114")
                                 A114.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "115")
                                 A115.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "116")
                                 A116.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "117")
                                 A117.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "118")
                                 A118.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "119")
                                 A119.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "120")
                                 A120.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "121")
                                 A121.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "122")
                                 A122.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "123")
                                 A123.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "124")
                                 A124.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "125")
                                 A125.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "126")
                                 A126.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "127")
                                 A127.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "128")
                                 A128.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "129")
                                 A129.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "130")
                                 A130.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "131")
                                 A131.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "132")
                                 A132.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "133")
                                 A133.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "134")
                                 A134.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "135")
                                 A135.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "136")
                                 A136.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "137")
                                 A137.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "138")
                                 A138.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "139")
                                 A139.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "140")
                                 A140.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "141")
                                 A141.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "142")
                                 A142.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "143")
                                 A143.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "144")
                                 A144.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "145")
                                 A145.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "146")
                                 A146.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "147")
                                 A147.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "148")
                                 A148.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "149")
                                 A149.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "150")
                                 A150.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "151")
                                 A151.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "152")
                                 A152.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "153")
                                 A153.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "154")
                                 A154.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "155")
                                 A155.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "156")
                                 A156.BackColor = Color.Green;
                        }
                    }
                    
                    if (ds.Tables[0].Rows[i][0].ToString() == "C")
                    {
                        if (ds.Tables[0].Rows[i][2].ToString() == "empty")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                C1.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                C2.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                C3.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                C4.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                C5.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                C6.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                C7.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                C8.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                C9.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                C10.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                C11.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                C12.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                C13.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                C14.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                C15.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                C16.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                C17.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                C18.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                C19.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                C20.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                C21.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                C22.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                C23.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                C244.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                C25.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                C26.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                C27.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                C28.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                C29.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                C30.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                C31.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                C32.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                C33.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                C34.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                C35.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                C36.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "37")
                                C37.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "38")
                                C38.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "39")
                                C39.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "40")
                                C40.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "41")
                                C41.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "42")
                                C42.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "43")
                                C43.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "44")
                                C44.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "45")
                                C45.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "46")
                                C46.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "47")
                                C47.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "48")
                                C48.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                C49.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                C50.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                C51.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                C52.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                C53.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                C54.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                C55.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                C56.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                C57.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                C58.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "59")
                                C59.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "60")
                                C60.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "61")
                                C61.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "62")
                                C62.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "63")
                                C63.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "64")
                                C64.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "65")
                                C65.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "66")
                                C66.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "67")
                                C67.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "68")
                                C68.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "69")
                                C69.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "70")
                                C70.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "71")
                                C71.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "72")
                                C72.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "73")
                                C73.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "74")
                                C74.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "75")
                                C75.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "76")
                                C76.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "77")
                                C77.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "78")
                                C78.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "79")
                                C79.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "80")
                                C80.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "81")
                                C81.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "82")
                                C82.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "83")
                                C83.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "84")
                                C84.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "85")
                                C85.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "86")
                                C86.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "87")
                                C87.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "88")
                                C88.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "89")
                                C89.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "90")
                                C90.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "91")
                                C91.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "92")
                                C92.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "93")
                                C93.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "94")
                                C94.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "95")
                                C95.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "96")
                                C96.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "97")
                                C97.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "98")
                                C98.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "99")
                                C99.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "100")
                                C100.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "101")
                                C101.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "102")
                                C102.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "103")
                                C103.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "104")
                                C104.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "105")
                                C105.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "106")
                                C106.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "107")
                                C107.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "108")
                                C108.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "109")
                                C109.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "110")
                                C110.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "111")
                                C111.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "112")
                                C112.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "113")
                                C113.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "114")
                                C114.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "115")
                                C115.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "116")
                                C116.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "117")
                                C117.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "118")
                                C118.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "119")
                                C119.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "120")
                                C120.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "121")
                                C121.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "122")
                                C122.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "123")
                                C123.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "124")
                                C124.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "125")
                                C125.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "126")
                                C126.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "127")
                                C127.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "128")
                                C128.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "129")
                                C129.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "130")
                                C130.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "131")
                                C131.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "132")
                                C132.BackImageUrl = "amar.gif";
							if (ds.Tables[0].Rows[i][1].ToString() == "133")
                                C133.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "134")
                                C134.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "135")
                                C135.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "136")
                                C136.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "137")
                                C137.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "138")
                                C138.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "139")
                                C139.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "140")
                                C140.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "141")
                                C141.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "142")
                                C142.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "143")
                                C143.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "144")
                                C144.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "145")
                                C145.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "146")
                                C146.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "147")
                                C147.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "148")
                                C148.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "149")
                                C149.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "150")
                                C150.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "151")
                                C151.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "152")
                                C152.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "153")
                                C153.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "154")
                                C154.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "155")
                                C155.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "156")
                                C156.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "157")
                                C157.BackImageUrl = "amar.gif";

                        }
                        if (ds.Tables[0].Rows[i][2].ToString() == "book")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                C1.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                C2.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                C3.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                C4.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                C5.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                C6.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                C7.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                C8.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                C9.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                C10.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                C11.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                C12.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                C13.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                C14.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                C15.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                C16.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                C17.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                C18.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                C19.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                C20.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                C21.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                C22.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                C23.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                C244.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                C25.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                C26.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                C27.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                C28.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                C29.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                C30.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                C31.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                C32.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                C33.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                C34.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                C35.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                C36.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "37")
                                C37.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "38")
                                C38.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "39")
                                C39.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "40")
                                C40.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "41")
                                C41.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "42")
                                C42.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "43")
                                C43.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "44")
                                C44.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "45")
                                C45.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "46")
                                C46.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "47")
                                C47.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "48")
                                C48.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                C49.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                C50.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                C51.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                C52.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                C53.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                C54.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                C55.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                C56.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                C57.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                C58.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "59")
                                C59.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "60")
                                C60.BackColor = Color.Green;
							
							if (ds.Tables[0].Rows[i][1].ToString() == "61")
                                C61.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "62")
                                C62.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "63")
                                C63.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "64")
                                C64.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "65")
                                C65.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "66")
                                C66.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "67")
                                C67.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "68")
                                C68.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "69")
                                C69.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "70")
                                C70.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "71")
                                C71.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "72")
                                C72.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "73")
                                C73.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "74")
                                C74.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "75")
                                C75.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "76")
                                C76.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "77")
                                C77.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "78")
                                C78.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "79")
                                C79.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "80")
                                C80.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "81")
                                C81.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "82")
                                C82.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "83")
                                C83.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "84")
                                C84.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "85")
                                C85.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "86")
                                C86.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "87")
                                C87.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "88")
                                C88.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "89")
                                C89.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "90")
                                C90.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "91")
                                C91.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "92")
                                C92.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "93")
                                C93.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "94")
                                C94.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "95")
                                C95.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "96")
                                C96.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "97")
                                C97.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "98")
                                C98.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "99")
                                C99.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "100")
                                C100.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "101")
                                C101.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "102")
                                C102.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "103")
                                C103.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "104")
                                C104.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "105")
                                C105.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "106")
                                C106.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "107")
                                C107.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "108")
                                C108.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "109")
                                C109.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "110")
                                C110.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "111")
                                C111.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "112")
                                C112.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "113")
                                C113.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "114")
                                C114.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "115")
                                C115.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "116")
                                C116.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "117")
                                C117.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "118")
                                C118.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "119")
                                C119.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "120")
                                C120.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "121")
                                C121.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "122")
                                C122.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "123")
                                C123.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "124")
                                C124.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "125")
                                C125.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "126")
                                C126.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "127")
                                C127.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "128")
                                C128.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "129")
                                C129.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "130")
                                C130.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "131")
                                C131.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "132")
                                C132.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "133")
                                C133.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "134")
                                C134.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "135")
                                C135.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "136")
                                C136.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "137")
                                C137.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "138")
                                C138.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "139")
                                C139.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "140")
                                C140.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "141")
                                C141.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "142")
                                C142.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "143")
                                C143.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "144")
                                C144.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "145")
                                C145.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "146")
                                C146.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "147")
                                C147.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "148")
                                C148.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "149")
                                C149.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "150")
                                C150.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "151")
                                C151.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "152")
                                C152.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "153")
                                C153.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "154")
                                C154.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "155")
                                C155.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "156")
                                C156.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "157")
                                C157.BackColor = Color.Green;
                        }
                    }
                    if (ds.Tables[0].Rows[i][0].ToString() == "B")
                    {
                        if (ds.Tables[0].Rows[i][2].ToString() == "empty")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                B1.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                B2.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                B3.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                B4.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                B5.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                B6.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                B7.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                B8.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                B9.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                B10.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                B11.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                B12.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                B13.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                B14.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                B15.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                B16.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                B17.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                B18.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                B19.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                B20.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                B21.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                B22.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                B23.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                B24.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                B25.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                B26.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                B27.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                B28.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                B29.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                B30.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                B31.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                B32.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                B33.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                B34.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                B35.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                B36.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "37")
                                B37.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "38")
                                B38.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "39")
                                B39.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "40")
                                B40.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "41")
                                B41.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "42")
                                B42.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "43")
                                B43.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "44")
                                B44.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "45")
                                B45.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "46")
                                B46.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "47")
                                B47.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "48")
                                B48.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                B49.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                B50.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                B51.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                B52.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                B53.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                B54.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                B55.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                B56.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                B57.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                B58.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "59")
                                B59.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "60")
                                B60.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "61")
                                B61.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "62")
                                B62.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "63")
                                B63.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "64")
                                B64.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "65")
                                B65.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "66")
                                B66.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "67")
                                B67.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "68")
                                B68.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "69")
                               B69.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "70")
                               B70.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "71")
                               B71.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "72")
                               B72.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "73")
                               B73.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "74")
                               B74.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "75")
                               B75.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "76")
                               B76.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "77")
                               B77.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "78")
                               B78.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "79")
                               B79.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "80")
                               B80.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "81")
                               B81.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "82")
                               B82.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "83")
                               B83.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "84")
                               B84.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "85")
                               B85.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "86")
                               B86.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "87")
                               B87.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "88")
                               B88.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "89")
                               B89.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "90")
                               B90.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "91")
                               B91.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "92")
                               B92.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "93")
                               B93.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "94")
                               B94.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "95")
                               B95.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "96")
                               B96.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "97")
                               B97.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "98")
                               B98.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "99")
                               B99.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "100")
                               B100.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "101")
                               B101.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "102")
                               B102.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "103")
                               B103.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "104")
                               B104.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "105")
                               B105.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "106")
                               B106.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "107")
                               B107.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "108")
                               B108.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "109")
                               B109.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "110")
                               B110.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "111")
                               B111.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "112")
                               B112.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "113")
                               B113.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "114")
                               B114.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "115")
                               B115.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "116")
                               B116.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "117")
                               B117.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "118")
                               B118.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "119")
                               B119.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "120")
                               B120.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "121")
                               B121.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "122")
                               B122.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "123")
                               B123.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "124")
                               B124.BackImageUrl = "amar.gif";
                           if (ds.Tables[0].Rows[i][1].ToString() == "125")
                               B125.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "126")
                               B126.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "127")
                               B127.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "128")
                                 B128.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "129")
                                 B129.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "130")
                                 B130.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "131")
                                 B131.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "132")
                                 B132.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "133")
                                 B133.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "134")
                                 B134.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "135")
                                 B135.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "136")
                                 B136.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "137")
                                 B137.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "138")
                                 B138.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "139")
                                 B139.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "140")
                                 B140.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "141")
                                 B141.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "142")
                                 B142.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "143")
                                 B143.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "144")
                                 B144.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "145")
                                 B145.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "146")
                                 B146.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "147")
                                 B147.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "148")
                                 B148.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "149")
                                 B149.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "150")
                                 B150.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "151")
                                 B151.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "152")
                                 B152.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "153")
                                 B153.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "154")
                                 B154.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "155")
                                 B155.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "156")
                                 B156.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "157")
                                 B157.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "158")
                                 B158.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "159")
                                 B159.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "160")
                                 B160.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "161")
                                 B161.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "162")
                                 B162.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "163")
                                 B163.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "164")
                                 B164.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "165")
                                 B165.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "166")
                                 B166.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "167")
                                 B167.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "168")
                                 B168.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "169")
                                 B169.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "170")
                                 B170.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "171")
                                 B171.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "172")
                                 B172.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "173")
                                 B173.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "174")
                                 B174.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "175")
                                 B175.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "176")
                                 B176.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "177")
                                 B177.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "178")
                                 B178.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "179")
                                 B179.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "180")
                                 B180.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "181")
                                 B181.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "182")
                                 B182.BackImageUrl = "amar.gif";
                             if (ds.Tables[0].Rows[i][1].ToString() == "183")
                                 B183.BackImageUrl = "amar.gif";
                          
                        }
                        if (ds.Tables[0].Rows[i][2].ToString() == "book")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                B1.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                B2.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                B3.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                B4.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                B5.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                B6.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                B7.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                B8.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                B9.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                B10.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                B11.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                B12.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                B13.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                B14.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                B15.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                B16.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                B17.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                B18.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                B19.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                B20.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                B21.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                B22.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                B23.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                B24.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                B25.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                B26.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                B27.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                B28.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                B29.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                B30.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                B31.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                B32.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                B33.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                B34.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                B35.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                B36.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "37")
                                B37.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "38")
                                B38.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "39")
                                B39.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "40")
                                B40.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "41")
                                B41.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "42")
                                B42.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "43")
                                B43.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "44")
                                B44.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "45")
                                B45.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "46")
                                B46.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "47")
                                B47.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "48")
                                B48.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                B49.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                B50.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                B51.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                B52.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                B53.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                B54.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                B55.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                B56.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                B57.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                B58.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "59")
                                B59.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "60")
                                B60.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "61")
                                B61.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "62")
                                B62.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "63")
                                B63.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "64")
                                B64.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "65")
                                B65.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "66")
                                B66.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "67")
                                B67.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "68")
                                B68.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "69")
                                B69.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "70")
                                B70.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "71")
                                B71.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "72")
                                B72.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "73")
                                B73.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "74")
                                B74.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "75")
                                B75.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "76")
                                B76.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "77")
                                B77.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "78")
                                B78.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "79")
                                B79.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "80")
                                B80.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "81")
                                B81.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "82")
                                B82.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "83")
                                B83.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "84")
                                B84.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "85")
                                B85.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "86")
                                B86.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "87")
                                B87.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "88")
                                B88.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "89")
                                B89.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "90")
                                B90.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "91")
                                B91.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "92")
                                B92.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "93")
                                B93.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "94")
                                B94.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "95")
                                B95.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "96")
                                B96.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "97")
                                B97.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "98")
                                B98.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "99")
                                B99.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "100")
                                B100.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "101")
                                B101.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "102")
                                B102.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "103")
                                B103.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "104")
                                B104.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "105")
                                B105.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "106")
                                B106.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "107")
                                B107.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "108")
                                B108.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "109")
                                B109.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "110")
                                B110.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "111")
                                B111.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "112")
                                B112.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "113")
                                B113.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "114")
                                B114.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "115")
                                B115.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "116")
                                B116.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "117")
                                B117.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "118")
                                B118.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "119")
                                B119.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "120")
                                B120.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "121")
                                B121.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "122")
                                B122.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "123")
                                B123.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "124")
                                B124.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "125")
                                B125.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "126")
                                B126.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "127")
                                B127.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "128")
                                B128.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "129")
                                B129.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "130")
                                B130.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "131")
                                B131.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "132")
                                B132.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "133")
                                B133.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "134")
                                B134.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "135")
                                B135.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "136")
                                B136.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "137")
                                B137.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "138")
                                B138.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "139")
                                B139.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "140")
                                B140.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "141")
                                B141.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "142")
                                B142.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "143")
                                B143.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "144")
                                B144.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "145")
                                B145.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "146")
                                B146.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "147")
                                B147.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "148")
                                B148.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "149")
                                B149.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "150")
                                B150.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "151")
                                B151.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "152")
                                B152.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "153")
                                B153.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "154")
                                B154.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "155")
                                B155.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "156")
                                B156.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "157")
                                B157.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "158")
                                B158.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "159")
                                B159.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "160")
                                B160.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "161")
                                B161.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "162")
                                B162.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "163")
                                B163.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "164")
                                B164.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "165")
                                B165.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "166")
                                B166.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "167")
                                B167.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "168")
                                B168.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "169")
                                B169.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "170")
                                B170.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "171")
                                B171.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "172")
                                B172.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "173")
                                B173.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "174")
                                B174.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "175")
                                B175.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "176")
                                B176.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "177")
                                B177.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "178")
                                B178.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "179")
                                B179.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "180")
                                B180.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "181")
                                B181.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "182")
                                B182.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "183")
                                B183.BackColor = Color.Green;
                           

                        }
                    }
                    if (ds.Tables[0].Rows[i][0].ToString() == "F")
                    {
                        if (ds.Tables[0].Rows[i][2].ToString() == "empty")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                FP1.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                FP2.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                FP3.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                FP4.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                FP5.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                FP6.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                FP7.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                FP8.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                FP9.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                FP10.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                FP11.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                FP12.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                FP13.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                FP14.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                FP15.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                FP16.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                FP17.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                FP18.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                FP19.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                FP20.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                FP21.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                FP22.BackImageUrl = "amar.gif";
                            /*   if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                   FP23.BackImageUrl = "amar.gif";
                               if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                   FP24.BackImageUrl = "amar.gif";
                               if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                   FP25.BackImageUrl = "amar.gif";
                               if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                   FP26.BackImageUrl = "amar.gif";
                               if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                   FP27.BackImageUrl = "amar.gif";*/
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                FP28.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                FP29.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                FP30.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                FP31.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                FP32.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                FP33.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                FP34.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                FP35.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                FP36.BackImageUrl = "amar.gif";

                        }

                        if (ds.Tables[0].Rows[i][2].ToString() == "book")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                FP1.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                FP2.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                FP3.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                FP4.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                FP5.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                FP6.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                FP7.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                FP8.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                FP9.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                FP10.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                FP11.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                FP12.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                FP13.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                FP14.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                FP15.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                FP16.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                FP17.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                FP18.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                FP19.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                FP20.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                FP21.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                FP22.BackColor = Color.Green;
                            /*    if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                    FP23.BackColor = Color.Green;
                                if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                    FP24.BackColor = Color.Green;
                                if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                    FP25.BackColor = Color.Green;
                                if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                    FP26.BackColor = Color.Green;
                                if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                    FP27.BackColor = Color.Green;*/
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                FP28.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                FP29.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                FP30.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                FP31.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                FP32.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                FP33.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                FP34.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                FP35.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                FP36.BackColor = Color.Green;

                        }
                    }
                    if (ds.Tables[0].Rows[i][0].ToString() == "E")
                    {
                        if (ds.Tables[0].Rows[i][2].ToString() == "empty")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                E1.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                E2.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                E3.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                E4.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                E5.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                E6.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                E7.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                E8.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                E9.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                E10.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                E11.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                E12.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                E13.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                E14.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                E15.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                E16.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                E17.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                E18.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                E19.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                E20.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                E21.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                E22.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                E23.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                E24.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                E25.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                E26.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                E27.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                E28.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                E29.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                E30.BackImageUrl = "amar.gif";
                           /* if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                E31.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                E32.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                E33.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                E34.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                E35.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                E36.BackImageUrl = "amar.gif";*/
                            if (ds.Tables[0].Rows[i][1].ToString() == "37")
                                E37.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "38")
                                E38.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "39")
                                E39.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "40")
                                E40.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "41")
                                E41.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "42")
                                E42.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "43")
                                E43.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "44")
                                E44.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "45")
                                E45.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "46")
                                E46.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "47")
                                E47.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "48")
                                E48.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                E49.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                E50.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                E51.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                E52.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                E53.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                E54.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                E55.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                E56.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                E57.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                E58.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "59")
                                E59.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "60")
                                E60.BackImageUrl = "amar.gif";

                            if (ds.Tables[0].Rows[i][1].ToString() == "61")
                                E61.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "62")
                                E62.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "63")
                                E63.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "64")
                                E64.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "65")
                                E65.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "66")
                                E66.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "67")
                                E67.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "68")
                                E68.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "69")
                                E69.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "70")
                                E70.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "71")
                                E71.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "72")
                                E72.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "73")
                                E73.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "74")
                                E74.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "75")
                                E75.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "76")
                                E76.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "77")
                                E77.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "78")
                                E78.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "79")
                                E79.BackImageUrl = "amar.gif";
                            if (ds.Tables[0].Rows[i][1].ToString() == "80")
                                E80.BackImageUrl = "amar.gif";
							 if (ds.Tables[0].Rows[i][1].ToString() == "81")
                                E81.BackImageUrl = "amar.gif";
                           
                        }

                        if (ds.Tables[0].Rows[i][2].ToString() == "book")
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() == "1")
                                E1.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "2")
                                E2.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "3")
                                E3.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "4")
                                E4.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "5")
                                E5.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "6")
                                E6.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "7")
                                E7.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "8")
                                E8.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "9")
                                E9.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "10")
                                E10.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "11")
                                E11.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "12")
                                E12.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "13")
                                E13.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "14")
                                E14.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "15")
                                E15.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "16")
                                E16.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "17")
                                E17.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "18")
                                E18.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "19")
                                E19.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "20")
                                E20.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "21")
                                E21.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "22")
                                E22.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "23")
                                E23.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "24")
                                E24.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "25")
                                E25.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "26")
                                E26.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "27")
                                E27.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "28")
                                E28.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "29")
                                E29.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "30")
                                E30.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "31")
                                E31.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "32")
                                E32.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "33")
                                E33.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "34")
                                E34.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "35")
                                E35.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "36")
                                E36.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "37")
                                E37.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "38")
                                E38.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "39")
                                E39.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "40")
                                E40.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "41")
                                E41.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "42")
                                E42.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "43")
                                E43.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "44")
                                E44.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "45")
                                E45.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "46")
                                E46.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "47")
                                E47.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "48")
                                E48.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "49")
                                E49.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "50")
                                E50.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "51")
                                E51.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "52")
                                E52.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "53")
                                E53.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "54")
                                E54.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "55")
                                E55.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "56")
                                E56.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "57")
                                E57.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "58")
                                E58.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "59")
                                E59.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "60")
                                E60.BackColor = Color.Green;

                            if (ds.Tables[0].Rows[i][1].ToString() == "61")
                                E61.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "62")
                                E62.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "63")
                                E63.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "64")
                                E64.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "65")
                                E65.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "66")
                                E66.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "67")
                                E67.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "68")
                                E68.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "69")
                                E69.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "70")
                                E70.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "71")
                                E71.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "72")
                                E72.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "73")
                                E73.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "74")
                                E74.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "75")
                                E75.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "76")
                                E76.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "77")
                                E77.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "78")
                                E78.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "79")
                                E79.BackColor = Color.Green;
                            if (ds.Tables[0].Rows[i][1].ToString() == "80")
                                E80.BackColor = Color.Green;
							if (ds.Tables[0].Rows[i][1].ToString() == "81")
                                E81.BackColor = Color.Green;
                        }
                    }

                }
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (ds1.Tables[0].Rows[i][0].ToString() == "A")
                    {

                        if (ds1.Tables[0].Rows[i][1].ToString() == "1")
                            A11.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "2")
                            A2.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "3")
                            A3.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "4")
                            A4.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "5")
                            A5.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "6")
                            A6.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "7")
                            A7.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "8")
                            A8.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "9")
                            A9.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "10")
                            A10.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "11")
                            A111.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "12")
                            A12.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "13")
                            A13.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "14")
                            A14.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "15")
                            A15.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "16")
                            A16.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "17")
                            A17.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "18")
                            A18.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "19")
                            A19.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "20")
                            A20.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "21")
                            A21.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "22")
                            A22.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "23")
                            A23.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "24")
                            A24.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "25")
                            A25.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "26")
                            A26.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "27")
                            A27.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "28")
                            A28.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "29")
                            A29.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "30")
                            A30.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "31")
                            A31.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "32")
                            A32.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "33")
                            A33.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "34")
                            A34.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "35")
                            A35.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "36")
                            A36.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "37")
                            A37.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "38")
                            A38.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "39")
                            A39.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "40")
                            A40.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "41")
                            A41.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "42")
                            A42.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "43")
                            A43.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "44")
                            A44.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "45")
                            A45.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "46")
                            A46.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "47")
                            A47.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "48")
                            A48.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "49")
                            A49.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "50")
                            A50.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "51")
                            A51.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "52")
                            A52.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "53")
                            A53.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "54")
                            A54.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "55")
                            A55.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "56")
                            A56.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "57")
                            A57.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "58")
                            A58.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "59")
                            A59.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "60")
                            A60.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "61")
                            A61.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "62")
                            A62.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "63")
                            A63.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "64")
                            A64.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "65")
                            A65.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "66")
                            A66.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "67")
                            A67.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "68")
                            A68.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "69")
                            A69.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "70")
                            A70.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "71")
                            A71.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "72")
                            A72.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "73")
                            A73.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "74")
                            A74.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "75")
                            A75.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "76")
                            A76.BackColor = Color.Red;
						
							/*if (ds1.Tables[0].Rows[i][1].ToString() == "77")
                                 A77.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "78")
                                 A78.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "79")
                                 A79.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "80")
                                 A80.BackColor = Color.Red;*/
							if (ds1.Tables[0].Rows[i][1].ToString() == "81")
                                 A81.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "82")
                                 A82.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "83")
                                 A83.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "84")
                                 A84.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "85")
                                 A85.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "86")
                                 A86.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "87")
                                 A87.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "88")
                                 A88.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "89")
                                 A89.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "90")
                                 A90.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "91")
                                 A91.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "92")
                                 A92.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "93")
                                 A93.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "94")
                                 A94.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "95")
                                 A95.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "96")
                                 A96.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "97")
                                 A97.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "98")
                                 A98.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "99")
                                 A99.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "100")
                                 A100.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "101")
                                 A101.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "102")
                                 A102.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "103")
                                 A103.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "104")
                                 A104.BackColor = Color.Red;
												if (ds1.Tables[0].Rows[i][1].ToString() == "105")
                                 A105.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "106")
                                 A106.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "107")
                                 A107.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "108")
                                 A108.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "109")
                                 A109.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "110")
                                 A110.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "111")
                                 A1111.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "112")
                                 A112.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "113")
                                 A113.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "114")
                                 A114.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "115")
                                 A115.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "116")
                                 A116.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "117")
                                 A117.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "118")
                                 A118.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "119")
                                 A119.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "120")
                                 A120.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "121")
                                 A121.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "122")
                                 A122.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "123")
                                 A123.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "124")
                                 A124.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "125")
                                 A125.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "126")
                                 A126.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "127")
                                 A127.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "128")
                                 A128.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "129")
                                 A129.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "130")
                                 A130.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "131")
                                 A131.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "132")
                                 A132.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "133")
                                 A133.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "134")
                                 A134.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "135")
                                 A135.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "136")
                                 A136.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "137")
                                 A137.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "138")
                                 A138.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "139")
                                 A139.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "140")
                                 A140.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "141")
                                 A141.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "142")
                                 A142.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "143")
                                 A143.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "144")
                                 A144.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "145")
                                 A145.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "146")
                                 A146.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "147")
                                 A147.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "148")
                                 A148.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "149")
                                 A149.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "150")
                                 A150.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "151")
                                 A151.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "152")
                                 A152.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "153")
                                 A153.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "154")
                                 A154.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "155")
                                 A155.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "156")
                                 A156.BackColor = Color.Red;

                    }

                    if (ds1.Tables[0].Rows[i][0].ToString() == "C")
                    {
                        if (ds1.Tables[0].Rows[i][1].ToString() == "1")
                            C1.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "2")
                            C2.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "3")
                            C3.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "4")
                            C4.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "5")
                            C5.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "6")
                            C6.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "7")
                            C7.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "8")
                            C8.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "9")
                            C9.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "10")
                            C10.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "11")
                            C11.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "12")
                            C12.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "13")
                            C13.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "14")
                            C14.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "15")
                            C15.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "16")
                            C16.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "17")
                            C17.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "18")
                            C18.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "19")
                            C19.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "20")
                            C20.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "21")
                            C21.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "22")
                            C22.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "23")
                            C23.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "24")
                            C244.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "25")
                            C25.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "26")
                            C26.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "27")
                            C27.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "28")
                            C28.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "29")
                            C29.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "30")
                            C30.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "31")
                            C31.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "32")
                            C32.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "33")
                            C33.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "34")
                            C34.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "35")
                            C35.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "36")
                            C36.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "37")
                            C37.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "38")
                            C38.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "39")
                            C39.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "40")
                            C40.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "41")
                            C41.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "42")
                            C42.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "43")
                            C43.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "44")
                            C44.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "45")
                            C45.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "46")
                            C46.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "47")
                            C47.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "48")
                            C48.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "49")
                            C49.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "50")
                            C50.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "51")
                            C51.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "52")
                            C52.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "53")
                            C53.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "54")
                            C54.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "55")
                            C55.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "56")
                            C56.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "57")
                            C57.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "58")
                            C58.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "59")
                            C59.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "60")
                            C60.BackColor = Color.Red;
							 	
							if (ds1.Tables[0].Rows[i][1].ToString() == "61")
                                C61.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "62")
                                C62.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "63")
                                C63.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "64")
                                C64.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "65")
                                C65.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "66")
                                C66.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "67")
                                C67.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "68")
                                C68.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "69")
                                C69.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "70")
                                C70.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "71")
                                C71.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "72")
                                C72.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "73")
                                C73.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "74")
                                C74.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "75")
                                C75.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "76")
                                C76.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "77")
                                C77.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "78")
                                C78.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "79")
                                C79.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "80")
                                C80.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "81")
                                C81.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "82")
                                C82.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "83")
                                C83.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "84")
                                C84.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "85")
                                C85.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "86")
                                C86.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "87")
                                C87.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "88")
                                C88.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "89")
                                C89.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "90")
                                C90.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "91")
                                C91.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "92")
                                C92.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "93")
                                C93.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "94")
                                C94.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "95")
                                C95.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "96")
                                C96.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "97")
                                C97.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "98")
                                C98.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "99")
                                C99.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "100")
                                C100.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "101")
                                C101.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "102")
                                C102.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "103")
                                C103.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "104")
                                C104.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "105")
                                C105.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "106")
                                C106.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "107")
                                C107.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "108")
                                C108.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "109")
                                C109.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "110")
                                C110.BackColor = Color.Red;
						if (ds1.Tables[0].Rows[i][1].ToString() == "111")
                                C111.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "112")
                                C112.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "113")
                                C113.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "114")
                                C114.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "115")
                                C115.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "116")
                                C116.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "117")
                                C117.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "118")
                                C118.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "119")
                                C119.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "120")
                                C120.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "121")
                                C121.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "122")
                                C122.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "123")
                                C123.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "124")
                                C124.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "125")
                                C125.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "126")
                                C126.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "127")
                                C127.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "128")
                                C128.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "129")
                                C129.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "130")
                                C130.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "131")
                                C131.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "132")
                                C132.BackColor = Color.Red;
							if (ds1.Tables[0].Rows[i][1].ToString() == "133")
                                C133.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "134")
                                C134.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "135")
                                C135.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "136")
                                C136.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "137")
                                C137.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "138")
                                C138.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "139")
                                C139.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "140")
                                C140.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "141")
                                C141.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "142")
                                C142.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "143")
                                C143.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "144")
                                C144.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "145")
                                C145.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "146")
                                C146.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "147")
                                C147.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "148")
                                C148.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "149")
                                C149.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "150")
                                C150.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "151")
                                C151.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "152")
                                C152.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "153")
                                C153.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "154")
                                C154.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "155")
                                C155.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "156")
                                C156.BackColor = Color.Red;
                            if (ds1.Tables[0].Rows[i][1].ToString() == "157")
                                C157.BackColor = Color.Red;
                    }

                    if (ds1.Tables[0].Rows[i][0].ToString() == "B")
                    {

                        if (ds1.Tables[0].Rows[i][1].ToString() == "1")
                            B1.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "2")
                            B2.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "3")
                            B3.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "4")
                            B4.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "5")
                            B5.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "6")
                            B6.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "7")
                            B7.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "8")
                            B8.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "9")
                            B9.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "10")
                            B10.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "11")
                            B11.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "12")
                            B12.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "13")
                            B13.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "14")
                            B14.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "15")
                            B15.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "16")
                            B16.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "17")
                            B17.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "18")
                            B18.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "19")
                            B19.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "20")
                            B20.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "21")
                            B21.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "22")
                            B22.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "23")
                            B23.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "24")
                            B24.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "25")
                            B25.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "26")
                            B26.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "27")
                            B27.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "28")
                            B28.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "29")
                            B29.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "30")
                            B30.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "31")
                            B31.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "32")
                            B32.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "33")
                            B33.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "34")
                            B34.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "35")
                            B35.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "36")
                            B36.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "37")
                            B37.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "38")
                            B38.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "39")
                            B39.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "40")
                            B40.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "41")
                            B41.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "42")
                            B42.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "43")
                            B43.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "44")
                            B44.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "45")
                            B45.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "46")
                            B46.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "47")
                            B47.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "48")
                            B48.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "49")
                            B49.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "50")
                            B50.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "51")
                            B51.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "52")
                            B52.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "53")
                            B53.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "54")
                            B54.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "55")
                            B55.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "56")
                            B56.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "57")
                            B57.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "58")
                            B58.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "59")
                            B59.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "60")
                            B60.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "61")
                            B61.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "62")
                            B62.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "63")
                            B63.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "64")
                            B64.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "65")
                            B65.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "66")
                            B66.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "67")
                            B67.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "68")
                            B68.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "69")
                            B69.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "70")
                            B70.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "71")
                            B71.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "72")
                            B72.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "73")
                            B73.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "74")
                            B74.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "75")
                            B75.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "76")
                            B76.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "77")
                            B77.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "78")
                            B78.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "79")
                            B79.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "80")
                            B80.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "81")
                            B81.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "82")
                            B82.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "83")
                            B83.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "84")
                            B84.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "85")
                            B85.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "86")
                            B86.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "87")
                            B87.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "88")
                            B88.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "89")
                            B89.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "90")
                            B90.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "91")
                            B91.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "92")
                            B92.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "93")
                            B93.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "94")
                            B94.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "95")
                            B95.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "96")
                            B96.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "97")
                            B97.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "98")
                            B98.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "99")
                            B99.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "100")
                            B100.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "101")
                            B101.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "102")
                            B102.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "103")
                            B103.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "104")
                            B104.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "105")
                            B105.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "106")
                            B106.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "107")
                            B107.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "108")
                            B108.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "109")
                            B109.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "110")
                            B110.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "111")
                            B111.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "112")
                            B112.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "113")
                            B113.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "114")
                            B114.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "115")
                            B115.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "116")
                            B116.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "117")
                            B117.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "118")
                            B118.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "119")
                            B119.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "120")
                            B120.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "121")
                            B121.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "122")
                            B122.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "123")
                            B123.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "124")
                            B124.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "125")
                            B125.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "126")
                            B126.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "127")
                            B127.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "128")
                            B128.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "129")
                            B129.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "130")
                            B130.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "131")
                            B131.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "132")
                            B132.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "133")
                            B133.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "134")
                            B134.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "135")
                            B135.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "136")
                            B136.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "137")
                            B137.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "138")
                            B138.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "139")
                            B139.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "140")
                            B140.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "141")
                            B141.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "142")
                            B142.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "143")
                            B143.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "144")
                            B144.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "145")
                            B145.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "146")
                            B146.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "147")
                            B147.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "148")
                            B148.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "149")
                            B149.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "150")
                            B150.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "151")
                            B151.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "152")
                            B152.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "153")
                            B153.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "154")
                            B154.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "155")
                            B155.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "156")
                            B156.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "157")
                            B157.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "158")
                            B158.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "159")
                            B159.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "160")
                            B160.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "161")
                            B161.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "162")
                            B162.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "163")
                            B163.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "164")
                            B164.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "165")
                            B165.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "166")
                            B166.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "167")
                            B167.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "168")
                            B168.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "169")
                            B169.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "170")
                            B170.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "171")
                            B171.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "172")
                            B172.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "173")
                            B173.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "174")
                            B174.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "175")
                            B175.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "176")
                            B176.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "177")
                            B177.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "178")
                            B178.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "179")
                            B179.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "180")
                            B180.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "181")
                            B181.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "182")
                            B182.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "183")
                            B183.BackColor = Color.Red;

                    }
                    if (ds1.Tables[0].Rows[i][0].ToString() == "F")
                    {

                        if (ds1.Tables[0].Rows[i][1].ToString() == "1")
                            FP1.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "2")
                            FP2.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "3")
                            FP3.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "4")
                            FP4.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "5")
                            FP5.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "6")
                            FP6.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "7")
                            FP7.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "8")
                            FP8.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "9")
                            FP9.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "10")
                            FP10.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "11")
                            FP11.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "12")
                            FP12.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "13")
                            FP13.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "14")
                            FP14.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "15")
                            FP15.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "16")
                            FP16.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "17")
                            FP17.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "18")
                            FP18.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "19")
                            FP19.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "20")
                            FP20.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "21")
                            FP21.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "22")
                            FP22.BackColor = Color.Red;
                        /*if (ds1.Tables[0].Rows[i][1].ToString() == "23")
                            FP23.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "24")
                            FP24.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "25")
                            FP25.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "26")
                            FP26.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "27")
                            FP27.BackColor = Color.Red;*/
                        if (ds1.Tables[0].Rows[i][1].ToString() == "28")
                            FP28.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "29")
                            FP29.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "30")
                            FP30.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "31")
                            FP31.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "32")
                            FP32.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "33")
                            FP33.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "34")
                            FP34.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "35")
                            FP35.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "36")
                            FP36.BackColor = Color.Red;

                    }
                    if (ds1.Tables[0].Rows[i][0].ToString() == "E")
                    {
                        if (ds1.Tables[0].Rows[i][1].ToString() == "1")
                            E1.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "2")
                            E2.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "3")
                            E3.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "4")
                            E4.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "5")
                            E5.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "6")
                            E6.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "7")
                            E7.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "8")
                            E8.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "9")
                            E9.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "10")
                            E10.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "11")
                            E11.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "12")
                            E12.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "13")
                            E13.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "14")
                            E14.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "15")
                            E15.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "16")
                            E16.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "17")
                            E17.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "18")
                            E18.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "19")
                            E19.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "20")
                            E20.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "21")
                            E21.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "22")
                            E22.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "23")
                            E23.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "24")
                            E24.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "25")
                            E25.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "26")
                            E26.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "27")
                            E27.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "28")
                            E28.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "29")
                            E29.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "30")
                            E30.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "31")
                            E31.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "32")
                            E32.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "33")
                            E33.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "34")
                            E34.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "35")
                            E35.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "36")
                            E36.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "37")
                            E37.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "38")
                            E38.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "39")
                            E39.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "40")
                            E40.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "41")
                            E41.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "42")
                            E42.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "43")
                            E43.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "44")
                            E44.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "45")
                            E45.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "46")
                            E46.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "47")
                            E47.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "48")
                            E48.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "49")
                            E49.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "50")
                            E50.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "51")
                            E51.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "52")
                            E52.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "53")
                            E53.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "54")
                            E54.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "55")
                            E55.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "56")
                            E56.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "57")
                            E57.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "58")
                            E58.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "59")
                            E59.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "60")
                            E60.BackColor = Color.Red;

                        if (ds1.Tables[0].Rows[i][1].ToString() == "61")
                            E61.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "62")
                            E62.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "63")
                            E63.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "64")
                            E64.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "65")
                            E65.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "66")
                            E66.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "67")
                            E67.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "68")
                            E68.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "69")
                            E69.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "70")
                            E70.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "71")
                            E71.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "72")
                            E72.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "73")
                            E73.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "74")
                            E74.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "75")
                            E75.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "76")
                            E76.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "77")
                            E77.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "78")
                            E78.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "79")
                            E79.BackColor = Color.Red;
                        if (ds1.Tables[0].Rows[i][1].ToString() == "80")
                            E80.BackColor = Color.Red;
						if (ds1.Tables[0].Rows[i][1].ToString() == "81")
                            E81.BackColor = Color.Red;
                    }

                }
            }
			
 if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (ds2.Tables[0].Rows[i][0].ToString() == "A")
                    {

                        if (ds2.Tables[0].Rows[i][1].ToString() == "1")
                            A11.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "2")
                            A2.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "3")
                            A3.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "4")
                            A4.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "5")
                            A5.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "6")
                            A6.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "7")
                            A7.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "8")
                            A8.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "9")
                            A9.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "10")
                            A10.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "11")
                            A111.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "12")
                            A12.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "13")
                            A13.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "14")
                            A14.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "15")
                            A15.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "16")
                            A16.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "17")
                            A17.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "18")
                            A18.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "19")
                            A19.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "20")
                            A20.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "21")
                            A21.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "22")
                            A22.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "23")
                            A23.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "24")
                            A24.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "25")
                            A25.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "26")
                            A26.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "27")
                            A27.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "28")
                            A28.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "29")
                            A29.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "30")
                            A30.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "31")
                            A31.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "32")
                            A32.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "33")
                            A33.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "34")
                            A34.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "35")
                            A35.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "36")
                            A36.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "37")
                            A37.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "38")
                            A38.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "39")
                            A39.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "40")
                            A40.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "41")
                            A41.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "42")
                            A42.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "43")
                            A43.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "44")
                            A44.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "45")
                            A45.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "46")
                            A46.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "47")
                            A47.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "48")
                            A48.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "49")
                            A49.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "50")
                            A50.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "51")
                            A51.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "52")
                            A52.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "53")
                            A53.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "54")
                            A54.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "55")
                            A55.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "56")
                            A56.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "57")
                            A57.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "58")
                            A58.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "59")
                            A59.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "60")
                            A60.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "61")
                            A61.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "62")
                            A62.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "63")
                            A63.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "64")
                            A64.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "65")
                            A65.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "66")
                            A66.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "67")
                            A67.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "68")
                            A68.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "69")
                            A69.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "70")
                            A70.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "71")
                            A71.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "72")
                            A72.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "73")
                            A73.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "74")
                            A74.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "75")
                            A75.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "76")
                            A76.BackImageUrl = "blue.gif";
						
							/*if (ds2.Tables[0].Rows[i][1].ToString() == "77")
                                 A77.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "78")
                                 A78.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "79")
                                 A79.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "80")
                                 A80.BackImageUrl = "blue.gif";*/
							if (ds2.Tables[0].Rows[i][1].ToString() == "81")
                                 A81.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "82")
                                 A82.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "83")
                                 A83.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "84")
                                 A84.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "85")
                                 A85.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "86")
                                 A86.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "87")
                                 A87.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "88")
                                 A88.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "89")
                                 A89.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "90")
                                 A90.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "91")
                                 A91.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "92")
                                 A92.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "93")
                                 A93.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "94")
                                 A94.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "95")
                                 A95.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "96")
                                 A96.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "97")
                                 A97.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "98")
                                 A98.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "99")
                                 A99.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "100")
                                 A100.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "101")
                                 A101.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "102")
                                 A102.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "103")
                                 A103.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "104")
                                 A104.BackImageUrl = "blue.gif";
												if (ds2.Tables[0].Rows[i][1].ToString() == "105")
                                 A105.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "106")
                                 A106.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "107")
                                 A107.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "108")
                                 A108.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "109")
                                 A109.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "110")
                                 A110.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "111")
                                 A1111.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "112")
                                 A112.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "113")
                                 A113.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "114")
                                 A114.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "115")
                                 A115.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "116")
                                 A116.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "117")
                                 A117.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "118")
                                 A118.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "119")
                                 A119.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "120")
                                 A120.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "121")
                                 A121.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "122")
                                 A122.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "123")
                                 A123.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "124")
                                 A124.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "125")
                                 A125.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "126")
                                 A126.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "127")
                                 A127.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "128")
                                 A128.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "129")
                                 A129.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "130")
                                 A130.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "131")
                                 A131.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "132")
                                 A132.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "133")
                                 A133.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "134")
                                 A134.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "135")
                                 A135.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "136")
                                 A136.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "137")
                                 A137.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "138")
                                 A138.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "139")
                                 A139.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "140")
                                 A140.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "141")
                                 A141.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "142")
                                 A142.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "143")
                                 A143.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "144")
                                 A144.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "145")
                                 A145.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "146")
                                 A146.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "147")
                                 A147.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "148")
                                 A148.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "149")
                                 A149.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "150")
                                 A150.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "151")
                                 A151.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "152")
                                 A152.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "153")
                                 A153.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "154")
                                 A154.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "155")
                                 A155.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "156")
                                 A156.BackImageUrl = "blue.gif";

                    }

                    if (ds2.Tables[0].Rows[i][0].ToString() == "C")
                    {
                        if (ds2.Tables[0].Rows[i][1].ToString() == "1")
                            C1.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "2")
                            C2.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "3")
                            C3.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "4")
                            C4.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "5")
                            C5.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "6")
                            C6.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "7")
                            C7.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "8")
                            C8.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "9")
                            C9.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "10")
                            C10.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "11")
                            C11.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "12")
                            C12.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "13")
                            C13.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "14")
                            C14.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "15")
                            C15.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "16")
                            C16.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "17")
                            C17.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "18")
                            C18.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "19")
                            C19.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "20")
                            C20.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "21")
                            C21.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "22")
                            C22.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "23")
                            C23.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "24")
                            C244.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "25")
                            C25.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "26")
                            C26.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "27")
                            C27.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "28")
                            C28.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "29")
                            C29.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "30")
                            C30.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "31")
                            C31.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "32")
                            C32.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "33")
                            C33.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "34")
                            C34.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "35")
                            C35.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "36")
                            C36.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "37")
                            C37.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "38")
                            C38.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "39")
                            C39.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "40")
                            C40.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "41")
                            C41.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "42")
                            C42.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "43")
                            C43.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "44")
                            C44.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "45")
                            C45.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "46")
                            C46.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "47")
                            C47.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "48")
                            C48.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "49")
                            C49.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "50")
                            C50.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "51")
                            C51.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "52")
                            C52.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "53")
                            C53.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "54")
                            C54.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "55")
                            C55.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "56")
                            C56.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "57")
                            C57.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "58")
                            C58.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "59")
                            C59.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "60")
                            C60.BackImageUrl = "blue.gif";
							 	
							if (ds2.Tables[0].Rows[i][1].ToString() == "61")
                                C61.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "62")
                                C62.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "63")
                                C63.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "64")
                                C64.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "65")
                                C65.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "66")
                                C66.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "67")
                                C67.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "68")
                                C68.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "69")
                                C69.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "70")
                                C70.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "71")
                                C71.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "72")
                                C72.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "73")
                                C73.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "74")
                                C74.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "75")
                                C75.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "76")
                                C76.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "77")
                                C77.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "78")
                                C78.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "79")
                                C79.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "80")
                                C80.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "81")
                                C81.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "82")
                                C82.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "83")
                                C83.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "84")
                                C84.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "85")
                                C85.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "86")
                                C86.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "87")
                                C87.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "88")
                                C88.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "89")
                                C89.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "90")
                                C90.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "91")
                                C91.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "92")
                                C92.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "93")
                                C93.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "94")
                                C94.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "95")
                                C95.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "96")
                                C96.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "97")
                                C97.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "98")
                                C98.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "99")
                                C99.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "100")
                                C100.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "101")
                                C101.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "102")
                                C102.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "103")
                                C103.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "104")
                                C104.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "105")
                                C105.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "106")
                                C106.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "107")
                                C107.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "108")
                                C108.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "109")
                                C109.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "110")
                                C110.BackImageUrl = "blue.gif";
						if (ds2.Tables[0].Rows[i][1].ToString() == "111")
                                C111.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "112")
                                C112.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "113")
                                C113.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "114")
                                C114.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "115")
                                C115.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "116")
                                C116.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "117")
                                C117.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "118")
                                C118.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "119")
                                C119.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "120")
                                C120.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "121")
                                C121.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "122")
                                C122.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "123")
                                C123.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "124")
                                C124.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "125")
                                C125.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "126")
                                C126.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "127")
                                C127.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "128")
                                C128.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "129")
                                C129.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "130")
                                C130.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "131")
                                C131.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "132")
                                C132.BackImageUrl = "blue.gif";
							if (ds2.Tables[0].Rows[i][1].ToString() == "133")
                                C133.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "134")
                                C134.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "135")
                                C135.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "136")
                                C136.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "137")
                                C137.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "138")
                                C138.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "139")
                                C139.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "140")
                                C140.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "141")
                                C141.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "142")
                                C142.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "143")
                                C143.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "144")
                                C144.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "145")
                                C145.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "146")
                                C146.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "147")
                                C147.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "148")
                                C148.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "149")
                                C149.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "150")
                                C150.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "151")
                                C151.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "152")
                                C152.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "153")
                                C153.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "154")
                                C154.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "155")
                                C155.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "156")
                                C156.BackImageUrl = "blue.gif";
                            if (ds2.Tables[0].Rows[i][1].ToString() == "157")
                                C157.BackImageUrl = "blue.gif";
                    }

                    if (ds2.Tables[0].Rows[i][0].ToString() == "B")
                    {

                        if (ds2.Tables[0].Rows[i][1].ToString() == "1")
                            B1.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "2")
                            B2.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "3")
                            B3.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "4")
                            B4.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "5")
                            B5.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "6")
                            B6.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "7")
                            B7.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "8")
                            B8.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "9")
                            B9.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "10")
                            B10.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "11")
                            B11.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "12")
                            B12.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "13")
                            B13.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "14")
                            B14.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "15")
                            B15.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "16")
                            B16.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "17")
                            B17.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "18")
                            B18.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "19")
                            B19.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "20")
                            B20.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "21")
                            B21.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "22")
                            B22.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "23")
                            B23.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "24")
                            B24.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "25")
                            B25.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "26")
                            B26.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "27")
                            B27.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "28")
                            B28.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "29")
                            B29.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "30")
                            B30.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "31")
                            B31.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "32")
                            B32.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "33")
                            B33.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "34")
                            B34.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "35")
                            B35.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "36")
                            B36.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "37")
                            B37.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "38")
                            B38.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "39")
                            B39.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "40")
                            B40.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "41")
                            B41.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "42")
                            B42.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "43")
                            B43.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "44")
                            B44.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "45")
                            B45.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "46")
                            B46.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "47")
                            B47.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "48")
                            B48.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "49")
                            B49.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "50")
                            B50.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "51")
                            B51.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "52")
                            B52.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "53")
                            B53.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "54")
                            B54.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "55")
                            B55.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "56")
                            B56.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "57")
                            B57.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "58")
                            B58.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "59")
                            B59.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "60")
                            B60.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "61")
                            B61.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "62")
                            B62.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "63")
                            B63.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "64")
                            B64.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "65")
                            B65.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "66")
                            B66.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "67")
                            B67.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "68")
                            B68.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "69")
                            B69.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "70")
                            B70.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "71")
                            B71.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "72")
                            B72.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "73")
                            B73.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "74")
                            B74.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "75")
                            B75.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "76")
                            B76.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "77")
                            B77.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "78")
                            B78.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "79")
                            B79.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "80")
                            B80.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "81")
                            B81.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "82")
                            B82.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "83")
                            B83.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "84")
                            B84.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "85")
                            B85.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "86")
                            B86.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "87")
                            B87.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "88")
                            B88.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "89")
                            B89.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "90")
                            B90.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "91")
                            B91.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "92")
                            B92.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "93")
                            B93.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "94")
                            B94.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "95")
                            B95.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "96")
                            B96.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "97")
                            B97.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "98")
                            B98.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "99")
                            B99.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "100")
                            B100.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "101")
                            B101.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "102")
                            B102.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "103")
                            B103.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "104")
                            B104.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "105")
                            B105.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "106")
                            B106.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "107")
                            B107.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "108")
                            B108.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "109")
                            B109.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "110")
                            B110.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "111")
                            B111.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "112")
                            B112.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "113")
                            B113.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "114")
                            B114.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "115")
                            B115.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "116")
                            B116.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "117")
                            B117.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "118")
                            B118.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "119")
                            B119.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "120")
                            B120.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "121")
                            B121.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "122")
                            B122.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "123")
                            B123.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "124")
                            B124.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "125")
                            B125.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "126")
                            B126.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "127")
                            B127.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "128")
                            B128.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "129")
                            B129.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "130")
                            B130.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "131")
                            B131.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "132")
                            B132.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "133")
                            B133.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "134")
                            B134.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "135")
                            B135.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "136")
                            B136.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "137")
                            B137.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "138")
                            B138.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "139")
                            B139.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "140")
                            B140.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "141")
                            B141.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "142")
                            B142.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "143")
                            B143.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "144")
                            B144.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "145")
                            B145.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "146")
                            B146.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "147")
                            B147.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "148")
                            B148.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "149")
                            B149.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "150")
                            B150.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "151")
                            B151.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "152")
                            B152.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "153")
                            B153.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "154")
                            B154.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "155")
                            B155.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "156")
                            B156.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "157")
                            B157.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "158")
                            B158.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "159")
                            B159.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "160")
                            B160.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "161")
                            B161.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "162")
                            B162.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "163")
                            B163.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "164")
                            B164.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "165")
                            B165.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "166")
                            B166.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "167")
                            B167.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "168")
                            B168.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "169")
                            B169.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "170")
                            B170.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "171")
                            B171.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "172")
                            B172.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "173")
                            B173.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "174")
                            B174.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "175")
                            B175.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "176")
                            B176.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "177")
                            B177.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "178")
                            B178.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "179")
                            B179.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "180")
                            B180.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "181")
                            B181.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "182")
                            B182.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "183")
                            B183.BackImageUrl = "blue.gif";

                    }
                    if (ds2.Tables[0].Rows[i][0].ToString() == "F")
                    {

                        if (ds2.Tables[0].Rows[i][1].ToString() == "1")
                            FP1.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "2")
                            FP2.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "3")
                            FP3.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "4")
                            FP4.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "5")
                            FP5.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "6")
                            FP6.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "7")
                            FP7.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "8")
                            FP8.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "9")
                            FP9.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "10")
                            FP10.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "11")
                            FP11.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "12")
                            FP12.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "13")
                            FP13.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "14")
                            FP14.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "15")
                            FP15.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "16")
                            FP16.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "17")
                            FP17.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "18")
                            FP18.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "19")
                            FP19.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "20")
                            FP20.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "21")
                            FP21.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "22")
                            FP22.BackImageUrl = "blue.gif";
                        /*if (ds2.Tables[0].Rows[i][1].ToString() == "23")
                            FP23.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "24")
                            FP24.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "25")
                            FP25.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "26")
                            FP26.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "27")
                            FP27.BackImageUrl = "blue.gif";*/
                        if (ds2.Tables[0].Rows[i][1].ToString() == "28")
                            FP28.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "29")
                            FP29.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "30")
                            FP30.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "31")
                            FP31.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "32")
                            FP32.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "33")
                            FP33.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "34")
                            FP34.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "35")
                            FP35.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "36")
                            FP36.BackImageUrl = "blue.gif";

                    }
                    if (ds2.Tables[0].Rows[i][0].ToString() == "E")
                    {

                        if (ds2.Tables[0].Rows[i][1].ToString() == "1")
                            E1.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "2")
                            E2.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "3")
                            E3.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "4")
                            E4.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "5")
                            E5.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "6")
                            E6.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "7")
                            E7.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "8")
                            E8.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "9")
                            E9.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "10")
                            E10.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "11")
                            E11.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "12")
                            E12.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "13")
                            E13.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "14")
                            E14.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "15")
                            E15.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "16")
                            E16.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "17")
                            E17.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "18")
                            E18.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "19")
                            E19.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "20")
                            E20.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "21")
                            E21.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "22")
                            E22.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "23")
                            E23.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "24")
                            E24.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "25")
                            E25.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "26")
                            E26.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "27")
                            E27.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "28")
                            E28.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "29")
                            E29.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "30")
                            E30.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "31")
                            E31.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "32")
                            E32.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "33")
                            E33.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "34")
                            E34.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "35")
                            E35.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "36")
                            E36.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "37")
                            E37.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "38")
                            E38.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "39")
                            E39.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "40")
                            E40.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "41")
                            E41.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "42")
                            E42.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "43")
                            E43.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "44")
                            E44.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "45")
                            E45.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "46")
                            E46.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "47")
                            E47.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "48")
                            E48.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "49")
                            E49.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "50")
                            E50.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "51")
                            E51.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "52")
                            E52.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "53")
                            E53.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "54")
                            E54.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "55")
                            E55.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "56")
                            E56.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "57")
                            E57.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "58")
                            E58.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "59")
                            E59.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "60")
                            E60.BackImageUrl = "blue.gif";

                        if (ds2.Tables[0].Rows[i][1].ToString() == "61")
                            E61.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "62")
                            E62.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "63")
                            E63.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "64")
                            E64.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "65")
                            E65.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "66")
                            E66.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "67")
                            E67.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "68")
                            E68.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "69")
                            E69.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "70")
                            E70.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "71")
                            E71.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "72")
                            E72.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "73")
                            E73.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "74")
                            E74.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "75")
                            E75.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "76")
                            E76.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "77")
                            E77.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "78")
                            E78.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "79")
                            E79.BackImageUrl = "blue.gif";
                        if (ds2.Tables[0].Rows[i][1].ToString() == "80")
                            E80.BackImageUrl = "blue.gif";
						 if (ds2.Tables[0].Rows[i][1].ToString() == "81")
                            E81.BackImageUrl = "blue.gif";
                    }
                }
            }
			if (ds5.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                {
                    if (ds5.Tables[0].Rows[i][0].ToString() == "A")
                    {

                        if (ds5.Tables[0].Rows[i][1].ToString() == "1")
                            A11.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "2")
                            A2.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "3")
                            A3.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "4")
                            A4.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "5")
                            A5.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "6")
                            A6.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "7")
                            A7.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "8")
                            A8.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "9")
                            A9.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "10")
                            A10.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "11")
                            A111.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "12")
                            A12.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "13")
                            A13.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "14")
                            A14.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "15")
                            A15.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "16")
                            A16.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "17")
                            A17.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "18")
                            A18.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "19")
                            A19.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "20")
                            A20.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "21")
                            A21.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "22")
                            A22.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "23")
                            A23.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "24")
                            A24.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "25")
                            A25.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "26")
                            A26.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "27")
                            A27.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "28")
                            A28.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "29")
                            A29.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "30")
                            A30.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "31")
                            A31.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "32")
                            A32.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "33")
                            A33.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "34")
                            A34.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "35")
                            A35.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "36")
                            A36.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "37")
                            A37.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "38")
                            A38.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "39")
                            A39.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "40")
                            A40.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "41")
                            A41.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "42")
                            A42.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "43")
                            A43.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "44")
                            A44.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "45")
                            A45.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "46")
                            A46.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "47")
                            A47.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "48")
                            A48.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "49")
                            A49.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "50")
                            A50.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "51")
                            A51.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "52")
                            A52.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "53")
                            A53.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "54")
                            A54.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "55")
                            A55.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "56")
                            A56.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "57")
                            A57.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "58")
                            A58.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "59")
                            A59.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "60")
                            A60.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "61")
                            A61.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "62")
                            A62.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "63")
                            A63.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "64")
                            A64.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "65")
                            A65.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "66")
                            A66.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "67")
                            A67.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "68")
                            A68.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "69")
                            A69.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "70")
                            A70.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "71")
                            A71.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "72")
                            A72.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "73")
                            A73.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "74")
                            A74.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "75")
                            A75.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "76")
                            A76.BackImageUrl = "notsale.jpg";
						
							/*if (ds5.Tables[0].Rows[i][1].ToString() == "77")
                                 A77.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "78")
                                 A78.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "79")
                                 A79.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "80")
                                 A80.BackImageUrl = "notsale.jpg";*/
							if (ds5.Tables[0].Rows[i][1].ToString() == "81")
                                 A81.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "82")
                                 A82.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "83")
                                 A83.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "84")
                                 A84.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "85")
                                 A85.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "86")
                                 A86.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "87")
                                 A87.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "88")
                                 A88.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "89")
                                 A89.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "90")
                                 A90.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "91")
                                 A91.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "92")
                                 A92.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "93")
                                 A93.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "94")
                                 A94.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "95")
                                 A95.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "96")
                                 A96.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "97")
                                 A97.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "98")
                                 A98.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "99")
                                 A99.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "100")
                                 A100.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "101")
                                 A101.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "102")
                                 A102.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "103")
                                 A103.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "104")
                                 A104.BackImageUrl = "notsale.jpg";
												if (ds5.Tables[0].Rows[i][1].ToString() == "105")
                                 A105.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "106")
                                 A106.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "107")
                                 A107.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "108")
                                 A108.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "109")
                                 A109.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "110")
                                 A110.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "111")
                                 A1111.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "112")
                                 A112.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "113")
                                 A113.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "114")
                                 A114.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "115")
                                 A115.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "116")
                                 A116.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "117")
                                 A117.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "118")
                                 A118.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "119")
                                 A119.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "120")
                                 A120.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "121")
                                 A121.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "122")
                                 A122.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "123")
                                 A123.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "124")
                                 A124.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "125")
                                 A125.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "126")
                                 A126.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "127")
                                 A127.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "128")
                                 A128.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "129")
                                 A129.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "130")
                                 A130.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "131")
                                 A131.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "132")
                                 A132.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "133")
                                 A133.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "134")
                                 A134.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "135")
                                 A135.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "136")
                                 A136.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "137")
                                 A137.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "138")
                                 A138.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "139")
                                 A139.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "140")
                                 A140.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "141")
                                 A141.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "142")
                                 A142.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "143")
                                 A143.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "144")
                                 A144.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "145")
                                 A145.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "146")
                                 A146.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "147")
                                 A147.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "148")
                                 A148.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "149")
                                 A149.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "150")
                                 A150.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "151")
                                 A151.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "152")
                                 A152.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "153")
                                 A153.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "154")
                                 A154.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "155")
                                 A155.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "156")
                                 A156.BackImageUrl = "notsale.jpg";

                    }

                    if (ds5.Tables[0].Rows[i][0].ToString() == "C")
                    {
                        if (ds5.Tables[0].Rows[i][1].ToString() == "1")
                            C1.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "2")
                            C2.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "3")
                            C3.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "4")
                            C4.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "5")
                            C5.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "6")
                            C6.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "7")
                            C7.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "8")
                            C8.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "9")
                            C9.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "10")
                            C10.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "11")
                            C11.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "12")
                            C12.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "13")
                            C13.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "14")
                            C14.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "15")
                            C15.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "16")
                            C16.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "17")
                            C17.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "18")
                            C18.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "19")
                            C19.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "20")
                            C20.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "21")
                            C21.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "22")
                            C22.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "23")
                            C23.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "24")
                            C244.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "25")
                            C25.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "26")
                            C26.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "27")
                            C27.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "28")
                            C28.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "29")
                            C29.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "30")
                            C30.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "31")
                            C31.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "32")
                            C32.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "33")
                            C33.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "34")
                            C34.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "35")
                            C35.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "36")
                            C36.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "37")
                            C37.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "38")
                            C38.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "39")
                            C39.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "40")
                            C40.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "41")
                            C41.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "42")
                            C42.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "43")
                            C43.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "44")
                            C44.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "45")
                            C45.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "46")
                            C46.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "47")
                            C47.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "48")
                            C48.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "49")
                            C49.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "50")
                            C50.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "51")
                            C51.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "52")
                            C52.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "53")
                            C53.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "54")
                            C54.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "55")
                            C55.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "56")
                            C56.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "57")
                            C57.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "58")
                            C58.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "59")
                            C59.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "60")
                            C60.BackImageUrl = "notsale.jpg";
							 	
							if (ds5.Tables[0].Rows[i][1].ToString() == "61")
                                C61.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "62")
                                C62.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "63")
                                C63.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "64")
                                C64.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "65")
                                C65.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "66")
                                C66.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "67")
                                C67.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "68")
                                C68.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "69")
                                C69.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "70")
                                C70.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "71")
                                C71.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "72")
                                C72.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "73")
                                C73.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "74")
                                C74.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "75")
                                C75.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "76")
                                C76.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "77")
                                C77.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "78")
                                C78.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "79")
                                C79.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "80")
                                C80.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "81")
                                C81.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "82")
                                C82.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "83")
                                C83.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "84")
                                C84.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "85")
                                C85.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "86")
                                C86.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "87")
                                C87.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "88")
                                C88.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "89")
                                C89.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "90")
                                C90.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "91")
                                C91.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "92")
                                C92.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "93")
                                C93.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "94")
                                C94.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "95")
                                C95.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "96")
                                C96.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "97")
                                C97.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "98")
                                C98.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "99")
                                C99.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "100")
                                C100.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "101")
                                C101.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "102")
                                C102.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "103")
                                C103.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "104")
                                C104.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "105")
                                C105.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "106")
                                C106.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "107")
                                C107.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "108")
                                C108.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "109")
                                C109.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "110")
                                C110.BackImageUrl = "notsale.jpg";
						if (ds5.Tables[0].Rows[i][1].ToString() == "111")
                                C111.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "112")
                                C112.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "113")
                                C113.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "114")
                                C114.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "115")
                                C115.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "116")
                                C116.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "117")
                                C117.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "118")
                                C118.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "119")
                                C119.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "120")
                                C120.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "121")
                                C121.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "122")
                                C122.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "123")
                                C123.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "124")
                                C124.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "125")
                                C125.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "126")
                                C126.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "127")
                                C127.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "128")
                                C128.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "129")
                                C129.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "130")
                                C130.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "131")
                                C131.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "132")
                                C132.BackImageUrl = "notsale.jpg";
							if (ds5.Tables[0].Rows[i][1].ToString() == "133")
                                C133.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "134")
                                C134.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "135")
                                C135.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "136")
                                C136.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "137")
                                C137.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "138")
                                C138.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "139")
                                C139.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "140")
                                C140.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "141")
                                C141.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "142")
                                C142.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "143")
                                C143.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "144")
                                C144.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "145")
                                C145.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "146")
                                C146.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "147")
                                C147.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "148")
                                C148.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "149")
                                C149.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "150")
                                C150.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "151")
                                C151.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "152")
                                C152.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "153")
                                C153.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "154")
                                C154.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "155")
                                C155.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "156")
                                C156.BackImageUrl = "notsale.jpg";
                            if (ds5.Tables[0].Rows[i][1].ToString() == "157")
                                C157.BackImageUrl = "notsale.jpg";
                    }

                    if (ds5.Tables[0].Rows[i][0].ToString() == "B")
                    {

                        if (ds5.Tables[0].Rows[i][1].ToString() == "1")
                            B1.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "2")
                            B2.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "3")
                            B3.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "4")
                            B4.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "5")
                            B5.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "6")
                            B6.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "7")
                            B7.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "8")
                            B8.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "9")
                            B9.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "10")
                            B10.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "11")
                            B11.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "12")
                            B12.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "13")
                            B13.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "14")
                            B14.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "15")
                            B15.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "16")
                            B16.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "17")
                            B17.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "18")
                            B18.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "19")
                            B19.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "20")
                            B20.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "21")
                            B21.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "22")
                            B22.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "23")
                            B23.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "24")
                            B24.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "25")
                            B25.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "26")
                            B26.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "27")
                            B27.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "28")
                            B28.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "29")
                            B29.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "30")
                            B30.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "31")
                            B31.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "32")
                            B32.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "33")
                            B33.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "34")
                            B34.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "35")
                            B35.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "36")
                            B36.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "37")
                            B37.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "38")
                            B38.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "39")
                            B39.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "40")
                            B40.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "41")
                            B41.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "42")
                            B42.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "43")
                            B43.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "44")
                            B44.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "45")
                            B45.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "46")
                            B46.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "47")
                            B47.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "48")
                            B48.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "49")
                            B49.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "50")
                            B50.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "51")
                            B51.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "52")
                            B52.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "53")
                            B53.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "54")
                            B54.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "55")
                            B55.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "56")
                            B56.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "57")
                            B57.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "58")
                            B58.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "59")
                            B59.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "60")
                            B60.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "61")
                            B61.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "62")
                            B62.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "63")
                            B63.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "64")
                            B64.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "65")
                            B65.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "66")
                            B66.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "67")
                            B67.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "68")
                            B68.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "69")
                            B69.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "70")
                            B70.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "71")
                            B71.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "72")
                            B72.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "73")
                            B73.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "74")
                            B74.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "75")
                            B75.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "76")
                            B76.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "77")
                            B77.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "78")
                            B78.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "79")
                            B79.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "80")
                            B80.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "81")
                            B81.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "82")
                            B82.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "83")
                            B83.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "84")
                            B84.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "85")
                            B85.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "86")
                            B86.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "87")
                            B87.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "88")
                            B88.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "89")
                            B89.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "90")
                            B90.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "91")
                            B91.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "92")
                            B92.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "93")
                            B93.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "94")
                            B94.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "95")
                            B95.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "96")
                            B96.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "97")
                            B97.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "98")
                            B98.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "99")
                            B99.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "100")
                            B100.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "101")
                            B101.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "102")
                            B102.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "103")
                            B103.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "104")
                            B104.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "105")
                            B105.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "106")
                            B106.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "107")
                            B107.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "108")
                            B108.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "109")
                            B109.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "110")
                            B110.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "111")
                            B111.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "112")
                            B112.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "113")
                            B113.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "114")
                            B114.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "115")
                            B115.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "116")
                            B116.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "117")
                            B117.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "118")
                            B118.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "119")
                            B119.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "120")
                            B120.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "121")
                            B121.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "122")
                            B122.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "123")
                            B123.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "124")
                            B124.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "125")
                            B125.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "126")
                            B126.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "127")
                            B127.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "128")
                            B128.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "129")
                            B129.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "130")
                            B130.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "131")
                            B131.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "132")
                            B132.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "133")
                            B133.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "134")
                            B134.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "135")
                            B135.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "136")
                            B136.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "137")
                            B137.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "138")
                            B138.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "139")
                            B139.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "140")
                            B140.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "141")
                            B141.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "142")
                            B142.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "143")
                            B143.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "144")
                            B144.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "145")
                            B145.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "146")
                            B146.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "147")
                            B147.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "148")
                            B148.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "149")
                            B149.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "150")
                            B150.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "151")
                            B151.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "152")
                            B152.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "153")
                            B153.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "154")
                            B154.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "155")
                            B155.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "156")
                            B156.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "157")
                            B157.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "158")
                            B158.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "159")
                            B159.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "160")
                            B160.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "161")
                            B161.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "162")
                            B162.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "163")
                            B163.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "164")
                            B164.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "165")
                            B165.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "166")
                            B166.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "167")
                            B167.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "168")
                            B168.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "169")
                            B169.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "170")
                            B170.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "171")
                            B171.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "172")
                            B172.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "173")
                            B173.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "174")
                            B174.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "175")
                            B175.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "176")
                            B176.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "177")
                            B177.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "178")
                            B178.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "179")
                            B179.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "180")
                            B180.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "181")
                            B181.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "182")
                            B182.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "183")
                            B183.BackImageUrl = "notsale.jpg";

                    }
                    if (ds5.Tables[0].Rows[i][0].ToString() == "F")
                    {

                        if (ds5.Tables[0].Rows[i][1].ToString() == "1")
                            FP1.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "2")
                            FP2.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "3")
                            FP3.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "4")
                            FP4.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "5")
                            FP5.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "6")
                            FP6.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "7")
                            FP7.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "8")
                            FP8.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "9")
                            FP9.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "10")
                            FP10.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "11")
                            FP11.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "12")
                            FP12.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "13")
                            FP13.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "14")
                            FP14.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "15")
                            FP15.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "16")
                            FP16.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "17")
                            FP17.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "18")
                            FP18.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "19")
                            FP19.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "20")
                            FP20.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "21")
                            FP21.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "22")
                            FP22.BackImageUrl = "notsale.jpg";
                       /* if (ds5.Tables[0].Rows[i][1].ToString() == "23")
                            FP23.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "24")
                            FP24.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "25")
                            FP25.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "26")
                            FP26.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "27")
                            FP27.BackImageUrl = "notsale.jpg";*/
                        if (ds5.Tables[0].Rows[i][1].ToString() == "28")
                            FP28.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "29")
                            FP29.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "30")
                            FP30.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "31")
                            FP31.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "32")
                            FP32.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "33")
                            FP33.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "34")
                            FP34.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "35")
                            FP35.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "36")
                            FP36.BackImageUrl = "notsale.jpg";

                    }
                    if (ds5.Tables[0].Rows[i][0].ToString() == "E")
                    {

                        if (ds5.Tables[0].Rows[i][1].ToString() == "1")
                            E1.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "2")
                            E2.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "3")
                            E3.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "4")
                            E4.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "5")
                            E5.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "6")
                            E6.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "7")
                            E7.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "8")
                            E8.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "9")
                            E9.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "10")
                            E10.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "11")
                            E11.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "12")
                            E12.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "13")
                            E13.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "14")
                            E14.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "15")
                            E15.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "16")
                            E16.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "17")
                            E17.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "18")
                            E18.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "19")
                            E19.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "20")
                            E20.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "21")
                            E21.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "22")
                            E22.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "23")
                            E23.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "24")
                            E24.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "25")
                            E25.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "26")
                            E26.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "27")
                            E27.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "28")
                            E28.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "29")
                            E29.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "30")
                            E30.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "31")
                            E31.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "32")
                            E32.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "33")
                            E33.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "34")
                            E34.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "35")
                            E35.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "36")
                            E36.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "37")
                            E37.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "38")
                            E38.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "39")
                            E39.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "40")
                            E40.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "41")
                            E41.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "42")
                            E42.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "43")
                            E43.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "44")
                            E44.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "45")
                            E45.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "46")
                            E46.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "47")
                            E47.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "48")
                            E48.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "49")
                            E49.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "50")
                            E50.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "51")
                            E51.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "52")
                            E52.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "53")
                            E53.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "54")
                            E54.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "55")
                            E55.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "56")
                            E56.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "57")
                            E57.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "58")
                            E58.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "59")
                            E59.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "60")
                            E60.BackImageUrl = "notsale.jpg";

                        if (ds5.Tables[0].Rows[i][1].ToString() == "61")
                            E61.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "62")
                            E62.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "63")
                            E63.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "64")
                            E64.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "65")
                            E65.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "66")
                            E66.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "67")
                            E67.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "68")
                            E68.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "69")
                            E69.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "70")
                            E70.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "71")
                            E71.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "72")
                            E72.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "73")
                            E73.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "74")
                            E74.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "75")
                            E75.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "76")
                            E76.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "77")
                            E77.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "78")
                            E78.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "79")
                            E79.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "80")
                            E80.BackImageUrl = "notsale.jpg";
						if (ds5.Tables[0].Rows[i][1].ToString() == "81")
                            E81.BackImageUrl = "notsale.jpg";
                    }
                }
            }
        }
        catch (Exception rt)
        {
        }
    }

    
}