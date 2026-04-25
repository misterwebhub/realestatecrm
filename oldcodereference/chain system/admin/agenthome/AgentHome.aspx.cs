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
using System.Globalization;
using System.IO;
using System.Drawing;


public partial class admin_agenthome_AgentHome : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    static string id ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id = "";
            if (Session["ID"] != null)
            {
                id = Session["ID"].ToString();
                //Label13.Text = "heedrealestate";
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select name from agent where formid='" + id + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        Label1.Text = ds.Tables[0].Rows[0][0].ToString() + "( " + id + " )";
                        // bind2();
                        bind(id);
                    }
                }
            }
            else
            {
               // Response.Redirect("https://chhayakunj.com/admin.aspx");
            }
            
            
           
        }
    }
    public void bind(string id)
    {/*
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select c.formid,c.agentid,c.location,c.name,c.block,c.plotno,c.area,CAST((c.totalamount-c.discount+(c.totalamount*plc/100)) as INT) AS total,r.PAID,(CAST((c.totalamount-c.discount+(c.totalamount*plc/100)) as INT) -r.PAID) AS balance,c.booktype,c.date  from (select formid ,sum(paid) AS PAID from bookrecipt group by formid) AS r INNER JOIN booking  AS c ON c.formid=r.formid where c.agentid='" + id + "' AND c.secondstatus IN('Book','Hold')", con);
        

        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        GridView1.DataSource = ds;
        GridView1.DataBind();*/

    }
    
    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GridView1.AllowPaging = false;
            this.bind(id);

            GridView1.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }





    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        string script = "window.onload = function() { printGrid(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "printGrid", script, true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string s3 = TextBox2.Text;
        string dd1 = s3.Substring(0, 2);
        string mm1 = s3.Substring(3, 2);
        string yy1 = s3.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;
        string date2 = mm1 + "/" + dd1 + "/" + yy1;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select c.date3 AS 'DATE',c.CUSTREGNO as 'CUSTREGNO',SUBSTRING(c.NAMEDOBADDRESS,1,15) AS 'NAME',c.CONSAMOUNT AS 'TOTALAMOUNT',r.PAID AS 'PA',(c.CONSAMOUNT-r.PAID) AS 'BALANCE',c.APPNO,c.PLOTSIZE AS 'PLOTSIZE',c.plotno AS 'PLOTNO',c.regstatus AS 'STATUS',c.mobile AS 'MOBILE',c.booktype AS 'MODE',c.agentid AS 'AGENTID' from (select CUSTREGNO,sum(AMOUNTR) AS PAID from  wjstar1.recipt1 GROUP BY CUSTREGNO Having CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where date3 between '" + date1 + "' AND '" + date2 + "' AND agentid IN('"+id+"')  AND APPNO in(select arazi from chainarazi) )  ) AS r INNER JOIN wjstar1.customerreg1 AS c ON c.CUSTREGNO=r.CUSTREGNO", con);
        // SqlDataAdapter da = new SqlDataAdapter("select date3,CUSTREGNO,CONSAMOUNT,APPNO,plotno,PLOTSIZE,mobile,booktype,agentid from wjstar1.customerreg1 where date3 between '" + date1 + "' AND '" + date2 + "' AND agentid IS NOT NULL  AND APPNO in(select arazi from chainarazi)", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
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
    }
}