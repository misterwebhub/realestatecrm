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

public partial class PLOTDET : System.Web.UI.Page
{
   string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
         {
             DropDownList1.Items.Clear();
             SqlConnection con = new SqlConnection(s);
             con.Open();
             SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
             DataSet ds = new DataSet();
             da.Fill(ds);
             con.Close();
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
             }
             con.Close();
                                                        
        
         }
    }
    public void bind()
    {
		 
        GridView1.Visible = true;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select plotno,CUSTREGNO,PLOTSIZE,date3 as 'DATE',NAMEDOBADDRESS,CHECKBY,mobile,regstatus,ragistry,ragistryamt from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='completed' or regstatus='Cancel')", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();

        con.Close();

        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(convert(int,PLOTSIZE)) from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "'AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='completed')", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Label3.Text = ds1.Tables[0].Rows[0][0].ToString();
        }
        
        con.Open();
        SqlDataAdapter da4 = new SqlDataAdapter("select plotno,CUSTREGNO,PLOTSIZE,date3,NAMEDOBADDRESS,CHECKBY,mobile,regstatus,ragistry,ragistryamt from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='completed')", con);
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
              con.Close();
              GridView2.DataSource = ds4;
              GridView2.DataBind();
             
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        bind();
    }
		   protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string f = e.Row.Cells[7].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "Registry")
                {
                    cell.BackColor = Color.Yellow;
                }
				if (f == "Cancel")
                {
                    cell.BackColor = Color.Pink;
                }

            }
        }
    }												
														
														
    
    protected void Button8_Click(object sender, EventArgs e)
    {

    }
    protected void Button20_Click(object sender, EventArgs e)
    {

    }
    protected void ar239b13_Click(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            
            if (TextBox1.Text == "")
            {
                Label5.Text = "please enter registration number";
            }
            else
            {
				if(DropDownList2.Text=="Registry")
				{
                SqlCommand cmd = new SqlCommand("update wjstar1.customerreg1 set regstatus='" + DropDownList2.Text + "' where CUSTREGNO='" + TextBox1.Text + "'", con);
               int p=0;
					con.Open();
                p= cmd.ExecuteNonQuery();
					con.Close();
                if (p == 1)
                {
                    Label5.Text = "Registry Updated sucessfully";
                    bind();
                }
                else
                {
                    Label5.Text = "internal problem";
                }
				}
				else
				{
					if(DropDownList2.Text=="Cancel")
				{
                    string ddd = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
               SqlCommand cmd = new SqlCommand("INSERT INTO returnrecipt1 (CUSTREGNO,ASCNAME,RECIPT,ASCCODE,DATE,DUDATE,NEXTDATE,INSTNO,ENDOFTERM,ASCADDRESS,PLANTERM,MOD,AMOUNTR,EXPLANDVALUE,SUBAMOUNT,LATECHARGE,ASSADDRESS,AMOUNTWORD,status,mobile,checkby,DATE1,usertype)SELECT CUSTREGNO,ASCNAME,RECIPT,ASCCODE,DATE,DUDATE,NEXTDATE,INSTNO,ENDOFTERM,ASCADDRESS,PLANTERM,MOD,AMOUNTR,EXPLANDVALUE,SUBAMOUNT,LATECHARGE,ASSADDRESS,AMOUNTWORD,status,mobile,checkby,DATE1,usertype FROM wjstar1.recipt1 WHERE CUSTREGNO='"+TextBox1.Text+"'", con);
        int p=0;
						con.Open();
						p= cmd.ExecuteNonQuery();
       con.Close();
		con.Open();
		SqlCommand cmd1 = new SqlCommand("delete from wjstar1.recipt1 where  CUSTREGNO='"+TextBox1.Text+"'", con);
		p=cmd1.ExecuteNonQuery();
        con.Close();
               SqlCommand cmd3 = new SqlCommand("update wjstar1.customerreg1 set regstatus='" + DropDownList2.Text + "',deletedate='"+ddd+"' where CUSTREGNO='" + TextBox1.Text + "'", con);
               
					con.Open();
                p= cmd3.ExecuteNonQuery();
					con.Close();
               
                if (p != 0)
                {
                    Label5.Text = "Registry Updated sucessfully";
                    bind();
                }
                else
                {
                    Label5.Text = "internal problem";
                }
				}
				}
            }
        }
        catch (Exception r)
        {
            Label5.Text = "internal problem"+r;
        }
    }
    
    protected void Button5_Click1(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            if (TextBox2.Text == "")
            {
                Label5.Text = "please enter registration number";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update wjstar1.customerreg1 set regstatus='" + DropDownList3.Text + "' where CUSTREGNO='" + TextBox2.Text + "'", con);
                int p = 0;
                p = cmd.ExecuteNonQuery();
                if (p == 1)
                {
                    Label5.Text = "Registry Updated sucessfully";
                    bind();
                }
                else
                {
                    Label5.Text = "internal problem";
                }
            }
        }
        catch (Exception r)
        {
            Label5.Text = "internal problem";
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblname = (Label)e.Row.FindControl("creson8");



            if (lblname.Text == "completed")
            {

                lblname.Style.Add("color", "red");

            }
           
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(s);

            if (TextBox3.Text == "")
            {
                Label7.Text = "please enter registration number";
            }
            else
            {

                SqlCommand cmd = new SqlCommand("update wjstar1.customerreg1 set ragistry='FREE',ragistryamt="+TextBox4.Text+" where CUSTREGNO='" + TextBox3.Text + "'", con);
                int p = 0;
                con.Open();
                p = cmd.ExecuteNonQuery();
                con.Close();
                if (p !=0)
                {
                    Label7.Text = "Registry Updated sucessfully";
                    bind();
                }
                else
                {
                    Label5.Text = "internal problem";
                }
            }
        }
        catch (Exception rt)
        {
            Label7.Text = "server error";
        }
    }
}