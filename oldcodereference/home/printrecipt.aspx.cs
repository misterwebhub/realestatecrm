﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

public partial class new_form_printrecipt : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    string mob;
    static Double num = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
       // Label4.Text = Session["ID"].ToString();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

public void FUN()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select DATEOFCOM from wjstar1.customerreg1 where CUSTREGNO IN(select CUSTREGNO from wjstar1.recipt1 where RECIPT='" + TextBox1.Text + "')", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con1.Close();
        dateofcom = ds1.Tables[0].Rows[0][0].ToString();
        con1.Open();
    }
    public void print1()
    {
		FUN();
        Session["creg"] = TextBox3.Text;
        Session["ascname"] = TextBox2.Text;
        Session["recipt"] = TextBox1.Text;
        Session["asccode"] = TextBox4.Text;
        Session["date"] = TextBox19.Text;
        Session["dudate"] = TextBox20.Text;
        // Session["ndate"] = TextBox21.Text;
        Session["instno"] = TextBox7.Text;
        Session["endterm"] = TextBox8.Text;
        Session["ascaddr"] = TextBox9.Text;
        Session["planterm"] = TextBox11.Text;
        Session["mod"] = DropDownList1.Text;
        Session["amr"] = TextBox13.Text;
        Session["expr"] = TextBox14.Text;
        Session["subam"] = TextBox15.Text;
        Session["latecharge"] = TextBox16.Text;
        Session["assaddr"] = TextBox17.Text;
        Session["amwrd"] = TextBox18.Text;
        Session["ref"] = TextBox5.Text;
		Session["book"] = dateofcom;
        Session["tdp"] = Label10.Text;
        Session["tpdp"] = Label8.Text; 
        Session["tbdp"] = Label9.Text; 
        Session["rdp"] = Label12.Text; 
        Session["rpdp"] = Label13.Text; 
        Session["rbdp"] = Label14.Text;
        Session["balrec"] = Label27.Text;
        Session["chequebounce"] = Label26.Text;
        Session["chequeno"] = Label28.Text;

    }
    string dateofcom;
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter cmd = new SqlDataAdapter("select * from wjstar1.recipt1 where RECIPT='" + TextBox1.Text + "'", con1);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            con1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = "";
                TextBox5.Text = ds.Tables[0].Rows[0][21].ToString();
                TextBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                TextBox2.Text = ds.Tables[0].Rows[0][2].ToString();
                TextBox4.Text = ds.Tables[0].Rows[0][4].ToString();
                TextBox19.Text = ds.Tables[0].Rows[0][5].ToString();
                TextBox20.Text = ds.Tables[0].Rows[0][6].ToString();
                // TextBox21.Text = ds.Tables[0].Rows[0][7].ToString();
                TextBox7.Text = ds.Tables[0].Rows[0][8].ToString();
                TextBox8.Text = ds.Tables[0].Rows[0][9].ToString();
                TextBox9.Text = ds.Tables[0].Rows[0][10].ToString();
                TextBox11.Text = ds.Tables[0].Rows[0][11].ToString();
                DropDownList1.Text = ds.Tables[0].Rows[0][12].ToString();
                Label27.Text = ds.Tables[0].Rows[0][13].ToString();
                TextBox14.Text = ds.Tables[0].Rows[0][14].ToString();
                TextBox15.Text = ds.Tables[0].Rows[0][15].ToString();
                TextBox16.Text = ds.Tables[0].Rows[0][16].ToString();
                TextBox17.Text = ds.Tables[0].Rows[0][17].ToString();
                TextBox18.Text = ds.Tables[0].Rows[0][18].ToString();
             Label10.Text = ds.Tables[0].Rows[0][29].ToString();
             Label8.Text = ds.Tables[0].Rows[0][30].ToString();
             Label9.Text = ds.Tables[0].Rows[0][31].ToString();
             Label12.Text = ds.Tables[0].Rows[0][32].ToString();
             Label13.Text = ds.Tables[0].Rows[0][33].ToString();
             Label14.Text = ds.Tables[0].Rows[0][34].ToString();
             TextBox13.Text = ds.Tables[0].Rows[0][38].ToString();
             Label26.Text = ds.Tables[0].Rows[0][37].ToString();
             Label28.Text = ds.Tables[0].Rows[0][39].ToString();
             //Label14.Text = ds.Tables[0].Rows[0][34].ToString();
            
             con1.Open();
             SqlDataAdapter da1 = new SqlDataAdapter("select date3 from wjstar1.customerreg1 where CUSTREGNO='"+TextBox3.Text+"'", con1);
             DataSet ds1 = new DataSet();
             da1.Fill(ds1);
             con1.Close();
             Label29.Text = ds1.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                Label1.Text = "not find receipt";
            }

            con1.Close();

        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }

    }




    protected void Button3_Click(object sender, EventArgs e)
    {
      DateTime date56 = Convert.ToDateTime(Label29.Text);
         DateTime date57 = Convert.ToDateTime("01/09/2022");
         int result = DateTime.Compare(date56, date57);
		/* print1();
             Response.Redirect("~/home/print.aspx");*/
        // string relationship;
         if (result < 0)
         {
             //  print1();

             print1();
             Response.Redirect("~/home/print.aspx");
         }
         else
         {
              SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter cmd = new SqlDataAdapter("select chequenopay from wjstar1.recipt1 where RECIPT='" + TextBox1.Text + "'", con1);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            con1.Close();
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) == 0 || ds.Tables[0].Rows[0][0].ToString() == null)
            {

                Label1.Text = "Record Viewed Successfully";
               
            }
            else
            {
                print1();
                Response.Redirect("~/home/print.aspx");
            }
             
         }
       

    }
}