
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

public partial class dialer_paymentdone : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Button5.Visible = false;
            Panel4.Visible = false;
            Panel3.Visible = false;

        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        advbind();
        advbinddata12();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible =true;
        dakhilbid();
        lekhbinddata12();
    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList4.Text == "--SELECT--")
        {
            Label8.Text = "PLEASE SELCT TYPE";
        }
        else
        {
            if (DropDownList4.Text == "CASH")
            {
                Label8.Text = "";
                TextBox9.Text = "CASH";
            }
            else
            {
                Label8.Text = "";
                TextBox9.Text = "0";
            }
        }
    }
    public void advbinddata()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT TOP 3 ID,	name,	date,	type,	transno,	amount,	remark from avoate order by ID DESC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView1.DataSource = ds1;
        GridView1.DataBind();
    }
    public void lekhbinddata()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT TOP 3 ID,	name,	date,amount,remark from lekhpal order by ID DESC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView2.DataSource = ds1;
        GridView2.DataBind();
    }
    public void advbinddata12()
    {
        DateTime aDate = DateTime.Now;
       int m1 = aDate.Month;
        string m = "";
        if (m1 == 10)
        {
            m = m1.ToString();
        }
        else
        {

            if (m1 == 11)
            {
                m = m1.ToString() ;
            }
            else
            {
                if (m1 == 12)
                {
                    m = m1.ToString();
                }
                else
                {
                    m = "0"+m1.ToString() ;
                }
            }
        }
        string y = aDate.Year.ToString();
        String date1 = m + "/01" + "/" + y;
        DateTime first = new DateTime(Convert.ToInt32(y), Convert.ToInt32(m), 1);
        DateTime last = first.AddMonths(1).AddSeconds(-1);
        string d = last.Day.ToString();
        String date2 = m + "/" + d + "/" + y;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT sum(amount) from avoate where date between '" + date1 + "' AND '" +
            date2 + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT sum(PAYAMOUNT) from ragfistrypay where date between '" + date1 + "' AND '" +
            date2 + "'", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double TOTAL = 0, PAY = 0, BAL = 0,adp=0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            TOTAL = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            TOTAL = 0;
        }
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            PAY = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            PAY = 0;
        }
        Label1.Text = TOTAL.ToString();
        Label2.Text = PAY.ToString();
