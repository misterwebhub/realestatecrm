using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Drawing;



public partial class Detail : System.Web.UI.Page
{
  public static Double latemipay,lateemipayment,payment,dpbalpayment,emipayment,balpayment,sumdppaid,sumemipaid,pendingemi,emidetails,pendingemi2;
    public static string status;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String id = "";
            Label44.Visible = false;
            Label48.Visible = false;
            Label49.Visible = false;
            DropDownList4.Visible = false;
           
                id = Session["idr"].ToString();
               // Button2.Visible = false;
                //id = "Ashok8396";
              // id = "heedrealestate";
                bind(id);
               
           
           
            find();
            
        }
    
    }
    public void bind(String id)
    {
        try
        {

            // Button2.Visible = false;
            Label48.Visible = false;
            Label49.Visible = false;
            DropDownList3.Items.Add(id);


        }
        catch (Exception t)
        {
            Label1.Text = "internal problem" + t;
        }
    }
    public void find()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT arazino from wjstar1.ploted1", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                // DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                DropDownList2.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    Double recpaidamount = 0, overamount = 0, dpdemo = 0, emidemo = 0, recamountcustomer = 0, totalamountcustomer = 0;
    public void allpaid(String user1)
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

        SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby,RECIPT from wjstar1.recipt1 where status='PAID' AND usertype='" + user1 + "' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='Cancel'))) order by RECIPT,DATE1 ASC", con1);
        DataSet ds = new DataSet();
        cmd.Fill(ds);
       // GridView1.DataSource = ds;
       // GridView1.DataBind();
        con1.Close();
        DataTable paiddt = new DataTable();

        paiddt.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("DPAMOUNT",typeof(string)),new DataColumn("EMIAMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string)),new DataColumn("FIXEDEMI",typeof(int))});
        DataRow dr1 = paiddt.NewRow();
        dr1 = null;
        string reg = "";
        payment = 0;
        sumdppaid = 0;
        sumemipaid = 0;
        dpbalpayment = 0;
        emipayment = 0;
        balpayment = 0;
        Double recpaidamount = 0, overamount = 0, dpdemo = 0, emidemo = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                reg = "";
                dpbalpayment = 0;
                emipayment = 0;
                balpayment = 0;
                dpdemo = 0;
                emidemo = 0;
                overamount = 0;
                recpaidamount = 0;
                reg = ds.Tables[0].Rows[i][0].ToString();
                dr1 = paiddt.NewRow();
                emical(reg);


                String dty = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                string s10 = dty;
                string dd10 = s10.Substring(0, 2);
                string mm10 = s10.Substring(3, 2);
                string yy10 = s10.Substring(6, 4);
                string date10 = mm10 + "/" + dd10 + "/" + yy10;
                con1.Open();

                SqlDataAdapter cmd9 = new SqlDataAdapter("select RECIPT from wjstar1.recipt1 where status='PAID' AND (DATE1 = '" + date10 + "') AND CUSTREGNO='" + reg + "' ORDER BY RECIPT ASC", con1);
                DataSet ds9 = new DataSet();
                cmd9.Fill(ds9);
                con1.Close();
               
                Double fix = 0;
                String dpty = "";
                if (ds9.Tables[0].Rows.Count > 0)
                {
                    if (ds9.Tables[0].Rows.Count != 1)
                    {
                        for (int k = 0; k < ds9.Tables[0].Rows.Count; k++)
                        {
                            int rc = Convert.ToInt32(ds9.Tables[0].Rows[k][0].ToString());
                            con1.Open();
                            SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (RECIPT < " + rc + ") AND CUSTREGNO='" + reg + "'", con1);
                            DataSet ds7 = new DataSet();
                            cmd7.Fill(ds7);
                            con1.Close();
                            if (ds7.Tables[0].Rows.Count > 0)
                            {
                                if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                {
                                    recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                }
                                else
                                {
                                    recamountcustomer = 0;
                                }

                            }
                            dpbalpayment = Convert.ToDouble(Label16.Text);
                            fix = pendingemi2;
                            //fix = Convert.ToDouble(Label23.Text);
                            //String drt = Label23.Text;
                            if (recamountcustomer <= dpbalpayment)
                            {

                                recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                totalamountcustomer = recpaidamount + recamountcustomer;
                                if (totalamountcustomer <= dpbalpayment)
                                {
                                    dpdemo = recpaidamount;
                                    emidemo = 0;
                                    fix = 0;
                                }
                                else
                                {
                                    overamount = totalamountcustomer - dpbalpayment;
                                    dpdemo = recpaidamount - overamount;
                                    emidemo = overamount;

                                    fix = pendingemi2;
                                }
                                dr1["DPAMOUNT"] = dpdemo;
                            }
                            else
                            {
                                dpdemo = 0;
                                dr1["DPAMOUNT"] = "COMPLETED";
                                recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                emidemo = recpaidamount;
                                fix = pendingemi2;
                            }
                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                            dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                            dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                            
                            sumdppaid = sumdppaid + dpdemo;
                            dr1["EMIAMOUNT"] = emidemo;
                            sumemipaid = sumemipaid + emidemo;
                            dr1["LATE_EMI"] = latemipay;
                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                          //  //payment = payment + lateemipayment;
                            dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                            statusragistry(reg);
                            dr1["STATUS"] = status;
                            dr1["FIXEDEMI"] = fix;
                            paiddt.Rows.Add(dr1);
                            dr1 = paiddt.NewRow();
                            if (k != ds9.Tables[0].Rows.Count - 1)
                            {
                               // i = i + 1;
                               // continue;
//k = k + 1;
								break;

                            }
                            recpaidamount = 0;
                        }
                    }
                    else
                    {

                        recpaidamount = 0;
                        con1.Open();
                        SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (DATE1 < '" + date10 + "') AND CUSTREGNO='" + reg + "'", con1);
                        DataSet ds7 = new DataSet();
                        cmd7.Fill(ds7);
                        con1.Close();
                        if (ds7.Tables[0].Rows.Count > 0)
                        {
                            if (ds7.Tables[0].Rows[0][0].ToString() != "")
                            {
                                recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                            }
                            else
                            {
                                recamountcustomer = 0;
                            }

                        }
                        dpbalpayment = Convert.ToDouble(Label16.Text);
                        fix = pendingemi2;

                        if (recamountcustomer <= dpbalpayment)
                        {

                            recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                            totalamountcustomer = recpaidamount + recamountcustomer;
                            if (totalamountcustomer <= dpbalpayment)
                            {
                                dpdemo = recpaidamount;
                                emidemo = 0;
                                fix = 0;
                            }
                            else
                            {
                                overamount = totalamountcustomer - dpbalpayment;
                                dpdemo = recpaidamount - overamount;
                                emidemo = overamount;

                                fix = pendingemi2;
                            }
                            dr1["DPAMOUNT"] = dpdemo;
                        }
                        else
                        {
                            dpdemo = 0;
                            dr1["DPAMOUNT"] = "COMPLETED";
                            recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                            emidemo = recpaidamount;
                            fix = pendingemi2;
                        }
                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                        dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                        //dr1["DPAMOUNT"] = dpdemo;
                        sumdppaid = sumdppaid + dpdemo;
                        dr1["EMIAMOUNT"] = emidemo;
                        sumemipaid = sumemipaid + emidemo;
                        dr1["LATE_EMI"] = latemipay;
                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                       // //payment = payment + lateemipayment;
                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                        statusragistry(reg);
                        dr1["STATUS"] = status;
                        dr1["FIXEDEMI"] = fix;
                        paiddt.Rows.Add(dr1);

                    }

                }





            }
        }
        GridView1.DataSource = paiddt;
        GridView1.DataBind();

        DataTable demo = new DataTable();
        demo.Columns.AddRange(new DataColumn[4] { new DataColumn("REGNO", typeof(string)), new DataColumn("amount", typeof(int)), new DataColumn("fixedpay", typeof(int)), new DataColumn("STATUSP", typeof(string)) });
        DataRow dr2 = demo.NewRow();

        Double finalfixed = 0, otherfix = 0, comfix = 0, dm = 0;
        String st = "";
        for (int j = 0; j < paiddt.Rows.Count; j++)
        {


            int c = 0;
            Double emifi = 0;
            st = "";
            for (int h = 0; h < demo.Rows.Count; h++)
            {
                if (demo.Rows[h][0].ToString() == paiddt.Rows[j][0].ToString())
                {
                    c = 1;

                    dm = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                    // dr2["amount"] = dm;
                    string find = "REGNO = '" + paiddt.Rows[j][0].ToString() + "'";
                    //find out id  
                    DataRow[] resultupdate = demo.Select(find);
                    //update row  
                    resultupdate[0]["amount"] = dm;
                    resultupdate[0]["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                   // resultupdate[0]["STATUSP"] =paiddt.Rows[j][8].ToString();
                    //Accept Changes  
                    demo.AcceptChanges();
                    break;
                }




            }
            if (c == 0)
            {
                String hu = paiddt.Rows[j][0].ToString();
                st = paiddt.Rows[j][8].ToString();
                dr2["REGNO"] = hu;
                emifi = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                dr2["amount"] = emifi;
                dr2["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                dr2["STATUSP"] =paiddt.Rows[j][8].ToString();

                demo.Rows.Add(dr2);
                dr2 = demo.NewRow();
            }
            otherfix = otherfix + Convert.ToDouble(paiddt.Rows[j][4].ToString());



        }
        int count = 0;
        for (int j = 0; j < demo.Rows.Count; j++)
        {
            finalfixed = finalfixed + Convert.ToDouble(demo.Rows[j][1].ToString());
            //payment = payment + Convert.ToDouble(demo.Rows[j][2].ToString());
            if (Convert.ToDouble(demo.Rows[j][1].ToString()) != 0)
            {
                count = count + 1;
            }
            if (demo.Rows[j][3].ToString() == "completed")
            {
                comfix = comfix + Convert.ToDouble(demo.Rows[j][1].ToString());
            }


        }
        Label47.Text = count.ToString();
        //Label29.Text = payment.ToString();
        Label30.Text = sumdppaid.ToString();
        //  finalfixed = finalfixed -first;
        Label31.Text = finalfixed.ToString();


        Label45.Text = (otherfix - finalfixed).ToString();
        Label46.Text = comfix.ToString();
          Double extra = 0;
          extra = otherfix - finalfixed;
          if (extra >= 0)
          {
              Label45.Text = extra.ToString();
              Label45.ForeColor = System.Drawing.Color.Green;
          }
          else
          {
              Label45.Text = extra.ToString();
              Label45.ForeColor = System.Drawing.Color.Red;
          }
        SqlConnection con2 = new SqlConnection(s);
        con2.Open();
       /* Double extra = 0;
        extra = sumemipaid - finalfixed;
        if (extra >= 0)
        {
            Label45.Text = extra.ToString();
            Label45.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            Label45.Text = extra.ToString();
            Label45.ForeColor = System.Drawing.Color.Red;
        }*/
       // Label45.Text = (sumemipaid - finalfixed).ToString();
        
       
    }
   public void  statusragistry(string reg)
    {
        status = "";
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();

        SqlDataAdapter cmd = new SqlDataAdapter("select regstatus from wjstar1.customerreg1 where  CUSTREGNO='"+reg+"'", con1);
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        // GridView1.DataSource = ds;
        // GridView1.DataBind();
        con1.Close();
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            status = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            status = "";
        }

    }
  

   public void singlepaid(string user)
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
       if (user != "ALL USER")
       {
           if (DropDownList2.Text != "ALL ARAZI")
           {
               if (DropDownList2.Text != "152")
               {
                   SqlConnection con1 = new SqlConnection(s);
                   con1.Open();

                   SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby,RECIPT from wjstar1.recipt1 where status='PAID' AND usertype='" + user + "' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))) order by RECIPT,DATE1 ASC", con1);
                   DataSet ds = new DataSet();
                   cmd.Fill(ds);
                   // GridView1.DataSource = ds;
                   // GridView1.DataBind();
                   con1.Close();
                   DataTable paiddt = new DataTable();

                   paiddt.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", 

typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("DPAMOUNT",typeof(string)),new DataColumn("EMIAMOUNT",typeof(string)),new DataColumn("LATE_EMI", 

typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn

("STATUS",typeof(string)),new DataColumn("FIXEDEMI",typeof(int))});
                   DataRow dr1 = paiddt.NewRow();
                   dr1 = null;
                   string reg = "";
                   payment = 0;
                   sumdppaid = 0;
                   sumemipaid = 0;
                   dpbalpayment = 0;
                   emipayment = 0;
                   balpayment = 0;
                   Double recpaidamount = 0, overamount = 0, dpdemo = 0, emidemo = 0;
                   if (ds.Tables[0].Rows.Count > 0)
                   {
                       for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                       {
                           reg = "";
                           dpbalpayment = 0;
                           emipayment = 0;
                           balpayment = 0;
                           dpdemo = 0;
                           emidemo = 0;
                           overamount = 0;
                           recpaidamount = 0;
                           reg = ds.Tables[0].Rows[i][0].ToString();
                           dr1 = paiddt.NewRow();
                           emical(reg);


                           String dty = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                           string s10 = dty;
                           string dd10 = s10.Substring(0, 2);
                           string mm10 = s10.Substring(3, 2);
                           string yy10 = s10.Substring(6, 4);
                           string date10 = mm10 + "/" + dd10 + "/" + yy10;
                           con1.Open();

                           SqlDataAdapter cmd9 = new SqlDataAdapter("select RECIPT from wjstar1.recipt1 where status='PAID' AND (DATE1 = '" +

date10 + "') AND CUSTREGNO='" + reg + "' ORDER BY RECIPT ASC", con1);
                           DataSet ds9 = new DataSet();
                           cmd9.Fill(ds9);
                           con1.Close();
                    
                           Double fix = 0;
                           if (ds9.Tables[0].Rows.Count > 0)
                           {
                               if (ds9.Tables[0].Rows.Count != 1)
                               {
                                   for (int k = 0; k < ds9.Tables[0].Rows.Count; k++)
                                   {
                                       int rc = Convert.ToInt32(ds9.Tables[0].Rows[k][0].ToString());
                                       con1.Open();
                                       SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (RECIPT < " + rc + ") AND CUSTREGNO='" + reg + "'", con1);
                                       DataSet ds7 = new DataSet();
                                       cmd7.Fill(ds7);
                                       con1.Close();
                                       if (ds7.Tables[0].Rows.Count > 0)
                                       {
                                           if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                           {
                                               recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                           }
                                           else
                                           {
                                               recamountcustomer = 0;
                                           }

                                       }
                                       dpbalpayment = Convert.ToDouble(Label16.Text);
                                       fix = pendingemi2;
                                       //fix = Convert.ToDouble(Label23.Text);
                                       //String drt = Label23.Text;
                                       if (recamountcustomer <= dpbalpayment)
                                       {

                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           totalamountcustomer = recpaidamount + recamountcustomer;
                                           if (totalamountcustomer <= dpbalpayment)
                                           {
                                               dpdemo = recpaidamount;
                                               emidemo = 0;
                                               fix = 0;
                                           }
                                           else
                                           {
                                               overamount = totalamountcustomer - dpbalpayment;
                                               dpdemo = recpaidamount - overamount;
                                               emidemo = overamount;

                                               fix = pendingemi2;
                                           }
                                           dr1["DPAMOUNT"] = dpdemo;
                                       }
                                       else
                                       {
                                           dpdemo = 0;
                                           dr1["DPAMOUNT"] = "COMPLETED";
                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           emidemo = recpaidamount;
                                           fix = pendingemi2;
                                       }
                                       dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                       dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                       dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                     //  dr1["DPAMOUNT"] = dpdemo;
                                       sumdppaid = sumdppaid + dpdemo;
                                       dr1["EMIAMOUNT"] = emidemo;
                                       sumemipaid = sumemipaid + emidemo;
                                       dr1["LATE_EMI"] = latemipay;
                                       dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                      // payment = payment + lateemipayment;
                                       dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                       statusragistry(reg);
                                       dr1["STATUS"] = status;
                                       dr1["FIXEDEMI"] = fix;
                                       paiddt.Rows.Add(dr1);
                                       dr1 = paiddt.NewRow();
                                       if (k != ds9.Tables[0].Rows.Count - 1)
                                       {
                                           //i = i + 1;
                                          // continue;
										   break;

                                       }
                                       recpaidamount = 0;
                                   }
                               }
                               else
                               {

                                   recpaidamount = 0;
                                   con1.Open();
                                   SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (DATE1 < '" + date10 + "') AND CUSTREGNO='" + reg + "'", con1);
                                   DataSet ds7 = new DataSet();
                                   cmd7.Fill(ds7);
                                   con1.Close();
                                   if (ds7.Tables[0].Rows.Count > 0)
                                   {
                                       if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                       {
                                           recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                       }
                                       else
                                       {
                                           recamountcustomer = 0;
                                       }

                                   }
                                   dpbalpayment = Convert.ToDouble(Label16.Text);
                                   fix = pendingemi2;

                                   if (recamountcustomer <= dpbalpayment)
                                   {

                                       recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                       totalamountcustomer = recpaidamount + recamountcustomer;
                                       if (totalamountcustomer <= dpbalpayment)
                                       {
                                           dpdemo = recpaidamount;
                                           emidemo = 0;
                                           fix = 0;
                                       }
                                       else
                                       {
                                           overamount = totalamountcustomer - dpbalpayment;
                                           dpdemo = recpaidamount - overamount;
                                           emidemo = overamount;

                                           fix = pendingemi2;
                                       }
                                       dr1["DPAMOUNT"] = dpdemo;
                                   }
                                   else
                                   {
                                       dpdemo = 0;
                                       dr1["DPAMOUNT"] = "COMPLETED";
                                       recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                       emidemo = recpaidamount;
                                       fix = pendingemi2;
                                   }
                                   dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                   dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                   dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                //   dr1["DPAMOUNT"] = dpdemo;
                                   sumdppaid = sumdppaid + dpdemo;
                                   dr1["EMIAMOUNT"] = emidemo;
                                   sumemipaid = sumemipaid + emidemo;
                                   dr1["LATE_EMI"] = latemipay;
                                   dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                   //payment = payment + lateemipayment;
                                   dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                   statusragistry(reg);
                                   dr1["STATUS"] = status;
                                   dr1["FIXEDEMI"] = fix;
                                   paiddt.Rows.Add(dr1);

                               }

                           }





                       }
                   }
                   GridView1.DataSource = paiddt;
                   GridView1.DataBind();

                   DataTable demo = new DataTable();
                   demo.Columns.AddRange(new DataColumn[4] { new DataColumn("REGNO", typeof(string)), new DataColumn("amount", typeof(int)), new DataColumn("fixedpay", typeof(int)), new DataColumn("STATUSP", typeof(string)) });
                   DataRow dr2 = demo.NewRow();

                   Double finalfixed = 0, otherfix = 0, comfix = 0, dm = 0;
                   String st = "";
                   for (int j = 0; j < paiddt.Rows.Count; j++)
                   {


                       int c = 0;
                       Double emifi = 0;
                       st = "";
                       for (int h = 0; h < demo.Rows.Count; h++)
                       {
                           if (demo.Rows[h][0].ToString() == paiddt.Rows[j][0].ToString())
                           {
                               c = 1;

                               dm = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                               // dr2["amount"] = dm;
                               string find = "REGNO = '" + paiddt.Rows[j][0].ToString() + "'";
                               //find out id  
                               DataRow[] resultupdate = demo.Select(find);
                               //update row  
                               resultupdate[0]["amount"] = dm;
                               resultupdate[0]["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                               // resultupdate[0]["STATUSP"] =paiddt.Rows[j][8].ToString();
                               //Accept Changes  
                               demo.AcceptChanges();
                               break;
                           }




                       }
                       if (c == 0)
                       {
                           String hu = paiddt.Rows[j][0].ToString();
                           st = paiddt.Rows[j][8].ToString();
                           dr2["REGNO"] = hu;
                           emifi = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                           dr2["amount"] = emifi;
                           dr2["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                           dr2["STATUSP"] = paiddt.Rows[j][8].ToString();

                           demo.Rows.Add(dr2);
                           dr2 = demo.NewRow();
                       }
                       otherfix = otherfix + Convert.ToDouble(paiddt.Rows[j][4].ToString());



                   }
                   int count = 0;
                   for (int j = 0; j < demo.Rows.Count; j++)
                   {
                       finalfixed = finalfixed + Convert.ToDouble(demo.Rows[j][1].ToString());
                       //payment = payment + Convert.ToDouble(demo.Rows[j][2].ToString());
                       if (Convert.ToDouble(demo.Rows[j][1].ToString()) != 0)
                       {
                           count = count + 1;
                       }
                       if (demo.Rows[j][3].ToString() == "completed")
                       {
                           comfix = comfix + Convert.ToDouble(demo.Rows[j][1].ToString());
                       }


                   }
                   Label47.Text = count.ToString();
                   //Label29.Text = payment.ToString();
                   Label30.Text = sumdppaid.ToString();
                   //  finalfixed = finalfixed -first;
                   Label31.Text = finalfixed.ToString();


                   Label45.Text = (otherfix - finalfixed).ToString();
                   Label46.Text = comfix.ToString();
                   Double extra = 0;
                   extra = otherfix - finalfixed;
                   if (extra >= 0)
                   {
                       Label45.Text = extra.ToString();
                       Label45.ForeColor = System.Drawing.Color.Green;
                   }
                   else
                   {
                       Label45.Text = extra.ToString();
                       Label45.ForeColor = System.Drawing.Color.Red;
                   }
                  
               }
               else
               {
                   if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                   {
                       payment = 0;
                       SqlConnection con1 = new SqlConnection(s);
                       con1.Open();

                       SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby,RECIPT from wjstar1.recipt1 where status='PAID' AND usertype='" + user + "' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='Cancel'))) order by RECIPT,DATE1 ASC", con1);
                       DataSet ds = new DataSet();
                       cmd.Fill(ds);
                       //GridView1.DataSource = ds;
                       //GridView1.DataBind();
                       con1.Close();

                       DataTable paiddt = new DataTable();
                       paiddt.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),new DataColumn

("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("DPAMOUNT",typeof(string)),new DataColumn("EMIAMOUNT",typeof(string)),new DataColumn("LATE_EMI", 

typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn

("STATUS",typeof(string)),new DataColumn("FIXEDEMI",typeof(int))});
                       DataRow dr1 = paiddt.NewRow();
                       dr1 = null;
                       string reg = "";
                       payment = 0;
                       sumdppaid = 0;
                       sumemipaid = 0;
                       dpbalpayment = 0;
                       emipayment = 0;
                       balpayment = 0;
                       Double recpaidamount = 0, overamount = 0, dpdemo = 0, emidemo = 0;
                       if (ds.Tables[0].Rows.Count > 0)
                       {
                           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                           {
                               reg = "";
                               dpbalpayment = 0;
                               emipayment = 0;
                               balpayment = 0;
                               dpdemo = 0;
                               emidemo = 0;
                               overamount = 0;
                               recpaidamount = 0;
                               reg = ds.Tables[0].Rows[i][0].ToString();
                               dr1 = paiddt.NewRow();
                               emical(reg);


                               String dty = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                               string s10 = dty;
                               string dd10 = s10.Substring(0, 2);
                               string mm10 = s10.Substring(3, 2);
                               string yy10 = s10.Substring(6, 4);
                               string date10 = mm10 + "/" + dd10 + "/" + yy10;
                               con1.Open();

                               SqlDataAdapter cmd9 = new SqlDataAdapter("select RECIPT from wjstar1.recipt1 where status='PAID' AND (DATE1 = '" +

date10 + "') AND CUSTREGNO='" + reg + "' ORDER BY RECIPT ASC", con1);
                               DataSet ds9 = new DataSet();
                               cmd9.Fill(ds9);
                               con1.Close();
                              
                               Double fix = 0;
                               if (ds9.Tables[0].Rows.Count > 0)
                               {
                                   if (ds9.Tables[0].Rows.Count != 1)
                                   {
                                       for (int k = 0; k < ds9.Tables[0].Rows.Count; k++)
                                       {
                                           int rc = Convert.ToInt32(ds9.Tables[0].Rows[k][0].ToString());
                                           con1.Open();
                                           SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (RECIPT < " + rc + ") AND CUSTREGNO='" + reg + "'", con1);
                                           DataSet ds7 = new DataSet();
                                           cmd7.Fill(ds7);
                                           con1.Close();
                                           if (ds7.Tables[0].Rows.Count > 0)
                                           {
                                               if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                               {
                                                   recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                               }
                                               else
                                               {
                                                   recamountcustomer = 0;
                                               }

                                           }
                                           dpbalpayment = Convert.ToDouble(Label16.Text);
                                           fix = pendingemi2;
                                           //fix = Convert.ToDouble(Label23.Text);
                                           //String drt = Label23.Text;
                                           if (recamountcustomer <= dpbalpayment)
                                           {

                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               totalamountcustomer = recpaidamount + recamountcustomer;
                                               if (totalamountcustomer <= dpbalpayment)
                                               {
                                                   dpdemo = recpaidamount;
                                                   emidemo = 0;
                                                   fix = 0;
                                               }
                                               else
                                               {
                                                   overamount = totalamountcustomer - dpbalpayment;
                                                   dpdemo = recpaidamount - overamount;
                                                   emidemo = overamount;

                                                   fix = pendingemi2;
                                               }
                                               dr1["DPAMOUNT"] = dpdemo;
                                           }
                                           else
                                           {
                                               dpdemo = 0;
                                               dr1["DPAMOUNT"] = "COMPLETED";
                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               emidemo = recpaidamount;
                                               fix = pendingemi2;
                                           }
                                           dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                           dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                           dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                         //  dr1["DPAMOUNT"] = dpdemo;
                                           sumdppaid = sumdppaid + dpdemo;
                                           dr1["EMIAMOUNT"] = emidemo;
                                           sumemipaid = sumemipaid + emidemo;
                                           dr1["LATE_EMI"] = latemipay;
                                           dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                           //payment = payment + lateemipayment;
                                           dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                           statusragistry(reg);
                                           dr1["STATUS"] = status;
                                           dr1["FIXEDEMI"] = fix;
                                           paiddt.Rows.Add(dr1);
                                           dr1 = paiddt.NewRow();
                                           if (k != ds9.Tables[0].Rows.Count - 1)
                                           {
                                              // i = i + 1;
                                              // continue;
                                               // k = k + 1;
											   break;

                                           }
                                           recpaidamount = 0;
                                       }
                                   }
                                   else
                                   {

                                       recpaidamount = 0;
                                       con1.Open();
                                       SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (DATE1 < '" + date10 + "') AND CUSTREGNO='" + reg + "'", con1);
                                       DataSet ds7 = new DataSet();
                                       cmd7.Fill(ds7);
                                       con1.Close();
                                       if (ds7.Tables[0].Rows.Count > 0)
                                       {
                                           if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                           {
                                               recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                           }
                                           else
                                           {
                                               recamountcustomer = 0;
                                           }

                                       }
                                       dpbalpayment = Convert.ToDouble(Label16.Text);
                                       fix = pendingemi2;

                                       if (recamountcustomer <= dpbalpayment)
                                       {

                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           totalamountcustomer = recpaidamount + recamountcustomer;
                                           if (totalamountcustomer <= dpbalpayment)
                                           {
                                               dpdemo = recpaidamount;
                                               emidemo = 0;
                                               fix = 0;
                                           }
                                           else
                                           {
                                               overamount = totalamountcustomer - dpbalpayment;
                                               dpdemo = recpaidamount - overamount;
                                               emidemo = overamount;

                                               fix = pendingemi2;
                                           }
                                           dr1["DPAMOUNT"] = dpdemo;
                                       }
                                       else
                                       {
                                           dpdemo = 0;
                                           dr1["DPAMOUNT"] = "COMPLETED";
                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           emidemo = recpaidamount;
                                           fix = pendingemi2;
                                       }
                                       dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                       dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                       dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                       //dr1["DPAMOUNT"] = dpdemo;
                                       sumdppaid = sumdppaid + dpdemo;
                                       dr1["EMIAMOUNT"] = emidemo;
                                       sumemipaid = sumemipaid + emidemo;
                                       dr1["LATE_EMI"] = latemipay;
                                       dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                       //payment = payment + lateemipayment;
                                       dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                       statusragistry(reg);
                                       dr1["STATUS"] = status;
                                       dr1["FIXEDEMI"] = fix;
                                       paiddt.Rows.Add(dr1);

                                   }

                               }





                           }
                       }
                       GridView1.DataSource = paiddt;
                       GridView1.DataBind();

                       DataTable demo = new DataTable();
                       demo.Columns.AddRange(new DataColumn[4] { new DataColumn("REGNO", typeof(string)), new DataColumn("amount", typeof(int)), new DataColumn("fixedpay", typeof(int)), new DataColumn("STATUSP", typeof(string)) });
                       DataRow dr2 = demo.NewRow();

                       Double finalfixed = 0, otherfix = 0, comfix = 0, dm = 0;
                       String st = "";
                       for (int j = 0; j < paiddt.Rows.Count; j++)
                       {


                           int c = 0;
                           Double emifi = 0;
                           st = "";
                           for (int h = 0; h < demo.Rows.Count; h++)
                           {
                               if (demo.Rows[h][0].ToString() == paiddt.Rows[j][0].ToString())
                               {
                                   c = 1;

                                   dm = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                                   // dr2["amount"] = dm;
                                   string find = "REGNO = '" + paiddt.Rows[j][0].ToString() + "'";
                                   //find out id  
                                   DataRow[] resultupdate = demo.Select(find);
                                   //update row  
                                   resultupdate[0]["amount"] = dm;
                                   resultupdate[0]["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                                   // resultupdate[0]["STATUSP"] =paiddt.Rows[j][8].ToString();
                                   //Accept Changes  
                                   demo.AcceptChanges();
                                   break;
                               }




                           }
                           if (c == 0)
                           {
                               String hu = paiddt.Rows[j][0].ToString();
                               st = paiddt.Rows[j][8].ToString();
                               dr2["REGNO"] = hu;
                               emifi = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                               dr2["amount"] = emifi;
                               dr2["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                               dr2["STATUSP"] = paiddt.Rows[j][8].ToString();

                               demo.Rows.Add(dr2);
                               dr2 = demo.NewRow();
                           }
                           otherfix = otherfix + Convert.ToDouble(paiddt.Rows[j][4].ToString());



                       }
                       int count = 0;
                       for (int j = 0; j < demo.Rows.Count; j++)
                       {
                           finalfixed = finalfixed + Convert.ToDouble(demo.Rows[j][1].ToString());
                           //payment = payment + Convert.ToDouble(demo.Rows[j][2].ToString());
                           if (Convert.ToDouble(demo.Rows[j][1].ToString()) != 0)
                           {
                               count = count + 1;
                           }
                           if (demo.Rows[j][3].ToString() == "completed")
                           {
                               comfix = comfix + Convert.ToDouble(demo.Rows[j][1].ToString());
                           }


                       }
                       Label47.Text = count.ToString();
                       //Label29.Text = payment.ToString();
                       Label30.Text = sumdppaid.ToString();
                       //  finalfixed = finalfixed -first;
                       Label31.Text = finalfixed.ToString();


                       Label45.Text = (otherfix - finalfixed).ToString();
                       Label46.Text = comfix.ToString();
                       Double extra = 0;
                       extra = otherfix - finalfixed;
                       if (extra >= 0)
                       {
                           Label45.Text = extra.ToString();
                           Label45.ForeColor = System.Drawing.Color.Green;
                       }
                       else
                       {
                           Label45.Text = extra.ToString();
                           Label45.ForeColor = System.Drawing.Color.Red;
                       }
                      
                   }
                   else
                   {
                       payment = 0;
                       SqlConnection con1 = new SqlConnection(s);
                       con1.Open();

                       SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby,RECIPT from wjstar1.recipt1 where status='PAID' AND usertype='" + user + "' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='Cancel'))) order by DATE1,RECIPT ASC",

