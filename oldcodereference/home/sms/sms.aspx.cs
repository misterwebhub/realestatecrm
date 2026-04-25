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

public partial class sms_sms : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            bind();
           
        }
    }
    public void bind()
    {
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
           
        }
        con.Close();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
         try
        {
            string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox2.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string date2 = mm1 + "/" + dd1 + "/" + yy1;
            if (DropDownList1.Text == "PAID")
            {

                SqlConnection con1 = new SqlConnection(s);
                con1.Open();
               
               // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,ASCADDRESS,mobile from recipt where status='PAID' and DATE between '" + TextBox1.Text + "' AND '" + TextBox2.Text + "' AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg1 where APPNO='" + DropDownList1.Text + "'))  ", con1);
                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,ASCADDRESS,mobile from wjstar1.recipt1 where status='PAID' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList2.Text + "'))", con1);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                con1.Close();
            }
            else
            {
                if (DropDownList1.Text == "NON PAID")
                {
                    SqlConnection con1 = new SqlConnection(s);
                    con1.Open();

                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,ASCADDRESS,mobile from wjstar1.recipt1 where CUSTREGNO not in(select DISTINCT CUSTREGNO from wjstar1.recipt where status='PAID' AND (DATE between '" +date1+ "' AND '" +date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList2.Text + "')))", con1);
                    DataSet ds = new DataSet();
                    cmd.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    con1.Close();
                }
                else
                {
                    Label1.Text = "SELECT ANY ONE STATUS";
                }
            }
            // DataTable dt = new DataTable();


        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }

    }
 protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow dr = GridView1.SelectedRow;
        TextBox3.Text = dr.Cells[3].Text;
    }
}