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

public partial class home_remidercheque : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label2.Text = "";
            bind();
            gbind();
            total();
        }
    }
    public void total()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(amount) from wjstar1.remcheque", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount) from wjstar1.remcheque where status='CASH' OR status='CHEQUE PAID'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        string totalamt = ds.Tables[0].Rows[0][0].ToString();
        string paid = ds1.Tables[0].Rows[0][0].ToString();
        Double total1 = Convert.ToDouble(totalamt);
        Double paid1 = Convert.ToDouble(paid);
        Double bal = total1 - paid1;
        Label6.Text = total1.ToString();
        Label5.Text = paid1.ToString();
        Label4.Text = bal.ToString();
        
    }
    public void gbind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazi,name,date,cheque,amount,plotno,status,statusdate from wjstar1.remcheque order by name ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();      

    }
    public void bind()
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
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        con.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string dateString2 = TextBox2.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            string ddd2 = dateTime2.ToString("mm/dd/yyyy");
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into wjstar1.remcheque(arazi,name,date,cheque,amount,plotno,status,statusdate)values('" + DropDownList1.Text + "','"+TextBox1.Text+"','" + ddd2 + "','" + TextBox3.Text + "'," + TextBox4.Text + ",'" + TextBox5.Text + "','unpaid',null)", con1);
            int i = cmd.ExecuteNonQuery();
            con1.Close();
            if (i != 0)
            {
                Label2.Text = "Record Added";
                gbind();
                total();
            }
            else
            {
                Label2.Text = "Internal Problem";
            }
            


        }
        catch (Exception t)
        {
            Label2.Text = "internal problem";
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try{
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazi,name,date,amount,plotno from wjstar1.remcheque where cheque='"+TextBox11.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            TextBox6.Text = ds.Tables[0].Rows[0][1].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0][2].ToString();
            TextBox9.Text = ds.Tables[0].Rows[0][3].ToString();
            TextBox10.Text = ds.Tables[0].Rows[0][4].ToString();
        }
        else
        {
            Label3.Text = "Record Not Found";
        }
        con.Close();
        }
        catch (Exception t)
        {
            Label3.Text = "internal problem";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
           
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("delete from wjstar1.remcheque where cheque='" + TextBox11.Text + "'", con1);
            int i = cmd.ExecuteNonQuery();
            con1.Close();
            if (i != 0)
            {
                Label3.Text = "Record Deleted";
                gbind();
                total();
            }
            else
            {
                Label3.Text = "Internal Problem";
            }



        }
        catch (Exception t)
        {
            Label3.Text = "internal problem";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string dateString2 = TextBox7.Text;
            string format = "dd/mm/yyyy";
            DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            string ddd2 = dateTime2.ToString("mm/dd/yyyy");
            string dateString3 = TextBox12.Text;
            string format1 = "dd/mm/yyyy";
            DateTime dateTime3 = DateTime.ParseExact(dateString3, format1, CultureInfo.InvariantCulture);
            string ddd3 = dateTime3.ToString("mm/dd/yyyy");
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("update wjstar1.remcheque set arazi='"+DropDownList2.Text+"',name='"+TextBox6.Text+"',date='"+ddd2+"',amount='"+TextBox9.Text+"',plotno='"+TextBox10.Text+"',status='"+DropDownList3.Text+"',statusdate='"+ddd3+"' where cheque='" + TextBox11.Text + "' ",  con1);
            int i = cmd.ExecuteNonQuery();
            con1.Close();
            if (i != 0)
            {
                Label3.Text = "Record Updated Successfully";
                gbind();
                total();
            }
            else
            {
                Label3.Text = "Internal Problem";
            }



        }
        catch (Exception t)
        {
            Label2.Text = "internal problem";
        }
    }
   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            Label lblstatus = (Label)e.Row.FindControl("status1");
            Label lblarazi = (Label)e.Row.FindControl("arazi1");
            Label lblname = (Label)e.Row.FindControl("name1");
            Label lbldate = (Label)e.Row.FindControl("date1");
            Label lblcheque = (Label)e.Row.FindControl("cheque1");
            Label lblamount = (Label)e.Row.FindControl("amount1");
            Label lblplotno = (Label)e.Row.FindControl("plotno1");
			 Label lblstatus2 = (Label)e.Row.FindControl("status2");


            if (lblstatus.Text == "CASH")
            {

                lblstatus.Style.Add("color", "orange");
                lblarazi.Style.Add("color", "orange");
                lblname.Style.Add("color", "orange");
                lbldate.Style.Add("color", "orange");
                lblcheque.Style.Add("color", "orange");
                lblamount.Style.Add("color", "orange");
                lblplotno.Style.Add("color", "orange");
 lblstatus2.Style.Add("color", "orange");
            }
            if (lblstatus.Text == "CHEQUE PAID")
            {

                lblstatus.Style.Add("color", "Green");
                lblarazi.Style.Add("color", "Green");
                lblname.Style.Add("color", "Green");
                lbldate.Style.Add("color", "Green");
                lblcheque.Style.Add("color", "Green");
                lblamount.Style.Add("color", "Green");
                lblplotno.Style.Add("color", "Green");
 lblstatus2.Style.Add("color", "green");
            }
        }
    }
}