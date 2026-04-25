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


public partial class regcount : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
 if (!IsPostBack)
        {
	 if(Session["ID"] != null)
			{
				Label11.Text = Session["ID"].ToString();
			   //Label13.Text = "heedrealestate";
			}
			else
				
			{
				Response.Redirect("~/home/usercredential/credential.aspx");
			}
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
        Label1.Text = "";
        SqlConnection con1 = new SqlConnection(s);

       
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
      /*  SqlDataAdapter da5 = new SqlDataAdapter("select sum(c.CONSAMOUNT),c.CONSAMOUNT*0.50 AS 'percentage' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds5 = new DataSet();
        da5.Fill(ds5);
        con1.Close();*/
        con1.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select count(c.CUSTREGNO) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con1.Close();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con1.Close(); 
        con1.Open();
            
		     SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con1.Close();
        con1.Open();
        SqlDataAdapter da5 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND APPNO IN('152','506','519','239','161GHA' ,'186MI','RAMAI137','217','187-KHA','419','356','320','353','356','357','2001GA','156','343','JDBHATTA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds50per = new DataSet();
        da5.Fill(ds50per);
        con1.Close();
        Double perc50=0,cal50=0;
        if (ds50per.Tables[0].Rows.Count > 0)
        {
            if (ds50per.Tables[0].Rows[0][0].ToString() != "")
            {
                perc50 = Convert.ToDouble(ds50per.Tables[0].Rows[0][0].ToString());
                cal50 = perc50 * 0.50;
            }
            else
            {
                perc50 = 0;
                cal50 = perc50 * 0.50;
            }
        }
        else
        {
            perc50 = 0;
            cal50 = perc50 * 0.50;
        }
        con1.Open();
        SqlDataAdapter da6 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND APPNO IN('375KA','30','174MI','372KA','385KA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds35per = new DataSet();
        da6.Fill(ds35per);
        con1.Close();
        Double perc35 = 0, cal35 = 0;
        if (ds35per.Tables[0].Rows.Count > 0)
        {
            if (ds35per.Tables[0].Rows[0][0].ToString() != "")
            {
                perc35 = Convert.ToDouble(ds35per.Tables[0].Rows[0][0].ToString());
                cal35 = perc35 * 0.35;
            }
            else
            {
                perc35 = 0;
                cal35 = perc35 * 0.35;
            }
        }
        else
        {
            perc35 = 0;
            cal35 = perc35 * 0.35;
        }
        con1.Open();
        SqlDataAdapter da7 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND APPNO IN('0','100','1204','1412','1414 surpal','1989','2011','24KA','254','274','239A','343','364','369','432','436','1989') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds25per = new DataSet();
        da7.Fill(ds25per);
        con1.Close();
        Double perc25 = 0, cal25 = 0;
        if (ds25per.Tables[0].Rows.Count > 0)
        {
            if (ds25per.Tables[0].Rows[0][0].ToString() != "")
            {
                perc25 = Convert.ToDouble(ds25per.Tables[0].Rows[0][0].ToString());
                cal25 = perc25 * 0.25;
            }
            else
            {
                perc25 = 0;
                cal25 = perc25 * 0.25;
            }
        }
        else
        {
            perc25 = 0;
            cal25 = perc25 * 0.25;
        }
        Double finaltotalvalue=0,finalpervalue=0;
        finaltotalvalue = perc50 + perc35 + perc25;
        finalpervalue = cal50 + cal35 + cal25;
        Label13.Text = finaltotalvalue.ToString();
        Label14.Text = finalpervalue.ToString();
       GridView1.DataSource = ds1;
        GridView1.DataBind();
        Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
		Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
        Double balacne = finalpervalue - Convert.ToDouble(Label8.Text);
        Label15.Text = balacne.ToString();
        int c = 0,t=0;
        if (ds3.Tables[0].Rows.Count > 0)
        {
            c = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            c = 0;
        }
        t = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
        t = t + c;
        Label1.Text = t.ToString();
        Label9.Text = c.ToString();
        con1.Open();
        SqlDataAdapter da4 = new SqlDataAdapter("select sum(c.PLOTSIZE) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
        con1.Close();
        int gz = 0;
        if (ds4.Tables[0].Rows.Count > 0)
        {
            gz = Convert.ToInt32(ds4.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            gz = 0;
        }
        Label12.Text = gz.ToString();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string f = e.Row.Cells[8].Text;

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

            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('office') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('office') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('office') AND APPNO IN('152','506','519','239','161GHA' ,'186MI','RAMAI137','217','187-KHA','419','356','320','353','356','357','2001GA','156','343','JDBHATTA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds50per = new DataSet();
            da5.Fill(ds50per);
            con1.Close();
            Double perc50 = 0, cal50 = 0;
            if (ds50per.Tables[0].Rows.Count > 0)
            {
                if (ds50per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc50 = Convert.ToDouble(ds50per.Tables[0].Rows[0][0].ToString());
                    cal50 = perc50 * 0.50;
                }
                else
                {
                    perc50 = 0;
                    cal50 = perc50 * 0.50;
                }
            }
            else
            {
                perc50 = 0;
                cal50 = perc50 * 0.50;
            }
            con1.Open();
            SqlDataAdapter da6 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('office') AND APPNO IN('375KA','30','174MI','372KA','385KA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds35per = new DataSet();
            da6.Fill(ds35per);
            con1.Close();
            Double perc35 = 0, cal35 = 0;
            if (ds35per.Tables[0].Rows.Count > 0)
            {
                if (ds35per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc35 = Convert.ToDouble(ds35per.Tables[0].Rows[0][0].ToString());
                    cal35 = perc35 * 0.35;
                }
                else
                {
                    perc35 = 0;
                    cal35 = perc35 * 0.35;
                }
            }
            else
            {
                perc35 = 0;
                cal35 = perc35 * 0.35;
            }
            con1.Open();
            SqlDataAdapter da7 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('office') AND APPNO IN('0','100','1204','1412','1414 surpal','1989','2011','24KA','254','274','239A','343','364','369','432','436','1989') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds25per = new DataSet();
            da7.Fill(ds25per);
            con1.Close();
            Double perc25 = 0, cal25 = 0;
            if (ds25per.Tables[0].Rows.Count > 0)
            {
                if (ds25per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc25 = Convert.ToDouble(ds25per.Tables[0].Rows[0][0].ToString());
                    cal25 = perc25 * 0.25;
                }
                else
                {
                    perc25 = 0;
                    cal25 = perc25 * 0.25;
                }
            }
            else
            {
                perc25 = 0;
                cal25 = perc25 * 0.25;
            }
            Double finaltotalvalue = 0, finalpervalue = 0;
            finaltotalvalue = perc50 + perc35 + perc25;
            finalpervalue = cal50 + cal35 + cal25;
            Label13.Text = finaltotalvalue.ToString();
            Label14.Text = finalpervalue.ToString();

            GridView1.DataSource = ds1;
            GridView1.DataBind();
            int c = 0, t = 0,k=0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
               k= Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label10.Text ="0";
                Label8.Text = "0";
                k = 0;
            }

         
            Double balacne = finalpervalue - Convert.ToDouble(Label8.Text);
            Label15.Text = balacne.ToString();
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
            SqlDataAdapter da4 = new SqlDataAdapter("select sum(c.PLOTSIZE) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('office') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con1.Close();
            int gz = 0;
            if (ds4.Tables[0].Rows.Count > 0)
            {
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    gz = Convert.ToInt32(ds4.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    gz = 0;
                }
            }
            else
            {
                gz = 0;
            }
            Label12.Text = gz.ToString();
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

            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('TAUDHAKPUR OFFICE') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('TAUDHAKPUR OFFICE') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('TAUDHAKPUR OFFICE') AND APPNO IN('152','506','519','239','161GHA' ,'186MI','RAMAI137','217','187-KHA','419','356','320','353','356','357','2001GA','156','343','JDBHATTA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds50per = new DataSet();
            da5.Fill(ds50per);
            con1.Close();
            Double perc50 = 0, cal50 = 0;
            if (ds50per.Tables[0].Rows.Count > 0)
            {
                if (ds50per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc50 = Convert.ToDouble(ds50per.Tables[0].Rows[0][0].ToString());
                    cal50 = perc50 * 0.50;
                }
                else
                {
                    perc50 = 0;
                    cal50 = perc50 * 0.50;
                }
            }
            else
            {
                perc50 = 0;
                cal50 = perc50 * 0.50;
            }
            con1.Open();
            SqlDataAdapter da6 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('TAUDHAKPUR OFFICE') AND APPNO IN('375KA','30','174MI','372KA','385KA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds35per = new DataSet();
            da6.Fill(ds35per);
            con1.Close();
            Double perc35 = 0, cal35 = 0;
            if (ds35per.Tables[0].Rows.Count > 0)
            {
                if (ds35per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc35 = Convert.ToDouble(ds35per.Tables[0].Rows[0][0].ToString());
                    cal35 = perc35 * 0.35;
                }
                else
                {
                    perc35 = 0;
                    cal35 = perc35 * 0.35;
                }
            }
            else
            {
                perc35 = 0;
                cal35 = perc35 * 0.35;
            }
            con1.Open();
            SqlDataAdapter da7 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('TAUDHAKPUR OFFICE') AND APPNO IN('0','100','1204','1412','1414 surpal','1989','2011','24KA','254','274','239A','343','364','369','432','436','1989') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds25per = new DataSet();
            da7.Fill(ds25per);
            con1.Close();
            Double perc25 = 0, cal25 = 0;
            if (ds25per.Tables[0].Rows.Count > 0)
            {
                if (ds25per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc25 = Convert.ToDouble(ds25per.Tables[0].Rows[0][0].ToString());
                    cal25 = perc25 * 0.25;
                }
                else
                {
                    perc25 = 0;
                    cal25 = perc25 * 0.25;
                }
            }
            else
            {
                perc25 = 0;
                cal25 = perc25 * 0.25;
            }
            Double finaltotalvalue = 0, finalpervalue = 0;
            finaltotalvalue = perc50 + perc35 + perc25;
            finalpervalue = cal50 + cal35 + cal25;
            Label13.Text = finaltotalvalue.ToString();
            Label14.Text = finalpervalue.ToString();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            int c = 0, t = 0, k = 0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
            }
            
            Double balacne = finalpervalue - Convert.ToDouble(Label8.Text);
            Label15.Text = balacne.ToString();

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
            SqlDataAdapter da4 = new SqlDataAdapter("select sum(c.PLOTSIZE) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('TAUDHAKPUR OFFICE') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con1.Close();
            int gz = 0;
            if (ds4.Tables[0].Rows.Count > 0)
            {
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    gz = Convert.ToInt32(ds4.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    gz = 0;
                }
            }
            else
            {
                gz = 0;
            }
            Label12.Text = gz.ToString();
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

            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('RAMAIPUROFFICE') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('RAMAIPUROFFICE') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('RAMAIPUROFFICE') AND APPNO IN('152','506','519','239','161GHA' ,'186MI','RAMAI137','217','187-KHA','419','356','320','353','356','357','2001GA','156','343','JDBHATTA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds50per = new DataSet();
            da5.Fill(ds50per);
            con1.Close();
            Double perc50 = 0, cal50 = 0;
            if (ds50per.Tables[0].Rows.Count > 0)
            {
                if (ds50per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc50 = Convert.ToDouble(ds50per.Tables[0].Rows[0][0].ToString());
                    cal50 = perc50 * 0.50;
                }
                else
                {
                    perc50 = 0;
                    cal50 = perc50 * 0.50;
                }
            }
            else
            {
                perc50 = 0;
                cal50 = perc50 * 0.50;
            }
            con1.Open();
            SqlDataAdapter da6 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('RAMAIPUROFFICE') AND APPNO IN('375KA','30','174MI','372KA','385KA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds35per = new DataSet();
            da6.Fill(ds35per);
            con1.Close();
            Double perc35 = 0, cal35 = 0;
            if (ds35per.Tables[0].Rows.Count > 0)
            {
                if (ds35per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc35 = Convert.ToDouble(ds35per.Tables[0].Rows[0][0].ToString());
                    cal35 = perc35 * 0.35;
                }
                else
                {
                    perc35 = 0;
                    cal35 = perc35 * 0.35;
                }
            }
            else
            {
                perc35 = 0;
                cal35 = perc35 * 0.35;
            }
            con1.Open();
            SqlDataAdapter da7 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('RAMAIPUROFFICE') AND APPNO IN('0','100','1204','1412','1414 surpal','1989','2011','24KA','254','274','239A','343','364','369','432','436','1989') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds25per = new DataSet();
            da7.Fill(ds25per);
            con1.Close();
            Double perc25 = 0, cal25 = 0;
            if (ds25per.Tables[0].Rows.Count > 0)
            {
                if (ds25per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc25 = Convert.ToDouble(ds25per.Tables[0].Rows[0][0].ToString());
                    cal25 = perc25 * 0.25;
                }
                else
                {
                    perc25 = 0;
                    cal25 = perc25 * 0.25;
                }
            }
            else
            {
                perc25 = 0;
                cal25 = perc25 * 0.25;
            }
            Double finaltotalvalue = 0, finalpervalue = 0;
            finaltotalvalue = perc50 + perc35 + perc25;
            finalpervalue = cal50 + cal35 + cal25;
            Label13.Text = finaltotalvalue.ToString();
            Label14.Text = finalpervalue.ToString();
            int c = 0, t = 0, k = 0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Label8.Text = "0";
                }

            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
            }
            Double balacne = finalpervalue - Convert.ToDouble(Label8.Text);
            Label15.Text = balacne.ToString();

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
            SqlDataAdapter da4 = new SqlDataAdapter("select sum(c.PLOTSIZE) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('RAMAIPUROFFICE') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con1.Close();
            int gz = 0;
            if (ds4.Tables[0].Rows.Count > 0)
            {
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    if (ds4.Tables[0].Rows[0][0].ToString() != "")
                    {
                        gz = Convert.ToInt32(ds4.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        gz = 0;
                    }
                }
                else
                {
                    gz = 0;
                }
            }
            else
            {
                gz = 0;
            }
            Label12.Text = gz.ToString();
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

            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('MACHHARIYAOFFICE') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('MACHHARIYAOFFICE') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('MACHHARIYAOFFICE') AND APPNO IN('152','506','519','239','161GHA' ,'186MI','RAMAI137','217','187-KHA','419','356','320','353','356','357','2001GA','156','343','JDBHATTA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds50per = new DataSet();
            da5.Fill(ds50per);
            con1.Close();
            Double perc50 = 0, cal50 = 0;
            if (ds50per.Tables[0].Rows.Count > 0)
            {
                if (ds50per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc50 = Convert.ToDouble(ds50per.Tables[0].Rows[0][0].ToString());
                    cal50 = perc50 * 0.50;
                }
                else
                {
                    perc50 = 0;
                    cal50 = perc50 * 0.50;
                }
            }
            else
            {
                perc50 = 0;
                cal50 = perc50 * 0.50;
            }
            con1.Open();
            SqlDataAdapter da6 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('MACHHARIYAOFFICE') AND APPNO IN('375KA','30','174MI','372KA','385KA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds35per = new DataSet();
            da6.Fill(ds35per);
            con1.Close();
            Double perc35 = 0, cal35 = 0;
            if (ds35per.Tables[0].Rows.Count > 0)
            {
                if (ds35per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc35 = Convert.ToDouble(ds35per.Tables[0].Rows[0][0].ToString());
                    cal35 = perc35 * 0.35;
                }
                else
                {
                    perc35 = 0;
                    cal35 = perc35 * 0.35;
                }
            }
            else
            {
                perc35 = 0;
                cal35 = perc35 * 0.35;
            }
            con1.Open();
            SqlDataAdapter da7 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY IN ('MACHHARIYAOFFICE') AND APPNO IN('0','100','1204','1412','1414 surpal','1989','2011','24KA','254','274','239A','343','364','369','432','436','1989') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds25per = new DataSet();
            da7.Fill(ds25per);
            con1.Close();
            Double perc25 = 0, cal25 = 0;
            if (ds25per.Tables[0].Rows.Count > 0)
            {
                if (ds25per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc25 = Convert.ToDouble(ds25per.Tables[0].Rows[0][0].ToString());
                    cal25 = perc25 * 0.25;
                }
                else
                {
                    perc25 = 0;
                    cal25 = perc25 * 0.25;
                }
            }
            else
            {
                perc25 = 0;
                cal25 = perc25 * 0.25;
            }
            Double finaltotalvalue = 0, finalpervalue = 0;
            finaltotalvalue = perc50 + perc35 + perc25;
            finalpervalue = cal50 + cal35 + cal25;
            Label13.Text = finaltotalvalue.ToString();
            Label14.Text = finalpervalue.ToString();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            int c = 0, t = 0, k = 0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
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
            SqlDataAdapter da4 = new SqlDataAdapter("select sum(c.PLOTSIZE) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY IN ('MACHHARIYAOFFICE') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con1.Close();
            int gz = 0;
            if (ds4.Tables[0].Rows.Count > 0)
            {
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    gz = Convert.ToInt32(ds4.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    gz = 0;
                }
            }
            else
            {
                gz = 0;
            }
            Label12.Text = gz.ToString();
        }
        if (DropDownList2.Text == "BROKER" || DropDownList2.Text == "JKGROUP")
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

            SqlDataAdapter da1 = new SqlDataAdapter("select c.date3,c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAMEDOBADDRESS',c.APPNO,c.plotno,c.PLOTSIZE,c.CHECKBY,r.PAID,c.regstatus from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID),count(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus IN('Cancel')))) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            con1.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') AND APPNO IN('152','506','519','239','161GHA' ,'186MI','RAMAI137' ,'217','187-KHA','419','356','320','353','356','357','2001GA','156','343','JDBHATTA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds50per = new DataSet();
            da5.Fill(ds50per);
            con1.Close();
            Double perc50 = 0, cal50 = 0;
            if (ds50per.Tables[0].Rows.Count > 0)
            {
                if (ds50per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc50 = Convert.ToDouble(ds50per.Tables[0].Rows[0][0].ToString());
                    cal50 = perc50 * 0.50;
                }
                else
                {
                    perc50 = 0;
                    cal50 = perc50 * 0.50;
                }
            }
            else
            {
                perc50 = 0;
                cal50 = perc50 * 0.50;
            }
            con1.Open();
            SqlDataAdapter da6 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "'  AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') AND APPNO IN('375KA','30','174MI','372KA','385KA') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds35per = new DataSet();
            da6.Fill(ds35per);
            con1.Close();
            Double perc35 = 0, cal35 = 0;
            if (ds35per.Tables[0].Rows.Count > 0)
            {
                if (ds35per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc35 = Convert.ToDouble(ds35per.Tables[0].Rows[0][0].ToString());
                    cal35 = perc35 * 0.35;
                }
                else
                {
                    perc35 = 0;
                    cal35 = perc35 * 0.35;
                }
            }
            else
            {
                perc35 = 0;
                cal35 = perc35 * 0.35;
            }
            con1.Open();
            SqlDataAdapter da7 = new SqlDataAdapter("select sum(c.CONSAMOUNT) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') AND APPNO IN('0','100','1204','1412','1414 surpal','1989','2011','24KA','254','274','239A','343','364','369','432','436','1989') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds25per = new DataSet();
            da7.Fill(ds25per);
            con1.Close();
            Double perc25 = 0, cal25 = 0;
            if (ds25per.Tables[0].Rows.Count > 0)
            {
                if (ds25per.Tables[0].Rows[0][0].ToString() != "")
                {
                    perc25 = Convert.ToDouble(ds25per.Tables[0].Rows[0][0].ToString());
                    cal25 = perc25 * 0.25;
                }
                else
                {
                    perc25 = 0;
                    cal25 = perc25 * 0.25;
                }
            }
            else
            {
                perc25 = 0;
                cal25 = perc25 * 0.25;
            }
            Double finaltotalvalue = 0, finalpervalue = 0;
            finaltotalvalue = perc50 + perc35 + perc25;
            finalpervalue = cal50 + cal35 + cal25;
            Label13.Text = finaltotalvalue.ToString();
            Label14.Text = finalpervalue.ToString();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            int c = 0, t = 0, k = 0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds2.Tables[0].Rows[0][1].ToString();
                k = Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString());
                if (ds2.Tables[0].Rows[0][0].ToString() != " ")
                {
                    Label8.Text = ds2.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Label8.Text = "0";
                }

            }
            else
            {
                Label10.Text = "0";
                Label8.Text = "0";
                k = 0;
            }
            Double balacne = finalpervalue - Convert.ToDouble(Label8.Text);
            Label15.Text = balacne.ToString();

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
            SqlDataAdapter da4 = new SqlDataAdapter("select sum(c.PLOTSIZE) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CHECKBY NOT IN ('MACHHARIYAOFFICE','RAMAIPUROFFICE','TAUDHAKPUR OFFICE','office') )) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con1);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con1.Close();
            int gz = 0;
            if (ds4.Tables[0].Rows.Count > 0)
            {
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    gz = Convert.ToInt32(ds4.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    gz = 0;
                }
            }
            else
            {
                gz = 0;
            }
            Label12.Text = gz.ToString();
        }
    }
}