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

public partial class Plotdetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Panel1.Visible = false;
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


        }
    }
    public void bind()
    {
        GridView1.Visible = true;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select plotno as 'PLOT NO',CUSTREGNO as 'CUSTOMER Reg. NO',PLOTSIZE as 'PLOT SIZE' from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' order by date3 ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();

        con.Close();

        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(convert(int,PLOTSIZE)) from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Label3.Text = ds1.Tables[0].Rows[0][0].ToString();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        bind();
    }
    



    protected void Button8_Click(object sender, EventArgs e)
    {

    }
    protected void Button20_Click(object sender, EventArgs e)
    {

    }
    protected void ar239b13_Click(object sender, EventArgs e)
    {

    }


    protected void Button4_Click1(object sender, EventArgs e)
    {
        if (TextBox2.Text == "heed09696")
        {
            Panel1.Visible = true;
        }
        else
        {
            Label6.Text = "Enter Correct Details";
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/map/254.pdf");
    }
}