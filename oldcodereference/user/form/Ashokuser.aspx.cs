﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Web.Services;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;
using System.Drawing;

public partial class userreciptdetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
         Label2.Text = Session["ID"].ToString(); 
       // Label2.Text = "amar";
        if (!IsPostBack)
        {
           
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Label8.Visible = true;
          
            Label1.Text = "";
            Label3.Text = "";
            string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox2.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string date2 = mm1 + "/" + dd1 + "/" + yy1;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO,SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.INSTNO,r.chequenopay AS 'che',r.AMOUNTR AS 'AMOUNT',r.dppaidamount,r.instamtpaid,r.LATECHARGE,r.chequebounce,r.checkby AS 'CHECKBY',r.usertype AS 'USER',u.APPNO AS 'ARAZI',u.plotno AS 'PLOT',u.PLOTSIZE AS 'SIZE',r.userstatus,r.paidamount,r.deldate,u.date3 from  wjstar1.recipt1 r  LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "')  AND r.usertype='"+Label2.Text+"' ORDER BY r.RECIPT ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select r.CUSTREGNO,SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.INSTNO,r.chequenopay AS 'che',r.AMOUNTR AS 'AMOUNT',r.checkby AS 'CHECKBY',r.usertype AS 'USER',u.APPNO AS 'ARAZI',u.plotno AS 'PLOT',u.PLOTSIZE AS 'SIZE',r.userstatus,r.paidamount,r.deldate,u.date3  from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.deldate BETWEEN '" + date1 + "' AND '" + date2 + "')  AND r.usertype='" + Label2.Text + "' AND r.CUSTREGNO NOT IN(select CUSTREGNO from  wjstar1.recipt1 where r.deldate=r.DATE1)", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter da22 = new SqlDataAdapter("select sum(r.paidamount) from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.deldate BETWEEN '" + date1 + "' AND '" + date2 + "') AND r.usertype='" + Label2.Text + "' AND r.CUSTREGNO NOT IN(select CUSTREGNO from  wjstar1.recipt1 where r.deldate=r.DATE1)", con1);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            con1.Close();
            Double backamount = 0;
            if (ds22.Tables[0].Rows[0][0].ToString() != "")
            {
                backamount = Convert.ToDouble(ds22.Tables[0].Rows[0][0].ToString());
                Label9.Text = backamount.ToString();
            }
            else
            {
                backamount = 0;
                Label9.Text = backamount.ToString();
            }
            con1.Open();
            SqlDataAdapter da223 = new SqlDataAdapter("select sum(r.paidamount) from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "')  AND r.usertype='" + Label2.Text + "' AND r.userstatus='Inactive'", con1);
            DataSet ds223 = new DataSet();
            da223.Fill(ds223);
            con1.Close();
            Double curamount = 0;
            if (ds223.Tables[0].Rows[0][0].ToString() != "")
            {
                curamount = Convert.ToDouble(ds223.Tables[0].Rows[0][0].ToString());
                Label8.Text = curamount.ToString();
            }
            else
            {
                curamount = 0;
                Label8.Text = curamount.ToString();
            }
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("select sum(r.AMOUNTR) AS 'AMOUNT',sum(r.LATECHARGE)+sum(r.chequebounce) AS 'FINE' from  wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where (r.DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "')  AND r.usertype='" + Label2.Text + "'", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();

            Double d4 = 0;
            // Label3.Text = ds2.Tables[0].Rows[0][0].ToString();
            Double d2 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            Double fine = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
            /* if (ds4.Tables[0].Rows[0][0].ToString()!="")
             {
                 d4 = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
             }
             else
             {
                 d4 = 0;
             }*/
            Double d5 = d2 + d4;
            Label3.Text = d5.ToString();
            Label10.Text = fine.ToString();

            GridView1.DataSource = ds;
            GridView1.DataBind();

            GridView2.DataSource = ds2;
            GridView2.DataBind();

            bal();
            /* string ddd6 = DateTime.Now.ToString("MM/dd/yyyy");
             string mm5 = ddd6.Substring(0, 2);
             string dd5 = ddd6.Substring(3, 2);
             string yy5 = ddd6.Substring(6, 4);
             string date7 = mm5 + "/" + dd5 + "/" + yy5;
             if (date7 == date1)
             {
                 cancel0();
             }
             else
             {
                 cancel();
             }*/

        }
        catch (Exception t)
        {
            Label1.Text = "error" + t;
        }

    }

    
    public static int d = 0;
   
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        d = Convert.ToInt32(dd);
    }
   
    public void bal()
    {
        try
        {

            //Label1.Text = "";
            // Label3.Text = "";
            string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox2.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string date2 = mm1 + "/" + dd1 + "/" + yy1;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da = new SqlDataAdapter("select sum(recamount) from userreciveamount where username='" + Label2.Text + "' AND recdate BETWEEN '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();

            Double recamt, total, bal;
            total = Convert.ToDouble(Label3.Text);
            if (ds.Tables[0].Rows[0][0].ToString() == "")
            {
                recamt = 0;
            }
            else
            {
                recamt = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            bal = total - recamt;
           // Label4.Text = bal.ToString();
        }
        catch (Exception t)
        {
            Label1.Text = "error" + t;
        }

    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string f = e.Row.Cells[19].Text;
            e.Row.Cells[2].ForeColor = System.Drawing.Color.Blue;
            e.Row.Cells[4].ForeColor = System.Drawing.Color.Blue;
            e.Row.Cells[8].ForeColor = System.Drawing.Color.Blue;
            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "Inactive")
                {
                    cell.BackColor = Color.Red;
                }


            }
        }
    }

    public Double[] recamtpayment(string reg, Double tdp, Double tins, Double bal)
    {

        Double[] array5 = new Double[6];
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        Double instrecamt = 0, tdpbal = 0, dprecamt = 0, instbal = 0, fixinst = 0, curinst = 0;
        SqlDataAdapter cmd = new SqlDataAdapter("select SUM(dppaidamount) from wjstar1.recipt1 where CUSTREGNO='" + reg + "'", con1);
        DataSet ds = new DataSet();
        cmd.Fill(ds);
       
        con1.Close();
        con1.Open();
        SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(instamtpaid) from wjstar1.recipt1 where CUSTREGNO='" + reg + "'", con1);
        DataSet ds1 = new DataSet();
        cmd1.Fill(ds1);
        con1.Close();
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            dprecamt = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            dprecamt = 0;
        }
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            instrecamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            instrecamt = 0;
        }
        tdpbal = tdp - dprecamt;
        instbal = tins - instrecamt;
        array5[0] = dprecamt;
        array5[1] = tdpbal;
        array5[2] = instrecamt;
        array5[3] = instbal;
        //  Label14.Text = dprecamt.ToString();
        // Label15.Text = tdpbal.ToString();
        // Label17.Text = instrecamt.ToString();
        // Label18.Text = instbal.ToString();
        Double[] inststatus = amountbal(tins, reg, instbal, bal);
        fixinst = inststatus[0];
        curinst = inststatus[1];
        array5[4] = fixinst;
        array5[5] = curinst;
        return array5;


    }
    public Double[] amountbal(Double instbalrec, String reg, Double instbalance, Double bal1)
    {
        Double[] inststatus = new Double[2];
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select DATEDIFF(MONTH,date3,lastdate),date3 from  wjstar1.customerreg1 where CUSTREGNO='" + reg + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        String date3 = "";
        Double mont = 0;
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            mont = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            date3 = ds.Tables[0].Rows[0][1].ToString();
        }
        else
        {
            mont = 0;
        }

        Double paodbalinst = 0;
        paodbalinst = instbalrec / mont;
        inststatus[0] = paodbalinst;
        // Label21.Text = paodbalinst.ToString("N2");
        SqlDataAdapter da1 = new SqlDataAdapter("select DATEDIFF(MONTH,(select TOP 1 DATE1 from wjstar1.recipt1 where CUSTREGNO='" + reg + "'),(select TOP 1 DATE1 from wjstar1.recipt1 where CUSTREGNO='" + reg + "' ORDER BY DATE1 DESC)) ", con);
        con.Open();
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Double bal = 0, rec = 0;
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            bal = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            bal = 0;
        }
        rec = mont - bal;
        Double paodbalinst1 = 0, recpaid = 0;
        recpaid = bal1;
        paodbalinst1 = recpaid / rec;
        inststatus[1] = paodbalinst1;
        // Label22.Text = paodbalinst1.ToString("N2");
        return inststatus;

    }
    public Double[] arazisearch(string arazi, Double custotalpayment, string reg, Double bal)
    {
        Double dp = 0, pl = 0, insbal = 0;
        Double[] amar1 = new Double[8];
        if (arazi == "152" || arazi == "506" || arazi == "519" || arazi == "239" || arazi == "161GHA")
        {
            dp = custotalpayment * 0.50;
            insbal = custotalpayment - dp;
            // Label13.Text = dp.ToString();
            //Label16.Text = insbal.ToString();
            Double[] backlist = recamtpayment(reg, dp, insbal, bal);
            amar1[0] = dp;
            amar1[1] = insbal;
            amar1[2] = backlist[0];
            amar1[3] = backlist[1];
            amar1[4] = backlist[2];
            amar1[5] = backlist[3];
            amar1[6] = backlist[4];
            amar1[7] = backlist[5];




        }
        else
        {
            if (arazi == "375KA" || arazi == "30" || arazi == "174MI")
            {
                dp = custotalpayment * 0.35;
                insbal = custotalpayment - dp;
                //Label13.Text = dp.ToString();
                //Label16.Text = insbal.ToString();
                Double[] backlist = recamtpayment(reg, dp, insbal, bal);
                amar1[0] = dp;
                amar1[1] = insbal;
                amar1[2] = backlist[0];
                amar1[3] = backlist[1];
                amar1[4] = backlist[2];
                amar1[5] = backlist[3];
                amar1[6] = backlist[4];
                amar1[7] = backlist[5];

            }
            else
            {
                if (arazi == "0" || arazi == "100" || arazi == "1204" || arazi == "1412" || arazi == "1414 surpal" || arazi == "1989" || arazi == "2011" || arazi == "24KA" || arazi == "254" || arazi == "274" || arazi == "239A" || arazi == "343" || arazi == "364" || arazi == "369" || arazi == "432" || arazi == "436" || arazi == "1989")
                {
                    dp = custotalpayment * 0.25;
                    insbal = custotalpayment - dp;
                    // Label13.Text = dp.ToString();
                    // Label16.Text = insbal.ToString();
                    Double[] backlist = recamtpayment(reg, dp, insbal, bal);
                    amar1[0] = dp;
                    amar1[1] = insbal;
                    amar1[2] = backlist[0];
                    amar1[3] = backlist[1];
                    amar1[4] = backlist[2];
                    amar1[5] = backlist[3];
                    amar1[6] = backlist[4];
                    amar1[7] = backlist[5];
                }
            }
        }
        return amar1;
    }
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Reference the GridView Row using RowIndex from CommandArgument.
        if (e.CommandName == "Show")
        {
            GridViewRow selectedRow = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            string reg = "", arazi = "";
            reg = selectedRow.Cells[2].Text;
            Double total = 0, bal = 0;
            // Label10.Text = reg;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,APPNO,CONSAMOUNT from  wjstar1.customerreg1 where CUSTREGNO='" + reg + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            arazi = ds.Tables[0].Rows[0][1].ToString();
            //Label12.Text = ds.Tables[0].Rows[0][2].ToString();
            total = Convert.ToDouble(ds.Tables[0].Rows[0][2].ToString());
            Double amt = 0;
            SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO='" + reg + "'", con1);
            DataSet ds1 = new DataSet();
            cmd1.Fill(ds1);
            con1.Close();

            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                amt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                // Label20.Text = amt.ToString();


            }
            else
            {
                amt = 0;
                // Label20.Text = amt.ToString();

            }
            bal = total - amt;
            // Label19.Text = bal.ToString();
            Double[] finallist = arazisearch(ds.Tables[0].Rows[0][1].ToString(), total, reg, bal);

            // popup.Show();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('FIXED EMI :  " + finallist[6] + "     CURRENT EMI :  " + finallist[7] + "\\n\\nCUSTOMER REG.NO. :  " + reg + "      ARAZI NO. : " + arazi + "\\n\\nTOTAL AMT : " + total + "      TOTAL RCV : " + amt + "      TOTAL BAL : " + bal + "\\n\\n TOTAL D.P : " + finallist[0] + "              REC D.P : " + finallist[2] + "                   BAL D.P : " + finallist[3] + "\\n\\n TOTAL EMI : " + finallist[1] + "          REC EMI : " + finallist[4] + "           BAL EMI : " + finallist[5] + "');", true);
        }
        if (e.CommandName == "Details")
        {

            GridViewRow selectedRow = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            string reg = "";
            reg = selectedRow.Cells[2].Text;
            Session["reg"] = reg.ToString();
            Page.ClientScript.RegisterStartupScript(
   this.GetType(), "OpenWindow", "window.open('https://www.heedrealestate.com/home/customerdetails1.aspx','_newtab');", true);


        }
    }


}