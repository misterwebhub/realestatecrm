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
               
            }
            con.Close();
            con.Open();
            int a=0;
            SqlDataAdapter da1 = new SqlDataAdapter("select max(ID) from chequekishan", con);
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

            SqlDataAdapter da2 = new SqlDataAdapter("select kid ,arazino,kname,location,amount from chequekishan", con);
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
          
            bid();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
       
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("insert into chequekishan(kid,arazino,kname,location,amount)values('" + TextBox3.Text + "','" + DropDownList1.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox6.Text + ")", con);
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
   
    
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT loc from wjstar1.ploted1 where arazino='"+DropDownList1.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
           TextBox2.Text= ds.Tables[0].Rows[i][0].ToString();

        }
    }
}