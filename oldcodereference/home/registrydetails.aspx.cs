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


public partial class registrydetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            con.Close();
            find();


        }
    }
    public void find()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT CHECKBY FROM wjstar1.customerreg1", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            
        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
    public void bind()
    {
        GridView1.Visible = true;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        //SqlDataAdapter da = new SqlDataAdapter("select plotno,CUSTREGNO,PLOTSIZE,date3 as 'DATE',NAMEDOBADDRESS,CHECKBY,mobile,regstatus from customerreg1 where APPNO='" + DropDownList1.Text + "' AND regstatus='completed'", con);
       // DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REG NO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.CONSAMOUNT AS 'TOTAL AMOUNT',r.PAID,c.PLOTSIZE AS 'PLOT SIZE',c.plotno AS 'PLOT NO',c.mobile AS 'MOBILE',c.CHECKBY AS 'BROKER',c.regstatus AS 'STATUS' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND regstatus='completed') ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close(); 
        GridView1.DataSource = ds;
        GridView1.DataBind();

        con.Close();

        }
    public void broker()
    {
        GridView1.Visible = true;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        //SqlDataAdapter da = new SqlDataAdapter("select plotno,CUSTREGNO,PLOTSIZE,date3 as 'DATE',NAMEDOBADDRESS,CHECKBY,mobile,regstatus from customerreg1 where CHECKBY='" + DropDownList2.Text + "' AND regstatus='completed'", con);
        SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO AS 'REG NO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.date3 AS 'DATE',c.CONSAMOUNT AS 'TOTAL AMOUNT',r.PAID,c.PLOTSIZE AS 'PLOT SIZE',c.plotno AS 'PLOT NO',c.mobile AS 'MOBILE',c.CHECKBY AS 'BROKER',c.regstatus AS 'STATUS' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where CHECKBY='" + DropDownList2.Text + "' AND regstatus='completed') ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
        
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();

        con.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        broker();
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        String d = TextBox2.Text;
        Double f = Convert.ToDouble(d);
        Double a = Convert.ToDouble(TextBox3.Text);
        Double t = (f * a) / 100;
        TextBox5.Text = t.ToString();
    }
    public void show()
    {
        GridView2.Visible = true;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        //SqlDataAdapter da = new SqlDataAdapter("select plotno,CUSTREGNO,PLOTSIZE,date3 as 'DATE',NAMEDOBADDRESS,CHECKBY,mobile,regstatus from customerreg1 where CHECKBY='" + DropDownList2.Text + "' AND regstatus='completed'", con);
        SqlDataAdapter da = new SqlDataAdapter("select * from wjstar1.registrybroker where CHECKBY='"+DropDownList2.Text+"'", con);
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(PAID) from wjstar1.registrybroker where CHECKBY='" + DropDownList2.Text + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
        Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        Label3.Text = "TOTAL PAID AMOUNT :  "+d.ToString();
        con.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into wjstar1.registrybroker(CUSTREGNO,TOTALAMT,PERC,PAID,DATE1,PLOTNO,CHECKBY)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "'," + TextBox5.Text + ",'" + TextBox4.Text + "','" + TextBox6.Text + "','"+DropDownList2.Text+"')", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label2.Text = "Record Added";
            show();
        }
        else
        {
            Label2.Text = "Please enter correct details";
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        show();
    }
}