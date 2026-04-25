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


public partial class arazi137ramipur_investcal : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fetch();
        }
    }
    public void fetch()
    {
        SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select invid,intrest,date from newintinvester WHERE invid='I005' ", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        string kid;
       Double intr;
       string bkdate = "";
       // if (ds.Tables[0].Rows.Count > 0)
       // {
       //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
                kid = "";
                intr = 0;
                 kid= ds.Tables[0].Rows[0][0].ToString() ;
                intr  = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                bkdate  =ds.Tables[0].Rows[0][2].ToString();
                DateTime bkdate1=Convert.ToDateTime(bkdate);
                string lastdate5 = "12/18/2022";
              //  DateTime tu = DateTime.Now;  
        DateTime tu=Convert.ToDateTime(lastdate5);
                int dayaaj = tu.Day;
                int daybook = bkdate1.Day;
               con.Open();
               SqlDataAdapter da1 = new SqlDataAdapter("select year(date) from intinvesterrecipt where invid='" + kid + "'", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][0].ToString() != "")
                    {
                        if (dayaaj == daybook)
                        {
                            cal(kid, intr, bkdate);
                        }

                    }
                    else
                    {
                        Label1.Text = "please enter correct id";
                    }
               // }
            //}
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        
    }
    public void cal(string kid,Double intrest,string bokdate)
    {
        string cdd,bdd,cmm,bmm;
        DateTime bkdate1 = Convert.ToDateTime(bokdate);

        DateTime tu = DateTime.Now;  
        int dayaaj = DateTime.Today.Day;
        int daybook = bkdate1.Day;
        int todayyear = DateTime.Today.Year;
        int todaymonth = DateTime.Today.Month;
        int backmonth,backyear;
        if (todaymonth == 1)
        {
            backmonth = 12;
            backyear = todayyear - 1;
        }
        else
        {
            backmonth = todaymonth - 1;
            backyear = todayyear;
        }
        
       // DateTime datetab = firstDay;

        int mm1, yy1,dd1,dd2,mm2;
       // string s2 = TextBox2.Text;

        dd1 = dayaaj;
        if (dd1 == 1 || dd1 == 2 || dd1 == 3 || dd1 == 4 || dd1 == 5 || dd1 == 6 || dd1 == 7 || dd1 == 8 || dd1 == 9)
        {
            cdd = "0"+dd1;
        }
        else
        {
            cdd= dd1.ToString();
        }
        dd2 = daybook;
        if (dd2 == 1 || dd2 == 2 || dd2 == 3 || dd2 == 4 || dd2 == 5 || dd2 == 6 || dd2 == 7 || dd2 == 8 || dd2 == 9)
        {
            bdd = "0" + dd2;
        }
        else
        {
            bdd = dd2.ToString();
        }


        mm1 = todaymonth;
        if (mm1 == 10 || mm1 == 11 || mm1 == 12)
        {
            cmm = mm1.ToString();
        }
        else
        {
            cmm = "0" + mm1.ToString();
        }
        mm2 = backmonth;
        if (mm2 == 10 || mm2 == 11 || mm2 == 12)
        {
            bmm = mm2.ToString();
        }
        else
        {
            bmm = "0" + mm2.ToString();
        }

            
        string date1 = bmm + "/" + bdd + "/" + backyear;
       
        string date2 = cmm + "/" + cdd + "/" + todayyear;
        string enddate1 = cmm + "/" + cdd + "/" + todayyear;
        string start1 = bmm + "/" + bdd + "/" + backyear;
        Double rec = 0, ret = 0;
        SqlConnection con = new SqlConnection(s);
        DataTable dt = new DataTable();
        
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("amount", typeof(int)),new DataColumn("dramount", typeof(int)),
                            new DataColumn("type", typeof(string)),
                            new DataColumn("date",typeof(string)),new DataColumn("status", typeof(string))});

        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select amount,dramount,type,date,status from intinvesterrecipt where invid='" + kid + "' AND date between '" + date1 + "' AND '" + date2 + "' AND status='PAID' order by date", con);
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
        dr1["amount"] = rec - ret;
        dr1["dramount"] = 0;
        dr1["type"] = "RECEIVE";
        dr1["date"] = Convert.ToDateTime(start1);
        dr1["status"] = "PAID";
       
        dt.Rows.Add(dr1);
        dr1 = null;
       // string date1, date2;
       int cramount,dramount;
        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                
                dr1 = dt.NewRow();
                dr1["amount"] = Convert.ToDouble(ds1.Tables[0].Rows[i][0].ToString());
                dr1["dramount"] = Convert.ToDouble(ds1.Tables[0].Rows[i][1].ToString());
                dr1["type"] = ds1.Tables[0].Rows[i][2].ToString();
                dr1["date"] = ds1.Tables[0].Rows[i][3].ToString();
                dr1["status"] = ds1.Tables[0].Rows[i][4].ToString();
               
                dt.Rows.Add(dr1);
            }
        }
        GridView2.DataSource = dt;
        GridView2.DataBind();
        DataTable dt2 = new DataTable();
        dt2.Columns.AddRange(new DataColumn[9] { new DataColumn("cramount", typeof(int)),new DataColumn("dramount", typeof(int)),new DataColumn("bal", typeof(int)),
                            new DataColumn("type", typeof(string)),
                            new DataColumn("date",typeof(string)),new DataColumn("status", typeof(string)),new DataColumn("days", typeof(int)),new DataColumn("intrest", typeof(int)),new DataColumn("month", typeof(string))});
        DataRow dr2 = dt2.NewRow();
        dr2 = dt2.NewRow();
        DateTime startdate, enddate;
        int days, SUM = 0 ;
        
        for (int k = 0; k < dt.Rows.Count; k++)
        {
            
                dr2 = null;
                days = 0;
			 TimeSpan difference;
                if (dt.Rows[k][2].ToString() == "RECEIVE")
                {
                    int back = 0, cred = 0;
                    startdate = Convert.ToDateTime(dt.Rows[k][3].ToString());
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
                
                    dr2 = dt2.NewRow();
                    int credbal = 0;
                    if (k != 0)
                    {
                        cred = Convert.ToInt32(dt.Rows[k][0].ToString()); 
                        back = Convert.ToInt32(dt2.Rows[k - 1][2].ToString());
                        dr2["bal"] = cred + back;
                        credbal = cred + back;
                        dr2["month"] = "CURRENT";
                    }
                    else
                    {
                        cred = Convert.ToInt32(dt.Rows[k][0].ToString()); 
                        back = Convert.ToInt32(dt.Rows[k][0].ToString());
                        dr2["bal"] =back;
                        credbal = back;
                        dr2["month"] = "BACK";
                    }
                    
                    dr2["cramount"] = Convert.ToInt32(dt.Rows[k][0].ToString());
                    dr2["dramount"] = 0;
                 
                    dr2["type"] = dt.Rows[k][2].ToString();
                    dr2["date"] = dt.Rows[k][3].ToString();
                    dr2["status"] = dt.Rows[k][4].ToString();
                    dr2["days"] = days;
                    int intr = Convert.ToInt32(credbal * intrest * 12 / 100 * days / 365);
                    dr2["intrest"] = intr;
                    dt2.Rows.Add(dr2);
                    SUM = SUM + intr;
                }
                else
                {
                    int back=0,devit = 0;
                    startdate = Convert.ToDateTime(dt.Rows[k][3].ToString());
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
                    back = Convert.ToInt32(dt2.Rows[k-1][2].ToString());
                    devit = Convert.ToInt32(dt.Rows[k][1].ToString()); 
                    dr2["cramount"] = 0;
                    dr2["dramount"] = Convert.ToInt32(dt.Rows[k][1].ToString());
                    int amytbal;
                    amytbal = back - devit; ;
                    dr2["bal"] = amytbal;
                    dr2["type"] = dt.Rows[k][2].ToString();
                    dr2["date"] = dt.Rows[k][3].ToString();
                    dr2["status"] = dt.Rows[k][4].ToString();
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
        Label2.Text = SUM.ToString();
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into invwallet(invid,date,usewalletamt,totalamt)values('"+kid+"','"+enddate1+"',0,"+SUM+")", con);
        cmd.ExecuteNonQuery();
        con.Close();

        SUM = 0;
    }
   
   
}