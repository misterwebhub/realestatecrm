﻿using System;
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
using System.Globalization;

public partial class pradhan_monthdetailst : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Visible = false;
            DropDownList4.Visible = false;

            bind2();
            year();
        }
    }
    public void year()
    {
        DateTime dt=DateTime.Now;
        int y=dt.Year;
        DropDownList3.Items.Add("---select---");

        for (int i = 2018; i <= y; i++)
        {
            DropDownList3.Items.Add(i.ToString());
        }
    }
    public void bind2()
    {
        DropDownList1.Items.Clear();
        // DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT name from addname", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("---SELECT----");
        // DropDownList4.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            //  DropDownList4.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();

    }
    public void bind4()
    {


        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazi from addarazidemo where name='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        con.Close();
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("---SELECT----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
        }
        con.Close();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind4();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string arazi = "", block = "";

        DataTable paiddt = new DataTable();

        paiddt.Columns.AddRange(new DataColumn[4] { 
            new DataColumn("MONTH", typeof(string)),
            new DataColumn("TOTAL", typeof(string)),
            new DataColumn("PAID", typeof(string)),
            new DataColumn("BALANCE",typeof(string))});
        DataRow dr1 = paiddt.NewRow();
        DateTime start;
        DateTime end;
        int d=0;
        int feb5 = 0;
        d=Convert.ToInt32(DropDownList3.Text);
        int t=d%4;
        if (t == 0)
        {
            feb5 = 28;
        }
        else
        {
            feb5 = 29;
        }
        for (int i = 1; i <= 12; i++)
        {
            if(i==1 || i==3 || i==5 || i==7 || i==8 || i==10 || i==12)
            {
                start = new DateTime(d, i, 1);
                end = new DateTime(d, i,31);
            }
            else
            {
                if(i==2)
                {
                    start = new DateTime(d, i, 1);
                  /*  string dateString2 =feb5+"/0"+i+"/"+d;
                    string format = "dd/mm/yyyy";
                    end = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);*/
                    
                   end = new DateTime(d, i, 28);
                }
                else
                {
                    start = new DateTime(d, i, 1);
                    end = new DateTime(d, i, 30);
                }
             }

            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazi,block from addarazidemo where name='" + DropDownList1.Text + "' AND arazi='"+DropDownList2.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                arazi = ds.Tables[0].Rows[0][0].ToString();
                block = ds.Tables[0].Rows[0][1].ToString();
                if (block == "NO")
                {
                    con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID),SUM(c.CONSAMOUNT)-SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + start + "' AND '" + end + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + arazi + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        switch (i)
                        {
                            case 1:
                                dr1["MONTH"] = "Jan " + d;
                                break;
                            case 2:
                                dr1["MONTH"] = "Feb " + d;
                                break;
                            case 3:
                                dr1["MONTH"] = "Mar " + d;
                                break;
                            case 4:
                                dr1["MONTH"] = "Apr " + d;
                                break;
                            case 5:
                                dr1["MONTH"] = "May " + d;
                                break;
                            case 6:
                                dr1["MONTH"] = "Jun " + d;
                                break;
                            case 7:
                                dr1["MONTH"] = "Jul " + d;
                                break;
                            case 8:
                                dr1["MONTH"] = "Aug " + d;
                                break;
                            case 9:
                                dr1["MONTH"] = "Sep " + d;
                                break;
                            case 10:
                                dr1["MONTH"] = "Oct " + d;
                                break;
                            case 11:
                                dr1["MONTH"] = "Nov " + d;
                                break;
                            case 12:
                                dr1["MONTH"] = "Dec " + d;
                                break;
                            default:
                                
                                break;
                        }
                        
                        dr1["TOTAL"] = ds1.Tables[0].Rows[0][0].ToString();
                        dr1["PAID"] = ds1.Tables[0].Rows[0][1].ToString();

                        dr1["BALANCE"] = ds1.Tables[0].Rows[0][2].ToString();
                        paiddt.Rows.Add(dr1);
                        dr1 = paiddt.NewRow();
                    }
                }
                else
                {
                    con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID),SUM(c.CONSAMOUNT)-SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + start + "' AND '" + end + "' AND CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND status='book' AND plotno IN(select plotno from addaraziplot where name='" + DropDownList1.Text + "' AND arazi='" + DropDownList2.Text + "' AND block='" + DropDownList4.Text + "' ) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        switch (i)
                        {
                            case 1:
                                dr1["MONTH"] = "Jan " + d;
                                break;
                            case 2:
                                dr1["MONTH"] = "Feb " + d;
                                break;
                            case 3:
                                dr1["MONTH"] = "Mar " + d;
                                break;
                            case 4:
                                dr1["MONTH"] = "Apr " + d;
                                break;
                            case 5:
                                dr1["MONTH"] = "May " + d;
                                break;
                            case 6:
                                dr1["MONTH"] = "Jun " + d;
                                break;
                            case 7:
                                dr1["MONTH"] = "Jul " + d;
                                break;
                            case 8:
                                dr1["MONTH"] = "Aug " + d;
                                break;
                            case 9:
                                dr1["MONTH"] = "Sep " + d;
                                break;
                            case 10:
                                dr1["MONTH"] = "Oct " + d;
                                break;
                            case 11:
                                dr1["MONTH"] = "Nov " + d;
                                break;
                            case 12:
                                dr1["MONTH"] = "Dec " + d;
                                break;
                            default:

                                break;
                        }
                        dr1["TOTAL"] = ds1.Tables[0].Rows[0][0].ToString();
                        dr1["PAID"] = ds1.Tables[0].Rows[0][1].ToString();

                        dr1["BALANCE"] = ds1.Tables[0].Rows[0][2].ToString();
                        paiddt.Rows.Add(dr1);
                        dr1 = paiddt.NewRow();
                    }
                }
            }
        }
        GridView1.DataSource = paiddt;
        GridView1.DataBind();
        Double tt = 0, pt = 0, bt = 0;
        if (paiddt.Rows.Count > 0)
        {
            for (int y = 0; y < paiddt.Rows.Count; y++)
            {
              
                if (paiddt.Rows[y][2].ToString() == "")
                {
                   
                }
                else
                {
                    pt = pt + Convert.ToDouble(paiddt.Rows[y][2].ToString());
                }
                if (paiddt.Rows[y][1].ToString() == "")
                {
                    
                }
                else
                {
                    tt = 0;
                    tt = Convert.ToDouble(paiddt.Rows[y][1].ToString());
                }
               
            }
        }
        bt = tt - pt;
        Label2.Text = tt.ToString();
        Label3.Text = pt.ToString();
        Label4.Text = bt.ToString();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT block from addarazidemo where name='" + DropDownList1.Text + "' AND arazi='" + DropDownList2.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "YES")
            {
                DropDownList4.Items.Clear();
                Label1.Visible = true;
                DropDownList4.Visible = true;
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("select DISTINCT block from addaraziplot where name='" + DropDownList1.Text + "' AND arazi='" + DropDownList2.Text + "'", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                DropDownList4.Items.Add("---Select---");
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        DropDownList4.Items.Add(ds1.Tables[0].Rows[i][0].ToString());
                    }
                }
                    

            }
            else
            {
                Label1.Visible = false;
                DropDownList4.Visible = false;
            }
        }
        else
        {
            Label1.Visible = false;
            DropDownList4.Visible = false;
        }
    }
}