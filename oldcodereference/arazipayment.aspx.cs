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


public partial class arazipayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
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
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '"+date1+"' AND '"+date2+"' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='100' )", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        Label1.Text = ds.Tables[0].Rows[0][0].ToString();
        
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1204' )", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1412' )", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Label3.Text = ds2.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1414 surpal' )", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        Label4.Text = ds3.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da4 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='174MI' )", con);
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
        con.Close();
        Label5.Text = ds4.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da5 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='2011' )", con);
        DataSet ds5 = new DataSet();
        da5.Fill(ds5);
        con.Close();
        Label6.Text = ds5.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da6 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='239' )", con);
        DataSet ds6 = new DataSet();
        da6.Fill(ds6);
        con.Close();
        Label7.Text = ds6.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da7 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='254' )", con);
        DataSet ds7 = new DataSet();
        da7.Fill(ds7);
        con.Close();
        Label8.Text = ds7.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da8 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='293A' )", con);
        DataSet ds8 = new DataSet();
        da8.Fill(ds8);
        con.Close();
        Label9.Text = ds8.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da9 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='30' )", con);
        DataSet ds9 = new DataSet();
        da9.Fill(ds9);
        con.Close();
        Label10.Text = ds9.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da10 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='343' )", con);
        DataSet ds10 = new DataSet();
        da10.Fill(ds10);
        con.Close();
        Label11.Text = ds10.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da11 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='375KA' )", con);
        DataSet ds11 = new DataSet();
        da11.Fill(ds11);
        con.Close();
        Label12.Text = ds11.Tables[0].Rows[0][0].ToString();
        con.Open();
        SqlDataAdapter da12 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='432' )", con);
        DataSet ds12 = new DataSet();
        da12.Fill(ds12);
        con.Close();
		 SqlDataAdapter da19 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='436' )", con);
        DataSet ds19 = new DataSet();
        da19.Fill(ds19);
        con.Close();
		Label19.Text = ds19.Tables[0].Rows[0][0].ToString();
        Label13.Text = ds12.Tables[0].Rows[0][0].ToString();
        Double l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13,l19, total = 0,bal=0,rec=0 ;
        if (Label1.Text == "")
            l1 = 0;
        else
            l1 = Convert.ToDouble(Label1.Text);
        if (Label2.Text == "")
            l2 = 0;
        else
            l2 = Convert.ToDouble(Label2.Text);
        if (Label3.Text == "")
            l3 = 0;
        else
            l3 = Convert.ToDouble(Label3.Text);
        if (Label4.Text == "")
            l4 = 0;
        else
            l4 = Convert.ToDouble(Label4.Text);
        if (Label5.Text == "")
            l5 = 0;
        else
            l5 = Convert.ToDouble(Label5.Text);
        if (Label6.Text == "")
            l6 = 0;
        else
            l6 = Convert.ToDouble(Label6.Text);
        if (Label7.Text == "")
            l7 = 0;
        else
            l7 = Convert.ToDouble(Label7.Text);
        if (Label8.Text == "")
            l8 = 0;
        else
            l8 = Convert.ToDouble(Label8.Text);
        if (Label9.Text == "")
            l9 = 0;
        else
            l9 = Convert.ToDouble(Label9.Text);
        if (Label10.Text == "")
            l10 = 0;
        else
            l10 = Convert.ToDouble(Label10.Text);
        if (Label11.Text == "")
            l11 = 0;
        else
            l11 = Convert.ToDouble(Label11.Text);
        if (Label12.Text == "")
            l12 = 0;
        else
            l12 = Convert.ToDouble(Label12.Text);
        if (Label13.Text == "")
            l13 = 0;
        else
            l13 = Convert.ToDouble(Label13.Text);
		if (Label19.Text == "")
            l19 = 0;
        else
            l19 = Convert.ToDouble(Label19.Text);
        total = l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8 + l9 + l10 + l11 + l12 + l13+l19;
        Label14.Text = total.ToString();
        //Label20.Text = total.ToString();
        con.Close();
        SqlDataAdapter da90 = new SqlDataAdapter("select SUM(AMOUNTR) from  wjstar1.recipt1 where  DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' )", con);
        DataSet ds90 = new DataSet();
        da90.Fill(ds90);
        con.Close();
        rec = Convert.ToDouble(ds90.Tables[0].Rows[0][0].ToString());
        Label21.Text = rec.ToString();
        bal = total - rec;
        Label22.Text = bal.ToString();

       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        Double total=0, recamt=0, emiamt=0;
        int i;
        SqlConnection con = new SqlConnection(s);
        int from = Convert.ToInt32(TextBox3.Text);
        int to = Convert.ToInt32(TextBox4.Text);
        int year = Convert.ToInt32(TextBox5.Text);
        Label23.Text = " ";
        Label24.Text = " ";
        Label25.Text = " ";
        Label26.Text = " ";
        Label27.Text = " ";
        Label28.Text = " ";
        Label29.Text = " ";
        Label30.Text = " ";
        Label31.Text = " ";
        Label32.Text = " ";
        Label33.Text = " ";
        Label34.Text = " ";
        Label35.Text = " ";
        Label36.Text = " ";
        Label37.Text = " ";
        Label38.Text = " ";
        Label39.Text = " ";
        Label40.Text = " ";
        Label41.Text = " ";
        Label42.Text = " ";
        Label43.Text = " ";
        Label45.Text = " ";
        Label46.Text = " ";
        Label47.Text = " ";
        Label48.Text = " ";
        Label49.Text = " ";
        Label44.Text = " ";
        Label50.Text = " ";
        Label51.Text = " ";
        Label52.Text = " ";
        Label53.Text = " ";
        Label54.Text = " ";
        Label55.Text = " ";
        Label56.Text = " ";
        Label57.Text = " ";
        Label58.Text = " ";
        for (i=from; i <= to; i++)
        {
             if(i==1) 
             {  
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='"+i+"' AND year(DATE1)='"+year+"'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    total = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    Label23.Text = total.ToString();
                    con.Close();
                     con.Open();
                     SqlDataAdapter da90 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                     DataSet ds90 = new DataSet();
                     da90.Fill(ds90);
                     con.Close();
                     recamt = Convert.ToDouble(ds90.Tables[0].Rows[0][0].ToString());
                     Label24.Text =recamt.ToString();
                     emiamt = total - recamt;
                     Label25.Text = emiamt.ToString();
             }

               
                    if(i==2)
                    {
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    total = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
                    Label26.Text = total.ToString();
                    con.Close();
                    con.Open();
                    SqlDataAdapter da22 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                    DataSet ds22 = new DataSet();
                    da22.Fill(ds22);
                    con.Close();
                    recamt = Convert.ToDouble(ds22.Tables[0].Rows[0][0].ToString());
                    Label27.Text = recamt.ToString();
                    emiamt = total - recamt;
                    Label28.Text = emiamt.ToString();
                    }
                    if (i == 3)
                    {
                        con.Open();
                        SqlDataAdapter da3 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3);
                        total = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                        Label29.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da33 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds33 = new DataSet();
                        da33.Fill(ds33);
                        con.Close();
                        recamt = Convert.ToDouble(ds33.Tables[0].Rows[0][0].ToString());
                        Label30.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label31.Text = emiamt.ToString();
                    }
                    if (i == 4)
                    {
                        con.Open();
                        SqlDataAdapter da4 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds4 = new DataSet();
                        da4.Fill(ds4);
                        total = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
                        Label32.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da44 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds44 = new DataSet();
                        da44.Fill(ds44);
                        con.Close();
                        recamt = Convert.ToDouble(ds44.Tables[0].Rows[0][0].ToString());
                        Label33.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label34.Text = emiamt.ToString();
                    }
                    if (i == 5)
                    {
                        con.Open();
                        SqlDataAdapter da5 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds5 = new DataSet();
                        da5.Fill(ds5);
                        total = Convert.ToDouble(ds5.Tables[0].Rows[0][0].ToString());
                        Label35.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da55 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds55 = new DataSet();
                        da55.Fill(ds55);
                        con.Close();
                        recamt = Convert.ToDouble(ds55.Tables[0].Rows[0][0].ToString());
                        Label36.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label37.Text = emiamt.ToString();
                    }
                    if (i == 6)
                    {
                        con.Open();
                        SqlDataAdapter da6 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds6 = new DataSet();
                        da6.Fill(ds6);
                        total = Convert.ToDouble(ds6.Tables[0].Rows[0][0].ToString());
                        Label38.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da66 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds66 = new DataSet();
                        da66.Fill(ds66);
                        con.Close();
                        recamt = Convert.ToDouble(ds66.Tables[0].Rows[0][0].ToString());
                        Label39.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label40.Text = emiamt.ToString();
                    }
                    if (i == 7)
                    {
                        con.Open();
                        SqlDataAdapter da7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds7 = new DataSet();
                        da7.Fill(ds7);
                        total = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                        Label41.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da77 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds77 = new DataSet();
                        da77.Fill(ds77);
                        con.Close();
                        recamt = Convert.ToDouble(ds77.Tables[0].Rows[0][0].ToString());
                        Label42.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label43.Text = emiamt.ToString();
                    }
                    if (i == 8)
                    {
                        con.Open();
                        SqlDataAdapter da8 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds8 = new DataSet();
                        da8.Fill(ds8);
                        total = Convert.ToDouble(ds8.Tables[0].Rows[0][0].ToString());
                        Label44.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da88 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds88 = new DataSet();
                        da88.Fill(ds88);
                        con.Close();
                        recamt = Convert.ToDouble(ds88.Tables[0].Rows[0][0].ToString());
                        Label45.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label46.Text = emiamt.ToString();
                    }
                    if (i == 9)
                    {
                        con.Open();
                        SqlDataAdapter da9 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds9 = new DataSet();
                        da9.Fill(ds9);
                        total = Convert.ToDouble(ds9.Tables[0].Rows[0][0].ToString());
                        Label47.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da99 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds99 = new DataSet();
                        da99.Fill(ds99);
                        con.Close();
                        recamt = Convert.ToDouble(ds99.Tables[0].Rows[0][0].ToString());
                        Label48.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label49.Text = emiamt.ToString();
                    }
                    if (i == 10)
                    {
                        con.Open();
                        SqlDataAdapter da10 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds10 = new DataSet();
                        da10.Fill(ds10);
                        total = Convert.ToDouble(ds10.Tables[0].Rows[0][0].ToString());
                        Label50.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da100 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds100 = new DataSet();
                        da100.Fill(ds100);
                        con.Close();
                        recamt = Convert.ToDouble(ds100.Tables[0].Rows[0][0].ToString());
                        Label51.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label52.Text = emiamt.ToString();
                    }
                    if (i == 11)
                    {
                        con.Open();
                        SqlDataAdapter da11 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds11 = new DataSet();
                        da11.Fill(ds11);
                        total = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                        Label53.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da111 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds111 = new DataSet();
                        da111.Fill(ds111);
                        con.Close();
                        recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                        Label54.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label55.Text = emiamt.ToString();
                    }
                    if (i == 12)
                    {
                        con.Open();
                        SqlDataAdapter da12 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds12 = new DataSet();
                        da12.Fill(ds12);
                        total = Convert.ToDouble(ds12.Tables[0].Rows[0][0].ToString());
                        Label56.Text = total.ToString();
                        con.Close();
                        con.Open();
                        SqlDataAdapter da112 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds112 = new DataSet();
                        da112.Fill(ds112);
                        con.Close();
                        recamt = Convert.ToDouble(ds112.Tables[0].Rows[0][0].ToString());
                        Label57.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label58.Text = emiamt.ToString();
                    }
                   
            
        }
    }
}