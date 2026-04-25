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


public partial class registr : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fetch();
            bindl();
            bindl2();
            bindl3();
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
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
                Label12.Text = "K00" + rcid.ToString();
               

            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }
    public void fetchinv()
    {
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int rcid = 0;
            SqlCommand cmd = new SqlCommand("select max(id) from newinvester", con1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    rcid = Convert.ToInt32(dr.GetValue(0));
                }
                rcid = rcid + 1;
                Label14.Text = "I00" + rcid.ToString();
               

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
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT loc from wjstar1.ploted1 where arazino='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            TextBox5.Text = ds.Tables[0].Rows[i][0].ToString();
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
        bindl2();
       
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
            SqlCommand cmd = new SqlCommand("insert into newkishan(id,kname,date,mobile,landsize,arazi,location,landamount,baymode,paidamount,landbalance,lastdate,brokername,btotal,bpaid,bbalance,bcomment,kcomment,modetype,saleland,salerate,status)values('" + Label12.Text + "','" + TextBox1.Text + "','" + kdate1 + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DropDownList1.Text + "','" + TextBox5.Text + "'," + TextBox6.Text + ",'" + TextBox9.Text + "'," + TextBox8.Text + "," + TextBox7.Text + ",'" + ldate2 + "','" + DropDownList2.Text + "'," + TextBox11.Text + "," + TextBox12.Text + "," + TextBox13.Text + ",'" + TextBox14.Text + "','" + TextBox15.Text + "','" + mode + "'," + TextBox24.Text + "," + TextBox25.Text + ",'currently')", con1);
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
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        fetch();
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        Panel3.Visible = true;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        fetchinv();
        Panel4.Visible = false;
        Panel3.Visible = false;
        Panel6.Visible = false;
        Panel5.Visible = true;
        Panel7.Visible = false;
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        fetch();
        Panel3.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = true;
        Panel7.Visible = false;
    }
   
    protected void Button14_Click(object sender, EventArgs e)
    {
        try
        {
            Panel4.Visible = false;
            Label10.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into kishanbrokarpage(name,aadhar,mobile)values('" + TextBox39.Text + "','" + TextBox40.Text + "','" + TextBox41.Text + "')", con1);
            int i = cmd.ExecuteNonQuery();

            con1.Close();


            if (i == 1)
            {
                Label16.Text = "Record added Sucessfully";
                bindl3();
               
            }
            else
            {
                Label10.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label16.Text = "internal problem";
        }
    }
    public void bindl3()
    {

        DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT name from kishanbrokarpage", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList4.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
    }
    protected void RadioButton9_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton9.Checked)
        {
            TextBox37.Text = "CASH";
            Label15.Text = "CASH";
        }
    }
    protected void RadioButton10_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton10.Checked)
        {
            TextBox37.Text = " ";
            Label15.Text = "CHEQUE NO";
        }
    }
    protected void TextBox75_TextChanged(object sender, EventArgs e)
    {
        Double total = 0, paid = 0, bal = 0;
        total = Convert.ToDouble(TextBox49.Text);
        paid = Convert.ToDouble(TextBox75.Text);
        bal = total - paid;
        TextBox42.Text = bal.ToString();
    }
    protected void TextBox76_TextChanged(object sender, EventArgs e)
    {
        Double total = 0, paid = 0, bal = 0;
        total = Convert.ToDouble(TextBox44.Text);
        paid = Convert.ToDouble(TextBox76.Text);
        bal = total - paid;
        TextBox46.Text = bal.ToString();
    }
    protected void Button15_Click(object sender, EventArgs e)
    {

    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        try
        {
            string mode = "";
            string s2 = TextBox30.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string kdate1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox43.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string ldate2 = mm1 + "/" + dd1 + "/" + yy1;
            Label17.Text = "";
            if (RadioButton9.Checked)
            {
                mode = RadioButton9.Text;
            }
            if (RadioButton10.Checked)
            {
                mode = RadioButton10.Text;
            }
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into newinvester(invid,ivname,date,mobile,totalinvestamt,returnamt,paymode,modetype,recamount,balance,lastdate,brokername,btotal,bpaid,bbalance,bcomment,icomment,status,monthlypay)values('"+Label14.Text+"','"+TextBox29.Text+"','"+kdate1+"','"+TextBox31.Text+"',"+TextBox49.Text+","+TextBox36.Text+",'"+TextBox37.Text+"','"+mode+"',"+TextBox75.Text+","+TextBox42.Text+",'"+ldate2+"','"+DropDownList4.Text+"',"+TextBox44.Text+","+TextBox76.Text+","+TextBox46.Text+",'"+TextBox47.Text+"','"+TextBox48.Text+"','currently','"+TextBox481.Text+"')", con1);
            int i = cmd.ExecuteNonQuery();

            con1.Close();



            if (i == 1)
            {
                Label17.Text = "Record added Sucessfully";

            }
            else
            {
                Label17.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label17.Text = "internal problem"+t;
        }
    }
    public void fetchbro()
    {
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int rcid = 0;
            SqlCommand cmd = new SqlCommand("select max(id) from newbroker", con1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    rcid = Convert.ToInt32(dr.GetValue(0));
                }
                rcid = rcid + 1;
                Label22.Text = "B00" + rcid.ToString();


            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label22.Text = "Due to error";
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        fetchbro();
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = true;
        Panel3.Visible = false;
    }
    protected void RadioButton11_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton11.Checked)
        {
            TextBox71.Text = "CASH";
            Label23.Text = "CASH";
        }
    }
    protected void RadioButton12_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton12.Checked)
        {
            TextBox71.Text = " ";
            Label23.Text = "CHEQUE NO";
        }

    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        fetchbro();
        TextBox66.Text = "";
        Label24.Text = "";
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        try
        {
            string mode = "";
            string s2 = TextBox67.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string kdate1 = mm + "/" + dd + "/" + yy;
           
            Label23.Text = "";
            if (RadioButton11.Checked)
            {
                mode = RadioButton11.Text;
            }
            if (RadioButton12.Checked)
            {
                mode = RadioButton12.Text;
            }
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into newbroker(bregno,name,date,mobile,paymode,paytype,paidamt,empcommt)values('"+Label22.Text+"','"+TextBox66.Text+"','"+kdate1+"','"+TextBox68.Text+"','"+TextBox71.Text+"','"+mode+"',"+TextBox77.Text+",'"+TextBox74.Text+"')", con1);
            int i = cmd.ExecuteNonQuery();

            con1.Close();



            if (i == 1)
            {
                Label24.Text = "Record added Sucessfully";

            }
            else
            {
                Label24.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label24.Text = "internal problem" + t;
        }
    }
}
