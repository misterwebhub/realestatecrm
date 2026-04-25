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

public partial class extrapayment : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fun();
        }
    }
    public void fun()
    {

        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select ID,RDATE,RAMOUNT,RREASON from extrapayment", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = 0;
        string dateString = TextBox3.Text;
        string format = "dd/mm/yyyy";
        DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        string strdate = dateTime.ToString("mm/dd/yyyy");
       
        SqlConnection con = new SqlConnection(s);
        con.Open();
        if ( TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "")
        {
            Label1.Text = "Please fill all text box";
        }
        else
        {
            SqlCommand cmd = new SqlCommand("insert into extrapayment (RDATE,RAMOUNT,RREASON)values('" + strdate + "'," + TextBox4.Text + ",'" + TextBox5.Text + "')", con);
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                Label1.Text = "RECORD ADDED SUCCESSFULLY";
                TextBox5.Text = "";
                TextBox4.Text = "";
                bind();
            }
            else
            {
                Label1.Text = "ERROR";
            }
        }
    }
    public void bind()
    {
        string s2 = TextBox3.Text;
        string dd = s2.Substring(0, 2);
        string m = s2.Substring(3, 2);
        string y = s2.Substring(6, 4);
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select ID,RDATE,RAMOUNT,RREASON from extrapayment where month(RDATE)=" + m + " AND year(RDATE)=" + y + "", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(RAMOUNT) from extrapayment where month(RDATE)=" + m + " AND year(RDATE)=" + y + "", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            Label6.Text = ds1.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            Label6.Text = "0";
        }
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from extrapayment where ID=" + TextBox7.Text + " ", con);
        i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label5.Text = "Record Deleted ";
            bind();
           
        }
        else
        {
            Label5.Text = "error";
        }
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("id119");
            lblname.Style.Add("color", "red");
        }

    }
}