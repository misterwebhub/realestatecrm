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

public partial class invsterintrest_investerbondint : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fetchinv();
            bindl2();
            Panel4.Visible = false;
        }
    }
    public void fetchinv()
    {
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int rcid = 0;
            SqlCommand cmd = new SqlCommand("select max(id) from newintinvester", con1);
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
            Label17.Text = "Due to error";
        }
    }
    public void bindl2()
    {

        DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT name from intinvesterbrokarpage", con);
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
    protected void Button14_Click(object sender, EventArgs e)
    {
        try
        {
            
            Label16.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into intinvesterbrokarpage(name,aadhar,mobile)values('" + TextBox39.Text + "','" + TextBox40.Text + "','" + TextBox41.Text + "')", con1);
            int i = cmd.ExecuteNonQuery();

            con1.Close();


            if (i == 1)
            {
                Label16.Text = "Record added Sucessfully";
                bindl2();
                Panel4.Visible = false;
            }
            else
            {
                Label16.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label16.Text = "internal problem";
        }
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
            SqlCommand cmd = new SqlCommand("insert into newintinvester(invid,ivname,date,mobile,totalinvestamt,returnamt,paymode,modetype,recamount,balance,lastdate,brokername,btotal,bpaid,bbalance,bcomment,icomment,intrest)values('" + Label14.Text + "','" + TextBox29.Text + "','" + kdate1 + "','" + TextBox31.Text + "'," + TextBox49.Text + "," + TextBox36.Text + ",'" + TextBox37.Text + "','" + mode + "'," + TextBox75.Text + "," + TextBox42.Text + ",'" + ldate2 + "','" + DropDownList4.Text + "'," + TextBox44.Text + "," + TextBox76.Text + "," + TextBox46.Text + ",'" + TextBox47.Text + "','" + TextBox48.Text + "',"+TextBox77.Text+")", con1);
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
            Label17.Text = "internal problem" + t;
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
}