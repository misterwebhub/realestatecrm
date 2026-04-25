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
    static string araz;
    string s = ConfigurationManager.ConnectionStrings["amar1"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

          
            bindl();
            
        }
    }
    public void bindl()
    {
        DropDownList1.Items.Clear();
      
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from wjstar1.plotd", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
           
        }
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("insert into wjstar1.plotd(arazino,loc,kname,brokername)values('" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
     int   i = cmd2.ExecuteNonQuery();
        con.Close();
        if (i == 0)
        {
            Label2.Text = "internal problam";

        }
        else
        {
            Label2.Text = "successfully added"; 
            bindl();

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("delete from wjstar1.plotd where arazino='"+DropDownList1.Text+"'", con);
        int i = cmd2.ExecuteNonQuery();
        con.Close();
        if (i == 0)
        {
            Label2.Text = "internal problam";

        }
        else
        {
            Label2.Text = "Successfully Deleted";
            bindl();

        }
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT loc from wjstar1.plotd WHERE arazino='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        TextBox7.Text = ds.Tables[0].Rows[0][0].ToString();
        araz = ds.Tables[0].Rows[0][0].ToString();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("update wjstar1.plotd set loc='" + TextBox7.Text + "' where arazino='" + DropDownList1.Text + "' AND loc='" + araz + "'", con);
        int i = cmd2.ExecuteNonQuery();
        con.Close();
        if (i == 0)
        {
            Label2.Text = "internal problam";

        }
        else
        {
            Label2.Text = "Successfully Updated";
            bindl();

        }

    }
}