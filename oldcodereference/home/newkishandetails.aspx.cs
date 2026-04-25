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

public partial class newkishandetails : System.Web.UI.Page
{
    public static Double custtotal = 0, custpaid = 0,kishan=0;
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grdbind();
        }
    }
    public void grdbind()
    {
        DropDownList1.Items.Clear();
       // DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("---------SELECT--------");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        con.Close();

    }
    public void customer()
    {
        custpaid = 0;
        custtotal = 0;
        SqlConnection con = new SqlConnection(s);
       
        if (DropDownList1.Text != "152")
        {
            if (DropDownList1.Text == "161-D")
            {
                con.Open();
                SqlDataAdapter da152d = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND  CUSTREGNO IN(select CUSTREGNO from arazi30beegha where block='D' AND status='book') )", con);
                DataSet ds152d = new DataSet();
                da152d.Fill(ds152d);
                con.Close();
                if (ds152d.Tables[0].Rows.Count > 0)
                {
                    if (ds152d.Tables[0].Rows[0][0].ToString() != "")
                    {
                        custpaid = Convert.ToDouble(ds152d.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        custpaid = 0;
                    }
                }
                else
                {
                    custpaid = 0;
                }
                con.Open();
                SqlDataAdapter da152d1 = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where APPNO='152' AND  CUSTREGNO IN(select CUSTREGNO from arazi30beegha where block='D' AND status='book') ", con);
                DataSet ds152d1 = new DataSet();
                da152d1.Fill(ds152d1);
                con.Close();
                if (ds152d1.Tables[0].Rows.Count > 0)
                {
                    if (ds152d1.Tables[0].Rows[0][0].ToString() !="")
                    {
                        custtotal = Convert.ToDouble(ds152d1.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        custtotal = 0;
                    }
                }
                else
                {
                    custtotal = 0;
                }
            }
            else
            {
                if (DropDownList1.Text == "161-F")
                {
                    con.Open();
                    SqlDataAdapter da152f = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND CUSTREGNO IN(select CUSTREGNO from arazi30beegha where block='F' AND status='book') )", con);
                    DataSet ds152f = new DataSet();
                    da152f.Fill(ds152f);
                    con.Close();
                    if (ds152f.Tables[0].Rows.Count > 0)
                    {
                        if (ds152f.Tables[0].Rows[0][0].ToString() != "")
                        {
                            custpaid = Convert.ToDouble(ds152f.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            custpaid = 0;
                        }
                    }
                    else
                    {
                        custpaid = 0;
                    }
                    con.Open();
                    SqlDataAdapter da152f1 = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where APPNO='152' AND  CUSTREGNO IN(select CUSTREGNO from arazi30beegha where block='F' AND status='book') ", con);
                    DataSet ds152f1 = new DataSet();
                    da152f1.Fill(ds152f1);
                    con.Close();
                    if (ds152f1.Tables[0].Rows.Count > 0)
                    {
                        if (ds152f1.Tables[0].Rows[0][0].ToString() != "")
                        {
                            custtotal = Convert.ToDouble(ds152f1.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            custtotal = 0;
                        }
                    }
                    else
                    {
                        custtotal = 0;
                    }
                }
                else
                {
                    if (DropDownList1.Text == "161")
                    {
                        con.Open();
                        SqlDataAdapter da152e = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND CUSTREGNO IN(select CUSTREGNO from arazi30beegha where block='E' AND status='book') )", con);
                        DataSet ds152e = new DataSet();
                        da152e.Fill(ds152e);
                        con.Close();
                        if (ds152e.Tables[0].Rows.Count > 0)
                        {
                            if (ds152e.Tables[0].Rows[0][0].ToString() != "")
                            {
                                custpaid = Convert.ToDouble(ds152e.Tables[0].Rows[0][0].ToString());
                            }
                            else
                            {
                                custpaid = 0;
                            }
                        }
                        else
                        {
                            custpaid = 0;
                        }
                        con.Open();
                        SqlDataAdapter da152e1 = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where APPNO='152' AND  CUSTREGNO IN(select CUSTREGNO from arazi30beegha where block='E' AND status='book') ", con);
                        DataSet ds152e1 = new DataSet();
                        da152e1.Fill(ds152e1);
                        con.Close();
                        if (ds152e1.Tables[0].Rows.Count > 0)
                        {
                            if (ds152e1.Tables[0].Rows[0][0].ToString() != "")
                            {
                                custtotal = Convert.ToDouble(ds152e1.Tables[0].Rows[0][0].ToString());
                            }
                            else
                            {
                                custtotal = 0;
                            }
                        }
                        else
                        {
                            custtotal = 0;
                        }
                    }
                    else
                    {
                        con.Open();
                        SqlDataAdapter da777 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
                        DataSet ds777 = new DataSet();
                        da777.Fill(ds777);
                        con.Close();
                        if (ds777.Tables[0].Rows.Count > 0)
                        {
                            if (ds777.Tables[0].Rows[0][0].ToString() !="")
                            {
                                custpaid = Convert.ToDouble(ds777.Tables[0].Rows[0][0].ToString());
                            }
                            else
                            {
                                custpaid = 0;
                            }
                        }
                        else
                        {
                            custpaid = 0;
                        }
                        con.Open();
                        SqlDataAdapter da77 = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where APPNO='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') ", con);
                        DataSet ds77 = new DataSet();
                        da77.Fill(ds77);
                        con.Close();
                        if (ds77.Tables[0].Rows.Count > 0)
                        {
                            if (ds77.Tables[0].Rows[0][0].ToString() != "")
                            {
                                custtotal = Convert.ToDouble(ds77.Tables[0].Rows[0][0].ToString());
                            }
                            else
                            {
                                custtotal = 0;
                            }
                        }
                        else
                        {
                            custtotal = 0;
                        }
                    }
                }
            }
            Label4.Text = custtotal.ToString("N0");
            Label5.Text = custpaid.ToString("N0");
            Label6.Text = (custtotal-custpaid).ToString("N0");
        }
        else
        {
            string message = "There are no customer payment";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        kishan = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select c.arazi,c.id,c.kname,c.landsize,c.landamount,r.PAID,c.landamount-r.PAID as balance from (select kid,sum(amount) AS PAID from kishanrecipt where status='PAID' GROUP BY kid ) AS r inner join newkishan AS c ON c.id=r.kid where c.arazi='" + DropDownList1.Text + "' AND c.id NOT IN('K0060')", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(c.landamount),sum(r.PAID),sum(c.landamount-r.PAID) as balance from (select kid,sum(amount) AS PAID from kishanrecipt where status='PAID' GROUP BY kid ) AS r inner join newkishan AS c ON c.id=r.kid where c.arazi='" + DropDownList1.Text + "' AND c.id NOT IN('K0060')", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label1.Text = ds1.Tables[0].Rows[0][0].ToString();
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    kishan = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    kishan = 0;
                }
            }
            else
            {
                Label1.Text ="0";
                kishan = 0;
            }
            if (ds1.Tables[0].Rows[0][1].ToString() != "")
            {
                Label2.Text = ds1.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                Label2.Text = "0";
            }
            if (ds1.Tables[0].Rows[0][2].ToString() != "")
            {
                Label3.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Label3.Text = "0";
            }
        }
        else
        {
            Label1.Text = "0";
            Label2.Text = "0";
            Label3.Text = "0";
        }
        customer();
        cal();
    }
    public void cal()
    {
        Label7.Text = custpaid.ToString("N0");
        Label8.Text = kishan.ToString("N0");
      Double d=(custpaid - kishan);
      if (d >= 0)
      {
          Label9.Text = d.ToString("N0");
          Label13.Text = d.ToString("N0");
          Label9.ForeColor = System.Drawing.Color.Green;
      }
      else

      {
          Label9.Text = d.ToString("N0");
          Label13.Text = d.ToString("N0");
          Label9.ForeColor = System.Drawing.Color.Red;
      }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Double exp = 0, d = 0, a1 = 0, a2 = 0, t1 = 0,y1=0 ;
       d = (custpaid - kishan);
       if (d > 0)
       {
           if (TextBox1.Text != "")
           {
               t1 = Convert.ToDouble(TextBox1.Text);

           }
           else
           {
               t1 = 0;
           }
           exp = (d * t1) / 100;

           y1 = d - exp;
           a1 = y1 / 2;
           a2 = y1 / 2;
           Label14.Text = exp.ToString("N0");
           Label15.Text = y1.ToString("N0");
           Label10.Text = y1.ToString("N0");
           Label11.Text = a1.ToString("N0");
           Label12.Text = a2.ToString("N0");
       }
       else
       {
           Label14.Text = "";
           Label15.Text ="";
           Label10.Text ="";
           Label11.Text = "";
           Label12.Text = "";
           string message = "The Payment Not Calculated Because Its Negative Value ( - )";
           System.Text.StringBuilder sb = new System.Text.StringBuilder();
           sb.Append("<script type = 'text/javascript'>");
           sb.Append("window.onload=function(){");
           sb.Append("alert('");
           sb.Append(message);
           sb.Append("')};");
           sb.Append("</script>");
           ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
       }

    }

}