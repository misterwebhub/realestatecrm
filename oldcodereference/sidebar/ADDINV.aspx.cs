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
public partial class sidebar_ADDINV : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            Label2.Text = "";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Text = "";
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select ivname,status from newinvester where invid='" + TextBox1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Label1.Text = ds.Tables[0].Rows[0][0].ToString();
                Label2.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                Label1.Text = "";
                string message = "Record Not Found";
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
        else
        {
            Label1.Text = "";
            string message = "Record Not Found";
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
    public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select a.id AS 'ID',a.invid AS 'INV-ID',a.ivname AS 'NAME',ip.totalinvestamt AS 'REC. AMOUNT',ip.returnamt-ip.totalinvestamt AS 'PROFIT',ip.returnamt AS 'TOTAL AMOUNT',r.REC AS 'PAID',ip.returnamt-r.REC AS 'BALANCE' from (select invid,sum(amount) as 'REC' from investerrecipt  where  bpaid=0 AND status='PAID' AND type='RETURN' AND invid IN(select invid from invdetails where invid not in(select invid from monthinvdetails )) group by invid) as r inner join  invdetails as a on a.invid=r.invid inner join newinvester as ip on ip.invid=a.invid where ip.status='currently'", con);
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from  invdetails where id=" + TextBox2.Text + "", con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            string message = "Record Deleted Successfully";
            bind();
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
            string message = "We Found Error From Server";
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
        if (TextBox1.Text == "" )
        {
            string message = "Please Fill Invest ID";
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
            if (Label2.Text == "currently")
            {
                string s2 = TextBox1.Text;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select invid from invdetails where invid='" + TextBox1.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                int j = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        j = 0;
                    }
                    else
                    {
                        j = 1;
                    }
                }
                else
                {
                    j = 1;
                }
                if (j != 0)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into invdetails(invid,ivname)values('" + TextBox1.Text + "','" + Label1.Text + "')", con);
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        string message = "Record Added Successfully";
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                        bind();

                    }
                    else
                    {
                        string message = "We Found Error From Server";
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
                else
                {
                    string message = "Invester Id Already Added In To List";
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
            else
            {
                string message = "Invester Id Already Complted";
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
}