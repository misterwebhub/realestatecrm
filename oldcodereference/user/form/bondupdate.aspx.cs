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

public partial class user_form_bondupdate : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    static Double num = 0;
    public void bind()
    {
        Random r = new Random();
        int genRand = r.Next(1000, 9999);
        num = Convert.ToDouble(genRand);
        Label14.Text = num.ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label13.Text = Session["ID"].ToString();
            bindl();
            bind();

        }
    }

    public void bindl()
    {
        DropDownList3.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino,loc from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select DISTINCT name from brokarpage", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);

        con.Close();
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {

            DropDownList4.Items.Add(ds1.Tables[0].Rows[i][0].ToString());

        }
    }




    public void printreg()
    {
        Session["creg"] = TextBox21.Text;
        Session["dateofcom"] = TextBox1.Text;
        Session["plan"] = DropDownList2.Text;
        Session["mod"] = DropDownList1.Text;
        Session["consamt"] = TextBox4.Text;
        Session["instpay"] = TextBox5.Text;
        Session["subduedate"] = TextBox6.Text;
        Session["exppay"] = TextBox7.Text;
        Session["dateoflast"] = TextBox8.Text;
        Session["expirydate"] = TextBox9.Text;
        Session["agency"] = TextBox10.Text;
        Session["namedbad"] = TextBox11.Text;
        Session["appno"] = DropDownList3.Text;

        Session["plotsize"] = TextBox20.Text + "/" + TextBox13.Text;
        Session["nominee"] = TextBox14.Text;
        Session["reciptno"] = TextBox16.Text;
        Session["amountword"] = TextBox17.Text;
        Session["name2nominee"] = TextBox18.Text;
        Session["espr"] = TextBox15.Text;
        Session["idcard"] = TextBox2.Text;

    }





    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select  * from wjstar1.customerreg1 where CUSTREGNO='" + TextBox21.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label2.Text = " ";

            
            TextBox1.Text = ds.Tables[0].Rows[0][2].ToString();
            DropDownList2.Text = ds.Tables[0].Rows[0][3].ToString();
            DropDownList1.Items.Add(ds.Tables[0].Rows[0][4].ToString());
            TextBox4.Text = ds.Tables[0].Rows[0][5].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0][6].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0][7].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0][8].ToString();
            TextBox8.Text = ds.Tables[0].Rows[0][9].ToString();
            TextBox9.Text = ds.Tables[0].Rows[0][10].ToString();
            TextBox10.Text = ds.Tables[0].Rows[0][11].ToString();
            TextBox11.Text = ds.Tables[0].Rows[0][12].ToString();
            DropDownList3.Text = ds.Tables[0].Rows[0][13].ToString();
            TextBox13.Text = ds.Tables[0].Rows[0][14].ToString();
            TextBox14.Text = ds.Tables[0].Rows[0][15].ToString();
            TextBox16.Text = ds.Tables[0].Rows[0][16].ToString();
            TextBox17.Text = ds.Tables[0].Rows[0][17].ToString();
            TextBox15.Text = ds.Tables[0].Rows[0][18].ToString();
            DropDownList4.Text = ds.Tables[0].Rows[0][19].ToString();
            TextBox20.Text = ds.Tables[0].Rows[0][20].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0][21].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0][22].ToString();
            TextBox18.Text = ds.Tables[0].Rows[0][12].ToString();
            TextBox22.Text = ds.Tables[0].Rows[0][25].ToString();

            TextBox18.ReadOnly = false;
            TextBox15.ReadOnly = false;
            TextBox16.ReadOnly = false;

        }
        else
        {
            Label2.Text = "Registration Number Not Found";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            if (Label6.Text == "Varified")
            {
               string s1 = TextBox20.Text;
string dateString = TextBox1.Text;
                 string format = "dd/mm/yyyy";
                 DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
                 string ddd = dateTime.ToString("mm/dd/yyyy");
     
               
                SqlConnection con1 = new SqlConnection(s);
                con1.Open();
                SqlCommand cmd = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESs='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "' where CUSTREGNO='" + TextBox21.Text + "' ", con1);
                int i = cmd.ExecuteNonQuery();
                con1.Close();


                if (i != 0)
                {

                    Label2.Text = "REGISTRATION UPDATED SUCESSFULLY";
                    printreg();
                    Response.Redirect("~/home/printreg.aspx");
                }
                else
                {
                    Label2.Text = "Due to internal error";
                }
            }
            else
            {
                Label6.Text = "Please enter correct OTP";
            }

        }
        catch (Exception t)
        {
            Label2.Text = "internal problem"+t;
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox23.Text == "")
        {
            Label6.Text = "*Please enter OTP";
        }
        else
        {
            if (TextBox23.Text == num.ToString())
            {

                Label6.Text = "Varified";
            }
            else
            {
                Label6.Text = "*Please enter correct OTP";
            }
        }
    }
}