con.Open();
        SqlDataAdapter da4 = new SqlDataAdapter("SELECT sum(amount) from advancepay where date between '" + date1 + "' AND '" + date2 + "'", con);
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
        con.Close();
		 if (ds4.Tables[0].Rows[0][0].ToString() != "")
        {
            adp = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            adp = 0;
        }
        BAL = TOTAL - PAY+adp;
        if (BAL < 0)
        {
            Label3.Text = BAL.ToString();
            Label12.Visible = true;
            Label12.ForeColor = Color.Red;
            Label3.ForeColor = Color.Red;
        }
        else
        {
            Label3.Text = BAL.ToString();
            Label12.Visible = false;
            Label3.ForeColor = Color.Green;
        }


    }
    public void lekhbinddata12()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT sum(amount) from lekhpal", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT sum(REGAMOUNT)-sum(PAYAMOUNT) AS 'BALANCE' from ragfistrypay", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double TOTAL = 0, PAY = 0, BAL = 0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            TOTAL = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            TOTAL = 0;
        }
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            PAY = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            PAY = 0;
        }
        Label5.Text = TOTAL.ToString();
        Label6.Text = PAY.ToString();

        BAL = TOTAL - PAY;
        if (BAL < 0)
        {
            Label7.Text = BAL.ToString();
            Label13.Visible = true;
            Label13.ForeColor = Color.Red;
            Label7.ForeColor = Color.Red;
        }
        else
        {
            Label7.Text = BAL.ToString();
            Label13.Visible = false;
            Label7.ForeColor = Color.Green;
        }


    }

    public void advbind()
    {
        DropDownList3.Items.Clear();
        DropDownList5.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT name from advodakhil where adtype='ADV'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            DropDownList3.Items.Add("--SELECT--");
            DropDownList5.Items.Add("--SELECT--");
            for (int k = 0; k < ds1.Tables[0].Rows.Count; k++)
            {
                DropDownList3.Items.Add(ds1.Tables[0].Rows[k][0].ToString());
                DropDownList5.Items.Add(ds1.Tables[0].Rows[k][0].ToString());

            }
        }
    }
    public void dakhilbid()
    {
        DropDownList2.Items.Clear();
        DropDownList6.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT name from advodakhil where adtype='DAKHIL'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            DropDownList2.Items.Add("--SELECT--");
            DropDownList6.Items.Add("--SELECT--");
            for (int k = 0; k < ds1.Tables[0].Rows.Count; k++)
            {
                DropDownList2.Items.Add(ds1.Tables[0].Rows[k][0].ToString());
                DropDownList6.Items.Add(ds1.Tables[0].Rows[k][0].ToString());

            }
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into advodakhil(adtype,name)values('ADV','"+TextBox8.Text+"')",con);
        int i=cmd.ExecuteNonQuery();
        if (i != 0)
        {
            Label10.Text = "Record Added";
            advbind();
            Label10.Text = "";
            TextBox8.Text = "";
        }
        else
        {
            Label10.Text = "Got Error from server";
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into advodakhil(adtype,name)values('DAKHIL','" + TextBox1.Text + "')", con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            Label4.Text = "Record Added";
            dakhilbid();
            Label4.Text = "";
            TextBox1.Text = "";
        }
        else
        {
            Label4.Text = "Got Error from server";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
       
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT sum(amount) from avoate", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT sum(PAYAMOUNT) from ragfistrypay", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double TOTAL = 0, PAY = 0, BAL = 0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            TOTAL = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            TOTAL = 0;
        }
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            PAY = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            PAY = 0;
        }
       
        string s2 = TextBox2.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);      
        string date1 = mm + "/" + dd + "/" + yy;
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into avoate(name,date,type,transno,amount,remark,total,paid)values('" + DropDownList3.Text + "','" + date1 + "','" +DropDownList4.Text+ "','" + TextBox9.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "',"+TOTAL+","+PAY+")", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label8.Text = "Record Added";
            advbinddata();
            advbinddata12();
        }
        else
        {
            Label8.Text = "Error";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);

        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT sum(amount) from lekhpal", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT sum(REGAMOUNT)-sum(PAYAMOUNT) AS 'BALANCE' from ragfistrypay", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double TOTAL = 0, PAY = 0, BAL = 0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            TOTAL = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            TOTAL = 0;
        }
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            PAY = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            PAY = 0;
        }

        string s2 = TextBox5.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into lekhpal(name,date,amount,remark)values('" + DropDownList2.Text + "','" + date1 + "'," + TextBox6.Text + ",'" + TextBox7.Text + "')", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label9.Text = "Record Added";
            lekhbinddata();
            lekhbinddata12();
        }
        else
        {
            Label9.Text = "Error";
        }
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM avoate where ID="+TextBox10.Text+"", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label10.Text = "Record Deleted";
            advbinddata();
            advbinddata12();
        }
        else
        {
            Label10.Text = "Error";
        }
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        string s2 = TextBox11.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        string s3 = TextBox12.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string date2 = mm1 + "/" + dd1 + "/" + yy1;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT  ID,	name,	date,	type,	transno,	amount,	remark from avoate where date between '" + date1 + "' AND '" + date2 + "' AND name='" + DropDownList5.Text + "' order by date ASC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT  sum(amount) from avoate where date between '" + date1 + "' AND '" + date2 + "' AND name='" + DropDownList5.Text + "'  ", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT sum(PAYAMOUNT) from ragfistrypay where date between '" + date1 + "' AND '" + date2 + "'", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        Double amt = 0, pa = 0, bu = 0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            amt = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            amt = 0;
        }
        if (ds3.Tables[0].Rows[0][0].ToString() != "")
        {
            pa = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            pa = 0;
        }
        bu = pa - amt;
        if (bu < 0)
        {
            Label16.Text = bu.ToString();
            Label17.Visible = true;
            Label17.ForeColor = Color.Red;
            Label16.ForeColor = Color.Red;
        }
        else
        {
            Label16.Text = bu.ToString();
            Label17.Visible = false;
            Label16.ForeColor = Color.Green;
        }
        Label11.Text = amt.ToString();
        Label15.Text = pa.ToString();
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        fundetails();
    }
    public void fundetails()
    {
        string s2 = TextBox11.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        string s3 = TextBox12.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string date2 = mm1 + "/" + dd1 + "/" + yy1;

        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT  ID,	name,	date,	type,	transno,	amount,	remark from avoate where date between '" + date1 + "' AND '" + date2 + "'  order by date ASC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Open();
        SqlDataAdapter da8 = new SqlDataAdapter("SELECT  ID,	padate,	amount,	remark from advancepay where date between '" + date1 + "' AND '" + date2 + "'  order by padate ASC", con);
        DataSet ds8 = new DataSet();
        da8.Fill(ds8);
        con.Close();
        GridView3.DataSource = ds8;
        GridView3.DataBind();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT  sum(amount) from avoate  where date between '" + date1 + "' AND '" + date2 + "'", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double amt = 0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            amt = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            amt = 0;
        }
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT sum(PAYAMOUNT) from ragfistrypay where date between '" + date1 + "' AND '" + date2 + "'", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        con.Open();
        SqlDataAdapter da4 = new SqlDataAdapter("SELECT sum(amount) from advancepay where date between '" + date1 + "' AND '" + date2 + "'", con);
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
        con.Close();
        Double pa = 0, bu = 0,adp=0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            amt = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            amt = 0;
        }
        if (ds3.Tables[0].Rows[0][0].ToString() != "")
        {
            pa = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            pa = 0;
        }
        if (ds4.Tables[0].Rows[0][0].ToString() != "")
        {
            adp = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            adp = 0;
        }
        bu = pa - amt+adp;
        if (bu < 0)
        {
            Label16.Text = bu.ToString();
            Label17.Visible = true;
            Label17.ForeColor = Color.Red;
            Label16.ForeColor = Color.Red;
        }
        else
        {
            Label16.Text = bu.ToString();
            Label17.Visible = false;
            Label16.ForeColor = Color.Green;
        }
        Label11.Text = amt.ToString();
        Label15.Text = pa.ToString();
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM lekhpal where ID=" + TextBox13.Text + "", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label4.Text = "Record Deleted";
            lekhbinddata();
            lekhbinddata12();
        }
        else
        {
            Label4.Text = "Error";
        }
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        string s2 = TextBox14.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        string s3 = TextBox15.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string date2 = mm1 + "/" + dd1 + "/" + yy1;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT  ID,	name,	date,amount,	remark from lekhpal where date between '" + date1 + "' AND '" + date2 + "' AND name='" + DropDownList6.Text + "' order by date ASC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView2.DataSource = ds1;
        GridView2.DataBind();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT  sum(amount) from lekhpal where date between '" + date1 + "' AND '" + date2 + "' AND name='" + DropDownList6.Text + "'  ", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double amt = 0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            amt = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            amt = 0;
        }
        Label14.Text = amt.ToString();
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        string s2 = TextBox14.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        string s3 = TextBox15.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string date2 = mm1 + "/" + dd1 + "/" + yy1;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT  ID,	name,	date,amount,	remark from lekhpal where date between '" + date1 + "' AND '" + date2 + "' order by date ASC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView2.DataSource = ds1;
        GridView2.DataBind();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT  sum(amount) from lekhpal where date between '" + date1 + "' AND '" + date2 + "'  ", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double amt = 0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            amt = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            amt = 0;
        }
        Label14.Text = amt.ToString();
    }
    
   
}