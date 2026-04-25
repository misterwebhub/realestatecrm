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

public partial class checkentry : System.Web.UI.Page
{
    public void fun1()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select date,name,amount,chequeno from chequetrans where status='UNPAID'  AND arazi='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
    }
    public void fun2()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select date,name,amount,chequeno from chequetrans where status='PAID'  AND arazi='" + DropDownList7.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bid();
            Panel1.Visible = false;
            Panel4.Visible = false;
            GridView1.Visible = false;
            Panel6.Visible = false;
            GridView2.Visible = false;

        }
    }
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public void bid()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from chequekishan", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList7.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList9.Items.Add(ds.Tables[0].Rows[i][0].ToString());

        }
        con.Close();



    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT kname from chequekishan where arazino='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList2.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());


        }
        con.Close();
		GridView1.DataSource = null;
        GridView1.DataBind();
		fun1();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox6.Text = "";
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT location from chequekishan where arazino='" + DropDownList1.Text + "' AND kname='" + DropDownList2.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TextBox6.Text = ds.Tables[0].Rows[i][0].ToString();


        }
        con.Close();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string st = "UNPAID";
               
                SqlCommand cmd2 = new SqlCommand("insert into chequetrans(chequetype,arazi,kname,loc,date,name,amount,chequeno,status,type,moddate)values('" + DropDownList4.Text + "','" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + TextBox6.Text + "','" + date1 + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "','"+st+ "','CHEQUE',NULL)", con);
                int i = cmd2.ExecuteNonQuery();
                con.Close();
                if (i == 0)
                {
                    Label5.Text = "internal problam";

                }
                else
                {
                    Label5.Text = "successfully added";

                    fun1();
                    GridView1.Visible = true;
                }
            
           
        }
        catch (Exception t)
        {
            Label5.Text = "" + t;
        }

    }
    
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        //fun1();
        Panel1.Visible = true;
        Panel6.Visible = false;
        Panel4.Visible = false;
        GridView1.Visible = true;
        GridView2.Visible = false;
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        //fun2();
        Panel4.Visible = true;
        Panel1.Visible = false;
        GridView1.Visible = true;
        GridView2.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Panel6.Visible = true;
        Panel4.Visible = false;
        Panel1.Visible = false;
        GridView1.Visible = false;
        GridView2.Visible = true;

        Panel5.Visible = false;
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList6.Text == "CASH")
        {
            Panel5.Visible = false;

        }
        if (DropDownList6.Text == "CHEQUE")
        {
            Panel5.Visible = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            string s2 = TextBox7.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string st = "PAID";
            string cheq = "";
            if (DropDownList6.Text == "CASH")
            {
                cheq = "-";

            }
            if (DropDownList6.Text == "CHEQUE")
            {
                cheq = TextBox10.Text;
            }
            SqlCommand cmd2 = new SqlCommand("insert into chequetrans(chequetype,arazi,kname,loc,date,name,amount,chequeno,status,type,moddate)values('PMO','" + DropDownList7.Text + "','" + DropDownList8.Text + "','" + TextBox5.Text + "','" + date1 + "','" + TextBox8.Text + "'," + TextBox9.Text + ",'" + cheq + "','" + st + "','"+DropDownList6.Text+"','"+date1+"')", con);
            int i = cmd2.ExecuteNonQuery();
            con.Close();
            if (i == 0)
            {
                Label6.Text = "internal problam";

            }
            else
            {
                Label6.Text = "successfully added";

                fun2();
                GridView1.Visible = true;
            }


        }
        catch (Exception t)
        {
            Label5.Text = "" + t;
        }
    }
    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox5.Text = "";
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT location from chequekishan where arazino='" + DropDownList7.Text + "' AND kname='" + DropDownList8.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TextBox5.Text = ds.Tables[0].Rows[i][0].ToString();


        }
        con.Close();
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList8.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT kname from chequekishan where arazino='" + DropDownList7.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList8.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList8.Items.Add(ds.Tables[0].Rows[i][0].ToString());


        }
        con.Close();
		GridView1.DataSource = null;
        GridView1.DataBind();
		fun2();
    }
    public void bid2()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select item,amount from kishanexpense where arazi='" + DropDownList9.Text + "'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        GridView3.DataSource = ds1;
        GridView3.DataBind();
    }
    protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList10.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT kname from chequekishan where arazino='" + DropDownList9.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList10.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList10.Items.Add(ds.Tables[0].Rows[i][0].ToString());


        }
        con.Close();
        bid2();
    }
    protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList9.Text == "---Select----" || DropDownList10.Text == "---Select----")
        {
            Label7.Text = "Please Select Any Arazi No.";
        }
       
    }
    protected void DropDownList11_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList11.Text == "PAID")
        {
			 Label11.Text ="";
			 Label12.Text ="";
			 Label13.Text ="";
            Label9.Text ="";
            Label8.Text = "";
			 Label15.Text ="";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select date,name,amount,chequeno,type,chequetype,moddate from chequetrans where arazi='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "' AND status='" + DropDownList11.Text + "' ORDER BY date ASC", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select DISTINCT loc from chequetrans where arazi='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "' AND status='" + DropDownList11.Text + "' ", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds1.Tables[0].Rows[0][0].ToString();
                Label9.Text = DropDownList10.Text;
                Label8.Text = DropDownList9.Text;
            }
			Double total=0,paid=0,bal=0;
			 con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(amount) from chequetrans where arazi='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "' AND status='" + DropDownList11.Text + "'", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
			if (ds2.Tables[0].Rows.Count > 0)
            {
               paid=Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
				Label12.Text=paid.ToString();
            }
            con.Close();
			 con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select amount from chequekishan where arazino='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "'", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
			if (ds3.Tables[0].Rows.Count > 0)
            {
               total=Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
				Label11.Text=total.ToString();
            }
            con.Close();
			bal=total-paid;
			Label13.Text=bal.ToString();
            GridView2.Visible = true;

            GridView2.DataSource = ds;
            GridView2.DataBind();
            con.Close();
        }
        if (DropDownList11.Text == "UNPAID (Cheque)")
        {
				 Label15.Text ="";
			 Label11.Text ="";
			 Label12.Text ="";
			 Label13.Text ="";
            Label9.Text = "";
            Label8.Text = "";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select date,name,amount,chequeno,type,chequetype,moddate from chequetrans where arazi='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "' AND status='UNPAID' ORDER BY date ASC", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select DISTINCT loc from chequetrans where arazi='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "' AND status='UNPAID'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds1.Tables[0].Rows[0][0].ToString();
                Label9.Text = DropDownList10.Text;
                Label8.Text = DropDownList9.Text;
            }
			con.Open();
			Double amt=0;
            SqlDataAdapter da9 = new SqlDataAdapter("select sum(amount) from chequetrans where arazi='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "' AND status='UNPAID'", con);
            DataSet ds9 = new DataSet();
            da9.Fill(ds9);
            con.Close();
			if (ds9.Tables[0].Rows.Count > 0)
            {
                amt = Convert.ToDouble(ds9.Tables[0].Rows[0][0].ToString());
                 Label15.Text = amt.ToString();
            }
            GridView2.Visible = true;

            GridView2.DataSource = ds;
            GridView2.DataBind();
            con.Close();
        }
        if (DropDownList11.Text == "---Select---")
        {
            Label7.Text = "Please Select Type";
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("cheque2");



            if (lblname.Text == "MENTION")
            {

                lblname.Style.Add("color", "red");

            }
          
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            GridView3.Visible = false;
        }
        else
        {
            GridView3.Visible =true;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            string s2 = TextBox12.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            SqlCommand cmd = new SqlCommand("update chequetrans set status='PAID' , moddate='"+date1+"' where chequeno='"+TextBox11.Text+"'",con);
            int t = cmd.ExecuteNonQuery();
            con.Close();

            Label15.Text = "";
            Label11.Text = "";
            Label12.Text = "";
            Label13.Text = "";
            Label9.Text = "";
            Label8.Text = "";
           // SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select date,name,amount,chequeno,type,chequetype,moddate from chequetrans where arazi='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "' AND status='UNPAID' ORDER BY date ASC", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select DISTINCT loc from chequetrans where arazi='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "' AND status='UNPAID'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Label10.Text = ds1.Tables[0].Rows[0][0].ToString();
                Label9.Text = DropDownList10.Text;
                Label8.Text = DropDownList9.Text;
            }
            con.Open();
            Double amt = 0;
            SqlDataAdapter da9 = new SqlDataAdapter("select sum(amount) from chequetrans where arazi='" + DropDownList9.Text + "' AND kname='" + DropDownList10.Text + "' AND status='UNPAID'", con);
            DataSet ds9 = new DataSet();
            da9.Fill(ds9);
            con.Close();
            if (ds9.Tables[0].Rows.Count > 0)
            {
                amt = Convert.ToDouble(ds9.Tables[0].Rows[0][0].ToString());
                Label15.Text = amt.ToString();
            }
            GridView2.Visible = true;

            GridView2.DataSource = ds;
            GridView2.DataBind();
            con.Close();

            if (t != 0)
            {
                Label16.Text = "Record Updated Sucessfully";
            }
            else
            {
                Label16.Text = "internal problem";
            }
        }
        catch(Exception r)
        {
            Label16.Text = "internal problem with server"+r;
        }
    }
}