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


public partial class plotadd : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("insert into wjstar1.ploted1(arazino,loc,kname,brokername)values('" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
     int   i = cmd2.ExecuteNonQuery();
        con.Close();
		/*con.Open();

        SqlCommand cmd3 = new SqlCommand("insert into softploted1(arazino,loc,kname,brokername)values('" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
     int   i2 = cmd3.ExecuteNonQuery();
        con.Close();*/
        if (i == 0)
        {
            Label2.Text = "internal problam";

        }
        else
        {
            Label2.Text = "successfully added";

        }
    }
}