con1);
                       DataSet ds = new DataSet();
                       cmd.Fill(ds);
                       // GridView1.DataSource = ds;
                       // GridView1.DataBind();
                       con1.Close();
                       DataTable paiddt = new DataTable();

                       paiddt.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),new DataColumn

("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("DPAMOUNT",typeof(string)),new DataColumn("EMIAMOUNT",typeof(string)),new DataColumn("LATE_EMI", 

typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn

("STATUS",typeof(string)),new DataColumn("FIXEDEMI",typeof(int))});
                       DataRow dr1 = paiddt.NewRow();
                       dr1 = null;
                       string reg = "";
                       payment = 0;
                       sumdppaid = 0;
                       sumemipaid = 0;
                       dpbalpayment = 0;
                       emipayment = 0;
                       balpayment = 0;
                       Double recpaidamount = 0, overamount = 0, dpdemo = 0, emidemo = 0;
                       if (ds.Tables[0].Rows.Count > 0)
                       {
                           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                           {
                               reg = "";
                               dpbalpayment = 0;
                               emipayment = 0;
                               balpayment = 0;
                               dpdemo = 0;
                               emidemo = 0;
                               overamount = 0;
                               recpaidamount = 0;
                               reg = ds.Tables[0].Rows[i][0].ToString();
                               dr1 = paiddt.NewRow();
                               emical(reg);


                               String dty = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                               string s10 = dty;
                               string dd10 = s10.Substring(0, 2);
                               string mm10 = s10.Substring(3, 2);
                               string yy10 = s10.Substring(6, 4);
                               string date10 = mm10 + "/" + dd10 + "/" + yy10;
                               con1.Open();

                               SqlDataAdapter cmd9 = new SqlDataAdapter("select RECIPT from wjstar1.recipt1 where status='PAID' AND (DATE1 = '" +

date10 + "') AND CUSTREGNO='" + reg + "' ORDER BY RECIPT ASC", con1);
                               DataSet ds9 = new DataSet();
                               cmd9.Fill(ds9);
                               con1.Close();
                               con1.Open();
                               Double fix = 0;
                               if (ds9.Tables[0].Rows.Count > 0)
                               {
                                   if (ds9.Tables[0].Rows.Count != 1)
                                   {
                                       for (int k = 0; k < ds9.Tables[0].Rows.Count; k++)
                                       {
                                           int rc = Convert.ToInt32(ds9.Tables[0].Rows[k][0].ToString());
                                           SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (RECIPT < " + rc + ") AND CUSTREGNO='" + reg + "'", con1);
                                           DataSet ds7 = new DataSet();
                                           cmd7.Fill(ds7);
                                           con1.Close();
                                           if (ds7.Tables[0].Rows.Count > 0)
                                           {
                                               if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                               {
                                                   recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                               }
                                               else
                                               {
                                                   recamountcustomer = 0;
                                               }

                                           }
                                           dpbalpayment = Convert.ToDouble(Label16.Text);
                                           fix = pendingemi2;
                                           //fix = Convert.ToDouble(Label23.Text);
                                           //String drt = Label23.Text;
                                           if (recamountcustomer <= dpbalpayment)
                                           {

                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               totalamountcustomer = recpaidamount + recamountcustomer;
                                               if (totalamountcustomer <= dpbalpayment)
                                               {
                                                   dpdemo = recpaidamount;
                                                   emidemo = 0;
                                                   fix = 0;
                                               }
                                               else
                                               {
                                                   overamount = totalamountcustomer - dpbalpayment;
                                                   dpdemo = recpaidamount - overamount;
                                                   emidemo = overamount;

                                                   fix = pendingemi2;
                                               }
                                               dr1["DPAMOUNT"] = dpdemo;
                                           }
                                           else
                                           {
                                               dpdemo = 0;
                                               dr1["DPAMOUNT"] = "COMPLETED";
                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               emidemo = recpaidamount;
                                               fix = pendingemi2;
                                           }
                                           dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                           dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                           dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                          // dr1["DPAMOUNT"] = dpdemo;
                                           sumdppaid = sumdppaid + dpdemo;
                                           dr1["EMIAMOUNT"] = emidemo;
                                           sumemipaid = sumemipaid + emidemo;
                                           dr1["LATE_EMI"] = latemipay;
                                           dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                           //payment = payment + lateemipayment;
                                           dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                           statusragistry(reg);
                                           dr1["STATUS"] = status;
                                           dr1["FIXEDEMI"] = fix;
                                           paiddt.Rows.Add(dr1);
                                           dr1 = paiddt.NewRow();
                                           if (k != ds9.Tables[0].Rows.Count - 1)
                                           {
                                              // i = i + 1;
                                               //continue;
                                               //k = k + 1;
											   break;

                                           }
                                           recpaidamount = 0;
                                       }
                                   }
                                   else
                                   {

                                       recpaidamount = 0;
                                       SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (DATE1 < '" + date10 + "') AND CUSTREGNO='" + reg + "'", con1);
                                       DataSet ds7 = new DataSet();
                                       cmd7.Fill(ds7);
                                       con1.Close();
                                       if (ds7.Tables[0].Rows.Count > 0)
                                       {
                                           if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                           {
                                               recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                           }
                                           else
                                           {
                                               recamountcustomer = 0;
                                           }

                                       }
                                       dpbalpayment = Convert.ToDouble(Label16.Text);
                                       fix = pendingemi2;

                                       if (recamountcustomer <= dpbalpayment)
                                       {

                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           totalamountcustomer = recpaidamount + recamountcustomer;
                                           if (totalamountcustomer <= dpbalpayment)
                                           {
                                               dpdemo = recpaidamount;
                                               emidemo = 0;
                                               fix = 0;
                                           }
                                           else
                                           {
                                               overamount = totalamountcustomer - dpbalpayment;
                                               dpdemo = recpaidamount - overamount;
                                               emidemo = overamount;

                                               fix = pendingemi2;
                                           }
                                           dr1["DPAMOUNT"] = dpdemo;
                                       }
                                       else
                                       {
                                           dpdemo = 0;
                                           dr1["DPAMOUNT"] = "COMPLETED";
                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           emidemo = recpaidamount;
                                           fix = pendingemi2;
                                       }
                                       dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                       dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                       dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                      // dr1["DPAMOUNT"] = dpdemo;
                                       sumdppaid = sumdppaid + dpdemo;
                                       dr1["EMIAMOUNT"] = emidemo;
                                       sumemipaid = sumemipaid + emidemo;
                                       dr1["LATE_EMI"] = latemipay;
                                       dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                       //payment = payment + lateemipayment;
                                       dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                       statusragistry(reg);
                                       dr1["STATUS"] = status;
                                       dr1["FIXEDEMI"] = fix;
                                       paiddt.Rows.Add(dr1);

                                   }

                               }





                           }
                       }
                       GridView1.DataSource = paiddt;
                       GridView1.DataBind();

                       DataTable demo = new DataTable();
                       demo.Columns.AddRange(new DataColumn[4] { new DataColumn("REGNO", typeof(string)), new DataColumn("amount", typeof(int)), new DataColumn("fixedpay", typeof(int)), new DataColumn("STATUSP", typeof(string)) });
                       DataRow dr2 = demo.NewRow();

                       Double finalfixed = 0, otherfix = 0, comfix = 0, dm = 0;
                       String st = "";
                       for (int j = 0; j < paiddt.Rows.Count; j++)
                       {


                           int c = 0;
                           Double emifi = 0;
                           st = "";
                           for (int h = 0; h < demo.Rows.Count; h++)
                           {
                               if (demo.Rows[h][0].ToString() == paiddt.Rows[j][0].ToString())
                               {
                                   c = 1;

                                   dm = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                                   // dr2["amount"] = dm;
                                   string find = "REGNO = '" + paiddt.Rows[j][0].ToString() + "'";
                                   //find out id  
                                   DataRow[] resultupdate = demo.Select(find);
                                   //update row  
                                   resultupdate[0]["amount"] = dm;
                                   resultupdate[0]["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                                   // resultupdate[0]["STATUSP"] =paiddt.Rows[j][8].ToString();
                                   //Accept Changes  
                                   demo.AcceptChanges();
                                   break;
                               }




                           }
                           if (c == 0)
                           {
                               String hu = paiddt.Rows[j][0].ToString();
                               st = paiddt.Rows[j][8].ToString();
                               dr2["REGNO"] = hu;
                               emifi = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                               dr2["amount"] = emifi;
                               dr2["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                               dr2["STATUSP"] = paiddt.Rows[j][8].ToString();

                               demo.Rows.Add(dr2);
                               dr2 = demo.NewRow();
                           }
                           otherfix = otherfix + Convert.ToDouble(paiddt.Rows[j][4].ToString());



                       }
                       int count = 0;
                       for (int j = 0; j < demo.Rows.Count; j++)
                       {
                           finalfixed = finalfixed + Convert.ToDouble(demo.Rows[j][1].ToString());
                           //payment = payment + Convert.ToDouble(demo.Rows[j][2].ToString());
                           if (Convert.ToDouble(demo.Rows[j][1].ToString()) != 0)
                           {
                               count = count + 1;
                           }
                           if (demo.Rows[j][3].ToString() == "completed")
                           {
                               comfix = comfix + Convert.ToDouble(demo.Rows[j][1].ToString());
                           }


                       }
                       Label47.Text = count.ToString();
                       //Label29.Text = payment.ToString();
                       Label30.Text = sumdppaid.ToString();
                       //  finalfixed = finalfixed -first;
                       Label31.Text = finalfixed.ToString();


                       Label45.Text = (otherfix - finalfixed).ToString();
                       Label46.Text = comfix.ToString();
                       Double extra = 0;
                       extra = otherfix - finalfixed;
                       if (extra >= 0)
                       {
                           Label45.Text = extra.ToString();
                           Label45.ForeColor = System.Drawing.Color.Green;
                       }
                       else
                       {
                           Label45.Text = extra.ToString();
                           Label45.ForeColor = System.Drawing.Color.Red;
                       }
                      
                   }
               }
           }
           else
           {
               allpaid(DropDownList3.Text);
           }
           //Label29.Text = payment.ToString();
           nonpaid(DropDownList3.Text);
       }
       else
       {
           payment = 0;
           if (DropDownList1.Text == "PAID")
           {
               GridView1.Visible = true;

               if (DropDownList2.Text != "ALL ARAZI")
               {
                   if (DropDownList2.Text != "152")
                   {
                       SqlConnection con1 = new SqlConnection(s);
                       con1.Open();

                       SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby,RECIPT from wjstar1.recipt1 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "')  AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='Cancel'))) order by DATE1,RECIPT ASC", con1);
                       DataSet ds = new DataSet();
                       cmd.Fill(ds);
                       // GridView1.DataSource = ds;
                       // GridView1.DataBind();
                       con1.Close();
                       DataTable paiddt = new DataTable();

                       paiddt.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),new DataColumn

("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("DPAMOUNT",typeof(string)),new DataColumn("EMIAMOUNT",typeof(string)),new DataColumn("LATE_EMI", 

typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn

("STATUS",typeof(string)),new DataColumn("FIXEDEMI",typeof(int))});
                       DataRow dr1 = paiddt.NewRow();
                       dr1 = null;
                       string reg = "";
                       payment = 0;
                       sumdppaid = 0;
                       sumemipaid = 0;
                       dpbalpayment = 0;
                       emipayment = 0;
                       balpayment = 0;
                       Double recpaidamount = 0, overamount = 0, dpdemo = 0, emidemo = 0;
                       if (ds.Tables[0].Rows.Count > 0)
                       {
                           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                           {
                               reg = "";
                               dpbalpayment = 0;
                               emipayment = 0;
                               balpayment = 0;
                               dpdemo = 0;
                               emidemo = 0;
                               overamount = 0;
                               recpaidamount = 0;
                               reg = ds.Tables[0].Rows[i][0].ToString();
                               dr1 = paiddt.NewRow();
                               emical(reg);


                               String dty = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                               string s10 = dty;
                               string dd10 = s10.Substring(0, 2);
                               string mm10 = s10.Substring(3, 2);
                               string yy10 = s10.Substring(6, 4);
                               string date10 = mm10 + "/" + dd10 + "/" + yy10;
                               con1.Open();

                               SqlDataAdapter cmd9 = new SqlDataAdapter("select RECIPT from wjstar1.recipt1 where status='PAID' AND (DATE1 = '" +

date10 + "') AND CUSTREGNO='" + reg + "' ORDER BY RECIPT ASC", con1);
                               DataSet ds9 = new DataSet();
                               cmd9.Fill(ds9);
                               con1.Close();
                               
                               Double fix = 0;
                               if (ds9.Tables[0].Rows.Count > 0)
                               {
                                   if (ds9.Tables[0].Rows.Count != 1)
                                   {
                                       for (int k = 0; k < ds9.Tables[0].Rows.Count; k++)
                                       {
                                           int rc = Convert.ToInt32(ds9.Tables[0].Rows[k][0].ToString());
                                           con1.Open();
                                           SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (RECIPT < " + rc + ") AND CUSTREGNO='" + reg + "'", con1);
                                           DataSet ds7 = new DataSet();
                                           cmd7.Fill(ds7);
                                           con1.Close();
                                           if (ds7.Tables[0].Rows.Count > 0)
                                           {
                                               if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                               {
                                                   recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                               }
                                               else
                                               {
                                                   recamountcustomer = 0;
                                               }

                                           }
                                           dpbalpayment = Convert.ToDouble(Label16.Text);
                                           fix = pendingemi2;
                                           //fix = Convert.ToDouble(Label23.Text);
                                           //String drt = Label23.Text;
                                           if (recamountcustomer <= dpbalpayment)
                                           {

                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               totalamountcustomer = recpaidamount + recamountcustomer;
                                               if (totalamountcustomer <= dpbalpayment)
                                               {
                                                   dpdemo = recpaidamount;
                                                   emidemo = 0;
                                                   fix = 0;
                                               }
                                               else
                                               {
                                                   overamount = totalamountcustomer - dpbalpayment;
                                                   dpdemo = recpaidamount - overamount;
                                                   emidemo = overamount;

                                                   fix = pendingemi2;
                                               }
                                               dr1["DPAMOUNT"] = dpdemo;
                                           }
                                           else
                                           {
                                               dpdemo = 0;
                                               dr1["DPAMOUNT"] = "COMPLETED";
                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               emidemo = recpaidamount;
                                               fix = pendingemi2;
                                           }
                                           dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                           dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                           dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                           // dr1["DPAMOUNT"] = dpdemo;
                                           sumdppaid = sumdppaid + dpdemo;
                                           dr1["EMIAMOUNT"] = emidemo;
                                           sumemipaid = sumemipaid + emidemo;
                                           dr1["LATE_EMI"] = latemipay;
                                           dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                           //payment = payment + lateemipayment;
                                           dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                           statusragistry(reg);
                                           dr1["STATUS"] = status;
                                           dr1["FIXEDEMI"] = fix;
                                           paiddt.Rows.Add(dr1);
                                           dr1 = paiddt.NewRow();
                                           if (k != ds9.Tables[0].Rows.Count - 1)
                                           {
                                              // i = i + 1;
                                             //  continue;
                                             //  k = k + 1;
											   break;

                                           }
                                           recpaidamount = 0;
                                       }
                                   }
                                   else
                                   {

                                       recpaidamount = 0;

                                       con1.Open(); 
                                       SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (DATE1 < '" + date10 + "') AND CUSTREGNO='" + reg + "'", con1);
                                       DataSet ds7 = new DataSet();
                                       cmd7.Fill(ds7);
                                       con1.Close();
                                       if (ds7.Tables[0].Rows.Count > 0)
                                       {
                                           if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                           {
                                               recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                           }
                                           else
                                           {
                                               recamountcustomer = 0;
                                           }

                                       }
                                       dpbalpayment = Convert.ToDouble(Label16.Text);
                                       fix = pendingemi2;

                                       if (recamountcustomer <= dpbalpayment)
                                       {

                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           totalamountcustomer = recpaidamount + recamountcustomer;
                                           if (totalamountcustomer <= dpbalpayment)
                                           {
                                               dpdemo = recpaidamount;
                                               emidemo = 0;
                                               fix = 0;
                                           }
                                           else
                                           {
                                               overamount = totalamountcustomer - dpbalpayment;
                                               dpdemo = recpaidamount - overamount;
                                               emidemo = overamount;

                                               fix = pendingemi2;
                                           }
                                           dr1["DPAMOUNT"] = dpdemo;
                                       }
                                       else
                                       {
                                           dpdemo = 0;
                                           dr1["DPAMOUNT"] = "COMPLETED";
                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           emidemo = recpaidamount;
                                           fix = pendingemi2;
                                       }
                                       dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                       dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                       dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                       // dr1["DPAMOUNT"] = dpdemo;
                                       sumdppaid = sumdppaid + dpdemo;
                                       dr1["EMIAMOUNT"] = emidemo;
                                       sumemipaid = sumemipaid + emidemo;
                                       dr1["LATE_EMI"] = latemipay;
                                       dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                       //payment = payment + lateemipayment;
                                       dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                       statusragistry(reg);
                                       dr1["STATUS"] = status;
                                       dr1["FIXEDEMI"] = fix;
                                       paiddt.Rows.Add(dr1);

                                   }

                               }





                           }
                       }
                       GridView1.DataSource = paiddt;
                       GridView1.DataBind();

                       DataTable demo = new DataTable();
                       demo.Columns.AddRange(new DataColumn[4] { new DataColumn("REGNO", typeof(string)), new DataColumn("amount", typeof(int)), new DataColumn("fixedpay", typeof(int)), new DataColumn("STATUSP", typeof(string)) });
                       DataRow dr2 = demo.NewRow();

                       Double finalfixed = 0, otherfix = 0, comfix = 0, dm = 0;
                       String st = "";
                       for (int j = 0; j < paiddt.Rows.Count; j++)
                       {


                           int c = 0;
                           Double emifi = 0;
                           st = "";
                           for (int h = 0; h < demo.Rows.Count; h++)
                           {
                               if (demo.Rows[h][0].ToString() == paiddt.Rows[j][0].ToString())
                               {
                                   c = 1;

                                   dm = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                                   // dr2["amount"] = dm;
                                   string find = "REGNO = '" + paiddt.Rows[j][0].ToString() + "'";
                                   //find out id  
                                   DataRow[] resultupdate = demo.Select(find);
                                   //update row  
                                   resultupdate[0]["amount"] = dm;
                                   resultupdate[0]["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                                   // resultupdate[0]["STATUSP"] =paiddt.Rows[j][8].ToString();
                                   //Accept Changes  
                                   demo.AcceptChanges();
                                   break;
                               }




                           }
                           if (c == 0)
                           {
                               String hu = paiddt.Rows[j][0].ToString();
                               st = paiddt.Rows[j][8].ToString();
                               dr2["REGNO"] = hu;
                               emifi = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                               dr2["amount"] = emifi;
                               dr2["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                               dr2["STATUSP"] = paiddt.Rows[j][8].ToString();

                               demo.Rows.Add(dr2);
                               dr2 = demo.NewRow();
                           }
                           otherfix = otherfix + Convert.ToDouble(paiddt.Rows[j][4].ToString());



                       }
                       int count = 0;
                       for (int j = 0; j < demo.Rows.Count; j++)
                       {
                           finalfixed = finalfixed + Convert.ToDouble(demo.Rows[j][1].ToString());
                           //payment = payment + Convert.ToDouble(demo.Rows[j][2].ToString());
                           if (Convert.ToDouble(demo.Rows[j][1].ToString()) != 0)
                           {
                               count = count + 1;
                           }
                           if (demo.Rows[j][3].ToString() == "completed")
                           {
                               comfix = comfix + Convert.ToDouble(demo.Rows[j][1].ToString());
                           }


                       }
                       Label47.Text = count.ToString();
                       //Label29.Text = payment.ToString();
                       Label30.Text = sumdppaid.ToString();
                       //  finalfixed = finalfixed -first;
                       Label31.Text = finalfixed.ToString();


                       Label45.Text = (otherfix - finalfixed).ToString();
                       Label46.Text = comfix.ToString();
                       Double extra = 0;
                       extra = otherfix - finalfixed;
                       if (extra >= 0)
                       {
                           Label45.Text = extra.ToString();
                           Label45.ForeColor = System.Drawing.Color.Green;
                       }
                       else
                       {
                           Label45.Text = extra.ToString();
                           Label45.ForeColor = System.Drawing.Color.Red;
                       }
                      
                   }
                   else
                   {
                       if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                       {
                           SqlConnection con1 = new SqlConnection(s);
                           con1.Open();

                           SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby,RECIPT from wjstar1.recipt1 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='Cancel'))) order by DATE1,RECIPT ASC", con1);
                           DataSet ds = new DataSet();
                           cmd.Fill(ds);
                           // GridView1.DataSource = ds;
                           // GridView1.DataBind();
                           con1.Close();
                           DataTable paiddt = new DataTable();

                           paiddt.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),new DataColumn

