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
    static string s = ConfigurationManager.ConnectionStrings["amar9"].ConnectionString.ToString();
    static string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  Button1.Visible = false;
            bind();
            gridbind();
            Label3.Visible = false;
            TextBox26.Visible = false;
            Button3.Visible = false;
            if (Session["ID"] != null)
            {

              //  id = Session["ID"].ToString();
                // bind2();
               // bind(id);
               
            }
        }
    }
    
    
    public void gridbind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select formid,designation,name,salary from staff", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(" select DISTINCT designation,ID from staffdesignation order by ID asc", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
      
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataTextField = "designation";
        DropDownList1.DataValueField = "designation";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
        DropDownList2.DataSource = ds.Tables[0];
        DropDownList2.DataTextField = "designation";
        DropDownList2.DataValueField = "designation";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
        GridView2.DataSource = ds;
        GridView2.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string pan, cheque, adhar, profile;
            if (CheckBox1.Checked == true)
            {
                string formid = fetch();
                pan = Server.MapPath("~/admin/staff/pan/");
                cheque = Server.MapPath("~/admin/staff/cheque/");
                adhar = Server.MapPath("~/admin/staff/adhar/");
                profile = Server.MapPath("~/admin/staff/profile/");
                String panpath = "", chequepath = "", adharpath = "", profilepath = "";
                if (FileUpload1.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                   // FileUpload4.SaveAs(path1 + "slider4" + extension);
                    FileUpload1.SaveAs(adhar + formid + extension);
                    adharpath = adhar + formid + extension;
                }
                else
                {
                    adharpath = "";
                }
                if (FileUpload2.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName);
                    // FileUpload4.SaveAs(path1 + "slider4" + extension);
                    FileUpload2.SaveAs(pan + formid + extension);
                    panpath = pan + formid + extension;
                    
                }
                else
                {
                    panpath = "";
                }
                if (FileUpload3.HasFile)
                {

                   
                    string extension = System.IO.Path.GetExtension(FileUpload3.PostedFile.FileName);
                    // FileUpload4.SaveAs(path1 + "slider4" + extension);
                    FileUpload3.SaveAs(cheque + formid + extension);
                    chequepath = cheque + formid + extension;
                }
                else
                {
                    chequepath = "";
                }
                if (FileUpload4.HasFile)
                {

                 
                    string extension = System.IO.Path.GetExtension(FileUpload4.PostedFile.FileName);
                    // FileUpload4.SaveAs(path1 + "slider4" + extension);
                    FileUpload4.SaveAs(profile + formid + extension);
                    profilepath = profile + formid + extension;

                }
                else
                {
                    profilepath = "";
                }
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

                    string design = DropDownList1.SelectedValue.ToString();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into staff(formid  ,	designation  ,epfid  ,epfamt,	name  ,	father	 ,gender  ,	dob ,	address  ,	city  ,	state  ,	pincode  ,	mobile  ,	aletrmobile	 ,email  ,	noname	 ,noage	 ,relation  ,	noaddress  ,	occupation  ,	qualification  ,	adhar	 ,pan  ,	bankname  ,	branch  ,	account  ,	ifsc  ,	adharpath	 ,panpath  ,	chequepath  	,profilepath	 ,salary,doj )values('" + formid + "','" +design + "','" +TextBox24.Text + "',"+TextBox25.Text+",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList3.Text + "','" + date1 + "','" + TextBox22.Text + "','" + TextBox5.Text + "','" + TextBox3.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "','" + TextBox13.Text + "','" + TextBox14.Text + "','" + TextBox15.Text + "','" + TextBox16.Text + "','" + TextBox17.Text + "','" + TextBox18.Text + "','" + TextBox19.Text + "','" + TextBox20.Text + "','" + TextBox21.Text + "','" + adharpath + "','" + panpath + "','" + chequepath + "','" + profilepath + "',"+TextBox23.Text+",'"+DateTime.Now+"')", con);
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
                       // gridbind();
                       // bind(id);
                        TextBox17.BackColor = Color.White;
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
        SqlCommand cmd = new SqlCommand("select max(ID) from staff", con1);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                rcid = Convert.ToInt32(dr.GetValue(0));
            }
            rcid = rcid + 1;
            id = "CKE00" + rcid.ToString();

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
        SqlCommand cmd = new SqlCommand("delete from  staff where formid='" + id.Text + "'", con);
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
        GridView2.PageIndex = e.NewPageIndex;
        this.bind();
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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Label3.Visible = true;
        TextBox26.Visible = true;
        Button3.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select designation from staffdesignation where designation='" + TextBox26.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        int r = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                if (TextBox26.Text.Trim() == ds.Tables[0].Rows[j][0].ToString())
                {
                    r = 1;
                    break;
                }

            }
        }
        if (r == 0)
        {
            SqlCommand cmd = new SqlCommand("insert into staffdesignation (designation)values('"+TextBox26.Text+"')", con);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                TextBox26.Text = "";
                //  TextBox2.Text = "";
                bind();
                Label3.Visible = false;
                TextBox26.Visible = false;
                Button3.Visible = false;
            }
        }
        else
        {
            string message = "Designation Already Exist";
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
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label id = GridView2.Rows[e.RowIndex].FindControl("lbl_form1d") as Label;
        // TextBox name = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
        //TextBox city = GridView1.Rows[e.RowIndex].FindControl("txt_City") as TextBox;
        SqlConnection con;
        con = new SqlConnection(s);
        con.Open();
        //updating the record  
        SqlCommand cmd = new SqlCommand("delete from  staffdesignation where ID=" + id.Text + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        //GridView1.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        bind();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select formid,designation,name,salary from staff where designation='" + DropDownList2.SelectedValue.ToString() + "'", con);
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