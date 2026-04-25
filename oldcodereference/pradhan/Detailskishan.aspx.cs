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
        DataTable bty = new DataTable();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arazi = ds.Tables[0].Rows[i][0].ToString();
                block = ds.Tables[0].Rows[i][1].ToString();
                if (block == "NO")
                {
                   
                    
                    bty = null;
                    bty = backdetails(arazi,"NO",block);
                    Double p1 = 0;
                    if (bty.Rows.Count > 0)
                    {
                        if (bty.Rows[0][2].ToString() != "")
                        {
                            p1 = Convert.ToDouble(bty.Rows[0][2].ToString());
                        }
                        else
                        {
                            p1 = 0;
                        }
                    }
           
                    con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("select SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + arazi + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where APPNO='" + arazi + "' AND date3<='" + ddd2 + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    con.Close();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dr1["ARAZI"] = arazi;
                        //dr1["TOTAL"] = ds1.Tables[0].Rows[0][0].ToString();
                        dr1["PAID"] = ds1.Tables[0].Rows[0][0].ToString();

                        Double tot = 0, pa = 0, bal = 0;
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            if (ds2.Tables[0].Rows[0][0].ToString() != "")
                            {
                                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                                {
                                    dr1["TOTAL"] = ds2.Tables[0].Rows[0][0].ToString();
                                    tot = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
                                    pa = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                                    bal = tot - pa-p1;
                                    dr1["BALANCE"] = bal.ToString();
                                }
                                else
                                {
                                    dr1["TOTAL"] = "";
                                    tot = 0;
                                    pa = 0;
                                    bal = tot - pa-p1;
                                    dr1["BALANCE"] = "";
                                }

                            }
                            else
                            {
                                tot = 0;
                            }
                        }



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
                            bty = null;
                            bty = backdetails(arazi, "YES", block);
                            Double p2 = 0;
                            if (bty.Rows.Count > 0)
                            {
                                if (bty.Rows[0][2].ToString() != "")
                                {
                                    p2 = Convert.ToDouble(bty.Rows[0][2].ToString());
                                }
                                else
                                {
                                    p2 = 0;
                                }
                            }
                          //  plot = ds2.Tables[0].Rows[r][1].ToString();
                            con.Open();
                            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + block + "' AND status='book' AND plotno in(select plotno from addaraziplot where name='" + DropDownList1.Text + "' AND arazi='" +arazi + "' AND block='" +block + "')) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') GROUP BY CUSTREGNO) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                            DataSet ds1 = new DataSet();
                            da1.Fill(ds1);
                            con.Close();
                            con.Open();
                            SqlDataAdapter da3 = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where date3<='" + ddd2 + "' AND CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" +block + "' AND status='book' AND plotno IN(select plotno from addaraziplot where name='" + DropDownList1.Text + "' AND arazi='" + arazi + "' AND block='" + block + "' )) AND  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                           // SqlDataAdapter da3 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID),SUM(c.CONSAMOUNT)-SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + block + "' AND status='book' AND plotno in(select plotno from addaraziplot where name='" + DropDownList1.Text + "' AND arazi='" + arazi + "' AND block='" + block + "')) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') GROUP BY CUSTREGNO) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                            DataSet ds3 = new DataSet();
                            da3.Fill(ds3);
                            con.Close();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                               
                                dr1["PAID"] = ds1.Tables[0].Rows[0][0].ToString();


                            }


                            Double tot = 0, pa = 0, bal = 0;
                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                                {
                                    if (ds1.Tables[0].Rows[0][0].ToString() != "")
                                    {
                                        dr1["TOTAL"] = ds3.Tables[0].Rows[0][0].ToString();
                                        tot = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                                        pa = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                                        bal = tot - pa-p2;
                                        dr1["BALANCE"] = bal.ToString();
                                    }
                                    else
                                    {
                                        dr1["TOTAL"] = "";
                                        tot = 0;
                                        pa = 0;
                                        bal = tot - pa-p2;
                                        dr1["BALANCE"] = "";
                                    }

                                }
                                else
                                {
                                    tot = 0;
                                }
                            }



                            
                            dr1["ARAZI"] = arazi+" - "+block;
                           
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
    public DataTable backdetails(string ar,string blok,string blk)
    {
        string arazi = "", block = "";
        SqlConnection con = new SqlConnection(s);
       // con.Open();
       // SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazi,block from addarazidemo where name='" + DropDownList1.Text + "' AND arazi='" + ar + "'", con);
       // DataSet ds = new DataSet();
       // da.Fill(ds);
       // con.Close();
        arazi = ar;
        block = blk;
        string dateString1 = TextBox1.Text;
       // string dateString2 = TextBox2.Text;
        string format = "dd/mm/yyyy";
        DateTime dateTime1 = DateTime.ParseExact(dateString1, format, CultureInfo.InvariantCulture);
        string ddd1 = dateTime1.ToString("mm/dd/yyyy");
      //  DateTime ddd1 = new DateTime(2015, 1, 1);
       // int year = Convert.ToInt32(DropDownList3.Text) - 1;
       // DateTime ddd2 = new DateTime(year, 12, 31);
        DataTable paiddt = new DataTable();

        paiddt.Columns.AddRange(new DataColumn[4] { 
            new DataColumn("ARAZI", typeof(string)),
            new DataColumn("TOTAL", typeof(string)),
            new DataColumn("PAID", typeof(string)),
            new DataColumn("BALANCE",typeof(string))});
        DataRow dr1 = paiddt.NewRow();

        if (blok == "NO")
        {
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 < '" + ddd1 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where APPNO='" + arazi + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')) GROUP BY CUSTREGNO ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where APPNO='" + arazi + "' AND date3<'" + ddd1 + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dr1["ARAZI"] = arazi;
                //dr1["TOTAL"] = ds1.Tables[0].Rows[0][0].ToString();
                dr1["PAID"] = ds1.Tables[0].Rows[0][0].ToString();

                Double tot = 0, pa = 0, bal = 0;
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    {
                        if (ds1.Tables[0].Rows[0][0].ToString() != "")
                        {
                            dr1["TOTAL"] = ds2.Tables[0].Rows[0][0].ToString();
                            tot = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
                            pa = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                            bal = tot - pa;
                            dr1["BALANCE"] = bal.ToString();
                        }
                        else
                        {
                            dr1["TOTAL"] = "";
                            tot = 0;
                            pa = 0;
                            bal = tot - pa;
                            dr1["BALANCE"] = "";
                        }

                    }
                    else
                    {
                        tot = 0;
                    }
                }



                paiddt.Rows.Add(dr1);
                dr1 = paiddt.NewRow();
            }
        }
        else
        {
            string plot = "";
            
            Double totalsum = 0, totalpaid = 0, totalbal = 0;

            
            block = blk; 
                    //  plot = ds2.Tables[0].Rows[r][1].ToString();
                    con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("select SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 < '" + ddd1 + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + block + "' AND status='book' AND plotno in(select plotno from addaraziplot where name='" + DropDownList1.Text + "' AND arazi='" + arazi + "' AND block='" + block + "')) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') GROUP BY CUSTREGNO) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    con.Open();
                    SqlDataAdapter da3 = new SqlDataAdapter("select sum(CONSAMOUNT) from wjstar1.customerreg1 where date3<='" + ddd1 + "' AND CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + block + "' AND status='book' AND plotno IN(select plotno from addaraziplot where name='" + DropDownList1.Text + "' AND arazi='" + arazi + "' AND block='" + block + "' )) AND  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                    // SqlDataAdapter da3 = new SqlDataAdapter("select SUM(c.CONSAMOUNT),SUM(r.PAID),SUM(c.CONSAMOUNT)-SUM(r.PAID) from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 where DATE1 BETWEEN '" + ddd1 + "' AND '" + ddd2 + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from arazi30beegha where block='" + block + "' AND status='book' AND plotno in(select plotno from addaraziplot where name='" + DropDownList1.Text + "' AND arazi='" + arazi + "' AND block='" + block + "')) AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel') GROUP BY CUSTREGNO) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    con.Close();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {

                        dr1["PAID"] = ds1.Tables[0].Rows[0][0].ToString();


                    }


                    Double tot = 0, pa = 0, bal = 0;
                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        if (ds3.Tables[0].Rows[0][0].ToString() != "")
                        {
                            if (ds1.Tables[0].Rows[0][0].ToString() != "")
                            {
                                dr1["TOTAL"] = ds3.Tables[0].Rows[0][0].ToString();
                                tot = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                                pa = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                                bal = tot - pa;
                                dr1["BALANCE"] = bal.ToString();
                            }
                            else
                            {
                                dr1["TOTAL"] = "";
                                tot = 0;
                                pa = 0;
                                bal = tot - pa;
                                dr1["BALANCE"] = "";
                            }

                        }
                        else
                        {
                            tot = 0;
                        }
                    }




                    dr1["ARAZI"] = arazi + " - " + block;

                    paiddt.Rows.Add(dr1);
                    dr1 = paiddt.NewRow();
                

            



        }
        return paiddt;
    }
}