using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Services;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;

public partial class dialer_advocatemenu : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
			/*if(Session["ID"] != null)
			{
				
			   Label2.Text = "heedrealestate";
			}
			else
				
			{
				Response.Redirect("~/home/usercredential/credential.aspx");
			}*/
            BIND();
            Panel1.Visible = false;
        }
    }
    public void BIND()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1 where arazino not in(select DISTINCT arazino from softploted1)", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "zaber003" || TextBox1.Text == "ZABER003")
        {
            Label1.Text = "";
            Panel1.Visible = true;
            GridView1.Visible = true;
            GridView2.Visible = false;
        }
        else
        {
            Label1.Text = "Please Enter Correct Password";
            Panel1.Visible = false;
        }
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select RECIPT,CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',DATE1,AMOUNTR from   wjstar1.recipt1 where RECIPT='" + TextBox2.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Label2.Text = "";
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                Label2.Text = "RECIPT NO NOT FOUND";
            }
        }
        else
        {
            GridView1.DataSource =null;
            GridView1.DataBind();
            Label2.Text = "RECIPT NO NOT FOUND";

        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["RECIPT"].ToString());
        //Label2.Text = id.ToString();
        SqlConnection con1 = new SqlConnection(s);
       
        SqlCommand cmd = new SqlCommand("insert into recipt2(CUSTREGNO,	ASCNAME,	RECIPT,	ASCCODE,	DATE,	DUDATE,	NEXTDATE,	INSTNO,	ENDOFTERM,	ASCADDRESS,	PLANTERM,	MOD,	AMOUNTR,	EXPLANDVALUE,	SUBAMOUNT,	LATECHARGE,	ASSADDRESS,	AMOUNTWORD,	status,	mobile,	checkby,	DATE1,	DUDATE1	,usertype,	insttype,	userstatus,	paidamount,	deldate,	dptotal,	dppaid,dpbal,	insttotal,	instpaid,	instbal,	instamtpaid	,dppaidamount,	chequebounce,	totalrec,	chequeno,	chequenopay,	entrytime) select CUSTREGNO,	ASCNAME,	RECIPT,	ASCCODE,	DATE,	DUDATE,	NEXTDATE,	INSTNO,	ENDOFTERM,	ASCADDRESS,	PLANTERM,	MOD,	AMOUNTR,	EXPLANDVALUE,	SUBAMOUNT,	LATECHARGE,	ASSADDRESS,	AMOUNTWORD,	status,	mobile,	checkby,	DATE1,	DUDATE1	,usertype,	insttype,	userstatus,	paidamount,	deldate,	dptotal,	dppaid,dpbal,	insttotal,	instpaid,	instbal,	instamtpaid	,dppaidamount,	chequebounce,	totalrec,	chequeno,	chequenopay,	entrytime from  wjstar1.recipt1 where RECIPT="+id+"", con1);
        con1.Open();
       int i= cmd.ExecuteNonQuery();
        con1.Close();
        if (i != 0)
        {
            SqlCommand cmd1 = new SqlCommand("delete from  wjstar1.recipt1 where RECIPT=" + id + "", con1);
            con1.Open();
            int j = cmd1.ExecuteNonQuery();
            con1.Close();
            Label2.Text = "RECORD DELETED SUCESSFULLY";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        else
        {
            Label2.Text = "RECORD NOT DELETED";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[5].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete Recipt" + item + "?')){ return false; };";
                }
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        GridView1.Visible = false;
        GridView2.Visible = true;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select RECIPT,CUSTREGNO,SUBSTRING(ASCADDRESS,1,15) AS 'NAME',DATE1,AMOUNTR from  recipt2 ORDER BY DATE1 ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select left(NAMEDOBADDRESS,15) AS 'NAME',APPNO from  wjstar1.customerreg1 where CUSTREGNO='"+TextBox3.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Label4.Text = "NAME -      "+ds.Tables[0].Rows[0][0].ToString()+"  ARAZI.NO-     "+ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                Label4.Text = "No Record Found";
            }
        
        }
        else
        {
            Label4.Text = "No Record Found";
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //Label2.Text = id.ToString();
        SqlConnection con1 = new SqlConnection(s);

        SqlCommand cmd = new SqlCommand("update  wjstar1.customerreg1 set APPNO='"+DropDownList1.Text+"' where CUSTREGNO='"+TextBox3.Text+"'", con1);
        con1.Open();
        int i = cmd.ExecuteNonQuery();
        con1.Close();
        Label4.Text = "Arazi updated sucessfully";
    }
}