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



public partial class kishan_kishanadd : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public void bid()
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
                DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            con.Close();
            con.Open();
            int a=0;
            SqlDataAdapter da1 = new SqlDataAdapter("select max(ID) from wjstar1.kishan", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                 a = Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString());
            }
            a = a + 1;
            TextBox3.Text = "K00" + a.ToString();
            con.Open();
          
            SqlDataAdapter da2 = new SqlDataAdapter("select kid ,arazino,kname,adharno from wjstar1.kishan", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            GridView1.DataSource = ds2;
            GridView1.DataBind();
            con.Close();

        
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            bid();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("insert into wjstar1.kishan(kid,arazino,kname,adharno)values('" + TextBox3.Text + "','" + DropDownList1.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "')", con);
        int i = cmd2.ExecuteNonQuery();
        con.Close();
        if (i == 0)
        {
            Label1.Text = "internal problam";

        }
        else
        {
            Label1.Text = "successfully added";
            bid();

        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazino,kname,adharno from wjstar1.kishan where kid='" + TextBox4.Text + "' OR adharno='" + TextBox4.Text + "'",con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DropDownList2.Text = ds.Tables[0].Rows[0][0].ToString();
                       TextBox5.Text = ds.Tables[0].Rows[0][1].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0][2].ToString();
        }
        else
        {
            Label2.Text = "record not found";
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("delete from wjstar1.kishan where kid='" + TextBox4.Text + "' OR adharno='" + TextBox4.Text + "'", con);
        int i = cmd2.ExecuteNonQuery();
        con.Close();
        if (i == 0)
        {
            Label2.Text = "internal problam";

        }
        else
        {
            Label2.Text = "Record deleted";
            bid();

        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("update wjstar1.kishan set arazino='"+DropDownList2.Text+"',kname='"+TextBox5.Text+"',adharno='"+TextBox6.Text+"' where kid='" + TextBox4.Text + "' OR adharno='" + TextBox4.Text + "'", con);
        int i = cmd2.ExecuteNonQuery();
        con.Close();
        if (i == 0)
        {
            Label2.Text = "internal problam";

        }
        else
        {
            Label2.Text = "Record updated";
            bid();

        }
    }
}