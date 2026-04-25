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
using System.Globalization;

public partial class home_Default : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("id119");
            lblname.Style.Add("color", "red");
        }

    }
    public void bind()
    {
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        string m = s2.Substring(3, 2);
        string y = s2.Substring(6, 4);
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select ID,RDATE,RAMOUNT,RREASON from expensetable where month(CDATE)=" + m + " AND year(CDATE)=" + y + "", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    public void balance1()
    {
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        string m = s2.Substring(3, 2);
        string y = s2.Substring(6, 4);
        // DateTime datetime1 = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
        // MessageBox.Show(oDate.ToString());
        // DateTime dateTime = Convert.ToDateTime(dateString);


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(RAMOUNT) from expensetable where month(CDATE)=" + m + " AND year(CDATE)=" + y + "", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(RAMOUNT) from extrapayment where month(RDATE)=" + m + " AND year(RDATE)=" + y + "", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select BACKAMT,CURAMT from expensetable where month(CDATE)=" + m + " AND year(CDATE)=" + y + "", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Double total = 0, expamt = 0, balamt = 0, backamt = 0, curamt = 0,ext=0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            ext = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            Label7.Text = ext.ToString();
        }
        else
        {
            ext = 0;
            Label7.Text = ext.ToString();
        }

        if (ds.Tables[0].Rows[0][0].ToString() != "" && ds1.Tables[0].Rows[0][0].ToString() != "" && ds1.Tables[0].Rows[0][1].ToString() != "")
        {
            backamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            curamt = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
            total = backamt + curamt+ext;
            expamt = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            balamt = total - expamt;
            Label1.Text = backamt.ToString();
            Label2.Text = curamt.ToString();
            Label6.Text = total.ToString();
            Label4.Text = expamt.ToString();
            Label5.Text = balamt.ToString();
        }
        else
        {
            expamt = 0;
            backamt = 0;
            curamt = 0;
            total = backamt + curamt+ext;
            balamt = total - expamt;

            Label1.Text = backamt.ToString();
            Label2.Text = curamt.ToString();
            Label6.Text = total.ToString();
            Label4.Text = expamt.ToString();
            Label5.Text = balamt.ToString();
        }
        con.Close();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        balance1();
        bind();
    }
}