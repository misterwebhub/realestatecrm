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
public partial class kishan_Bin_datewisepayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String id = "heedrealestate";
            // Label4.Visible = false;
            // DropDownList4.Visible = false;
            Session["ID"] = "xdc";
           /* if (id != null)
            {
                id = "heedrealestate";
                //  id = Session["idr"].ToString();
                //Label13.Text = 
            }
            else
            {
                Response.Redirect("~/telelogin/dist/telelogin.aspx");
            }*/

            //id = Session["idr"].ToString();
            // Button2.Visible = false;
            //id = "Ashok8396";
            //id = "heedrealestate";
            bind(id);



            find();

        }

    }
    public void bind(String id)
    {
        try
        {


            // Button2.Visible = false;
            TextBox4.Text = id;





        }
        catch (Exception t)
        {
            Label1.Text = "internal problem" + t;
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
            if (Convert.ToInt32(mm) != 2)
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

                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND  c.APPNO='" + DropDownList2.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
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


                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
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

                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) BETWEEN '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND  c.APPNO='" + DropDownList3.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
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


                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) BETWEEN '" + dd + "' AND '" + dd1 + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
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


    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string dateString1 = e.Row.Cells[9].Text;
            string dateString2 = e.Row.Cells[11].Text;

            CultureInfo provider = CultureInfo.InvariantCulture;
            // It throws Argument null exception  

            string h = e.Row.Cells[9].Text;
            string h2 = e.Row.Cells[11].Text;
            if (h != "&nbsp;" && h2 != "&nbsp;")
            {
                // DateTime d1 = Convert.ToDateTime(e.Row.Cells[9].Text);
                DateTime d1 = DateTime.ParseExact(dateString1, "mm/dd/yyyy", provider);
                DateTime d2 = DateTime.ParseExact(dateString2, "mm/dd/yyyy", provider);
                /* if (birthDate.ToShortDateString() == "1/1/1900")
                 {
                     e.Row.Cells[1].Text = "null";
                 }*/
                int res = DateTime.Compare(d1, d2);
                // returns <0 since d1 is earlier than d2
                if (res == 0)
                {
                    e.Row.Cells[11].Text = "";
                }
            }


        }

    }
}