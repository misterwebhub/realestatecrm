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

public partial class _30neeghanew_calc : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindl();
            add();
        }
    }
    public void add()
    {
        TextBox3.Text = "0";
        TextBox4.Text = "0";
        TextBox5.Text = "0";
        TextBox6.Text = "0";
        TextBox7.Text = "0";
        TextBox8.Text = "0";
        TextBox9.Text = "0";
        TextBox10.Text = "0";
        TextBox11.Text = "0";
        TextBox12.Text = "0";
        TextBox17.Text = "0";
        TextBox18.Text = "0";
        TextBox14.Text = "0";
        TextBox15.Text = "0";
        TextBox16.Text = "0";
        TextBox19.Text = "0";
        TextBox20.Text = "0";
        TextBox21.Text = "0";
        TextBox22.Text = "0";
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
      
        DropDownList1.Items.Add("----SELECT----");
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
           
        }
        
        con.Close();
    }
    protected void TextBox11_TextChanged(object sender, EventArgs e)
    {
        Double t11=0,t12=0;
        t11 = Convert.ToDouble(TextBox11.Text);
        t12 = t11 * 2;
        TextBox12.Text = t12.ToString();
        cal();
    }
    public void cal()
    {
        Double t11 = 0, t12 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0, t10 = 0, t14 = 0, t17 = 0, t19 = 0, t20 = 0, total = 0, rate = 0, profit = 0, newtotal = 0, per10 = 0, old = 0, newamt = 0, prof = 0, prfgz = 0; 
        t3 = Convert.ToDouble(TextBox3.Text);
        t4 = Convert.ToDouble(TextBox4.Text);
        t5 = Convert.ToDouble(TextBox5.Text);
        t6 = Convert.ToDouble(TextBox6.Text);
        t7 = Convert.ToDouble(TextBox7.Text);
        t8 = Convert.ToDouble(TextBox8.Text);
        t9 = Convert.ToDouble(TextBox9.Text);
        t10 = Convert.ToDouble(TextBox10.Text);
        t11 = Convert.ToDouble(TextBox11.Text);
        t12 = Convert.ToDouble(TextBox12.Text);
        t14 = ret();
        t17 = Convert.ToDouble(TextBox17.Text);
        t19 = Convert.ToDouble(TextBox19.Text);
        t20 = Convert.ToDouble(TextBox20.Text);
        total = t3 + t4 + t5 + t6 + t7 + t8 + t9 + t10 + t12 + t14;
        TextBox15.Text = (total - t14).ToString();
        TextBox16.Text = total.ToString();
        if (t17 != 0)
        {
            rate = total / t17;
        }
        else
        {
            rate = 0;
        }
        TextBox18.Text = rate.ToString();
        old = Convert.ToDouble(TextBox16.Text);
        newamt = Convert.ToDouble(TextBox20.Text);
        prof = newamt - old;
        prfgz = prof / t17;
        TextBox21.Text = prof.ToString();
        TextBox22.Text = prfgz.ToString();

    }
    public Double ret()
    {
        Double r = 0, gz = 0, total = 0 ;
        r=Convert.ToDouble(TextBox19.Text);
        gz = Convert.ToDouble(TextBox17.Text);
        total = (r * gz)*0.10;
        TextBox14.Text = total.ToString();
        TextBox20.Text = (r*gz).ToString();
        
        return total;
       
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        cal();

    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        cal();
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        cal();
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        cal();
    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {
        cal();
    }
    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {
        cal();
    }
    protected void TextBox9_TextChanged(object sender, EventArgs e)
    {
        cal();
    }
    protected void TextBox10_TextChanged(object sender, EventArgs e)
    {
        cal();
    }

    protected void TextBox14_TextChanged(object sender, EventArgs e)
    {
        cal();
    }
    protected void TextBox17_TextChanged(object sender, EventArgs e)
    {
        cal();
    }
    protected void TextBox19_TextChanged(object sender, EventArgs e)
    {
        cal();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        add();
    }
}