("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("DPAMOUNT",typeof(string)),new DataColumn("EMIAMOUNT",typeof(string)),new DataColumn("LATE_EMI", 

typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn

("STATUS",typeof(string)),new DataColumn("FIXEDEMI",typeof(int))});
                           DataRow dr1 = paiddt.NewRow();
                           dr1 = null;
                           string reg = "";
                           payment = 0;
                           sumdppaid = 0;
                           sumemipaid = 0;
                           dpbalpayment = 0;
                           emipayment = 0;
                           balpayment = 0;
                           Double recpaidamount = 0, overamount = 0, dpdemo = 0, emidemo = 0;
                           if (ds.Tables[0].Rows.Count > 0)
                           {
                               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                               {
                                   reg = "";
                                   dpbalpayment = 0;
                                   emipayment = 0;
                                   balpayment = 0;
                                   dpdemo = 0;
                                   emidemo = 0;
                                   overamount = 0;
                                   recpaidamount = 0;
                                   reg = ds.Tables[0].Rows[i][0].ToString();
                                   dr1 = paiddt.NewRow();
                                   emical(reg);


                                   String dty = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                   string s10 = dty;
                                   string dd10 = s10.Substring(0, 2);
                                   string mm10 = s10.Substring(3, 2);
                                   string yy10 = s10.Substring(6, 4);
                                   string date10 = mm10 + "/" + dd10 + "/" + yy10;
                                   con1.Open();

                                   SqlDataAdapter cmd9 = new SqlDataAdapter("select RECIPT from wjstar1.recipt1 where status='PAID' AND (DATE1 = '" +

    date10 + "') AND CUSTREGNO='" + reg + "' ORDER BY RECIPT ASC", con1);
                                   DataSet ds9 = new DataSet();
                                   cmd9.Fill(ds9);
                                   con1.Close();
                                  
                                   Double fix = 0;
                                   if (ds9.Tables[0].Rows.Count > 0)
                                   {
                                       if (ds9.Tables[0].Rows.Count != 1)
                                       {
                                           for (int k = 0; k < ds9.Tables[0].Rows.Count; k++)
                                           {
                                               int rc = Convert.ToInt32(ds9.Tables[0].Rows[k][0].ToString());
                                               con1.Open();
                                               SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (RECIPT < " + rc + ") AND CUSTREGNO='" + reg + "'", con1);
                                               DataSet ds7 = new DataSet();
                                               cmd7.Fill(ds7);
                                               con1.Close();
                                               if (ds7.Tables[0].Rows.Count > 0)
                                               {
                                                   if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                                   {
                                                       recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                                   }
                                                   else
                                                   {
                                                       recamountcustomer = 0;
                                                   }

                                               }
                                               dpbalpayment = Convert.ToDouble(Label16.Text);
                                               fix = pendingemi2;
                                               //fix = Convert.ToDouble(Label23.Text);
                                               //String drt = Label23.Text;
                                               if (recamountcustomer <= dpbalpayment)
                                               {

                                                   recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                                   totalamountcustomer = recpaidamount + recamountcustomer;
                                                   if (totalamountcustomer <= dpbalpayment)
                                                   {
                                                       dpdemo = recpaidamount;
                                                       emidemo = 0;
                                                       fix = 0;
                                                   }
                                                   else
                                                   {
                                                       overamount = totalamountcustomer - dpbalpayment;
                                                       dpdemo = recpaidamount - overamount;
                                                       emidemo = overamount;

                                                       fix = pendingemi2;
                                                   }
                                                   dr1["DPAMOUNT"] = dpdemo;
                                               }
                                               else
                                               {
                                                   dpdemo = 0;
                                                   dr1["DPAMOUNT"] = "COMPLETED";
                                                   recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                                   emidemo = recpaidamount;
                                                   fix = pendingemi2;
                                               }
                                               dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                               dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                               dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                               // dr1["DPAMOUNT"] = dpdemo;
                                               sumdppaid = sumdppaid + dpdemo;
                                               dr1["EMIAMOUNT"] = emidemo;
                                               sumemipaid = sumemipaid + emidemo;
                                               dr1["LATE_EMI"] = latemipay;
                                               dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                               //payment = payment + lateemipayment;
                                               dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                               statusragistry(reg);
                                               dr1["STATUS"] = status;
                                               dr1["FIXEDEMI"] = fix;
                                               paiddt.Rows.Add(dr1);
                                               dr1 = paiddt.NewRow();
                                               if (k != ds9.Tables[0].Rows.Count - 1)
                                               {
                                                  // i = i + 1;
                                                   //continue;
                                                   //k = k + 1;
												   break;

                                               }
                                               recpaidamount = 0;
                                           }
                                       }
                                       else
                                       {

                                           recpaidamount = 0;
                                           con1.Open();
                                           SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (DATE1 < '" + date10 + "') AND CUSTREGNO='" + reg + "'", con1);
                                           DataSet ds7 = new DataSet();
                                           cmd7.Fill(ds7);
                                           con1.Close();
                                           if (ds7.Tables[0].Rows.Count > 0)
                                           {
                                               if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                               {
                                                   recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                               }
                                               else
                                               {
                                                   recamountcustomer = 0;
                                               }

                                           }
                                           dpbalpayment = Convert.ToDouble(Label16.Text);
                                           fix = pendingemi2;

                                           if (recamountcustomer <= dpbalpayment)
                                           {

                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               totalamountcustomer = recpaidamount + recamountcustomer;
                                               if (totalamountcustomer <= dpbalpayment)
                                               {
                                                   dpdemo = recpaidamount;
                                                   emidemo = 0;
                                                   fix = 0;
                                               }
                                               else
                                               {
                                                   overamount = totalamountcustomer - dpbalpayment;
                                                   dpdemo = recpaidamount - overamount;
                                                   emidemo = overamount;

                                                   fix = pendingemi2;
                                               }
                                               dr1["DPAMOUNT"] = dpdemo;
                                           }
                                           else
                                           {
                                               dpdemo = 0;
                                               dr1["DPAMOUNT"] = "COMPLETED";
                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               emidemo = recpaidamount;
                                               fix = pendingemi2;
                                           }
                                           dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                           dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                           dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                           // dr1["DPAMOUNT"] = dpdemo;
                                           sumdppaid = sumdppaid + dpdemo;
                                           dr1["EMIAMOUNT"] = emidemo;
                                           sumemipaid = sumemipaid + emidemo;
                                           dr1["LATE_EMI"] = latemipay;
                                           dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                           //payment = payment + lateemipayment;
                                           dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                           statusragistry(reg);
                                           dr1["STATUS"] = status;
                                           dr1["FIXEDEMI"] = fix;
                                           paiddt.Rows.Add(dr1);

                                       }

                                   }





                               }
                           }
                           GridView1.DataSource = paiddt;
                           GridView1.DataBind();

                           DataTable demo = new DataTable();
                           demo.Columns.AddRange(new DataColumn[4] { new DataColumn("REGNO", typeof(string)), new DataColumn("amount", typeof(int)), new DataColumn("fixedpay", typeof(int)), new DataColumn("STATUSP", typeof(string)) });
                           DataRow dr2 = demo.NewRow();

                           Double finalfixed = 0, otherfix = 0, comfix = 0, dm = 0;
                           String st = "";
                           for (int j = 0; j < paiddt.Rows.Count; j++)
                           {


                               int c = 0;
                               Double emifi = 0;
                               st = "";
                               for (int h = 0; h < demo.Rows.Count; h++)
                               {
                                   if (demo.Rows[h][0].ToString() == paiddt.Rows[j][0].ToString())
                                   {
                                       c = 1;

                                       dm = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                                       // dr2["amount"] = dm;
                                       string find = "REGNO = '" + paiddt.Rows[j][0].ToString() + "'";
                                       //find out id  
                                       DataRow[] resultupdate = demo.Select(find);
                                       //update row  
                                       resultupdate[0]["amount"] = dm;
                                       resultupdate[0]["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                                       // resultupdate[0]["STATUSP"] =paiddt.Rows[j][8].ToString();
                                       //Accept Changes  
                                       demo.AcceptChanges();
                                       break;
                                   }




                               }
                               if (c == 0)
                               {
                                   String hu = paiddt.Rows[j][0].ToString();
                                   st = paiddt.Rows[j][8].ToString();
                                   dr2["REGNO"] = hu;
                                   emifi = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                                   dr2["amount"] = emifi;
                                   dr2["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                                   dr2["STATUSP"] = paiddt.Rows[j][8].ToString();

                                   demo.Rows.Add(dr2);
                                   dr2 = demo.NewRow();
                               }
                               otherfix = otherfix + Convert.ToDouble(paiddt.Rows[j][4].ToString());



                           }
                           int count = 0;
                           for (int j = 0; j < demo.Rows.Count; j++)
                           {
                               finalfixed = finalfixed + Convert.ToDouble(demo.Rows[j][1].ToString());
                               //payment = payment + Convert.ToDouble(demo.Rows[j][2].ToString());
                               if (Convert.ToDouble(demo.Rows[j][1].ToString()) != 0)
                               {
                                   count = count + 1;
                               }
                               if (demo.Rows[j][3].ToString() == "completed")
                               {
                                   comfix = comfix + Convert.ToDouble(demo.Rows[j][1].ToString());
                               }


                           }
                           Label47.Text = count.ToString();
                           //Label29.Text = payment.ToString();
                           Label30.Text = sumdppaid.ToString();
                           //  finalfixed = finalfixed -first;
                           Label31.Text = finalfixed.ToString();


                           Label45.Text = (otherfix - finalfixed).ToString();
                           Label46.Text = comfix.ToString();
                           Double extra = 0;
                           extra = otherfix - finalfixed;
                           if (extra >= 0)
                           {
                               Label45.Text = extra.ToString();
                               Label45.ForeColor = System.Drawing.Color.Green;
                           }
                           else
                           {
                               Label45.Text = extra.ToString();
                               Label45.ForeColor = System.Drawing.Color.Red;
                           }
                          
                       }
                       else
                       {
                           SqlConnection con1 = new SqlConnection(s);
                           con1.Open();

                           SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby,RECIPT from wjstar1.recipt1 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='Cancel'))) order by DATE1,RECIPT ASC", con1);
                           DataSet ds = new DataSet();
                           cmd.Fill(ds);
                           // GridView1.DataSource = ds;
                           // GridView1.DataBind();
                           con1.Close();
                           DataTable paiddt = new DataTable();

                           paiddt.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),new DataColumn

