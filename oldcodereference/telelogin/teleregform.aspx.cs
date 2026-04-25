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
using System.Drawing;

public partial class telelogin_teleregform : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          


            bind();

            fetch();

            // find();

        }
    }
    public void fetch()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();


        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM telelogin", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con1.Close();


        GridView1.DataSource = ds1;
        GridView1.DataBind();
    }
    public void bind()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT username FROM logininfo", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();


            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {

                DropDownList1.Items.Add(ds1.Tables[0].Rows[j][0].ToString());


            }
        }


        catch (Exception t)
        {
            Label1.Text = "internal problem" + t;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "")
        {
            Label1.Text = "Please Fill All Fields";
        }
        else
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into telelogin(name,mobile,office,username,password)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList1.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                Label1.Text = "Record Added";
                fetch();
            }
            else
            {
                Label1.Text = "Error";
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
    }
}