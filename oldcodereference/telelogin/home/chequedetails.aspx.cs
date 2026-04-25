﻿
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


public partial class _30neeghanew_chequedetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
		 if (!IsPostBack)
		 {
 DropDownList1.Items.Clear();
             SqlConnection con = new SqlConnection(s);
             con.Open();
             SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
             DataSet ds = new DataSet();
             da.Fill(ds);
             con.Close();
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
             }
             con.Close();
		 }
    }
    public void bindgrid()
    {
        Label1.Text = "";
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
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter(" Select c.ID	,c.CUSTREGNO,c.NAME,c.ARAZI,c.PLOTNO,c.PLOTSIZE,c.CDATE,c.CHEQUENO,c.CAMOUNT,c.CHEQUETYPE,c.STATUS,u.CHECKBY,c.paiddate,CASE  WHEN (u.CONSAMOUNT-p.AMT-rc.pmt)<0 THEN '0' WHEN (u.CONSAMOUNT-p.AMT-rc.pmt)>0 THEN u.CONSAMOUNT-p.AMT-rc.pmt END 'PENDING' from chequedetails AS c inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt from wjstar1.recipt1 group By CUSTREGNO) as rc ON c.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CAMOUNT) AS 'AMT' from chequedetails where  CHEQUETYPE='MENTION' group By CUSTREGNO ) AS p ON c.CUSTREGNO=p.CUSTREGNO INNER JOIN wjstar1.customerreg1 AS u ON u.CUSTREGNO=c.CUSTREGNO where  c.CDATE between '" + date1 + "' AND '" + date2 + "' ORDER BY c.CDATE ASC ", con1);
            //SqlDataAdapter da = new SqlDataAdapter("Select c.ID	,c.CUSTREGNO,c.NAME,c.ARAZI,c.PLOTNO,c.PLOTSIZE,c.CDATE,c.CHEQUENO,c.CAMOUNT,c.CHEQUETYPE,c.STATUS,u.CHECKBY,c.paiddate from chequedetails AS c INNER JOIN wjstar1.customerreg1 AS u ON u.CUSTREGNO=c.CUSTREGNO where  c.CDATE between 
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("Select SUM(CAMOUNT) from chequedetails where CDATE between '" + date1 + "' AND '" + date2 + "' ", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString()) != 0)
                {
                    Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
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
        }
        catch (Exception ty)
        {
            Label1.Text = "Internal Error Found" + ty;
        }
    }
	 public void bindgrid2()
    {
        Label1.Text = "";
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
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter(" Select c.ID	,c.CUSTREGNO,c.NAME,c.ARAZI,c.PLOTNO,c.PLOTSIZE,c.CDATE,c.CHEQUENO,c.CAMOUNT,c.CHEQUETYPE,c.STATUS,u.CHECKBY,c.paiddate,CASE  WHEN (u.CONSAMOUNT-p.AMT-rc.pmt)<0 THEN '0' WHEN (u.CONSAMOUNT-p.AMT-rc.pmt)>0 THEN u.CONSAMOUNT-p.AMT-rc.pmt END 'PENDING' from chequedetails AS c inner join (select CUSTREGNO,sum(AMOUNTR) AS pmt from wjstar1.recipt1 group By CUSTREGNO) as rc ON c.CUSTREGNO=rc.CUSTREGNO inner join (select CUSTREGNO,sum(CAMOUNT) AS 'AMT' from chequedetails where  CHEQUETYPE='MENTION' group By CUSTREGNO ) AS p ON c.CUSTREGNO=p.CUSTREGNO INNER JOIN wjstar1.customerreg1 AS u ON u.CUSTREGNO=c.CUSTREGNO where  c.CDATE between '" + date1 + "' AND '" + date2 + "' AND c.ARAZI='"+DropDownList1.Text+"'  ORDER BY c.CDATE ASC ", con1);
            //SqlDataAdapter da = new SqlDataAdapter("Select c.ID	,c.CUSTREGNO,c.NAME,c.ARAZI,c.PLOTNO,c.PLOTSIZE,c.CDATE,c.CHEQUENO,c.CAMOUNT,c.CHEQUETYPE,c.STATUS,u.CHECKBY,c.paiddate from chequedetails AS c INNER JOIN wjstar1.customerreg1 AS u ON u.CUSTREGNO=c.CUSTREGNO where  c.CDATE between 
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("Select SUM(CAMOUNT) from chequedetails where CDATE between '" + date1 + "' AND '" + date2 + "' AND ARAZI='"+DropDownList1.Text+"' ", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString()) != 0)
                {
                    Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
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
        }
        catch (Exception ty)
        {
            Label1.Text = "Internal Error Found" + ty;
        }
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
	protected void Button2_Click(object sender, EventArgs e)
    {
        bindgrid2();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string f = e.Row.Cells[11].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "MENTION")
                {
                    e.Row.Cells[11].ForeColor = Color.Red;
                }


            }
        }
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindgrid();

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection con = new SqlConnection(s);

        int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["ID"].ToString());

        DropDownList status = GridView1.Rows[e.RowIndex].FindControl("STATUS") as DropDownList;
       // DropDownList type2 = GridView3.Rows[e.RowIndex].FindControl("CHEQUETYPE") as DropDownList;
        TextBox paid = GridView1.Rows[e.RowIndex].FindControl("paiddate") as TextBox;
        String date = paid.Text;
        string s2 = date;
        string date1;
        if (s2 != "")
        {
            string yy = s2.Substring(0, 4);
            string mm = s2.Substring(5, 2);
            string dd = s2.Substring(8, 2);
            date1 = mm + "/" + dd + "/" + yy;
        }
        else
        {
            date1 = null;
        }
        SqlCommand cmd = new SqlCommand("update chequedetails set STATUS='" + status.Text + "',paiddate='" + date1 + "' where ID=" + id + "", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        GridView1.EditIndex = -1;
        bindgrid();  
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindgrid();

    }
}