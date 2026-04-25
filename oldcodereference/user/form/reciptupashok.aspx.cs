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
public partial class kishan_Bin_map2_174mi_reciptupashok : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    string mob;
    static Double num = 0;
    public void bind()
    {
        Random r = new Random();
        int genRand = r.Next(1000, 9999);
        num = Convert.ToDouble(genRand);
        Label7.Text = num.ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label4.Text = Session["ID"].ToString();
            //Label4.Text = "amar";
            Label5.Visible = false;
            TextBox6.Visible = false;
            Button5.Visible = false;
            bind();
            Panel1.Visible = false;
        }

    }
    static Double amt, bal;
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    { //string companyName = "WJSTAR LAND DEVELOPERS PRIVATE LIMITED";
        Panel1.Visible = true;
    }
	string dateofcom="";
public void FUN()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select DATEOFCOM from wjstar1.customerreg1 where CUSTREGNO IN(select CUSTREGNO from wjstar1.recipt1 where RECIPT='" + TextBox1.Text + "')", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con1.Close();
        dateofcom = ds1.Tables[0].Rows[0][0].ToString();
        con1.Open();
    }
    public void print1()
    {
		FUN();
        Session["creg"] = TextBox3.Text;
        Session["ascname"] = TextBox2.Text;
        Session["recipt"] = TextBox1.Text;
        Session["asccode"] = TextBox4.Text;
        Session["date"] = TextBox19.Text;
        Session["dudate"] = TextBox20.Text;
        // Session["ndate"] = TextBox21.Text;
        Session["instno"] = TextBox7.Text;
        Session["endterm"] = TextBox8.Text;
        Session["ascaddr"] = TextBox9.Text;
        Session["planterm"] = TextBox11.Text;
        Session["mod"] = DropDownList1.Text;
        Session["amr"] = TextBox13.Text;
        Session["expr"] = TextBox14.Text;
        Session["subam"] = TextBox15.Text;
        Session["latecharge"] = TextBox16.Text;
        Session["assaddr"] = TextBox17.Text;
        Session["amwrd"] = TextBox18.Text;
        Session["ref"] = TextBox5.Text;
		 Session["book"] = dateofcom; 

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = false;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter cmd = new SqlDataAdapter("select * from wjstar1.recipt1 where RECIPT='" + TextBox1.Text + "'", con1);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = "";
                TextBox5.Text = ds.Tables[0].Rows[0][21].ToString();
                TextBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                TextBox2.Text = ds.Tables[0].Rows[0][2].ToString();
                TextBox4.Text = ds.Tables[0].Rows[0][4].ToString();
                TextBox19.Text = ds.Tables[0].Rows[0][5].ToString();
                TextBox20.Text = ds.Tables[0].Rows[0][6].ToString();
                // TextBox21.Text = ds.Tables[0].Rows[0][7].ToString();
                TextBox7.Text = ds.Tables[0].Rows[0][8].ToString();
                TextBox8.Text = ds.Tables[0].Rows[0][9].ToString();
                TextBox9.Text = ds.Tables[0].Rows[0][10].ToString();
                TextBox11.Text = ds.Tables[0].Rows[0][11].ToString();
                DropDownList1.Text = ds.Tables[0].Rows[0][12].ToString();
                TextBox13.Text = ds.Tables[0].Rows[0][13].ToString();
                amt = Convert.ToDouble(TextBox13.Text);
                TextBox21.Text = ds.Tables[0].Rows[0][13].ToString();
                TextBox14.Text = ds.Tables[0].Rows[0][14].ToString();
                TextBox15.Text = ds.Tables[0].Rows[0][15].ToString();
                bal = Convert.ToDouble(TextBox15.Text);
                TextBox16.Text = ds.Tables[0].Rows[0][16].ToString();
                TextBox17.Text = ds.Tables[0].Rows[0][17].ToString();
                TextBox18.Text = ds.Tables[0].Rows[0][18].ToString();
            }
            else
            {
                Label1.Text = "not find receipt";
            }

            con1.Close();

        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }

    }

    public static string convertnumtoword(int number)
    {
        if (number == 0)
            return "Zero";
        if (number < 0)
            return "MINUS" + convertnumtoword(Math.Abs(number));
        string word = "";
        if ((number / 1000000) > 0 || (number / 100000) > 0)
        {
            if ((number / 1000000) > 0)
            {
                word += convertnumtoword(number / 1000000) + " Lakh ";
                number %= 1000000;
            }
            if ((number / 100000) > 0)
            {
                word += convertnumtoword(number / 100000) + " Lakh ";
                number %= 100000;
            }
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
    protected void TextBox13_TextChanged(object sender, EventArgs e)
    {
        int a = 0, b = 0, c = 0;
        Double amt1, bal1, t13;

        TextBox20.Text = TextBox20.Text;
        t13 = Convert.ToDouble(TextBox13.Text);

        amt1 = amt - t13;
        bal1 = bal + amt1;

        TextBox15.Text = bal1.ToString();

        string word = convertnumtoword(Convert.ToInt32(TextBox13.Text)) + " Rupees Only";
        TextBox18.Text = word;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Label6.Text == "Varified")
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int tamt1, tamt;
            tamt1 = Convert.ToInt32(TextBox13.Text);
            string s2 = TextBox19.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;


            SqlCommand cmd = new SqlCommand("update wjstar1.recipt1 set ASCNAME='" + TextBox2.Text + "',ASCCODE='" + TextBox4.Text + "',DATE='" + TextBox19.Text + "',DUDATE='" + TextBox20.Text + "',NEXTDATE='00',INSTNO='" + TextBox7.Text + "',ENDOFTERM='" + TextBox8.Text + "',ASCADDRESS='" + TextBox9.Text + "',PLANTERM='" + TextBox11.Text + "',MOD='" + DropDownList1.Text + "',AMOUNTR=" + TextBox13.Text + ",EXPLANDVALUE=" + TextBox14.Text + ",SUBAMOUNT=" + TextBox15.Text + ",ASSADDRESS='" + TextBox17.Text + "',AMOUNTWORD='" + TextBox18.Text + "',checkby='" + TextBox5.Text + "',DATE1='" + date1 + "',usertype='Ashok8396' where RECIPT='" + TextBox1.Text + "'", con1);
            int i = cmd.ExecuteNonQuery();
            con1.Close();
            if (i != 0)
            {
                Label1.Text = "Record updated successfully";
                print1();
                Response.Redirect("~/home/print.aspx");
            }
            else
            {
                Label1.Text = "Due to internal error";
            }
        }
        else
        {
            Label6.Text = "Please enter correct OTP";
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Label5.Visible = true;
        TextBox6.Visible = true;
        Button5.Visible = true;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox6.Text == "")
        {
            Label6.Text = "*Please enter OTP";
        }
        else
        {
            if (TextBox6.Text == num.ToString())
            {

                Label6.Text = "Varified";
            }
            else
            {
                Label6.Text = "*Please enter correct OTP";
            }
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            if (Label6.Text == "Varified")
            {
                string ddd = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                SqlConnection con1 = new SqlConnection(s);
                // SqlCommand cmd1 = new SqlCommand("insert into delrecipt(CUSTREGNO,NAME,DATE,AMOUNT,RECIPT,ARAZINO,PLOTNO,PLOTSIZE,CHECKBY,USERBY,PAIDAMOUNT,DELETEDATE)values('" + ds.Tables[0].Rows[0][0].ToString() + "','" + ds.Tables[0].Rows[0][1].ToString() + "','" + ds.Tables[0].Rows[0][3].ToString() + "'," + ds.Tables[0].Rows[0][4].ToString() + "," + ds.Tables[0].Rows[0][2].ToString() + ",'" + ds.Tables[0].Rows[0][7].ToString() + "','" + ds.Tables[0].Rows[0][8].ToString() + "','" + ds.Tables[0].Rows[0][9].ToString() + "','" + ds.Tables[0].Rows[0][5].ToString() + "','heedrealestate'," + TextBox21.Text + ",'" + ddd + "')", con1);
                SqlCommand cmd = new SqlCommand("update  wjstar1.recipt1 set usertype='Ashok8396', userstatus='Inactive',paidamount=" + TextBox21.Text + ",deldate='" + ddd + "' where RECIPT='" + TextBox1.Text + "' ", con1);
                con1.Open();
                int i = cmd.ExecuteNonQuery();
                con1.Close();

                if (i == 1)
                {

                    Label1.Text = "Installment deleted successfully";
                }
                else
                {
                    Label1.Text = "Due to internal error";
                }
            }
            else
            {
                Label6.Text = "Please Enter Correct OTP";
            }

        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
}