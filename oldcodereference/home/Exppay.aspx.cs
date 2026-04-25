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

public partial class arazi3435_menu1 : System.Web.UI.Page
{
    string s1 = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    string mob;
    public static string inst;
    public static string arazi = "";
    public static int amt, balamt, BL;
    public static Double instrecamt, dprecamt, total, fixedinst, instcutamt, dpcutamt;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack == true)
        {
            Session["ID"] = "heedrealestate";
            //Label4.Text =Request.QueryString["val1"].ToString();
            if (Session["ID"] != null)
            {
                fun();
                
            }
            else
            {
                Response.Redirect("~/home/usercredential/credential.aspx");
            }
            // Label4.Text = Session["ID"].ToString();
            // Label4.Text = "heedrealestate";
           
            
          

        }

    }
    
   
   
    public override void VerifyRenderingInServerForm(Control control)
    {

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



    public void fun()
    {
        DateTime dateValue = DateTime.Now;
string monthStringPadded = dateValue.ToString("MM");
int m = Convert.ToInt32(monthStringPadded);
int year = dateValue.Year;
        SqlConnection con1 = new SqlConnection(s1);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("select id,date,name,mode1,amount,reason from extraexp where  month(date)=" + m + " AND year(date)=" + year + " ORDER by date DESC", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount) from extraexp where month(date)=" + m + " AND year(date)=" + year + " ", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con1.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Double amt = 0;
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                amt=Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                amt =0;
            }
            Label3.Text = amt.ToString();
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

    }






    protected void Button1_Click(object sender, EventArgs e)
    {

        SqlConnection con1 = new SqlConnection(s1);
       
        con1.Open();
      string s2 = TextBox11.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
		string date1 = dd + "/" + mm + "/" + yy;
        string date2 = mm + "/" + dd + "/" + yy;
        string entrytime1 = DateTime.Now.ToString("h:mm:ss tt");
        SqlCommand cmd = new SqlCommand("insert into extraexp(date,name,mode1,amount,reason)values('"+date2+"','"+TextBox1.Text+"','"+DropDownList1.Text+"',"+TextBox2.Text+",'"+TextBox3.Text+"')", con1);
       
       int i = cmd.ExecuteNonQuery();
        con1.Close();
        fun();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s1);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from extraexp where ID="+TextBox4.Text+"",con);
        cmd.ExecuteNonQuery();
        con.Close();
        fun();
    }
}