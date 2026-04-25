using System;
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

using System.Text;

public partial class kishanarazipayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public static DataTable data = new DataTable();
    public DataRow dr1;
    public static DataTable data1 = new DataTable();
    public DataRow dr2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // invester();
			bindinv();
            DropDownList1.Items.Clear();
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT toarazi from kishanarazi", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close(); 
            DropDownList1.Items.Add("---select---");

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
    public void bindcustomer()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where CUSTREGNO NOT IN(select CUSTREGNO from  wjstar1.customerreg1 where  regstatus IN('Cancel')) ", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where userstatus='Active'", con);
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
        Label348.Text = totalcust.ToString("N0");
        Label349.Text = paidcust.ToString("N0");
        Label350.Text = balc.ToString("N0");
        bindkishan();
        bindland();
    }
    public void bindland()
    {
        Double landsold = 0, landsale = 0, landrate = 0,deedtotal=0;
         SqlConnection con = new SqlConnection(s);
       con.Open();
       SqlDataAdapter da6 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO IN(select distinct fromarazi from kishanarazi) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds6 = new DataSet();
                da6.Fill(ds6);
                con.Close();
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    if (ds6.Tables[0].Rows[0][0].ToString() != "")
                    {
                        landsold =Convert.ToDouble(ds6.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        landsold =0;

                    }
                }
                else
                {
                    landsold =0;

                }

            
            con.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("select sum(totalland)-sum(road) as 'sale',avg(rate) from kishanarazi", con);
            // SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con.Close();
            if (ds4.Tables[0].Rows.Count > 0)
            {
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    landsale =Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    landsale = 0;

                }
                if (ds4.Tables[0].Rows[0][1].ToString() != "")
                {
                    landrate = Convert.ToDouble(ds4.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    landrate = 0;

                }
            }
            else
            {
                landsale = 0;
                landrate = 0;

            }
         con.Open();
         SqlDataAdapter da3 = new SqlDataAdapter("select sum(land) as 'pur' from deeddetails where id in(select max(id) from deeddetails where arazi in(select distinct fromarazi from kishanarazi)  group by deedno)", con);
                // SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                con.Close();
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    if (ds3.Tables[0].Rows[0][0].ToString() != "")
                    {
                        deedtotal= Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        deedtotal = 0;

                    }
                }
                else
                {
                    deedtotal = 0;

                }
                Label390.Text = deedtotal.ToString("N0");
                Label355.Text = landsale.ToString("N0");
                Label357.Text = landsold.ToString("N0");
                Label358.Text =(landsale-landsold).ToString("N0");
                Label359.Text =(landsale*landrate).ToString("N0");
                Label360.Text = (landsold*landrate).ToString("N0");
                Label361.Text = ((landsale - landsold)*landrate).ToString("N0");
               Double result = ((landsale * landrate) / landsold) * 1800;
                Label383.Text = ((landsale * landrate) / landsold).ToString("N0");
                Label384.Text = result.ToString("N0");

    }
    public void bindkishan()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(landamount) from newkishan where status='currently' AND arazi in(select DISTINCT arazi from deeddetails where arazi NOT IN('BANK STATEMENT','DM PERMISSION','POWER OF ATONY','OLD KISHAN DEED','AGREEMENT','CAR','UP78GR0319','Company Registration','PANI PLANT'))", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(amount) from kishanrecipt where status='PAID' and kid IN(select id from newkishan where status='currently' AND arazi in(select DISTINCT arazi from deeddetails where arazi NOT IN('BANK STATEMENT','DM PERMISSION','POWER OF ATONY','OLD KISHAN DEED','AGREEMENT','CAR','UP78GR0319','Company Registration','PANI PLANT'))) ", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double totalkishan = 0, paidkishan = 0, balk = 0;
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
        Label351.Text = totalkishan.ToString("N0");
        Label352.Text = paidkishan.ToString("N0");
        Label353.Text = balk.ToString("N0");
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
            Label378.Text = totalinv.ToString("N0");
            Label381.Text = returnprofit.ToString("N0");
            Label379.Text = total.ToString("N0");
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
                Label380.Text = paid.ToString("N0");
                bal = total - paid;
                Label389.Text=bal.ToString("N0");
            }
        }
    }

    public void Clear1()
    {
        Label2.Text = ""; Label3.Text = ""; Label4.Text = ""; Label5.Text = ""; Label6.Text = ""; Label7.Text = ""; Label8.Text = ""; Label9.Text = ""; Label10.Text = ""; Label11.Text = ""; Label12.Text = ""; Label13.Text = ""; Label14.Text = ""; Label15.Text = ""; Label16.Text = ""; Label382.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        Panel1.Visible = true;
        Panel2.Visible = false;
        SqlConnection con = new SqlConnection(s);
       // con.Open();
        Double custtotal1 = 0, custpaid1 = 0, custbal1 = 0, kishantotal = 0, kishanpaid = 0, kishanbal = 0, deedtotal = 0, landsale = 0, landrate = 0, landsold=0;
        if (DropDownList1.Text != "")
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT fromarazi from kishanarazi where toarazi='"+DropDownList1.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

           

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + ds.Tables[0].Rows[i][0].ToString() + "' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][0].ToString() != "")
                    {
                        custtotal1 = custtotal1 + Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                       
                    }
                    else
                    {
                        custtotal1 = custtotal1 + 0;
                    }
                    if (ds1.Tables[0].Rows[0][1].ToString() != "")
                    {
                       
                        custpaid1 = custpaid1 + Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
                       
                    }
                    else
                    {
                        custpaid1 = custpaid1 + 0;
                    }
                    if (ds1.Tables[0].Rows[0][2].ToString() != "")
                    {
                       
                        custbal1 = custbal1 + Convert.ToDouble(ds1.Tables[0].Rows[0][2].ToString());
                    }
                    else
                    {
                        custbal1 = custbal1 + 0;
                    }
                }
                else
                {
                    custbal1 = custbal1 + 0;
                    custpaid1 = custpaid1 + 0;
                    custtotal1 = custtotal1 + 0;
                }
                con.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi,sum(k.landamount),r.PAID AS 'PAID',(SUM(k.landamount)-r.PAID)AS 'BAL' from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having  arazi='" + ds.Tables[0].Rows[i][0].ToString() + "' AND status='PAID') AS r inner join newkishan k on k.arazi=r.arazi where  k.arazi='" + ds.Tables[0].Rows[i][0].ToString() + "' group by k.arazi,r.PAID", con);
                // SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='" + DropDownList1.Text + "' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                con.Close();
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds2.Tables[0].Rows[0][1].ToString() != "")
                    {
                        kishantotal = kishantotal + Convert.ToDouble(ds2.Tables[0].Rows[0][1].ToString());
                       
                    }
                    else
                    {
                        kishantotal = kishantotal + 0;
                    }
                    if (ds2.Tables[0].Rows[0][2].ToString() != "")
                    {
                        kishanpaid = kishanpaid + Convert.ToDouble(ds2.Tables[0].Rows[0][2].ToString());

                    }
                    else
                    {
                        kishanpaid = kishanpaid + 0;
                    }
                    
                }
                else
                {
                    kishanpaid = kishanpaid + 0;
                    kishantotal = kishantotal + 0;
                }

                //land details

                con.Open();
                SqlDataAdapter da3 = new SqlDataAdapter("select sum(land) as 'pur' from deeddetails where id in(select max(id) from deeddetails where arazi='" + ds.Tables[0].Rows[i][0].ToString() + "'  group by deedno)", con);
                // SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                con.Close();
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    if (ds3.Tables[0].Rows[0][0].ToString() != "")
                    {
                        deedtotal = deedtotal + Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        deedtotal = deedtotal + 0;

                    }
                }
                else
                {
                    deedtotal = deedtotal + 0;

                }
                con.Open();
                SqlDataAdapter da6 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='" + ds.Tables[0].Rows[i][0].ToString() + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds6 = new DataSet();
                da6.Fill(ds6);
                con.Close();
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    if (ds6.Tables[0].Rows[0][0].ToString() != "")
                    {
                        landsold = landsold + Convert.ToDouble(ds6.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        landsold = landsold + 0;

                    }
                }
                else
                {
                    landsold = landsold + 0;

                }

            }
            con.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("select sum(totalland)-sum(road) as 'sale',sum(rate) from kishanarazi where toarazi='" + DropDownList1.Text + "'", con);
            // SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con.Close();
            if (ds4.Tables[0].Rows.Count > 0)
            {
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    landsale =Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    landsale = 0;

                }
                if (ds4.Tables[0].Rows[0][1].ToString() != "")
                {
                    landrate = Convert.ToDouble(ds4.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    landrate = 0;

                }
            }
            else
            {
                landsale = 0;
                landrate = 0;

            }
            kishanbal = kishantotal - kishanpaid;
            Label2.Text = DropDownList1.Text;
            Label3.Text = custtotal1.ToString("N0");
            Label4.Text = custpaid1.ToString("N0");
            Label5.Text = custbal1.ToString("N0");
            Label6.Text = kishantotal.ToString("N0");
            Label7.Text = kishanpaid.ToString("N0");
            Label8.Text = kishanbal.ToString("N0");
            Label9.Text = deedtotal.ToString("N0");
            Label10.Text = landsale.ToString("N0");
            Label11.Text = landrate.ToString("N0");
          
           

            
                Label12.Text = landsold.ToString("N0");
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
        Label390.Text = "0";
        Label361.Text = "0";
        
    }
    public void cal(String arazi)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
        SqlConnection con = new SqlConnection(s);
        // con.Open();
        dr1 = data.NewRow();
        Double custtotal1 = 0, custpaid1 = 0, custbal1 = 0, kishantotal = 0, kishanpaid = 0, kishanbal = 0, deedtotal = 0, landsale = 0, landrate = 0, landsold = 0;
        if (arazi != "")
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT fromarazi from kishanarazi where toarazi='" + arazi + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();



            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + ds.Tables[0].Rows[i][0].ToString() + "' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][0].ToString() != "")
                    {
                        custtotal1 = custtotal1 + Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());

                    }
                    else
                    {
                        custtotal1 = custtotal1 + 0;
                    }
                    if (ds1.Tables[0].Rows[0][1].ToString() != "")
                    {

                        custpaid1 = custpaid1 + Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());

                    }
                    else
                    {
                        custpaid1 = custpaid1 + 0;
                    }
                    if (ds1.Tables[0].Rows[0][2].ToString() != "")
                    {

                        custbal1 = custbal1 + Convert.ToDouble(ds1.Tables[0].Rows[0][2].ToString());
                    }
                    else
                    {
                        custbal1 = custbal1 + 0;
                    }
                }
                else
                {
                    custbal1 = custbal1 + 0;
                    custpaid1 = custpaid1 + 0;
                    custtotal1 = custtotal1 + 0;
                }
                con.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi,sum(k.landamount),r.PAID AS 'PAID',(SUM(k.landamount)-r.PAID)AS 'BAL' from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having  arazi='" + ds.Tables[0].Rows[i][0].ToString() + "' AND status='PAID') AS r inner join newkishan k on k.arazi=r.arazi where  k.arazi='" + ds.Tables[0].Rows[i][0].ToString() + "' group by k.arazi,r.PAID", con);
                // SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='" + DropDownList1.Text + "' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                con.Close();
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds2.Tables[0].Rows[0][1].ToString() != "")
                    {
                        kishantotal = kishantotal + Convert.ToDouble(ds2.Tables[0].Rows[0][1].ToString());

                    }
                    else
                    {
                        kishantotal = kishantotal + 0;
                    }
                    if (ds2.Tables[0].Rows[0][2].ToString() != "")
                    {
                        kishanpaid = kishanpaid + Convert.ToDouble(ds2.Tables[0].Rows[0][2].ToString());

                    }
                    else
                    {
                        kishanpaid = kishanpaid + 0;
                    }

                }
                else
                {
                    kishanpaid = kishanpaid + 0;
                    kishantotal = kishantotal + 0;
                }

                //land details

                con.Open();
                SqlDataAdapter da3 = new SqlDataAdapter("select sum(land) as 'pur' from deeddetails where id in(select max(id) from deeddetails where arazi='" + ds.Tables[0].Rows[i][0].ToString() + "'  group by deedno)", con);
                // SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                con.Close();
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    if (ds3.Tables[0].Rows[0][0].ToString() != "")
                    {
                        deedtotal = deedtotal + Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        deedtotal = deedtotal + 0;

                    }
                }
                else
                {
                    deedtotal = deedtotal + 0;

                }
                con.Open();
                SqlDataAdapter da6 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='" + ds.Tables[0].Rows[i][0].ToString() + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds6 = new DataSet();
                da6.Fill(ds6);
                con.Close();
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    if (ds6.Tables[0].Rows[0][0].ToString() != "")
                    {
                        landsold = landsold + Convert.ToDouble(ds6.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        landsold = landsold + 0;

                    }
                }
                else
                {
                    landsold = landsold + 0;

                }

            }
            con.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("select sum(totalland)-sum(road) as 'sale',sum(rate) from kishanarazi where toarazi='" + arazi + "'", con);
            // SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con.Close();
            if (ds4.Tables[0].Rows.Count > 0)
            {
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    landsale = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    landsale = 0;

                }
                if (ds4.Tables[0].Rows[0][1].ToString() != "")
                {
                    landrate = Convert.ToDouble(ds4.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    landrate = 0;

                }
            }
            else
            {
                landsale = 0;
                landrate = 0;

            }
            kishanbal = kishantotal - kishanpaid;
            dr1["toarazi"] = arazi;
            dr1["CUS_Total"] = custtotal1.ToString("N0");
            dr1["CUS_Paid"] = custpaid1.ToString("N0");
            dr1["CUS_Balance"] = custbal1.ToString("N0");
            dr1["KIS_Total"] = kishantotal.ToString("N0");
            dr1["KIS_Paid"] = kishanpaid.ToString("N0");
            dr1["KIS_Bal"] = kishanbal.ToString("N0");
            dr1["TOTAL_DEED"] = deedtotal.ToString("N0");
            dr1["LAN_Sale"] = landsale.ToString("N0");
            dr1["LAN_Rate"] = landrate.ToString("N0");




            dr1["LAN_Sold"] = landsold.ToString("N0");
            Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
            saleland = landsold;
            totalland = landsale;
            landbal = totalland - saleland;
            dr1["LAN_Bal"] = landbal.ToString();
            totalamt = landsale * landrate;
            dr1["Total_AMT"] = totalamt.ToString();
            saleamt = landsold * landrate;
            dr1["Sold_AMT"] = saleamt.ToString();
            balamt = totalamt - saleamt;
            dr1["Bal_AMT"] = balamt.ToString();
            Double  bal9 = 0;


            bal9 = custtotal1 / landsold;

            dr1["Avg_AMT"] = bal9.ToString("N0");


            data.Rows.Add(dr1);

        }
    }
                                

       

    
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        data.Clear();
        // fresh.Clear();
        for (int col = data.Columns.Count - 1; col >= 0; col--)
        {

            data.Columns.RemoveAt(col);
        }
        data.Columns.AddRange(new DataColumn[16] { new DataColumn("toarazi", typeof(string)),new DataColumn("CUS_Total", typeof(string)),new DataColumn("CUS_Paid", typeof(string)),
                            new DataColumn("CUS_Balance",typeof(string)),new DataColumn("KIS_Total",typeof(string)),new DataColumn("KIS_Paid", typeof(string)),new DataColumn("KIS_Bal", typeof(string)) ,new DataColumn("TOTAL_DEED",typeof(string)),new DataColumn("LAN_Sale",typeof(string)),new DataColumn("LAN_Rate",typeof(string)),new DataColumn("LAN_Sold",typeof(string)),new DataColumn("LAN_Bal",typeof(string)),new DataColumn("Total_AMT",typeof(string)),new DataColumn("Sold_AMT",typeof(string)),new DataColumn("Bal_AMT",typeof(string)),new DataColumn("Avg_AMT",typeof(string))});
        dr1 = data.NewRow();
        dr1 = null;
        Panel1.Visible = false;
        Panel2.Visible = true;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT toarazi from kishanarazi", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
       // DropDownList1.Items.Add("---select---");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cal(ds.Tables[0].Rows[i][0].ToString());
        }
        GridView1.DataSource = data;
        GridView1.DataBind();
        bindcustomer();




    }
	
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            data1.Clear();
            // fresh.Clear();
            for (int col = data1.Columns.Count - 1; col >= 0; col--)
            {

                data1.Columns.RemoveAt(col);
            }
            data1.Columns.AddRange(new DataColumn[16] { new DataColumn("fromarazi", typeof(string)),new DataColumn("CUS_Total", typeof(string)),new DataColumn("CUS_Paid", typeof(string)),
                            new DataColumn("CUS_Balance",typeof(string)),new DataColumn("KIS_Total",typeof(string)),new DataColumn("KIS_Paid", typeof(string)),new DataColumn("KIS_Bal", typeof(string)) ,new DataColumn("TOTAL_DEED",typeof(string)),new DataColumn("LAN_Sale",typeof(string)),new DataColumn("LAN_Rate",typeof(string)),new DataColumn("LAN_Sold",typeof(string)),new DataColumn("LAN_Bal",typeof(string)),new DataColumn("Total_AMT",typeof(string)),new DataColumn("Sold_AMT",typeof(string)),new DataColumn("Bal_AMT",typeof(string)),new DataColumn("Avg_AMT",typeof(string))});
            dr2 = data1.NewRow();
            dr2 = null;
            SqlConnection con = new SqlConnection(s);
            
            string ar = e.Row.Cells[1].Text.ToString();
            GridView gv = (GridView)e.Row.FindControl("GridView2");

           
            if (ar != "")
            {
                con.Open();
                dr2 = data1.NewRow();
                SqlDataAdapter da = new SqlDataAdapter("select DISTINCT fromarazi from kishanarazi where toarazi='" +ar + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();



                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                  Double  custtotal1 = 0, custpaid1 = 0, custbal1 = 0, kishantotal = 0, kishanpaid = 0, kishanbal = 0, deedtotal = 0, landsale = 0, landrate = 0, landsold = 0;
                  con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT) AS 'TOTAL',SUM(r.PAID) AS 'PAID',(SUM(c.CONSAMOUNT)-SUM(r.PAID)) AS 'BAl' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + ds.Tables[0].Rows[i][0].ToString() + "' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows[0][0].ToString() != "")
                        {
                            custtotal1 =Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());

                        }
                        else
                        {
                            custtotal1 =  0;
                        }
                        if (ds1.Tables[0].Rows[0][1].ToString() != "")
                        {

                            custpaid1 =  Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());

                        }
                        else
                        {
                            custpaid1 = 0;
                        }
                        if (ds1.Tables[0].Rows[0][2].ToString() != "")
                        {

                            custbal1 = Convert.ToDouble(ds1.Tables[0].Rows[0][2].ToString());
                        }
                        else
                        {
                            custbal1 =0;
                        }
                    }
                    else
                    {
                        custbal1 = 0;
                        custpaid1 = 0;
                        custtotal1 =0;
                    }
                    dr2["CUS_Total"] = custtotal1.ToString("N0");
                    dr2["CUS_Paid"] = custpaid1.ToString("N0");
                    dr2["CUS_Balance"] = custbal1.ToString("N0");
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi,sum(k.landamount),r.PAID AS 'PAID',(SUM(k.landamount)-r.PAID)AS 'BAL' from (select arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY arazi,status  Having  arazi='" + ds.Tables[0].Rows[i][0].ToString() + "' AND status='PAID') AS r inner join newkishan k on k.arazi=r.arazi where  k.arazi='" + ds.Tables[0].Rows[i][0].ToString() + "' group by k.arazi,r.PAID", con);
                    // SqlDataAdapter da2 = new SqlDataAdapter("select k.arazi AS 'ARAZI',k.landamount AS 'TOTAL',c.PAID AS 'PAID',(k.landamount-c.PAID)AS 'BAL',k.id from (select kid,arazi,sum(amount) AS 'PAID' from kishanrecipt  GROUP BY kid,arazi,status  Having arazi='" + DropDownList1.Text + "' AND status='PAID') AS c INNER JOIN newkishan AS k ON k.id=c.kid", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    con.Close();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        if (ds2.Tables[0].Rows[0][1].ToString() != "")
                        {
                            kishantotal =Convert.ToDouble(ds2.Tables[0].Rows[0][1].ToString());

                        }
                        else
                        {
                            kishantotal = 0;
                        }
                        if (ds2.Tables[0].Rows[0][2].ToString() != "")
                        {
                            kishanpaid = Convert.ToDouble(ds2.Tables[0].Rows[0][2].ToString());

                        }
                        else
                        {
                            kishanpaid = 0;
                        }

                    }
                    else
                    {
                        kishanpaid =0;
                        kishantotal = 0;
                    }
                    kishanbal = kishantotal - kishanpaid;
                    dr2["KIS_Total"] = kishantotal.ToString("N0");
                    dr2["KIS_Paid"] = kishanpaid.ToString("N0");
                    dr2["KIS_Bal"] = kishanbal.ToString("N0");
                    //land details

                    con.Open();
                    SqlDataAdapter da3 = new SqlDataAdapter("select sum(land) as 'pur' from deeddetails where id in(select max(id) from deeddetails where arazi='" + ds.Tables[0].Rows[i][0].ToString() + "'  group by deedno)", con);
                    // SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    con.Close();
                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        if (ds3.Tables[0].Rows[0][0].ToString() != "")
                        {
                            deedtotal =Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            deedtotal = 0;

                        }
                    }
                    else
                    {
                        deedtotal = 0;

                    }
                    dr2["TOTAL_DEED"] = deedtotal.ToString("N0");
                    con.Open();
                    SqlDataAdapter da6 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='" + ds.Tables[0].Rows[i][0].ToString() + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);
                    con.Close();
                    if (ds6.Tables[0].Rows.Count > 0)
                    {
                        if (ds6.Tables[0].Rows[0][0].ToString() != "")
                        {
                            landsold = Convert.ToDouble(ds6.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            landsold =0;

                        }
                    }
                    else
                    {
                        landsold =0;

                    }

                    dr2["LAN_Sold"] = landsold.ToString("N0");
                    con.Open();
                    SqlDataAdapter da4 = new SqlDataAdapter("select sum(totalland)-sum(road) as 'sale',sum(rate) from kishanarazi where fromarazi='" + ds.Tables[0].Rows[i][0].ToString() + "'", con);
                    // SqlDataAdapter da3 = new SqlDataAdapter("select landsize,saleland,salerate from newkishan where id IN(select id from newkishan where arazi='" + DropDownList1.Text + "')", con);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);
                    con.Close();
                    if (ds4.Tables[0].Rows.Count > 0)
                    {
                        if (ds4.Tables[0].Rows[0][0].ToString() != "")
                        {
                            landsale = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            landsale = 0;

                        }
                        if (ds4.Tables[0].Rows[0][1].ToString() != "")
                        {
                            landrate = Convert.ToDouble(ds4.Tables[0].Rows[0][1].ToString());
                        }
                        else
                        {
                            landrate = 0;

                        }
                    }
                    else
                    {
                        landsale = 0;
                        landrate = 0;

                    }
                    dr2["LAN_Sale"] = landsale.ToString("N0");
                    dr2["LAN_Rate"] = landrate.ToString("N0");
                    dr2["fromarazi"] = ds.Tables[0].Rows[i][0].ToString();
                   
                 




              
                    Double totalland = 0, saleland = 0, landbal = 0, totalamt = 0, saleamt = 0, balamt = 0;
                    saleland = landsold;
                    totalland = landsale;
                    landbal = totalland - saleland;

                    dr2["LAN_Bal"] = landbal.ToString();
                    totalamt = landsale * landrate;
                    dr2["Total_AMT"] = totalamt.ToString();
                    saleamt = landsold * landrate;
                    dr2["Sold_AMT"] = saleamt.ToString();
                    balamt = totalamt - saleamt;
                    dr2["Bal_AMT"] = balamt.ToString();
                    Double bal9 = 0;


                    bal9 = custtotal1 / landsold;

                    dr2["Avg_AMT"] = bal9.ToString("N0"); 
                    data1.Rows.Add(dr2);
                    dr2 = data1.NewRow();

                }
                              




            }








            gv.DataSource = data1;
            gv.DataBind();

        }
    }
}