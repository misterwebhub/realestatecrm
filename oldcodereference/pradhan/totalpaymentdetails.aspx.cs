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
using System.Globalization;

public partial class totalpaymentdetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label4.Visible = false;
            DropDownList4.Visible = false;
           bind2();

        }
    }
	 public void bind2()
    {
        DropDownList6.Items.Clear();
        // DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT name from addname", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList6.Items.Add("---SELECT----");
        // DropDownList4.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList6.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            //  DropDownList4.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        string dateString1 = TextBox1.Text;
        string dateString2 = TextBox2.Text;
        string format = "dd/mm/yyyy";
        DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
        string ddd1 = dateTime1.ToString("mm/dd/yyyy");
        DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
        string ddd2 = dateTime2.ToString("mm/dd/yyyy");
        if (DropDownList1.Text != "152")
        {
            SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REGNO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.CONSAMOUNT AS 'TOTALAMOUNT',r.PAID AS 'PA',(c.CONSAMOUNT-r.PAID) AS 'BALANCE',c.INSTSUBPAY AS 'EMI',FLOOR(c.CONSAMOUNT/NULLIF(c.PLOTSIZE,0)) AS 'RATE',c.PLOTSIZE AS 'PLOTSIZE',c.plotno AS 'PLOTNO',c.regstatus AS 'STATUS',c.CHECKBY AS 'BROKAR' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1  where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND date3 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND date3 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            Double totalamt, paidalamt;
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                totalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                totalamt = 0;
            }
            if (ds1.Tables[0].Rows[0][1].ToString() != "")
            {
                paidalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                paidalamt = 0;
            }
            
            GridView1.DataSource = ds;
            GridView1.DataBind();
            Double bal = totalamt - paidalamt;
            Label1.Text = totalamt.ToString();
            Label2.Text = paidalamt.ToString();
            Label3.Text = bal.ToString();
        }
        else
        {
            if (DropDownList4.Text == "E" || DropDownList4.Text == "D" || DropDownList4.Text == "F")
            {
                SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REGNO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.CONSAMOUNT AS 'TOTALAMOUNT',r.PAID AS 'PA',(c.CONSAMOUNT-r.PAID) AS 'BALANCE',c.INSTSUBPAY AS 'EMI',FLOOR(c.CONSAMOUNT/NULLIF(c.PLOTSIZE,0)) AS 'RATE',c.PLOTSIZE AS 'PLOTSIZE',c.plotno AS 'PLOTNO',c.regstatus AS 'STATUS',c.CHECKBY AS 'BROKAR' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND status='book' AND plotno IN(select plotno from addaraziplot where name='" + DropDownList6.Text + "' AND arazi='" + DropDownList1.Text + "' AND block='" + DropDownList4.Text + "' )) AND date3 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') )  GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                con.Open();

                SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID,max(DATE1)  AS MK from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND status='book' AND plotno IN(select plotno from addaraziplot where name='" + DropDownList6.Text + "' AND arazi='" + DropDownList1.Text + "' AND block='" + DropDownList4.Text + "' )) AND date3 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                Double totalamt, paidalamt;
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    totalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    totalamt = 0;
                }
                if (ds1.Tables[0].Rows[0][1].ToString() != "")
                {
                    paidalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    paidalamt = 0;
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Double bal = totalamt - paidalamt;
                Label1.Text = totalamt.ToString();
                Label2.Text = paidalamt.ToString();
                Label3.Text = bal.ToString();
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REGNO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.CONSAMOUNT AS 'TOTALAMOUNT',r.PAID AS 'PA',(c.CONSAMOUNT-r.PAID) AS 'BALANCE',c.INSTSUBPAY AS 'EMI',FLOOR(c.CONSAMOUNT/NULLIF(c.PLOTSIZE,0)) AS 'RATE',c.PLOTSIZE AS 'PLOTSIZE',c.plotno AS 'PLOTNO',c.regstatus AS 'STATUS',c.CHECKBY AS 'BROKAR' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C')) AND date3 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') ) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                con.Open();

                SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where  block IN ('A','B','C')) AND date3 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                Double totalamt, paidalamt;
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    totalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    totalamt = 0;
                }
                if (ds1.Tables[0].Rows[0][1].ToString() != "")
                {
                    paidalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    paidalamt = 0;
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Double bal = totalamt - paidalamt;
                Label1.Text = totalamt.ToString();
                Label2.Text = paidalamt.ToString();
                Label3.Text = bal.ToString();
            }
        }
       // GridView2.DataSource = ds1;
        //GridView2.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string f = e.Row.Cells[9].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "Registry")
                {
                    cell.BackColor = Color.Yellow;
                }

            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        if (DropDownList1.Text != "152")
        {
            SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REGNO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.CONSAMOUNT AS 'TOTALAMOUNT',r.PAID AS 'PA',(c.CONSAMOUNT-r.PAID) AS 'BALANCE',c.INSTSUBPAY AS 'EMI',FLOOR(c.CONSAMOUNT/NULLIF(c.PLOTSIZE,0)) AS 'RATE',c.PLOTSIZE AS 'PLOTSIZE',c.plotno AS 'PLOTNO',c.regstatus AS 'STATUS',c.CHECKBY AS 'BROKAR' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "'  AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') )  ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            Double totalamt, paidalamt;
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                totalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                totalamt = 0;
            }
            if (ds1.Tables[0].Rows[0][1].ToString() != "")
            {
                paidalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                paidalamt = 0;
            }

            GridView1.DataSource = ds;
            GridView1.DataBind();
            Double bal = totalamt - paidalamt;
            Label1.Text = totalamt.ToString();
            Label2.Text = paidalamt.ToString();
            Label3.Text = bal.ToString();
        }
        else
        {
            if (DropDownList4.Text == "E" || DropDownList4.Text == "D" || DropDownList4.Text == "F")
            {
                SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REGNO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.CONSAMOUNT AS 'TOTALAMOUNT',r.PAID AS 'PA',(c.CONSAMOUNT-r.PAID) AS 'BALANCE',c.INSTSUBPAY AS 'EMI',FLOOR(c.CONSAMOUNT/NULLIF(c.PLOTSIZE,0)) AS 'RATE',c.PLOTSIZE AS 'PLOTSIZE',c.plotno AS 'PLOTNO',c.regstatus AS 'STATUS',c.CHECKBY AS 'BROKAR' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND status='book' AND plotno IN(select plotno from addaraziplot where name='" + DropDownList6.Text + "' AND arazi='" + DropDownList1.Text + "' AND block='" + DropDownList4.Text + "' )) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') )  ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                con.Open();

                SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND status='book' AND plotno IN(select plotno from addaraziplot where name='" + DropDownList6.Text + "' AND arazi='" + DropDownList1.Text + "' AND block='" + DropDownList4.Text + "' )) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                Double totalamt, paidalamt;
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    totalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    totalamt = 0;
                }
                if (ds1.Tables[0].Rows[0][1].ToString() != "")
                {
                    paidalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    paidalamt = 0;
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Double bal = totalamt - paidalamt;
                Label1.Text = totalamt.ToString();
                Label2.Text = paidalamt.ToString();
                Label3.Text = bal.ToString();
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REGNO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.CONSAMOUNT AS 'TOTALAMOUNT',r.PAID AS 'PA',(c.CONSAMOUNT-r.PAID) AS 'BALANCE',c.INSTSUBPAY AS 'EMI',FLOOR(c.CONSAMOUNT/NULLIF(c.PLOTSIZE,0)) AS 'RATE',c.PLOTSIZE AS 'PLOTSIZE',c.plotno AS 'PLOTNO',c.regstatus AS 'STATUS',c.CHECKBY AS 'BROKAR' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C')) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') )  ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                con.Open();

                SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where  block IN ('A','B','C')) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                Double totalamt, paidalamt;
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    totalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    totalamt = 0;
                }
                if (ds1.Tables[0].Rows[0][1].ToString() != "")
                {
                    paidalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
                }
                else
                {
                    paidalamt = 0;
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Double bal = totalamt - paidalamt;
                Label1.Text = totalamt.ToString();
                Label2.Text = paidalamt.ToString();
                Label3.Text = bal.ToString();
            }
        }
























       /* SqlConnection con = new SqlConnection(s);
        con.Open();
       /* string dateString1 = TextBox1.Text;
        string dateString2 = TextBox2.Text;
        string format = "dd/mm/yyyy";
        DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
        string ddd1 = dateTime1.ToString("mm/dd/yyyy");
        DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
        string ddd2 = dateTime2.ToString("mm/dd/yyyy");*/
       /* SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REGNO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.CONSAMOUNT AS 'TOTALAMOUNT',r.PAID AS 'PA',(c.CONSAMOUNT-r.PAID) AS 'BALANCE',c.INSTSUBPAY AS 'EMI',FLOOR(c.CONSAMOUNT/NULLIF(c.PLOTSIZE,0)) AS 'RATE',c.PLOTSIZE AS 'PLOTSIZE',c.plotno AS 'PLOTNO',c.regstatus AS 'STATUS',c.CHECKBY AS 'BROKAR' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND  CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') )  ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();

        SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
 Double totalamt, paidalamt;
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                totalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                totalamt = 0;
            }
            if (ds1.Tables[0].Rows[0][1].ToString() != "")
            {
                paidalamt = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                paidalamt = 0;
            }
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Double bal = totalamt - paidalamt;
        Label1.Text = totalamt.ToString();
        Label2.Text = paidalamt.ToString();
        Label3.Text = bal.ToString();*/

    }
	protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind4();
    }
	public void bind4()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazi from addarazidemo where name='" + DropDownList6.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        con.Close();
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text != "152")
        {
            DropDownList4.Visible = false;
            Label4.Visible = false;
        }
        else
        {SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT block from addarazidemo where name='" + DropDownList6.Text + "' AND arazi='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "YES")
            {
                DropDownList4.Items.Clear();
                Label4.Visible = true;
                DropDownList4.Visible = true;
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("select DISTINCT block from addaraziplot where name='" + DropDownList6.Text + "' AND arazi='" + DropDownList1.Text + "'", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                DropDownList4.Items.Add("---Select---");
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        DropDownList4.Items.Add(ds1.Tables[0].Rows[i][0].ToString());
                    }
                }
                    

            }
            else
            {
                Label4.Visible = false;
                DropDownList4.Visible = false;
            }
        }
        else
        {
            Label4.Visible = false;
            DropDownList4.Visible = false;
        }
        }
    }
}