("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("DPAMOUNT",typeof(string)),new DataColumn("EMIAMOUNT",typeof(string)),new DataColumn("LATE_EMI", 

typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn

("STATUS",typeof(string)),new DataColumn("FIXEDEMI",typeof(int))});
                           DataRow dr1 = paiddt.NewRow();
                           dr1 = null;
                           string reg = "";
                           payment = 0;
                           sumdppaid = 0;
                           sumemipaid = 0;
                           dpbalpayment = 0;
                           emipayment = 0;
                           balpayment = 0;
                           Double recpaidamount = 0, overamount = 0, dpdemo = 0, emidemo = 0;
                           if (ds.Tables[0].Rows.Count > 0)
                           {
                               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                               {
                                   reg = "";
                                   dpbalpayment = 0;
                                   emipayment = 0;
                                   balpayment = 0;
                                   dpdemo = 0;
                                   emidemo = 0;
                                   overamount = 0;
                                   recpaidamount = 0;
                                   reg = ds.Tables[0].Rows[i][0].ToString();
                                   dr1 = paiddt.NewRow();
                                   emical(reg);


                                   String dty = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                   string s10 = dty;
                                   string dd10 = s10.Substring(0, 2);
                                   string mm10 = s10.Substring(3, 2);
                                   string yy10 = s10.Substring(6, 4);
                                   string date10 = mm10 + "/" + dd10 + "/" + yy10;
                                   con1.Open();

                                   SqlDataAdapter cmd9 = new SqlDataAdapter("select RECIPT from wjstar1.recipt1 where status='PAID' AND (DATE1 = '" +

    date10 + "') AND CUSTREGNO='" + reg + "' ORDER BY RECIPT ASC", con1);
                                   DataSet ds9 = new DataSet();
                                   cmd9.Fill(ds9);
                                   con1.Close();
                              
                                   Double fix = 0;
                                   if (ds9.Tables[0].Rows.Count > 0)
                                   {
                                       if (ds9.Tables[0].Rows.Count != 1)
                                       {
                                           for (int k = 0; k < ds9.Tables[0].Rows.Count; k++)
                                           {
                                               int rc = Convert.ToInt32(ds9.Tables[0].Rows[k][0].ToString());
                                               con1.Open();
                                               SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (RECIPT < " + rc + ") AND CUSTREGNO='" + reg + "'", con1);
                                               DataSet ds7 = new DataSet();
                                               cmd7.Fill(ds7);
                                               con1.Close();
                                               if (ds7.Tables[0].Rows.Count > 0)
                                               {
                                                   if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                                   {
                                                       recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                                   }
                                                   else
                                                   {
                                                       recamountcustomer = 0;
                                                   }

                                               }
                                               dpbalpayment = Convert.ToDouble(Label16.Text);
                                               fix = pendingemi2;
                                               //fix = Convert.ToDouble(Label23.Text);
                                               //String drt = Label23.Text;
                                               if (recamountcustomer <= dpbalpayment)
                                               {

                                                   recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                                   totalamountcustomer = recpaidamount + recamountcustomer;
                                                   if (totalamountcustomer <= dpbalpayment)
                                                   {
                                                       dpdemo = recpaidamount;
                                                       emidemo = 0;
                                                       fix = 0;
                                                   }
                                                   else
                                                   {
                                                       overamount = totalamountcustomer - dpbalpayment;
                                                       dpdemo = recpaidamount - overamount;
                                                       emidemo = overamount;

                                                       fix = pendingemi2;
                                                   }
                                                   dr1["DPAMOUNT"] = dpdemo;
                                               }
                                               else
                                               {
                                                   dpdemo = 0;
                                                   dr1["DPAMOUNT"] = "COMPLETED";
                                                   recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                                   emidemo = recpaidamount;
                                                   fix = pendingemi2;
                                               }
                                               dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                               dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                               dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                               // dr1["DPAMOUNT"] = dpdemo;
                                               sumdppaid = sumdppaid + dpdemo;
                                               dr1["EMIAMOUNT"] = emidemo;
                                               sumemipaid = sumemipaid + emidemo;
                                               dr1["LATE_EMI"] = latemipay;
                                               dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                               //payment = payment + lateemipayment;
                                               dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                               statusragistry(reg);
                                               dr1["STATUS"] = status;
                                               dr1["FIXEDEMI"] = fix;
                                               paiddt.Rows.Add(dr1);
                                               dr1 = paiddt.NewRow();
                                               if (k != ds9.Tables[0].Rows.Count - 1)
                                               {
                                                  // i = i + 1;
                                                 //  continue;
                                                  // k = k + 1;
												   break;

                                               }
                                               recpaidamount = 0;
                                           }
                                       }
                                       else
                                       {

                                           recpaidamount = 0;
                                           con1.Open();
                                           SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (DATE1 < '" + date10 + "') AND CUSTREGNO='" + reg + "'", con1);
                                           DataSet ds7 = new DataSet();
                                           cmd7.Fill(ds7);
                                           con1.Close();
                                           if (ds7.Tables[0].Rows.Count > 0)
                                           {
                                               if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                               {
                                                   recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                               }
                                               else
                                               {
                                                   recamountcustomer = 0;
                                               }

                                           }
                                           dpbalpayment = Convert.ToDouble(Label16.Text);
                                           fix = pendingemi2;

                                           if (recamountcustomer <= dpbalpayment)
                                           {

                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               totalamountcustomer = recpaidamount + recamountcustomer;
                                               if (totalamountcustomer <= dpbalpayment)
                                               {
                                                   dpdemo = recpaidamount;
                                                   emidemo = 0;
                                                   fix = 0;
                                               }
                                               else
                                               {
                                                   overamount = totalamountcustomer - dpbalpayment;
                                                   dpdemo = recpaidamount - overamount;
                                                   emidemo = overamount;

                                                   fix = pendingemi2;
                                               }
                                               dr1["DPAMOUNT"] = dpdemo;
                                           }
                                           else
                                           {
                                               dpdemo = 0;
                                               dr1["DPAMOUNT"] = "COMPLETED";
                                               recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                               emidemo = recpaidamount;
                                               fix = pendingemi2;
                                           }
                                           dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                           dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                           dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                           // dr1["DPAMOUNT"] = dpdemo;
                                           sumdppaid = sumdppaid + dpdemo;
                                           dr1["EMIAMOUNT"] = emidemo;
                                           sumemipaid = sumemipaid + emidemo;
                                           dr1["LATE_EMI"] = latemipay;
                                           dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                           //payment = payment + lateemipayment;
                                           dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                           statusragistry(reg);
                                           dr1["STATUS"] = status;
                                           dr1["FIXEDEMI"] = fix;
                                           paiddt.Rows.Add(dr1);

                                       }

                                   }





                               }
                           }
                           GridView1.DataSource = paiddt;
                           GridView1.DataBind();

                           DataTable demo = new DataTable();
                           demo.Columns.AddRange(new DataColumn[4] { new DataColumn("REGNO", typeof(string)), new DataColumn("amount", typeof(int)), new DataColumn("fixedpay", typeof(int)), new DataColumn("STATUSP", typeof(string)) });
                           DataRow dr2 = demo.NewRow();

                           Double finalfixed = 0, otherfix = 0, comfix = 0, dm = 0;
                           String st = "";
                           for (int j = 0; j < paiddt.Rows.Count; j++)
                           {


                               int c = 0;
                               Double emifi = 0;
                               st = "";
                               for (int h = 0; h < demo.Rows.Count; h++)
                               {
                                   if (demo.Rows[h][0].ToString() == paiddt.Rows[j][0].ToString())
                                   {
                                       c = 1;

                                       dm = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                                       // dr2["amount"] = dm;
                                       string find = "REGNO = '" + paiddt.Rows[j][0].ToString() + "'";
                                       //find out id  
                                       DataRow[] resultupdate = demo.Select(find);
                                       //update row  
                                       resultupdate[0]["amount"] = dm;
                                       resultupdate[0]["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                                       // resultupdate[0]["STATUSP"] =paiddt.Rows[j][8].ToString();
                                       //Accept Changes  
                                       demo.AcceptChanges();
                                       break;
                                   }




                               }
                               if (c == 0)
                               {
                                   String hu = paiddt.Rows[j][0].ToString();
                                   st = paiddt.Rows[j][8].ToString();
                                   dr2["REGNO"] = hu;
                                   emifi = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                                   dr2["amount"] = emifi;
                                   dr2["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                                   dr2["STATUSP"] = paiddt.Rows[j][8].ToString();

                                   demo.Rows.Add(dr2);
                                   dr2 = demo.NewRow();
                               }
                               otherfix = otherfix + Convert.ToDouble(paiddt.Rows[j][4].ToString());



                           }
                           int count = 0;
                           for (int j = 0; j < demo.Rows.Count; j++)
                           {
                               finalfixed = finalfixed + Convert.ToDouble(demo.Rows[j][1].ToString());
                               //payment = payment + Convert.ToDouble(demo.Rows[j][2].ToString());
                               if (Convert.ToDouble(demo.Rows[j][1].ToString()) != 0)
                               {
                                   count = count + 1;
                               }
                               if (demo.Rows[j][3].ToString() == "completed")
                               {
                                   comfix = comfix + Convert.ToDouble(demo.Rows[j][1].ToString());
                               }


                           }
                           Label47.Text = count.ToString();
                           //Label29.Text = payment.ToString();
                           Label30.Text = sumdppaid.ToString();
                           //  finalfixed = finalfixed -first;
                           Label31.Text = finalfixed.ToString();


                           Label45.Text = (otherfix - finalfixed).ToString();
                           Label46.Text = comfix.ToString();
                           Double extra = 0;
                           extra = otherfix - finalfixed;
                           if (extra >= 0)
                           {
                               Label45.Text = extra.ToString();
                               Label45.ForeColor = System.Drawing.Color.Green;
                           }
                           else
                           {
                               Label45.Text = extra.ToString();
                               Label45.ForeColor = System.Drawing.Color.Red;
                           }
                          
                       }
                   }
               }
               else
               {

                   SqlConnection con1 = new SqlConnection(s);
                   con1.Open();

                   SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby,RECIPT from wjstar1.recipt1 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='Cancel'))) order by DATE1,RECIPT ASC", con1);
                   DataSet ds = new DataSet();
                   cmd.Fill(ds);
                   // GridView1.DataSource = ds;
                   // GridView1.DataBind();
                   con1.Close();
                   DataTable paiddt = new DataTable();

                   paiddt.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),new DataColumn

