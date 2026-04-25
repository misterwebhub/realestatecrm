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
using System.Drawing;

public partial class broker : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
//String y=Session["sp"].ToString();

            find();
Label15.Text="";
        }
    }
    public void find()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT name from brokarpage", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

               // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
														 con1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT APPNO FROM wjstar1.customerreg1", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
               // DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                DropDownList2.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
            }
con1.Close();
        }
        catch (Exception t)
        {
            Label5.Text = "internal problem";
        }
    }
    double total;
    double ST;
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
Label15.Text="";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT CUSTREGNO AS 'REGNO.',LEFT(NAMEDOBADDRESS,20) as 'NAME',APPNO AS 'ARAZI NO',CONSAMOUNT AS 'AMOUNT',INSTSUBPAY AS 'INSTALLMENT',PLOTSIZE AS 'PLOT SIZE',plotno as 'PLOT NO',DATEOFCOM AS 'DATE' FROM wjstar1.customerreg1 where CHECKBY='" + DropDownList1.Text + "' AND APPNO='" + DropDownList2.Text + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();
           // TextBox6.Text = DropDownList1.Text;
						//TextBox2.Text = "";
														//TextBox3.Text = "";

            con1.Open();
float gz=0;
SqlDataAdapter da1 = new SqlDataAdapter("SELECT PLOTSIZE FROM wjstar1.customerreg1 where CHECKBY='" + DropDownList1.Text + "' AND APPNO='" + DropDownList2.Text + "'", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
if(ds1.Tables[0].Rows.Count>0)
{
    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
    {
        gz += float.Parse(ds1.Tables[0].Rows[i][0].ToString());
    }
Label15.Text="Total Plot Size Booked =  "+gz.ToString();
}
            con1.Close();
          
          
        }
        catch (Exception t)
        {
            Label5.Text = "internal problem";
        }
    }
   
    protected void Button3_Click(object sender, EventArgs e)
    {
       
    }
   
   
   

    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
Label15.Text="";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT CUSTREGNO AS 'REGNO.',LEFT(NAMEDOBADDRESS,20) as 'NAME',APPNO AS 'ARAZI NO',CONSAMOUNT AS 'AMOUNT',INSTSUBPAY AS 'INSTALLMENT',PLOTSIZE AS 'PLOT SIZE',plotno as 'PLOT NO',DATEOFCOM AS 'DATE' FROM wjstar1.customerreg1 where CHECKBY='" + DropDownList1.Text + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //TextBox6.Text = DropDownList1.Text;
            //TextBox2.Text = "";
            //TextBox3.Text = "";

            con1.Open();
            float gz = 0;
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT PLOTSIZE FROM wjstar1.customerreg1 where CHECKBY='" + DropDownList1.Text + "' ", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    gz += float.Parse(ds1.Tables[0].Rows[i][0].ToString());
                }
                Label15.Text = "Total Plot Size Booked =  " + gz.ToString();
            }
            con1.Close();


        }
        catch (Exception t)
        {
            Label5.Text = "internal problem";
        }
    }
}