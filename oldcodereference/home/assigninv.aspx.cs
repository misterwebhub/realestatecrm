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

public partial class arazi246_assigninv : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindl3();
            bindl4();
            bindl5();
            bindl6();
        }
    }
    public void bindl4()
    {

        DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select name as fun from assignname", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        con.Close();
        DropDownList4.DataSource = ds.Tables[0];
        DropDownList4.DataTextField = "fun";
       
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    public void bindl5()
    {

       
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from assignname", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        GridView1.DataSource = ds;
        GridView1.DataBind();
       

    }
    public void bindl6()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from assignnameid", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        GridView2.DataSource = ds;
        GridView2.DataBind();


    }
    public void bindl3()
    {

        DropDownList3.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid,CONCAT(invid,'-->',ivname) as fun from newinvester", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        
        con.Close();
        DropDownList3.DataSource = ds.Tables[0];
        DropDownList3.DataTextField = "fun";
        DropDownList3.DataValueField = "invid";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select name from assignname where name='"+TextBox1.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        int i = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
        }
        else
        {
            i = 0;
        }
        if (i == 0)
        {
            SqlCommand cmd = new SqlCommand("insert into assignname (name)values('"+TextBox1.Text+"')",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindl4();
            bindl5();
        }
        else
        {
            string message = "Name Already Exist ";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select name from assignnameid where name='" + DropDownList4.Text + "' AND invid='" + DropDownList3.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        int i = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
        }
        else
        {
            i = 0;
        }
        if (i == 0)
        {
            SqlCommand cmd = new SqlCommand("insert into assignnameid (name,invid)values('" + DropDownList4.Text+ "','"+DropDownList3.SelectedValue+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindl6();
        }
        else
        {
            string message = "Name & Id Already Exist ";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        SqlCommand cmd = new SqlCommand("delete from assignname where id="+TextBox2.Text+"", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        bindl5();

        string message = "Name Deleted ";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload=function(){");
        sb.Append("alert('");
        sb.Append(message);
        sb.Append("')};");
        sb.Append("</script>");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        SqlCommand cmd = new SqlCommand("delete from assignnameid where id=" + TextBox3.Text + "", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        bindl6();

        string message = "Name & Id Deleted ";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload=function(){");
        sb.Append("alert('");
        sb.Append(message);
        sb.Append("')};");
        sb.Append("</script>");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
    }
}