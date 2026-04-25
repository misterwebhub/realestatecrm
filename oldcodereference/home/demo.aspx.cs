using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

public partial class demo : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            bindl();
            bindl2();
        }
    }
    public void bindl()
    {

        DropDownList1.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT id from newkishan", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
    public void bindl2()
    {

        DropDownList1.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT invid from newinvester", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string kid = DropDownList1.Text;
        
        Double ktotal = 0, kpaid = 0, kbal = 0, btotal = 0, bpaid = 0, bbal = 0, unpaid = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select landamount from newkishan where id='" + kid + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        Label2.Text = ds.Tables[0].Rows[0][0].ToString();
       
        ktotal = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
       
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount),sum(bpaid) from kishanrecipt where kid='" + kid + "' AND status='PAID' ", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();

        SqlDataAdapter da3 = new SqlDataAdapter("select sum(amount) from kishanrecipt where kid='" + kid + "' AND status='UNPAID'", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                kpaid = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                kpaid = 0;
            }
            if (ds1.Tables[0].Rows[0][1].ToString() != "")
            {
                bpaid = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                bpaid = 0;
            }
        }
        if (ds3.Tables[0].Rows[0][0].ToString() != "")
        {
            unpaid = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            unpaid = 0;
        }
        kbal = ktotal - kpaid;
        Label3.Text = kpaid.ToString();
        Label4.Text = kbal.ToString();
       // bbal = btotal - bpaid;
        Label6.Text = bpaid.ToString();
        //Label13.Text = bbal.ToString();
        Label5.Text = unpaid.ToString();
        con.Open();
        SqlDataAdapter da5 = new SqlDataAdapter("select reciptid,kid,arazi,date,amount,paymode,cheqdate,cheqno,refno,status,bpaid from kishanrecipt where kid='" + kid + "' order by date ASC ", con);
        DataSet ds5 = new DataSet();
        da5.Fill(ds5);
        con.Close();
        GridView1.DataSource = ds5;
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlCommand cmd = new SqlCommand("delete from kishanrecipt where reciptid='"+TextBox1.Text+"'", con1);
        int i = cmd.ExecuteNonQuery();

        con1.Close();



        if (i == 1)
        {
            Label7.Text = "Record deleted Sucessfully";

        }
        else
        {
            Label7.Text = "Due to internal error";
        }
    }
    public void bin()
    {
        string kid = DropDownList2.Text;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da5 = new SqlDataAdapter("select invrecipt,name,date,amount,type,paymode,chekdate, chkno,refby,status from investerrecipt where invid='" + kid + "' order by date DESC ", con);
        DataSet ds5 = new DataSet();
        da5.Fill(ds5);
        con.Close();
        GridView2.DataSource = ds5;
        GridView2.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        bin();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlCommand cmd = new SqlCommand("delete from investerrecipt where invrecipt='" + TextBox2.Text + "'", con1);
        int i = cmd.ExecuteNonQuery();

        con1.Close();



        if (i == 1)
        {
            Label8.Text = "Record deleted Sucessfully";
            bin();

        }
        else
        {
            Label8.Text = "Due to internal error";
        }
    }
}