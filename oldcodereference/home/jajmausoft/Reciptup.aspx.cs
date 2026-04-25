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

public partial class Reciptup : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    static string instno, insttype,noinst;
    static Double num = 0;
    public void bind()
    {
        Random r = new Random();
        int genRand = r.Next(1000,9999);
        num = Convert.ToDouble(genRand);
        Label7.Text = num.ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // Label4.Text = Session["ID"].ToString();
			if(Session["ID"] != null)
			{
				Label4.Text = Session["ID"].ToString();
			   //Label13.Text = "heedrealestate";
			}
			else
				
			{
				Response.Redirect("~/home/usercredential/credential.aspx");
			}
           // Label4.Text = "heedrealestate";
            Label5.Visible = false;
            TextBox6.Visible = false;
            Button5.Visible = false;
            bind();
            Panel1.Visible = false;
            bind3();
        }

    }
    public void bind3()
    {
        try
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

                DropDownList2.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label1.Text = "internal problem"+t;
        }
    }
    static Double recamty,amt, bal, tdp, tdppaid, tdpbal, tins, tinspaid, tinsbal, instcutamt, dpcutamt,fine,chequefine;
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    { //string companyName = "WJSTAR LAND DEVELOPERS PRIVATE LIMITED";
        Panel1.Visible = true;
    }
    public void FUN()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select DATEOFCOM from customerreg3 where CUSTREGNO IN(select CUSTREGNO from recipt3 where RECIPT='" + TextBox1.Text + "')", con1);
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
        Session["instno"] = Label17.Text;
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
        Session["tdp"] = Label11.Text;
        Session["tpdp"] = Label8.Text;
        Session["tbdp"] = Label9.Text;
        Session["rdp"] = Label12.Text;
        Session["rpdp"] = Label13.Text;
        Session["rbdp"] = Label14.Text;
        Session["balrec"] = Label20.Text;
        Session["chequebounce"] = TextBox22.Text;
        Session["chequeno"] = Label18.Text;

    }
    string dateofcom;
    string date222;
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = false;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter cmd = new SqlDataAdapter("select * from recipt3 where RECIPT='" + TextBox1.Text + "'", con1);
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
                String dudate = ds.Tables[0].Rows[0][5].ToString();
               
                if (dudate != "")
                {
                    string dd1 = dudate.Substring(0, 2);
                    string mm1 = dudate.Substring(3, 2);
                    int d2 = Convert.ToInt32(mm1);
                    
                    string yy1 = dudate.Substring(6, 4);
                    if (d2 == 1 || d2 == 2 || d2 == 3 || d2 == 4 || d2 == 5 || d2 == 6 || d2 == 7 || d2 == 8 || d2 == 9)
                    {
                        date222 = "0" + d2 + "/" + dd1 + "/" + yy1;
                    }
                    else
                    {
                        date222 = d2 + "/" + dd1 + "/" + yy1;
                    }
                }
                con1.Open();


                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where  CUSTREGNO IN(select CUSTREGNO from recipt3 where RECIPT='" + TextBox1.Text + "')  AND DATE1<='" + date222+ "'", con1);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                con1.Close();
                TextBox20.Text = ds.Tables[0].Rows[0][6].ToString();
               // TextBox21.Text = ds.Tables[0].Rows[0][7].ToString();
                instno=ds.Tables[0].Rows[0][8].ToString();
                TextBox8.Text = ds.Tables[0].Rows[0][9].ToString();
                TextBox9.Text = ds.Tables[0].Rows[0][10].ToString();
                TextBox11.Text = ds.Tables[0].Rows[0][11].ToString();
                DropDownList1.Text = ds.Tables[0].Rows[0][12].ToString();
                TextBox13.Text = ds.Tables[0].Rows[0][38].ToString();
                Label20.Text = ds.Tables[0].Rows[0][13].ToString();
                recamty =Convert.ToDouble(ds.Tables[0].Rows[0][13].ToString());
                amt = Convert.ToDouble(TextBox13.Text);
                TextBox21.Text = ds.Tables[0].Rows[0][13].ToString();
                TextBox14.Text = ds.Tables[0].Rows[0][14].ToString();
                
                int ta = 0, paidam = 0;
                ta = Convert.ToInt32(ds.Tables[0].Rows[0][14].ToString());
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][0].ToString() != "")
                    {
                        paidam = Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString());


                    }
                    else
                    {
                        paidam = 0;
                    }
                }
                bal = ta - paidam;
                TextBox15.Text = bal.ToString() ;
                bal = Convert.ToDouble(TextBox15.Text);
                
                TextBox16.Text = ds.Tables[0].Rows[0][16].ToString();
                fine = Convert.ToDouble(ds.Tables[0].Rows[0][16].ToString());
                TextBox17.Text = ds.Tables[0].Rows[0][17].ToString();
                TextBox18.Text = ds.Tables[0].Rows[0][18].ToString();
                Label11.Text = ds.Tables[0].Rows[0][29].ToString();
                tdp = Convert.ToDouble(Label11.Text);
                Label8.Text = ds.Tables[0].Rows[0][30].ToString();
                tdppaid = Convert.ToDouble(Label8.Text);
                Label9.Text = ds.Tables[0].Rows[0][31].ToString();
                tdpbal = Convert.ToDouble(ds.Tables[0].Rows[0][31].ToString());
                Label12.Text = ds.Tables[0].Rows[0][32].ToString();
                tins = Convert.ToDouble(Label12.Text);
                Label15.Text = tins.ToString(); ;
                Label13.Text = ds.Tables[0].Rows[0][33].ToString();
                tinspaid = Convert.ToDouble(Label13.Text);
                Label14.Text = ds.Tables[0].Rows[0][34].ToString();
                 tinsbal = Convert.ToDouble(ds.Tables[0].Rows[0][34].ToString());
                Label17.Text = ds.Tables[0].Rows[0][8].ToString();
                TextBox22.Text = ds.Tables[0].Rows[0][37].ToString();
                chequefine = Convert.ToDouble(ds.Tables[0].Rows[0][37].ToString());
                Label18.Text = ds.Tables[0].Rows[0][39].ToString();
                TextBox23.Text = ds.Tables[0].Rows[0][40].ToString();
                insttype = ds.Tables[0].Rows[0][25].ToString();
                DropDownList2.Text = ds.Tables[0].Rows[0][24].ToString();
                String reg =ds.Tables[0].Rows[0][1].ToString();
                amountbal(tins,reg);
            }
            else
            {
                Label1.Text = "not find receipt";
            }

           

        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }

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
    public void cal()
    {
        int a = 0, b = 0, c = 0, finalbal = 0, fi = 0;
        fi = Convert.ToInt32(fine);
        a = Convert.ToInt32(bal);
        TextBox20.Text = TextBox20.Text;
        b = Convert.ToInt32(TextBox13.Text);
        finalbal = b - Convert.ToInt32(TextBox16.Text) - Convert.ToInt32(TextBox22.Text);
        c = a - finalbal + Convert.ToInt32(recamty);
        TextBox15.Text = c.ToString();
        Label20.Text = finalbal.ToString();

        string word = convertnumtoword(Convert.ToInt32(Label20.Text)) + " Rupees Only";
        TextBox18.Text = word;
        Double enteramt = 0;
        enteramt = finalbal;
        checkpayment(enteramt);
    }
    protected void TextBox13_TextChanged(object sender, EventArgs e)
    {
       /* int a = 0, b = 0, c = 0;
        Double amt1,bal1,t13;
       
        TextBox20.Text = TextBox20.Text;
        t13 = Convert.ToDouble(Label20.Text);
        
        amt1 = amt -t13 ;
        bal1 = bal + amt1;
 
        TextBox15.Text = bal1.ToString();

        string word = convertnumtoword(Convert.ToInt32(Label20.Text)) + " Rupees Only";
        TextBox18.Text = word;*/

        cal();

    }
    public void amountbal(Double instbalrec,String reg)
    {
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select DATEDIFF(MONTH,date3,lastdate) from  customerreg3 where CUSTREGNO='" +reg + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
       // String date3 = "";
        Double mont = 0;
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            mont = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
           // date3 = ds.Tables[0].Rows[0][1].ToString();
        }
        else
        {
            mont = 0;
        }

        Double paodbalinst = 0;
        paodbalinst = instbalrec / mont;
       // fixedinst = paodbalinst;
        Label15.Text = paodbalinst.ToString("N2");
      


    }
    public void checkpayment(Double recivepayment)
    {
        Double fixpayment = 0, instpaid = 0, dppaid = 0, totalinst = 0, totaldp = 0, overdp = 0;
        int balanaceinst = 0, balancedp = 0;
        int inst = 0, dpp = 0;
        instcutamt = 0;
        dpcutamt = 0;
        fixpayment = Convert.ToDouble(Label15.Text);

       // Double[] minMax = paymentsearch();
        totalinst = Convert.ToDouble(Label12.Text);
        totaldp = Convert.ToDouble(Label11.Text);
        instpaid = tinspaid;
        dppaid =tdppaid;
        if (Label17.Text != "1")
        {
            if (dppaid <= totaldp)
            {
                if (recivepayment <= fixpayment)
                {
                    inst = Convert.ToInt32(recivepayment);
                    instpaid = instpaid + inst-instpaid;
                    balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
                    Label13.Text = Convert.ToInt32(instpaid).ToString();
                    Label14.Text = Convert.ToInt32(balanaceinst).ToString();
                    Label8.Text = Convert.ToInt32(dppaid).ToString();
                    balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
                    Label9.Text = Convert.ToInt32(balancedp).ToString();
                    dpp = 0;

                }
                else
                {
                   // dpp = Convert.ToInt32(recivepayment) - Convert.ToInt32(fixpayment);
				//	Double dpp6 = Convert.ToDouble(recivepayment) - Convert.ToDouble(fixpayment);
					dpp=0;
                    inst = Convert.ToInt32(recivepayment) - dpp;
                    dppaid = dppaid + dpp-dppaid;
                    if (dppaid <= totaldp)
                    {
                        instpaid = instpaid + inst-instpaid;

                    }
                    else
                    {
                        overdp = dppaid - totaldp;
                        dppaid = dppaid - overdp;
                        instpaid = instpaid + inst + overdp-instpaid;
                        dpp = Convert.ToInt32(totaldp);
                        inst = inst + Convert.ToInt32(overdp);
                    }

                    balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
                    Label13.Text = Convert.ToInt32(instpaid).ToString();
                    Label14.Text = Convert.ToInt32(balanaceinst).ToString();
                    Label8.Text = Convert.ToInt32(dppaid).ToString();
                    balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
                    Label9.Text = Convert.ToInt32(balancedp).ToString();

                }
            }
            else
            {

                inst = Convert.ToInt32(recivepayment);
                instpaid = instpaid + inst;
                balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
                Label13.Text = Convert.ToInt32(instpaid).ToString();
                Label14.Text = Convert.ToInt32(balanaceinst).ToString();
                Label8.Text = Convert.ToInt32(dppaid).ToString();
                balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
                Label9.Text = Convert.ToInt32(balancedp).ToString();

                dpp = 0;

            }
        }
        else
        {
            dpp = Convert.ToInt32(recivepayment);
            inst = 0;
            dppaid = Convert.ToInt32(dppaid) + dpp - Convert.ToInt32(dppaid);
            instpaid = instpaid + inst;
            balanaceinst = Convert.ToInt32(totalinst) - Convert.ToInt32(instpaid);
            Label13.Text = Convert.ToInt32(instpaid).ToString();
            Label14.Text = Convert.ToInt32(balanaceinst).ToString();
            Label8.Text = Convert.ToInt32(dppaid).ToString();
            balancedp = Convert.ToInt32(totaldp) - Convert.ToInt32(dppaid);
            Label9.Text = Convert.ToInt32(balancedp).ToString();


        }
        instcutamt = inst;
        dpcutamt = dpp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Label6.Text == "Varified")
        {SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        int tamt1, tamt;
        tamt1 = Convert.ToInt32(TextBox13.Text);
        string s2 = TextBox19.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        string date1 = mm + "/" + dd + "/" + yy;



        SqlCommand cmd = new SqlCommand("update recipt3 set ASCNAME='" + TextBox2.Text + "',ASCCODE='" + TextBox4.Text + "',DATE='" + TextBox19.Text + "',DUDATE='" + TextBox20.Text + "',NEXTDATE='00',INSTNO='" + Label17.Text + "',ENDOFTERM='" + TextBox8.Text + "',ASCADDRESS='" + TextBox9.Text + "',PLANTERM='" + TextBox11.Text + "',MOD='" + DropDownList1.Text + "',AMOUNTR=" + Label20.Text + ",EXPLANDVALUE=" + TextBox14.Text + ",SUBAMOUNT=" + TextBox15.Text + ",ASSADDRESS='" + TextBox17.Text + "',AMOUNTWORD='" + TextBox18.Text + "',checkby='" + TextBox5.Text + "',DATE1='" + date1 + "',usertype='" + DropDownList2.Text + "',insttype='" + Label17.Text + "',dptotal=" + Label11.Text + ",dppaid=" + Label8.Text + ",dpbal=" + Label9.Text + ",insttotal=" + Label12.Text + ",instpaid=" + Label13.Text + ",instbal=" + Label14.Text + ",LATECHARGE=" + TextBox16.Text + ",chequebounce=" + TextBox22.Text + ",instamtpaid=" + instcutamt + ",dppaidamount=" + dpcutamt + ",totalrec=" + TextBox13.Text + ",chequeno='" + Label18.Text + "',chequenopay='"+TextBox23.Text+"'  where RECIPT='" + TextBox1.Text + "'", con1);
        int i = cmd.ExecuteNonQuery();
        con1.Close();
            if (i != 0)
            {
                Label1.Text = "Record updated successfully";
               /* if (TextBox23.Text != "0")
                { 
                SqlCommand cmd1 = new SqlCommand("update chequedetails set BSTATUS=NULL,BDATE=NULL,STATUS='PAID',paiddate='" + date1 + "' where  CUSTREGNO='" + TextBox3.Text + "' AND CHEQUENO='" + TextBox23.Text + "'", con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();
            }*/
                print1();
                Response.Redirect("~/home/jajmausoft/print.aspx");
        }
        else
        {
            Label1.Text = "Due to internal error";
        }
        }
        else
        {
            Label6.Text = "Please enter correct OTP";
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Label5.Visible = true;
        TextBox6.Visible = true;
        Button5.Visible = true;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox6.Text == "")
        {
            Label6.Text = "*Please enter OTP";
        }
        else
        {
            if (TextBox6.Text == num.ToString())
            {

                Label6.Text = "Varified";
            }
            else
            {
                Label6.Text = "*Please enter correct OTP";
            }
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            if (Label6.Text == "Varified")
            {
               // string ddd = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                string s2 = TextBox24.Text;
                string dd = s2.Substring(0, 2);
                string mm = s2.Substring(3, 2);
                string yy = s2.Substring(6, 4);
                string ddd = mm + "/" + dd + "/" + yy;
                SqlConnection con1 = new SqlConnection(s);
                // SqlCommand cmd1 = new SqlCommand("insert into delrecipt(CUSTREGNO,NAME,DATE,AMOUNT,RECIPT,ARAZINO,PLOTNO,PLOTSIZE,CHECKBY,USERBY,PAIDAMOUNT,DELETEDATE)values('" + ds.Tables[0].Rows[0][0].ToString() + "','" + ds.Tables[0].Rows[0][1].ToString() + "','" + ds.Tables[0].Rows[0][3].ToString() + "'," + ds.Tables[0].Rows[0][4].ToString() + "," + ds.Tables[0].Rows[0][2].ToString() + ",'" + ds.Tables[0].Rows[0][7].ToString() + "','" + ds.Tables[0].Rows[0][8].ToString() + "','" + ds.Tables[0].Rows[0][9].ToString() + "','" + ds.Tables[0].Rows[0][5].ToString() + "','heedrealestate'," + TextBox21.Text + ",'" + ddd + "')", con1);
                SqlCommand cmd = new SqlCommand("update  recipt3 set usertype='"+DropDownList2.Text+"', userstatus='Inactive',paidamount=" + TextBox21.Text + ",deldate='" + ddd + "' where RECIPT='" + TextBox1.Text + "' ", con1);
                con1.Open();
                int i = cmd.ExecuteNonQuery();
                con1.Close();

                if (i == 1)
                {
                   
                    Label1.Text = "Installment deleted successfully";
                }
                else
                {
                    Label1.Text = "Due to internal error";
                }
            }
            else
            {
                Label6.Text = "Please Enter Correct OTP";
            }

        }
        catch (Exception t)
        {
            Label1.Text = "internal problem"+t;
        }
    }
    public String instcount()
    {
        String inst="";
        SqlConnection con1 = new SqlConnection(s);

        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select count(INSTNO) from recipt3 where CUSTREGNO='" + TextBox1.Text + "' AND insttype NOT IN('Downpayment')", con1);
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
        return inst;
    }
    protected void TextBox16_TextChanged(object sender, EventArgs e)
    {
        int fi = 0,gh=0,total=0,rec=0;
        fi = Convert.ToInt32(fine);
        gh = fi - Convert.ToInt32(TextBox16.Text);
        rec= Convert.ToInt32(Label20.Text);
        total = rec + gh;
        Label20.Text = total.ToString();
        cal();
    }
    protected void TextBox22_TextChanged(object sender, EventArgs e)
    {
        int fi = 0, gh = 0, total = 0, rec = 0;
        fi = Convert.ToInt32(chequefine);
        gh = fi - Convert.ToInt32(TextBox22.Text);
        rec = Convert.ToInt32(Label20.Text);
        total = rec + gh;
        Label20.Text = total.ToString();
        cal();
    }
    
}