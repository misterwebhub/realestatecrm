using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

public partial class sidebar_araziaddfordetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindarazi();
            bind2();
           
        }
    }
    public void bindarazi()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select arazino from wjstar1.ploted1 where arazino not in('BANK STATEMENT','DM PERMISSION','POWER OF ATONY','OLD KISHAN DEED','AGREEMENT','CAR','UP78GR0319','Company Registration','PANI PLANT','0')", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        if (ds3.Tables[0].Rows.Count > 0)
        {
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            if (ds3.Tables[0].Rows[0][0].ToString() != "")
            {
                DropDownList1.Items.Add("---SELECT---");
                DropDownList2.Items.Add("---SELECT---");
                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    DropDownList1.Items.Add(ds3.Tables[0].Rows[i][0].ToString());
                    DropDownList2.Items.Add(ds3.Tables[0].Rows[i][0].ToString());
                }
            }
            else
            {
                DropDownList1.DataSource = null;
                DropDownList2.DataSource = null;
            }
        }
        else
        {
            DropDownList1.DataSource = null;
            DropDownList2.DataSource = null;
        }

    }
    public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select ID,fromarazi AS 'ARAZI',totalland AS 'TOTAL LAND',road AS 'ROAD',rate AS 'RATE' from kishanarazi where toarazi='" + DropDownList1.Text + "'", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();

        if (ds3.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds3;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

    }
    public void bind2()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select ID,fromarazi AS 'ARAZI',totalland AS 'TOTAL LAND',road AS 'ROAD',rate AS 'RATE' from kishanarazi", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();

        if (ds3.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = ds3;
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select fromarazi from kishanarazi where toarazi='"+DropDownList1.Text+"' AND fromarazi='"+DropDownList2.Text+"'", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        int i = 0;
        if (ds3.Tables[0].Rows.Count > 0)
        {
            
            if (ds3.Tables[0].Rows[0][0].ToString() != "")
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
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into kishanarazi (toarazi,fromarazi,totalland,road,rate)values('" + DropDownList1.Text + "','" + DropDownList2.Text + "'," + TextBox1.Text + "," + TextBox2.Text + "," + TextBox4.Text + ")", con);
            int p=cmd.ExecuteNonQuery();
            con.Close();
            if (p != 0)
            {
                string message = DropDownList2.Text + " Arazi Added In " + DropDownList1.Text;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                bind();
                bind2();
            }

        }
        else
        {
            string message = DropDownList2.Text+" Arazi Already Added In " +DropDownList1.Text;
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
         SqlConnection con = new SqlConnection(s);
        con.Open();
     //   con.Open();
            SqlCommand cmd = new SqlCommand("delete from kishanarazi where id="+TextBox3.Text+"", con);
            int p=cmd.ExecuteNonQuery();
            con.Close();
            if (p != 0)
            {
                string message ="Deleted Successfully";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                bind();
                bind2();
            }

        
        else
        {
            string message = "Please Enter Correct Id ";
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