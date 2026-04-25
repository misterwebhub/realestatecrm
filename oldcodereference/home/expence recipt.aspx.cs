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

public partial class home_expence_recipt : System.Web.UI.Page
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
        SqlDataAdapter da = new SqlDataAdapter("select ID,RDATE,RAMOUNT,RREASON from expensetable", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    public void balance1()
    {
        string s2 = TextBox2.Text;
        string dd = s2.Substring(0, 2);
        string m = s2.Substring(3, 2);
        string y = s2.Substring(6, 4);
       // DateTime datetime1 = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
       // MessageBox.Show(oDate.ToString());
        // DateTime dateTime = Convert.ToDateTime(dateString);
        
       
       SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(RAMOUNT) from expensetable where month(CDATE)=" + m+ " AND year(CDATE)="+y+"", con);
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
        Double total = 0,expamt=0,balamt=0,backamt=0,curamt=0,ext=0;

        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            ext = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            Label6.Text = ext.ToString();
        }
        else
        {
            ext = 0;
            Label6.Text = ext.ToString();
        }
        if (ds.Tables[0].Rows[0][0].ToString() != "" && ds1.Tables[0].Rows[0][0].ToString() != "" && ds1.Tables[0].Rows[0][1].ToString() != "")
        {
            backamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            curamt = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
            total = backamt + curamt+ext;
            expamt = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            balamt = total - expamt;
            if (balamt < 0)
            {
                Label4.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Label4.ForeColor = System.Drawing.Color.Green;
            }
            TextBox1.Text = backamt.ToString();
            TextBox6.Text = curamt.ToString();
            Label2.Text = total.ToString();
            Label3.Text = expamt.ToString();
            Label4.Text = balamt.ToString();
        }
        else
        {
            expamt = 0;
            backamt = 0;
            curamt =0;
            total = backamt + curamt+ext;
            balamt = total - expamt;
            
            TextBox1.Text = backamt.ToString();
            TextBox6.Text = curamt.ToString();
            Label2.Text = total.ToString();
            Label3.Text = expamt.ToString();
            Label4.Text = balamt.ToString();
        }
        con.Close();
    }
    public void balance()
    {
        //string dateString = TextBox2.Text;

        string s2 = TextBox2.Text;
        string dd = s2.Substring(0, 2);
        string m = s2.Substring(3, 2);
        string y = s2.Substring(6, 4);
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(RAMOUNT) from expensetable where month(CDATE)=" + m + " AND year(CDATE)=" + y + "", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Double total = 0, expamt = 0, balamt = 0;
        total = Convert.ToDouble(Label2.Text);
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {

            expamt = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            balamt = total - expamt;
            Label3.Text = expamt.ToString();
            Label4.Text = balamt.ToString();
        }
        else
        {
            expamt = 0;
            balamt = total - expamt;
            Label3.Text = expamt.ToString();
            Label4.Text = balamt.ToString();
        }
        con.Close();
    }
    public void bind()
    {
        string s2 = TextBox2.Text;
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


    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = 0;
        string dateString = TextBox2.Text;
        string format = "dd/mm/yyyy";
        DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        string strdate = dateTime.ToString("mm/dd/yyyy");
        string dateString1 = TextBox3.Text;
        string format1 = "dd/mm/yyyy";
        DateTime dateTime1 = DateTime.ParseExact(dateString1, format1, CultureInfo.InvariantCulture);
        string strdate1 = dateTime1.ToString("mm/dd/yyyy");
        SqlConnection con = new SqlConnection(s);
        con.Open();
        if (TextBox1.Text == "" || TextBox6.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "")
        {
            Label1.Text = "Please fill all text box";
        }
        else
        {
            SqlCommand cmd = new SqlCommand("insert into expensetable (TAMOUNT,CDATE,RDATE,RAMOUNT,RREASON,BACKAMT,CURAMT)values(" + Label2.Text + ",'" + strdate + "','" + strdate1 + "'," + TextBox4.Text + ",'" + TextBox5.Text + "',"+TextBox1.Text+","+TextBox6.Text+")", con);
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                Label1.Text = "RECORD ADDED SUCCESSFULLY";
                TextBox5.Text = "";
                TextBox4.Text = "";
                Label3.Text="";
                Label4.Text = "";
                balance1();
                bind();
            }
            else
            {
                Label1.Text = "ERROR";
            }
        }
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        Double backamt=0, curamt=0, total=0,ex=0;
        backamt = Convert.ToDouble(TextBox1.Text);
        curamt = Convert.ToDouble(TextBox6.Text);
		ex = Convert.ToDouble(Label6.Text);
        total = backamt + curamt+ex;
        Label2.Text = total.ToString();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from expensetable where ID="+TextBox7.Text+" ", con);
        i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label5.Text = "Record Deleted ";
            bind();
            balance();
        }
        else
        {
            Label5.Text = "error";
        }
        
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        balance1();
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