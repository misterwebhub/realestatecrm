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

public partial class PATMENT : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public static string arazi="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;

            Panel2.Visible = false;
            bind();
            bindl3();
            bind3();
        }
    }
    public void bind3()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select id,pid ,name,arazi,deedno from getpayment", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    public void bindl3()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(" select invid,ivname,invid+'--- '+ivname  as demo from newinvester where invid not in('I0021')", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        
            DropDownList6.DataSource = ds.Tables[0];
            DropDownList6.DataTextField = "demo";

            DropDownList6.DataValueField = "ivname";
            DropDownList6.DataBind();
            DropDownList6.Items.Insert(0, new ListItem("--Select--", "0"));

     
       
        
       
      
        DropDownList6.Items.Add("I001---Alok Kumar Pandey (HISHAB)");

    }
    public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList2.Items.Add("---select---");
        DropDownList4.Items.Add("---select---");
        DropDownList8.Items.Add("---select---");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList4.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList8.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        con.Close();
    }
    public void binddeed(string deed)
    {
       
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT deedno from ragistrydetails where arazi='" + deed + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (DropDownList1.Text == "KISHAN NAME")
        {
            DropDownList5.Items.Clear();
            DropDownList5.Items.Add("---SELECT----");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList5.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
        }
        else
        {
            DropDownList9.Items.Clear();
            DropDownList9.Items.Add("---SELECT----");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList9.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "KISHAN NAME")
        {
            Panel1.Visible = true;

            Panel2.Visible = false;
        }
        if (DropDownList1.Text == "INVESTER NAME")
        {
            Panel1.Visible = false;

            Panel2.Visible = true;
        }
        
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList4.Text != "---select---")
        {
            arazi = DropDownList4.Text;
            binddeed(arazi);
        }
    }
    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList8.Text != "---select---")
        {
            arazi = DropDownList8.Text;
            binddeed(arazi);
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select kname from newkishan where arazi='" + DropDownList2.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList3.Items.Clear();
        DropDownList3.Items.Insert(0, "---select---");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());

        }
        con.Close();
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into getpayment(pid ,name,arazi,deedno,ptype)values('" + DropDownList2.Text + "','" + DropDownList3.Text + "','" + DropDownList4.Text + "','" + DropDownList5.Text + "','" + DropDownList1.Text + "')",con);
        int r = cmd.ExecuteNonQuery();
        con.Close();
        if (r != 0)
        {
            string message = "Record Added";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            bind3();

        }
        else
        {
            string message = "We got some error from server";
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into getpayment(pid ,name,arazi,deedno,ptype)values('" + TextBox1.Text + "','" + DropDownList6.SelectedValue + "','" + DropDownList8.Text + "','" + DropDownList9.Text + "','" + DropDownList1.Text + "')",con);
        int r = cmd.ExecuteNonQuery();
        con.Close();
        if (r != 0)
        {
            string message = "Record Added";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            bind3();

        }
        else
        {
            string message = "We got some error from server";
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
        SqlCommand cmd = new SqlCommand("delete from  getpayment where id="+TextBox2.Text+"", con);
        int r = cmd.ExecuteNonQuery();
        con.Close();
        if (r != 0)
        {
            string message = "Record Deleted";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            bind3();

        }
        else
        {
            string message = "We got some error from server";
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
}