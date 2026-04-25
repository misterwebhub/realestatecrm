﻿using System;
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

public partial class kishanarazipayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            invester();
            DropDownList1.Items.Clear();
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            con.Close();
            Panel1.Visible = false;
            Panel2.Visible = false;
            Clear1();
        }
    }
    public void invester()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select SUM(totalinvestamt),SUM(returnamt) from newinvester", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Label378.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label378.Text = "0";
            }
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                Label379.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                Label379.Text = "0";
            }
        }
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select SUM(amount) from investerrecipt where type='RECEIVE' AND status='PAID'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label381.Text = ds1.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label381.Text = "0";
            }
            
        }
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select SUM(amount) from investerrecipt where type='RETURN' AND status='PAID'", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        if (ds2.Tables[0].Rows.Count > 0)
        {
            if (ds2.Tables[0].Rows[0][0].ToString() != "")
            {
                Label380.Text = ds2.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label380.Text = "0";
            }
            
        }
    }
    public void Clear1()
    {
        Label2.Text = ""; Label3.Text = ""; Label4.Text = ""; Label5.Text = ""; Label6.Text = ""; Label7.Text = ""; Label8.Text = ""; Label9.Text = ""; Label10.Text = ""; Label11.Text = ""; Label12.Text = ""; Label13.Text = ""; Label14.Text = ""; Label15.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        if (DropDownList1.Text != "186MI")
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label3.Text = ds1.Tables[0].Rows[0][0].ToString();
                    Label4.Text = ds1.Tables[0].Rows[0][1].ToString();
                    Label5.Text = ds1.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    Label3.Text = "0";
                    Label4.Text = "0";
                    Label5.Text = "0";
                }
            }
            else
            {
                Label3.Text = "0";
                Label4.Text = "0";
                Label5.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='" + DropDownList1.Text + "' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label2.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label6.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Label7.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Label8.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label2.Text = "0";
                    Label6.Text = "0";
                    Label7.Text = "0";
                    Label8.Text = "0";
                }
            }
            else
            {
                Label2.Text = "0";
                Label6.Text = "0";
                Label7.Text = "0";
                Label8.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label9.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label10.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Label11.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label9.Text = "0";
                    Label10.Text = "0";
                    Label11.Text = "0";

                }
            }
            else
            {
                Label9.Text = "0";
                Label10.Text = "0";
                Label11.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label12.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label12.Text);
                totalland = Convert.ToDouble(Label10.Text);
                landbal = totalland - saleland;
                Label14.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label10.Text) * Convert.ToDouble(Label11.Text);
                Label16.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label12.Text) * Convert.ToDouble(Label11.Text);
                Label13.Text = saleamt.ToString();
                balamt = totalamt - saleamt;
                Label15.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label3.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label3.Text);
                }
                if (Label12.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label12.Text);
                }

                bal9 = custtotal / soldamt2;
                
                Label382.Text = bal9.ToString("N0");


            }
            else
            {
                Label12.Text = "0";


            }
        }
        else
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='186MI' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label3.Text = ds1.Tables[0].Rows[0][0].ToString();
                    Label4.Text = ds1.Tables[0].Rows[0][1].ToString();
                    Label5.Text = ds1.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    Label3.Text = "0";
                    Label4.Text = "0";
                    Label5.Text = "0";
                }
            }
            else
            {
                Label3.Text = "0";
                Label4.Text = "0";
                Label5.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',sum(k.landamount) AS 'TOTAL',c.PAID AS 'PAID',(sum(k.landamount)-c.PAID)AS 'BAL',sum(k.saleland) from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi group by k.arazi,c.PAID", con);
           // SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='" + DropDownList1.Text + "' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label2.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label6.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Label7.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Label8.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label2.Text = "0";
                    Label6.Text = "0";
                    Label7.Text = "0";
                    Label8.Text = "0";
                }
            }
            else
            {
                Label2.Text = "0";
                Label6.Text = "0";
                Label7.Text = "0";
                Label8.Text = "0";
            }
           
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,salerate from newkishan where id IN(select id from newkishan where arazi='186MI')", con);
            //SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label9.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label10.Text = ds2.Tables[0].Rows[0][4].ToString();
                    Label11.Text = ds3.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    Label9.Text = "0";
                    Label10.Text = "0";
                    Label11.Text = "0";

                }
            }
            else
            {
                Label9.Text = "0";
                Label10.Text = "0";
                Label11.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='186MI' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label12.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label12.Text);
                totalland = Convert.ToDouble(Label10.Text);
                landbal = totalland - saleland;
                Label14.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label10.Text) * Convert.ToDouble(Label11.Text);
                Label16.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label12.Text) * Convert.ToDouble(Label11.Text);
                Label13.Text = saleamt.ToString();
                balamt = totalamt - saleamt;
                Label15.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label3.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label3.Text);
                }
                if (Label12.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label12.Text);
                }

                bal9 = custtotal / soldamt2;
                Label382.Text = bal9.ToString("N0");


            }
            else
            {
                Label12.Text = "0";
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label12.Text);
                totalland = Convert.ToDouble(Label10.Text);
                landbal = totalland - saleland;
                Label14.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label10.Text) * Convert.ToDouble(Label11.Text);
                Label16.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label12.Text) * Convert.ToDouble(Label11.Text);
                Label13.Text = saleamt.ToString();
                balamt = totalamt - saleamt;
                Label15.Text = balamt.ToString();

            }
        }
            Label348.Text = "0";
            Label349.Text = "0";
            Label350.Text = "0";
            Label351.Text = "0";
            Label352.Text = "0";
            Label353.Text = "0";
            Label355.Text = "0";
            Label357.Text = "0";
            Label358.Text = "0";
            Label359.Text = "0";
            Label360.Text = "0";
            Label361.Text = "0";
        
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Double custotal = 0,custpaid=0,kishantotal=0,kishanpaid=0,landtotal=0,landsold=0,totallandamt=0,soldamt=0;
        string[] ar = { "1204", "1412", "1414 surpal", "174MI", "2011", "239", "30", "254", "343", "375KA", "432", "436", "RAMAI137", "152", "506", "1989", "161GHA", "2001GA", "513RA", "1418", "372KA", "385KA", "186MI","217","357","187-KHA","320" ,"353","356","419"};
        if (ar[0] =="1204")
        {
           
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='1204' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                
                Label18.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label18.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label18.Text);
                    custotal = custotal + ar1;
                }
                Label19.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label19.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label19.Text);
                    custpaid = custpaid + ar2;
                }
                Label20.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label18.Text = "0";
                Label19.Text = "0";
                Label20.Text = "0";
            }
            con.Open();
            
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='1204' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label17.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label21.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label21.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label21.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label22.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label22.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label22.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label23.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label17.Text = "1204";
                    Label21.Text = "0";
                    Label22.Text = "0";
                    Label23.Text = "0";
                }
            }
            else
            {
                Label17.Text = "1204";
                Label21.Text = "0";
                Label22.Text = "0";
                Label23.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='1204')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label24.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label25.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label25.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label25.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label26.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label24.Text = "0";
                    Label25.Text = "0";
                    Label26.Text = "0";

                }
            }
            else
            {
                Label24.Text = "0";
                Label25.Text = "0";
                Label26.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='1204' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label27.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label27.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label27.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label27.Text);
                totalland = Convert.ToDouble(Label25.Text);
                landbal = totalland - saleland;
                Label28.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label25.Text) * Convert.ToDouble(Label26.Text);
                Label29.Text = totalamt.ToString();
                
                
                saleamt = Convert.ToDouble(Label27.Text) * Convert.ToDouble(Label26.Text);
                Label30.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label29.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label29.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label30.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label30.Text);
                    soldamt= soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label31.Text = balamt.ToString();

                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label18.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label18.Text);
                }
                if (Label27.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label27.Text);
                }

                bal9 = custtotal / soldamt2;
                Label383.Text = bal9.ToString("N0");

            }
            else
            {
                Label27.Text = "0";


            }
        }
        if (ar[1] == "1412")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='1412' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label33.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label33.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label33.Text);
                    custotal = custotal + ar1;
                }
                Label34.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label34.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label34.Text);
                    custpaid = custpaid + ar2;
                }
                Label35.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label33.Text = "0";
                Label34.Text = "0";
                Label35.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='1412' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label32.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label36.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label36.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label36.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label37.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label37.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label37.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label38.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label32.Text = "0";
                    Label36.Text = "0";
                    Label37.Text = "0";
                    Label38.Text = "0";
                }
            }
            else
            {
                Label32.Text = "0";
                Label36.Text = "0";
                Label37.Text = "0";
                Label38.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='1412')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label39.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label40.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label40.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label40.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label41.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label39.Text = "0";
                    Label40.Text = "0";
                    Label41.Text = "0";

                }
            }
            else
            {
                Label39.Text = "0";
                Label40.Text = "0";
                Label41.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='1412' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label42.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label42.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label42.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label42.Text);
                totalland = Convert.ToDouble(Label40.Text);
                landbal = totalland - saleland;
                Label43.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label40.Text) * Convert.ToDouble(Label41.Text);
                Label44.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label42.Text) * Convert.ToDouble(Label41.Text);
                Label45.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label44.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label44.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label45.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label45.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label46.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label33.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label33.Text);
                }
                if (Label42.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label42.Text);
                }

                bal9 = custtotal / soldamt2;
                Label384.Text = bal9.ToString("N0");


            }
            else
            {
                Label42.Text = "0";


            }
        }
        if (ar[2] == "1414 surpal")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='1414 surpal' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label48.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label48.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label48.Text);
                    custotal = custotal + ar1;
                }
                Label49.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label49.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label49.Text);
                    custpaid = custpaid + ar2;
                }
                Label50.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label48.Text = "0";
                Label49.Text = "0";
                Label50.Text = "0";
            }
            con.Open();
           
           SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='1414 surpal' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    //Label47.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label47.Text = "1414 surpal";
                    Label51.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label51.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label51.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label52.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label52.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label52.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label53.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label47.Text = "0";
                    Label51.Text = "0";
                    Label52.Text = "0";
                    Label53.Text = "0";
                }
            }
            else
            {
                Label47.Text = "1414 surpal";
                Label51.Text = "0";
                Label52.Text = "0";
                Label53.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='1414 surpal')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label54.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label55.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label55.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label55.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label56.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label54.Text = "0";
                    Label55.Text = "0";
                    Label56.Text = "0";

                }

            }
            else
            {
                Label54.Text = "0";
                Label55.Text = "0";
                Label56.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='1414 surpal' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label57.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label57.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label57.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label57.Text);
                totalland = Convert.ToDouble(Label55.Text);
                landbal = totalland - saleland;
                Label58.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label55.Text) * Convert.ToDouble(Label56.Text);
                Label59.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label57.Text) * Convert.ToDouble(Label56.Text);
                Label60.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label59.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label59.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label60.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label60.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label61.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label48.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label48.Text);
                }
                if (Label57.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label57.Text);
                }

                bal9 = custtotal / soldamt2;
                Label385.Text = bal9.ToString("N0");


            }
            else
            {
                Label57.Text = "0";


            }
        }
        if (ar[3] == "174MI")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='174MI' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label63.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label63.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label63.Text);
                    custotal = custotal + ar1;
                }
                Label64.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label64.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label64.Text);
                    custpaid = custpaid + ar2;
                }
                Label65.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label63.Text = "0";
                Label64.Text = "0";
                Label65.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='174MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label62.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label66.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label66.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label66.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label67.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label67.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label67.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label68.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label62.Text = "0";
                    Label66.Text = "0";
                    Label67.Text = "0";
                    Label68.Text = "0";
                }
            }
            else
            {
                Label62.Text = "0";
                Label66.Text = "0";
                Label67.Text = "0";
                Label68.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='174MI')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label69.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label70.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label70.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label70.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label71.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label69.Text = "0";
                    Label70.Text = "0";
                    Label71.Text = "0";

                }
            }
            else
            {
                Label69.Text = "0";
                Label70.Text = "0";
                Label71.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='174MI' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label72.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label72.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label72.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label72.Text);
                totalland = Convert.ToDouble(Label70.Text);
                landbal = totalland - saleland;
                Label73.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label70.Text) * Convert.ToDouble(Label71.Text);
                Label74.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label72.Text) * Convert.ToDouble(Label71.Text);
                Label75.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label74.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label74.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label75.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label75.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label76.Text = balamt.ToString();

                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label63.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label63.Text);
                }
                if (Label72.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label72.Text);
                }

                bal9 = custtotal / soldamt2;
                Label386.Text = bal9.ToString("N0");

            }
            else
            {
                Label72.Text = "0";


            }
        }
        if (ar[4] == "2011")
        {
            custotal = custotal + 0;
            custpaid = custpaid + 0;
            kishantotal = kishantotal + 0;
            kishanpaid = kishanpaid + 0;
        }
        if (ar[5] == "239")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='239' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label93.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label93.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label93.Text);
                    custotal = custotal + ar1;
                }
                Label94.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label94.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label94.Text);
                    custpaid = custpaid + ar2;
                }
                Label95.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label93.Text = "0";
                Label94.Text = "0";
                Label95.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='239' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label92.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label96.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label96.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label96.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label97.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label97.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label97.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label98.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label92.Text = "0";
                    Label96.Text = "0";
                    Label97.Text = "0";
                    Label98.Text = "0";
                }
            }

            else
            {
                Label92.Text = "0";
                Label96.Text = "0";
                Label97.Text = "0";
                Label98.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='239')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label99.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label100.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label100.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label100.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label101.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label99.Text = "0";
                    Label100.Text = "0";
                    Label101.Text = "0";

                }
            }
            else
            {
                Label99.Text = "0";
                Label100.Text = "0";
                Label101.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='239' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label102.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label102.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label102.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label102.Text);
                totalland = Convert.ToDouble(Label100.Text);
                landbal = totalland - saleland;
                Label103.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label100.Text) * Convert.ToDouble(Label101.Text);
                Label104.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label102.Text) * Convert.ToDouble(Label101.Text);
                Label105.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label104.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label104.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label105.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label105.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label106.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label93.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label93.Text);
                }
                if (Label102.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label102.Text);
                }

                bal9 = custtotal / soldamt2;
                Label388.Text = bal9.ToString("N0");


            }
            else
            {
                Label102.Text = "0";


            }

        }
        if (ar[6] == "30")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='30' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label123.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label123.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label123.Text);
                    custotal = custotal + ar1;
                }
                Label124.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label124.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label124.Text);
                    custpaid = custpaid + ar2;
                }
                Label125.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label123.Text = "0";
                Label124.Text = "0";
                Label125.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='30' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label122.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label126.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label126.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label126.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label127.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label127.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label127.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label128.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label122.Text = "0";
                    Label126.Text = "0";
                    Label127.Text = "0";
                    Label128.Text = "0";
                }
            }
            else
            {
                Label122.Text = "0";
                Label126.Text = "0";
                Label127.Text = "0";
                Label128.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='30')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label129.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label130.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label130.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label130.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label131.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label129.Text = "0";
                    Label130.Text = "0";
                    Label131.Text = "0";

                }
            }
            else
            {
                Label129.Text = "0";
                Label130.Text = "0";
                Label131.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='30' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label132.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label132.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label132.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label132.Text);
                totalland = Convert.ToDouble(Label130.Text);
                landbal = totalland - saleland;
                Label133.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label130.Text) * Convert.ToDouble(Label131.Text);
                Label134.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label132.Text) * Convert.ToDouble(Label131.Text);
                Label135.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label134.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label134.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label135.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label135.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label136.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label123.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label123.Text);
                }
                if (Label132.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label132.Text);
                }

                bal9 = custtotal / soldamt2;
                Label390.Text = bal9.ToString("N0");


            }
            else
            {
                Label132.Text = "0";


            }
        }
        if (ar[7] == "254")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='254' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label108.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label108.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label108.Text);
                    custotal = custotal + ar1;
                }
                Label109.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label109.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label109.Text);
                    custpaid = custpaid + ar2;
                }
                Label110.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label108.Text = "0";
                Label109.Text = "0";
                Label110.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='254' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label107.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label111.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label111.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label111.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label112.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label112.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label112.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label113.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label107.Text = "0";
                    Label111.Text = "0";
                    Label112.Text = "0";
                    Label113.Text = "0";
                }
            }
            else
            {
                Label107.Text = "0";
                Label111.Text = "0";
                Label112.Text = "0";
                Label113.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='254')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label114.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label115.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label115.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label115.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label116.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label114.Text = "0";
                    Label115.Text = "0";
                    Label116.Text = "0";

                }
            }
            else
            {
                Label114.Text = "0";
                Label115.Text = "0";
                Label116.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='254' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label117.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label117.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label117.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label117.Text);
                totalland = Convert.ToDouble(Label115.Text);
                landbal = totalland - saleland;
                Label118.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label115.Text) * Convert.ToDouble(Label116.Text);
                Label119.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label117.Text) * Convert.ToDouble(Label116.Text);
                Label120.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label119.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label119.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label120.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label120.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label121.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label108.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label108.Text);
                }
                if (Label117.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label117.Text);
                }

                bal9 = custtotal / soldamt2;
                Label389.Text = bal9.ToString("N0");


            }
            else
            {
                Label117.Text = "0";


            }
        }
        if (ar[8] == "343")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='343' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label138.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label138.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label138.Text);
                    custotal = custotal + ar1;
                }
                Label139.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label139.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label139.Text);
                    custpaid = custpaid + ar2;
                }
                Label140.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label138.Text = "0";
                Label139.Text = "0";
                Label140.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='343' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label137.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label141.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label141.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label141.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label142.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label142.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label142.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label143.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label137.Text = "0";
                    Label141.Text = "0";
                    Label142.Text = "0";
                    Label143.Text = "0";
                }
            }
            else
            {
                Label137.Text = "0";
                Label141.Text = "0";
                Label142.Text = "0";
                Label143.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='343')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label144.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label145.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label145.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label145.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label146.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label144.Text = "0";
                    Label145.Text = "0";
                    Label146.Text = "0";

                }
            }
            else
            {
                Label144.Text = "0";
                Label145.Text = "0";
                Label146.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='343' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label147.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label147.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label147.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label147.Text);
                totalland = Convert.ToDouble(Label145.Text);
                landbal = totalland - saleland;
                Label148.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label145.Text) * Convert.ToDouble(Label146.Text);
                Label149.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label147.Text) * Convert.ToDouble(Label146.Text);
                Label150.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label149.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label149.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label150.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label150.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label151.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label138.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label138.Text);
                }
                if (Label147.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label147.Text);
                }

                bal9 = custtotal / soldamt2;
                Label391.Text = bal9.ToString("N0");


            }
            else
            {
                Label147.Text = "0";


            }
        }
        if (ar[9] == "375KA")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='375KA' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label153.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label153.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label153.Text);
                    custotal = custotal + ar1;
                }
                Label154.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label154.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label154.Text);
                    custpaid = custpaid + ar2;
                }
                Label155.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label153.Text = "0";
                Label154.Text = "0";
                Label155.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='375KA' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label152.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label156.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label156.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label156.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label157.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label157.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label157.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label158.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label152.Text = "0";
                    Label156.Text = "0";
                    Label157.Text = "0";
                    Label158.Text = "0";
                }
            }
            else
            {
                Label152.Text = "0";
                Label156.Text = "0";
                Label157.Text = "0";
                Label158.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='375KA')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label159.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label160.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label160.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label160.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label161.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label159.Text = "0";
                    Label160.Text = "0";
                    Label161.Text = "0";

                }
            }
            else
            {
                Label159.Text = "0";
                Label160.Text = "0";
                Label161.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='375KA' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label162.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label162.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label162.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label162.Text);
                totalland = Convert.ToDouble(Label160.Text);
                landbal = totalland - saleland;
                Label163.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label160.Text) * Convert.ToDouble(Label161.Text);
                Label164.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label162.Text) * Convert.ToDouble(Label161.Text);
                Label165.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label164.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label164.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label165.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label165.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label166.Text = balamt.ToString();

                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label153.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label153.Text);
                }
                if (Label162.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label162.Text);
                }

                bal9 = custtotal / soldamt2;
                Label392.Text = bal9.ToString("N0");

            }
            else
            {
                Label162.Text = "0";


            }
        }
        if (ar[10] == "432")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='432' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label168.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label168.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label168.Text);
                    custotal = custotal + ar1;
                }
                Label169.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label169.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label169.Text);
                    custpaid = custpaid + ar2;
                }
                Label170.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label168.Text = "0";
                Label169.Text = "0";
                Label170.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='432' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label167.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label171.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label171.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label171.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label172.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label172.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label172.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label173.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label167.Text = "432";
                    Label171.Text = "0";
                    Label172.Text = "0";
                    Label173.Text = "0";
                }
            }
            else
            {
                Label167.Text = "432";
                Label171.Text = "0";
                Label172.Text = "0";
                Label173.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='432')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label174.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label175.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label175.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label175.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label176.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label174.Text = "0";
                    Label175.Text = "0";
                    Label176.Text = "0";

                }
            }
            else
            {
                Label174.Text = "0";
                Label175.Text = "0";
                Label176.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='432' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label177.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label177.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label177.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label177.Text);
                totalland = Convert.ToDouble(Label175.Text);
                landbal = totalland - saleland;
                Label178.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label175.Text) * Convert.ToDouble(Label176.Text);
                Label179.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label177.Text) * Convert.ToDouble(Label176.Text);
                Label180.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label179.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label179.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label180.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label180.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label181.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label168.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label168.Text);
                }
                if (Label177.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label177.Text);
                }

                bal9 = custtotal / soldamt2;
                Label393.Text = bal9.ToString("N0");


            }
            else
            {
                Label177.Text = "0";


            }
        }
        if (ar[11] == "436")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='436' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label183.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label183.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label183.Text);
                    custotal = custotal + ar1;
                }
                Label184.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label184.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label184.Text);
                    custpaid = custpaid + ar2;
                }
                Label185.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label183.Text = "0";
                Label184.Text = "0";
                Label185.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='436' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label182.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label186.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label186.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label186.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label187.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label187.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label187.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label188.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label182.Text = "0";
                    Label186.Text = "0";
                    Label187.Text = "0";
                    Label188.Text = "0";
                }
            }
            else
            {
                Label182.Text = "0";
                Label186.Text = "0";
                Label187.Text = "0";
                Label188.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='436')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label189.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label190.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label190.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label190.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label191.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label189.Text = "0";
                    Label190.Text = "0";
                    Label191.Text = "0";

                }
            }
            else
            {
                Label189.Text = "0";
                Label190.Text = "0";
                Label191.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='436' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label192.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label192.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label192.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label192.Text);
                totalland = Convert.ToDouble(Label190.Text);
                landbal = totalland - saleland;
                Label193.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label190.Text) * Convert.ToDouble(Label191.Text);
                Label194.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label192.Text) * Convert.ToDouble(Label191.Text);
                Label195.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label194.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label194.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label195.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label195.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label196.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label183.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label183.Text);
                }
                if (Label192.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label192.Text);
                }

                bal9 = custtotal / soldamt2;
                Label394.Text = bal9.ToString("N0");


            }
            else
            {
                Label192.Text = "0";


            }
        }
        if (ar[12] == "RAMAI137")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='RAMAI137' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label198.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label198.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label198.Text);
                    custotal = custotal + ar1;
                }
                Label199.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label199.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label199.Text);
                    custpaid = custpaid + ar2;
                }
                Label200.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label198.Text = "0";
                Label199.Text = "0";
                Label200.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='RAMAI137' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label197.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label201.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label201.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label201.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label202.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label202.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label202.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label203.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label197.Text = "0";
                    Label201.Text = "0";
                    Label202.Text = "0";
                    Label203.Text = "0";
                }
            }
            else
            {
                Label197.Text = "0";
                Label201.Text = "0";
                Label202.Text = "0";
                Label203.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='RAMAI137')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label204.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label205.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label205.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label205.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label206.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label204.Text = "0";
                    Label205.Text = "0";
                    Label206.Text = "0";

                }
            }
            else
            {
                Label204.Text = "0";
                Label205.Text = "0";
                Label206.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='RAMAI137' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label207.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label207.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label207.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label207.Text);
                totalland = Convert.ToDouble(Label205.Text);
                landbal = totalland - saleland;
                Label208.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label205.Text) * Convert.ToDouble(Label206.Text);
                Label209.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label207.Text) * Convert.ToDouble(Label206.Text);
                Label210.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label209.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label209.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label210.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label210.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label211.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label198.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label198.Text);
                }
                if (Label207.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label207.Text);
                }

                bal9 = custtotal / soldamt2;
                Label395.Text = bal9.ToString("N0");


            }
            else
            {
                Label207.Text = "0";


            }
        }
        if (ar[13] == "152")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label213.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label213.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label213.Text);
                    custotal = custotal + ar1;
                }
                Label214.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label214.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label214.Text);
                    custpaid = custpaid + ar2;
                }
                Label215.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label213.Text = "0";
                Label214.Text = "0";
                Label215.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='152' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label212.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label216.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label216.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label216.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label217.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label217.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label217.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label218.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label212.Text = "0";
                    Label216.Text = "0";
                    Label217.Text = "0";
                    Label218.Text = "0";
                }
            }
            else
            {
                Label212.Text = "0";
                Label216.Text = "0";
                Label217.Text = "0";
                Label218.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='152')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label219.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label220.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label220.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label220.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label221.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label219.Text = "0";
                    Label220.Text = "0";
                    Label221.Text = "0";

                }
            }
            else
            {
                Label219.Text = "0";
                Label220.Text = "0";
                Label221.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='152' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label222.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label222.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label222.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label222.Text);
                totalland = Convert.ToDouble(Label220.Text);
                landbal = totalland - saleland;
                Label223.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label220.Text) * Convert.ToDouble(Label221.Text);
                Label224.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label222.Text) * Convert.ToDouble(Label221.Text);
                Label225.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label224.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label224.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label225.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label225.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label226.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label213.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label213.Text);
                }
                if (Label222.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label222.Text);
                }

                bal9 = custtotal / soldamt2;
                Label396.Text = bal9.ToString("N0");


            }
            else
            {
                Label222.Text = "0";


            }
        }
        if (ar[14] == "506")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='506' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label228.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label228.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label228.Text);
                    custotal = custotal + ar1;
                }
                Label229.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label229.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label229.Text);
                    custpaid = custpaid + ar2;
                }
                Label230.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label228.Text = "0";
                Label229.Text = "0";
                Label230.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='506' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label227.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label231.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label231.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label231.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label232.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label232.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label232.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label233.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label227.Text = "0";
                    Label231.Text = "0";
                    Label232.Text = "0";
                    Label233.Text = "0";
                }
            }
            else
            {
                Label227.Text = "0";
                Label231.Text = "0";
                Label232.Text = "0";
                Label233.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='506')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label234.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label235.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label235.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label235.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label236.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label234.Text = "0";
                    Label235.Text = "0";
                    Label236.Text = "0";

                }
            }
            else
            {
                Label234.Text = "0";
                Label235.Text = "0";
                Label236.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='506' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label237.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label237.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label237.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label237.Text);
                totalland = Convert.ToDouble(Label235.Text);
                landbal = totalland - saleland;
                Label238.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label235.Text) * Convert.ToDouble(Label236.Text);
                Label239.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label237.Text) * Convert.ToDouble(Label236.Text);
                Label240.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label239.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label239.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label240.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label240.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label241.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label228.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label228.Text);
                }
                if (Label237.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label237.Text);
                }

                bal9 = custtotal / soldamt2;
                Label397.Text = bal9.ToString("N0");


            }
            else
            {
                Label237.Text = "0";


            }
        }
        if (ar[15] == "1989")
        {
            custotal = custotal + 0;
            custpaid = custpaid + 0;
            kishantotal = kishantotal + 0;
            kishanpaid = kishanpaid + 0;

        }
        if (ar[16] == "161GHA")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='161GHA' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label258.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label258.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label258.Text);
                    custotal = custotal + ar1;
                }
                Label259.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label259.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label259.Text);
                    custpaid = custpaid + ar2;
                }
                Label260.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label258.Text = "0";
                Label259.Text = "0";
                Label260.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='161GHA' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label257.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label261.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label261.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label261.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label262.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label262.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label262.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label263.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label257.Text = "0";
                    Label261.Text = "0";
                    Label262.Text = "0";
                    Label263.Text = "0";
                }
            }
            else
            {
                Label257.Text = "0";
                Label261.Text = "0";
                Label262.Text = "0";
                Label263.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='161GHA')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label264.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label265.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label265.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label265.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label266.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label264.Text = "0";
                    Label265.Text = "0";
                    Label266.Text = "0";

                }
            }
            else
            {
                Label264.Text = "0";
                Label265.Text = "0";
                Label266.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='161GHA' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label267.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label267.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label267.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label267.Text);
                totalland = Convert.ToDouble(Label265.Text);
                landbal = totalland - saleland;
                Label268.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label265.Text) * Convert.ToDouble(Label266.Text);
                Label269.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label267.Text) * Convert.ToDouble(Label266.Text);
                Label270.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label269.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label269.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label270.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label270.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label271.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label258.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label258.Text);
                }
                if (Label267.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label267.Text);
                }

                bal9 = custtotal / soldamt2;
                Label399.Text = bal9.ToString("N0");


            }
            else
            {
                Label267.Text = "0";


            }
        }
        if (ar[17] == "2001GA")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='2001GA' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label273.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label273.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label273.Text);
                    custotal = custotal + ar1;
                }
                Label274.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label274.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label274.Text);
                    custpaid = custpaid + ar2;
                }
                Label275.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label273.Text = "0";
                Label274.Text = "0";
                Label275.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='2001GA' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label272.Text = ds2.Tables[0].Rows[0][0].ToString();

                    Label276.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label276.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label276.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label277.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label277.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label277.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label278.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label272.Text = "0";
                    Label276.Text = "0";
                    Label277.Text = "0";
                    Label278.Text = "0";
                }
            }
            else
            {
                Label272.Text = "0";
                Label276.Text = "0";
                Label277.Text = "0";
                Label278.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='2001GA')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label279.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label280.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label280.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label280.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label281.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label279.Text = "0";
                    Label280.Text = "0";
                    Label281.Text = "0";

                }
            }
            else
            {
                Label279.Text = "0";
                Label280.Text = "0";
                Label281.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='2001GA' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label282.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label282.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label282.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label282.Text);
                totalland = Convert.ToDouble(Label280.Text);
                landbal = totalland - saleland;
                Label283.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label280.Text) * Convert.ToDouble(Label281.Text);
                Label284.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label282.Text) * Convert.ToDouble(Label281.Text);
                Label285.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label284.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label284.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label285.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label285.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label286.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label273.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label273.Text);
                }
                if (Label282.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label282.Text);
                }

                bal9 = custtotal / soldamt2;
                Label400.Text = bal9.ToString("N0");


            }
            else
            {
                Label282.Text = "0";


            }
        }
        if (ar[18] == "513RA")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='513RA' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label288.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label288.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label288.Text);
                    custotal = custotal + ar1;
                }
                Label289.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label289.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label289.Text);
                    custpaid = custpaid + ar2;
                }
                Label290.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label288.Text = "0";
                Label289.Text = "0";
                Label290.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='513RA' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label287.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label291.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label291.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label291.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label292.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label292.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label292.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label293.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label287.Text = "0";
                    Label291.Text = "0";
                    Label292.Text = "0";
                    Label293.Text = "0";
                }
            }
            else
            {
                Label287.Text = "0";
                Label291.Text = "0";
                Label292.Text = "0";
                Label293.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='513RA')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label294.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label295.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label295.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label295.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label296.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label294.Text = "0";
                    Label295.Text = "0";
                    Label296.Text = "0";

                }
            }
            else
            {
                Label294.Text = "0";
                Label295.Text = "0";
                Label296.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='513RA' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label297.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label297.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label297.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label297.Text);
                totalland = Convert.ToDouble(Label295.Text);
                landbal = totalland - saleland;
                Label298.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label295.Text) * Convert.ToDouble(Label296.Text);
                Label299.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label297.Text) * Convert.ToDouble(Label296.Text);
                Label300.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label299.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label299.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label300.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label300.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label301.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label288.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label288.Text);
                }
                if (Label297.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label297.Text);
                }

                bal9 = custtotal / soldamt2;
                Label401.Text = bal9.ToString("N0");


            }
            else
            {
                Label297.Text = "0";


            }
        }
        if (ar[19] == "1418")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='1418' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label303.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label303.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label303.Text);
                    custotal = custotal + ar1;
                }
                Label304.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label304.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label304.Text);
                    custpaid = custpaid + ar2;
                }
                Label305.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label303.Text = "0";
                Label304.Text = "0";
                Label305.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='1418' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label302.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label306.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label306.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label306.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label307.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label307.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label307.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label308.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label302.Text = "0";
                    Label306.Text = "0";
                    Label307.Text = "0";
                    Label308.Text = "0";
                }
            }
            else
            {
                Label302.Text = "0";
                Label306.Text = "0";
                Label307.Text = "0";
                Label308.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='1418')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label309.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label310.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label310.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label310.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label311.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label309.Text = "0";
                    Label310.Text = "0";
                    Label311.Text = "0";

                }
            }
            else
            {
                Label309.Text = "0";
                Label310.Text = "0";
                Label311.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='1418' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label312.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label312.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label312.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label312.Text);
                totalland = Convert.ToDouble(Label310.Text);
                landbal = totalland - saleland;
                Label313.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label310.Text) * Convert.ToDouble(Label311.Text);
                Label314.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label312.Text) * Convert.ToDouble(Label311.Text);
                Label315.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label314.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label314.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label315.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label315.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label316.Text = balamt.ToString();

                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label303.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label303.Text);
                }
                if (Label312.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label312.Text);
                }

                bal9 = custtotal / soldamt2;
                Label402.Text = bal9.ToString("N0");

            }
            else
            {
                Label312.Text = "0";


            }
        }
        if (ar[20] == "372KA")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='372KA' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
           
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label318.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label318.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label318.Text);
                    custotal = custotal + ar1;
                }
                Label319.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label319.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label319.Text);
                    custpaid = custpaid + ar2;
                }
                Label320.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label318.Text = "0";
                Label319.Text = "0";
                Label320.Text = "0";
            }
            con.Open();
             SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID) AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='372KA' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label317.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label321.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label321.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label321.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label322.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label322.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label322.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label323.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label317.Text = "372KA";
                    Label321.Text = "0";
                    Label322.Text = "0";
                    Label323.Text = "0";
                }
            }
            else
            {
                Label317.Text = "372KA";
                Label321.Text = "0";
                Label322.Text = "0";
                Label323.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='372KA')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label324.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label325.Text = ds3.Tables[0].Rows[0][1].ToString();
                    Double ar4 = 0;
                    if (Label325.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label325.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label326.Text = ds3.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    Label324.Text = "0";
                    Label325.Text = "0";
                    Label326.Text = "0";

                }
            }
            else
            {
                Label324.Text = "0";
                Label325.Text = "0";
                Label326.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='372KA' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label327.Text = ds5.Tables[0].Rows[0][0].ToString();
              Double ar5 = 0;
                if (Label327.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label327.Text);
                    landsold = landsold + ar5;
                }
                Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                saleland = Convert.ToDouble(Label327.Text);
                totalland = Convert.ToDouble(Label325.Text);
                landbal = totalland - saleland;
                Label328.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label325.Text) * Convert.ToDouble(Label326.Text);
                Label329.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label327.Text) * Convert.ToDouble(Label326.Text);
                Label330.Text = saleamt.ToString();
              Double ar6 = 0, ar7 = 0;
                if (Label329.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label329.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label330.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label330.Text);
                    soldamt= soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label331.Text = balamt.ToString();

                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label318.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label318.Text);
                }
                if (Label327.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label327.Text);
                }

                bal9 = custtotal / soldamt2;
                Label403.Text = bal9.ToString("N0");

            }
            else
            {
                Label327.Text = "0";


            }
        }
        if (ar[21] == "385KA")
        {
            SqlConnection con = new SqlConnection(s);
           con.Open();
           SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='385KA' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
           DataSet ds1 = new DataSet();
           da1.Fill(ds1);
           con.Close();
           if (ds1.Tables[0].Rows[0][0].ToString() != "")
           {
               Label333.Text = ds1.Tables[0].Rows[0][0].ToString();
               Double ar1 = 0;
               if (Label333.Text == "")
               {
                   ar1 = 0;
                   custotal = custotal + ar1;
               }
               else
               {
                   ar1 = Convert.ToDouble(Label333.Text);
                   custotal = custotal + ar1;
               }
               Label334.Text = ds1.Tables[0].Rows[0][1].ToString();
               Double ar2 = 0;
               if (Label334.Text == "")
               {
                   ar2 = 0;
                   custpaid = custpaid + ar2;
               }
               else
               {
                   ar2 = Convert.ToDouble(Label334.Text);
                   custpaid = custpaid + ar2;
               }
               Label335.Text = ds1.Tables[0].Rows[0][2].ToString();
           }
           else
           {
               Label333.Text = "0";
               Label334.Text = "0";
               Label335.Text = "0";
           }
           con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='385KA' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
           DataSet ds2 = new DataSet();
           da2.Fill(ds2);
           con.Close();
           if (ds2.Tables[0].Rows.Count > 0)
           {
               if (ds2.Tables[0].Rows[0][0].ToString() != "")
               {
                   Label332.Text = ds2.Tables[0].Rows[0][0].ToString();
                   Label336.Text = ds2.Tables[0].Rows[0][1].ToString();
                   Double ar2 = 0;
                   if (Label336.Text == "")
                   {
                       ar2 = 0;
                       kishantotal = kishantotal + ar2;
                   }
                   else
                   {
                       ar2 = Convert.ToDouble(Label336.Text);
                       kishantotal = kishantotal + ar2;
                   }
                   Label337.Text = ds2.Tables[0].Rows[0][2].ToString();
                   Double ar3 = 0;
                   if (Label337.Text == "")
                   {
                       ar3 = 0;
                       kishanpaid = kishanpaid + ar3;
                   }
                   else
                   {
                       ar3 = Convert.ToDouble(Label337.Text);
                       kishanpaid = kishanpaid + ar3;
                   }
                   Label338.Text = ds2.Tables[0].Rows[0][3].ToString();
               }
               else
               {
                   Label332.Text = "385KA";
                   Label336.Text = "0";
                   Label337.Text = "0";
                   Label338.Text = "0";
               }
           }
           else
           {
               Label332.Text = "385KA";
               Label336.Text = "0";
               Label337.Text = "0";
               Label338.Text = "0";
           }
           con.Open();
           SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='385KA')", con);
           DataSet ds3 = new DataSet();
           da3.Fill(ds3);
           con.Close();
           if (ds3.Tables[0].Rows.Count > 0)
           {
               if (ds3.Tables[0].Rows[0][0].ToString() != "")
               {
                   Label339.Text = ds3.Tables[0].Rows[0][0].ToString();
                   Label340.Text = ds3.Tables[0].Rows[0][1].ToString();
                   Double ar4 = 0;
                   if (Label340.Text == "")
                   {
                       ar4 = 0;
                       landtotal = landtotal + ar4;
                   }
                   else
                   {
                       ar4 = Convert.ToDouble(Label340.Text);
                       landtotal = landtotal + ar4;
                   }
                   Label341.Text = ds3.Tables[0].Rows[0][2].ToString();

               }
               else
               {
                   Label339.Text = "0";
                   Label341.Text = "0";
                   Label340.Text = "0";

               }
           }
           else
           {
               Label339.Text = "0";
               Label341.Text = "0";
               Label340.Text = "0";

           }
           con.Open();
           SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='385KA' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
           DataSet ds5 = new DataSet();
           da5.Fill(ds5);
           con.Close();
           if (ds5.Tables[0].Rows[0][0].ToString() != "")
           {
               Label342.Text = ds5.Tables[0].Rows[0][0].ToString();
              Double ar5 = 0;
                if (Label342.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label342.Text);
                    landsold = landsold + ar5;
                }
               Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
               saleland = Convert.ToDouble(Label342.Text);
               totalland = Convert.ToDouble(Label340.Text);
               landbal = totalland - saleland;
               Label343.Text = landbal.ToString();
               totalamt = Convert.ToDouble(Label340.Text) * Convert.ToDouble(Label341.Text);
               Label344.Text = totalamt.ToString();
               saleamt = Convert.ToDouble(Label342.Text) * Convert.ToDouble(Label341.Text);
               Label345.Text = saleamt.ToString();
              Double ar6 = 0, ar7 = 0;
                if (Label344.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label344.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label345.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label345.Text);
                    soldamt= soldamt + ar7;
                }
               balamt = totalamt - saleamt;
               Label346.Text = balamt.ToString();

               Double custtotal = 0, soldamt2 = 0, bal9 = 0;
               if (Label333.Text == "")
               {
                   custtotal = 0;
               }
               else
               {
                   custtotal = Convert.ToDouble(Label333.Text);
               }
               if (Label342.Text == "")
               {
                   soldamt2 = 0;
               }
               else
               {
                   soldamt2 = Convert.ToDouble(Label342.Text);
               }

               bal9 = custtotal / soldamt2;
               Label404.Text = bal9.ToString("N0");

           }
           else
           {
               Label342.Text = "0";


           }

          
        }
        if (ar[22] == "186MI")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='186MI' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label364.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label364.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label364.Text);
                    custotal = custotal + ar1;
                }
                Label365.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label365.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label365.Text);
                    custpaid = custpaid + ar2;
                }
                Label366.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label364.Text = "0";
                Label365.Text = "0";
                Label366.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',sum(k.landamount) AS 'TOTAL',c.PAID AS 'PAID',(sum(k.landamount)-c.PAID)AS 'BAL',sum(k.saleland) from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi group by k.arazi,c.PAID", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.saleland from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("",con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label363.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label367.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label367.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label367.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label368.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label368.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label368.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label369.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label363.Text = "186MI";
                    Label367.Text = "0";
                    Label368.Text = "0";
                    Label369.Text = "0";
                }
            }
            else
            {
                Label363.Text = "186MI";
                Label367.Text = "0";
                Label368.Text = "0";
                Label369.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,salerate from newkishan where id IN(select id from newkishan where arazi='186MI')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label370.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label371.Text = ds2.Tables[0].Rows[0][4].ToString();
                    Double ar4 = 0;
                    if (Label371.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label371.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label372.Text = ds3.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    Label370.Text = "0";
                    Label372.Text = "0";
                    Label371.Text = "0";

                }
            }
            else
            {
                Label370.Text = "0";
                Label372.Text = "0";
                Label371.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='186MI' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label373.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label373.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label373.Text);
                    landsold = landsold + ar5;
                }
               
                saleland = Convert.ToDouble(Label373.Text);
                totalland = Convert.ToDouble(Label371.Text);
                landbal = totalland - saleland;
                Label374.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label371.Text) * Convert.ToDouble(Label372.Text);
                Label375.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label373.Text) * Convert.ToDouble(Label372.Text);
                Label376.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label375.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label375.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label376.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label376.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label377.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label364.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label364.Text);
                }
                if (Label373.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label373.Text);
                }

                bal9 = custtotal / soldamt2;
                Label405.Text = bal9.ToString("N0");


            }
            else
            {
                Label373.Text = "0";
                saleland = Convert.ToDouble(Label373.Text);
                totalland = Convert.ToDouble(Label371.Text);
                landbal = totalland - saleland;
                Label374.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label371.Text) * Convert.ToDouble(Label372.Text);
                Label375.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label373.Text) * Convert.ToDouble(Label372.Text);
                Label376.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label376.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label376.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label377.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label364.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label364.Text);
                }
                if (Label373.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label373.Text);
                }

                bal9 = custtotal / soldamt2;
                Label405.Text = bal9.ToString("N0");
            }

            Label348.Text = custotal.ToString();
            Label349.Text = custpaid.ToString();
            Double custbal = 0, kishanbal = 0, landbal1 = 0, totalbalamt = 0;
            custbal = Convert.ToDouble(Label348.Text) - Convert.ToDouble(Label349.Text);
            Label350.Text = custbal.ToString();
            Label351.Text = kishantotal.ToString();
            Label352.Text = kishanpaid.ToString();
            kishanbal = Convert.ToDouble(Label351.Text) - Convert.ToDouble(Label352.Text);
            Label353.Text = kishanbal.ToString();
            Label355.Text = landtotal.ToString();
            Label357.Text = landsold.ToString();
            landbal1 = Convert.ToDouble(Label355.Text) - Convert.ToDouble(Label357.Text);
            Label358.Text = landbal1.ToString();
            Label359.Text = totallandamt.ToString();
            Label360.Text = soldamt.ToString();
            totalbalamt = Convert.ToDouble(Label359.Text) - Convert.ToDouble(Label360.Text);

            Label361.Text = totalbalamt.ToString();
        }

        if (ar[23] == "217")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='217' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label354.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label354.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label354.Text);
                    custotal = custotal + ar1;
                }
                Label356.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label356.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label356.Text);
                    custpaid = custpaid + ar2;
                }
                Label362.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label354.Text = "0";
                Label356.Text = "0";
                Label362.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',sum(k.landamount) AS 'TOTAL',c.PAID AS 'PAID',(sum(k.landamount)-c.PAID)AS 'BAL',sum(k.saleland) from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='217' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi group by k.arazi,c.PAID", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.saleland from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("",con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label347.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label406.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label347.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label406.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label407.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label407.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label407.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label408.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label347.Text = "217";
                    Label406.Text = "0";
                    Label407.Text = "0";
                    Label408.Text = "0";
                }
            }
            else
            {
                Label347.Text = "217";
                Label406.Text = "0";
                Label407.Text = "0";
                Label408.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,salerate from newkishan where id IN(select id from newkishan where arazi='217')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label409.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label410.Text = ds2.Tables[0].Rows[0][4].ToString();
                    Double ar4 = 0;
                    if (Label410.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label410.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label411.Text = ds3.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    Label409.Text = "0";
                    Label410.Text = "0";
                    Label411.Text = "0";

                }
            }
            else
            {
                Label409.Text = "0";
                Label410.Text = "0";
                Label411.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='217' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label412.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label412.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label412.Text);
                    landsold = landsold + ar5;
                }

                saleland = Convert.ToDouble(Label412.Text);
                totalland = Convert.ToDouble(Label410.Text);
                landbal = totalland - saleland;
                Label413.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label410.Text) * Convert.ToDouble(Label411.Text);
                Label414.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label412.Text) * Convert.ToDouble(Label411.Text);
                Label415.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label414.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label414.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label415.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label415.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label416.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label354.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label354.Text);
                }
                if (Label412.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label412.Text);
                }

                bal9 = custtotal / soldamt2;
                Label417.Text = bal9.ToString("N0");


            }
            else
            {
                Label412.Text = "0";
                saleland = Convert.ToDouble(Label412.Text);
                totalland = Convert.ToDouble(Label410.Text);
                landbal = totalland - saleland;
                Label413.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label410.Text) * Convert.ToDouble(Label411.Text);
                Label414.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label412.Text) * Convert.ToDouble(Label411.Text);
                Label415.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label415.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label415.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label416.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label354.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label354.Text);
                }
                if (Label412.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label412.Text);
                }

                bal9 = custtotal / soldamt2;
                Label417.Text = bal9.ToString("N0");
            }

            Label348.Text = custotal.ToString();
            Label349.Text = custpaid.ToString();
            Double custbal = 0, kishanbal = 0, landbal1 = 0, totalbalamt = 0;
            custbal = Convert.ToDouble(Label348.Text) - Convert.ToDouble(Label349.Text);
            Label350.Text = custbal.ToString();
            Label351.Text = kishantotal.ToString();
            Label352.Text = kishanpaid.ToString();
            kishanbal = Convert.ToDouble(Label351.Text) - Convert.ToDouble(Label352.Text);
            Label353.Text = kishanbal.ToString();
            Label355.Text = landtotal.ToString();
            Label357.Text = landsold.ToString();
            landbal1 = Convert.ToDouble(Label355.Text) - Convert.ToDouble(Label357.Text);
            Label358.Text = landbal1.ToString();
            Label359.Text = totallandamt.ToString();
            Label360.Text = soldamt.ToString();
            totalbalamt = Convert.ToDouble(Label359.Text) - Convert.ToDouble(Label360.Text);

            Label361.Text = totalbalamt.ToString();
        }


        if (ar[24] == "357")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='357' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label419.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label419.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label419.Text);
                    custotal = custotal + ar1;
                }
                Label420.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label420.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label420.Text);
                    custpaid = custpaid + ar2;
                }
                Label421.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label419.Text = "0";
                Label420.Text = "0";
                Label421.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',sum(k.landamount) AS 'TOTAL',c.PAID AS 'PAID',(sum(k.landamount)-c.PAID)AS 'BAL',sum(k.saleland) from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='357' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi group by k.arazi,c.PAID", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.saleland from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("",con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label418.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label422.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label418.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label422.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label423.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label423.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label423.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label424.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label418.Text = "357";
                    Label422.Text = "0";
                    Label423.Text = "0";
                    Label424.Text = "0";
                }
            }
            else
            {
                Label418.Text = "357";
                Label422.Text = "0";
                Label423.Text = "0";
                Label424.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,salerate from newkishan where id IN(select id from newkishan where arazi='357')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label425.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label426.Text = ds2.Tables[0].Rows[0][4].ToString();
                    Double ar4 = 0;
                    if (Label426.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label426.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label427.Text = ds3.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    Label425.Text = "0";
                    Label426.Text = "0";
                    Label427.Text = "0";

                }
            }
            else
            {
                Label425.Text = "0";
                Label426.Text = "0";
                Label427.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='357' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label428.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label428.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label428.Text);
                    landsold = landsold + ar5;
                }

                saleland = Convert.ToDouble(Label428.Text);
                totalland = Convert.ToDouble(Label426.Text);
                landbal = totalland - saleland;
                Label429.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label426.Text) * Convert.ToDouble(Label427.Text);
                Label430.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label428.Text) * Convert.ToDouble(Label427.Text);
                Label431.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label430.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label430.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label431.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label431.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label432.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label419.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label419.Text);
                }
                if (Label428.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label428.Text);
                }

                bal9 = custtotal / soldamt2;
                Label433.Text = bal9.ToString("N0");


            }
            else
            {
                Label428.Text = "0";
                saleland = Convert.ToDouble(Label428.Text);
                totalland = Convert.ToDouble(Label426.Text);
                landbal = totalland - saleland;
                Label429.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label426.Text) * Convert.ToDouble(Label427.Text);
                Label430.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label428.Text) * Convert.ToDouble(Label427.Text);
                Label431.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label431.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label431.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label432.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label419.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label419.Text);
                }
                if (Label428.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label428.Text);
                }

                bal9 = custtotal / soldamt2;
                Label433.Text = bal9.ToString("N0");
            }

            Label348.Text = custotal.ToString();
            Label349.Text = custpaid.ToString();
            Double custbal = 0, kishanbal = 0, landbal1 = 0, totalbalamt = 0;
            custbal = Convert.ToDouble(Label348.Text) - Convert.ToDouble(Label349.Text);
            Label350.Text = custbal.ToString();
            Label351.Text = kishantotal.ToString();
            Label352.Text = kishanpaid.ToString();
            kishanbal = Convert.ToDouble(Label351.Text) - Convert.ToDouble(Label352.Text);
            Label353.Text = kishanbal.ToString();
            Label355.Text = landtotal.ToString();
            Label357.Text = landsold.ToString();
            landbal1 = Convert.ToDouble(Label355.Text) - Convert.ToDouble(Label357.Text);
            Label358.Text = landbal1.ToString();
            Label359.Text = totallandamt.ToString();
            Label360.Text = soldamt.ToString();
            totalbalamt = Convert.ToDouble(Label359.Text) - Convert.ToDouble(Label360.Text);

            Label361.Text = totalbalamt.ToString();
        }

        if (ar[25] == "187-KHA")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='187-KHA' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label436.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label419.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label436.Text);
                    custotal = custotal + ar1;
                }
                Label437.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label437.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label437.Text);
                    custpaid = custpaid + ar2;
                }
                Label438.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label436.Text = "0";
                Label437.Text = "0";
                Label438.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',sum(k.landamount) AS 'TOTAL',c.PAID AS 'PAID',(sum(k.landamount)-c.PAID)AS 'BAL',sum(k.saleland) from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='187-KHA' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi group by k.arazi,c.PAID", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.saleland from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("",con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label435.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label439.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label435.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label439.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label440.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label440.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label440.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label441.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label435.Text = "187-KHA";
                    Label439.Text = "0";
                    Label440.Text = "0";
                    Label441.Text = "0";
                }
            }
            else
            {
                Label435.Text = "187-KHA";
                Label439.Text = "0";
                Label440.Text = "0";
                Label441.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,salerate from newkishan where id IN(select id from newkishan where arazi='187-KHA')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label442.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label443.Text = ds2.Tables[0].Rows[0][4].ToString();
                    Double ar4 = 0;
                    if (Label443.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label443.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label444.Text = ds3.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    Label442.Text = "0";
                    Label443.Text = "0";
                    Label444.Text = "0";

                }
            }
            else
            {
                Label442.Text = "0";
                Label443.Text = "0";
                Label444.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='187-KHA' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label445.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label445.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label445.Text);
                    landsold = landsold + ar5;
                }

                saleland = Convert.ToDouble(Label445.Text);
                totalland = Convert.ToDouble(Label443.Text);
                landbal = totalland - saleland;
                Label446.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label443.Text) * Convert.ToDouble(Label444.Text);
                Label447.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label445.Text) * Convert.ToDouble(Label444.Text);
                Label448.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label447.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label447.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label448.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label448.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label449.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label436.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label436.Text);
                }
                if (Label445.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label445.Text);
                }

                bal9 = custtotal / soldamt2;
                Label450.Text = bal9.ToString("N0");


            }
            else
            {
                Label445.Text = "0";
                saleland = Convert.ToDouble(Label445.Text);
                totalland = Convert.ToDouble(Label443.Text);
                landbal = totalland - saleland;
                Label446.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label443.Text) * Convert.ToDouble(Label444.Text);
                Label447.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label445.Text) * Convert.ToDouble(Label444.Text);
                Label448.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label448.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label448.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label449.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label436.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label436.Text);
                }
                if (Label445.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label445.Text);
                }

                bal9 = custtotal / soldamt2;
                Label450.Text = bal9.ToString("N0");
            }

            Label348.Text = custotal.ToString();
            Label349.Text = custpaid.ToString();
            Double custbal = 0, kishanbal = 0, landbal1 = 0, totalbalamt = 0;
            custbal = Convert.ToDouble(Label348.Text) - Convert.ToDouble(Label349.Text);
            Label350.Text = custbal.ToString();
            Label351.Text = kishantotal.ToString();
            Label352.Text = kishanpaid.ToString();
            kishanbal = Convert.ToDouble(Label351.Text) - Convert.ToDouble(Label352.Text);
            Label353.Text = kishanbal.ToString();
            Label355.Text = landtotal.ToString();
            Label357.Text = landsold.ToString();
            landbal1 = Convert.ToDouble(Label355.Text) - Convert.ToDouble(Label357.Text);
            Label358.Text = landbal1.ToString();
            Label359.Text = totallandamt.ToString();
            Label360.Text = soldamt.ToString();
            totalbalamt = Convert.ToDouble(Label359.Text) - Convert.ToDouble(Label360.Text);

            Label361.Text = totalbalamt.ToString();
        }
        if (ar[26] == "320")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='320' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label452.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label419.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label452.Text);
                    custotal = custotal + ar1;
                }
                Label453.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label453.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label453.Text);
                    custpaid = custpaid + ar2;
                }
                Label454.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label452.Text = "0";
                Label453.Text = "0";
                Label454.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',sum(k.landamount) AS 'TOTAL',c.PAID AS 'PAID',(sum(k.landamount)-c.PAID)AS 'BAL',sum(k.saleland) from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='320' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi group by k.arazi,c.PAID", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.saleland from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("",con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label451.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label455.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label451.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label455.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label456.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label456.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label456.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label457.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label451.Text = "320";
                    Label455.Text = "0";
                    Label456.Text = "0";
                    Label457.Text = "0";
                }
            }
            else
            {
                Label451.Text = "320";
                Label455.Text = "0";
                Label456.Text = "0";
                Label457.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,salerate from newkishan where id IN(select id from newkishan where arazi='320')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label458.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label459.Text = ds2.Tables[0].Rows[0][4].ToString();
                    Double ar4 = 0;
                    if (Label459.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label459.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label460.Text = ds3.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    Label458.Text = "0";
                    Label459.Text = "0";
                    Label460.Text = "0";

                }
            }
            else
            {
                Label458.Text = "0";
                Label459.Text = "0";
                Label460.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='320' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label461.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label461.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label461.Text);
                    landsold = landsold + ar5;
                }

                saleland = Convert.ToDouble(Label461.Text);
                totalland = Convert.ToDouble(Label459.Text);
                landbal = totalland - saleland;
                Label462.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label459.Text) * Convert.ToDouble(Label460.Text);
                Label463.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label461.Text) * Convert.ToDouble(Label460.Text);
                Label464.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label463.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label463.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label464.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label464.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label465.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label452.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label452.Text);
                }
                if (Label461.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label461.Text);
                }

                bal9 = custtotal / soldamt2;
                Label466.Text = bal9.ToString("N0");


            }
            else
            {
                Label461.Text = "0";
                saleland = Convert.ToDouble(Label461.Text);
                totalland = Convert.ToDouble(Label459.Text);
                landbal = totalland - saleland;
                Label462.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label459.Text) * Convert.ToDouble(Label460.Text);
                Label463.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label461.Text) * Convert.ToDouble(Label460.Text);
                Label464.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label464.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label464.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label465.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label452.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label452.Text);
                }
                if (Label461.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label461.Text);
                }

                bal9 = custtotal / soldamt2;
                Label466.Text = bal9.ToString("N0");
            }

            Label348.Text = custotal.ToString();
            Label349.Text = custpaid.ToString();
            Double custbal = 0, kishanbal = 0, landbal1 = 0, totalbalamt = 0;
            custbal = Convert.ToDouble(Label348.Text) - Convert.ToDouble(Label349.Text);
            Label350.Text = custbal.ToString();
            Label351.Text = kishantotal.ToString();
            Label352.Text = kishanpaid.ToString();
            kishanbal = Convert.ToDouble(Label351.Text) - Convert.ToDouble(Label352.Text);
            Label353.Text = kishanbal.ToString();
            Label355.Text = landtotal.ToString();
            Label357.Text = landsold.ToString();
            landbal1 = Convert.ToDouble(Label355.Text) - Convert.ToDouble(Label357.Text);
            Label358.Text = landbal1.ToString();
            Label359.Text = totallandamt.ToString();
            Label360.Text = soldamt.ToString();
            totalbalamt = Convert.ToDouble(Label359.Text) - Convert.ToDouble(Label360.Text);

            Label361.Text = totalbalamt.ToString();
        }
        if (ar[27] == "353")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='353' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label468.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label419.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label468.Text);
                    custotal = custotal + ar1;
                }
                Label469.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label469.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label469.Text);
                    custpaid = custpaid + ar2;
                }
                Label470.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label468.Text = "0";
                Label469.Text = "0";
                Label470.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',sum(k.landamount) AS 'TOTAL',c.PAID AS 'PAID',(sum(k.landamount)-c.PAID)AS 'BAL',sum(k.saleland) from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='353' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi group by k.arazi,c.PAID", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.saleland from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("",con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label467.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label471.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label467.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label471.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label472.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label472.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label472.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label473.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label467.Text = "353";
                    Label471.Text = "0";
                    Label472.Text = "0";
                    Label473.Text = "0";
                }
            }
            else
            {
                Label467.Text = "353";
                Label471.Text = "0";
                Label472.Text = "0";
                Label473.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,salerate from newkishan where id IN(select id from newkishan where arazi='353')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label474.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label475.Text = ds2.Tables[0].Rows[0][4].ToString();
                    Double ar4 = 0;
                    if (Label475.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label475.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label476.Text = ds3.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    Label474.Text = "0";
                    Label475.Text = "0";
                    Label476.Text = "0";

                }
            }
            else
            {
                Label474.Text = "0";
                Label475.Text = "0";
                Label476.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='353' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label477.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label477.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label477.Text);
                    landsold = landsold + ar5;
                }

                saleland = Convert.ToDouble(Label477.Text);
                totalland = Convert.ToDouble(Label475.Text);
                landbal = totalland - saleland;
                Label478.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label475.Text) * Convert.ToDouble(Label476.Text);
                Label479.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label477.Text) * Convert.ToDouble(Label476.Text);
                Label480.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label479.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label479.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label480.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label480.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label481.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label468.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label468.Text);
                }
                if (Label477.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label477.Text);
                }

                bal9 = custtotal / soldamt2;
                Label482.Text = bal9.ToString("N0");


            }
            else
            {
                Label477.Text = "0";
                saleland = Convert.ToDouble(Label477.Text);
                totalland = Convert.ToDouble(Label475.Text);
                landbal = totalland - saleland;
                Label478.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label475.Text) * Convert.ToDouble(Label476.Text);
                Label479.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label477.Text) * Convert.ToDouble(Label476.Text);
                Label480.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label480.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label480.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label481.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label468.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label468.Text);
                }
                if (Label477.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label477.Text);
                }

                bal9 = custtotal / soldamt2;
                Label482.Text = bal9.ToString("N0");
            }

            Label348.Text = custotal.ToString();
            Label349.Text = custpaid.ToString();
            Double custbal = 0, kishanbal = 0, landbal1 = 0, totalbalamt = 0;
            custbal = Convert.ToDouble(Label348.Text) - Convert.ToDouble(Label349.Text);
            Label350.Text = custbal.ToString();
            Label351.Text = kishantotal.ToString();
            Label352.Text = kishanpaid.ToString();
            kishanbal = Convert.ToDouble(Label351.Text) - Convert.ToDouble(Label352.Text);
            Label353.Text = kishanbal.ToString();
            Label355.Text = landtotal.ToString();
            Label357.Text = landsold.ToString();
            landbal1 = Convert.ToDouble(Label355.Text) - Convert.ToDouble(Label357.Text);
            Label358.Text = landbal1.ToString();
            Label359.Text = totallandamt.ToString();
            Label360.Text = soldamt.ToString();
            totalbalamt = Convert.ToDouble(Label359.Text) - Convert.ToDouble(Label360.Text);

            Label361.Text = totalbalamt.ToString();
        }
        if (ar[28] == "356")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='356' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label484.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label419.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label484.Text);
                    custotal = custotal + ar1;
                }
                Label485.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label485.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label485.Text);
                    custpaid = custpaid + ar2;
                }
                Label486.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label484.Text = "0";
                Label485.Text = "0";
                Label486.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',sum(k.landamount) AS 'TOTAL',c.PAID AS 'PAID',(sum(k.landamount)-c.PAID)AS 'BAL',sum(k.saleland) from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='356' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi group by k.arazi,c.PAID", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.saleland from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("",con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label483.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label487.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label483.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label487.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label488.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label488.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label488.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label489.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label483.Text = "356";
                    Label487.Text = "0";
                    Label488.Text = "0";
                    Label489.Text = "0";
                }
            }
            else
            {
                Label483.Text = "356";
                Label487.Text = "0";
                Label488.Text = "0";
                Label489.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,salerate from newkishan where id IN(select id from newkishan where arazi='356')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label490.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label491.Text = ds2.Tables[0].Rows[0][4].ToString();
                    Double ar4 = 0;
                    if (Label491.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label491.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label492.Text = ds3.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    Label490.Text = "0";
                    Label491.Text = "0";
                    Label492.Text = "0";

                }
            }
            else
            {
                Label490.Text = "0";
                Label491.Text = "0";
                Label492.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='356' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label493.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label493.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label493.Text);
                    landsold = landsold + ar5;
                }

                saleland = Convert.ToDouble(Label493.Text);
                totalland = Convert.ToDouble(Label491.Text);
                landbal = totalland - saleland;
                Label494.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label491.Text) * Convert.ToDouble(Label492.Text);
                Label495.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label493.Text) * Convert.ToDouble(Label492.Text);
                Label496.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label495.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label495.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label496.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label496.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label497.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label484.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label484.Text);
                }
                if (Label493.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label493.Text);
                }

                bal9 = custtotal / soldamt2;
                Label498.Text = bal9.ToString("N0");


            }
            else
            {
                Label493.Text = "0";
                saleland = Convert.ToDouble(Label493.Text);
                totalland = Convert.ToDouble(Label491.Text);
                landbal = totalland - saleland;
                Label494.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label491.Text) * Convert.ToDouble(Label492.Text);
                Label495.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label493.Text) * Convert.ToDouble(Label492.Text);
                Label496.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label496.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label496.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label497.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label484.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label484.Text);
                }
                if (Label493.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label493.Text);
                }

                bal9 = custtotal / soldamt2;
                Label498.Text = bal9.ToString("N0");
            }

            Label348.Text = custotal.ToString();
            Label349.Text = custpaid.ToString();
            Double custbal = 0, kishanbal = 0, landbal1 = 0, totalbalamt = 0;
            custbal = Convert.ToDouble(Label348.Text) - Convert.ToDouble(Label349.Text);
            Label350.Text = custbal.ToString();
            Label351.Text = kishantotal.ToString();
            Label352.Text = kishanpaid.ToString();
            kishanbal = Convert.ToDouble(Label351.Text) - Convert.ToDouble(Label352.Text);
            Label353.Text = kishanbal.ToString();
            Label355.Text = landtotal.ToString();
            Label357.Text = landsold.ToString();
            landbal1 = Convert.ToDouble(Label355.Text) - Convert.ToDouble(Label357.Text);
            Label358.Text = landbal1.ToString();
            Label359.Text = totallandamt.ToString();
            Label360.Text = soldamt.ToString();
            totalbalamt = Convert.ToDouble(Label359.Text) - Convert.ToDouble(Label360.Text);

            Label361.Text = totalbalamt.ToString();
        }
        if (ar[29] == "419")
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='419' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label500.Text = ds1.Tables[0].Rows[0][0].ToString();
                Double ar1 = 0;
                if (Label419.Text == "")
                {
                    ar1 = 0;
                    custotal = custotal + ar1;
                }
                else
                {
                    ar1 = Convert.ToDouble(Label500.Text);
                    custotal = custotal + ar1;
                }
                Label501.Text = ds1.Tables[0].Rows[0][1].ToString();
                Double ar2 = 0;
                if (Label501.Text == "")
                {
                    ar2 = 0;
                    custpaid = custpaid + ar2;
                }
                else
                {
                    ar2 = Convert.ToDouble(Label501.Text);
                    custpaid = custpaid + ar2;
                }
                Label502.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label500.Text = "0";
                Label501.Text = "0";
                Label502.Text = "0";
            }
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',sum(k.landamount) AS 'TOTAL',c.PAID AS 'PAID',(sum(k.landamount)-c.PAID)AS 'BAL',sum(k.saleland) from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='419' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi group by k.arazi,c.PAID", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.saleland from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having arazi='186MI' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.arazi=c.arazi", con);
            //SqlDataAdapter da2 = new SqlDataAdapter("",con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label499.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Label503.Text = ds2.Tables[0].Rows[0][1].ToString();
                    Double ar2 = 0;
                    if (Label499.Text == "")
                    {
                        ar2 = 0;
                        kishantotal = kishantotal + ar2;
                    }
                    else
                    {
                        ar2 = Convert.ToDouble(Label503.Text);
                        kishantotal = kishantotal + ar2;
                    }
                    Label504.Text = ds2.Tables[0].Rows[0][2].ToString();
                    Double ar3 = 0;
                    if (Label504.Text == "")
                    {
                        ar3 = 0;
                        kishanpaid = kishanpaid + ar3;
                    }
                    else
                    {
                        ar3 = Convert.ToDouble(Label504.Text);
                        kishanpaid = kishanpaid + ar3;
                    }
                    Label505.Text = ds2.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Label499.Text = "419";
                    Label503.Text = "0";
                    Label504.Text = "0";
                    Label505.Text = "0";
                }
            }
            else
            {
                Label499.Text = "419";
                Label503.Text = "0";
                Label504.Text = "0";
                Label505.Text = "0";
            }
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select landsize,salerate from newkishan where id IN(select id from newkishan where arazi='419')", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label506.Text = ds3.Tables[0].Rows[0][0].ToString();
                    Label507.Text = ds2.Tables[0].Rows[0][4].ToString();
                    Double ar4 = 0;
                    if (Label507.Text == "")
                    {
                        ar4 = 0;
                        landtotal = landtotal + ar4;
                    }
                    else
                    {
                        ar4 = Convert.ToDouble(Label507.Text);
                        landtotal = landtotal + ar4;
                    }
                    Label508.Text = ds3.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    Label506.Text = "0";
                    Label507.Text = "0";
                    Label508.Text = "0";

                }
            }
            else
            {
                Label506.Text = "0";
                Label507.Text = "0";
                Label508.Text = "0";

            }
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='419' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
            if (ds5.Tables[0].Rows[0][0].ToString() != "")
            {
                Label509.Text = ds5.Tables[0].Rows[0][0].ToString();
                Double ar5 = 0;
                if (Label509.Text == "")
                {
                    ar5 = 0;
                    landsold = landsold + ar5;
                }
                else
                {
                    ar5 = Convert.ToDouble(Label509.Text);
                    landsold = landsold + ar5;
                }

                saleland = Convert.ToDouble(Label509.Text);
                totalland = Convert.ToDouble(Label507.Text);
                landbal = totalland - saleland;
                Label510.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label507.Text) * Convert.ToDouble(Label508.Text);
                Label511.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label509.Text) * Convert.ToDouble(Label508.Text);
                Label512.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label511.Text == "")
                {
                    ar6 = 0;
                    totallandamt = totallandamt + ar6;
                }
                else
                {
                    ar6 = Convert.ToDouble(Label511.Text);
                    totallandamt = totallandamt + ar6;
                }
                if (Label512.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label512.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label513.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label500.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label500.Text);
                }
                if (Label509.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label509.Text);
                }

                bal9 = custtotal / soldamt2;
                Label514.Text = bal9.ToString("N0");


            }
            else
            {
                Label509.Text = "0";
                saleland = Convert.ToDouble(Label509.Text);
                totalland = Convert.ToDouble(Label507.Text);
                landbal = totalland - saleland;
                Label510.Text = landbal.ToString();
                totalamt = Convert.ToDouble(Label507.Text) * Convert.ToDouble(Label508.Text);
                Label511.Text = totalamt.ToString();
                saleamt = Convert.ToDouble(Label509.Text) * Convert.ToDouble(Label508.Text);
                Label512.Text = saleamt.ToString();
                Double ar6 = 0, ar7 = 0;
                if (Label512.Text == "")
                {
                    ar7 = 0;
                    soldamt = soldamt + ar7;
                }
                else
                {
                    ar7 = Convert.ToDouble(Label512.Text);
                    soldamt = soldamt + ar7;
                }
                balamt = totalamt - saleamt;
                Label513.Text = balamt.ToString();
                Double custtotal = 0, soldamt2 = 0, bal9 = 0;
                if (Label500.Text == "")
                {
                    custtotal = 0;
                }
                else
                {
                    custtotal = Convert.ToDouble(Label500.Text);
                }
                if (Label509.Text == "")
                {
                    soldamt2 = 0;
                }
                else
                {
                    soldamt2 = Convert.ToDouble(Label509.Text);
                }

                bal9 = custtotal / soldamt2;
                Label514.Text = bal9.ToString("N0");
            }

            Label348.Text = custotal.ToString();
            Label349.Text = custpaid.ToString();
            Double custbal = 0, kishanbal = 0, landbal1 = 0, totalbalamt = 0;
            custbal = Convert.ToDouble(Label348.Text) - Convert.ToDouble(Label349.Text);
            Label350.Text = custbal.ToString();
            Label351.Text = kishantotal.ToString();
            Label352.Text = kishanpaid.ToString();
            kishanbal = Convert.ToDouble(Label351.Text) - Convert.ToDouble(Label352.Text);
            Label353.Text = kishanbal.ToString();
            Label355.Text = landtotal.ToString();
            Label357.Text = landsold.ToString();
            landbal1 = Convert.ToDouble(Label355.Text) - Convert.ToDouble(Label357.Text);
            Label358.Text = landbal1.ToString();
            Label359.Text = totallandamt.ToString();
            Label360.Text = soldamt.ToString();
            totalbalamt = Convert.ToDouble(Label359.Text) - Convert.ToDouble(Label360.Text);

            Label361.Text = totalbalamt.ToString();
        }



    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}