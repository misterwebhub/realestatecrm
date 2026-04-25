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
using System.Globalization;

public partial class Default2 : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar2"].ConnectionString.ToString();
    string s3 = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public static Double bal, paid;
    protected void Page_Load(object sender, EventArgs e)
    {
        Double t;
        if (!IsPostBack == true)
        {
            //Label4.Text =Request.QueryString["val1"].ToString();
            Session["ID"] = "ft";
            if (Session["ID"] != null)
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select hoarac from hishab where ID=(select max(ID) from hishab)",con);
                DataSet ds= new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        t = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        t = 0;
                    }
                }
                else
                {
                    t = 0;

                }
                Label1.Text = t.ToString();
                bal = t;
                bind();
                 bind1();
               
             
            }
            else
            {
                Response.Redirect("~/home/usercredential/credential.aspx");
            }
        }
       
    }
    public void  bind1()
    {
      
        Double rt=0;
        DateTime dt = DateTime.Now;
        SqlConnection con = new SqlConnection(s3);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select  sum(amount) from userchequepaidac where date='" + dt.ToShortDateString() + "'", con);
        DataSet ds = new DataSet();
        con.Close();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                rt = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                rt = 0;
            }
        }
        else
        {
            rt = 0;
        }
        paid = bal-rt;

        Label4.Text = paid.ToString();
        Label5.Text = rt.ToString();
    }
    public void bind()
    {
        DateTime dt=DateTime.Now;
        SqlConnection con = new SqlConnection(s3);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select  * from userchequepaidac where date='"+dt.ToShortDateString()+"' order BY ID DESC", con);
        DataSet ds = new DataSet();
        con.Close();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s3);
        if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "")
        {
            Label2.Text = "Please Fill All Text";
        }
        else
        {
              DateTime dt = DateTime.Now;
			
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into userchequepaidac (date,ptype,name,chequeno,amount,remark)values('" + dt.ToShortDateString() + "','" + DropDownList1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "'," + TextBox4.Text + ",'" + TextBox5.Text + "')",con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
           // Label2.Text = "Record Added";
            TextBox2.Text = "";
                TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                   bind();
                   bind1();
        }
        else
        {
            Label2.Text = "Error ";
        }
        }
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(s3);

        SqlCommand cmd = new SqlCommand("insert into deluserchequepaidac(date,ptype,name,chequeno,amount,remark,deldate) select date,ptype,name,chequeno,amount,remark,GETDATE() from  userchequepaidac where ID="+TextBox6.Text+"", con1);
        con1.Open();
        int i = cmd.ExecuteNonQuery();
        con1.Close();
        if (i != 0)
        {
            SqlCommand cmd1 = new SqlCommand("delete from userchequepaidac where ID=" + TextBox6.Text + "", con1);
            con1.Open();
            int j = cmd1.ExecuteNonQuery();
            con1.Close();
            Label3.Text = "RECORD DELETED SUCESSFULLY";
            bind();
            bind1();
        }
        else
        {
            Label3.Text = "RECORD NOT DELETED";
        }
    }
}