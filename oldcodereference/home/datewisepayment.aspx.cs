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
public partial class kishan_Bin_datewisepayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            find();

        }

    }
    public void find()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT APPNO FROM wjstar1.customerreg1", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                // DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                DropDownList2.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
                DropDownList3.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string start = mm + "/01" + "/" + yy;
            string end;
            if (Convert.ToInt32(mm)!=2)
            {
                end = mm + "/" + dd + "/" + yy;
            }
            else
            {
                end = mm + "/28" + "/" + yy;
            }


            if (DropDownList1.Text == "NON PAID")
            {
                // GridView1.Visible = false;
                GridView2.Visible = true;
                SqlConnection con1 = new SqlConnection(s);
                con1.Open();

                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(NAMEDOBADDRESS,20) AS 'NAME', APPNO,plotno,PLOTSIZE,date3,CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where DAY(date3)='" + dd + "'  AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy+ "') AND  APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con1.Close();




            }
            else
            {
                if (DropDownList1.Text == "ALL ARAZI NON PAID")
                {
                    // GridView1.Visible = false;
                    GridView2.Visible = true;
                    SqlConnection con1 = new SqlConnection(s);
                    con1.Open();


                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(NAMEDOBADDRESS,20) AS 'NAME', APPNO,plotno,PLOTSIZE,date3,CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where DAY(date3)='" + dd + "'  AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                    DataSet ds = new DataSet();
                    cmd.Fill(ds);
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    con1.Close();




                }
                else
                {
                    Label1.Text = "Please select any mode";
                }
            }

            }
            // DataTable dt = new DataTable();


        
        catch (Exception t)
        {
            Label1.Text = "internal problem" + t;
        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gr = GridView2.SelectedRow;
        String id = gr.Cells[1].Text;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO AS 'REGNO',LEFT(r.ASSADDRESS,20) AS 'ADDRESS',r.PLANTERM AS 'PLAN',r.EXPLANDVALUE AS 'VALUE',r.RECIPT,r.DATE,r.INSTNO,r.AMOUNTR,u.APPNO from wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + id + "'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        GridView3.DataSource = ds;
        GridView3.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string s2 = TextBox2.Text;
            string s4 = TextBox3.Text;
            string dd = s2.Substring(0, 2);
            string dd1 = s4.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string start = mm + "/01" + "/" + yy;
            string end;
            if (Convert.ToInt32(mm) != 2)
            {
                end = mm + "/" + dd + "/" + yy;
            }
            else
            {
                end = mm + "/28" + "/" + yy;
            }


            if (DropDownList4.Text == "NON PAID")
            {
                // GridView1.Visible = false;
                GridView2.Visible = true;
                SqlConnection con1 = new SqlConnection(s);
                con1.Open();

                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(NAMEDOBADDRESS,20) AS 'NAME', APPNO,plotno,PLOTSIZE,date3,CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where DAY(date3) BETWEEN '" + dd + "' AND '" + dd1 + "'  AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "') AND  APPNO='" + DropDownList3.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con1.Close();




            }
            else
            {
                if (DropDownList4.Text == "ALL ARAZI NON PAID")
                {
                    // GridView1.Visible = false;
                    GridView2.Visible = true;
                    SqlConnection con1 = new SqlConnection(s);
                    con1.Open();


                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(NAMEDOBADDRESS,20) AS 'NAME', APPNO,plotno,PLOTSIZE,date3,CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where DAY(date3) BETWEEN '" + dd + "' AND '" + dd1 + "'  AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                    DataSet ds = new DataSet();
                    cmd.Fill(ds);
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    con1.Close();




                }
                else
                {
                    Label1.Text = "Please select any mode";
                }
            }

        }
        // DataTable dt = new DataTable();



        catch (Exception t)
        {
            Label1.Text = "internal problem" + t;
        }
    }
}