("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("DPAMOUNT",typeof(string)),new DataColumn("EMIAMOUNT",typeof(string)),new DataColumn("LATE_EMI", 

typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn

("STATUS",typeof(string)),new DataColumn("FIXEDEMI",typeof(int))});
                   DataRow dr1 = paiddt.NewRow();
                   dr1 = null;
                   string reg = "";
                   payment = 0;
                   sumdppaid = 0;
                   sumemipaid = 0;
                   dpbalpayment = 0;
                   emipayment = 0;
                   balpayment = 0;
                   Double recpaidamount = 0, overamount = 0, dpdemo = 0, emidemo = 0;
                   if (ds.Tables[0].Rows.Count > 0)
                   {
                       for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                       {
                           reg = "";
                           dpbalpayment = 0;
                           emipayment = 0;
                           balpayment = 0;
                           dpdemo = 0;
                           emidemo = 0;
                           overamount = 0;
                           recpaidamount = 0;
                           reg = ds.Tables[0].Rows[i][0].ToString();
                           dr1 = paiddt.NewRow();
                           emical(reg);


                           String dty = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                           string s10 = dty;
                           string dd10 = s10.Substring(0, 2);
                           string mm10 = s10.Substring(3, 2);
                           string yy10 = s10.Substring(6, 4);
                           string date10 = mm10 + "/" + dd10 + "/" + yy10;
                           con1.Open();

                           SqlDataAdapter cmd9 = new SqlDataAdapter("select RECIPT from wjstar1.recipt1 where status='PAID' AND (DATE1 = '" +

date10 + "') AND CUSTREGNO='" + reg + "' ORDER BY RECIPT ASC", con1);
                           DataSet ds9 = new DataSet();
                           cmd9.Fill(ds9);
                           con1.Close();
                      
                           Double fix = 0;
                           if (ds9.Tables[0].Rows.Count > 0)
                           {
                               if (ds9.Tables[0].Rows.Count != 1)
                               {
                                   for (int k = 0; k < ds9.Tables[0].Rows.Count; k++)
                                   {
                                       int rc = Convert.ToInt32(ds9.Tables[0].Rows[k][0].ToString());
                                       con1.Open();
                                       SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (RECIPT < " + rc + ") AND CUSTREGNO='" + reg + "'", con1);
                                       DataSet ds7 = new DataSet();
                                       cmd7.Fill(ds7);
                                       con1.Close();
                                       if (ds7.Tables[0].Rows.Count > 0)
                                       {
                                           if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                           {
                                               recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                           }
                                           else
                                           {
                                               recamountcustomer = 0;
                                           }

                                       }
                                       dpbalpayment = Convert.ToDouble(Label16.Text);
                                       fix = pendingemi2;
                                       //fix = Convert.ToDouble(Label23.Text);
                                       //String drt = Label23.Text;
                                       if (recamountcustomer <= dpbalpayment)
                                       {

                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           totalamountcustomer = recpaidamount + recamountcustomer;
                                           if (totalamountcustomer <= dpbalpayment)
                                           {
                                               dpdemo = recpaidamount;
                                               emidemo = 0;
                                               fix = 0;
                                           }
                                           else
                                           {
                                               overamount = totalamountcustomer - dpbalpayment;
                                               dpdemo = recpaidamount - overamount;
                                               emidemo = overamount;

                                               fix = pendingemi2;
                                           }
                                           dr1["DPAMOUNT"] = dpdemo;
                                       }
                                       else
                                       {
                                           dpdemo = 0;
                                           dr1["DPAMOUNT"] = "COMPLETED";
                                           recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                           emidemo = recpaidamount;
                                           fix = pendingemi2;
                                       }
                                       dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                       dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                       dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                       // dr1["DPAMOUNT"] = dpdemo;
                                       sumdppaid = sumdppaid + dpdemo;
                                       dr1["EMIAMOUNT"] = emidemo;
                                       sumemipaid = sumemipaid + emidemo;
                                       dr1["LATE_EMI"] = latemipay;
                                       dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                       //payment = payment + lateemipayment;
                                       dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                       statusragistry(reg);
                                       dr1["STATUS"] = status;
                                       dr1["FIXEDEMI"] = fix;
                                       paiddt.Rows.Add(dr1);
                                       dr1 = paiddt.NewRow();
                                       if (k != ds9.Tables[0].Rows.Count - 1)
                                       {
                                          // i = i + 1;
                                          // continue;
                                          // k = k + 1;
										   break;

                                       }
                                       recpaidamount = 0;
                                   }
                               }
                               else
                               {

                                   recpaidamount = 0;
                                   SqlDataAdapter cmd7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where status='PAID' AND (DATE1 < '" + date10 + "') AND CUSTREGNO='" + reg + "'", con1);
                                   DataSet ds7 = new DataSet();
                                   cmd7.Fill(ds7);
                                   con1.Close();
                                   if (ds7.Tables[0].Rows.Count > 0)
                                   {
                                       if (ds7.Tables[0].Rows[0][0].ToString() != "")
                                       {
                                           recamountcustomer = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                                       }
                                       else
                                       {
                                           recamountcustomer = 0;
                                       }

                                   }
                                   dpbalpayment = Convert.ToDouble(Label16.Text);
                                   fix = pendingemi2;

                                   if (recamountcustomer <= dpbalpayment)
                                   {

                                       recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                       totalamountcustomer = recpaidamount + recamountcustomer;
                                       if (totalamountcustomer <= dpbalpayment)
                                       {
                                           dpdemo = recpaidamount;
                                           emidemo = 0;
                                           fix = 0;
                                       }
                                       else
                                       {
                                           overamount = totalamountcustomer - dpbalpayment;
                                           dpdemo = recpaidamount - overamount;
                                           emidemo = overamount;

                                           fix = pendingemi2;
                                       }
                                       dr1["DPAMOUNT"] = dpdemo;
                                   }
                                   else
                                   {
                                       dpdemo = 0;
                                       dr1["DPAMOUNT"] = "COMPLETED";
                                       recpaidamount = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                       emidemo = recpaidamount;
                                       fix = pendingemi2;
                                   }
                                   dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                   dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                   dr1["DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                                   // dr1["DPAMOUNT"] = dpdemo;
                                   sumdppaid = sumdppaid + dpdemo;
                                   dr1["EMIAMOUNT"] = emidemo;
                                   sumemipaid = sumemipaid + emidemo;
                                   dr1["LATE_EMI"] = latemipay;
                                   dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                   //payment = payment + lateemipayment;
                                   dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                   statusragistry(reg);
                                   dr1["STATUS"] = status;
                                   dr1["FIXEDEMI"] = fix;
                                   paiddt.Rows.Add(dr1);

                               }

                           }





                       }
                   }
                   GridView1.DataSource = paiddt;
                   GridView1.DataBind();

                   DataTable demo = new DataTable();
                   demo.Columns.AddRange(new DataColumn[4] { new DataColumn("REGNO", typeof(string)), new DataColumn("amount", typeof(int)), new DataColumn("fixedpay", typeof(int)), new DataColumn("STATUSP", typeof(string)) });
                   DataRow dr2 = demo.NewRow();

                   Double finalfixed = 0, otherfix = 0, comfix = 0, dm = 0;
                   String st = "";
                   for (int j = 0; j < paiddt.Rows.Count; j++)
                   {


                       int c = 0;
                       Double emifi = 0;
                       st = "";
                       for (int h = 0; h < demo.Rows.Count; h++)
                       {
                           if (demo.Rows[h][0].ToString() == paiddt.Rows[j][0].ToString())
                           {
                               c = 1;

                               dm = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                               // dr2["amount"] = dm;
                               string find = "REGNO = '" + paiddt.Rows[j][0].ToString() + "'";
                               //find out id  
                               DataRow[] resultupdate = demo.Select(find);
                               //update row  
                               resultupdate[0]["amount"] = dm;
                               resultupdate[0]["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                               // resultupdate[0]["STATUSP"] =paiddt.Rows[j][8].ToString();
                               //Accept Changes  
                               demo.AcceptChanges();
                               break;
                           }




                       }
                       if (c == 0)
                       {
                           String hu = paiddt.Rows[j][0].ToString();
                           st = paiddt.Rows[j][8].ToString();
                           dr2["REGNO"] = hu;
                           emifi = Convert.ToDouble(paiddt.Rows[j][9].ToString());
                           dr2["amount"] = emifi;
                           dr2["fixedpay"] = Convert.ToDouble(paiddt.Rows[j][6].ToString());
                           dr2["STATUSP"] = paiddt.Rows[j][8].ToString();

                           demo.Rows.Add(dr2);
                           dr2 = demo.NewRow();
                       }
                       otherfix = otherfix + Convert.ToDouble(paiddt.Rows[j][4].ToString());



                   }
                   int count = 0;
                   for (int j = 0; j < demo.Rows.Count; j++)
                   {
                       finalfixed = finalfixed + Convert.ToDouble(demo.Rows[j][1].ToString());
                       //payment = payment + Convert.ToDouble(demo.Rows[j][2].ToString());
                       if (Convert.ToDouble(demo.Rows[j][1].ToString()) != 0)
                       {
                           count = count + 1;
                       }
                       if (demo.Rows[j][3].ToString() == "completed")
                       {
                           comfix = comfix + Convert.ToDouble(demo.Rows[j][1].ToString());
                       }


                   }
                   Label47.Text = count.ToString();
                   //Label29.Text = payment.ToString();
                   Label30.Text = sumdppaid.ToString();
                   //  finalfixed = finalfixed -first;
                   Label31.Text = finalfixed.ToString();


                   Label45.Text = (otherfix - finalfixed).ToString();
                   Label46.Text = comfix.ToString();
                   Double extra = 0;
                   extra = otherfix - finalfixed;
                   if (extra >= 0)
                   {
                       Label45.Text = extra.ToString();
                       Label45.ForeColor = System.Drawing.Color.Green;
                   }
                   else
                   {
                       Label45.Text = extra.ToString();
                       Label45.ForeColor = System.Drawing.Color.Red;
                   }
                  
               }
               //Label29.Text = payment.ToString();
               nonpaid(DropDownList3.Text);
           }
       }
   }







   protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
   {
       try
       {
           payment = 0;
           sumemipaid = 0;
           sumdppaid = 0;
           pendingemi = 0;
           String arazi = "", user = "";
           if (DropDownList1.Text == "PAID")
           {
               Label1.Text = "";
               singlepaid(DropDownList3.Text);
                Label33.Text = (Convert.ToDouble(Label32.Text) - Convert.ToDouble(Label31.Text)).ToString();
                Label49.Text = (Convert.ToDouble(Label31.Text) + Convert.ToDouble(Label30.Text)+ Convert.ToDouble(Label45.Text)).ToString();
                Double emipaid = 0, extr = 0, totalfix = 0;
                totalfix = Convert.ToDouble(Label31.Text);
                extr = Convert.ToDouble(Label45.Text);
                if (extr < 0)
                {
                    emipaid = totalfix + extr;
                    Label31.Text = emipaid.ToString();
                }

           }
           else
           {

               Label1.Text = "Please Select Option";
               GridView1.DataSource = null;
               GridView1.DataBind();
               Label29.Text = "0"; Label30.Text = "0"; Label31.Text = "0"; Label32.Text = "0"; Label33.Text = "0";Label49.Text = "0";
           }

       }
       catch (Exception t)
       {
           Label1.Text = "internal problem" + t;
       }
   }


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.Text != "152")
        {
            DropDownList4.Visible = false;
            
            Label44.Visible = false;
        }
        else
        {
            DropDownList4.Visible =true;
            Label44.Visible = true;
        }
    }





    // emi calculation code below


    public void emical(string reg)
    {
        int total1 = 0, total = 0, balance = 0;
        Label1.Text = "";
        
        try
        {
            reg = reg;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select LEFT(NAMEDOBADDRESS,20),CONSAMOUNT,plotno,PLOTSIZE,date3,APPNO,lastdate,regstatus FROM wjstar1.customerreg1 where CUSTREGNO='" + reg + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();

            SqlDataAdapter da2 = new SqlDataAdapter("select TOP 1 DATE1,AMOUNTR from wjstar1.recipt1 where CUSTREGNO='" + reg + "' order by DATE1 DESC", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label25.Text = Convert.ToDateTime(ds2.Tables[0].Rows[0][0]).ToString("dd/MM/yyyy");
                    Label26.Text = ds2.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    Label25.Text = "0";
                    Label26.Text = "0";
                }
            }
            SqlCommand cmd1 = new SqlCommand("select sum(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO='" + reg + "'", con1);

            con1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            total1 = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            if (dr1.HasRows == true)
            {
                while (dr1.Read())
                {
                    // total1 = Convert.ToInt32(dr.GetValue(1));
                    total = Convert.ToInt32(dr1.GetValue(0));
                }
                balance = total1 - total;

                Label7.Text = total.ToString();
                Label8.Text = balance.ToString();
            }

            con1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][7].ToString() != "Cancel")
                {
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        
                            Label5.Text = ds.Tables[0].Rows[0][0].ToString();
                            Label6.Text = ds.Tables[0].Rows[0][1].ToString();
                            Label3.Text = ds.Tables[0].Rows[0][2].ToString();
                            Label28.Text = ds.Tables[0].Rows[0][3].ToString();
                            //Label14.Text = ds.Tables[0].Rows[0][4].ToString();
                            String drbook = ds.Tables[0].Rows[0][4].ToString();
                            Label14.Text = Convert.ToDateTime(drbook).ToString("dd/MM/yyyy");
                            Label2.Text = ds.Tables[0].Rows[0][5].ToString();
                            //Label15.Text = ds.Tables[0].Rows[0][6].ToString();
                            String drend = ds.Tables[0].Rows[0][6].ToString();
                            Label15.Text = Convert.ToDateTime(drend).ToString("dd/MM/yyyy");
                            arazisearch(Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()), Label2.Text, total,reg);
                        
                      
                    }
                    else
                    {
                       /* Label5.Text = "";
                        Label6.Text = "";
                        Label3.Text = "";
                        Label28.Text = "";
                        Label14.Text = "";
                        Label2.Text = "";
                        Label15.Text = "";*/

                    }
                }
                else
                {
                  /*  Label1.Text = "Plot Cancel";
                    Label2.Text = "0";
                    Label3.Text = "0";
                    Label28.Text = "0";
                    Label14.Text = "0";
                    Label15.Text = "0";
                    Label5.Text = "0";
                    Label6.Text = "0";
                    Label16.Text = "0";
                    Label9.Text = "0";
                    Label20.Text = "0";
                    Label12.Text = "0";
                    latemipay=0;
                    lateemipayment = 0;
                    Label7.Text = "0";
                    Label17.Text = "0";
                    Label10.Text = "0";
                    Label21.Text = "0";
                    Label13.Text = "0";
                    Label8.Text = "0";
                    Label18.Text = "0";
                    Label11.Text = "0";
                    Label22.Text = "0";
                    Label19.Text = "0";*/
                }
            }


        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }

    public void arazisearch(Double custotalpayment, string arazi, Double totalrecieve,string reg)
    {
        latemipay = 0;
        lateemipayment = 0;
        Double dp = 0, instpaid = 0, dppaid = 0, dpbal = 0, lateemiamount = 0, lateemi = 0, totalmonthfixedemi = 0, advancamount = 0, balemi = 0;
        int fixedemi = 0, paidemi = 0;
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select DATEDIFF(MONTH,date3,lastdate),date3 from  wjstar1.customerreg1 where CUSTREGNO='" + reg + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        Double mont = 0;
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            mont = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());

           // Label20.Text = mont.ToString();
        }
        else
        {
            mont = 0;
        }

        SqlDataAdapter da1 = new SqlDataAdapter("select floor(DATEDIFF(DAY,(select date3 from  wjstar1.customerreg1 where CUSTREGNO='" + reg+ "'),getdate())/30.46) ", con);
        con.Open();
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Double bal = 0, rec = 0;
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            bal = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            bal = 0;
        }


        if (arazi == "152" || arazi == "506" || arazi == "519" || arazi == "239" || arazi == "161GHA" || arazi == "186MI" || arazi == "RAMAI137")
        {
            dp = custotalpayment * 0.50;
            fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
           // Label23.Text = fixedemi.ToString();
            pendingemi2 = fixedemi;
           // pendingemi = pendingemi + fixedemi;
            if (totalrecieve <= dp)
            {
                dppaid = totalrecieve;
                dpbal = dp - dppaid;
               
                Label16.Text = dp.ToString();
              //  Label17.Text = dppaid.ToString();
               // Label18.Text = dpbal.ToString();
               // Label9.Text = (custotalpayment - dp).ToString();
                instpaid = 0;
                totalmonthfixedemi = fixedemi * (bal);
                lateemiamount = totalmonthfixedemi;
                advancamount = 0;
                lateemi = bal;
                paidemi = 0;
                balemi = mont - bal;
                //Label21.Text = paidemi.ToString();
                //Label22.Text = balemi.ToString();
                //Label19.Text = advancamount.ToString();
               // Label12.Text = lateemi.ToString();
                latemipay = lateemi;
				 Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                   // Label13.Text = lateemiamount.ToString();
					  lateemipayment = lateemiamount;
                }
                else
                {
                 //   Label13.Text = bal11.ToString();
					  lateemipayment = bal11;
                }
             
              
               // Label10.Text = instpaid.ToString("N0");
               // Label24.Text = instpaid.ToString("N0");
               // Label11.Text = (custotalpayment - dp).ToString();
                //an other calculation of emi

            }
            else
            {
                instpaid = totalrecieve - dp;

                totalmonthfixedemi = fixedemi * (bal);
                if (instpaid >= totalmonthfixedemi)
                {
                    advancamount = instpaid - totalmonthfixedemi;
                }
                else
                {
                    advancamount = 0;
                }

                paidemi = Convert.ToInt32(instpaid) / fixedemi;

                lateemi = bal - paidemi;
                if (lateemi <= 0)
                {
                    lateemi = 0;
                    totalmonthfixedemi = 0;
                }
                else
                {
                    lateemi = lateemi;
                    lateemiamount = -(totalmonthfixedemi - (lateemi * fixedemi) - instpaid);
                    lateemiamount = (lateemi * fixedemi) - lateemiamount;
                }
                balemi = mont - bal;
                Label16.Text = dp.ToString();
                //Label17.Text = dp.ToString();
                //Label18.Text = "0";
                //Label21.Text = Convert.ToInt32(bal).ToString();
                //Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                //Label22.Text = balemi.ToString();
                //Label19.Text = advancamount.ToString();
                //Label12.Text = lateemi.ToString();
                latemipay = lateemi;
                         
				 Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                   // Label13.Text = lateemiamount.ToString();
					  lateemipayment = lateemiamount;
                }
                else
                {
                   // Label13.Text = bal11.ToString();
					  lateemipayment = bal11;
                }
               // Label9.Text = (custotalpayment - dp).ToString();
               // Label10.Text = instpaid.ToString("N0");
               // Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

            }



        }
        else
        {
            if (arazi == "375KA" || arazi == "30" || arazi == "174MI" || arazi == "372KA" || arazi == "385KA")
            {
                dp = custotalpayment * 0.35;
                fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
              //  Label23.Text = fixedemi.ToString();
                pendingemi2 = fixedemi;
             //  pendingemi = pendingemi + fixedemi;
                if (totalrecieve <= dp)
                {
                    dppaid = totalrecieve;
                    dpbal = dp - dppaid;
                    Label16.Text = dp.ToString();
                  //  Label17.Text = dppaid.ToString();
                  //  Label18.Text = dpbal.ToString();
                   // Label9.Text = (custotalpayment - dp).ToString();
                    instpaid = 0;
                    totalmonthfixedemi = fixedemi * (bal);
                    lateemiamount = totalmonthfixedemi;
                    advancamount = 0;
                    lateemi = bal;
                    paidemi = 0;
                    balemi = mont - bal;
                  //  Label21.Text = paidemi.ToString();
                    //Label22.Text = balemi.ToString();
                    //Label19.Text = advancamount.ToString();
                    //Label12.Text = lateemi.ToString();
                    latemipay = lateemi;
                                 
				 Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                   // Label13.Text = lateemiamount.ToString();
					  lateemipayment = lateemiamount;
                }
                else
                {
                   // Label13.Text = bal11.ToString();
					  lateemipayment = bal11;
                }
                   // Label10.Text = instpaid.ToString("N0");
                   // Label24.Text = instpaid.ToString("N0");
                   // Label11.Text = (custotalpayment - dp).ToString();
                    //an other calculation of emi

                }
                else
                {
                    instpaid = totalrecieve - dp;

                    totalmonthfixedemi = fixedemi * (bal);
                    if (instpaid >= totalmonthfixedemi)
                    {
                        advancamount = instpaid - totalmonthfixedemi;
                    }
                    else
                    {
                        advancamount = 0;
                    }

                    paidemi = Convert.ToInt32(instpaid) / fixedemi;

                    lateemi = bal - paidemi;
                    if (lateemi <= 0)
                    {
                        lateemi = 0;
                        totalmonthfixedemi = 0;
                    }
                    else
                    {
                        lateemi = lateemi;
                        lateemiamount = -(totalmonthfixedemi - (lateemi * fixedemi) - instpaid);
                        lateemiamount = (lateemi * fixedemi) - lateemiamount;
                    }
                    balemi = mont - bal;
                    Label16.Text = dp.ToString();
                    //Label17.Text = dp.ToString();
                    //Label18.Text = "0";
                    //Label21.Text = Convert.ToInt32(bal).ToString();
                    //Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                    //Label22.Text = balemi.ToString();
                    //Label19.Text = advancamount.ToString();
                    //Label12.Text = lateemi.ToString();
                    latemipay = lateemi;
                                  
				 Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                   // Label13.Text = lateemiamount.ToString();
					  lateemipayment = lateemiamount;
                }
                else
                {
                   // Label13.Text = bal11.ToString();
					  lateemipayment = bal11;
                }
                  //  Label9.Text = (custotalpayment - dp).ToString();
                    //Label10.Text = instpaid.ToString("N0");
                    //Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

                }

            }
            else
            {
                if (arazi == "0" || arazi == "100" || arazi == "1204" || arazi == "1412" || arazi == "1414 surpal" || arazi == "1989" || arazi == "2011" || arazi == "24KA" || arazi == "254" || arazi == "274" || arazi == "239A" || arazi == "343" || arazi == "364" || arazi == "369" || arazi == "432" || arazi == "436" || arazi == "1989")
                {
                    dp = custotalpayment * 0.25;
                    fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
                    //Label23.Text = fixedemi.ToString();
                  //  pendingemi = pendingemi + fixedemi;
                    pendingemi2 = fixedemi;
                    if (totalrecieve <= dp)
                    {
                        dppaid = totalrecieve;
                        dpbal = dp - dppaid;
                        Label16.Text = dp.ToString();
                        Label17.Text = dppaid.ToString();
                        Label18.Text = dpbal.ToString();
                        Label9.Text = (custotalpayment - dp).ToString();
                        instpaid = 0;
                        totalmonthfixedemi = fixedemi * (bal);
                        lateemiamount = totalmonthfixedemi;
                        advancamount = 0;
                        lateemi = bal;
                        paidemi = 0;
                       // balemi = mont - bal;
                      //  Label21.Text = paidemi.ToString();
                       // Label22.Text = balemi.ToString();
                       // Label19.Text = advancamount.ToString();
                       // Label12.Text = lateemi.ToString();
                        latemipay = lateemi;
                                  
				 Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    Label13.Text = lateemiamount.ToString();
					  lateemipayment = lateemiamount;
                }
                else
                {
                    Label13.Text = bal11.ToString();
					  lateemipayment = bal11;
                }
                        Label10.Text = instpaid.ToString("N0");
                        Label24.Text = instpaid.ToString("N0");
                        Label11.Text = (custotalpayment - dp).ToString();
                        //an other calculation of emi

                    }
                    else
                    {
                        instpaid = totalrecieve - dp;

                        totalmonthfixedemi = fixedemi * (bal);
                        if (instpaid >= totalmonthfixedemi)
                        {
                            advancamount = instpaid - totalmonthfixedemi;
                        }
                        else
                        {
                            advancamount = 0;
                        }

                        paidemi = Convert.ToInt32(instpaid) / fixedemi;

                        lateemi = bal - paidemi;
                        if (lateemi <= 0)
                        {
                            lateemi = 0;
                            totalmonthfixedemi = 0;
                        }
                        else
                        {
                            lateemi = lateemi;
                            lateemiamount = -(totalmonthfixedemi - (lateemi * fixedemi) - instpaid);
                            lateemiamount = (lateemi * fixedemi) - lateemiamount;
                        }
                        balemi = mont - bal;
                       Label16.Text = dp.ToString();
                        //Label17.Text = dp.ToString();
                        //Label18.Text = "0";
                        //Label21.Text = Convert.ToInt32(bal).ToString();
                        //Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                        //Label22.Text = balemi.ToString();
                        //Label19.Text = advancamount.ToString();
                        //Label12.Text = lateemi.ToString();
                        latemipay = lateemi;
                                    
				 Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                  //  Label13.Text = lateemiamount.ToString();
					  lateemipayment = lateemiamount;
                }
                else
                {
                    //Label13.Text = bal11.ToString();
					  lateemipayment = bal11;
                }
                       // Label9.Text = (custotalpayment - dp).ToString();
                        //Label10.Text = instpaid.ToString("N0");
                        //Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

                    }
                }
            }
        }
    }


     //second details non pad
    public void emical1(string reg)
    {
        int total1 = 0, total = 0, balance = 0;
        Label1.Text = "";

        try
        {
            reg = reg;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select LEFT(NAMEDOBADDRESS,20),CONSAMOUNT,plotno,PLOTSIZE,date3,APPNO,lastdate,regstatus FROM wjstar1.customerreg1 where CUSTREGNO='" + reg + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();

            SqlDataAdapter da2 = new SqlDataAdapter("select TOP 1 DATE1,AMOUNTR from wjstar1.recipt1 where CUSTREGNO='" + reg + "' order by DATE1 DESC", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label25.Text = Convert.ToDateTime(ds2.Tables[0].Rows[0][0]).ToString("dd/MM/yyyy");
                    Label26.Text = ds2.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    Label25.Text = "0";
                    Label26.Text = "0";
                }
            }
            SqlCommand cmd1 = new SqlCommand("select sum(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO='" + reg + "'", con1);

            con1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            total1 = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            if (dr1.HasRows == true)
            {
                while (dr1.Read())
                {
                    // total1 = Convert.ToInt32(dr.GetValue(1));
                    total = Convert.ToInt32(dr1.GetValue(0));
                }
                balance = total1 - total;

                Label7.Text = total.ToString();
                Label8.Text = balance.ToString();
            }

            con1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][7].ToString() != "Cancel")
                {
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                          Label5.Text = ds.Tables[0].Rows[0][0].ToString();
                            Label6.Text = ds.Tables[0].Rows[0][1].ToString();
                            Label3.Text = ds.Tables[0].Rows[0][2].ToString();
                            Label28.Text = ds.Tables[0].Rows[0][3].ToString();
                            //Label14.Text = ds.Tables[0].Rows[0][4].ToString();
                            String drbook = ds.Tables[0].Rows[0][4].ToString();
                            Label14.Text = Convert.ToDateTime(drbook).ToString("dd/MM/yyyy");
                            Label2.Text = ds.Tables[0].Rows[0][5].ToString();
                            //Label15.Text = ds.Tables[0].Rows[0][6].ToString();
                            String drend = ds.Tables[0].Rows[0][6].ToString();
                            Label15.Text = Convert.ToDateTime(drend).ToString("dd/MM/yyyy");
                         //   arazisearch(Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()), Label2.Text, total, reg);
                           arazisearch1(Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()), Label2.Text, total, reg);
                       
                    }
                    else
                    {
                        Label5.Text = "";
                        Label6.Text = "";
                        Label3.Text = "";
                        Label28.Text = "";
                        Label14.Text = "";
                        Label2.Text = "";
                        Label15.Text = "";

                    }
                }
                else
                {
                    Label1.Text = "Plot Cancel";
                    Label2.Text = "0";
                    Label3.Text = "0";
                    Label28.Text = "0";
                    Label14.Text = "0";
                    Label15.Text = "0";
                    Label5.Text = "0";
                    Label6.Text = "0";
                    Label16.Text = "0";
                    Label9.Text = "0";
                    Label20.Text = "0";
                    Label12.Text = "0";
                    latemipay = 0;
                    lateemipayment = 0;
                    Label7.Text = "0";
                    Label17.Text = "0";
                    Label10.Text = "0";
                    Label21.Text = "0";
                    Label13.Text = "0";
                    Label8.Text = "0";
                    Label18.Text = "0";
                    Label11.Text = "0";
                    Label22.Text = "0";
                    Label19.Text = "0";
                }
            }


        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }

    public void arazisearch1(Double custotalpayment, string arazi, Double totalrecieve, string reg)
    {
        latemipay = 0;
        lateemipayment = 0;
        Double dp = 0, instpaid = 0, dppaid = 0, dpbal = 0, lateemiamount = 0, lateemi = 0, totalmonthfixedemi = 0, advancamount = 0, balemi = 0;
        int fixedemi = 0, paidemi = 0;
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select DATEDIFF(MONTH,date3,lastdate),date3 from  wjstar1.customerreg1 where CUSTREGNO='" + reg + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        Double mont = 0;
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            mont = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());

            // Label20.Text = mont.ToString();
        }
        else
        {
            mont = 0;
        }

        SqlDataAdapter da1 = new SqlDataAdapter("select floor(DATEDIFF(DAY,(select date3 from  wjstar1.customerreg1 where CUSTREGNO='" + reg + "'),getdate())/30.46) ", con);
        con.Open();
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Double bal = 0, rec = 0;
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            bal = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            bal = 0;
        }


        if (arazi == "152" || arazi == "506" || arazi == "519" || arazi == "239" || arazi == "161GHA" || arazi == "186MI" || arazi == "RAMAI137")
        {
            dp = custotalpayment * 0.50;
            fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
            // Label23.Text = fixedemi.ToString();
            //pendingemi2 = fixedemi;
             pendingemi = pendingemi + fixedemi;
            if (totalrecieve <= dp)
            {
                dppaid = totalrecieve;
                dpbal = dp - dppaid;

                Label16.Text = dp.ToString();
                //  Label17.Text = dppaid.ToString();
                // Label18.Text = dpbal.ToString();
                // Label9.Text = (custotalpayment - dp).ToString();
                instpaid = 0;
                totalmonthfixedemi = fixedemi * (bal);
                lateemiamount = totalmonthfixedemi;
                advancamount = 0;
                lateemi = bal;
                paidemi = 0;
                balemi = mont - bal;
                //Label21.Text = paidemi.ToString();
                //Label22.Text = balemi.ToString();
                //Label19.Text = advancamount.ToString();
                // Label12.Text = lateemi.ToString();
                latemipay = lateemi;
                Double bal11 = Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    // Label13.Text = lateemiamount.ToString();
                    lateemipayment = lateemiamount;
                }
                else
                {
                    //   Label13.Text = bal11.ToString();
                    lateemipayment = bal11;
                }


                // Label10.Text = instpaid.ToString("N0");
                // Label24.Text = instpaid.ToString("N0");
                // Label11.Text = (custotalpayment - dp).ToString();
                //an other calculation of emi

            }
            else
            {
                instpaid = totalrecieve - dp;

                totalmonthfixedemi = fixedemi * (bal);
                if (instpaid >= totalmonthfixedemi)
                {
                    advancamount = instpaid - totalmonthfixedemi;
                }
                else
                {
                    advancamount = 0;
                }

                paidemi = Convert.ToInt32(instpaid) / fixedemi;

                lateemi = bal - paidemi;
                if (lateemi <= 0)
                {
                    lateemi = 0;
                    totalmonthfixedemi = 0;
                }
                else
                {
                    lateemi = lateemi;
                    lateemiamount = -(totalmonthfixedemi - (lateemi * fixedemi) - instpaid);
                    lateemiamount = (lateemi * fixedemi) - lateemiamount;
                }
                balemi = mont - bal;
                Label16.Text = dp.ToString();
                //Label17.Text = dp.ToString();
                //Label18.Text = "0";
                //Label21.Text = Convert.ToInt32(bal).ToString();
                //Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                //Label22.Text = balemi.ToString();
                //Label19.Text = advancamount.ToString();
                //Label12.Text = lateemi.ToString();
                latemipay = lateemi;

                Double bal11 = Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    // Label13.Text = lateemiamount.ToString();
                    lateemipayment = lateemiamount;
                }
                else
                {
                    // Label13.Text = bal11.ToString();
                    lateemipayment = bal11;
                }
                // Label9.Text = (custotalpayment - dp).ToString();
                // Label10.Text = instpaid.ToString("N0");
                // Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

            }



        }
        else
        {
            if (arazi == "375KA" || arazi == "30" || arazi == "174MI" || arazi == "372KA" || arazi == "385KA")
            {
                dp = custotalpayment * 0.35;
                fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
                //  Label23.Text = fixedemi.ToString();
               // pendingemi2 = fixedemi;
                  pendingemi = pendingemi + fixedemi;
                if (totalrecieve <= dp)
                {
                    dppaid = totalrecieve;
                    dpbal = dp - dppaid;
                    Label16.Text = dp.ToString();
                    //  Label17.Text = dppaid.ToString();
                    //  Label18.Text = dpbal.ToString();
                    // Label9.Text = (custotalpayment - dp).ToString();
                    instpaid = 0;
                    totalmonthfixedemi = fixedemi * (bal);
                    lateemiamount = totalmonthfixedemi;
                    advancamount = 0;
                    lateemi = bal;
                    paidemi = 0;
                    balemi = mont - bal;
                    //  Label21.Text = paidemi.ToString();
                    //Label22.Text = balemi.ToString();
                    //Label19.Text = advancamount.ToString();
                    //Label12.Text = lateemi.ToString();
                    latemipay = lateemi;

                    Double bal11 = Convert.ToDouble(Label8.Text);
                    if (lateemiamount < bal11)
                    {
                        // Label13.Text = lateemiamount.ToString();
                        lateemipayment = lateemiamount;
                    }
                    else
                    {
                        // Label13.Text = bal11.ToString();
                        lateemipayment = bal11;
                    }
                    // Label10.Text = instpaid.ToString("N0");
                    // Label24.Text = instpaid.ToString("N0");
                    // Label11.Text = (custotalpayment - dp).ToString();
                    //an other calculation of emi

                }
                else
                {
                    instpaid = totalrecieve - dp;

                    totalmonthfixedemi = fixedemi * (bal);
                    if (instpaid >= totalmonthfixedemi)
                    {
                        advancamount = instpaid - totalmonthfixedemi;
                    }
                    else
                    {
                        advancamount = 0;
                    }

                    paidemi = Convert.ToInt32(instpaid) / fixedemi;

                    lateemi = bal - paidemi;
                    if (lateemi <= 0)
                    {
                        lateemi = 0;
                        totalmonthfixedemi = 0;
                    }
                    else
                    {
                        lateemi = lateemi;
                        lateemiamount = -(totalmonthfixedemi - (lateemi * fixedemi) - instpaid);
                        lateemiamount = (lateemi * fixedemi) - lateemiamount;
                    }
                    balemi = mont - bal;
                    Label16.Text = dp.ToString();
                    //Label17.Text = dp.ToString();
                    //Label18.Text = "0";
                    //Label21.Text = Convert.ToInt32(bal).ToString();
                    //Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                    //Label22.Text = balemi.ToString();
                    //Label19.Text = advancamount.ToString();
                    //Label12.Text = lateemi.ToString();
                    latemipay = lateemi;

                    Double bal11 = Convert.ToDouble(Label8.Text);
                    if (lateemiamount < bal11)
                    {
                        // Label13.Text = lateemiamount.ToString();
                        lateemipayment = lateemiamount;
                    }
                    else
                    {
                        // Label13.Text = bal11.ToString();
                        lateemipayment = bal11;
                    }
                    //  Label9.Text = (custotalpayment - dp).ToString();
                    //Label10.Text = instpaid.ToString("N0");
                    //Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

                }

            }
            else
            {
                if (arazi == "0" || arazi == "100" || arazi == "1204" || arazi == "1412" || arazi == "1414 surpal" || arazi == "1989" || arazi == "2011" || arazi == "24KA" || arazi == "254" || arazi == "274" || arazi == "239A" || arazi == "343" || arazi == "364" || arazi == "369" || arazi == "432" || arazi == "436" || arazi == "1989")
                {
                    dp = custotalpayment * 0.25;
                    fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
                    //Label23.Text = fixedemi.ToString();
                      pendingemi = pendingemi + fixedemi;
                 //   pendingemi2 = fixedemi;
                    if (totalrecieve <= dp)
                    {
                        dppaid = totalrecieve;
                        dpbal = dp - dppaid;
                        Label16.Text = dp.ToString();
                        Label17.Text = dppaid.ToString();
                        Label18.Text = dpbal.ToString();
                        Label9.Text = (custotalpayment - dp).ToString();
                        instpaid = 0;
                        totalmonthfixedemi = fixedemi * (bal);
                        lateemiamount = totalmonthfixedemi;
                        advancamount = 0;
                        lateemi = bal;
                        paidemi = 0;
                        // balemi = mont - bal;
                        //  Label21.Text = paidemi.ToString();
                        // Label22.Text = balemi.ToString();
                        // Label19.Text = advancamount.ToString();
                        // Label12.Text = lateemi.ToString();
                        latemipay = lateemi;

                        Double bal11 = Convert.ToDouble(Label8.Text);
                        if (lateemiamount < bal11)
                        {
                            Label13.Text = lateemiamount.ToString();
                            lateemipayment = lateemiamount;
                        }
                        else
                        {
                            Label13.Text = bal11.ToString();
                            lateemipayment = bal11;
                        }
                        Label10.Text = instpaid.ToString("N0");
                        Label24.Text = instpaid.ToString("N0");
                        Label11.Text = (custotalpayment - dp).ToString();
                        //an other calculation of emi

                    }
                    else
                    {
                        instpaid = totalrecieve - dp;

                        totalmonthfixedemi = fixedemi * (bal);
                        if (instpaid >= totalmonthfixedemi)
                        {
                            advancamount = instpaid - totalmonthfixedemi;
                        }
                        else
                        {
                            advancamount = 0;
                        }

                        paidemi = Convert.ToInt32(instpaid) / fixedemi;

                        lateemi = bal - paidemi;
                        if (lateemi <= 0)
                        {
                            lateemi = 0;
                            totalmonthfixedemi = 0;
                        }
                        else
                        {
                            lateemi = lateemi;
                            lateemiamount = -(totalmonthfixedemi - (lateemi * fixedemi) - instpaid);
                            lateemiamount = (lateemi * fixedemi) - lateemiamount;
                        }
                        balemi = mont - bal;
                        Label16.Text = dp.ToString();
                        //Label17.Text = dp.ToString();
                        //Label18.Text = "0";
                        //Label21.Text = Convert.ToInt32(bal).ToString();
                        //Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                        //Label22.Text = balemi.ToString();
                        //Label19.Text = advancamount.ToString();
                        //Label12.Text = lateemi.ToString();
                        latemipay = lateemi;

                        Double bal11 = Convert.ToDouble(Label8.Text);
                        if (lateemiamount < bal11)
                        {
                            //  Label13.Text = lateemiamount.ToString();
                            lateemipayment = lateemiamount;
                        }
                        else
                        {
                            //Label13.Text = bal11.ToString();
                            lateemipayment = bal11;
                        }
                        // Label9.Text = (custotalpayment - dp).ToString();
                        //Label10.Text = instpaid.ToString("N0");
                        //Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

                    }
                }
            }
        }
    }


    




 public void nonpaid(String user2)
   {
       pendingemi = 0;
       payment = 0;
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
       if (user2 != "ALL USER")
       {
           
           //GridView1.Visible = false;
           // GridView2.Visible = true;
           if (DropDownList2.Text != "ALL ARAZI")
           {
               if (DropDownList2.Text != "152")
               {
                   SqlConnection con1 = new SqlConnection(s);
                   con1.Open();

                   SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + user2 + "' ) AND date3<'"+date1+"'  AND  APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed' OR regstatus='Cancel')", con1);
                   DataSet ds = new DataSet();
                   cmd.Fill(ds);
                   //GridView2.DataSource = ds;
                   //GridView2.DataBind();
                   con1.Close();


                   string reg = "";
                   if (ds.Tables[0].Rows.Count > 0)
                   {
                       for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                       {
                           reg = "";
                           reg = ds.Tables[0].Rows[i][0].ToString();

                           emical1(reg);
                           payment = payment + lateemipayment;

                       }
                   }
                   Label29.Text = payment.ToString();

               }
               else
               {
                   if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                   {
                       SqlConnection con1 = new SqlConnection(s);
                       con1.Open();

                       SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where  date3<'" + date1 + "' AND CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + user2 + "') AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed' OR  regstatus='Cancel')", con1);
                       DataSet ds = new DataSet();
                       cmd.Fill(ds);
                       // GridView2.DataSource = ds;
                       // GridView2.DataBind();
                       con1.Close();

                       string reg = "";
                       if (ds.Tables[0].Rows.Count > 0)
                       {
                           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                           {
                               reg = "";
                               reg = ds.Tables[0].Rows[i][0].ToString();

                               emical1(reg);
                               payment = payment + lateemipayment;

                           }
                       }
                       Label29.Text = payment.ToString();

                   }
                   else
                   {
                       SqlConnection con1 = new SqlConnection(s);
                       con1.Open();

                       SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + user2 + "' ) AND date3<'" + date1 + "'  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block in('A','B','C')) AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed' OR regstatus='Cancel')", con1);
                       DataSet ds = new DataSet();
                       cmd.Fill(ds);
                       // GridView2.DataSource = ds;
                       //GridView2.DataBind();
                       con1.Close();

                       string reg = "";
                       if (ds.Tables[0].Rows.Count > 0)
                       {
                           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                           {
                               reg = "";
                               reg = ds.Tables[0].Rows[i][0].ToString();

                               emical1(reg);
                               payment = payment + lateemipayment;

                           }
                       }
                       Label29.Text = payment.ToString();

                   }

               }
          

           }
           else
           {
               allnonpaid(user2);
           }
           
           
           Label32.Text =( Convert.ToInt32(pendingemi.ToString())+Convert.ToInt32(Label46.Text)).ToString();
       }
       else
       {
           pendingemi = 0;
            if (DropDownList2.Text != "ALL ARAZI")
                        {
                            if (DropDownList2.Text != "152")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') )  AND  APPNO='" + DropDownList2.Text + "' AND date3<'" + date1 + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='completed' OR regstatus='Cancel')", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                                // GridView2.DataSource = ds;
                                // GridView2.DataBind();
                                con1.Close();
                               
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                                                               emical1(reg);
                                                                               payment = payment + lateemipayment;
                                       
                                    }
                                }
                                Label29.Text = payment.ToString();
                               
                            }
                            else
                            {
                                if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') ) AND date3<'" + date1 + "' AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where   regstatus='completed' OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                    // GridView2.DataSource = ds;
                                    // GridView2.DataBind();
                                    con1.Close();
                                   
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                       
                                            emical1(reg);
                                            payment = payment + lateemipayment;
                                        
                                        }
                                    }
                                    Label29.Text = payment.ToString();
                                   
                                }
                                else
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') )  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block in('A','B','C')) AND date3<'" + date1 + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where   regstatus='completed' OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                    //GridView2.DataSource = ds;
                                    //GridView2.DataBind();
                                    con1.Close();
                                   
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            
                                            emical1(reg);
                                            payment = payment + lateemipayment;
                                         
                                        }
                                    }
                                    Label29.Text = payment.ToString();
                                  
                                }

                            }
                        }
                        else
                        {
                            SqlConnection con1 = new SqlConnection(s);
                            con1.Open();

                            SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') ) AND date3<'" + date1 + "'  AND  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='completed' OR  regstatus='Cancel')", con1);
                            DataSet ds = new DataSet();
                            cmd.Fill(ds);
                            // GridView2.DataSource = ds;
                            // GridView2.DataBind();
                            con1.Close();
                           
                            string reg = "";
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    reg = "";
                                    reg = ds.Tables[0].Rows[i][0].ToString();
                                  
                                    emical1(reg);
                                    payment = payment + lateemipayment;
                                    
                                }
                            }
                            Label29.Text = payment.ToString();
                            
                        }

                    
       }
       Label32.Text = (Convert.ToInt32(pendingemi.ToString()) + Convert.ToInt32(Label46.Text)).ToString();
   }
 public void allnonpaid(String user2)
 {
      payment = 0;
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

        SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from wjstar1.customerreg1 where CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + user2 + "' ) AND date3<'" + date1 + "'  AND  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where  regstatus='completed' OR regstatus='Cancel')", con1);
     DataSet ds = new DataSet();
        cmd.Fill(ds);
       // GridView2.DataSource = ds;
        //GridView2.DataBind();
        con1.Close();
       
        string reg = "";
		 // pendingemi = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                reg = "";
                reg = ds.Tables[0].Rows[i][0].ToString();
               
                emical1(reg);
                
                
                payment = payment + lateemipayment;
              
                
            }
        }
       // GridView2.DataSource = paiddt1;
       // GridView2.DataBind();
        Label29.Text = payment.ToString();
 }



   



}