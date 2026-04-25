using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

public partial class sidebar_home : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindinv();
            bindkishan();
            bindcustomer();
            bindland();
        }
    }
    public void bindkishan()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(landamount) from newkishan where status='currently' AND arazi in(select DISTINCT arazi from deeddetails where arazi NOT IN('BANK STATEMENT','DM PERMISSION','POWER OF ATONY','OLD KISHAN DEED','AGREEMENT','CAR','UP78GR0319','Company Registration','PANI PLANT','0','1989'))", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(amount) from kishanrecipt where status='PAID' and kid IN(select id from newkishan where status='currently' AND arazi in(select DISTINCT arazi from deeddetails where arazi NOT IN('BANK STATEMENT','DM PERMISSION','POWER OF ATONY','OLD KISHAN DEED','AGREEMENT','CAR','UP78GR0319','Company Registration','PANI PLANT','0','1989'))) ", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double totalkishan = 0,paidkishan=0,balk=0;
        if (ds.Tables[0].Rows.Count > 0)
        {
           
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                totalkishan = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                totalkishan = 0;
            }
        }
        if (ds2.Tables[0].Rows.Count > 0)
        {

            if (ds2.Tables[0].Rows[0][0].ToString() != "")
            {
                paidkishan = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                paidkishan = 0;
            }
        }
        balk = totalkishan - paidkishan;
        Label5.Text = totalkishan.ToString("N0");
        Label6.Text = paidkishan.ToString("N0");
        Label7.Text = balk.ToString("N0");
    }
    public void bindcustomer()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where CUSTREGNO NOT IN(select CUSTREGNO from  wjstar1.customerreg1 where  regstatus IN('Cancel','completed')) ", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where userstatus='Active' AND CUSTREGNO NOT IN(select CUSTREGNO from  wjstar1.customerreg1 where  regstatus IN('completed'))", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double totalcust = 0, paidcust = 0, balc = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                totalcust = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                totalcust = 0;
            }
        }
        if (ds2.Tables[0].Rows.Count > 0)
        {

            if (ds2.Tables[0].Rows[0][0].ToString() != "")
            {
                paidcust = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                paidcust = 0;
            }
        }
        balc = totalcust - paidcust;
        Label8.Text = totalcust.ToString("N0");
        Label9.Text = paidcust.ToString("N0");
        Label10.Text = balc.ToString("N0");
    }
    public void bindland()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select AVG(salerate) from newkishan where arazi in(select DISTINCT arazi from deeddetails where arazi NOT IN('BANK STATEMENT','DM PERMISSION','POWER OF ATONY','OLD KISHAN DEED','AGREEMENT','CAR','UP78GR0319','Company Registration','PANI PLANT','0','1989'))", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select sum(land)-sum(road) AS 'sale' from deeddetails where id in(select max(id) from deeddetails  group by deedno,arazi)", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(plotsize) from wjstar1.customerreg1 where CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where  regstatus in('Cancel')) AND APPNO IN (select arazi from deeddetails where id in(select max(id) from deeddetails where arazi NOT IN('BANK STATEMENT','DM PERMISSION','POWER OF ATONY','OLD KISHAN DEED','AGREEMENT','CAR','UP78GR0319','Company Registration','PANI PLANT','0','1989')  group by deedno,arazi)) ", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double totalland = 0, saleland = 0, balland = 0,salerate=0,ballandvalue=0;
        if (ds.Tables[0].Rows.Count > 0)
        {

           
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                salerate = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                salerate = 0;
            }
        }
        if (ds3.Tables[0].Rows.Count > 0)
        {

            if (ds3.Tables[0].Rows[0][0].ToString() != "")
            {
                totalland = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                totalland = 0;
            }
           
        }
        if (ds2.Tables[0].Rows.Count > 0)
        {

            if (ds2.Tables[0].Rows[0][0].ToString() != "")
            {
                saleland = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                saleland = 0;
            }
        }
       
        balland = totalland - saleland;
        ballandvalue = balland * salerate;
        Label11.Text = totalland.ToString("N0");
        Label12.Text = saleland.ToString("N0");
        Label13.Text = balland.ToString("N0");
        Label15.Text =ballandvalue.ToString("N0");
    }
    public void bindinv()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(totalinvestamt) from newinvester where invid in(select invid from invdetails) AND status='currently'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select sum(returnamt-totalinvestamt) from newinvester where invid in(select invid from invdetails) AND returnamt!=0 AND status='currently'", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(amount) from investerrecipt where  bpaid=0 AND status='PAID' AND type='RETURN' AND invid IN(select invid from invdetails where invid not in(select invid from monthinvdetails ) AND invid not in(select invid from newinvester where status='completed' ) )", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Double totalinv = 0, returnprofit = 0,total=0,retn=0;
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                totalinv = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                totalinv = 0;
            }
            if (ds3.Tables[0].Rows[0][0].ToString() != "")
            {
                retn = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                retn = 0;
            }
            returnprofit = retn;
            total = totalinv + returnprofit;
            Label1.Text = totalinv.ToString("N0");
            Label2.Text = returnprofit.ToString("N0");
            Label14.Text = total.ToString("N0");
            Double paid = 0,bal=0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
               
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    paid = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    paid = 0;
                }
                Label3.Text = paid.ToString("N0");
                bal = total - paid;
                Label4.Text=bal.ToString("N0");
            }
        }
    }
}