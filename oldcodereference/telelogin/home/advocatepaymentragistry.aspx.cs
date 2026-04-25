
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Services;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;

public partial class dialer_paymentragistry : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel2.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string s3 = TextBox2.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        string date2 = mm1 + "/" + dd1 + "/" + yy1;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT ID,CUSTREGNO,DATE,ARAZINO,PLOTNO,PLOTSIZE,regtype,status,REGAMOUNT,PAYAMOUNT,(REGAMOUNT-PAYAMOUNT) AS 'BALANCE' from ragfistrypay WHERE DATE between '" + date1+"' AND '"+date2+"'  ORDER BY DATE ASC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT sum(REGAMOUNT),sum(PAYAMOUNT) from ragfistrypay WHERE DATE between '" + date1 + "' AND '" + date2 + "'  ", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT count(ID) from ragfistrypay WHERE regtype='FREE' AND DATE between '" + date1 + "' AND '" + date2 + "'  ", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        Double rec = 0, pay = 0, bal = 0;
        if (ds3.Tables[0].Rows[0][0].ToString() != "")
        {
            Label6.Text =ds3.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            Label6.Text = "0";
        }
        if (ds2.Tables[0].Rows.Count > 0)
        {
            if (ds2.Tables[0].Rows[0][0].ToString() != "")
            {
                rec = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                rec = 0;
            }
            if (ds2.Tables[0].Rows[0][1].ToString() != "")
            {
                pay = Convert.ToDouble(ds2.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                pay = 0;
            }
            bal = rec - pay;
            Label2.Text = rec.ToString("N0");
            Label3.Text = pay.ToString("N0");
            Label4.Text = bal.ToString("N0");
        }
        else
        {
            Label2.Text = rec.ToString("N0");
            Label3.Text = pay.ToString("N0");
            Label4.Text = bal.ToString("N0");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT ID,CUSTREGNO,DATE,ARAZINO,PLOTNO,PLOTSIZE,regtype,status,REGAMOUNT,PAYAMOUNT,(REGAMOUNT-PAYAMOUNT) AS 'BALANCE' from ragfistrypay  ORDER BY DATE ASC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT sum(REGAMOUNT),sum(PAYAMOUNT) from ragfistrypay", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT count(ID) from ragfistrypay WHERE regtype='FREE'", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        Double rec = 0, pay = 0, bal = 0;
        if (ds3.Tables[0].Rows[0][0].ToString() != "")
        {
            Label6.Text = ds3.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            Label6.Text = "0";
        }
       // Double rec=0, pay=0, bal = 0;
        if (ds2.Tables[0].Rows.Count > 0)
        {
            if (ds2.Tables[0].Rows[0][0].ToString() != "")
            {
                rec = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                rec = 0;
            }
            if (ds2.Tables[0].Rows[0][1].ToString() != "")
            {
                pay = Convert.ToDouble(ds2.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                pay = 0;
            }
            bal = rec - pay;
            Label2.Text = rec.ToString("N0");
            Label3.Text = pay.ToString("N0");
            Label4.Text = bal.ToString("N0");
        }
        else
        {
            Label2.Text = rec.ToString("N0");
            Label3.Text = pay.ToString("N0");
            Label4.Text = bal.ToString("N0");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        String arazi = "", plotno = "", plotsize = "";
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO FROM ragfistrypay ", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        int c = 0;
        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        {
            if(ds.Tables[0].Rows[j][0].ToString()==TextBox3.Text)
            {
                c = 1;
                break;
            }
        }
        if (c!= 0)
        {
            Label5.Text = "Record Already Exist";
        }
        else
        {
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select CUSTREGNO,APPNO,PLOTSIZE,plotno FROM wjstar1.customerreg1", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            int c1 = 0,j=0;
            for ( j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (ds1.Tables[0].Rows[j][0].ToString() == TextBox3.Text)
                {
                    c1 = 1;
                    break;
                }
            }
            if (c1 == 0)
            {
                Label5.Text = "Record NOT Found In Bond List";
            }
            else
            {
                if (ds1.Tables[0].Rows[j][1].ToString() != "")
                {
                    arazi = ds1.Tables[0].Rows[j][1].ToString();
                }
                if (ds1.Tables[0].Rows[j][2].ToString() != "")
                {
                    plotsize = ds1.Tables[0].Rows[j][2].ToString();
                }
                if (ds1.Tables[0].Rows[j][3].ToString() != "")
                {
                    plotno = ds1.Tables[0].Rows[j][3].ToString();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into ragfistrypay(CUSTREGNO,ARAZINO,PLOTNO,PLOTSIZE,REGAMOUNT,PAYAMOUNT,regtype,status)values('" + TextBox3.Text+"','"+arazi+"','"+plotno+"','"+plotsize+"',"+TextBox4.Text+","+TextBox5.Text+",'"+DropDownList1.Text+"',NULL)",con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    Label5.Text = "Record Added";
                    con.Open();
                    SqlDataAdapter da8 = new SqlDataAdapter("SELECT TOP 3 ID,CUSTREGNO,DATE,ARAZINO,PLOTNO,PLOTSIZE,regtype,status,REGAMOUNT,PAYAMOUNT,(REGAMOUNT-PAYAMOUNT) AS 'BALANCE' from ragfistrypay  ORDER BY ID DESC", con);
                    DataSet ds8 = new DataSet();
                    da8.Fill(ds8);
                    con.Close();
                    GridView1.DataSource = ds8;
                    GridView1.DataBind();
                }


            }
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            // {
            string StatusValue = (e.Row.FindControl("camount4") as Label).Text;
            //  e.Row.Cells[1].Text;    string f = 

            if (StatusValue == "FREE")
            {

                (e.Row.FindControl("camount4") as Label).ForeColor = Color.Red;
            }
           
            // }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
       // con.Open();
        SqlCommand cmd = new SqlCommand("delete from  ragfistrypay where ID="+TextBox6.Text+"", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label5.Text = "Record Deleted";
            con.Open();
            SqlDataAdapter da8 = new SqlDataAdapter("SELECT TOP 3 ID,CUSTREGNO,DATE,ARAZINO,PLOTNO,PLOTSIZE,regtype,status,REGAMOUNT,PAYAMOUNT,(REGAMOUNT-PAYAMOUNT) AS 'BALANCE' from ragfistrypay  ORDER BY ID DESC", con);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            con.Close();
            GridView1.DataSource = ds8;
            GridView1.DataBind();

        }

    }
}