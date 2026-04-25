using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Drawing;

public partial class arazi137ramipur_emical : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        String reg1;
        if (IsPostBack)
        {
            reg1 = Session["CUSTID"].ToString();
            TextBox1.Text = reg1;
            search(reg1);
        }

    }
    public void search(String reg)
    {
        int total1 = 0, total = 0, balance = 0;
        Label1.Text = "";
      
        try
        {
            reg = TextBox1.Text;
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
                        if (ds.Tables[0].Rows[0][7].ToString() != "completed")
                        {
                            Label5.Text = ds.Tables[0].Rows[0][0].ToString();
                            Label6.Text = ds.Tables[0].Rows[0][1].ToString();
                            Label3.Text = ds.Tables[0].Rows[0][2].ToString();
                            Label4.Text = ds.Tables[0].Rows[0][3].ToString();
                            //Label14.Text = ds.Tables[0].Rows[0][4].ToString();
                            String drbook = ds.Tables[0].Rows[0][4].ToString();
                            Label14.Text = Convert.ToDateTime(drbook).ToString("dd/MM/yyyy");
                            Label2.Text = ds.Tables[0].Rows[0][5].ToString();
                            //Label15.Text = ds.Tables[0].Rows[0][6].ToString();
                            String drend = ds.Tables[0].Rows[0][6].ToString();
                            Label15.Text = Convert.ToDateTime(drend).ToString("dd/MM/yyyy");
                            arazisearch(Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()), Label2.Text, total);
                        }
                        else
                        {
                            Label1.Text = "Plot Completed";
                            Label2.Text = ds.Tables[0].Rows[0][5].ToString();
                            Label3.Text = ds.Tables[0].Rows[0][2].ToString();
                            Label4.Text = ds.Tables[0].Rows[0][3].ToString();
                            String drbook = ds.Tables[0].Rows[0][4].ToString();
                            Label14.Text = Convert.ToDateTime(drbook).ToString("dd/MM/yyyy");
                            String drend = ds.Tables[0].Rows[0][6].ToString();
                            Label15.Text = Convert.ToDateTime(drend).ToString("dd/MM/yyyy");
                            Label5.Text = ds.Tables[0].Rows[0][0].ToString();
                            Label6.Text = ds.Tables[0].Rows[0][1].ToString();
                            Label16.Text = "0";
                            Label9.Text = "0";
                            Label20.Text = "0";
                            Label12.Text = "0";
                            Label7.Text = total.ToString();
                            Label8.Text = balance.ToString();
                            Label17.Text = "0";
                            Label10.Text = "0";
                            Label21.Text = "0";
                            Label13.Text = "0";

                            Label18.Text = "0";
                            Label11.Text = "0";
                            Label22.Text = "0";
                            Label19.Text = "0";
                        }
                        //amountbal();
                    }
                    else
                    {
                        Label5.Text = "";
                        Label6.Text = "";
                        Label3.Text = "";
                        Label4.Text = "";
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
                    Label4.Text = "0";
                    Label14.Text = "0";
                    Label15.Text = "0";
                    Label5.Text = "0";
                    Label6.Text = "0";
                    Label16.Text = "0";
                    Label9.Text = "0";
                    Label20.Text = "0";
                    Label12.Text = "0";
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
   
    public void arazisearch(Double custotalpayment, string arazi, Double totalrecieve)
    {
        Double dp = 0, instpaid = 0, dppaid = 0, dpbal = 0, lateemiamount = 0, lateemi = 0, totalmonthfixedemi = 0, advancamount = 0, balemi = 0;
        int fixedemi = 0, paidemi = 0;
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select DATEDIFF(MONTH,date3,lastdate),date3 from  wjstar1.customerreg1 where CUSTREGNO='" + TextBox1.Text + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        Double mont = 0;
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            mont = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());

            Label20.Text = mont.ToString();
        }
        else
        {
            mont = 0;
        }

         SqlDataAdapter da1 = new SqlDataAdapter("select floor(DATEDIFF(DAY,(select date3 from  wjstar1.customerreg1 where CUSTREGNO='" + TextBox1.Text + "'),getdate())/30.46) ", con);
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
            fixedemi = Convert.ToInt32((custotalpayment - dp)/mont);
            Label23.Text = fixedemi.ToString();
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
                balemi = mont - bal;
                Label21.Text = paidemi.ToString();
                Label22.Text = balemi.ToString();
                Label19.Text = Convert.ToInt32(advancamount).ToString();
                Label12.Text = lateemi.ToString();
                 Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    Label13.Text = lateemiamount.ToString();
                }
                else
                {
                    Label13.Text = bal11.ToString();
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
                    advancamount =  instpaid-totalmonthfixedemi;
                }
                else
                {
                    advancamount = 0;
                }
                
                paidemi = Convert.ToInt32(instpaid)/fixedemi;
               
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
                Label17.Text = dp.ToString();
                Label18.Text = "0";
                Label21.Text = Convert.ToInt32(bal).ToString();
                Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                Label22.Text = balemi.ToString();
                Label19.Text = Convert.ToInt32(advancamount).ToString();
                Label12.Text = lateemi.ToString();
              Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    Label13.Text = lateemiamount.ToString();
                }
                else
                {
                    Label13.Text = bal11.ToString();
                }
                Label9.Text = (custotalpayment - dp).ToString();
                Label10.Text = instpaid.ToString("N0");
                Label11.Text = ((custotalpayment - dp)-instpaid).ToString();

            }
                

           
        }
        else
        {
            if (arazi == "375KA" || arazi == "30" || arazi == "174MI" || arazi == "372KA" || arazi == "385KA")
            {
                dp = custotalpayment * 0.35;
                fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
                Label23.Text = fixedemi.ToString();
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
                    balemi = mont - bal;
                    Label21.Text = paidemi.ToString();
                    Label22.Text = balemi.ToString();
                     Label19.Text = Convert.ToInt32(advancamount).ToString();
                    Label12.Text = lateemi.ToString();
                    Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    Label13.Text = lateemiamount.ToString();
                }
                else
                {
                    Label13.Text = bal11.ToString();
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
                    Label17.Text = dp.ToString();
                    Label18.Text = "0";
                    Label21.Text = Convert.ToInt32(bal).ToString();
                    Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                    Label22.Text = balemi.ToString();
                    Label19.Text = Convert.ToInt32(advancamount).ToString();
                    Label12.Text = lateemi.ToString();
                    Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    Label13.Text = lateemiamount.ToString();
                }
                else
                {
                    Label13.Text = bal11.ToString();
                }
                    Label9.Text = (custotalpayment - dp).ToString();
                    Label10.Text = instpaid.ToString("N0");
                    Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

                }

            }
            else
            {
                if (arazi == "0" || arazi == "100" || arazi == "1204" || arazi == "1412" || arazi == "1414 surpal" || arazi == "1989" || arazi == "2011" || arazi == "24KA" || arazi == "254" || arazi == "274" || arazi == "239A" || arazi == "343" || arazi == "364" || arazi == "369" || arazi == "432" || arazi == "436" || arazi == "1989")
                {
                    dp = custotalpayment * 0.25;
                    fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
                    Label23.Text = fixedemi.ToString();
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
                        balemi = mont - bal;
                        Label21.Text = paidemi.ToString();
                        Label22.Text = balemi.ToString();
                          Label19.Text = Convert.ToInt32(advancamount).ToString();
                        Label12.Text = lateemi.ToString();
                         Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    Label13.Text = lateemiamount.ToString();
                }
                else
                {
                    Label13.Text = bal11.ToString();
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
                        Label17.Text = dp.ToString();
                        Label18.Text = "0";
                        Label21.Text = Convert.ToInt32(bal).ToString();
                        Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                        Label22.Text = balemi.ToString();
                         Label19.Text = Convert.ToInt32(advancamount).ToString();
                        Label12.Text = lateemi.ToString();
                      Double bal11=Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    Label13.Text = lateemiamount.ToString();
                }
                else
                {
                    Label13.Text = bal11.ToString();
                }
                        Label9.Text = (custotalpayment - dp).ToString();
                        Label10.Text = instpaid.ToString("N0");
                        Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

                    }
                }
            }
        }
    }
    
}