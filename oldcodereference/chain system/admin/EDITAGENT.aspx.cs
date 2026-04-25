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
using System.Drawing;
using System.IO;

public partial class admin_dr : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public static string bank1, pan1, adhar1, profile1, formid,agentid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  Button1.Visible = false;
             formid = Request.QueryString["Parameter"].ToString();
           // DropDownList1.Items.Add(formid);
             Label3.Text = formid;
             bind56();
            find(formid);
            gridbind(formid);
      
           
        }
    }
    public void bind56()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select formid,CONCAT(formid,'-->',name) as demo from agent", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataTextField = "demo";
        DropDownList1.DataValueField = "formid";
        DropDownList1.DataBind();
        con.Open();
        SqlDataAdapter da55 = new SqlDataAdapter("select agentid from agent where formid='" + formid + "'", con);
        DataSet ds55 = new DataSet();
        da55.Fill(ds55);
        con.Close();
        string dy="";
        if (ds55.Tables[0].Rows.Count > 0)
        {
            if (ds55.Tables[0].Rows[0][0].ToString() != "")
            {
                dy = ds55.Tables[0].Rows[0][0].ToString();
            }
        }
        DropDownList1.Items.Insert(0, new ListItem(dy, "0"));

    }
    
    public void find(string fom)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select name,CONCAT(name,'-->',percentage,'%') as fun from agnettype where percentage=CAST((select percentage from agnettype where name=(select rank from agent where formid='" + fom + "')) AS NUMERIC)", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select name,CONCAT(name,'-->',percentage,'%') as fun from agnettype", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        DropDownList2.DataSource = ds1.Tables[0];
        DropDownList2.DataTextField = "fun";
        DropDownList2.DataValueField = "name";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem(ds2.Tables[0].Rows[0][1].ToString(), ds2.Tables[0].Rows[0][0].ToString()));
    }
    public void gridbind(string form)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select name,father,gender  ,dob,password,address  ,city  ,state  ,pincode  ,mobile  ,aletrmobile  ,email  ,noname  ,noage  ,realtion  ,noaddress  ,occupation  ,qualification  ,adhar  ,pan  ,bankname  ,branch  ,account  ,ifsc  ,spname,agentper from agent where formid='" + form + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                TextBox1.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                TextBox1.Text ="";
            }
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                TextBox2.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                TextBox2.Text = "";
            }
            if (ds.Tables[0].Rows[0][2].ToString() != "")
            {
               DropDownList3.Text = ds.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                DropDownList3.Text = "";
            }
            if (ds.Tables[0].Rows[0][3].ToString() != "")
            {
               TextBox4.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            else
            {
                TextBox4.Text = "";
            }
            DateTime dt=Convert.ToDateTime(ds.Tables[0].Rows[0][3].ToString());
            //string date222 = "";
                        if (dt != null)
            {
                TextBox4.Text =dt.ToString("dd/MM/yyyy");
            }
            else
            {
                TextBox4.Text = "";
            }
            if (ds.Tables[0].Rows[0][4].ToString() != "")
            {
                TextBox23.Text = ds.Tables[0].Rows[0][4].ToString();
            }
            else
            {
                TextBox23.Text = "";
            }
            if (ds.Tables[0].Rows[0][5].ToString() != "")
            {
                TextBox22.Text = ds.Tables[0].Rows[0][5].ToString();
            }
            else
            {
                TextBox22.Text = "";
            }
            if (ds.Tables[0].Rows[0][6].ToString() != "")
            {
                TextBox5.Text = ds.Tables[0].Rows[0][6].ToString();
            }
            else
            {
                TextBox5.Text = "";
            }
            if (ds.Tables[0].Rows[0][7].ToString() != "")
            {
                TextBox3.Text = ds.Tables[0].Rows[0][7].ToString();
            }
            else
            {
                TextBox3.Text = "";
            }
            if (ds.Tables[0].Rows[0][8].ToString() != "")
            {
                TextBox6.Text = ds.Tables[0].Rows[0][8].ToString();
            }
            else
            {
                TextBox6.Text = "";
            }
            if (ds.Tables[0].Rows[0][9].ToString() != "")
            {
                TextBox7.Text = ds.Tables[0].Rows[0][9].ToString();
            }
            else
            {
                TextBox7.Text = "";
            }
            if (ds.Tables[0].Rows[0][10].ToString() != "")
            {
                TextBox8.Text = ds.Tables[0].Rows[0][10].ToString();
            }
            else
            {
                TextBox8.Text = "";
            }
            if (ds.Tables[0].Rows[0][11].ToString() != "")
            {
                TextBox9.Text = ds.Tables[0].Rows[0][11].ToString();
            }
            else
            {
                TextBox9.Text = "";
            }
            if (ds.Tables[0].Rows[0][12].ToString() != "")
            {
                TextBox10.Text = ds.Tables[0].Rows[0][12].ToString();
            }
            else
            {
                TextBox10.Text = "";
            }
            if (ds.Tables[0].Rows[0][13].ToString() != "")
            {
                TextBox11.Text = ds.Tables[0].Rows[0][13].ToString();
            }
            else
            {
                TextBox11.Text = "";
            }
            if (ds.Tables[0].Rows[0][14].ToString() != "")
            {
                TextBox12.Text = ds.Tables[0].Rows[0][14].ToString();
            }
            else
            {
                TextBox12.Text = "";
            }
            if (ds.Tables[0].Rows[0][15].ToString() != "")
            {
                TextBox13.Text = ds.Tables[0].Rows[0][15].ToString();
            }
            else
            {
                TextBox13.Text = "";
            }
            if (ds.Tables[0].Rows[0][16].ToString() != "")
            {
                TextBox14.Text = ds.Tables[0].Rows[0][16].ToString();
            }
            else
            {
                TextBox14.Text = "";
            }
            if (ds.Tables[0].Rows[0][17].ToString() != "")
            {
                TextBox15.Text = ds.Tables[0].Rows[0][17].ToString();
            }
            else
            {
                TextBox15.Text = "";
            }
            if (ds.Tables[0].Rows[0][18].ToString() != "")
            {
                TextBox16.Text = ds.Tables[0].Rows[0][18].ToString();
            }
            else
            {
                TextBox16.Text = "";
            }
            if (ds.Tables[0].Rows[0][19].ToString() != "")
            {
                TextBox17.Text = ds.Tables[0].Rows[0][19].ToString();
            }
            else
            {
                TextBox17.Text = "";
            }
            if (ds.Tables[0].Rows[0][20].ToString() != "")
            {
                TextBox18.Text = ds.Tables[0].Rows[0][20].ToString();
            }
            else
            {
                TextBox18.Text = "";
            }
            if (ds.Tables[0].Rows[0][21].ToString() != "")
            {
                TextBox19.Text = ds.Tables[0].Rows[0][21].ToString();
            }
            else
            {
                TextBox19.Text = "";
            }
            if (ds.Tables[0].Rows[0][22].ToString() != "")
            {
                TextBox20.Text = ds.Tables[0].Rows[0][22].ToString();
            }
            else
            {
                TextBox20.Text = "";
            }
            if (ds.Tables[0].Rows[0][23].ToString() != "")
            {
                TextBox21.Text = ds.Tables[0].Rows[0][23].ToString();
            }
            else
            {
                TextBox21.Text = "";
            }
            

        }
    }
    
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckBox1.Checked == true)
            {
               
               
                if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox7.Text == "")
                {
                    string message = "Please Enter Name or Father Name or Mobile";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }
                else
                {
                   string formid1=formid;
                   string date1;
                   if (TextBox4.Text == "")
                   {
                       date1 = null;
                   }
                   else
                   {
                       string s2 = TextBox4.Text;
                       string dd = s2.Substring(0, 2);
                       string mm = s2.Substring(3, 2);
                       string yy = s2.Substring(6, 4);
                       date1 = mm + "/" + dd + "/" + yy;
                   }
                   SqlConnection con = new SqlConnection(s);
                 //  string agentid = DropDownList1.SelectedValue.ToString();
                   string agentname = "";
                   con.Open();
                   SqlDataAdapter da55 = new SqlDataAdapter("select name from agent where formid='" +formid +"'", con);
                   DataSet ds55 = new DataSet();
                   da55.Fill(ds55);
                   con.Close();
                   if (ds55.Tables[0].Rows.Count > 0)
                   {
                       if (ds55.Tables[0].Rows[0][0].ToString() != "")
                       {
                           agentname = ds55.Tables[0].Rows[0][0].ToString();
                       }
                   }
                   string agenip = "";
                   con.Open();
                   SqlDataAdapter da5555 = new SqlDataAdapter("select spname from agent where agentid='" + DropDownList1.SelectedValue.ToString() + "'", con);
                   DataSet ds5555 = new DataSet();
                   da5555.Fill(ds5555);
                   con.Close();
                   if (ds5555.Tables[0].Rows.Count > 0)
                   {
                       if (ds5555.Tables[0].Rows[0][0].ToString() != "")
                       {
                           agenip = ds5555.Tables[0].Rows[0][0].ToString();
                       }
                   }
                   con.Open();
                   string agentperc = "";
                   string level = DropDownList2.SelectedValue.ToString();
                   SqlDataAdapter da555 = new SqlDataAdapter("select percentage from agnettype where name='" + level + "'", con);
                   DataSet ds555 = new DataSet();
                   da555.Fill(ds555);
                   con.Close();
                   if (ds555.Tables[0].Rows.Count > 0)
                   {
                       if (ds555.Tables[0].Rows[0][0].ToString() != "")
                       {
                           agentperc = ds555.Tables[0].Rows[0][0].ToString();
                       }
                   }
                   
                   
                   con.Open();
                   SqlCommand cmd = new SqlCommand("update agent set spname='"+agenip+"',agentid='" + DropDownList1.SelectedValue.ToString() + "',rank='" + level + "',name='" + TextBox1.Text + "',father='" + TextBox2.Text + "',gender='" + DropDownList3.Text + "'  ,dob='" + date1 + "',address='" + TextBox22.Text + "'  ,city='" + TextBox5.Text + "'  ,state='" + TextBox3.Text + "'  ,pincode='" + TextBox6.Text + "'  ,mobile='" + TextBox7.Text + "'  ,aletrmobile='" + TextBox8.Text + "'  ,email='" + TextBox9.Text + "'  ,noname='" + TextBox10.Text + "'  ,noage='" + TextBox11.Text + "'  ,realtion ='" + TextBox12.Text + "' ,noaddress='" + TextBox13.Text + "'  ,occupation='" + TextBox14.Text + "'  ,qualification ='" + TextBox15.Text + "' ,adhar='" + TextBox16.Text + "'  ,pan='" + TextBox17.Text + "'  ,bankname='" + TextBox18.Text + "'  ,branch= '" + TextBox19.Text + "' ,account='" + TextBox20.Text + "'  ,ifsc ='" + TextBox21.Text + "' ,agentper='" + agentperc + "' where formid='" + formid + "'", con);
                   int t = cmd.ExecuteNonQuery();
                   if (t == 1)
                   {
                       
                      // gridbind();
                      // bind();
                       Response.Redirect("~/admin/ADDAGENT.aspx");
                      
                   }
                   else
                   {
                       string message = "We got some error from server";
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


            }
            else
            {
                string message = "Please Check the Box";
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
        catch (Exception t)
        {
        }
    }
   
   
   
    
        
    
}