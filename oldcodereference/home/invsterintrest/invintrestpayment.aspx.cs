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


public partial class invsterintrest_invintrestpayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
   public String st;
   public static int total;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindl3();
        }
    }
    public void bindl3()
    {

        DropDownList3.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid,ivname from newintinvester", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList3.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString() + "---" + ds.Tables[0].Rows[i][1].ToString());
        }

    }
    public void fetch()
    {
        string kid = TextBox1.Text;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid,intrest,date from newintinvester where invid='" + kid + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        Double intr;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                kid = " ";
                intr = 0;
                kid = ds.Tables[0].Rows[0][0].ToString();
                intr = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                st = Convert.ToDateTime(ds.Tables[0].Rows[0][2].ToString()).ToString("dd/MM/yyyy");
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("select year(date) from intinvesterrecipt where invid='" + kid + "'", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][0].ToString() != "")
                    {

                        cal(kid, intr);

                    }
                    else
                    {
                        Label14.Text = "please enter correct id";
                    }
                }
            }
        }
    }
    public string start1, enddate1, date1, date2;
    public void cal(string kid, Double intrest)
    {
        DataTable dt5 = new DataTable();
        dt5.Columns.AddRange(new DataColumn[16] { 
            new DataColumn("invrecipt", typeof(string)),
            new DataColumn("type", typeof(string)),
            new DataColumn("date",typeof(string)),
             new DataColumn("cramount", typeof(int)),
            new DataColumn("dramount", typeof(int)),
             new DataColumn("wallet", typeof(int)),
             new DataColumn("total", typeof(int)),
         new DataColumn("bal", typeof(int)),
            new DataColumn("paymod", typeof(string)),
             new DataColumn("chequedate", typeof(string)),
              new DataColumn("chequeno", typeof(string)),
             new DataColumn("status", typeof(string)),
              new DataColumn("days", typeof(int)),
            new DataColumn("intrest", typeof(int)),
            new DataColumn("month", typeof(string)),
                  new DataColumn("reason", typeof(string))
        });
        DataRow dr5 = dt5.NewRow();
        dr5 = dt5.NewRow();
        start1 = "";
        enddate1 = "";
        date1 = "";
        date2 = "";
        if (DropDownList1.Text == "DATEWISE")
        {
            string mode = "";
            string s2 = TextBox2.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string kdate1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox3.Text;
            string dd1 = s3.Substring(0, 2);
            int dd3 = Convert.ToInt32(dd1);

            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string ldate2 = mm1 + "/" + dd1 + "/" + yy1;


            date1 = kdate1;
            // int daysinmonth = DateTime.DaysInMonth(yy1, mm1);
            date2 = ldate2;
            enddate1 = mm1 + "/" + dd1 + "/" + yy1;
            start1 = mm + "/" + dd + "/" + yy;
            finddata(kid, intrest);
        }
        else
        {
            if (DropDownList1.Text == "ALL DETAILS MONTHWISE")
            {
                string mode = "";
                string s2 = st;
                string dd = s2.Substring(0, 2);
                string mm = s2.Substring(3, 2);
                string yy = s2.Substring(6, 4);
                string kdate1 = mm + "/" + dd + "/" + yy;
                /*DateTime datetab = DateTime.Today;
                string s3 = datetab.ToString("dd/MM/yyyy");
                string dd1 = s3.Substring(0, 2);
                string mm1 = s3.Substring(3, 2);
                string yy1 = s3.Substring(6, 4);
                string ldate2 = mm1 + "/" + dd1 + "/" + yy1;


                date1 = kdate1;
                // int daysinmonth = DateTime.DaysInMonth(yy1, mm1);
                date2 = ldate2;
                enddate1 = mm1 + "/" + dd1 + "/" + yy1;*/
                // start1 = mm + "/" + dd + "/" + yy;
                DateTime Date11 = new DateTime(Convert.ToInt32(yy), Convert.ToInt32(mm), Convert.ToInt32(dd), 0, 0, 0);
                //  DateTime Date2 = new DateTime(2022, 07, 18, 0, 0, 0);
                DateTime Date2 = DateTime.Now;
                int months = (Date2.Year - Date11.Year) * 12 + Date2.Month - Date11.Month;
                date1 = Date11.ToString();
                start1 = Date11.ToString();
                DateTime end, temp, pr;
                DataTable dt6;
                int balwallet = 0;
                for (int d = 1; d <= months; d++)
                {
                    int last = 1, sum = 0, lastamount = 0, usewallet = 0;
                    end = Date11.AddMonths(last);
                    date2 = end.ToString();
                    enddate1 = end.ToString();
                    dt6 = null;
                    dt6 = finddata(kid, intrest);

                    dr5 = null;
                    dr5 = dt5.NewRow();
                    for (int r = 0; r < dt6.Rows.Count; r++)
                    {
                        dr5["invrecipt"] = dt6.Rows[r][0].ToString();
                        dr5["type"] = dt6.Rows[r][1].ToString();
                        dr5["date"] = dt6.Rows[r][2].ToString();
                        dr5["cramount"] = dt6.Rows[r][3].ToString();
                        dr5["dramount"] = dt6.Rows[r][4].ToString();
                        usewallet = usewallet + Convert.ToInt32(dt6.Rows[r][5].ToString());
                        dr5["wallet"] = dt6.Rows[r][5].ToString();
                        dr5["total"] = dt6.Rows[r][6].ToString();
                        dr5["bal"] = dt6.Rows[r][7].ToString();
                        dr5["paymod"] = dt6.Rows[r][8].ToString();
                        dr5["chequedate"] = dt6.Rows[r][9].ToString();
                        dr5["chequeno"] = dt6.Rows[r][10].ToString();
                        dr5["status"] = dt6.Rows[r][11].ToString();
                        dr5["days"] = dt6.Rows[r][12].ToString();
                        dr5["intrest"] = dt6.Rows[r][13].ToString();
                        dr5["month"] = dt6.Rows[r][14].ToString();
                        dr5["reason"] = dt6.Rows[r][15].ToString();
                        dt5.Rows.Add(dr5);
                        dr5 = dt5.NewRow();
                        if (r == dt6.Rows.Count - 1)
                        {
                            lastamount = Convert.ToInt32(dt6.Rows[r][7].ToString());
                        }

                    }

                    dr5["invrecipt"] = "FINAL";
                    dr5["type"] = "BAL.AMT.";
                    dr5["date"] = null;
                    dr5["cramount"] = 0;
                    dr5["dramount"] = 0;
                    // usewallet = usewallet + Convert.ToInt32(dt6.Rows[r][5].ToString());
                    dr5["wallet"] = 0;
                    dr5["total"] = 0;
                    dr5["bal"] = lastamount.ToString();
                    dr5["paymod"] = "";
                    dr5["chequedate"] = "1/1/1900 12:00:00 AM";
                    dr5["chequeno"] = "";
                    dr5["status"] = "";
                    dr5["days"] = 0;
                    dr5["intrest"] = 0;
                    int tl = balwallet + total;
                    int ry = balwallet;
                    dr5["month"] = "";

                    balwallet = balwallet + total - usewallet;
                    dr5["reason"] = "Back - " + ry + "  Month - " + total.ToString() + "  Total Wallet -" + (tl).ToString() + "  Use - " + usewallet.ToString() + "  Bal - " + balwallet.ToString();
                    dt5.Rows.Add(dr5);
                    temp = end;
                    Date11 = temp;
                    date1 = Date11.ToString();
                    start1 = Date11.ToString();
                }
                GridView1.DataSource = dt5;
                GridView1.DataBind();
            }
            else
            {
                if (DropDownList1.Text == "ALL DETAILS")
                {
                    string mode = "";
                    string s2 = st;
                    string dd = s2.Substring(0, 2);
                    string mm = s2.Substring(3, 2);
                    string yy = s2.Substring(6, 4);
                    string kdate1 = mm + "/" + dd + "/" + yy;
                    DateTime datetab = DateTime.Today;
                    string s3 = datetab.ToString("dd/MM/yyyy");
                    string dd1 = s3.Substring(0, 2);
                    string mm1 = s3.Substring(3, 2);
                    string yy1 = s3.Substring(6, 4);
                    string ldate2 = mm1 + "/" + dd1 + "/" + yy1;


                    date1 = kdate1;
                    // int daysinmonth = DateTime.DaysInMonth(yy1, mm1);
                    date2 = ldate2;
                    enddate1 = mm1 + "/" + dd1 + "/" + yy1;
                    start1 = mm + "/" + dd + "/" + yy;
                   // finddata(kid, intrest);
                    Double rec = 0, ret = 0;
                    SqlConnection con = new SqlConnection(s);
                    DataTable dt = new DataTable();

                    dt.Columns.AddRange(new DataColumn[12] { 
            new DataColumn("invrecipt", typeof(string)),
            new DataColumn("type", typeof(string)),
            new DataColumn("date",typeof(string)),
            new DataColumn("amount", typeof(int)),
            new DataColumn("dramount", typeof(int)),
             new DataColumn("wallet", typeof(int)),
             new DataColumn("total", typeof(int)),
            new DataColumn("paymod", typeof(string)),
             new DataColumn("chequedate", typeof(string)),
              new DataColumn("chequeno", typeof(string)),
             new DataColumn("status", typeof(string)),
                  new DataColumn("reason", typeof(string))
           
            
        });

                    con.Open();
                    // SqlDataAdapter da1 = new SqlDataAdapter("select amount,dramount,type,date,status,wallet from intinvesterrecipt where invid='" + kid + "' AND date between '" + date1 + "' AND '" + date2 + "' AND status='PAID' order by date", con);
                    SqlDataAdapter da1 = new SqlDataAdapter("select invrecipt,date,type,amount,dramount,wallet,paymode,chekdate,chkno,status,reason from intinvesterrecipt  where invid='" + kid + "' AND date between '" + date1 + "' AND '" + date2 + "' AND status='PAID' order by date", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select sum(amount) from intinvesterrecipt where invid='" + kid + "' AND type='RECEIVE' AND date < '" + date1 + "' AND status='PAID'", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    con.Close();
                    if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    {
                        rec = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
                    }
                    con.Open();
                    SqlDataAdapter da3 = new SqlDataAdapter("select sum(dramount) from intinvesterrecipt where invid='" + kid + "' AND type='RETURN' AND date < '" + date1 + "' AND status='PAID'", con);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    if (ds3.Tables[0].Rows[0][0].ToString() != "")
                    {
                        ret = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                    }
                    con.Close();
                    DataRow dr1 = dt.NewRow();
                    dr1 = null;
                    dr1 = dt.NewRow();
                    dr1["invrecipt"] = "BACK";
                    dr1["type"] = "RECEIVE";
                    dr1["date"] = Convert.ToDateTime(start1);
                    dr1["amount"] = rec - ret;
                    dr1["dramount"] = 0;
                    dr1["wallet"] = 0;
                    dr1["total"] = 0;
                    dr1["paymod"] = "BACK";
                    dr1["chequedate"] = "BACK";
                    dr1["chequeno"] = "BACK";
                    dr1["status"] = "PAID";
                    dr1["reason"] = "BACK";

                    // dr1["bal"] = (rec*30/100)*ret;

                    dt.Rows.Add(dr1);
                    dr1 = null;
                    // string date1, date2;
                    int cramount, dramount;
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {

                            dr1 = dt.NewRow();
                            dr1["invrecipt"] = ds1.Tables[0].Rows[i][0].ToString();
                            dr1["type"] = ds1.Tables[0].Rows[i][2].ToString();
                            dr1["date"] = ds1.Tables[0].Rows[i][1].ToString();
                            dr1["amount"] = Convert.ToDouble(ds1.Tables[0].Rows[i][3].ToString());
                            dr1["dramount"] = Convert.ToDouble(ds1.Tables[0].Rows[i][4].ToString());
                            dr1["wallet"] = Convert.ToDouble(ds1.Tables[0].Rows[i][5].ToString());
                            dr1["total"] = Convert.ToDouble(ds1.Tables[0].Rows[i][4].ToString()) + Convert.ToDouble(ds1.Tables[0].Rows[i][5].ToString());
                            dr1["paymod"] = ds1.Tables[0].Rows[i][6].ToString();
                            dr1["chequedate"] = ds1.Tables[0].Rows[i][7].ToString();
                            dr1["chequeno"] = ds1.Tables[0].Rows[i][8].ToString();
                            dr1["status"] = ds1.Tables[0].Rows[i][9].ToString();
                            dr1["reason"] = ds1.Tables[0].Rows[i][10].ToString();
                            dt.Rows.Add(dr1);
                        }
                    }

                    DataTable dt2 = new DataTable();
                    dt2.Columns.AddRange(new DataColumn[16] { 
            new DataColumn("invrecipt", typeof(string)),
            new DataColumn("type", typeof(string)),
            new DataColumn("date",typeof(string)),
             new DataColumn("cramount", typeof(int)),
            new DataColumn("dramount", typeof(int)),
             new DataColumn("wallet", typeof(int)),
             new DataColumn("total", typeof(int)),
         new DataColumn("bal", typeof(int)),
            new DataColumn("paymod", typeof(string)),
             new DataColumn("chequedate", typeof(string)),
              new DataColumn("chequeno", typeof(string)),
             new DataColumn("status", typeof(string)),
              new DataColumn("days", typeof(int)),
            new DataColumn("intrest", typeof(int)),
            new DataColumn("month", typeof(string)),
                  new DataColumn("reason", typeof(string))
        });
                    DataRow dr2 = dt2.NewRow();
                    dr2 = dt2.NewRow();
                    DateTime startdate, enddate;
                    int days, SUM = 0;

                    for (int k = 0; k < dt.Rows.Count; k++)
                    {

                        dr2 = null;
                        days = 0;
                        TimeSpan difference;
                        if (dt.Rows[k][1].ToString() == "RECEIVE")
                        {
                            int back = 0, cred = 0;
                            startdate = Convert.ToDateTime(dt.Rows[k][2].ToString());

                            if ((k + 1) == dt.Rows.Count)
                            {
                                enddate = Convert.ToDateTime(enddate1);
                                //string s10=enddate.ToString();
                                int dd10 = Convert.ToInt32(enddate.Day);
                                int mm10 = Convert.ToInt32(enddate.Month);
                                int yy10 = Convert.ToInt32(enddate.Year);
                                //	string s7 = startdate.ToString();
                                int dd5 = Convert.ToInt32(startdate.Day);
                                int mm5 = Convert.ToInt32(startdate.Month);
                                int yy5 = Convert.ToInt32(startdate.Year);

                                DateTime dt111 = new DateTime(yy5, mm5, dd5, 0, 0, 0);
                                DateTime dt211 = new DateTime(yy10, mm10, dd10, 0, 0, 0);

                                TimeSpan interval11 = new TimeSpan(0, 0, 0);

                                TimeSpan difference11 = dt211 - dt111; //DateTime - DateTime 
                                days = difference11.Days;



                            }
                            else
                            {
                                enddate = Convert.ToDateTime(dt.Rows[k + 1][2].ToString());


                                //string s10=enddate.ToString();
                                int dd10 = Convert.ToInt32(enddate.Day);
                                int mm10 = Convert.ToInt32(enddate.Month);
                                int yy10 = Convert.ToInt32(enddate.Year);
                                //	string s7 = startdate.ToString();
                                int dd6 = Convert.ToInt32(startdate.Day);
                                int mm6 = Convert.ToInt32(startdate.Month);
                                int yy6 = Convert.ToInt32(startdate.Year);

                                DateTime dt1111 = new DateTime(yy6, mm6, dd6, 0, 0, 0);
                                DateTime dt2111 = new DateTime(yy10, mm10, dd10, 0, 0, 0);

                                TimeSpan interval = new TimeSpan(0, 0, 0);

                                TimeSpan difference111 = dt2111 - dt1111; //DateTime - DateTime 
                                days = difference111.Days;
                            }
                            // TimeSpan difference = enddate - startdate;
                            // days = Convert.ToInt32((enddate - startdate).TotalDays)+1;
                            // days = difference.Days;
                            dr2 = dt2.NewRow();
                            int credbal = 0;
                            if (k != 0)
                            {
                                cred = Convert.ToInt32(dt.Rows[k][3].ToString());
                                back = Convert.ToInt32(dt2.Rows[k - 1][7].ToString());
                                dr2["bal"] = cred + back;
                                credbal = cred + back;
                                dr2["month"] = "CURRENT";
                            }
                            else
                            {
                                cred = Convert.ToInt32(dt.Rows[k][3].ToString());
                                back = Convert.ToInt32(dt.Rows[k][3].ToString());
                                dr2["bal"] = back;
                                credbal = back;
                                dr2["month"] = "BACK";
                            }
                            dr2["invrecipt"] = dt.Rows[k][0].ToString();
                            dr2["cramount"] = Convert.ToInt32(dt.Rows[k][3].ToString());
                            dr2["dramount"] = 0;
                            dr2["wallet"] = Convert.ToInt32(dt.Rows[k][5].ToString());
                            dr2["total"] = Convert.ToInt32(dt.Rows[k][6].ToString());
                            dr2["type"] = dt.Rows[k][1].ToString();
                            dr2["paymod"] = dt.Rows[k][7].ToString();
                            dr2["chequedate"] = dt.Rows[k][8].ToString();
                            dr2["chequeno"] = dt.Rows[k][9].ToString();
                            dr2["reason"] = dt.Rows[k][11].ToString();
                            dr2["date"] = Convert.ToDateTime(dt.Rows[k][2].ToString()).ToString("dd/MM/yyyy");
                            dr2["status"] = dt.Rows[k][10].ToString();
                            dr2["days"] = days;
                            int intr = Convert.ToInt32(credbal * intrest * 12 / 100 * days / 365);
                            dr2["intrest"] = intr;
                            dt2.Rows.Add(dr2);
                            SUM = SUM + intr;

                        }
                        else
                        {

                            int back = 0, devit = 0;
                            startdate = Convert.ToDateTime(dt.Rows[k][2].ToString());
                            if ((k + 1) == dt.Rows.Count)
                            {
                                enddate = Convert.ToDateTime(enddate1);
                                int dd10 = Convert.ToInt32(enddate.Day);
                                int mm10 = Convert.ToInt32(enddate.Month);
                                int yy10 = Convert.ToInt32(enddate.Year);
                                //	string s7 = startdate.ToString();
                                int dd7 = Convert.ToInt32(startdate.Day);
                                int mm7 = Convert.ToInt32(startdate.Month);
                                int yy7= Convert.ToInt32(startdate.Year);

                                DateTime dt122 = new DateTime(yy7, mm7, dd7, 0, 0, 0);
                                DateTime dt222 = new DateTime(yy10, mm10, dd10, 0, 0, 0);

                                TimeSpan interval1111 = new TimeSpan(0, 0, 0);

                                TimeSpan difference22 = dt222 - dt122; //DateTime - DateTime 
                                days = difference22.Days;



                            }
                            else
                            {
                                enddate = Convert.ToDateTime(dt.Rows[k + 1][2].ToString());


                                string s10 = enddate.ToString();
                                int dd10 = Convert.ToInt32(enddate.Day);
                                int mm10 = Convert.ToInt32(enddate.Month);
                                int yy10 = Convert.ToInt32(enddate.Year);
                                //	string s7 = startdate.ToString();
                                int dd8 = Convert.ToInt32(startdate.Day);
                                int mm8 = Convert.ToInt32(startdate.Month);
                                int yy8 = Convert.ToInt32(startdate.Year);

                                DateTime dt1222 = new DateTime(yy8, mm8, dd8, 0, 0, 0);
                                DateTime dt2222 = new DateTime(yy10, mm10, dd10, 0, 0, 0);

                                TimeSpan interval33 = new TimeSpan(0, 0, 0);

                                TimeSpan difference33 = dt2222 - dt1222; //DateTime - DateTime 
                                days = difference33.Days;
                            }



                            dr2 = dt2.NewRow();
                            back = Convert.ToInt32(dt2.Rows[k - 1][7].ToString());
                            devit = Convert.ToInt32(dt.Rows[k][4].ToString());
                            dr2["invrecipt"] = dt.Rows[k][0].ToString();
                            dr2["cramount"] = 0;
                            dr2["dramount"] = Convert.ToInt32(dt.Rows[k][4].ToString());
                            dr2["wallet"] = Convert.ToInt32(dt.Rows[k][5].ToString());
                            dr2["total"] = Convert.ToInt32(dt.Rows[k][6].ToString());

                            dr2["paymod"] = dt.Rows[k][7].ToString();
                            dr2["chequedate"] = dt.Rows[k][8].ToString();
                            dr2["chequeno"] = dt.Rows[k][9].ToString();
                            dr2["reason"] = dt.Rows[k][11].ToString();

                            int amytbal;
                            amytbal = back - devit;
                            dr2["bal"] = amytbal;
                            dr2["type"] = dt.Rows[k][1].ToString();
                            dr2["date"] = Convert.ToDateTime(dt.Rows[k][2].ToString()).ToString("dd/MM/yyyy");
                            dr2["status"] = dt.Rows[k][10].ToString();
                            dr2["days"] = days;
                            int intr = Convert.ToInt32(amytbal * intrest * 12 / 100 * days / 365);

                            dr2["intrest"] = intr;
                            dr2["month"] = "CURRENT";

                            dt2.Rows.Add(dr2);
                            SUM = SUM + intr;
                        }

                    }
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                }
            }
        }

       
       
        
    }
    public DataTable finddata(string kid, Double intrest)
    {
        Double rec = 0, ret = 0;
        SqlConnection con = new SqlConnection(s);
        DataTable dt = new DataTable();

        dt.Columns.AddRange(new DataColumn[12] { 
            new DataColumn("invrecipt", typeof(string)),
            new DataColumn("type", typeof(string)),
            new DataColumn("date",typeof(string)),
            new DataColumn("amount", typeof(int)),
            new DataColumn("dramount", typeof(int)),
             new DataColumn("wallet", typeof(int)),
             new DataColumn("total", typeof(int)),
            new DataColumn("paymod", typeof(string)),
             new DataColumn("chequedate", typeof(string)),
              new DataColumn("chequeno", typeof(string)),
             new DataColumn("status", typeof(string)),
                  new DataColumn("reason", typeof(string))
           
            
        });

        con.Open();
        // SqlDataAdapter da1 = new SqlDataAdapter("select amount,dramount,type,date,status,wallet from intinvesterrecipt where invid='" + kid + "' AND date between '" + date1 + "' AND '" + date2 + "' AND status='PAID' order by date", con);
        SqlDataAdapter da1 = new SqlDataAdapter("select invrecipt,date,type,amount,dramount,wallet,paymode,chekdate,chkno,status,reason from intinvesterrecipt  where invid='" + kid + "' AND date between '" + date1 + "' AND '" + date2 + "' AND status='PAID' order by date", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(amount) from intinvesterrecipt where invid='" + kid + "' AND type='RECEIVE' AND date < '" + date1 + "' AND status='PAID'", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            rec = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select sum(dramount) from intinvesterrecipt where invid='" + kid + "' AND type='RETURN' AND date < '" + date1 + "' AND status='PAID'", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        if (ds3.Tables[0].Rows[0][0].ToString() != "")
        {
            ret = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
        }
        con.Close();
        DataRow dr1 = dt.NewRow();
        dr1 = null;
        dr1 = dt.NewRow();
        dr1["invrecipt"] = "BACK";
        dr1["type"] = "RECEIVE";
        dr1["date"] = Convert.ToDateTime(start1);
        dr1["amount"] = rec - ret;
        dr1["dramount"] = 0;
        dr1["wallet"] = 0;
        dr1["total"] = 0;
        dr1["paymod"] = "BACK";
        dr1["chequedate"] = "BACK";
        dr1["chequeno"] = "BACK";
        dr1["status"] = "PAID";
        dr1["reason"] = "BACK";

        // dr1["bal"] = (rec*30/100)*ret;

        dt.Rows.Add(dr1);
        dr1 = null;
        // string date1, date2;
        int cramount, dramount;
        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {

                dr1 = dt.NewRow();
                dr1["invrecipt"] = ds1.Tables[0].Rows[i][0].ToString();
                dr1["type"] = ds1.Tables[0].Rows[i][2].ToString();
                dr1["date"] = ds1.Tables[0].Rows[i][1].ToString();
                dr1["amount"] = Convert.ToDouble(ds1.Tables[0].Rows[i][3].ToString());
                dr1["dramount"] = Convert.ToDouble(ds1.Tables[0].Rows[i][4].ToString());
                dr1["wallet"] = Convert.ToDouble(ds1.Tables[0].Rows[i][5].ToString());
                dr1["total"] = Convert.ToDouble(ds1.Tables[0].Rows[i][4].ToString()) + Convert.ToDouble(ds1.Tables[0].Rows[i][5].ToString());
                dr1["paymod"] = ds1.Tables[0].Rows[i][6].ToString();
                dr1["chequedate"] = ds1.Tables[0].Rows[i][7].ToString();
                dr1["chequeno"] = ds1.Tables[0].Rows[i][8].ToString();
                dr1["status"] = ds1.Tables[0].Rows[i][9].ToString();
                dr1["reason"] = ds1.Tables[0].Rows[i][10].ToString();
                dt.Rows.Add(dr1);
            }
        }

        DataTable dt2 = new DataTable();
        dt2.Columns.AddRange(new DataColumn[16] { 
            new DataColumn("invrecipt", typeof(string)),
            new DataColumn("type", typeof(string)),
            new DataColumn("date",typeof(string)),
             new DataColumn("cramount", typeof(int)),
            new DataColumn("dramount", typeof(int)),
             new DataColumn("wallet", typeof(int)),
             new DataColumn("total", typeof(int)),
         new DataColumn("bal", typeof(int)),
            new DataColumn("paymod", typeof(string)),
             new DataColumn("chequedate", typeof(string)),
              new DataColumn("chequeno", typeof(string)),
             new DataColumn("status", typeof(string)),
              new DataColumn("days", typeof(int)),
            new DataColumn("intrest", typeof(int)),
            new DataColumn("month", typeof(string)),
                  new DataColumn("reason", typeof(string))
        });
        DataRow dr2 = dt2.NewRow();
        dr2 = dt2.NewRow();
        DateTime startdate, enddate;
        int days, SUM = 0;

        for (int k = 0; k < dt.Rows.Count; k++)
        {

            dr2 = null;
            days = 0;
            TimeSpan difference;
            if (dt.Rows[k][1].ToString() == "RECEIVE")
            {
                int back = 0, cred = 0;
                startdate = Convert.ToDateTime(dt.Rows[k][2].ToString());

                if ((k + 1) == dt.Rows.Count)
                {
                    enddate = Convert.ToDateTime(enddate1);
                    //string s10=enddate.ToString();
                    int dd10 = Convert.ToInt32(enddate.Day);
                    int mm10 = Convert.ToInt32(enddate.Month);
                    int yy10 = Convert.ToInt32(enddate.Year);
                    //	string s7 = startdate.ToString();
                    int dd = Convert.ToInt32(startdate.Day);
                    int mm = Convert.ToInt32(startdate.Month);
                    int yy = Convert.ToInt32(startdate.Year);

                    DateTime dt111 = new DateTime(yy, mm, dd, 0, 0, 0);
                    DateTime dt211 = new DateTime(yy10, mm10, dd10, 0, 0, 0);

                    TimeSpan interval11 = new TimeSpan(0, 0, 0);

                    TimeSpan difference11 = dt211 - dt111; //DateTime - DateTime 
                    days = difference11.Days;



                }
                else
                {
                    enddate = Convert.ToDateTime(dt.Rows[k + 1][2].ToString());


                    //string s10=enddate.ToString();
                    int dd10 = Convert.ToInt32(enddate.Day);
                    int mm10 = Convert.ToInt32(enddate.Month);
                    int yy10 = Convert.ToInt32(enddate.Year);
                    //	string s7 = startdate.ToString();
                    int dd = Convert.ToInt32(startdate.Day);
                    int mm = Convert.ToInt32(startdate.Month);
                    int yy = Convert.ToInt32(startdate.Year);

                    DateTime dt1111 = new DateTime(yy, mm, dd, 0, 0, 0);
                    DateTime dt2111 = new DateTime(yy10, mm10, dd10, 0, 0, 0);

                    TimeSpan interval = new TimeSpan(0, 0, 0);

                    TimeSpan difference111 = dt2111 - dt1111; //DateTime - DateTime 
                    days = difference111.Days;
                }
                // TimeSpan difference = enddate - startdate;
                // days = Convert.ToInt32((enddate - startdate).TotalDays)+1;
                // days = difference.Days;
                dr2 = dt2.NewRow();
                int credbal = 0;
                if (k != 0)
                {
                    cred = Convert.ToInt32(dt.Rows[k][3].ToString());
                    back = Convert.ToInt32(dt2.Rows[k - 1][7].ToString());
                    dr2["bal"] = cred + back;
                    credbal = cred + back;
                    dr2["month"] = "CURRENT";
                }
                else
                {
                    cred = Convert.ToInt32(dt.Rows[k][3].ToString());
                    back = Convert.ToInt32(dt.Rows[k][3].ToString());
                    dr2["bal"] = back;
                    credbal = back;
                    dr2["month"] = "BACK";
                }
                dr2["invrecipt"] = dt.Rows[k][0].ToString();
                dr2["cramount"] = Convert.ToInt32(dt.Rows[k][3].ToString());
                dr2["dramount"] = 0;
                dr2["wallet"] = Convert.ToInt32(dt.Rows[k][5].ToString());
                dr2["total"] = Convert.ToInt32(dt.Rows[k][6].ToString());
                dr2["type"] = dt.Rows[k][1].ToString();
                dr2["paymod"] = dt.Rows[k][7].ToString();
                dr2["chequedate"] = dt.Rows[k][8].ToString();
                dr2["chequeno"] = dt.Rows[k][9].ToString();
                dr2["reason"] = dt.Rows[k][11].ToString();
                dr2["date"] = Convert.ToDateTime(dt.Rows[k][2].ToString()).ToString("dd/MM/yyyy");
                dr2["status"] = dt.Rows[k][10].ToString();
                dr2["days"] = days;
                int intr = Convert.ToInt32(credbal * intrest * 12 / 100 * days / 365);
                dr2["intrest"] = intr;
                dt2.Rows.Add(dr2);
                SUM = SUM + intr;

            }
            else
            {

                int back = 0, devit = 0;
                startdate = Convert.ToDateTime(dt.Rows[k][2].ToString());
                if ((k + 1) == dt.Rows.Count)
                {
                    enddate = Convert.ToDateTime(enddate1);
                    int dd10 = Convert.ToInt32(enddate.Day);
                    int mm10 = Convert.ToInt32(enddate.Month);
                    int yy10 = Convert.ToInt32(enddate.Year);
                    //	string s7 = startdate.ToString();
                    int dd = Convert.ToInt32(startdate.Day);
                    int mm = Convert.ToInt32(startdate.Month);
                    int yy = Convert.ToInt32(startdate.Year);

                    DateTime dt122 = new DateTime(yy, mm, dd, 0, 0, 0);
                    DateTime dt222 = new DateTime(yy10, mm10, dd10, 0, 0, 0);

                    TimeSpan interval1111 = new TimeSpan(0, 0, 0);

                    TimeSpan difference22 = dt222 - dt122; //DateTime - DateTime 
                    days = difference22.Days;



                }
                else
                {
                    enddate = Convert.ToDateTime(dt.Rows[k + 1][2].ToString());


                    string s10 = enddate.ToString();
                    int dd10 = Convert.ToInt32(enddate.Day);
                    int mm10 = Convert.ToInt32(enddate.Month);
                    int yy10 = Convert.ToInt32(enddate.Year);
                    //	string s7 = startdate.ToString();
                    int dd = Convert.ToInt32(startdate.Day);
                    int mm = Convert.ToInt32(startdate.Month);
                    int yy = Convert.ToInt32(startdate.Year);

                    DateTime dt1222 = new DateTime(yy, mm, dd, 0, 0, 0);
                    DateTime dt2222 = new DateTime(yy10, mm10, dd10, 0, 0, 0);

                    TimeSpan interval33 = new TimeSpan(0, 0, 0);

                    TimeSpan difference33 = dt2222 - dt1222; //DateTime - DateTime 
                    days = difference33.Days;
                }



                dr2 = dt2.NewRow();
                back = Convert.ToInt32(dt2.Rows[k - 1][7].ToString());
                devit = Convert.ToInt32(dt.Rows[k][4].ToString());
                dr2["invrecipt"] = dt.Rows[k][0].ToString();
                dr2["cramount"] = 0;
                dr2["dramount"] = Convert.ToInt32(dt.Rows[k][4].ToString());
                dr2["wallet"] = Convert.ToInt32(dt.Rows[k][5].ToString());
                dr2["total"] = Convert.ToInt32(dt.Rows[k][6].ToString());

                dr2["paymod"] = dt.Rows[k][7].ToString();
                dr2["chequedate"] = dt.Rows[k][8].ToString();
                dr2["chequeno"] = dt.Rows[k][9].ToString();
                dr2["reason"] = dt.Rows[k][11].ToString();

                int amytbal;
                amytbal = back - devit;
                dr2["bal"] = amytbal;
                dr2["type"] = dt.Rows[k][1].ToString();
                dr2["date"] = Convert.ToDateTime(dt.Rows[k][2].ToString()).ToString("dd/MM/yyyy");
                dr2["status"] = dt.Rows[k][10].ToString();
                dr2["days"] = days;
                int intr = Convert.ToInt32(amytbal * intrest * 12 / 100 * days / 365);

                dr2["intrest"] = intr;
               dr2["month"] = "CURRENT";

                dt2.Rows.Add(dr2);
                SUM = SUM + intr;
            }

        }
        if (DropDownList1.Text == "ALL DETAILS MONTHWISE")
        {
            total = 0;
           // Label32.Text = SUM.ToString();
           
            total = SUM;
            return dt2;

        }
        else
        {
            total = 0;
            Label32.Text = SUM.ToString();
            GridView1.DataSource = dt2;
            GridView1.DataBind();
            total = SUM;
            return dt2;
        }


        SUM = 0;
    }
    
   
    protected void Button1_Click1(object sender, EventArgs e)
    {
        fetch();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

    }
    public void invwallet(string kid)
    {
        Double usewallet = 0, totalwallet = 0, balwallet = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(usewalletamt),sum(totalamt) from invwallet where invid='" + kid + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                usewallet = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                usewallet = 0;
            }
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                totalwallet = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                totalwallet = 0;
            }
            balwallet = totalwallet - usewallet;
            Label33.Text = balwallet.ToString();


        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Double recamt = 0, retamt = 0, bpaid = 0, unpaid = 0, trecamt = 0, tretamt = 0, balrec = 0, balret = 0, brtotal = 0, brbal = 0;

        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid,ivname,date,lastdate,totalinvestamt,returnamt,brokername,btotal,intrest from newintinvester where invid='" + TextBox1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Label15.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label15.Text = "0";
            }
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                Label16.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                Label16.Text = "0";
            }
            String dt;
            if (ds.Tables[0].Rows[0][2].ToString() != "")
            {
                dt = ds.Tables[0].Rows[0][2].ToString();
               // dt = dt.Substring(0, 10);
                DateTime dy = Convert.ToDateTime(dt);
                Label19.Text = dy.ToString("dd/MM/yyyy");
				//Label19.Text = dt;
            }
            else
            {
                Label19.Text = "0";
            }
            String ltdt;
            if (ds.Tables[0].Rows[0][3].ToString() != "")
            {

                ltdt = ds.Tables[0].Rows[0][3].ToString();
                ltdt = ltdt.Substring(0, 10);
                DateTime dy3 = Convert.ToDateTime(ltdt);
                Label20.Text = dy3.ToString("dd/MM/yyyy");
            }
            else
            {
                Label20.Text = "0";
            }
            if (ds.Tables[0].Rows[0][4].ToString() != "")
            {
                Label17.Text = ds.Tables[0].Rows[0][4].ToString();
                trecamt = Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
            }
            else
            {
                Label17.Text = "0";
                trecamt = 0;
            }
            if (ds.Tables[0].Rows[0][5].ToString() != "")
            {
                Label18.Text = ds.Tables[0].Rows[0][5].ToString();
                tretamt = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());
            }
            else
            {
                Label18.Text = "0";
                tretamt = 0;
            }
            if (ds.Tables[0].Rows[0][6].ToString() != "")
            {
                Label27.Text = ds.Tables[0].Rows[0][6].ToString();
            }
            else
            {
                Label27.Text = "0";
            }
            if (ds.Tables[0].Rows[0][7].ToString() != "")
            {
                Label28.Text = ds.Tables[0].Rows[0][7].ToString();
                brtotal = Convert.ToDouble(ds.Tables[0].Rows[0][7].ToString());
            }
            else
            {
                Label28.Text = "0";
                brtotal = 0;
            }
            if (ds.Tables[0].Rows[0][8].ToString() != "")
            {
                Label34.Text = ds.Tables[0].Rows[0][8].ToString();

            }
            else
            {
                Label34.Text = "0";

            }
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount) from intinvesterrecipt where bpaid=0 AND invid IN(select invid from intinvesterrecipt where invid='" + TextBox1.Text + "') AND status='PAID' AND type='RECEIVE'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                recamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                recamt = 0;
            }
            Label21.Text = recamt.ToString();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(dramount) from intinvesterrecipt where  bpaid=0 AND invid IN(select invid from intinvesterrecipt where invid='" + TextBox1.Text + "') AND status='PAID' AND type='RETURN'", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows[0][0].ToString() != "")
            {
                retamt = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                retamt = 0;
            }
            Label22.Text = retamt.ToString();
            con.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("select sum(bpaid) from intinvesterrecipt where bpaid NOT IN(0) AND invid IN(select invid from intinvesterrecipt where invid='" + TextBox1.Text + "') AND status='PAID'", con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con.Close();
            if (ds4.Tables[0].Rows[0][0].ToString() != "")
            {
                bpaid = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                bpaid = 0;
            }
            Label24.Text = bpaid.ToString();
            SqlDataAdapter da3 = new SqlDataAdapter("select sum(dramount) from intinvesterrecipt where invid IN(select invid from intinvesterrecipt where invid='" + TextBox1.Text + "') AND status='UNPAID'", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            if (ds3.Tables[0].Rows[0][0].ToString() != "")
            {
                unpaid = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                unpaid = 0;
            }
            Label30.Text = unpaid.ToString();
            balrec = trecamt - recamt;
            Label25.Text = balrec.ToString();
            balret = tretamt - retamt;
            Label26.Text = balret.ToString();
            brbal = brtotal - bpaid;
            Label29.Text = brbal.ToString();
            invwallet(TextBox1.Text);

        }
        else
        {
            Label14.Text = "Error";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string dateString1 = e.Row.Cells[9].Text;
            if (dateString1 == "BACK" || dateString1 == "1/1/1900 12:00:00 AM")
            {
                e.Row.Cells[9].Text = "";
            }
			else
			{
			string a = dateString1.Substring(0,9);
                e.Row.Cells[9].Text = a;
			}
            string st = e.Row.Cells[0].Text;
            foreach (TableCell cell in e.Row.Cells)
            {
                if (st == "FINAL")
                {
                    cell.BackColor = Color.Gray;
                    cell.ForeColor = Color.Black;
                }
                
                
            }
           
        }
    }
}