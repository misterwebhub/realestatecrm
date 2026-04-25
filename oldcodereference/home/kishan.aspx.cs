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

public partial class kishan : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fetch();
            bindl();
            bindl2();
            Panel1.Visible = false;
            Panel2.Visible = false;
        }
    }
    public void fetch()
    {
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int rcid = 0;
            SqlCommand cmd = new SqlCommand("select max(kid) from newkishan", con1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    rcid = Convert.ToInt32(dr.GetValue(0));
                }
                rcid = rcid + 1;
                Label12.Text = "K00"+rcid.ToString();

            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }
    public void bindl()
    {

        DropDownList1.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino,loc from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
    public void bindl2()
    {

        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT name from kishanbrokarpage", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlCommand cmd2 = new SqlCommand("insert into wjstar1.ploted1(arazino,loc,kname,brokername)values('" + TextBox22.Text + "','" + TextBox17.Text + "','" + TextBox16.Text + "',NULL)", con);
        int i = cmd2.ExecuteNonQuery();
        con.Close();
        if (i == 0)
        {
            Label4.Text = "internal problam";

        }
        else
        {
            Label4.Text = "successfully added";
            bindl();
            Panel1.Visible = false;

        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = false;
            Label10.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into kishanbrokarpage(name,aadhar,mobile)values('" + TextBox18.Text + "','" + TextBox23.Text + "','" + TextBox19.Text + "')", con1);
            int i = cmd.ExecuteNonQuery();
           
            con1.Close();


            if (i == 1)
            {
                Label10.Text = "Record added Sucessfully";
                bindl2();
                Panel2.Visible = false;
            }
            else
            {
                Label10.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label10.Text = "internal problem";
        }
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList1.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT loc from wjstar1.ploted1 where arazino='"+DropDownList1.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

           TextBox5.Text=ds.Tables[0].Rows[i][0].ToString();
        }
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {
            TextBox9.Text = "CASH";
            Label11.Text = "CASH";
        }
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {

        if (RadioButton2.Checked)
        {
            TextBox9.Text = " ";
            Label11.Text = "CHEQUE NO";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
    }
    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {
        Double total = 0, paid = 0, bal = 0;
        total = Convert.ToDouble(TextBox6.Text);
        paid = Convert.ToDouble(TextBox8.Text);
        bal = total - paid;
        TextBox7.Text = bal.ToString();
    }
    protected void TextBox12_TextChanged(object sender, EventArgs e)
    {
        Double total = 0, paid = 0, bal = 0;
        total = Convert.ToDouble(TextBox11.Text);
        paid = Convert.ToDouble(TextBox12.Text);
        bal = total - paid;
        TextBox13.Text = bal.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string mode = "";
            string s2 = TextBox2.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string kdate1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox10.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string ldate2 = mm1 + "/" + dd1 + "/" + yy1;
            Label1.Text = "";
            if (RadioButton2.Checked)
            {
                mode = RadioButton2.Text;
            }
            if (RadioButton1.Checked)
            {
                mode = RadioButton1.Text;
            }
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into newkishan(id,kname,date,mobile,landsize,arazi,location,landamount,baymode,paidamount,landbalance,lastdate,brokername,btotal,bpaid,bbalance,bcomment,kcomment,modetype,saleland,salerate)values('"+Label12.Text+"','"+TextBox1.Text+"','"+kdate1+"','"+TextBox3.Text+"','"+TextBox4.Text+"','"+DropDownList1.Text+"','"+TextBox5.Text+"',"+TextBox6.Text+",'"+TextBox9.Text+"',"+TextBox8.Text+","+TextBox7.Text+",'"+ldate2+"','"+DropDownList2.Text+"',"+TextBox11.Text+","+TextBox12.Text+","+TextBox13.Text+",'"+TextBox14.Text+"','"+TextBox15.Text+"','"+mode+"',"+TextBox24.Text+","+TextBox25.Text+")", con1);
            int i = cmd.ExecuteNonQuery();

            con1.Close();



            if (i == 1)
            {
                Label1.Text = "Record added Sucessfully";
               
            }
            else
            {
                Label1.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
}