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
public partial class admin_agenthome_agentteamlist : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar9"].ConnectionString.ToString();
    static string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             id = "";
            if (Session["ID"] != null)
            {

                id = Session["ID"].ToString();
                // bind2();
                bind(id);
            }


        }
    }
    public void bind(string id)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
       // SqlDataAdapter da = new SqlDataAdapter("select formid,name,agentid,rank,mobile,pan ,bankname ,account  ,ifsc from agent where agentid IN(select formid from agent where  agentid='" + id + "' or formid='" + id + "') or formid='" + id + "'", con);
 SqlDataAdapter da = new SqlDataAdapter("WITH cte_org AS ( SELECT formid,name,agentid,rank,mobile,pan ,bankname ,account  ,ifsc FROM agent where formid='"+id+"' UNION ALL select e.formid,e.name,e.agentid,e.rank,e.mobile,e.pan ,e.bankname ,e.account  ,e.ifsc from agent e  JOIN cte_org p on p.formid=e.agentid)  SELECT * FROM cte_org", con); 

        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        GridView1.DataSource = ds;
        GridView1.DataBind();

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

protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bind(id);
    }





    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        string script = "window.onload = function() { printGrid(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "printGrid", script, true);
    }
}