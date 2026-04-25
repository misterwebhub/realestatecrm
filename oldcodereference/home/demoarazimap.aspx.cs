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

public partial class arazi137ramipur_demoarazimap : System.Web.UI.Page
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
             bind();
         }
    }
    public void bind()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();


        SqlDataAdapter da = new SqlDataAdapter("select * from ARAZINOTSALE", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "")
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into ARAZINOTSALE(CUSTREGNO,ARAZI)values('"+TextBox1.Text+"','"+DropDownList1.Text+"')",con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            Label1.Text = "Bond Added";
            bind();
        }
        else
        {
            Label1.Text = "Error Generated";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from ARAZINOTSALE where ID="+TextBox2.Text+"", con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            Label1.Text = "Bond deleted";
            bind();
        }
        else
        {
            Label1.Text = "Error Generated";
        }
    }
}