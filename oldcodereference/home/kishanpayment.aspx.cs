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

public partial class kishanpayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fetch1();
            
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;

        }
    }
    public void fetch1()
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id,kname,arazi from newkishan where kid NOT IN (1)", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }
    public void fetchemp()
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select bregno,name from newbroker", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            GridView2.DataSource = ds;
            GridView2.DataBind();

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
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select invid,ivname from newinvester", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            GridView3.DataSource = ds;
            GridView3.DataBind();

        }
        catch (Exception t)
        {
            Label18.Text = "Due to error";
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Panel2.Visible =false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel7.Visible = false;
        fetchinv();
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = true;
        Panel5.Visible = false;
    }
    public void payadd()
    {
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select payname from brokerpay", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = true;
        fetchemp();
        payadd();
    }
  public static string mode;
   
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        mode = RadioButton1.Text;
        Panel1.Visible = false;
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        mode = RadioButton2.Text;
        Panel1.Visible = true;
    }
    public void fetchkishanrecipt()
    {
       
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int rcid = 0;
            SqlCommand cmd = new SqlCommand("select max(id) from kishanrecipt", con1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    rcid = Convert.ToInt32(dr.GetValue(0));
                }
                rcid = rcid + 1;
                Label14.Text = "R00"+rcid.ToString();

            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    
    }
    public void kishan()
    {
        string kid = id;
        fetchkishanrecipt();
        Double ktotal = 0, kpaid = 0, kbal = 0, btotal = 0, bpaid = 0, bbal = 0, unpaid = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select id,kname,arazi,landamount,brokername,btotal from newkishan where id='" + kid + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        Label2.Text = ds.Tables[0].Rows[0][0].ToString();
        Label3.Text = ds.Tables[0].Rows[0][2].ToString();
        Label4.Text = ds.Tables[0].Rows[0][1].ToString();
        Label5.Text = ds.Tables[0].Rows[0][3].ToString();
        ktotal = Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
        Label10.Text = ds.Tables[0].Rows[0][4].ToString();
        Label11.Text = ds.Tables[0].Rows[0][5].ToString();
        btotal = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount),sum(bpaid) from kishanrecipt where kid='" + kid + "' AND status='PAID' ", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();

        SqlDataAdapter da3 = new SqlDataAdapter("select sum(amount) from kishanrecipt where kid='" + kid + "' AND status='UNPAID'", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                kpaid = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                kpaid = 0;
            }
            if (ds1.Tables[0].Rows[0][1].ToString() != "")
            {
                bpaid = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                bpaid = 0;
            }
        }
        if (ds3.Tables[0].Rows[0][0].ToString() != "")
        {
            unpaid = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            unpaid = 0;
        }
        kbal = ktotal - kpaid;
        Label6.Text = kpaid.ToString();
        Label7.Text = kbal.ToString();
        bbal = btotal - bpaid;
        Label12.Text = bpaid.ToString();
        Label13.Text = bbal.ToString();
        Label8.Text = unpaid.ToString();
    }
	public static string convertnumtoword(int number)
    {
        if (number == 0)
            return "Zero";
        if (number < 0)
            return "MINUS" + convertnumtoword(Math.Abs(number));
        string word = "";
        
           
            
        
		if ((number / 100000) > 0)
            {
                word += convertnumtoword(number / 100000) + " Lakh ";
                number %= 100000;
            }
        if ((number / 1000) > 0)
        {
            word += convertnumtoword(number / 1000) + " Thousand ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            word += convertnumtoword(number / 100) + " Hundred ";
            number %= 100;
        }
        if (number > 0)
        {
            if (word != " ")
                word += "";
            var unitmap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tenmap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
            if (number < 20)
            {
                word += unitmap[number];
            }
            else
            {
                word += tenmap[number / 10];
                if ((number % 10) > 0)
                {
                    word += " " + unitmap[number % 10];
                }
            }
        }
        return word;

    }
    static string id;
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow selectedRow = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
        string kid=selectedRow.Cells[0].Text;
        id = kid;
        kishan();
    }
    String chkdate, chknn, refno, status;
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string s2 = TextBox3.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
        
        if (mode == "CASH")
        {
            chkdate = null;
            chknn = null;
            refno = null;
            status = "PAID";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into kishanrecipt(reciptid,kid,arazi,name,ktotalamt,kpaidamt,kbalance,kunpaid ,date,paymode,cheqdate,cheqno,refno,status,amount,reason,broker,btotal,btpaid,bbalance,bpaid,breason,unpaidamt)values('" + Label14.Text + "','" + Label2.Text + "','" + Label3.Text + "','" + Label4.Text + "'," + Label5.Text + "," + TextBox1.Text + "," + Label7.Text + "," + Label8.Text + ",'" + date1 + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "'," + TextBox1.Text + ",'" + TextBox2.Text + "','" + Label10.Text + "'," + Label11.Text + "," + TextBox4.Text + "," + Label13.Text + "," + TextBox4.Text + ",'" + TextBox5.Text + "',0)", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                Label9.Text = "Record Added";
            }
            else
            {
                Label9.Text = "Error";
            }
           
        }
        if (mode == "CHEQUE")
        {
            string s3 = TextBox8.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string ck = mm1 + "/" + dd1 + "/" + yy1;
            chkdate =ck;
            chknn =TextBox6.Text;
            refno = TextBox7.Text;
            status =DropDownList1.Text;

            if (status == "PAID")
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into kishanrecipt(reciptid,kid,arazi,name,ktotalamt,kpaidamt,kbalance,kunpaid ,date,paymode,cheqdate,cheqno,refno,status,amount,reason,broker,btotal,btpaid,bbalance,bpaid,breason,unpaidamt)values('" + Label14.Text + "','" + Label2.Text + "','" + Label3.Text + "','" + Label4.Text + "'," + Label5.Text + "," + TextBox1.Text + "," + Label7.Text + "," + Label8.Text + ",'" + date1 + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "'," + TextBox1.Text + ",'" + TextBox2.Text + "','" + Label10.Text + "'," + Label11.Text + "," + TextBox4.Text + "," + Label13.Text + "," + TextBox4.Text + ",'" + TextBox5.Text + "',0)", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    Label9.Text = "Record Added";
                }
                else
                {
                    Label9.Text = "Error";
                }
            }
            if (status == "UNPAID")
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into kishanrecipt(reciptid,kid,arazi,name,ktotalamt,kpaidamt,kbalance,kunpaid ,date,paymode,cheqdate,cheqno,refno,status,amount,reason,broker,btotal,btpaid,bbalance,bpaid,breason,unpaidamt)values('" + Label14.Text + "','" + Label2.Text + "','" + Label3.Text + "','" + Label4.Text + "'," + Label5.Text + "," + TextBox1.Text + "," + Label7.Text + "," + Label8.Text + ",'" + date1 + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "',0,'" + TextBox2.Text + "','" + Label10.Text + "'," + Label11.Text + "," + TextBox4.Text + "," + Label13.Text + "," + TextBox4.Text + ",'" + TextBox5.Text + "'," + TextBox1.Text + ")", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    Label9.Text = "Record Added";
                }
                else
                {
                    Label9.Text = "Error";
                }
            }
           
        }
        


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        kishan();
        Label9.Text = "";
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Panel6.Visible = true;
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        mode = RadioButton3.Text;
        Label31.Text = "CASH";
        TextBox12.Text = "CASH";
        Panel6.Visible = false;
    }
    
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        Label31.Text = "CHEQUE";
        TextBox12.Text = "";
        mode = RadioButton4.Text;
        Panel6.Visible = false;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into brokerpay(payname)values('"+TextBox14.Text+"')", con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            Label32.Text = "Record Added";
            payadd();
        }
        else
        {
            Label32.Text = "Error";
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.Text == "PERSONAL")
        {
            TextBox10.Text = "PERSONAL";
        }
        else
        {
            TextBox10.Text = "";
        }
    }
    public void fetchkishanrecipt1()
    {

        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int rcid = 0;
            SqlCommand cmd = new SqlCommand("select max(id) from emppayrecipt", con1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    rcid = Convert.ToInt32(dr.GetValue(0));
                }
                rcid = rcid + 1;
                Label16.Text = "B00" + rcid.ToString();

            }
            con1.Close();
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select sum(paid) from emppayrecipt ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows[0][0].ToString() != "")
                Label30.Text = ds.Tables[0].Rows[0][0].ToString();
            else
                Label30.Text = "0";
        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow selectedRow = GridView2.Rows[Convert.ToInt32(e.CommandArgument)];
        string kid = selectedRow.Cells[0].Text;
        string name = selectedRow.Cells[1].Text;
        Label29.Text = name;
        Label17.Text = kid;
        fetchkishanrecipt1();
       
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        fetchkishanrecipt1();
        Label28.Text = "";
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string s2 = TextBox9.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;

        if (mode == "CASH")
        {
            //chkdate = null;
            chknn = null;
           // refno = null;
            //status = "PAID";

        }
        if (mode == "CHEQUE")
        {
           
           
            chknn = TextBox12.Text;
           

        }
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into emppayrecipt(emprecipt,empreg ,name ,paid ,date ,payfor,payfortype ,reason ,paymode ,paytype )values('"+Label16.Text+"','"+Label17.Text+"','"+Label29.Text+"',"+TextBox13.Text+",'"+date1+"','"+DropDownList2.Text+"','"+TextBox10.Text+"','"+TextBox11.Text+"','"+mode+"','"+chknn+"')", con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            Label28.Text = "Record Added";
        }
        else
        {
            Label28.Text = "Error";
        }
    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
        mode = RadioButton5.Text;
        Panel7.Visible = false;
   
    }
    protected void RadioButton6_CheckedChanged(object sender, EventArgs e)
    {
        
        mode = RadioButton6.Text;
        Panel7.Visible = true;
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow selectedRow = GridView3.Rows[Convert.ToInt32(e.CommandArgument)];
        string kid = selectedRow.Cells[0].Text;
        id = kid;
        invester();
    }
    public void fetchinesterrecipt()
    {

        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int rcid = 0;
            SqlCommand cmd = new SqlCommand("select max(id) from investerrecipt", con1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    rcid = Convert.ToInt32(dr.GetValue(0));
                }
                rcid = rcid + 1;
                Label19.Text = "Z00" + rcid.ToString();

            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label19.Text = "Due to error";
        }

    }
    public void invester()
    {
        string kid = id;
        fetchinesterrecipt();
        Double ktotal = 0, kpaid = 0, kbal = 0, btotal = 0, bpaid = 0, bbal = 0, unpaid = 0,retamt=0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid,ivname,totalinvestamt,returnamt,brokername,btotal from newinvester where invid='" + kid + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        Label20.Text = ds.Tables[0].Rows[0][0].ToString();
        Label22.Text = ds.Tables[0].Rows[0][1].ToString();
        Label23.Text = ds.Tables[0].Rows[0][2].ToString();
        Label24.Text = ds.Tables[0].Rows[0][3].ToString();
        Label27.Text = ds.Tables[0].Rows[0][4].ToString();
        Label33.Text = ds.Tables[0].Rows[0][5].ToString();
        btotal = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());
       
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount) from investerrecipt where invid='" + kid + "' AND status='PAID' AND type='RECEIVE' AND bpaid=0  ", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            kpaid = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            kpaid = 0;
        }
        Label25.Text = kpaid.ToString();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(amount) from investerrecipt where invid='" + kid + "' AND status='PAID' AND  type='RETURN' AND bpaid=0 ", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            retamt = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            retamt = 0;
        }
        Label37.Text = retamt.ToString();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select sum(bpaid) from investerrecipt where invid='" + kid + "' AND status='PAID' AND bpaid NOT IN(0) ", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        if (ds3.Tables[0].Rows[0][0].ToString() != "")
        {
            bpaid = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            bpaid = 0;
        }
        bbal = btotal - bpaid;
        Label34.Text =bpaid.ToString();
        Label35.Text = bbal.ToString();
       
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        invester();
        Label36.Text = "";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string s2 = TextBox15.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;

        if (mode == "CASH")
        {
            chkdate = null;
            chknn = null;
            refno = null;
            status = "PAID";
            mode = "CASH";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into investerrecipt(invrecipt,invid,name,totalinvamt,totalreturn,date,amount,type,paymode,chekdate, chkno,refby,status,reason,bname,btotal,bpaid,breason,unpamt )values('" + Label19.Text + "','" + Label20.Text + "','" + Label22.Text + "'," + Label23.Text + "," + Label24.Text + ",'" + date1 + "'," + TextBox16.Text + ",'" + DropDownList4.Text + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "','" + TextBox20.Text + "','" + Label27.Text + "'," + Label33.Text + "," + TextBox21.Text + ",'" + TextBox22.Text + "',0)", con);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                Label36.Text = "Record Added";
            }
            else
            {
                Label36.Text = "Error";
            }

        }
        if (mode == "CHEQUE")
        {
            string s3 = TextBox17.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string ck = mm1 + "/" + dd1 + "/" + yy1;
            chkdate = ck;
            chknn = TextBox18.Text;
            refno = TextBox19.Text;
            mode = "CHEQUE";
            status = DropDownList3.Text;
            if (status == "PAID")
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into investerrecipt(invrecipt,invid,name,totalinvamt,totalreturn,date,amount,type,paymode,chekdate, chkno,refby,status,reason,bname,btotal,bpaid,breason,unpamt )values('" + Label19.Text + "','" + Label20.Text + "','" + Label22.Text + "'," + Label23.Text + "," + Label24.Text + ",'" + date1 + "'," + TextBox16.Text + ",'" + DropDownList4.Text + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "','" + TextBox20.Text + "','" + Label27.Text + "'," + Label33.Text + "," + TextBox21.Text + ",'" + TextBox22.Text + "',0)", con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    Label36.Text = "Record Added";
                }
                else
                {
                    Label36.Text = "Error";
                }
            }
            if (status == "UNPAID")
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into investerrecipt(invrecipt,invid,name,totalinvamt,totalreturn,date,amount,type,paymode,chekdate, chkno,refby,status,reason,bname,btotal,bpaid,breason,unpamt )values('" + Label19.Text + "','" + Label20.Text + "','" + Label22.Text + "'," + Label23.Text + "," + Label24.Text + ",'" + date1 + "',0,'" + DropDownList4.Text + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "','" + TextBox20.Text + "','" + Label27.Text + "'," + Label33.Text + "," + TextBox21.Text + ",'" + TextBox22.Text + "'," + TextBox16.Text + ")", con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    Label36.Text = "Record Added";
                }
                else
                {
                    Label36.Text = "Error";
                }
            }

        }
        
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string word = convertnumtoword(Convert.ToInt32(TextBox1.Text)) + " Rupees Only";
        TextBox2.Text = word;
    }
    protected void TextBox16_TextChanged(object sender, EventArgs e)
    {
        string word = convertnumtoword(Convert.ToInt32(TextBox16.Text)) + " Rupees Only";
        TextBox20.Text = word;
    }
}
