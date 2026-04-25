using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Drawing;

public partial class partnerpaid : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind5();
        }
    }
    public void bind5()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT username FROM logininfo", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
           
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    if (ds1.Tables[0].Rows[j][0].ToString() == "IMRAN7905")
                    {
                        continue;
                    }
                    else
                    {
                        DropDownList2.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
                    }
                }
           


        }
        catch (Exception t)
        {
            Label4.Text = "internal problem";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.Text == "----SELECT----")
            {
                Label4.Text = "please select type";
            }
           
            string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox2.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string date2 = mm1 + "/" + dd1 + "/" + yy1;


           SqlConnection con1 = new SqlConnection(s);
           if (DropDownList1.Text == "FROM JUNE-DEC (2020)")
           {
			   TextBox3.Text="";
			   TextBox4.Text="";
			   TextBox7.Text="";
               if (DropDownList2.Text == "heedrealestate")
               {
                   con1.Open();
                   SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020' AND '12/31/2020' AND APPNO NOT IN ('519') AND CHECKBY IN ('office')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   //SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   DataSet ds1 = new DataSet();
                   cmd1.Fill(ds1);
                   Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                   con1.Close();
                   Double d2 = 0;
                   Double d4 = d - d2;
                   Label2.Text = d4.ToString();
                   String d8 = DropDownList1.Text;
                   bind(d8);
               }
               if (DropDownList2.Text == "RAMAIPUROFFICE")
               {
                   con1.Open();
                   SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020' AND '12/31/2020' AND APPNO NOT IN ('519') AND CHECKBY IN ('RAMAIPUROFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   //SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   DataSet ds1 = new DataSet();
                   cmd1.Fill(ds1);
                   Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                   con1.Close();
                   Double d2 = 0;
                   Double d4 = d - d2;
                   Label2.Text = d4.ToString();
                   String d8 = DropDownList1.Text;
                   bind(d8);
               }
               if (DropDownList2.Text == "Ashok8396")
               {
                   con1.Open();
                   SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020' AND '12/31/2020' AND APPNO NOT IN ('519') AND CHECKBY IN ('TAUDHAKPUR OFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   //SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   DataSet ds1 = new DataSet();
                   cmd1.Fill(ds1);
                   Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                   con1.Close();
                   Double d2 = 0;
                   Double d4 = d - d2;
                   Label2.Text = d4.ToString();
                   String d8 = DropDownList1.Text;
                   bind(d8);
               }
               if (DropDownList2.Text == "MACHHARIYAOFFICE")
               {
                   con1.Open();
                   SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 BETWEEN '6/1/2020' AND '12/31/2020' AND APPNO NOT IN ('519') AND CHECKBY IN ('MACHHARIYAOFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   //SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='6/1/2020 12:00:00 AM' AND APPNO NOT IN ('519') AND  CHECKBY='office') AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   DataSet ds1 = new DataSet();
                   cmd1.Fill(ds1);
                   Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                   con1.Close();
                   Double d2 = 0;
                   Double d4 = d - d2;
                   Label2.Text = d4.ToString();
                   String d8 = DropDownList1.Text;
                   bind(d8);
               }
               
           
                }
           if (DropDownList1.Text == "FROM JANUARY (2021)")
           {
			    TextBox3.Text="";
			   TextBox4.Text="";
			   TextBox7.Text="";
               if (DropDownList2.Text == "heedrealestate")
               {
                   con1.Open();
                   SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('office')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   DataSet ds1 = new DataSet();
                   cmd1.Fill(ds1);
                   Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                   con1.Close();

                   Double d2 = 0;
                   Double d4 = d - d2-1275000;
                   Label2.Text = d4.ToString();
                   // con1.Close();
                   String d8 = DropDownList1.Text;
                   bind(d8);
               }
               if (DropDownList2.Text == "RAMAIPUROFFICE")
               {
                   con1.Open();
                   SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('RAMAIPUROFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   DataSet ds1 = new DataSet();
                   cmd1.Fill(ds1);
                   Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                   con1.Close();

                   Double d2 = 0;
                   Double d4 = d - d2;
                   Label2.Text = d4.ToString();
                   // con1.Close();
                   String d8 = DropDownList1.Text;
                   bind(d8);
               }
               if (DropDownList2.Text == "Ashok8396")
               {
                   con1.Open();
                   SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('TAUDHAKPUR OFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   DataSet ds1 = new DataSet();
                   cmd1.Fill(ds1);
                   Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                   con1.Close();

                   Double d2 = 0;
                   Double d4 = d - d2;
                   Label2.Text = d4.ToString();
                   // con1.Close();
                   String d8 = DropDownList1.Text;
                   bind(d8);
               }
               if (DropDownList2.Text == "MACHHARIYAOFFICE")
               {
                   con1.Open();
                   SqlDataAdapter cmd1 = new SqlDataAdapter("select SUM(AMOUNTR) AS 'AMOUNT' from wjstar1.recipt1 where CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3>='01/01/2021'  AND APPNO NOT IN ('519')  AND CHECKBY IN ('MACHHARIYAOFFICE')) AND userstatus='Active' AND DATE1 between '" + date1 + "' AND '" + date2 + "'", con1);
                   DataSet ds1 = new DataSet();
                   cmd1.Fill(ds1);
                   Double d = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                   con1.Close();

                   Double d2 = 0;
                   Double d4 = d - d2;
                   Label2.Text = d4.ToString();
                   // con1.Close();
                   String d8 = DropDownList1.Text;
                   bind(d8);
               }
              
           }



        }
        catch (Exception t)
        {
            Label4.Text = "internal problem"+t;
        }
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        String d = Label2.Text;
        Double f = Convert.ToDouble(d);
        Double a = Convert.ToDouble(TextBox3.Text);
        Double t = (f * a) / 100;
        TextBox4.Text = t.ToString();
        try
        {

            

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            string s3 = TextBox1.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string datefrom = mm1 + "/" + dd1 + "/" + yy1;
            string s4 = TextBox2.Text;
            string dd2 = s4.Substring(0, 2);
            string mm2 = s4.Substring(3, 2);
            string yy2 = s4.Substring(6, 4);
            string dateto = mm2 + "/" + dd2 + "/" + yy2;
            SqlDataAdapter da = new SqlDataAdapter("select sum(amount) from wjstar1.partnerpaid where datefrom='" + datefrom + "' and dateto='" + dateto + "' AND type='" + DropDownList1.Text + "' AND heeduser='"+DropDownList2.Text+"'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            string amt = ds.Tables[0].Rows[0][0].ToString();
            Double amtf = Convert.ToDouble(amt);
            Double balamt = t - amtf;
            Label5.Text = balamt.ToString(); 
        }
        catch (Exception p)
        {
            Label4.Text = "internal problem";
        }

       
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            String d = TextBox4.Text;
            Double f = Convert.ToDouble(d);
            Double t = (f / 10);
            TextBox7.Text = t.ToString();

        }
    }
    public void bind( String j)
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        string s3 = TextBox1.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string datefrom = mm1 + "/" + dd1 + "/" + yy1;
        string s4 = TextBox2.Text;
        string dd2 = s4.Substring(0, 2);
        string mm2 = s4.Substring(3, 2);
        string yy2 = s4.Substring(6, 4);
        string dateto = mm2 + "/" + dd2 + "/" + yy2;
        SqlDataAdapter da = new SqlDataAdapter("select name,date,amount from wjstar1.partnerpaid where datefrom='" + datefrom + "' and dateto='" + dateto + "' AND type='" + j + "' AND heeduser='" + DropDownList2.Text + "'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        String d =Label5.Text;
        Double f = Convert.ToDouble(d);
        Double a = Convert.ToDouble(TextBox7.Text);
        Double t = f - a;
        Label5.Text = t.ToString();
        SqlConnection con = new SqlConnection(s);

        con.Open();
        string s2 = TextBox6.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        string s3 = TextBox1.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string datefrom = mm1 + "/" + dd1 + "/" + yy1;
        string s4 = TextBox2.Text;
        string dd2 = s4.Substring(0, 2);
        string mm2 = s4.Substring(3, 2);
        string yy2 = s4.Substring(6, 4);
        string dateto = mm2 + "/" + dd2 + "/" + yy2;
       
Double rt = Convert.ToDouble(TextBox4.Text);
        if (CheckBox1.Checked)
        {
            SqlCommand cmd = new SqlCommand("insert into wjstar1.partnerpaid(name,date,amount,datefrom,dateto,tamount,type,heeduser)values('" + TextBox5.Text + "','" + date1 + "'," + TextBox7.Text + ",'" + datefrom + "','" + dateto + "'," + rt + ",'" + DropDownList1.Text + "','"+DropDownList2.Text+"')", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                Label3.Text = "Record Added Successfully";
                String h = DropDownList1.Text;
                bind(h);
            }
            else
            {
                Label3.Text = "due to internal problem";
            }
        }
        else
        {
            Label3.Text = "Please check check box";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox5.Text = "";
        TextBox7.Text = "";
        CheckBox1.Checked = false;
        Label3.Text = " ";

    }
}