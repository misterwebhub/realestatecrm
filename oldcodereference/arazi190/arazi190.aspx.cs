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


public partial class _161GHA_arazi190 : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='190' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='190' AND regstatus IN('Registry'))", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select arazi,plotno,status from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='190' AND regstatus IN('completed'))", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(plotno) from arazimap where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='190' AND regstatus IN('completed'))", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            SqlDataAdapter da5 = new SqlDataAdapter("select arazi,plotno,status from arazimap where arazi='190' AND CUSTREGNO IN(select CUSTREGNO from ARAZINOTSALE where ARAZI='190') ", con);

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
                        if (ds.Tables[0].Rows[i][1].ToString() == "217")
                            p217.BackImageUrl = "amar.gif";
                        if (ds.Tables[0].Rows[i][1].ToString() == "218")
                            p218.BackImageUrl = "amar.gif";
						 if (ds.Tables[0].Rows[i][1].ToString() == "219")
                            p219.BackImageUrl = "amar.gif";
                        

                    }
                    if (ds.Tables[0].Rows[i][2].ToString() == "book")
                    {
                        if (ds.Tables[0].Rows[i][1].ToString() == "217")
                            p217.BackColor = Color.Green;
                        if (ds.Tables[0].Rows[i][1].ToString() == "218")
                            p218.BackColor = Color.Green;
						if (ds.Tables[0].Rows[i][1].ToString() == "219")
                            p219.BackColor = Color.Green;
                       
                    }
                }
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (ds1.Tables[0].Rows[i][1].ToString() == "217")
                        p217.BackColor = Color.Red;
                    if (ds1.Tables[0].Rows[i][1].ToString() == "218")
                        p218.BackColor = Color.Red;
					 if (ds1.Tables[0].Rows[i][1].ToString() == "219")
                        p219.BackColor = Color.Red;
                   
                }

            }
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (ds2.Tables[0].Rows[i][1].ToString() == "217")
                        p217.BackImageUrl = "blue.gif";
                    if (ds2.Tables[0].Rows[i][1].ToString() == "218")
                        p218.BackImageUrl = "blue.gif";
					 if (ds2.Tables[0].Rows[i][1].ToString() == "219")
                        p219.BackImageUrl = "blue.gif";
                   
                }
                if (ds5.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                    {
                        if (ds5.Tables[0].Rows[i][1].ToString() == "217")
                            p217.BackImageUrl = "notsale.jpg";
                        if (ds5.Tables[0].Rows[i][1].ToString() == "218")
                            p218.BackImageUrl = "notsale.jpg";
						 if (ds5.Tables[0].Rows[i][1].ToString() == "219")
                            p219.BackImageUrl = "notsale.jpg";
                        
                    }
                }
            }
        }
        catch (Exception r)
        {

        }
    }
}