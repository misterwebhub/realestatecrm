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

public partial class _161GHA_extrapaymentrecipt : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox4.Visible = false;
            Label1.Visible = false;
            boind2();
        }
    }
    public void boind2()
    {
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select name from extraclass", con);
        con.Open();
         DataSet ds = new DataSet();
         da.Fill(ds);
         con.Close();
         DropDownList3.Items.Clear();
         DropDownList3.Items.Add("--select--");
         DropDownList4.Items.Clear();
         DropDownList4.Items.Add("--select--");
         if (ds.Tables[0].Rows.Count > 0)
         {
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                 DropDownList4.Items.Add(ds.Tables[0].Rows[i][0].ToString());
             }
         }
         else
         {
             DropDownList3.DataSource = null;
             DropDownList3.DataBind();
             DropDownList4.DataSource = null;
             DropDownList4.DataBind();
         }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.Text == "CASH")
        {
            TextBox4.Visible = false;
            Label1.Visible = false;
        }
        else
        {
            TextBox4.Visible = true;
            Label1.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string start = mm + "/" + dd + "/" + yy;
        string mode2 = null;
        if (DropDownList2.Text == "CASH")
        {
            mode2 = null;
        }
        else
        {
            mode2 = TextBox4.Text;
        }
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into extrapaymentexp(date,class1,name,mode1,amount,reason,number1,status)values('" + start + "','" + DropDownList3.Text + "','" + DropDownList1.Text + "','" + DropDownList2.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + mode2 + "','CR')", con);
        int r = cmd.ExecuteNonQuery();
        if (r == 1)
        {
            string message = "Payment added sucessfully";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else
        {
            string message = "Payment is not added";
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
        
        SqlDataAdapter da = new SqlDataAdapter("select name from extraclass where name='"+TextBox5.Text+"'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        int r = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                r = 1;
            }
            else
            {
                r = 0;
            }
        }
        else
        {
            r = 0;
        }
        if (r == 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into extraclass(name)values('"+TextBox5.Text+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            string message = "Class Name Added Sucessfully";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            boind2();
        }
        else
        {
            string message = "Class Name Already Exist";
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

        SqlDataAdapter da = new SqlDataAdapter("select name from extraclassname where name='" + TextBox6.Text + "' AND class1='"+DropDownList4.Text+"'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        int r = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                r = 1;
            }
            else
            {
                r = 0;
            }
        }
        else
        {
            r = 0;
        }
        if (r == 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into extraclassname(class1,name)values('"+DropDownList4.Text+"','" + TextBox6.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            string message = "Name Added Sucessfully";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            boind2();
        }
        else
        {
            string message = "Name Already Exist";
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
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select name from extraclassname where class1='"+DropDownList3.Text+"'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("--select--");
       
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
               // DropDownList4.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
        else
        {
            DropDownList1.DataSource = null;
            DropDownList1.DataBind();
           
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string s2 = TextBox7.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string start = mm + "/" + dd + "/" + yy;
        string s3 = TextBox8.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string start1 = mm1 + "/" + dd1 + "/" + yy1;
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select ID,date,class1,name,mode1,number1,amount,reason from extrapaymentexp where date between '" + start + "' AND '" + start1 + "' AND status='CR' ", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount) from extrapaymentexp where date between '" + start + "' AND '" + start1 + "' AND status='CR'", con);
        con.Open();
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
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
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label2.Text = "";
            }
        }
        else
        {
            Label2.Text = "";

        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from  extrapaymentexp where ID="+TextBox9.Text+"", con);
        int r = cmd.ExecuteNonQuery();
        if (r == 1)
        {
            string message = "Payment deleted sucessfully";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else
        {
            string message = "Payment is not deleted";
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