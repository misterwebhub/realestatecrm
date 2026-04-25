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

public partial class totalpaymentdetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from ploted1", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            con.Close();


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
   //    SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO,SUBSTRING(r.NAMEDOBADDRESS,1,28) AS 'NAME',r.date3 AS 'DATE',r.PLANANDTERM AS 'PLAN',r.CONSAMOUNT AS 'PLOT VALUE',r.INSTSUBPAY,r.plotno AS 'PLOT NO',r.PLOTSIZE AS 'PLOT SIZE',r.mobile from customerreg1 r LEFT JOIN (select u.CUSTREGNO,sum(u.AMOUNTR) from recipt1 u  GROUP BY CUSTREGNO)", con);
        //SqlDataAdapter da = new SqlDataAdapter("(select CUSTREGNO AS 'REG NO',SUBSTRING(NAMEDOBADDRESS,1,15) AS 'NAME',date3 AS 'DATE',PLANANDTERM AS 'PLAN',CONSAMOUNT AS 'TOTAL AMOUNT',INSTSUBPAY AS 'INSTALLMENT',PLOTSIZE AS 'PLOT SIZE',plotno AS 'PLOT NO',mobile AS 'MOBILE',regstatus AS 'STATUS ' from customerreg1 where APPNO='" + DropDownList1.Text + "')UNION (select CUSTREGNO AS 'REG NO',sum(AMOUNTR) AS 'PAID AMOUNT' from recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from customerreg1 where APPNO='" + DropDownList1.Text + "'))", con);
       // SqlDataAdapter da1 = new SqlDataAdapter("select CUSTREGNO AS 'REG NO',sum(AMOUNTR) AS 'PAID AMOUNT' from recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from customerreg1 where APPNO='" + DropDownList1.Text + "') ", con);
        SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REG NO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.PLANANDTERM AS 'PLAN',c.CONSAMOUNT AS 'TOTAL AMOUNT',c.INSTSUBPAY AS 'INSTALLMENT',c.PLOTSIZE AS 'PLOT SIZE',c.plotno AS 'PLOT NO',c.mobile AS 'MOBILE',c.regstatus AS 'STATUS ',r.amtrcv from (select CUSTREGNO,sum(AMOUNTR) AS amtrcv from  recipt1 GROUP BY CUSTREGNO) AS r INNER JOIN customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        //sum(AMOUNTR)
       // con.Open();
       // SqlDataAdapter da1 = new SqlDataAdapter("select CUSTREGNO from recipt1 where CUSTREGNO IN (select CUSTREGNO from customerreg1 where APPNO='" + DropDownList1.Text + "') GROUP By CUSTREGNO ", con);
       // DataSet ds1 = new DataSet();
        //da1.Fill(ds1);
       // con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
       // GridView2.DataSource = ds1;
        //GridView2.DataBind();
    }
}