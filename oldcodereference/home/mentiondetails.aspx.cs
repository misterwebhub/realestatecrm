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
public partial class arazi187kha_mentiondetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public static double final = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Populate();
        }
    }

    public void Populate()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("SELECT sum(CAMOUNT)  FROM chequedetails where STATUS='UNPAID' AND CHEQUETYPE='MENTION' AND ID NOT IN(SELECT ID from chequedetails where CHEQUETYPE='MENTION' AND STATUS='UNPAID' AND BSTATUS='BOUNCE')", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        con1.Open();
        DateTime dt = DateTime.Now;
        SqlDataAdapter da11 = new SqlDataAdapter("SELECT sum(CAMOUNT)  FROM chequedetails where STATUS='PAID' AND CHEQUETYPE='MENTION' AND month(paiddate)='" + dt.Month + "' AND year(paiddate)='" + dt.Year + "' ", con1);
        DataSet ds11 = new DataSet();
        da11.Fill(ds11);
        con1.Close();
        con1.Open();

        SqlDataAdapter da22 = new SqlDataAdapter("SELECT sum(CAMOUNT)  FROM chequedetails where STATUS='PAID' AND CHEQUETYPE='MENTION' AND paiddate='" + DateTime.Now + "' ", con1);
        DataSet ds22 = new DataSet();
        da22.Fill(ds22);
        con1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {

                string str = ds.Tables[0].Rows[0][0].ToString();
                string le = str.Substring(0, 3);
                Label1.Text = le;
                int sty = str.Length - 3;

                string lef = str.Substring(3, sty);

                //string re=right(str.Length);
                Label4.Text = ", " + lef;
            }
            else
            {
                Label1.Text = "";
            }
        }
        else
        {
            Label1.Text = "";
        }
        if (ds11.Tables[0].Rows.Count > 0)
        {
            if (ds11.Tables[0].Rows[0][0].ToString() != "")
            {

                string str = ds11.Tables[0].Rows[0][0].ToString();

                //string re=right(str.Length);
                Label2.Text = str;
            }
            else
            {
                Label2.Text = "0";
            }
        }
        else
        {
            // Label13.Text="0";
        }
        if (ds22.Tables[0].Rows.Count > 0)
        {
            if (ds22.Tables[0].Rows[0][0].ToString() != "")
            {

                string str = ds22.Tables[0].Rows[0][0].ToString();

                //string re=right(str.Length);
                Label3.Text = str;
            }
            else
            {
                Label3.Text = "0";
            }
        }
        else
        {
            Label3.Text = "0";
        }

    }
}