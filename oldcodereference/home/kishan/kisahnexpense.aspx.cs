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

public partial class kishan_kisahnexpense : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bid();
            
        }
    }
    public void bid()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from chequekishan", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            
        }
        con.Close();



    }
    public void bid2()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select ID,item,amount from kishanexpense where arazi='" + DropDownList1.Text + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView1.DataSource = ds1;
        GridView1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT kname from chequekishan where arazino='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList2.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());


        }
        bid2();
       
       
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {


        TextBox6.Text = "";
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT location from chequekishan where arazino='" + DropDownList1.Text + "' AND kname='" + DropDownList2.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TextBox6.Text = ds.Tables[0].Rows[i][0].ToString();


        }
        con.Close();
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
           

            SqlCommand cmd2 = new SqlCommand("insert into kishanexpense(arazi,kname,location,item,amount)values('" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + TextBox6.Text + "','" + TextBox8.Text + "'," + TextBox11.Text + ")", con);
            int i = cmd2.ExecuteNonQuery();
            con.Close();
            if (i == 0)
            {
                Label1.Text = "internal problam";

            }
            else
            {
                Label1.Text = "successfully added";
                bid2();          
               
            }


        }
        catch (Exception t)
        {
            Label1.Text = "" + t;
        }
    }
}