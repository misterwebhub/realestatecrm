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


public partial class pradhan_addentry : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

          //  Label2.Visible = false;
           // DropDownList3.Visible = false;
            Label4.Visible = false;
            TextBox2.Visible = false;
            Label5.Visible = false;
            DropDownList6.Visible = false;
            bindl();
            bind2();
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            Label2.Visible = true;
            Label2.Text = "BLOCK";
            DropDownList3.Visible = true;
        
       
    }
    public void bindl()
    {
        DropDownList2.Items.Clear();

        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList2.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();

    }
    public void bind2()
    {
        DropDownList1.Items.Clear();
        DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT name from addname", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("---SELECT----");
        DropDownList4.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList4.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();

    }
    public void bind3()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from addarazidemo where name='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    public void bind6()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from addaraziplot where name='" + DropDownList4.Text + "' AND arazi='" + DropDownList5.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView2.DataSource = ds;
        GridView2.DataBind();

    }
    public void bind4()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazi from addarazidemo where name='" + DropDownList4.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
       
        con.Close();
        DropDownList5.Items.Clear();
        DropDownList5.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList5.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
       
        if (TextBox1.Text != "")
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT name from addname where name='" + TextBox1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into addname(name)values('" + TextBox1.Text + "')", con);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                        Label1.Text = "Record Added";
                        bind2();
                    }
                    else
                    {
                        Label2.Text = "Error";
                    }
                }
                else
                {
                    Label2.Text = "Name Already Exist";
                }
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into addname(name)values('" + TextBox1.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    Label1.Text = "Record Added";
                    bind2();
                }
            }
           
        }
        else
        {
            Label1.Text = "Please Fill Name";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        int i = 0;
        
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into addarazidemo(name,arazi,block)values('" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + DropDownList3.Text + "')", con);
         i = cmd.ExecuteNonQuery();
            con.Close();
   
       
        
        if (i != 0)
        {
            
            bind3();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind3();
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind4();
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
       
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT block from addarazidemo where name='" + DropDownList4.Text + "' AND arazi='"+DropDownList5.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "YES")
                {
                    TextBox2.Visible = true;
                    Label5.Visible = true;
                    Label4.Visible = true;
                    Label4.Text = "Block";
                    Label5.Text = "PLOT NO";
                    DropDownList6.Visible = true;
                }
                else
                {
                    TextBox2.Visible = false;
                    Label5.Visible = false;
                    Label4.Visible = false;
                    //  Label4.Text = "Block";
                    DropDownList6.Visible = false;
                }


                bind6();
            }
            else
            {
                TextBox2.Visible = false;
                Label5.Visible = false;
                Label4.Visible = false;
                //  Label4.Text = "Block";
                DropDownList6.Visible = false;
            }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        int i = 0;
       
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into addaraziplot(name,arazi,block,plotno)values('" + DropDownList4.Text + "','" + DropDownList5.Text + "','" + DropDownList6.Text + "','" + TextBox2.Text + "')", con);
            i = cmd.ExecuteNonQuery();
            con.Close();
       
       
        if (i != 0)
        {

            bind6();
        }
    }
}