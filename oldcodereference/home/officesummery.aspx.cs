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
public partial class excel_office_summery : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind5();
        }
    }
    public void bind5()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT username FROM logininfo", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();

            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (ds1.Tables[0].Rows[j][0].ToString() == "IMRAN7905")
                {
                    DropDownList2.Items.Add("BROKER");
                }
                else
                {
                    DropDownList2.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
                }
            }



        }
        catch (Exception t)
        {
            Label11.Text = "internal problem";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible=false;
        Label12.Text = "";
        
            Label1.Text = "";
            SqlConnection con1 = new SqlConnection(s);

            con1.Open();
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
            /*SqlDataAdapter da = new SqlDataAdapter("select count(CUSTREGNO) from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel'))", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();*/
            // con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(c.CUSTREGNO) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con1.Close();
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();

            GridView1.DataSource = ds1;
            GridView1.DataBind();
            int c = 0, t = 0, k = 0,rt=0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    rt = Convert.ToInt32(ds2.Tables[0].Rows[0][0].ToString());
                else
                    rt = 0;
            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
                rt = 0;
            }


            if (ds3.Tables[0].Rows.Count > 0)
            {
                c = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                c = 0;
            }
            t = k;
            t = t + c;
            Label1.Text = t.ToString();
            Label9.Text = c.ToString();
            con1.Open();
            SqlDataAdapter cmd5 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519') ) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds5 = new DataSet();
            cmd5.Fill(ds5);
             Double d,u;
            if (ds1.Tables[0].Rows.Count > 0)
            {
               d = Convert.ToDouble(ds5.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                d = 0;
            }
            con1.Close();
            Label12.Text = d.ToString();
            u = d-rt;
            Label13.Text = u.ToString();
            con1.Open();
            SqlDataAdapter da10 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND date3 NOT BETWEEN '" + date1 + "' AND '" + date2 + "') AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            con1.Close();
            GridView2.DataSource = ds10;
            GridView2.DataBind();
            con1.Open();
            SqlDataAdapter da12 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds12 = new DataSet();
            da12.Fill(ds12);
            con1.Close();
            GridView3.DataSource = ds12;
            GridView3.DataBind();
        

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string f = e.Row.Cells[7].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "Cancel")
                {
                    cell.BackColor = Color.Red;
                }


            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible=false;
        Label12.Text = "";
        if (DropDownList2.Text == "heedrealestate")
        {
            Label1.Text = "";
            SqlConnection con1 = new SqlConnection(s);

            con1.Open();
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
            /*SqlDataAdapter da = new SqlDataAdapter("select count(CUSTREGNO) from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel'))", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();*/
            // con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(c.CUSTREGNO) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CHECKBY IN ('office') AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con1.Close();
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('office') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('office') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();

            GridView1.DataSource = ds1;
            GridView1.DataBind();
            int c = 0, t = 0, k = 0,rt=0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    rt = Convert.ToInt32(ds2.Tables[0].Rows[0][0].ToString());
                else
                    rt = 0;
            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
                rt = 0;
            }


            if (ds3.Tables[0].Rows.Count > 0)
            {
                c = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                c = 0;
            }
            t = k;
            t = t + c;
            Label1.Text = t.ToString();
            Label9.Text = c.ToString();
            con1.Open();
            SqlDataAdapter cmd5 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('office')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds5 = new DataSet();
            cmd5.Fill(ds5);
             Double d,u;
            if (ds1.Tables[0].Rows.Count > 0)
            {
               d = Convert.ToDouble(ds5.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                d = 0;
            }
            con1.Close();
            Label12.Text = d.ToString();
            u = d-rt;
            Label13.Text = u.ToString();
            con1.Open();
            SqlDataAdapter da10 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('office') AND date3 NOT BETWEEN '" + date1 + "' AND '" + date2 + "') AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            con1.Close();
            GridView2.DataSource = ds10;
            GridView2.DataBind();
            con1.Open();
            SqlDataAdapter da12 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('office')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds12 = new DataSet();
            da12.Fill(ds12);
            con1.Close();
            GridView3.DataSource = ds12;
            GridView3.DataBind();
        }
        if (DropDownList2.Text == "Ashok8396")
        {
            Label1.Text = "";
            SqlConnection con1 = new SqlConnection(s);

            con1.Open();
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
            /*SqlDataAdapter da = new SqlDataAdapter("select count(CUSTREGNO) from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel'))", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();*/
            // con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(c.CUSTREGNO) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CHECKBY IN ('TAUDHAKPUR OFFICE') AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con1.Close();
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('TAUDHAKPUR OFFICE') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('TAUDHAKPUR OFFICE') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter cmd5 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('TAUDHAKPUR OFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds5 = new DataSet();
            cmd5.Fill(ds5);
            Double d,u;
            if (ds1.Tables[0].Rows.Count > 0)
            {
                d = Convert.ToDouble(ds5.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                d = 0;
            }
            con1.Close();
            Label12.Text = d.ToString();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            int c = 0, t = 0, k = 0,rt=0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    rt = Convert.ToInt32(ds2.Tables[0].Rows[0][0].ToString());
                else
                    rt = 0;
            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
                rt = 0;
            }


            if (ds3.Tables[0].Rows.Count > 0)
            {
                c = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                c = 0;
            }
            t = k;
            t = t + c;
            Label1.Text = t.ToString();
            Label9.Text = c.ToString();
            u = d - rt;
            Label13.Text = u.ToString();
            con1.Open();
            SqlDataAdapter da10 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('TAUDHAKPUR OFFICE') AND date3 NOT BETWEEN '" + date1 + "' AND '" + date2 + "') AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            con1.Close();
            GridView2.DataSource = ds10;
            GridView2.DataBind();
            con1.Open();
            SqlDataAdapter da12 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('TAUDHAKPUR OFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds12 = new DataSet();
            da12.Fill(ds12);
            con1.Close();
            GridView3.DataSource = ds12;
            GridView3.DataBind();
        }
        if (DropDownList2.Text == "RAMAIPUROFFICE")
        {
            Label1.Text = "";
            SqlConnection con1 = new SqlConnection(s);

            con1.Open();
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
            /*SqlDataAdapter da = new SqlDataAdapter("select count(CUSTREGNO) from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel'))", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();*/
            // con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(c.CUSTREGNO) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CHECKBY IN ('RAMAIPUROFFICE') AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con1.Close();
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('RAMAIPUROFFICE') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('RAMAIPUROFFICE') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter cmd5 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('RAMAIPUROFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds5 = new DataSet();
            cmd5.Fill(ds5);
            Double d,u;
            if (ds1.Tables[0].Rows.Count > 0)
            {
                d = Convert.ToDouble(ds5.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                d = 0;
            }
            Label12.Text = d.ToString();
            con1.Close();
            int c = 0, t = 0, k = 0,rt=0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    rt = Convert.ToInt32(ds2.Tables[0].Rows[0][0].ToString());
                else
                    rt = 0;
            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
                rt = 0;
            }


            if (ds3.Tables[0].Rows.Count > 0)
            {
                c = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                c = 0;
            }
            t = k;
            t = t + c;
            Label1.Text = t.ToString();
            Label9.Text = c.ToString();
            u = d - rt;
            Label13.Text = u.ToString();
            con1.Open();
            SqlDataAdapter da10 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('RAMAIPUROFFICE') AND date3 NOT BETWEEN '" + date1 + "' AND '" + date2 + "') AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            con1.Close();
            GridView2.DataSource = ds10;
            GridView2.DataBind();
            con1.Open();
            SqlDataAdapter da12 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('RAMAIPUROFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds12 = new DataSet();
            da12.Fill(ds12);
            con1.Close();
            GridView3.DataSource = ds12;
            GridView3.DataBind();
        }
        if (DropDownList2.Text == "MACHHARIYAOFFICE")
        {
            Label1.Text = "";
            SqlConnection con1 = new SqlConnection(s);

            con1.Open();
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
            /*SqlDataAdapter da = new SqlDataAdapter("select count(CUSTREGNO) from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel'))", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();*/
            // con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(c.CUSTREGNO) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CHECKBY IN ('MACHHARIYAOFFICE') AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con1.Close();
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('MACHHARIYAOFFICE') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('MACHHARIYAOFFICE') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter cmd5 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('MACHHARIYAOFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds5 = new DataSet();
            cmd5.Fill(ds5);
            Double d,u;
            if (ds1.Tables[0].Rows.Count > 0)
            {
                d = Convert.ToDouble(ds5.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                d = 0;
            }
            Label12.Text = d.ToString();
            con1.Close();

            GridView1.DataSource = ds1;
            GridView1.DataBind();
            int c = 0, t = 0, k = 0,rt=0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    rt = Convert.ToInt32(ds2.Tables[0].Rows[0][0].ToString());
                else
                    rt = 0;
            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
                rt = 0;
            }


            if (ds3.Tables[0].Rows.Count > 0)
            {
                c = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                c = 0;
            }
            t = k;
            t = t + c;
            Label1.Text = t.ToString();
            Label9.Text = c.ToString();
            u = d - rt;
            Label13.Text = u.ToString();
            con1.Open();
            SqlDataAdapter da10 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('MACHHARIYAOFFICE') AND date3 NOT BETWEEN '" + date1 + "' AND '" + date2 + "') AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            con1.Close();
            GridView2.DataSource = ds10;
            GridView2.DataBind();
            con1.Open();
            SqlDataAdapter da12 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('MACHHARIYAOFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds12 = new DataSet();
            da12.Fill(ds12);
            con1.Close();
            GridView3.DataSource = ds12;
            GridView3.DataBind();
        }
        if (DropDownList2.Text == "BROKER")
        {
            Label1.Text = "";
            SqlConnection con1 = new SqlConnection(s);

            con1.Open();
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
            /*SqlDataAdapter da = new SqlDataAdapter("select count(CUSTREGNO) from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel'))", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();*/
            // con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(c.CUSTREGNO) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con1.Close();
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter cmd5 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
            DataSet ds5 = new DataSet();
            cmd5.Fill(ds5);
            Double d,u;
            if (ds5.Tables[0].Rows.Count > 0)
            {
                d = Convert.ToDouble(ds5.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                d = 0;
            }
            Label12.Text = d.ToString();
            con1.Close();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            int c = 0, t = 0, k = 0,rt=0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    rt = Convert.ToInt32(ds2.Tables[0].Rows[0][0].ToString());
                else
                    rt = 0;
            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
                rt = 0;
            }


            if (ds3.Tables[0].Rows.Count > 0)
            {
                c = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                c = 0;
            }
            t = k;
            t = t + c;
            Label1.Text = t.ToString();
            Label9.Text = c.ToString();
            u = d - rt;
            Label13.Text = u.ToString();
            con1.Open();
            SqlDataAdapter da10 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') AND date3 NOT BETWEEN '" + date1 + "' AND '" + date2 + "') AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            con1.Close();
            GridView2.DataSource = ds10;
            GridView2.DataBind();
            con1.Open();
            SqlDataAdapter da12 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,AMOUNTR AS 'PAID' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "') AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds12 = new DataSet();
            da12.Fill(ds12);
            con1.Close();
            GridView3.DataSource = ds12;
            GridView3.DataBind();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        GridView2.Visible = false;
        GridView3.Visible = false;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView2.Visible = true;
        GridView3.Visible = false;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView3.Visible = true;
        GridView2.Visible = false;
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string f = e.Row.Cells[7].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "Cancel")
                {
                    cell.BackColor = Color.Red;
                }


            }
        }
    }
}