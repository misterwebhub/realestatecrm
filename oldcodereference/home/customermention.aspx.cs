
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
using System.Globalization;

public partial class customer_details : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
        {
			 Label1.Text ="";
            Label2.Text ="";
            Label3.Text ="";
			 Label4.Text ="";
         
			bind();
		}
	}
	 protected void TextBox2_TextChanged(object sender, EventArgs e)
         {
		 SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select APPNO,plotno AS 'PLOT NO',PLOTSIZE from wjstar1.customerreg1 WHERE CUSTREGNO='" + TextBox2.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count==0)
        {
            Label4.Text = "RECORD DOES NOT FOUNT";
			 Label1.Text ="";
            Label2.Text ="";
            Label3.Text ="";
          
        }
        else
        {
			 Label4.Text = "";
            Label1.Text = ds.Tables[0].Rows[0][0].ToString();
            Label2.Text = ds.Tables[0].Rows[0][1].ToString();
            Label3.Text = ds.Tables[0].Rows[0][2].ToString();
          
           
		}
	 }
public void bind()
{
	SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM cheuqemention ORDER BY ID DESC", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
           GridView1.DataSource = ds1;
                GridView1.DataBind();
            
}
	protected void Button3_Click(object sender, EventArgs e)
    {
		SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM cheuqemention where refno LIKE '%"+TextBox5.Text+"%'", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
		 if (ds1.Tables[0].Rows.Count==0)
        {
            Label5.Text = "RECORD DOES NOT FOUNT";
			 GridView1.DataSource = null;
                GridView1.DataBind();
			
          
        }
        else
        {
			GridView1.DataSource = ds1;
                GridView1.DataBind();
          
           
		}
           
	}
	 protected void Button2_Click(object sender, EventArgs e)
    {
		  SqlConnection con1 = new SqlConnection(s);
            con1.Open();
		 
		 SqlCommand cmd = new SqlCommand("delete from cheuqemention where id="+TextBox21.Text+"", con1);
		 int i=cmd.ExecuteNonQuery();
		 if(i!=0)
		 {
			 Label4.Text="Record Deleted";
			 bind();
		 }
		 else			 
		 {
			Label4.Text="ID Not Found"; 
		 }
	 }
	 protected void Button1_Click(object sender, EventArgs e)
    {
		 SqlConnection con1 = new SqlConnection(s);
            con1.Open();
		 string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string start = mm + "/" + dd + "/" + yy;
		 SqlCommand cmd = new SqlCommand("insert into cheuqemention(CUSTREGNO,arazi,plotno,plotsize,date,mode,refno,amount)values('"+TextBox2.Text+"','"+Label1.Text+"','"+Label2.Text+"','"+Label3.Text+"','"+start+"','"+DropDownList1.Text+"','"+TextBox3.Text+"',"+TextBox4.Text+")", con1);
		 int i=cmd.ExecuteNonQuery();
		 if(i!=0)
		 {
			 Label4.Text="Record Added";
			 bind();
		 }
		 else			 
		 {
			Label4.Text="Error Generated"; 
		 }
		 
	 }
}