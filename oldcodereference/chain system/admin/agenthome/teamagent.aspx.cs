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
public partial class admin_agenthome_agentself : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
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
        SqlDataAdapter da = new SqlDataAdapter("WITH demo AS (SELECT  formid,name,agentid,rank,mobile,pan ,bankname ,account  ,ifsc,0 as lvl  from agent WHERE formid ='" + id + "' UNION ALL SELECT t.formid,t.name,t.agentid,t.rank,t.mobile,t.pan ,t.bankname ,t.account  ,t.ifsc,c.lvl-1 FROM demo c JOIN agent t ON c.agentid =  t.formid ) SELECT formid,name,agentid,rank,mobile,pan ,bankname ,account  ,ifsc FROM  demo order by lvl DESC", con);


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





    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        string script = "window.onload = function() { printGrid(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "printGrid", script, true);
    }
}