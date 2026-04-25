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
    static string ids;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             ids = "";
           
            if (Session["ID"] != null)
            {
                ids = Session["ID"].ToString();

                 bind2();
                bind(ids);
              
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
   
    public void bind(string id)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("select formid,CONCAT(formid,'/',name,'/',agentper) as demo from agent   where agentid IN(select formid from agent where  agentid='" + id + "' or formid='" + id + "') or formid='" + id + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList3.DataSource = ds.Tables[0];
        DropDownList3.DataTextField = "demo";
        DropDownList3.DataValueField = "formid";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("--Select--", "0"));
       

    }
    public void bind3(string agentid)
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
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select c.formid,c.name,c.location,c.block,c.plotno,r.paid,r.recid,r.mode,r.remark,c.agentid,a.name AS name1,r.date  from booking c LEFT JOIN bookrecipt r on r.formid=c.formid LEFT JOIN agent a on c.agentid=a.formid where c.agentid='" + agentid + "' AND c.location='" + DropDownList1.Text + "' AND r.date between '" + date1 + "' AND '" + date2 + "' AND c.secondstatus IN('Book','Hold')", con);


        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList3.Text != "--Select--")
        {
            string agentid = DropDownList3.SelectedValue.ToString();
            bind3(agentid);
        }
        else
        {
            string message = "Please Select Agnet Id";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
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
            this.bind(ids);

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