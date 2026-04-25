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


public partial class arazipayment : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void datewise()
    {
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        int dd1 = Convert.ToInt32(dd);
        string mm = s2.Substring(3, 2);
        int mm1 = Convert.ToInt32(mm);
        string yy = s2.Substring(6, 4);
        int yy1 = Convert.ToInt32(yy);
        string s3 = TextBox2.Text;
        string dd2 = s3.Substring(0, 2);
        int dd22 = Convert.ToInt32(dd2);
        string mm2 = s3.Substring(3, 2);
        int mm22 = Convert.ToInt32(mm2);
        string yy2 = s3.Substring(6, 4);
        int yy22 = Convert.ToInt32(yy2);
        string date1 = mm + "/" + dd + "/" + yy;
        DateTime d1 = new DateTime(yy1, mm1, dd1, 0, 0, 0);
        DateTime d2 = d1.AddMonths(1).AddDays(-1);
        int date2 = d2.Day;
        double sum = 0;
        if (dd1 ==1 && date2 == dd22 && mm1==mm22 && yy1==yy22)
        {
            for (int i = 1; i <= dd22; i++)
            {
                DateTime d3 = new DateTime(yy1, mm1, i, 0, 0, 0);
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 = '" + d3 + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (i <= 9)
                    {
                        var label = ((Label)FindControl("Label10" + i));
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            label.Text = ds.Tables[0].Rows[0][0].ToString();
                            sum = sum + Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            label.Text = "0";
                            sum = sum + 0;
                        }
                    }
                    else
                    {
                        var label = ((Label)FindControl("Label1" + i));
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                        label.Text = ds.Tables[0].Rows[0][0].ToString();
                        sum = sum + Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            label.Text = "0";
                            sum = sum + 0;
                        }

                    }
                }
                
            }
            Label132.Text = sum.ToString();
        }
        else
        {
            for (int i = 101; i <= 132; i++)
            {
                var label = ((Label)FindControl("Label" + i));
                
                    label.Text = "0";
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        datewise();
        Double rec = 0;
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
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da90;
        
            
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='100' AND date3<='12/31/2020' )", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            Label1.Text = ds.Tables[0].Rows[0][0].ToString();

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1204' AND date3<='12/31/2020' )", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1412' AND date3<='12/31/2020' )", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            Label3.Text = ds2.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1414 surpal' AND date3<='12/31/2020' )", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            con.Close();
            Label4.Text = ds3.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='174MI' AND date3<='12/31/2020' )", con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            con.Close();
            Label5.Text = ds4.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='2011' AND date3<='12/31/2020' )", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            con.Close();
            Label6.Text = ds5.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da6 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='239' AND date3<='12/31/2020' )", con);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            con.Close();
            Label7.Text = ds6.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da7 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='254' AND date3<='12/31/2020')", con);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
            con.Close();
            Label8.Text = ds7.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da8 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='293A' AND date3<='12/31/2020' )", con);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            con.Close();
            Label9.Text = ds8.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da9 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='30' AND date3<='12/31/2020')", con);
            DataSet ds9 = new DataSet();
            da9.Fill(ds9);
            con.Close();
            Label10.Text = ds9.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da10 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='343' AND date3<='12/31/2020')", con);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            con.Close();
            Label11.Text = ds10.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da11 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='375KA' AND date3<='12/31/2020')", con);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11);
            con.Close();
            Label12.Text = ds11.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da12 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='432' AND date3<='12/31/2020')", con);
            DataSet ds12 = new DataSet();
            da12.Fill(ds12);
            con.Close();
            con.Open();
            SqlDataAdapter da19 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='436' AND date3<='12/31/2020')", con);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            con.Close();
            Label19.Text = ds19.Tables[0].Rows[0][0].ToString();
            Label13.Text = ds12.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da20 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='519' AND date3<='12/31/2020')", con);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            con.Close();
            Label60.Text = ds20.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da21 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='506' AND date3<='12/31/2020')", con);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            con.Close();
            Label62.Text = ds21.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da22 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND date3<='12/31/2020' )", con);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            con.Close();
            Label61.Text = ds22.Tables[0].Rows[0][0].ToString();
		con.Open();
            SqlDataAdapter da340 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='340' AND date3<='12/31/2020' )", con);
            DataSet ds340 = new DataSet();
            da340.Fill(ds340);
            con.Close();
            Label80.Text = ds340.Tables[0].Rows[0][0].ToString();
		con.Open();
            SqlDataAdapter da161gha = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='161GHA' AND date3<='12/31/2020' )", con);
            DataSet ds161gha = new DataSet();
            da161gha.Fill(ds161gha);
            con.Close();
            Label82.Text = ds161gha.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da372ka = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='372KA' AND date3<='12/31/2020' )", con);
            DataSet ds372ka = new DataSet();
            da372ka.Fill(ds372ka);
            con.Close();
            Label84.Text = ds372ka.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da385ka = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='385KA' AND date3<='12/31/2020' )", con);
            DataSet ds385ka = new DataSet();
            da385ka.Fill(ds385ka);
            con.Close();
            Label86.Text = ds385ka.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da186mi = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='186MI' AND date3<='12/31/2020' )", con);
            DataSet ds186mi = new DataSet();
            da186mi.Fill(ds186mi);
            con.Close();
            Label88.Text = ds186mi.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da137rm = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='RAMAI137' AND date3<='12/31/2020' )", con);
            DataSet ds137rm = new DataSet();
            da137rm.Fill(ds137rm);
            con.Close();
            Label90.Text = ds137rm.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da217rm = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='217' AND date3<='12/31/2020' )", con);
            DataSet ds217rm = new DataSet();
            da217rm.Fill(ds217rm);
            con.Close();
            Label94.Text = ds217rm.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da357rm = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='357' AND date3<='12/31/2020' )", con);
            DataSet ds357rm = new DataSet();
            da357rm.Fill(ds357rm);
            con.Close();
            Label95.Text = ds357rm.Tables[0].Rows[0][0].ToString();
            con.Open();
           
            SqlDataAdapter da2001g1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='2001GA' AND date3<='12/31/2020'  AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds2001g1 = new DataSet();
            da2001g1.Fill(ds2001g1);
            con.Close();
            Label134.Text = ds2001g1.Tables[0].Rows[0][0].ToString();
             da90 = new SqlDataAdapter("select SUM(AMOUNTR) from  wjstar1.recipt1 where  DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  date3<='12/31/2021' )", con);
            DataSet ds90 = new DataSet();
            da90.Fill(ds90);
            con.Close();
            con.Open();
            SqlDataAdapter da320rm = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='320' AND date3<='12/31/2020' )", con);
            DataSet ds320rm = new DataSet();
            da320rm.Fill(ds320rm);
            con.Close();
            Label137.Text = ds320rm.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da187rm = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='187-KHA' AND date3<='12/31/2020' )", con);
            DataSet ds187rm = new DataSet();
            da187rm.Fill(ds187rm);
            con.Close();
            Label135.Text = ds187rm.Tables[0].Rows[0][0].ToString();
            if (ds90.Tables[0].Rows[0][0].ToString() != "")
            {
                rec = Convert.ToDouble(ds90.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                rec = 0;
            }
       
        
            
            con.Open();
            SqlDataAdapter da111 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='100' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds111 = new DataSet();
            da111.Fill(ds111);
            con.Close();
            Label63.Text = ds111.Tables[0].Rows[0][0].ToString();

            con.Open();
            SqlDataAdapter da1111 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1204' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds1111 = new DataSet();
            da1111.Fill(ds1111);
            con.Close();
            Label64.Text = ds1111.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da222 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1412' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds222 = new DataSet();
            da222.Fill(ds222);
            con.Close();
            Label65.Text = ds222.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da333 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1414 surpal' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds333 = new DataSet();
            da333.Fill(ds333);
            con.Close();
            Label66.Text = ds333.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da444 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='174MI' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds444 = new DataSet();
            da444.Fill(ds444);
            con.Close();
            Label67.Text = ds444.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da555 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='2011' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds555 = new DataSet();
            da555.Fill(ds555);
            con.Close();
            Label68.Text = ds555.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da666 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='239' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds666 = new DataSet();
            da666.Fill(ds666);
            con.Close();
            Label69.Text = ds666.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da777 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='254' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds777 = new DataSet();
            da777.Fill(ds777);
            con.Close();
            Label70.Text = ds777.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da888 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='293A' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds888 = new DataSet();
            da888.Fill(ds888);
            con.Close();
            Label71.Text = ds888.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da999 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='30' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds999 = new DataSet();
            da999.Fill(ds999);
            con.Close();
            Label72.Text = ds999.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da1000 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='343' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds1000 = new DataSet();
            da1000.Fill(ds1000);
            con.Close();
            Label73.Text = ds1000.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da11111 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='375KA' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds11111 = new DataSet();
            da11111.Fill(ds11111);
            con.Close();
            Label74.Text = ds11111.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da1222 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='432' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds1222 = new DataSet();
            da1222.Fill(ds1222);
            con.Close();
            Label75.Text = ds1222.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da1999 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='436' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds1999 = new DataSet();
            da1999.Fill(ds1999);
            con.Close();
            Label76.Text = ds1999.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da3201 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='320' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds3201 = new DataSet();
            da3201.Fill(ds3201);
            con.Close();
            Label138.Text = ds3201.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da1871 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='187-KHA' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds1871 = new DataSet();
            da1871.Fill(ds1871);
            con.Close();
            Label136.Text = ds1871.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da2000 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='519' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds2000 = new DataSet();
            da2000.Fill(ds2000);
            con.Close();
            Label77.Text = ds2000.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da2111 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='506' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds2111 = new DataSet();
            da2111.Fill(ds2111);
            con.Close();
            Label78.Text = ds2111.Tables[0].Rows[0][0].ToString();
            con.Open();
            Double Total152 = 0, dblock = 0, eblock = 0, bal152 = 0,fblock=0;
            SqlDataAdapter da152d = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND date3>='01/01/2021' AND CUSTREGNO IN(select CUSTREGNO from arazi30beegha where block='D' AND status='book') )", con);
            DataSet ds152d = new DataSet();
            da152d.Fill(ds152d);
            con.Close();
            if (ds152d.Tables[0].Rows[0][0].ToString() != "")
            {
                Label92.Text = ds152d.Tables[0].Rows[0][0].ToString();
                dblock = Convert.ToDouble(ds152d.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                dblock = 0;
            }

            con.Open();
            SqlDataAdapter da152E = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND date3>='01/01/2021' AND CUSTREGNO IN(select CUSTREGNO from arazi30beegha where block='E' AND status='book') )", con);
            DataSet ds152E = new DataSet();
            da152E.Fill(ds152E);
            con.Close();
            if (ds152E.Tables[0].Rows[0][0].ToString() != "")
            {
                Label93.Text = ds152E.Tables[0].Rows[0][0].ToString();
                eblock = Convert.ToDouble(ds152E.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                eblock = 0;
            }
            SqlDataAdapter da152f = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND date3>='01/01/2021' AND CUSTREGNO IN(select CUSTREGNO from arazi30beegha where block='F' AND status='book') )", con);
            DataSet ds152f = new DataSet();
            da152f.Fill(ds152f);
            con.Close();
            if (ds152f.Tables[0].Rows[0][0].ToString() != "")
            {
                Label98.Text = ds152f.Tables[0].Rows[0][0].ToString();
                fblock = Convert.ToDouble(ds152f.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                fblock = 0;
            }
            con.Open();
            SqlDataAdapter da2222 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='152' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds2222 = new DataSet();
            da2222.Fill(ds2222);
            con.Close();
            if (ds2222.Tables[0].Rows[0][0].ToString() != "")
            {
               // Label79.Text = ds2222.Tables[0].Rows[0][0].ToString();
               Total152 = Convert.ToDouble(ds2222.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                Total152 = 0;
            }

            bal152 = Total152 - dblock - eblock-fblock;
            Label79.Text = bal152.ToString() ;
		con.Open();
            SqlDataAdapter da3401 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='340' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds3401 = new DataSet();
            da3401.Fill(ds3401);
            con.Close();
            Label81.Text = ds3401.Tables[0].Rows[0][0].ToString();
		con.Open();
            SqlDataAdapter da161gha1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='161GHA' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds161gha1 = new DataSet();
            da161gha1.Fill(ds161gha1);
            con.Close();
            Label83.Text = ds161gha1.Tables[0].Rows[0][0].ToString();
            con.Open();
        
            SqlDataAdapter da372ka1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='372KA' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds372ka1 = new DataSet();
            da372ka1.Fill(ds372ka1);
            con.Close();
            Label85.Text = ds372ka1.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da385ka1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='385KA' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds385ka1 = new DataSet();
            da385ka1.Fill(ds385ka1);
            con.Close();
            Label87.Text = ds385ka1.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da186mi1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='186MI' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds186mi1 = new DataSet();
            da186mi1.Fill(ds186mi1);
            con.Close();
            Label89.Text = ds186mi1.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da137rm1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='RAMAI137' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds137rm1 = new DataSet();
            da137rm1.Fill(ds137rm1);
            con.Close();
            Label91.Text = ds137rm1.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da217rm1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='217' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds217rm1 = new DataSet();
            da217rm1.Fill(ds217rm1);
            con.Close();
            Label96.Text = ds217rm1.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da357rm1 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='357' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds357rm1 = new DataSet();
            da357rm1.Fill(ds357rm1);
            con.Close();
            Label97.Text = ds357rm1.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da2001g = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='2001GA' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds2001g = new DataSet();
            da2001g.Fill(ds2001g);
            con.Close();
            Label133.Text = ds2001g.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da353 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='353' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds353 = new DataSet();
            da353.Fill(ds353);
            con.Close();
            Label778.Text = ds353.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da356 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='356' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds356 = new DataSet();
            da356.Fill(ds356);
            con.Close();
            Label779.Text = ds356.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da419 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='419' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds419 = new DataSet();
            da419.Fill(ds419);
            con.Close();
            Label780.Text = ds419.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da1731 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='1731' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds1731 = new DataSet();
            da1731.Fill(ds1731);
            con.Close();
            Label781.Text = ds1731.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da246 = new SqlDataAdapter("select SUM(AMOUNTR) from wjstar1.recipt1 where DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN(select CUSTREGNO from wjstar1.customerreg1 where APPNO='246_12BEEGHA' AND date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds246 = new DataSet();
            da246.Fill(ds246);
            con.Close();
            Label782.Text = ds246.Tables[0].Rows[0][0].ToString();
            con.Open();
            SqlDataAdapter da901;
            da901 = new SqlDataAdapter("select SUM(AMOUNTR) from  wjstar1.recipt1 where  DATE1 between '" + date1 + "' AND '" + date2 + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  date3>='01/01/2021' AND CUSTREGNO NOT IN(select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel'))", con);
            DataSet ds901 = new DataSet();
            da901.Fill(ds901);
            con.Close();
            
            
            Double rec1 = 0;
            if (ds901.Tables[0].Rows[0][0].ToString() != "")
            {
                rec1 = Convert.ToDouble(ds901.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                rec1 = 0;
            }
        
        Double l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13,l19,l60,l70,l71,l80,l81,l82,l84,l86,l88,l90, total = 0,bal=0,l94=0,l95=0,l134=0,l135=0,l137=0 ;
        if (Label1.Text == "")
            l1 = 0;
        else
            l1 = Convert.ToDouble(Label1.Text);
        if (Label2.Text == "")
            l2 = 0;
        else
            l2 = Convert.ToDouble(Label2.Text);
        if (Label3.Text == "")
            l3 = 0;
        else
            l3 = Convert.ToDouble(Label3.Text);
        if (Label4.Text == "")
            l4 = 0;
        else
            l4 = Convert.ToDouble(Label4.Text);
        if (Label5.Text == "")
            l5 = 0;
        else
            l5 = Convert.ToDouble(Label5.Text);
        if (Label6.Text == "")
            l6 = 0;
        else
            l6 = Convert.ToDouble(Label6.Text);
        if (Label7.Text == "")
            l7 = 0;
        else
            l7 = Convert.ToDouble(Label7.Text);
        if (Label8.Text == "")
            l8 = 0;
        else
            l8 = Convert.ToDouble(Label8.Text);
        if (Label9.Text == "")
            l9 = 0;
        else
            l9 = Convert.ToDouble(Label9.Text);
        if (Label10.Text == "")
            l10 = 0;
        else
            l10 = Convert.ToDouble(Label10.Text);
        if (Label11.Text == "")
            l11 = 0;
        else
            l11 = Convert.ToDouble(Label11.Text);
        if (Label12.Text == "")
            l12 = 0;
        else
            l12 = Convert.ToDouble(Label12.Text);
        if (Label13.Text == "")
            l13 = 0;
        else
            l13 = Convert.ToDouble(Label13.Text);
		if (Label19.Text == "")
            l19 = 0;
        else
            l19 = Convert.ToDouble(Label19.Text);
        if (Label60.Text == "")
            l60 = 0;
        else
            l60 = Convert.ToDouble(Label60.Text);
        if (Label61.Text == "")
            l70 = 0;
        else
            l70 = Convert.ToDouble(Label61.Text);
        if (Label62.Text == "")
            l71 = 0;
        else
            l71 = Convert.ToDouble(Label62.Text);
		if (Label80.Text == "")
            l80 = 0;
        else
            l80 = Convert.ToDouble(Label80.Text);
		if (Label81.Text == "")
            l81 = 0;
        else
            l81 = Convert.ToDouble(Label81.Text);
		if (Label82.Text == "")
            l82 = 0;
        else
            l82 = Convert.ToDouble(Label82.Text);
        if (Label84.Text == "")
            l84 = 0;
        else
            l84 = Convert.ToDouble(Label84.Text);
        if (Label86.Text == "")
            l86 = 0;
        else
            l86 = Convert.ToDouble(Label86.Text);
        if (Label88.Text == "")
            l88 = 0;
        else
            l88 = Convert.ToDouble(Label88.Text);
        if (Label90.Text == "")
            l90 = 0;
        else
            l90 = Convert.ToDouble(Label90.Text);
        if (Label94.Text == "")
            l94 = 0;
        else
            l94 = Convert.ToDouble(Label94.Text);
        if (Label95.Text == "")
            l95 = 0;
        else
            l95 = Convert.ToDouble(Label95.Text);
        if (Label134.Text == "")
            l134 = 0;
        else
            l134 = Convert.ToDouble(Label134.Text);
        if (Label135.Text == "")
            l135 = 0;
        else
            l135 = Convert.ToDouble(Label135.Text);
        if (Label137.Text == "")
            l137 = 0;
        else
            l137 = Convert.ToDouble(Label137.Text);

        total = l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8 + l9 + l10 + l11 + l12 + l13+l19+l60+l70+l71+l80+l82+l84+l86+l88+l90+l94+l95+l134+l135+l137;
		
        Label14.Text = total.ToString();
        //Label20.Text = total.ToString();
        
        
        Label21.Text = (total+rec1).ToString();
        //bal = total - rec;
        Label22.Text = rec1.ToString();

       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        Double total=0, recamt=0, emiamt=0,sum=0;
        int i;
        SqlConnection con = new SqlConnection(s);
        int from = Convert.ToInt32(TextBox3.Text);
        int to = Convert.ToInt32(TextBox4.Text);
        int year = Convert.ToInt32(TextBox5.Text);
        Label23.Text = " ";
        Label24.Text = " ";
        Label25.Text = " ";
        Label26.Text = " ";
        Label27.Text = " ";
        Label28.Text = " ";
        Label29.Text = " ";
        Label30.Text = " ";
        Label31.Text = " ";
        Label32.Text = " ";
        Label33.Text = " ";
        Label34.Text = " ";
        Label35.Text = " ";
        Label36.Text = " ";
        Label37.Text = " ";
        Label38.Text = " ";
        Label39.Text = " ";
        Label40.Text = " ";
        Label41.Text = " ";
        Label42.Text = " ";
        Label43.Text = " ";
        Label45.Text = " ";
        Label46.Text = " ";
        Label47.Text = " ";
        Label48.Text = " ";
        Label49.Text = " ";
        Label44.Text = " ";
        Label50.Text = " ";
        Label51.Text = " ";
        Label52.Text = " ";
        Label53.Text = " ";
        Label54.Text = " ";
        Label55.Text = " ";
        Label56.Text = " ";
        Label57.Text = " ";
        Label58.Text = " ";
        for (i=from; i <= to; i++)
        {
             if(i==1) 
             {  
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='"+i+"' AND year(DATE1)='"+year+"'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        total = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        total = 0;
                    }
                    Label23.Text = total.ToString();
				 sum=sum+total;
                    con.Close();
                     con.Open();
                     SqlDataAdapter da90 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                     DataSet ds90 = new DataSet();
                     da90.Fill(ds90);
                     con.Close();
                     if (ds90.Tables[0].Rows[0][0].ToString() != "")
                     {
                         recamt = Convert.ToDouble(ds90.Tables[0].Rows[0][0].ToString());
                     }
                     else
                     {
                         recamt = 0;
                     }
                    
                     Label24.Text =recamt.ToString();
                     emiamt = total - recamt;
                     Label25.Text = emiamt.ToString();
             }

               
                    if(i==2)
                    {
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    {
                        total = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        total = 0;
                    }
                    Label26.Text = total.ToString();
						 sum=sum+total;
                    con.Close();
                    con.Open();
                    SqlDataAdapter da22 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                    DataSet ds22 = new DataSet();
                    da22.Fill(ds22);
                    con.Close();
                    if (ds22.Tables[0].Rows[0][0].ToString() != "")
                    {
                        recamt = Convert.ToDouble(ds22.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        recamt = 0;
                    }
                    Label27.Text = recamt.ToString();
                    emiamt = total - recamt;
                    Label28.Text = emiamt.ToString();
                    }
                    if (i == 3)
                    {
                        con.Open();
                        SqlDataAdapter da3 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3);
                        if (ds3.Tables[0].Rows[0][0].ToString() != "")
                        {
                            total = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                       // total = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                        Label29.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da33 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds33 = new DataSet();
                        da33.Fill(ds33);
                        con.Close();
                        if (ds33.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds33.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                       
                        Label30.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label31.Text = emiamt.ToString();
                    }
                    if (i == 4)
                    {
                        con.Open();
                        SqlDataAdapter da4 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds4 = new DataSet();
                        da4.Fill(ds4);
                        if (ds4.Tables[0].Rows[0][0].ToString() != "")
                        {
                            total = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                        Label32.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da44 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds44 = new DataSet();
                        da44.Fill(ds44);
                        con.Close();
                        if (ds44.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds44.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                        Label33.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label34.Text = emiamt.ToString();
                    }
                    if (i == 5)
                    {
                        con.Open();
                        SqlDataAdapter da5 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds5 = new DataSet();
                        da5.Fill(ds5);
                        if (ds5.Tables[0].Rows[0][0].ToString() != "")
                        {
                            total = Convert.ToDouble(ds5.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                        Label35.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da55 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds55 = new DataSet();
                        da55.Fill(ds55);
                        con.Close();
                        if (ds55.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds55.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                        Label36.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label37.Text = emiamt.ToString();
                    }
                    if (i == 6)
                    {
                        con.Open();
                        SqlDataAdapter da6 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds6 = new DataSet();
                        da6.Fill(ds6);
                        if (ds6.Tables[0].Rows[0][0].ToString() != "")
                        {
                            total = Convert.ToDouble(ds6.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                        Label38.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da66 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds66 = new DataSet();
                        da66.Fill(ds66);
                        con.Close();
                        if (ds66.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds66.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                        Label39.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label40.Text = emiamt.ToString();
                    }
                    if (i == 7)
                    {
                        con.Open();
                        SqlDataAdapter da7 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds7 = new DataSet();
                        da7.Fill(ds7);
                        if (ds7.Tables[0].Rows[0][0].ToString() != "")
                        {
                            total = Convert.ToDouble(ds7.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                        Label41.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da77 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds77 = new DataSet();
                        da77.Fill(ds77);
                        con.Close();
                        if (ds77.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds77.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                        Label42.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label43.Text = emiamt.ToString();
                    }
                    if (i == 8)
                    {
                        con.Open();
                        SqlDataAdapter da8 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds8 = new DataSet();
                        da8.Fill(ds8);
                        if (ds8.Tables[0].Rows[0][0].ToString() != "")
                        {

                            total = Convert.ToDouble(ds8.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                        Label44.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da88 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds88 = new DataSet();
                        da88.Fill(ds88);
                        con.Close();
                        if (ds88.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds88.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                        Label45.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label46.Text = emiamt.ToString();
                    }
                    if (i == 9)
                    {
                        con.Open();
                        SqlDataAdapter da9 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds9 = new DataSet();
                        da9.Fill(ds9);
                        if (ds9.Tables[0].Rows[0][0].ToString() != "")
                        {
                            total = Convert.ToDouble(ds9.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                        Label47.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da99 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds99 = new DataSet();
                        da99.Fill(ds99);
                        con.Close();
                        if (ds99.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds99.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                        Label48.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label49.Text = emiamt.ToString();
                    }
                    if (i == 10)
                    {
                        con.Open();
                        SqlDataAdapter da10 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds10 = new DataSet();
                        da10.Fill(ds10);
                        if (ds10.Tables[0].Rows[0][0].ToString() != "")
                        {
                            total = Convert.ToDouble(ds10.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                        Label50.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da100 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds100 = new DataSet();
                        da100.Fill(ds100);
                        con.Close();
                        if (ds100.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds100.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                        Label51.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label52.Text = emiamt.ToString();
                    }
                    if (i == 11)
                    {
                        con.Open();
                        SqlDataAdapter da11 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds11 = new DataSet();
                        da11.Fill(ds11);
                        if (ds11.Tables[0].Rows[0][0].ToString() != "")
                        {
                            total = Convert.ToDouble(ds11.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                        Label53.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da111 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds111 = new DataSet();
                        da111.Fill(ds111);
                        con.Close();
                        if (ds111.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds111.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                        Label54.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label55.Text = emiamt.ToString();
                    }
                    if (i == 12)
                    {
                        con.Open();
                        SqlDataAdapter da12 = new SqlDataAdapter("select sum(AMOUNTR) from wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "'", con);
                        DataSet ds12 = new DataSet();
                        da12.Fill(ds12);
                        if (ds12.Tables[0].Rows[0][0].ToString() != "")
                        {
                            total = Convert.ToDouble(ds12.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            total = 0;
                        }
                        Label56.Text = total.ToString();
						 sum=sum+total;
                        con.Close();
                        con.Open();
                        SqlDataAdapter da112 = new SqlDataAdapter("select sum(AMOUNTR) from  wjstar1.recipt1 where month(DATE1)='" + i + "' AND year(DATE1)='" + year + "' AND CUSTREGNO IN (select CUSTREGNO from wjstar1.customerreg1 where  month(date3)='" + i + "' AND year(date3)='" + year + "')", con);
                        DataSet ds112 = new DataSet();
                        da112.Fill(ds112);
                        con.Close();
                        if (ds112.Tables[0].Rows[0][0].ToString() != "")
                        {
                            recamt = Convert.ToDouble(ds112.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            recamt = 0;
                        }
                        Label57.Text = recamt.ToString();
                        emiamt = total - recamt;
                        Label58.Text = emiamt.ToString();
                    }
			
                    Label777.Text = sum.ToString();
            
        }
    }
}