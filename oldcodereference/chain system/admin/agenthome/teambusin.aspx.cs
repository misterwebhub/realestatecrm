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

public partial class admin_agenthome_selfbusin : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar9"].ConnectionString.ToString();
    public static string ids;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Session["ID"] != null)
            {
                ids = Session["ID"].ToString();

                 bind2();
               // bind(ids);
              
            }


        }
    }
    public void bind2()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select name from cklocation", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("--select--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

    }
   
    
    public void bind3()
    {
        string s2 = TextBox1.Text;
        string yy = s2.Substring(0, 4);
        string mm = s2.Substring(5, 2);
        string dd = s2.Substring(8, 2);
        string date1 = mm + "/" + dd + "/" + yy;
        string s3 = TextBox2.Text;
        string yy1 = s3.Substring(0, 4);
        string mm1 = s3.Substring(5, 2);
        string dd1 = s3.Substring(8, 2);
        string date2 = mm1 + "/" + dd1 + "/" + yy1;
        SqlConnection con = new SqlConnection(s);
       
		// SqlCommand da1 = new SqlCommand("create view amar AS WITH cte_org AS ( SELECT formid FROM agent where formid='" + ids + "' UNION ALL select e.formid from agent e  JOIN cte_org p on p.formid=e.agentid)  SELECT * FROM cte_org GO", con);
		//da1.ExecuteNonQuery();
		//con.Close();
       
		//SqlDataAdapter da1 = new SqlDataAdapter("select c.formid,c.name,c.location,c.block,c.plotno,r.paid,r.recid,r.mode,r.remark,c.agentid,r.date  from booking c INNER JOIN bookrecipt r on r.formid=c.formid where c.location='CHHAYA KUNJ SAJARI' AND r.date between '07/01/2023' AND '07/24/2023' AND c.agentid IN (SELECT formid FROM amar)", con);
		con.Open();
		       SqlDataAdapter da = new SqlDataAdapter("select c.formid,c.name,c.location,c.block,c.plotno,r.paid,r.recid,r.mode,r.remark,c.agentid,r.date  from booking c INNER JOIN bookrecipt r on r.formid=c.formid where c.location='" + DropDownList1.Text + "' AND r.date between '" + date1 + "' AND '" + date2 + "' AND c.secondstatus IN('Book','Hold') AND c.agentid IN (SELECT formid FROM amar)", con); 


        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
            bind3();
       
        
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
            this.bind3();

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
}