﻿using System;
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
using System.Globalization;

public partial class dialer_dailerfetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    public void callcount()
    {
        try
        {
            string s2 = TextBox1.Text;
            string s4 = TextBox2.Text;
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


                
                    // GridView1.Visible = false;
                  //  GridView2.Visible = true;
                    SqlConnection con1 = new SqlConnection(s);
                    con1.Open();

                     SqlDataAdapter cmd = new SqlDataAdapter("select count(c.CUSTREGNO)   from wjstar1.customerreg1 c  join calldemo r on r.CUSTREGNO=c.CUSTREGNO  where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                      /*  SqlDataAdapter cmd = new SqlDataAdapter("select count(c.CUSTREGNO) from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO AND r.userid='"+DropDownList1.Text+"' where DAY(c.date3) BETWEEN '" + dd + "' AND '" + dd1 + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + DropDownList1.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);*/
                        DataSet ds = new DataSet();
                        cmd.Fill(ds);

                        con1.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0][0].ToString() != "")
                            {
                                Label2.Text = ds.Tables[0].Rows[0][0].ToString();
                            }
                            else
                            {
                                Label2.Text = "0";
                            }
                        }
                        else
                        {
                            Label2.Text = "0";
                        }
            
                  




                
               
            }
        catch (Exception t)
        {
            Label3.Text = "internal problem" + t;
        }
    }
    public void calldetails()
    {
         string s2 = TextBox1.Text;
            string s4 = TextBox2.Text;
            string dd = s2.Substring(0, 2);
            string dd1 = s4.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
        string mm1=s4.Substring(3, 2);
          string yy1=s4.Substring(6,4);
            string start = mm +"/"+ dd + "/" + yy;
            string end;
            
           
                end = mm1 +"/"+ dd1 + "/" + yy1;
            


                
                    // GridView1.Visible = false;
                  //  GridView2.Visible = true;
                    SqlConnection con1 = new SqlConnection(s);
                    con1.Open();

                    
                        SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,r.status,r.duration,r.date,r.reason,r.feeddate,r.recording,r.entrytime  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where r.date BETWEEN '" + start + "' AND '" + end + "' AND r.CUSTREGNO IN(select CUSTREGNO from calldemo where r.userid='"+DropDownList1.Text+"')", con1);
                        DataSet ds = new DataSet();
                        cmd.Fill(ds);

                        con1.Close();
                        SqlDataAdapter cmd1 = new SqlDataAdapter("select count( c.CUSTREGNO) from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where r.date BETWEEN '" + start + "' AND '" + end + "'  AND c.CUSTREGNO IN(select CUSTREGNO from calldemo where r.userid='"+DropDownList1.Text+"')", con1);
                        DataSet ds1 = new DataSet();
                        cmd1.Fill(ds1);

                        con1.Close();
        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0][0].ToString() != "")
                            {
                                GridView1.DataSource=ds;
                                GridView1.DataBind();
                            }
                            else
                            {
                                GridView1.DataSource=null;
                                GridView1.DataBind();
                            }
                        }
                        else
                        {
                           GridView1.DataSource=null;
                                GridView1.DataBind();
                        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                Label1.Text = ds1.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label1.Text = "0";
            }
        }
        else
        {
            Label1.Text = "0";
        } 
            
                  




                
               
           
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.Text != "---SELECT---")
        {
            callcount();
            calldetails();

        }
        else
        {
            Label3.Text = "Please Select User";
        }
    }
}