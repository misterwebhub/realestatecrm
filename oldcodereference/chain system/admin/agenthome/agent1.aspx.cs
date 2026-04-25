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

public partial class admin_agenthome_agent1 : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    static string id;
    protected void Page_Load(object sender, EventArgs e)
    {
       
            //  Button1.Visible = false;
            //bind();
            if(!IsPostBack)
			{
            if (Session["ID"] != null)
            {

                id = Session["ID"].ToString();
                // bind2();
                bind(id);
				gridbind();
            password();
            }
			}
        
    }
    public void password()
    {
        string allowedChars = "";

        allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

        allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";

        allowedChars += "1,2,3,4,5,6,7,8,9,0,@";

        char[] sep = { ',' };

        string[] arr = allowedChars.Split(sep);

        string passwordString = "";

        string temp = "";

        Random rand = new Random();

        for (int i = 0; i < 6; i++)
        {

            temp = arr[rand.Next(0, arr.Length)];

            passwordString += temp;

        }

        TextBox23.Text = passwordString;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select name,CONCAT(name,'-->',percentage,'%') as fun from agnettype where percentage<CAST((select percentage from agnettype where name=(select rank from agent where formid='" + DropDownList1.SelectedValue + "')) AS NUMERIC)", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        DropDownList2.DataSource = ds1.Tables[0];
        DropDownList2.DataTextField = "fun";
        DropDownList2.DataValueField = "name";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    public void gridbind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select formid,name,agentid,spname,rank,agentper,password from agent where agentid IN(select formid from agent where  agentid='" + id + "' or formid='" + id + "') or formid='" + id + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    public void bind(string id)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(" select formid ,CONCAT(formid,'-->',name) as demo from agent where agentid IN(select formid from agent where  agentid='" + id + "' or formid='" + id + "') or formid='" + id + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataTextField = "demo";
        DropDownList1.DataValueField = "formid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));

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
                    string formid = fetch();
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
                    string agentid = DropDownList1.SelectedValue.ToString();
                    string agentname = "";
                    con.Open();
                    SqlDataAdapter da55 = new SqlDataAdapter("select name from agent where formid='" + agentid + "'", con);
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
                    SqlCommand cmd = new SqlCommand("insert into agent(formid,agentid,rank,name,father,gender  ,dob,address  ,city  ,state  ,pincode  ,mobile  ,aletrmobile  ,email  ,noname  ,noage  ,realtion  ,noaddress  ,occupation  ,qualification  ,adhar  ,pan  ,bankname  ,branch  ,account  ,ifsc  ,spname,agentper,password )values('" + formid + "','" + agentid + "','" + level + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList3.Text + "','" + date1 + "','" + TextBox22.Text + "','" + TextBox5.Text + "','" + TextBox3.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "','" + TextBox13.Text + "','" + TextBox14.Text + "','" + TextBox15.Text + "','" + TextBox16.Text + "','" + TextBox17.Text + "','" + TextBox18.Text + "','" + TextBox19.Text + "','" + TextBox20.Text + "','" + TextBox21.Text + "','" + agentname + "','" + agentperc + "','" + TextBox23.Text + "')", con);
                    int t = cmd.ExecuteNonQuery();
                    if (t == 1)
                    {
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                        TextBox5.Text = "";
                        TextBox6.Text = "";
                        TextBox7.Text = "";
                        TextBox8.Text = "";
                        TextBox9.Text = "";
                        TextBox10.Text = "";
                        TextBox11.Text = "";
                        TextBox12.Text = "";
                        TextBox13.Text = "";
                        TextBox14.Text = "";
                        TextBox15.Text = "";
                        TextBox16.Text = "";
                        TextBox17.Text = "";
                        TextBox18.Text = "";
                        TextBox19.Text = "";
                        TextBox20.Text = "";
                        TextBox21.Text = "";
                        gridbind();
                        bind(id);
                        TextBox17.BackColor = Color.White;
						 string message = "Agent Added Successfully";
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
    public string fetch()
    {
        string id = "";


        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        int rcid = 0;
        SqlCommand cmd = new SqlCommand("select max(ID) from agent", con1);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                rcid = Convert.ToInt32(dr.GetValue(0));
            }
            rcid = rcid + 1;
            id = "CHK00" + rcid.ToString();

        }
        con1.Close();
        return id;

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        Label1.Text = GridView1.SelectedRow.Cells[1].Text;
        /*txtName.Text = row.Cells[1].Text;
        txtCountry.Text = row.Cells[2].Text;
        pnlShowHide.Visible = true;*/
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_form1d") as Label;
        // TextBox name = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
        //TextBox city = GridView1.Rows[e.RowIndex].FindControl("txt_City") as TextBox;
        SqlConnection con;
        con = new SqlConnection(s);
        con.Open();
        //updating the record  
        SqlCommand cmd = new SqlCommand("delete from  agent where formid='" + id.Text + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        //GridView1.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        gridbind();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.gridbind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "views")
        {
            // Get the row selected and its index
            GridViewRow selected = (GridViewRow)((Control)(e.CommandSource)).Parent.Parent;
            int index = selected.RowIndex;

            // save the row index as it is needed to focus on the row when the users comes back to
            // this page
            Session["ContactRowIndex"] = index;
            // redirect the user to contact details screen for the contact chosen
            Response.Redirect(e.CommandArgument.ToString());
        }
    }

}