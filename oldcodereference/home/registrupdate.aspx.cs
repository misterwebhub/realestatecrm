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
   protected void Button5_Click(object sender, EventArgs e)
    {
SqlConnection con=new SqlConnection(s);
con.Open();
SqlCommand cmd = new SqlCommand("update newinvester set status='"+DropDownList11.Text+"'  where invid='"+TextBox79.Text+"' ", con);
cmd.ExecuteNonQuery();
con.Close();
Label17.Text    = "Status Change Success";


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
            SqlCommand cmd = new SqlCommand("update newkishan set kname='" + TextBox1.Text + "',date='" + kdate1 + "',mobile='" + TextBox3.Text + "',landsize='" + TextBox4.Text + "',arazi='" + DropDownList1.Text + "',location='" + TextBox5.Text + "',landamount=" + TextBox6.Text + ",baymode='" + TextBox9.Text + "',paidamount=" + TextBox8.Text + ",landbalance=" + TextBox7.Text + ",lastdate='" + ldate2 + "',brokername='" + DropDownList2.Text + "',btotal=" + TextBox11.Text + ",bpaid=" + TextBox2.Text + ",bbalance=" + TextBox3.Text + ",bcomment='" + TextBox14.Text + "',kcomment='" + TextBox15.Text + "',modetype='" + mode + "',saleland='" + TextBox24.Text + "',salerate='" + TextBox25.Text + "',status='"+DropDownList113.Text+"' where id='" + TextBox78.Text + "'", con1);
            int i = cmd.ExecuteNonQuery();

            con1.Close();



            if (i == 1)
            {
                Label1.Text = "Record Updated Sucessfully";

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
       
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        Panel3.Visible = true;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        
        Panel4.Visible = false;
        Panel3.Visible = false;
        Panel6.Visible = false;
        Panel5.Visible = true;
        Panel7.Visible = false;
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
       
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
			 Label17.Text="";
				 
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
            Label1.Text = "";
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
            SqlCommand cmd = new SqlCommand("update newinvester set ivname='"+TextBox29.Text+"',date='"+kdate1+"',mobile='"+TextBox31.Text+"',totalinvestamt="+TextBox49.Text+",returnamt="+TextBox36.Text+",paymode='"+TextBox37.Text+"',modetype='"+mode+"',recamount="+TextBox75.Text+",balance="+TextBox42.Text+",lastdate='"+ldate2+"',brokername='"+DropDownList4.Text+"',btotal="+TextBox44.Text+",bpaid="+TextBox76.Text+",bbalance="+TextBox46.Text+",bcomment='"+TextBox47.Text+"',icomment='"+TextBox48.Text+"',monthlypay='"+TextBox482.Text+"' where invid='"+TextBox79.Text+"'", con1);
            int i = cmd.ExecuteNonQuery();

            con1.Close();



            if (i == 1)
            {
                Label17.Text = "Record Updated Sucessfully";

            }
            else
            {
                Label17.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label17.Text = "internal problem";
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

    protected void Button19_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select kname,date,mobile,landsize,modetype,saleland,salerate,arazi,location,landamount,baymode,paidamount,landbalance,lastdate,brokername,btotal,bpaid,bbalance,bcomment,kcomment,status from newkishan where id='"+TextBox78.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label25.Text = "";
            TextBox1.Text = ds.Tables[0].Rows[0][0].ToString();
            string s4 = ds.Tables[0].Rows[0][1].ToString();
            DateTime r1 = Convert.ToDateTime(s4);
            int s8 = Convert.ToInt32(r1.Day.ToString());
            int m2 = Convert.ToInt32(r1.Month.ToString());
            if (m2 == 1 || m2 == 2 || m2 == 3 || m2 == 4 || m2 == 5 || m2 == 6 || m2 == 7 || m2 == 8 || m2 == 9)
            {
                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                {
                    string s2 = r1.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 1);
                    string yy = s2.Substring(4, 4);
                    string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                    TextBox2.Text = date1.ToString();

                }
                else
                {
                    string s2 = r1.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 2);
                    string yy = s2.Substring(5, 4);
                    string date1 = dd + "/" + "0" + mm + "/" + yy;
                    TextBox2.Text = date1.ToString();
                }

            }
            else
            {
                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                {
                    string s2 = r1.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 1);
                    string yy = s2.Substring(5, 4);
                    string date1 = "0" + dd + "/" + mm + "/" + yy;
                    TextBox2.Text = date1.ToString();

                }
                else
                {
                    string s2 = r1.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 2);
                    string yy = s2.Substring(6, 4);
                    string date1 = dd + "/" + mm + "/" + yy;
                    TextBox2.Text = date1.ToString();
                }
            }
            TextBox3.Text = ds.Tables[0].Rows[0][2].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0][3].ToString();
            TextBox24.Text = ds.Tables[0].Rows[0][5].ToString();
            TextBox25.Text = ds.Tables[0].Rows[0][6].ToString();
            DropDownList1.Text = ds.Tables[0].Rows[0][7].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0][8].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0][9].ToString();
            TextBox8.Text = ds.Tables[0].Rows[0][11].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0][12].ToString();
           // TextBox10.Text = ds.Tables[0].Rows[0][13].ToString();
            string s5 = ds.Tables[0].Rows[0][13].ToString();
            DateTime r2 = Convert.ToDateTime(s5);
            int s9 = Convert.ToInt32(r2.Day.ToString());
            int m3 = Convert.ToInt32(r2.Month.ToString());
            if (m3 == 1 || m3 == 2 || m3 == 3 || m3 == 4 || m3 == 5 || m3 == 6 || m3 == 7 || m3 == 8 || m3 == 9)
            {
                if (s9 == 1 || s9 == 2 || s9 == 3 || s9 == 4 || s9 == 5 || s9 == 6 || s9 == 7 || s9 == 8 || s9 == 9)
                {
                    string s2 = r2.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 1);
                    string yy = s2.Substring(4, 4);
                    string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                    TextBox10.Text = date1.ToString();

                }
                else
                {
                    string s2 = r2.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 2);
                    string yy = s2.Substring(5, 4);
                    string date1 = dd + "/" + "0" + mm + "/" + yy;
                    TextBox10.Text = date1.ToString();
                }

            }
            else
            {
                if (s9 == 1 || s9 == 2 || s9 == 3 || s9 == 4 || s9 == 5 || s9 == 6 || s9 == 7 || s9 == 8 || s9 == 9)
                {
                    string s2 = r2.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 1);
                    string yy = s2.Substring(5, 4);
                    string date1 = "0" + dd + "/" + mm + "/" + yy;
                    TextBox10.Text = date1.ToString();

                }
                else
                {
                    string s2 = r2.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 2);
                    string yy = s2.Substring(6, 4);
                    string date1 = dd + "/" + mm + "/" + yy;
                    TextBox10.Text = date1.ToString();
                }
            }
            DropDownList2.Text = ds.Tables[0].Rows[0][14].ToString();
            TextBox11.Text = ds.Tables[0].Rows[0][15].ToString();
            TextBox12.Text = ds.Tables[0].Rows[0][16].ToString();
            TextBox13.Text = ds.Tables[0].Rows[0][17].ToString();
            TextBox14.Text = ds.Tables[0].Rows[0][18].ToString();
            TextBox15.Text = ds.Tables[0].Rows[0][19].ToString();
			    DropDownList113.Text = ds.Tables[0].Rows[0][20].ToString();
            if (ds.Tables[0].Rows[0][4].ToString() == "CASH")
            {
                RadioButton1.Checked = true;
                RadioButton2.Checked = false;
                TextBox9.Text = "CASH";
                Label11.Text = "CASH";
            }
            else
            {
                RadioButton1.Checked = false;
                RadioButton2.Checked = true;
                TextBox9.Text =ds.Tables[0].Rows[0][10].ToString();
                Label11.Text = ds.Tables[0].Rows[0][4].ToString();

            }
        }
        else
        {
            Label25.Text = "Record Not Found";
        }
    }
    protected void Button20_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlCommand cmd = new SqlCommand("delete from newkishan where id='" + TextBox78.Text + "'", con1);
        int i = cmd.ExecuteNonQuery();

        con1.Close();



        if (i == 1)
        {
            Label1.Text = "Record Deleted Sucessfully";

        }
        else
        {
            Label1.Text = "Due to internal error";
        }
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        Label26.Text = "";
         SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select ivname,date,mobile,totalinvestamt,returnamt,paymode,modetype,recamount,balance,lastdate,brokername,btotal,bpaid,bbalance,bcomment,icomment,monthlypay from newinvester where invid='" + TextBox79.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {

            TextBox29.Text = ds.Tables[0].Rows[0][0].ToString();
            TextBox31.Text = ds.Tables[0].Rows[0][2].ToString();
            TextBox49.Text = ds.Tables[0].Rows[0][3].ToString();
            TextBox36.Text = ds.Tables[0].Rows[0][4].ToString();
            TextBox75.Text = ds.Tables[0].Rows[0][7].ToString();
            TextBox42.Text = ds.Tables[0].Rows[0][8].ToString();
           // TextBox43.Text = ds.Tables[0].Rows[0][9].ToString();
            DropDownList4.Text = ds.Tables[0].Rows[0][10].ToString();
            TextBox44.Text = ds.Tables[0].Rows[0][11].ToString();
            TextBox76.Text = ds.Tables[0].Rows[0][12].ToString();
            TextBox46.Text = ds.Tables[0].Rows[0][13].ToString();
            TextBox47.Text = ds.Tables[0].Rows[0][14].ToString();
            TextBox48.Text = ds.Tables[0].Rows[0][15].ToString();
			 TextBox482.Text = ds.Tables[0].Rows[0][16].ToString();
            string s4 = ds.Tables[0].Rows[0][1].ToString();
            DateTime r1 = Convert.ToDateTime(s4);
            int s8 = Convert.ToInt32(r1.Day.ToString());
            int m2 = Convert.ToInt32(r1.Month.ToString());
            if (m2 == 1 || m2 == 2 || m2 == 3 || m2 == 4 || m2 == 5 || m2 == 6 || m2 == 7 || m2 == 8 || m2 == 9)
            {
                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                {
                    string s2 = r1.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 1);
                    string yy = s2.Substring(4, 4);
                    string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                    TextBox30.Text = date1.ToString();

                }
                else
                {
                    string s2 = r1.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 2);
                    string yy = s2.Substring(5, 4);
                    string date1 = dd + "/" + "0" + mm + "/" + yy;
                    TextBox30.Text = date1.ToString();
                }

            }
            else
            {
                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                {
                    string s2 = r1.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 1);
                    string yy = s2.Substring(5, 4);
                    string date1 = "0" + dd + "/" + mm + "/" + yy;
                    TextBox30.Text = date1.ToString();

                }
                else
                {
                    string s2 = r1.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 2);
                    string yy = s2.Substring(6, 4);
                    string date1 = dd + "/" + mm + "/" + yy;
                    TextBox30.Text = date1.ToString();
                }
            }
            string s5 = ds.Tables[0].Rows[0][9].ToString();
            DateTime r2 = Convert.ToDateTime(s5);
            int s9 = Convert.ToInt32(r2.Day.ToString());
            int m3 = Convert.ToInt32(r2.Month.ToString());
            if (m3 == 1 || m3 == 2 || m3 == 3 || m3 == 4 || m3 == 5 || m3 == 6 || m3 == 7 || m3 == 8 || m3 == 9)
            {
                if (s9 == 1 || s9 == 2 || s9 == 3 || s9 == 4 || s9 == 5 || s9 == 6 || s9 == 7 || s9 == 8 || s9 == 9)
                {
                    string s2 = r2.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 1);
                    string yy = s2.Substring(4, 4);
                    string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                    TextBox43.Text = date1.ToString();

                }
                else
                {
                    string s2 = r2.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 2);
                    string yy = s2.Substring(5, 4);
                    string date1 = dd + "/" + "0" + mm + "/" + yy;
                    TextBox43.Text = date1.ToString();
                }

            }
            else
            {
                if (s9 == 1 || s9 == 2 || s9 == 3 || s9 == 4 || s9 == 5 || s9 == 6 || s9 == 7 || s9 == 8 || s9 == 9)
                {
                    string s2 = r2.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 1);
                    string yy = s2.Substring(5, 4);
                    string date1 = "0" + dd + "/" + mm + "/" + yy;
                    TextBox43.Text = date1.ToString();

                }
                else
                {
                    string s2 = r2.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 2);
                    string yy = s2.Substring(6, 4);
                    string date1 = dd + "/" + mm + "/" + yy;
                    TextBox43.Text = date1.ToString();
                }
            }
            if (ds.Tables[0].Rows[0][6].ToString() == "CASH")
            {
                RadioButton9.Checked = true;
                RadioButton10.Checked = false;
                TextBox37.Text = "CASH";
                Label15.Text = "CASH";
            }
            else
            {
                RadioButton9.Checked = false;
                RadioButton10.Checked = true;
                TextBox37.Text = ds.Tables[0].Rows[0][5].ToString();
                Label15.Text = ds.Tables[0].Rows[0][6].ToString();

            }
        }
        else
        {
            Label26.Text = "Record Not Found";
        }
    }
    protected void Button22_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlCommand cmd = new SqlCommand("delete from newinvester where invid='" + TextBox79.Text + "'", con1);
        int i = cmd.ExecuteNonQuery();

        con1.Close();



        if (i == 1)
        {
            Label1.Text = "Record Deleted Sucessfully";

        }
        else
        {
            Label1.Text = "Due to internal error";
        }
    }
}
