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

public partial class kishan_partnerpaidbal : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Double t1=0,t2=0,total = 0, recamt = 0, emiamt = 0;
        int i;
        SqlConnection con1 = new SqlConnection(s);
        int from = Convert.ToInt32(TextBox1.Text);
        int to = Convert.ToInt32(TextBox2.Text);
        int year = Convert.ToInt32(TextBox3.Text);
        for (i = from; i <= to; i++)
        {
            if (i == 1)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
               total= (t1 + t2)*0.10;
               if (total != 0)
                   Label1.Text = total.ToString();
               else
               {
                   total = 0;
                   Label1.Text = total.ToString() ;
               }
                    
                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label2.Text =recamt.ToString();
                emiamt = total - recamt;
                Label3.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 2)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label4.Text = total.ToString();
                else
                {
                    total = 0;
                    Label4.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label5.Text = recamt.ToString();
                emiamt = total - recamt;
                Label6.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 3)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label7.Text = total.ToString();
                else
                {
                    total = 0;
                    Label7.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label8.Text = recamt.ToString();
                emiamt = total - recamt;
                Label9.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 4)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label10.Text = total.ToString();
                else
                {
                    total = 0;
                    Label10.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label11.Text = recamt.ToString();
                emiamt = total - recamt;
                Label12.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 5)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label13.Text = total.ToString();
                else
                {
                    total = 0;
                    Label13.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label14.Text = recamt.ToString();
                emiamt = total - recamt;
                Label15.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 6)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label16.Text = total.ToString();
                else
                {
                    total = 0;
                    Label16.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label17.Text = recamt.ToString();
                emiamt = total - recamt;
                Label18.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 7)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label19.Text = total.ToString();
                else
                {
                    total = 0;
                    Label19.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label20.Text = recamt.ToString();
                emiamt = total - recamt;
                Label21.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 8)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label22.Text = total.ToString();
                else
                {
                    total = 0;
                    Label22.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label23.Text = recamt.ToString();
                emiamt = total - recamt;
                Label24.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 9)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label25.Text = total.ToString();
                else
                {
                    total = 0;
                    Label25.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label26.Text = recamt.ToString();
                emiamt = total - recamt;
                Label27.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 10)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label28.Text = total.ToString();
                else
                {
                    total = 0;
                    Label28.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label29.Text = recamt.ToString();
                emiamt = total - recamt;
                Label30.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 11)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label31.Text = total.ToString();
                else
                {
                    total = 0;
                    Label31.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label32.Text = recamt.ToString();
                emiamt = total - recamt;
                Label33.Text = emiamt.ToString();
                con1.Close();

            }
            if (i == 12)
            {
                t1 = 0; t2 = 0; total = 0; recamt = 0; emiamt = 0;
                con1.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    t1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t1 = 0;
                }
                con1.Close();
                con1.Open();

                SqlDataAdapter cmd11 = new SqlDataAdapter("select SUM(AMOUNTR-AMOUNTR*0.10) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY NOT IN ('office','Satya prakas tiwari')) AND month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con1);
                DataSet ds11 = new DataSet();
                cmd11.Fill(ds11);
                if (ds11.Tables[0].Rows[0][0].ToString() != "")
                {
                    t2 = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    t2 = 0;
                }
                total = (t1 + t2) * 0.10;
                if (total != 0)
                    Label34.Text = total.ToString();
                else
                {
                    total = 0;
                    Label34.Text = total.ToString();
                }

                con1.Close();
                con1.Open();
                SqlDataAdapter cmd111 = new SqlDataAdapter("select SUM(amount)  from wjstar1.partnerpaid where month(datefrom)='" + i + "' AND year(datefrom)='" + year + "'", con1);
                DataSet ds111 = new DataSet();
                cmd111.Fill(ds111);
                if (ds111.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label35.Text = recamt.ToString();
                emiamt = total - recamt;
                Label36.Text = emiamt.ToString();
                con1.Close();

            }

        }
    }
}