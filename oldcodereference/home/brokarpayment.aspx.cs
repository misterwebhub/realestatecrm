using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Drawing;
using System.Globalization;

public partial class home_brokarpayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //String y=Session["sp"].ToString();

            find();
            //brokerbind();
            Label15.Text = "";
        }
    }
    public void find()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT name from brokarpage", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            con1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT APPNO FROM wjstar1.customerreg1", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                // DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                DropDownList2.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label15.Text = "internal problem";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //TextBox3.Text = DropDownList1.Text;
            string dateString1 = TextBox1.Text;
            string dateString2 = TextBox2.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
            string ddd1 = dateTime1.ToString("mm/dd/yyyy");
            DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            string ddd2 = dateTime2.ToString("mm/dd/yyyy");
            Label15.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter("select u.date3 AS 'BOOKING',r.CUSTREGNO,u.APPNO AS 'ARAZI',SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.AMOUNTR AS 'AMOUNT' from  wjstar1.recipt1 r  LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO IN(SELECT DISTINCT CUSTREGNO FROM wjstar1.customerreg1 where r.CHECKBY='" + DropDownList1.Text + "' AND u.APPNO='" + DropDownList2.Text + "' AND r.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed' OR regstatus='Cancel')) AND r.date1 between '" + ddd1 + "' AND '" + ddd2 + "'", con1);
           // SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,PLANTERM,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',RECIPT,AMOUNTR,DATE1 from wjstar1.recipt1 where CUSTREGNO IN(SELECT DISTINCT CUSTREGNO FROM wjstar1.customerreg1 where CHECKBY='" + DropDownList1.Text + "' AND APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed')) AND date1 between '" + ddd1 + "' AND '" + ddd2 + "' order by date1 ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            // TextBox6.Text = DropDownList1.Text;
            //TextBox2.Text = "";
            //TextBox3.Text = "";

            con1.Open();
            float gz = 0;
            SqlDataAdapter da1 = new SqlDataAdapter("select sum(r.AMOUNTR) from  wjstar1.recipt1 r  LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO IN(SELECT DISTINCT CUSTREGNO FROM wjstar1.customerreg1 where r.CHECKBY='" + DropDownList1.Text + "' AND u.APPNO='" + DropDownList2.Text + "' AND r.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed' OR regstatus='Cancel')) AND r.date1 between '" + ddd1 + "' AND '" + ddd2 + "'", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {

                gz += float.Parse(ds1.Tables[0].Rows[0][0].ToString());

                Label15.Text =gz.ToString();
            }
            con1.Close();


        }
        catch (Exception t)
        {
            Label15.Text = "internal problem";
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
			TextBox5.Text="";
            //TextBox3.Text = DropDownList1.Text;
            string dateString1 = TextBox1.Text;
            string dateString2 = TextBox2.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
            string ddd1 = dateTime1.ToString("mm/dd/yyyy");
            DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            string ddd2 = dateTime2.ToString("mm/dd/yyyy");
            Label15.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
           // SqlDataAdapter da = new SqlDataAdapter("select u.date3 AS 'BOOKING',r.CUSTREGNO,SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.AMOUNTR AS 'AMOUNT',u.APPNO AS 'ARAZI' from  wjstar1.recipt1 r where r.CUSTREGNO IN(SELECT DISTINCT CUSTREGNO FROM wjstar1.customerreg1 where CHECKBY='" + DropDownList1.Text + "'  AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed')) AND date1 between '" + ddd1 + "' AND '" + ddd2 + "' LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO ", con1);
            SqlDataAdapter da = new SqlDataAdapter("select u.date3 AS 'BOOKING',r.CUSTREGNO,u.APPNO AS 'ARAZI',SUBSTRING(r.ASCADDRESS,1,15) AS 'NAME',r.RECIPT,r.DATE1 AS 'DATE',r.AMOUNTR AS 'AMOUNT' from  wjstar1.recipt1 r  LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO IN(SELECT DISTINCT CUSTREGNO FROM wjstar1.customerreg1 where r.CHECKBY='" + DropDownList1.Text + "'  AND r.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed' OR regstatus='Cancel')) AND r.date1 between '" + ddd1 + "' AND '" + ddd2 + "'", con1);
            // SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,PLANTERM,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',RECIPT,AMOUNTR,DATE1 from wjstar1.recipt1 where CUSTREGNO IN(SELECT DISTINCT CUSTREGNO FROM wjstar1.customerreg1 where CHECKBY='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed')) AND date1 between '" + ddd1 + "' AND '" + ddd2 + "' order by date1 ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            // TextBox6.Text = DropDownList1.Text;
            //TextBox2.Text = "";
            //TextBox3.Text = "";

            con1.Open();
            float gz = 0;
            SqlDataAdapter da1 = new SqlDataAdapter("select sum(r.AMOUNTR) from  wjstar1.recipt1 r  LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO IN(SELECT DISTINCT CUSTREGNO FROM wjstar1.customerreg1 where r.CHECKBY='" + DropDownList1.Text + "'  AND r.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed' OR regstatus='Cancel')) AND r.date1 between '" + ddd1 + "' AND '" + ddd2 + "'", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {

                gz += float.Parse(ds1.Tables[0].Rows[0][0].ToString());

                Label15.Text =gz.ToString();
            }
            con1.Close();


        }
        catch (Exception t)
        {
            Label15.Text = "internal problem";
        }
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        String d = Label15.Text;
        Double f = Convert.ToDouble(d);
        Double a = Convert.ToDouble(TextBox5.Text);
        Double t = (f * a) / 100;
        TextBox6.Text = t.ToString();

    }
    public void brokerbind()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT bname,pdate,perc,amount,reason FROM brokerpayment where bname='"+DropDownList1.Text+"' order by pdate ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            GridView2.DataSource = ds;
            GridView2.DataBind();
           
        }
        catch (Exception t)
        {
            Label16.Text = "internal problem";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string dateString2 = TextBox4.Text;
            string format = "dd/mm/yyyy";
           DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            string ddd2 = dateTime2.ToString("mm/dd/yyyy");
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into brokerpayment(bname,pdate,perc,amount,reason)values('" + DropDownList1.Text + "','" + ddd2 + "','" + TextBox5.Text + "'," + TextBox6.Text + ",'" + TextBox7.Text + "')", con1);
            int i = cmd.ExecuteNonQuery();
			con1.Close();
            if (i != 0)
            {
                Label16.Text = "Record Added";
                brokerbind();
            }
            else
            {
                Label16.Text = "Internal Problem";
            }
          


        }
        catch (Exception t)
        {
            Label16.Text = "internal problem";
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT bname,pdate,perc,amount,reason FROM brokerpayment  where bname='" + DropDownList1.Text + "' order by pdate ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            GridView2.DataSource = ds;
            GridView2.DataBind();

        }
        catch (Exception t)
        {
            Label16.Text = "internal problem";
        }
    }
}