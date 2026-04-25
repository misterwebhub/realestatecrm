using System;
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
public partial class kishan_Bin_map2_174mi_reciptupashok : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    string mob;
    public static string inst;
    public static string arazi = "";
    public static int amt, balamt, BL;
    public static Double instrecamt, dprecamt, total, fixedinst, instcutamt, dpcutamt;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack == true)
        {
            
           // Label4.Text = Session["ID"].ToString();
          Label4.Text = "Ashok8396";
            if (Label4.Text == "heedrealestate")
            {
                TextBox13.Visible = false;
                Label21.Visible = false;
                Label22.Visible = true;
                TextBox21.Visible = false;
                DropDownList1.Visible = true;
                user();
            }
            else
            {
                Label21.Visible = false;
                Label22.Visible = false;
                TextBox21.Visible = false;
                DropDownList1.Visible = false;
            }
            TextBox2.Text = "Kanpur";
            TextBox4.Text = "208015";
            // Label7.Text = "";
            Label6.Text = "";
            // Label8.Text = "";
            // Label9.Text = "";
            Label10.Text = "";
            Label20.Text = "0";
            DateTime r = DateTime.Now;
            int s = Convert.ToInt32(r.Day.ToString());
            int m = Convert.ToInt32(r.Month.ToString());
            if (m == 1 || m == 2 || m == 3 || m == 4 || m == 5 || m == 6 || m == 7 || m == 8 || m == 9)
            {
                if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                {
                    string s2 = r.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 1);
                    string yy = s2.Substring(4, 4);
                    string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                    TextBox19.Text = date1.ToString();

                }
                else
                {
                    string s2 = r.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 1);
                    string dd = s2.Substring(2, 2);
                    string yy = s2.Substring(5, 4);
                    string date1 = dd + "/" + "0" + mm + "/" + yy;
                    TextBox19.Text = date1.ToString();
                }

            }
            else
            {
                if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                {
                    string s2 = r.ToString("M/d/yyyy ");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 1);
                    string yy = s2.Substring(5, 4);
                    string date1 = "0" + dd + "/" + mm + "/" + yy;
                    TextBox19.Text = date1.ToString();

                }
                else
                {
                    string s2 = r.ToString("M/d/yyyy");
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 2);
                    string yy = s2.Substring(6, 4);
                    string date1 = dd + "/" + mm + "/" + yy;
                    TextBox19.Text = date1.ToString();
                }
            }



        }

    }
    public void user()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();


        SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT username FROM logininfo", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con1.Close();

        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
        {
            // DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            DropDownList1.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
        }
        con1.Close();
    }
    public void search()
    {
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            amt = 0;
            SqlDataAdapter cmd = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "'", con1);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            con1.Close();

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                amt = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }

            //TextBox15.Text = rcid.ToString();


            else
            {
                amt = 0;

            }
        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }
    public void fetch()
    {
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int rcid = 0;
            SqlCommand cmd = new SqlCommand("select max(RCID) from wjstar1.recipt1", con1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    rcid = Convert.ToInt32(dr.GetValue(0));
                }
                rcid = rcid + 1;
                TextBox3.Text = rcid.ToString();

            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    public void bouncecheque()
    {
        SqlConnection con1 = new SqlConnection(s);


        string chequenon = Label18.Text;
       /* if (chequenon != "")
        {
            SqlCommand cmd = new SqlCommand("update  chequebounce set status='PAID' where CUSTREGNO='" + TextBox1.Text + "'", con1);
            con1.Open();
            int i = cmd.ExecuteNonQuery();
            con1.Close();
        }
        */
    }
    public void entry(string usertype, string cheq)
    {
        try
        {
            int i = 0, tamt1;
            fetch();

            SqlConnection con1 = new SqlConnection(s);
            Double instpaidamount = instcutamt;
            Double dppaidamount = dpcutamt;
            Double chequeounce = Convert.ToDouble(Label19.Text);



            tamt1 = Convert.ToInt32(Label20.Text);

            string s2 = TextBox19.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string entrytime1 = DateTime.Now.ToString("h:mm:ss tt");

          /*  SqlCommand cmd = new SqlCommand("insert into wjstar1.recipt1(CUSTREGNO,ASCNAME,RECIPT,ASCCODE,DATE,DUDATE,NEXTDATE,INSTNO,ENDOFTERM,ASCADDRESS,PLANTERM,MOD,AMOUNTR,EXPLANDVALUE,SUBAMOUNT,LATECHARGE,ASSADDRESS,AMOUNTWORD,status,mobile,checkby,DATE1,usertype,insttype,userstatus,paidamount,deldate,dptotal,dppaid,dpbal,insttotal,instpaid,instbal,chequebounce,instamtpaid,dppaidamount,totalrec,chequeno,chequenopay,entrytime,discount)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox19.Text + "','" + TextBox20.Text + "','00','" + Label17.Text + "','" + TextBox8.Text + "','" + TextBox17.Text + "','" + TextBox11.Text + "','" + Label11.Text + "'," + Label20.Text + "," + TextBox14.Text + "," + TextBox15.Text + "," + TextBox16.Text + ",'" + TextBox17.Text + "','" + TextBox18.Text + "','PAID','" + Label3.Text + "','" + TextBox5.Text + "','" + date1 + "','" + usertype + "','Installment','Active',0,null,0,0,0,0,0,0," + chequeounce + "," + instpaidamount + "," + dppaidamount + "," + TextBox13.Text + ",'" + Label18.Text + "','" + cheq + "','" + entrytime1 + "',NULL)", con1);
            con1.Open();
            i = cmd.ExecuteNonQuery();
            con1.Close();
            bouncecheque();*/
            i = 1;
            if (i != 0)
            {
                Label1.Text = "Thank You for Paid Installment";
               /* SqlCommand cmd1 = new SqlCommand("update chequedetails set BSTATUS=NULL,BDATE=NULL,STATUS='PAID',paiddate='" + date1 + "' where  CUSTREGNO='" + TextBox1.Text + "' AND CHEQUENO='" + cheq + "'", con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();*/
                DateTime date56 = Convert.ToDateTime(Label25.Text);
                DateTime date57 = Convert.ToDateTime("09/01/2022");
                int result = DateTime.Compare(date56, date57);
                string relationship;
                if (result < 0)
                {
                    print1();


                    Response.Redirect("~/home/print.aspx");
                }
                else
                {
                    if (DropDownList2.Text == "CHEQUE")
                    {
                        print1();


                        Response.Redirect("~/home/print.aspx");
                    }
                    else
                    {
                        Label1.Text = "Record Added Successfully";

                    }
                }
            }
            else
            {
                Label1.Text = "Due to internal error";
            }

        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    { //string companyName = "WJSTAR LAND DEVELOPERS PRIVATE LIMITED";
        try
        {

            string usertype = "", cheq = "";
            if (Label4.Text == "heedrealestate")
            {
                if (DropDownList1.Text != "---SELECT---")
                {
                    usertype = DropDownList1.Text;
                    if (DropDownList2.Text == "CASH")
                    {

                        TextBox21.Text = "0";

                    }
                    else
                    {
                        if (DropDownList2.Text == "CHEQUE")
                        {
                            TextBox21.Text = TextBox21.Text;
                        }
                    }
                    cheq = TextBox21.Text;
                    entry(usertype, cheq);
                }
                else
                {
                    Label1.Text = "please select user first";
                }
            }
            else
            {
                cheq = "0";
                usertype = Label4.Text;
                entry(usertype, cheq);
            }

        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }


    public void print1()
    {
        Session["creg"] = TextBox1.Text;
        Session["ascname"] = TextBox2.Text;
        Session["recipt"] = TextBox3.Text;
        Session["asccode"] = TextBox4.Text;
        Session["date"] = TextBox19.Text;
        Session["dudate"] = TextBox20.Text;
        // Session["ndate"] = TextBox21.Text;
        Session["instno"] = inst;
        Session["endterm"] = TextBox8.Text;
        Session["ascaddr"] = ".";
        Session["planterm"] = TextBox11.Text;
        Session["mod"] = Label11.Text;
        Session["amr"] = TextBox13.Text;
        Session["expr"] = TextBox14.Text;
        Session["subam"] = TextBox15.Text;
        Session["latecharge"] = TextBox16.Text;
        Session["assaddr"] = TextBox17.Text;
        Session["amwrd"] = TextBox18.Text;
        Session["ref"] = TextBox5.Text;
        Session["book"] = Label6.Text;
        // Session["tdp"] = Label7.Text;
        // Session["tpdp"] = Label8.Text;
        //Session["tbdp"] = Label9.Text;
        //Session["rdp"] = Label12.Text;
        //Session["rpdp"] = Label13.Text;
        // Session["rbdp"] = Label14.Text;
        Session["balrec"] = Label20.Text;
        Session["chequebounce"] = Label19.Text;
        Session["chequeno"] = Label18.Text;
        Session["instno"] = Label17.Text;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox21.Visible = false;
        Label24.Visible = false;
        Label21.Visible = false;
        TextBox21.Text = "0";
        TextBox13.Text = "";
        Label24.Text = "";
        DropDownList2.Text = "----SELECT----";
        checkreg();
        instcount();
        // payment();
        bounce();
        latefine();

    }
    public void latefine()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da22 = new SqlDataAdapter("select DAY(date3) from  wjstar1.customerreg1 where CUSTREGNO='" + TextBox1.Text + "'", con1);
        DataSet ds22 = new DataSet();
        da22.Fill(ds22);
        con1.Close();
        con1.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select MONTH(DATE1),Year(DATE1) from wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "' AND DATE1 =(select max(DATE1) from  wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "')", con1);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con1.Close();
        if (ds2.Tables[0].Rows.Count > 0)
        {
            string dayedateString = ds22.Tables[0].Rows[0][0].ToString();
            string monthdateString = ds2.Tables[0].Rows[0][0].ToString();
            if (monthdateString == "2")
            {
                if (Convert.ToInt32(dayedateString) <= 28)
                {
                    dayedateString = ds22.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    dayedateString = "28";
                }

            }
            else
            {
                if (monthdateString == "1" || monthdateString == "3" || monthdateString == "5" || monthdateString == "7" || monthdateString == "8" || monthdateString == "10" || monthdateString == "12")
                {
                    dayedateString = ds22.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    if (Convert.ToInt32(dayedateString) <= 30)
                    {
                        dayedateString = ds22.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        dayedateString = "30";
                    }
                }
            }
            string yeardateString = ds2.Tables[0].Rows[0][1].ToString();
            string dateString = monthdateString + "/" + dayedateString + "/" + yeardateString;
            DateTime endDate = Convert.ToDateTime(dateString);
            DateTime now = DateTime.Now;

            int a = GetMonthDifference(now, endDate);
            Double late = 0;
            if (a > 1)
            {
                late = (fixedinst * 0.02) * (a - 1);
                TextBox16.Text = Convert.ToInt32(late).ToString();

            }
            else
            {
                TextBox16.Text = "0";
            }
            con1.Close();
        }
        else
        {
            TextBox16.Text = "0";
        }

    }
    public static int GetMonthDifference(DateTime startDate, DateTime endDate)
    {
        int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
        return Math.Abs(monthsApart);
    }
    public void bounce()
    {
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select chequeno from chequebounce where CUSTREGNO='" + TextBox1.Text + "' AND status='UNPAID'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            int c = 0;
            string cheque = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    c = c + 1;
                    cheque = cheque + ds.Tables[0].Rows[i][0].ToString();
                }
                Label18.Text = cheque;
                Label19.Text = (600 * c).ToString();
            }
            else
            {
                Label18.Text = "0";
                Label19.Text = "0";
            }
            //TextBox15.Text = rcid.ToString();



        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }
    public void checkreg()
    {
        string dudate = "", date2;
        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter("select CUSTREGNO,NAMEDOBADDRESS,CONSAMOUNT,PLANANDTERM,EXPIRYDATE,mobile,CHECKBY,DATEOFCOM,APPNO,plotno,regstatus,date3 from wjstar1.customerreg1", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();

            BL = 0;
            int r = 0, s1 = 0, amtr = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (TextBox1.Text == ds.Tables[0].Rows[i][0].ToString())
                    {
                        Label2.Text = ds.Tables[0].Rows[i][1].ToString();
                        // TextBox9.Text = ".";
                        //  TextBox9.Text = ds.Tables[0].Rows[i][1].ToString();
                        TextBox17.Text = ds.Tables[0].Rows[i][1].ToString();
                        TextBox14.Text = ds.Tables[0].Rows[i][2].ToString();
                        amtr = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                        total = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                        TextBox8.Text = ds.Tables[0].Rows[i][4].ToString();
                        TextBox11.Text = ds.Tables[0].Rows[i][3].ToString();
                        Label3.Text = ds.Tables[0].Rows[i][5].ToString();
                        TextBox5.Text = ds.Tables[0].Rows[i][6].ToString();
                        Label6.Text = ds.Tables[0].Rows[i][7].ToString();
                        Label25.Text = ds.Tables[0].Rows[i][11].ToString();
                        arazi = ds.Tables[0].Rows[i][8].ToString();
                        Label10.Text = arazi;
                        Label23.Text = ds.Tables[0].Rows[i][9].ToString();
                        if (ds.Tables[0].Rows[i][10].ToString() == "Registry" || ds.Tables[0].Rows[i][10].ToString() == "completed")
                        {
                            Image1.Visible = true;
                        }
                        else
                        {
                            Image1.Visible = false;
                        }

                        r = 1;
                        break;
                    }

                }
                if (TextBox5.Text == "")
                {
                    TextBox5.Text = "None";
                }


                con1.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select DUDATE from wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "' AND DATE1 =(select max(DATE1) from  wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "')", con1);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                con1.Close();

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            dudate = ds2.Tables[0].Rows[i][0].ToString();
                        }

                        s1 = 1;
                        break;
                    }

                }
                else
                {
                    DateTime thisDay = DateTime.Today;
                    string dd = thisDay.Day.ToString();
                    int dd2 = Convert.ToInt32(dd);
                    string mm = thisDay.Month.ToString();
                    int mm2 = Convert.ToInt32(mm);
                    string yy = thisDay.Year.ToString();

                    if (dd2 == 1 || dd2 == 2 || dd2 == 3 || dd2 == 4 || dd2 == 5 || dd2 == 6 || dd2 == 7 || dd2 == 8 || dd2 == 9)
                    {
                        dd = "0" + dd2;
                    }
                    if (mm2 == 1 || mm2 == 2 || mm2 == 3 || mm2 == 4 || mm2 == 5 || mm2 == 6 || mm2 == 7 || mm2 == 8 || mm2 == 9)
                    {
                        mm = "0" + mm2;
                    }

                    date2 = dd + "/" + mm + "/" + yy;
                    TextBox20.Text = date2;
                }
                if (r == 1)
                {
                    if (s1 == 1)
                    {
                        if (dudate != "")
                        {
                            string dd1 = dudate.Substring(0, 2);
                            string mm1 = dudate.Substring(3, 2);
                            int d2 = Convert.ToInt32(mm1);
                            d2 = d2 + 1;
                            string yy1 = dudate.Substring(6, 4);
                            if (d2 == 1 || d2 == 2 || d2 == 3 || d2 == 4 || d2 == 5 || d2 == 6 || d2 == 7 || d2 == 8 || d2 == 9)
                            {
                                date2 = dd1 + "/0" + d2 + "/" + yy1;
                            }
                            else
                            {
                                date2 = dd1 + "/" + d2 + "/" + yy1;
                            }
                        }
                        else
                        {
                            DateTime thisDay = DateTime.Today;
                            string dd = thisDay.Day.ToString();
                            int dd2 = Convert.ToInt32(dd);
                            string mm = thisDay.Month.ToString();
                            int mm2 = Convert.ToInt32(mm);
                            string yy = thisDay.Year.ToString();

                            if (dd2 == 1 || dd2 == 2 || dd2 == 3 || dd2 == 4 || dd2 == 5 || dd2 == 6 || dd2 == 7 || dd2 == 8 || dd2 == 9)
                            {
                                dd = "0" + dd2;
                            }
                            if (mm2 == 1 || mm2 == 2 || mm2 == 3 || mm2 == 4 || mm2 == 5 || mm2 == 6 || mm2 == 7 || mm2 == 8 || mm2 == 9)
                            {
                                mm = "0" + mm2;
                            }

                            date2 = dd + "/" + mm + "/" + yy;
                        }

                        TextBox20.Text = date2;
                        Label1.Text = "VALID CUSTOMER";
                        search();

                        //arazisearch(amt, amtr);
                        if (amt != 0)
                        {
                            balamt = amtr - amt;
                            TextBox15.Text = balamt.ToString();



                        }
                        else
                        {
                            balamt = amtr;
                            TextBox15.Text = balamt.ToString();
                        }


                    }
                    else
                    {
                        search();
                        // arazisearch(amt, amtr);
                        if (amt != 0)
                        {
                            balamt = amtr - amt;
                            TextBox15.Text = balamt.ToString();


                        }
                        else
                        {
                            balamt = amtr;
                            TextBox15.Text = balamt.ToString();
                        }
                    }

                    arazisearch(total);

                }
                else
                {
                    Label1.Text = "CUSTOMER NOT VALID";
                }
            }

        }
        finally
        {

            Label1.Text = "Error";
        }


    }
    public Double[] paymentsearch()
    {
        Double[] minMax = new Double[2];
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        Double instpaid = 0, dppaid = 0;
        SqlDataAdapter cmd = new SqlDataAdapter("select SUM(instamtpaid),sum(dppaidamount) from wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "'", con1);
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        con1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                instpaid = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                instpaid = 0;
            }
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                dppaid = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                dppaid = 0;
            }

        }

        else
        {
            instpaid = 0;
            dppaid = 0;
        }
        minMax[0] = instpaid;
        minMax[1] = dppaid;
        return minMax;

    }
    public void arazisearch(Double custotalpayment)
    {
        Double dp = 0, instpaid = 0, dppaid = 0, insbal = 0, pl = 0, al = 0;
        Double[] minMax = paymentsearch();
        instpaid = minMax[0];
        dppaid = minMax[1];
        if (arazi == "159" || arazi == "152" || arazi == "506" || arazi == "519" || arazi == "239" || arazi == "161GHA" || arazi == "186MI" || arazi == "RAMAI137" || arazi == "1452" || arazi == "357"  || arazi == "217" )
        {
            dp = custotalpayment * 0.50;
            if (dppaid <= dp)
            {

                //  Label7.Text = dp.ToString();
                //  Label8.Text = (dppaid).ToString();
                // Label8.ForeColor = System.Drawing.Color.Red;
                pl = dp - dppaid;
                // Label9.Text = pl.ToString();

            }
            else
            {
                // Label7.Text = dp.ToString();
                //Label8.Text = dppaid.ToString();
                // Label8.ForeColor = System.Drawing.Color.Green;
                // Label9.Text = "0";

            }
            insbal = total - dp;
            amountbal(insbal);

            if (instpaid <= insbal)
            {

                // Label12.Text = insbal.ToString();
                // Label13.Text = (instpaid).ToString();
                // Label14.ForeColor = System.Drawing.Color.Red;
                al = insbal - instpaid;
                // Label14.Text = al.ToString();

            }
            else
            {
                // Label12.Text = insbal.ToString();
                // Label13.Text = (instpaid).ToString();
                Label4.ForeColor = System.Drawing.Color.Green;
                // Label14.Text = "0";
                // instcount(); 
            }
        }
        else
        {
            if (arazi == "375KA" || arazi == "30" || arazi == "174MI" || arazi == "372KA" || arazi == "385KA")
            {
                dp = custotalpayment * 0.35;
                if (dppaid <= dp)
                {

                    //  Label7.Text = dp.ToString();
                    //  Label8.Text = (dppaid).ToString();
                    //  Label8.ForeColor = System.Drawing.Color.Red;
                    pl = dp - dppaid;
                    //  Label9.Text = pl.ToString();

                }
                else
                {
                    // Label7.Text = dp.ToString();
                    // Label8.Text = dppaid.ToString();
                    // Label8.ForeColor = System.Drawing.Color.Green;
                    // Label9.Text = "0";

                }
                insbal = total - dp;
                amountbal(insbal);

                if (instpaid <= insbal)
                {

                    // Label12.Text = insbal.ToString();
                    // Label13.Text = (instpaid).ToString();
                    // Label14.ForeColor = System.Drawing.Color.Red;
                    al = insbal - instpaid;
                    // Label14.Text = al.ToString();

                }
                else
                {
                    // Label12.Text = insbal.ToString();
                    // Label13.Text = (instpaid).ToString();
                    Label4.ForeColor = System.Drawing.Color.Green;
                    // Label14.Text = "0";
                    // instcount(); 
                }

            }
            else
            {
                if (arazi == "0" || arazi == "100" || arazi == "1204" || arazi == "1412" || arazi == "1414 surpal" || arazi == "1989" || arazi == "2011" || arazi == "24KA" || arazi == "254" || arazi == "274" || arazi == "239A" || arazi == "343" || arazi == "364" || arazi == "369" || arazi == "432" || arazi == "436" || arazi == "1989")
                {
                    dp = custotalpayment * 0.25;
                    if (dppaid <= dp)
                    {

                        // Label7.Text = dp.ToString();
                        // Label8.Text = (dppaid).ToString();
                        // Label8.ForeColor = System.Drawing.Color.Red;
                        pl = dp - dppaid;
                        // Label9.Text = pl.ToString();

                    }
                    else
                    {
                        //  Label7.Text = dp.ToString();
                        // Label8.Text = dppaid.ToString();
                        // Label8.ForeColor = System.Drawing.Color.Green;
                        // Label9.Text = "0";

                    }
                    insbal = total - dp;
                    amountbal(insbal);

                    if (instpaid <= insbal)
                    {

                        // Label12.Text = insbal.ToString();
                        // Label13.Text = (instpaid).ToString();
                        // Label14.ForeColor = System.Drawing.Color.Red;
                        al = insbal - instpaid;
                        //Label14.Text = al.ToString();

                    }
                    else
                    {
                        // Label12.Text = insbal.ToString();
                        // Label13.Text = (instpaid).ToString();
                        Label4.ForeColor = System.Drawing.Color.Green;
                        //Label14.Text = "0";
                        // instcount(); 
                    }
                }
            }
        }
    }
    public void instcount()
    {
        SqlConnection con1 = new SqlConnection(s);

        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select count(INSTNO) from wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "'", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con1.Close();


        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                int u = Convert.ToInt32(ds1.Tables[0].Rows[i][0].ToString());
                u = u + 1;
                // TextBox20.Text=ds1.Tables[0].Rows[i][1].ToString()
                inst = u.ToString();
                break;
            }

        }
        else
        {
            inst = "1 booking";
        }
        Label17.Text = inst;
    }
    public static string convertnumtoword(int number)
    {
        if (number == 0)
            return "Zero";
        if (number < 0)
            return "MINUS" + convertnumtoword(Math.Abs(number));
        string word = "";
        if ((number / 1000000) > 0 || (number / 100000) > 0)
        {
            if ((number / 1000000) > 0)
            {
                word += convertnumtoword(number / 1000000) + " Lakh ";
                number %= 1000000;
            }
            if ((number / 100000) > 0)
            {
                word += convertnumtoword(number / 100000) + " Lakh ";
                number %= 100000;
            }
        }
        if ((number / 1000) > 0)
        {
            word += convertnumtoword(number / 1000) + " Thousand ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            word += convertnumtoword(number / 100) + " Hundred ";
            number %= 100;
        }
        if (number > 0)
        {
            if (word != " ")
                word += "";
            var unitmap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tenmap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
            if (number < 20)
            {
                word += unitmap[number];
            }
            else
            {
                word += tenmap[number / 10];
                if ((number % 10) > 0)
                {
                    word += " " + unitmap[number % 10];
                }
            }
        }
        return word;

    }
    public void text(int valuetext)
    {
        int a = 0, b = 0, c = 0, finalbal = 0, totalamtdemo = 0, balamtdemo = 0;
        search();
        totalamtdemo = Convert.ToInt32(TextBox14.Text);
        balamtdemo = totalamtdemo - amt;
        a = balamtdemo;
        TextBox20.Text = TextBox20.Text;
        b = Convert.ToInt32(valuetext);
        finalbal = b - Convert.ToInt32(TextBox16.Text) - Convert.ToInt32(Label19.Text);
        c = a - finalbal;
        TextBox15.Text = c.ToString();
        Label20.Text = finalbal.ToString();

        string word = convertnumtoword(Convert.ToInt32(Label20.Text)) + " Rupees Only";
        TextBox18.Text = word;
        Double enteramt = 0;
        enteramt = finalbal;
        // checkpayment(enteramt);
    }
    protected void TextBox13_TextChanged(object sender, EventArgs e)
    {
        text(Convert.ToInt32(TextBox13.Text));
    }
    public int checkpayrecur()
    {
        int check = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select count(AMOUNTR) from wjstar1.recipt1 where month(DATE1)=month(getdate()) AND year(DATE1)=year(getdate()) AND CUSTREGNO='" + TextBox1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) != 0)
            {
                check = 1;
            }
            else
            {
                check = 0;
            }
        }
        else
        {
            check = 0;
        }
        return check;
    }
    public void checkpayment(Double recivepayment)
    {
        int checkdateinst = 0;
        Double fixpayment = 0, instpaid = 0, dppaid = 0, totalinst = 0, totaldp = 0, overdp = 0, acdppaid = 0;
        int balanaceinst = 0, balancedp = 0;
        int inst = 0, dpp = 0;
        instcutamt = 0;
        dpcutamt = 0;
        fixpayment = Convert.ToDouble(Label15.Text);

        Double[] minMax = paymentsearch();
        totalinst = Convert.ToDouble(Label12.Text);
        totaldp = Convert.ToDouble(Label7.Text);
        instpaid = minMax[0];
        dppaid = minMax[1];
        if (Label17.Text != "1")
        {
            checkdateinst = checkpayrecur();
            if (checkdateinst == 0)
            {
                if (dppaid <= totaldp)
                {
                    if (recivepayment <= fixpayment)
                    {
                        inst = Convert.ToInt32(recivepayment);
                        instpaid = instpaid + inst;
                        balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
                        // Label13.Text = Convert.ToInt32(instpaid).ToString();
                        //Label14.Text = Convert.ToInt32(balanaceinst).ToString();
                        //Label8.Text = Convert.ToInt32(dppaid).ToString();
                        balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
                        //Label9.Text = Convert.ToInt32(balancedp).ToString();
                        dpp = 0;

                    }
                    else
                    {
                        dpp = Convert.ToInt32(recivepayment) - Convert.ToInt32(fixpayment);
                        inst = Convert.ToInt32(recivepayment) - dpp;
                        dppaid = dppaid + dpp;
                        if (dppaid <= totaldp)
                        {
                            instpaid = instpaid + inst;

                        }
                        else
                        {
                            overdp = dppaid - totaldp;
                            dppaid = dppaid - overdp;
                            instpaid = instpaid + inst + overdp;
                            dpp = Convert.ToInt32(totaldp);
                            inst = inst + Convert.ToInt32(overdp);
                        }

                        balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
                        //  Label13.Text = Convert.ToInt32(instpaid).ToString();
                        //  Label14.Text = Convert.ToInt32(balanaceinst).ToString();
                        // Label8.Text = Convert.ToInt32(dppaid).ToString();
                        balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
                        // Label9.Text = Convert.ToInt32(balancedp).ToString();

                    }

                }

                else
                {

                    inst = Convert.ToInt32(recivepayment);
                    instpaid = instpaid + inst;
                    balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
                    // Label13.Text = Convert.ToInt32(instpaid).ToString();
                    // Label14.Text = Convert.ToInt32(balanaceinst).ToString();
                    // Label8.Text = Convert.ToInt32(dppaid).ToString();
                    balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
                    // Label9.Text = Convert.ToInt32(balancedp).ToString();

                    dpp = 0;

                }
            }
            else
            {
                if (dppaid <= totaldp)
                {


                    dpp = Convert.ToInt32(recivepayment);
                    inst = 0;
                    dppaid = dppaid + dpp;
                    if (dppaid <= totaldp)
                    {
                        instpaid = instpaid + inst;

                    }
                    else
                    {
                        overdp = dppaid - totaldp;
                        acdppaid = dpp - overdp;
                        instpaid = instpaid + inst + overdp;
                        dpp = Convert.ToInt32(acdppaid);
                        inst = inst + Convert.ToInt32(overdp);
                    }

                    balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
                    // Label13.Text = Convert.ToInt32(instpaid).ToString();
                    // Label14.Text = Convert.ToInt32(balanaceinst).ToString();
                    if (dppaid <= totaldp)
                    {
                        //  Label8.Text = Convert.ToInt32(dppaid).ToString();
                        balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
                        // Label9.Text = Convert.ToInt32(balancedp).ToString();
                    }
                    else
                    {
                        // Label8.Text = Convert.ToInt32(totaldp).ToString();
                        balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
                        // Label9.Text = Convert.ToInt32(0).ToString();
                    }




                }

                else
                {

                    inst = Convert.ToInt32(recivepayment);
                    instpaid = instpaid + inst;
                    balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
                    // Label13.Text = Convert.ToInt32(instpaid).ToString();
                    //Label14.Text = Convert.ToInt32(balanaceinst).ToString();
                    //Label8.Text = Convert.ToInt32(dppaid).ToString();
                    balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
                    //Label9.Text = Convert.ToInt32(balancedp).ToString();

                    dpp = 0;

                }
            }
        }

        else
        {
            dpp = Convert.ToInt32(recivepayment);
            inst = 0;
            dppaid = Convert.ToInt32(dppaid) + dpp;
            instpaid = instpaid + inst;
            balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
            // Label13.Text = Convert.ToInt32(instpaid).ToString();
            // Label14.Text = Convert.ToInt32(balanaceinst).ToString();
            // Label8.Text = Convert.ToInt32(dppaid).ToString();
            balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
            // Label9.Text = Convert.ToInt32(balancedp).ToString();


        }
        instcutamt = inst;
        dpcutamt = dpp;
    }


    public void amountbal(Double instbalrec)
    {
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select DATEDIFF(MONTH,date3,lastdate),date3 from  wjstar1.customerreg1 where CUSTREGNO='" + TextBox1.Text + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        String date3 = "";
        Double mont = 0;
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            mont = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            date3 = ds.Tables[0].Rows[0][1].ToString();
        }
        else
        {
            mont = 0;
        }

        Double paodbalinst = 0;
        if (mont == 0)
        {
            paodbalinst = instbalrec;
        }
        else
        {
            paodbalinst = instbalrec / mont;
        }

        fixedinst = paodbalinst;
        Label15.Text = paodbalinst.ToString("N0");
        SqlDataAdapter da1 = new SqlDataAdapter("select DATEDIFF(MONTH,(select TOP 1 DATE1 from wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "'),(select TOP 1 DATE1 from wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "' ORDER BY DATE1 DESC)) ", con);
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
        rec = mont - bal;
        Double paodbalinst1 = 0, recpaid = 0;
        recpaid = Convert.ToDouble(TextBox15.Text);
        paodbalinst1 = recpaid / rec;
        Label16.Text = paodbalinst1.ToString("N0");


    }


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.Text == "CASH")
        {
            TextBox13.Visible = true;
            Label21.Visible = false;
            TextBox21.Visible = false;
            TextBox21.Text = "0";
            Label24.Visible = false;
        }
        else
        {
            if (DropDownList2.Text == "CHEQUE")
            {
                TextBox13.Visible = true;
                Label21.Visible = true;
                TextBox21.Visible = true;
                Label24.Visible = true;
            }
        }
    }

    protected void TextBox21_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select CHEQUENO,CAMOUNT from  chequedetails where CUSTREGNO='" + TextBox1.Text + "'  AND STATUS='UNPAID'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        int rty = 0, amtcheck = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (TextBox21.Text == ds.Tables[0].Rows[i][0].ToString())
                {
                    rty = 1;
                    amtcheck = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    break;
                }
            }
            if (rty == 0)
            {
                Label24.Text = "CHEQUE NOT FOUND";
                Label24.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                Label24.Text = "CHEQUE FOUND";
                Label24.ForeColor = System.Drawing.Color.Green;
                TextBox13.Text = amtcheck.ToString();
                text(Convert.ToInt32(amtcheck));
            }
        }
        else
        {
            Label24.Text = "CHEQUE NOT FOUND";
            Label24.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void TextBox16_TextChanged(object sender, EventArgs e)
    {
        text(Convert.ToInt32(TextBox13.Text));
    }
}