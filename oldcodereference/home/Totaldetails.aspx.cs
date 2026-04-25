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

public partial class Total_Balance : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
if(!IsPostBack)
{
	 DropDownList4.Visible = false;
            Label4.Visible = false;
        SqlConnection con = new SqlConnection(s);
             con.Open();
             SqlDataAdapter da = new SqlDataAdapter("select   DISTINCT  APPNO from wjstar1.customerreg1", con);
             DataSet ds = new DataSet();
             da.Fill(ds);
             con.Close();
             if (ds.Tables[0].Rows.Count > 0)
             {
                 for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                 {
                     DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString()); 
                 }
             }
																}
    }
     int total;
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            total = 0;
                    GridView1.Visible = true;
                    Label1.Text = "";
                    SqlConnection con1 = new SqlConnection(s);

                  
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
			if (DropDownList1.Text != "152")
        {
			  con1.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,ASCADDRESS,RECIPT,DATE1,AMOUNTR,checkby from wjstar1.recipt1 where (DATE1 BETWEEN '" +date1+ "' AND '" +date2+ "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')))order by DATE1 ASC", con1);
			//SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,ASCADDRESS,RECIPT,DATE1,AMOUNTR,checkby from wjstar1.recipt1 where (DATE1 BETWEEN '" +date1+ "' AND '" +date2+ "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND  regstatus!='Cancel')))order by DATE1 ASC", con1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con1.Close();


                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    con1.Open();
                    SqlCommand cmd = new SqlCommand("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 BETWEEN '" + date1+ "' AND '" + date2 + "' AND CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con1);
                    SqlDataReader dr1 = cmd.ExecuteReader();

                    if (dr1.HasRows == true)
                    {
                        while (dr1.Read())
                        {
                            // total1 = Convert.ToInt32(dr.GetValue(1));
                            total = Convert.ToInt32(dr1.GetValue(0));
                        }
                    }
                    Label1.Text = total.ToString() + " RS.";
                    con1.Close();
			}
			else
        {
            if (DropDownList4.Text == "E" || DropDownList4.Text == "D" || DropDownList4.Text == "F")
            {
				
			  con1.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,ASCADDRESS,RECIPT,DATE1,AMOUNTR,checkby from wjstar1.recipt1 where (DATE1 BETWEEN '" +date1+ "' AND '" +date2+ "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "') AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')))order by DATE1 ASC", con1);
			//SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,ASCADDRESS,RECIPT,DATE1,AMOUNTR,checkby from wjstar1.recipt1 where (DATE1 BETWEEN '" +date1+ "' AND '" +date2+ "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND  regstatus!='Cancel')))order by DATE1 ASC", con1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con1.Close();


                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    con1.Open();
                    SqlCommand cmd = new SqlCommand("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 BETWEEN '" + date1+ "' AND '" + date2 + "' AND CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "') AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con1);
                    SqlDataReader dr1 = cmd.ExecuteReader();

                    if (dr1.HasRows == true)
                    {
                        while (dr1.Read())
                        {
                            // total1 = Convert.ToInt32(dr.GetValue(1));
                            total = Convert.ToInt32(dr1.GetValue(0));
                        }
                    }
                    Label1.Text = total.ToString() + " RS.";
                    con1.Close();
			}
				else
				{
					
			  con1.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,ASCADDRESS,RECIPT,DATE1,AMOUNTR,checkby from wjstar1.recipt1 where (DATE1 BETWEEN '" +date1+ "' AND '" +date2+ "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C'))  AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')))order by DATE1 ASC", con1);
			//SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,ASCADDRESS,RECIPT,DATE1,AMOUNTR,checkby from wjstar1.recipt1 where (DATE1 BETWEEN '" +date1+ "' AND '" +date2+ "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND  regstatus!='Cancel')))order by DATE1 ASC", con1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con1.Close();


                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    con1.Open();
                    SqlCommand cmd = new SqlCommand("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 BETWEEN '" + date1+ "' AND '" + date2 + "' AND CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C'))  AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con1);
                    SqlDataReader dr1 = cmd.ExecuteReader();

                    if (dr1.HasRows == true)
                    {
                        while (dr1.Read())
                        {
                            // total1 = Convert.ToInt32(dr.GetValue(1));
                            total = Convert.ToInt32(dr1.GetValue(0));
                        }
                    }
                    Label1.Text = total.ToString() + " RS.";
                    con1.Close();
				}
			}
            
           

        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }




    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            total = 0;
            GridView1.Visible = true;
            Label1.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
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
            SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,ASCADDRESS,RECIPT,DATE1,AMOUNTR,checkby from wjstar1.recipt1 where (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')))order by DATE1 ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();


            GridView1.DataSource = ds;
            GridView1.DataBind();
            con1.Open();
            SqlCommand cmd = new SqlCommand("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con1);
            SqlDataReader dr1 = cmd.ExecuteReader();

            if (dr1.HasRows == true)
            {
                while (dr1.Read())
                {
                    // total1 = Convert.ToInt32(dr.GetValue(1));
                    total = Convert.ToInt32(dr1.GetValue(0));
                }
            }
            Label1.Text = total.ToString() + " RS.";
            con1.Close();



        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }

    }
	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text != "152")
        {
            DropDownList4.Visible = false;
            Label4.Visible = false;
        }
        else
        {
            DropDownList4.Visible = true;
            Label4.Visible = true;
        }
    }
}