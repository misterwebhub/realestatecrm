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
public partial class pradhan_Detailskishan : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           
            bind2();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string arazi = "";
        string block = "";
        string dateString1 = TextBox1.Text;
        string dateString2 = TextBox2.Text;
        string format = "dd/mm/yyyy";
        DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
        string ddd1 = dateTime1.ToString("mm/dd/yyyy");
        DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
        string ddd2 = dateTime2.ToString("mm/dd/yyyy");

        DataTable paiddt = new DataTable();

        paiddt.Columns.AddRange(new DataColumn[4] { 
            new DataColumn("ARAZI", typeof(string)),
            new DataColumn("TOTAL", typeof(string)),
            new DataColumn("PAID", typeof(string)),
            new DataColumn("BALANCE",typeof(string))});
        DataRow dr1 = paiddt.NewRow();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazi,block from addarazidemo where name='"+DropDownList1.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arazi = ds.Tables[0].Rows[i][0].ToString();
                block = ds.Tables[0].Rows[i][1].ToString();
                if (block == "NO")
                {
                    con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID),SUM(c.CONSAMOUNT)-SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + arazi + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dr1["ARAZI"] = arazi;
                        dr1["TOTAL"] = ds1.Tables[0].Rows[0][0].ToString();
                        dr1["PAID"] = ds1.Tables[0].Rows[0][1].ToString();

                        dr1["BALANCE"] = ds1.Tables[0].Rows[0][2].ToString();
                        paiddt.Rows.Add(dr1);
                        dr1 = paiddt.NewRow();
                    }
                }
                else
                {
                    string plot = "";
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select DISTINCT block from addaraziplot where arazi='" + arazi + "' AND name='" + DropDownList1.Text + "'", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    con.Close();
                    Double totalsum = 0, totalpaid = 0, totalbal = 0;
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        for (int r = 0; r < ds2.Tables[0].Rows.Count; r++)
                        {
                            block = ds2.Tables[0].Rows[r][0].ToString();
                          //  plot = ds2.Tables[0].Rows[r][1].ToString();
                            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID),SUM(c.CONSAMOUNT)-SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + block + "' AND status='book' AND plotno in(select plotno from addaraziplot where name='" + DropDownList1.Text + "' AND arazi='" +arazi + "' AND block='" +block + "')) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') GROUP BY CUSTREGNO) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                            DataSet ds1 = new DataSet();
                            da1.Fill(ds1);
                            con.Close();
                            if(ds1.Tables[0].Rows.Count>0)
                            {
                                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                                {
                                    totalsum = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                                }
                                else
                                {
                                    totalsum = 0;
                                }
                                if (ds1.Tables[0].Rows[0][1].ToString() != "")
                                {
                                    totalpaid = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
                                }
                                else
                                {
                                    totalpaid = 0;
                                }
                                if (ds1.Tables[0].Rows[0][2].ToString() != "")
                                {
                                    totalbal = Convert.ToDouble(ds1.Tables[0].Rows[0][2].ToString());
                                }
                                else
                                {
                                    totalbal = 0;
                                }

                             }
                            dr1["ARAZI"] = arazi+" - "+block;
                            dr1["TOTAL"] = totalsum;
                            dr1["PAID"] = totalpaid;

                            dr1["BALANCE"] = totalbal;
                            paiddt.Rows.Add(dr1);
                            dr1 = paiddt.NewRow();
                        }

                    }
                   
                    
                       
                                    }
            }
        }
        GridView1.DataSource = paiddt;
        GridView1.DataBind();
    }
}