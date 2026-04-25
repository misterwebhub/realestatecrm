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
    public static Double latemipay,lateemipayment,payment;
    public static string status;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String id = "";
            Label4.Visible = false;
            DropDownList4.Visible = false;
           
                id = Session["ID"].ToString();
               // Button2.Visible = false;
                //id = "Ashok8396";
                //id = "heedrealestate";
                bind(id);
               
           
           
            find();
            
        }
    
    }
    public void bind(String id)
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT username FROM logininfo", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            if (id == "heedrealestate")
            {
               // Button2.Visible = true;
                DropDownList3.Items.Add("ALL USER");
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {

                    DropDownList3.Items.Add(ds1.Tables[0].Rows[j][0].ToString());


                }
            }
            else
            {
               // Button2.Visible = false;
                DropDownList3.Items.Add(id);


            }


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


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT arazino from softploted1", con1);
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

        SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='"+user1+"' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
        DataSet ds = new DataSet();
        cmd.Fill(ds);
       // GridView1.DataSource = ds;
       // GridView1.DataBind();
        con1.Close();
        DataTable paiddt = new DataTable();

        paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
        DataRow dr1 = paiddt.NewRow();
        dr1 = null;
        string reg = "";
        payment = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                reg = "";
                reg = ds.Tables[0].Rows[i][0].ToString();
                dr1 = paiddt.NewRow();
                emical(reg);
               
                dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                dr1["LATE_EMI"] = latemipay;
                dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                payment = payment + lateemipayment;
                dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                statusragistry(reg);
                dr1["STATUS"] = status;
                paiddt.Rows.Add(dr1);
            }
        }
         GridView1.DataSource = paiddt;
         GridView1.DataBind();
         Label29.Text = payment.ToString();
        SqlConnection con2 = new SqlConnection(s);
        con2.Open();

        SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='" + user1 + "' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
        DataSet ds1 = new DataSet();
        cmd1.Fill(ds1);
        Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
        con2.Close();
    }
   public void  statusragistry(string reg)
    {
        status = "";
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();

        SqlDataAdapter cmd = new SqlDataAdapter("select regstatus from customerreg3 where  CUSTREGNO='"+reg+"'", con1);
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

        SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='"+user2+"' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
        DataSet ds = new DataSet();
        cmd.Fill(ds);
       // GridView2.DataSource = ds;
        //GridView2.DataBind();
        con1.Close();
        DataTable paiddt1 = new DataTable();

        paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
        DataRow dr1 = paiddt1.NewRow();
        dr1 = null;
        string reg = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                reg = "";
                reg = ds.Tables[0].Rows[i][0].ToString();
                dr1 = paiddt1.NewRow();
                emical(reg);
                dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                dr1["NAME"] =ds.Tables[0].Rows[i][2].ToString();
                dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                dr1["LATE_EMI"] = latemipay;
                dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                payment = payment + lateemipayment;
                dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                statusragistry(reg);
                dr1["STATUS"] = status;
                paiddt1.Rows.Add(dr1);
            }
        }
        GridView2.DataSource = paiddt1;
        GridView2.DataBind();
        Label24.Text = payment.ToString();

        Label2.Text = "000";
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
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
            if (DropDownList3.Text == "heedrealestate")
            {
                if (DropDownList1.Text == "PAID")
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;

                    if (DropDownList2.Text != "ALL ARAZI")
                    {
                        if (DropDownList2.Text != "152")
                        {
                            SqlConnection con1 = new SqlConnection(s);
                            con1.Open();

                            SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='heedrealestate' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='Cancel'))) order by DATE1 ASC", con1);
                            DataSet ds = new DataSet();
                            cmd.Fill(ds);
                           // GridView1.DataSource = ds;
                           // GridView1.DataBind();
                            con1.Close();
                            DataTable paiddt = new DataTable();

                            paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                            DataRow dr1 = paiddt.NewRow();
                            dr1 = null;
                            string reg = "";
                            payment = 0;
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    reg = "";
                                    reg = ds.Tables[0].Rows[i][0].ToString();
                                    dr1 = paiddt.NewRow();
                                    emical(reg);
                                    dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                    dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                  dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                    dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                    dr1["LATE_EMI"] = latemipay;
                                    dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                    payment = payment + lateemipayment;
                                    dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                    statusragistry(reg);
                                    dr1["STATUS"] = status;
                                    paiddt.Rows.Add(dr1);
                                }
                            }
                            GridView1.DataSource = paiddt;
                            GridView1.DataBind();
                            Label24.Text = payment.ToString();
                            SqlConnection con2 = new SqlConnection(s);
                            con2.Open();

                            SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='heedrealestate' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                            DataSet ds1 = new DataSet();
                            cmd1.Fill(ds1);
                            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                            con2.Close();
                        }
                        else
                        {
                            if (DropDownList4.Text == "E" || DropDownList4.Text == "D" || DropDownList4.Text == "F")
                            {
                                payment = 0;
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='heedrealestate' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                                //GridView1.DataSource = ds;
                                //GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                Label24.Text = payment.ToString();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='heedrealestate' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                            else
                            {
                                payment = 0;
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='heedrealestate' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView1.DataSource = ds;
                               // GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)) ,new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                Label24.Text = payment.ToString();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='heedrealestate' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                        }
                    }
                    else
                    {
                        allpaid("heedrealestate");
                    }

                }
                else
                {

                    if (DropDownList1.Text == "NON PAID")
                    {
                        payment = 0;
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        if (DropDownList2.Text != "ALL ARAZI")
                        {
                            if (DropDownList2.Text != "152")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='heedrealestate' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                                //GridView2.DataSource = ds;
                                //GridView2.DataBind();
                                con1.Close();
                                DataTable paiddt1 = new DataTable();

                                paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt1.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt1.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                        dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                        dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                        dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt1.Rows.Add(dr1);
                                    }
                                }
                                GridView2.DataSource = paiddt1;
                                GridView2.DataBind();

                                Label2.Text = "000";
                            }
                            else
                            {
                                if (DropDownList4.Text == "E" || DropDownList4.Text == "D" || DropDownList4.Text == "F")
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='heedrealestate' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='"+DropDownList4.Text+"') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                   // GridView2.DataSource = ds;
                                   // GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }
                                else
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='heedrealestate' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block in('A','B','C')) AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                   // GridView2.DataSource = ds;
                                    //GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }

                            }

                        }
                        else
                        {
                            allnonpaid("heedrealestate");
                        }
                        Label24.Text = payment.ToString();
                    }
                    else
                    {
                        Label1.Text = "Please select any mode";
                    }

                }
            }
            if (DropDownList3.Text == "Ashok8396")
            {
                payment = 0;
                if (DropDownList1.Text == "PAID")
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    if (DropDownList2.Text != "ALL ARAZI")
                    {
                        if (DropDownList2.Text != "152")
                        {
                            SqlConnection con1 = new SqlConnection(s);
                            con1.Open();

                            SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='Ashok8396' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                            DataSet ds = new DataSet();
                            cmd.Fill(ds);
                            //GridView1.DataSource = ds;
                            //GridView1.DataBind();
                            DataTable paiddt = new DataTable();

                            paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                            DataRow dr1 = paiddt.NewRow();
                            dr1 = null;
                            string reg = "";
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    reg = "";
                                    reg = ds.Tables[0].Rows[i][0].ToString();
                                    dr1 = paiddt.NewRow();
                                    emical(reg);
                                    dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                    dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                  dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                    dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                    dr1["LATE_EMI"] = latemipay;
                                    dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                    payment = payment + lateemipayment;
                                    dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                    statusragistry(reg);
                                    dr1["STATUS"] = status;
                                    paiddt.Rows.Add(dr1);
                                }
                            }
                            GridView1.DataSource = paiddt;
                            GridView1.DataBind();
                            con1.Close();

                            SqlConnection con2 = new SqlConnection(s);
                            con2.Open();

                            SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='Ashok8396' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                            DataSet ds1 = new DataSet();
                            cmd1.Fill(ds1);
                            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                            con2.Close();
                        }
                        else
                        {
                            if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='Ashok8396' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView1.DataSource = ds;
                               // GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='Ashok8396' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                            else
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='Ashok8396' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView1.DataSource = ds;
                               // GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='Ashok8396' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                        }
                    }
                    else
                    {
                        allpaid("Ashok8396");
                    }
                }
                else
                {

                    if (DropDownList1.Text == "NON PAID")
                    {
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        if (DropDownList2.Text != "ALL ARAZI")
                        {
                            if (DropDownList2.Text != "152")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='Ashok8396' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                                //GridView2.DataSource = ds;
                                //GridView2.DataBind();
                                con1.Close();
                                DataTable paiddt1 = new DataTable();

                                paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt1.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt1.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                        dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                        dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                        dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt1.Rows.Add(dr1);
                                    }
                                }
                                GridView2.DataSource = paiddt1;
                                GridView2.DataBind();

                                Label2.Text = "000";
                            }
                            else
                            {
                                if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='Ashok8396' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                   // GridView2.DataSource = ds;
                                   // GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }
                                else
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='Ashok8396' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block in('A','B','C')) AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                    //GridView2.DataSource = ds;
                                    //GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }

                            }
                        }
                        else
                        {
                            allnonpaid("Ashok8396");
                        }

                    }
                    else
                    {
                        Label1.Text = "Please select any mode";
                    }

                }
                Label24.Text = payment.ToString();
            }
            if (DropDownList3.Text == "RAMAIPUROFFICE")
            {
                payment = 0;
                if (DropDownList1.Text == "PAID")
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    if (DropDownList2.Text != "ALL ARAZI")
                    {
                        if (DropDownList2.Text != "152")
                        {
                            SqlConnection con1 = new SqlConnection(s);
                            con1.Open();

                            SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='RAMAIPUROFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                            DataSet ds = new DataSet();
                            cmd.Fill(ds);
                            //GridView1.DataSource = ds;
                           // GridView1.DataBind();
                            con1.Close();
                            DataTable paiddt = new DataTable();

                            paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                            DataRow dr1 = paiddt.NewRow();
                            dr1 = null;
                            string reg = "";
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    reg = "";
                                    reg = ds.Tables[0].Rows[i][0].ToString();
                                    dr1 = paiddt.NewRow();
                                    emical(reg);
                                    dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                    dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                  dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                    dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                    dr1["LATE_EMI"] = latemipay;
                                    dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                    payment = payment + lateemipayment;
                                    dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                    statusragistry(reg);
                                    dr1["STATUS"] = status;
                                    paiddt.Rows.Add(dr1);
                                }
                            }
                            GridView1.DataSource = paiddt;
                            GridView1.DataBind();
                            SqlConnection con2 = new SqlConnection(s);
                            con2.Open();

                            SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='RAMAIPUROFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                            DataSet ds1 = new DataSet();
                            cmd1.Fill(ds1);
                            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                            con2.Close();
                        }
                        else
                        {
                            if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='RAMAIPUROFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView1.DataSource = ds;
                                //GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='RAMAIPUROFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                            else
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='RAMAIPUROFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                                //GridView1.DataSource = ds;
                                //GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='RAMAIPUROFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                        }
                    }
                    else
                    {
                        allpaid("RAMAIPUROFFICE");
                    }
                }
                else
                {

                    if (DropDownList1.Text == "NON PAID")
                    {
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        if (DropDownList2.Text != "ALL ARAZI")
                        {
                            if (DropDownList2.Text != "152")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='RAMAIPUROFFICE' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                                //GridView2.DataSource = ds;
                                //GridView2.DataBind();
                                con1.Close();
                                DataTable paiddt1 = new DataTable();

                                paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt1.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt1.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                        dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                        dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                        dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt1.Rows.Add(dr1);
                                    }
                                }
                                GridView2.DataSource = paiddt1;
                                GridView2.DataBind();

                                Label2.Text = "000";
                            }
                            else
                            {
                                if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='RAMAIPUROFFICE' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                    //GridView2.DataSource = ds;
                                    //GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }
                                else
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='RAMAIPUROFFICE' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block in('A','B','C')) AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                    //GridView2.DataSource = ds;
                                    //GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }

                            }
                        }
                        else
                        {
                            allnonpaid("RAMAIPUROFFICE");
                        }

                    }
                    else
                    {
                        Label1.Text = "Please select any mode";
                    }

                }
                Label24.Text = payment.ToString();
            }
            if (DropDownList3.Text == "MACHHARIYAOFFICE")
            {payment=0;
                
                if (DropDownList1.Text == "PAID")
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    if (DropDownList2.Text != "ALL ARAZI")
                    {
                        if (DropDownList2.Text != "152")
                        {
                            SqlConnection con1 = new SqlConnection(s);
                            con1.Open();

                            SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='MACHHARIYAOFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                            DataSet ds = new DataSet();
                            cmd.Fill(ds);
                            //GridView1.DataSource = ds;
                           // GridView1.DataBind();
                            con1.Close();
                            DataTable paiddt = new DataTable();

                            paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                            DataRow dr1 = paiddt.NewRow();
                            dr1 = null;
                            string reg = "";
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    reg = "";
                                    reg = ds.Tables[0].Rows[i][0].ToString();
                                    dr1 = paiddt.NewRow();
                                    emical(reg);
                                    dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                    dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                  dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                    dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                    dr1["LATE_EMI"] = latemipay;
                                    dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                    payment = payment + lateemipayment;
                                    dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                    statusragistry(reg);
                                    dr1["STATUS"] = status;
                                    paiddt.Rows.Add(dr1);
                                }
                            }
                            GridView1.DataSource = paiddt;
                            GridView1.DataBind();
                            SqlConnection con2 = new SqlConnection(s);
                            con2.Open();

                            SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='MACHHARIYAOFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                            DataSet ds1 = new DataSet();
                            cmd1.Fill(ds1);
                            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                            con2.Close();
                        }
                        else
                        {
                            if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='MACHHARIYAOFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView1.DataSource = ds;
                               // GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='MACHHARIYAOFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                            else
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='MACHHARIYAOFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                                //GridView1.DataSource = ds;
                                //GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='MACHHARIYAOFFICE' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                        }
                    }
                    else
                    {
                        allpaid("MACHHARIYAOFFICE");
                    }
                }
                
                else
                {

                    if (DropDownList1.Text == "NON PAID")
                    {
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        if (DropDownList2.Text != "ALL ARAZI")
                        {
                            if (DropDownList2.Text != "152")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='MACHHARIYAOFFICE' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView2.DataSource = ds;
                               // GridView2.DataBind();
                                con1.Close();

                                DataTable paiddt1 = new DataTable();

                                paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt1.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt1.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                        dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                        dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                        dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt1.Rows.Add(dr1);
                                    }
                                }
                                GridView2.DataSource = paiddt1;
                                GridView2.DataBind();
                                Label2.Text = "000";
                            }
                            else
                            {
                                if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='MACHHARIYAOFFICE' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                   // GridView2.DataSource = ds;
                                   // GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }
                                else
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='MACHHARIYAOFFICE' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block in('A','B','C')) AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                   // GridView2.DataSource = ds;
                                    //GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }

                            }
                        }
                        else
                        {
                            allnonpaid("MACHHARIYAOFFICE");
                        }

                    }
                    else
                    {
                        Label1.Text = "Please select any mode";
                    }

                }
                
                Label24.Text=payment.ToString();
            }
            if (DropDownList3.Text == "IMRAN7905")
            {
                payment = 0;
                if (DropDownList1.Text == "PAID")
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    if (DropDownList2.Text != "ALL ARAZI")
                    {
                        if (DropDownList2.Text != "152")
                        {
                            SqlConnection con1 = new SqlConnection(s);
                            con1.Open();

                            SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='IMRAN7905' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='Cancel'))) order by DATE1 ASC", con1);
                            DataSet ds = new DataSet();
                            cmd.Fill(ds);
                           // GridView1.DataSource = ds;
                           // GridView1.DataBind();
                            con1.Close();
                            DataTable paiddt = new DataTable();

                            paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                            DataRow dr1 = paiddt.NewRow();
                            dr1 = null;
                            string reg = "";
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    reg = "";
                                    reg = ds.Tables[0].Rows[i][0].ToString();
                                    dr1 = paiddt.NewRow();
                                    emical(reg);
                                    dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                    dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                  dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                    dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                    dr1["LATE_EMI"] = latemipay;
                                    dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                    payment = payment + lateemipayment;
                                    dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                    statusragistry(reg);
                                    dr1["STATUS"] = status;
                                    paiddt.Rows.Add(dr1);
                                }
                            }
                            GridView1.DataSource = paiddt;
                            GridView1.DataBind();
                            SqlConnection con2 = new SqlConnection(s);
                            con2.Open();

                            SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='IMRAN7905' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                            DataSet ds1 = new DataSet();
                            cmd1.Fill(ds1);
                            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                            con2.Close();
                        }
                        else
                        {
                            if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='IMRAN7905' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView1.DataSource = ds;
                               // GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='IMRAN7905' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                            else
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype='IMRAN7905' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                                //GridView1.DataSource = ds;
                                //GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype='IMRAN7905' AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                        }
                    }
                    else
                    {
                        allpaid("IMRAN7905");
                    }
                }
                else
                {

                    if (DropDownList1.Text == "NON PAID")
                    {
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        if (DropDownList2.Text != "ALL ARAZI")
                        {
                            if (DropDownList2.Text != "152")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='IMRAN7905' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                                //GridView2.DataSource = ds;
                                //GridView2.DataBind();
                                con1.Close();
                                DataTable paiddt1 = new DataTable();

                                paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt1.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt1.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                        dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                        dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                        dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt1.Rows.Add(dr1);
                                    }
                                }
                                GridView2.DataSource = paiddt1;
                                GridView2.DataBind();

                                Label2.Text = "000";
                            }
                            else
                            {
                                if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='IMRAN7905' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                    //GridView2.DataSource = ds;
                                    //GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }
                                else
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype='IMRAN7905' AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block in('A','B','C')) AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                    //GridView2.DataSource = ds;
                                   // GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }

                            }
                        }
                        else
                        {
                            allnonpaid("IMRAN7905");
                        }

                    }
                    else
                    {
                        Label1.Text = "Please select any mode";
                    }

                }
                Label24.Text = payment.ToString();
            }
            if (DropDownList3.Text == "ALL USER")
            {
                payment = 0;
                if (DropDownList1.Text == "PAID")
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    if (DropDownList2.Text != "ALL ARAZI")
                    {
                        if (DropDownList2.Text != "152")
                        {
                            SqlConnection con1 = new SqlConnection(s);
                            con1.Open();

                            SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                            DataSet ds = new DataSet();
                            cmd.Fill(ds);
                           // GridView1.DataSource = ds;
                           // GridView1.DataBind();
                            con1.Close();
                            DataTable paiddt = new DataTable();

                            paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                            DataRow dr1 = paiddt.NewRow();
                            dr1 = null;
                            string reg = "";
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    reg = "";
                                    reg = ds.Tables[0].Rows[i][0].ToString();
                                    dr1 = paiddt.NewRow();
                                    emical(reg);
                                    dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                    dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                  dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                    dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                    dr1["LATE_EMI"] = latemipay;
                                    dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                    payment = payment + lateemipayment;
                                    dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                    statusragistry(reg);
                                    dr1["STATUS"] = status;
                                    paiddt.Rows.Add(dr1);
                                }
                            }
                            GridView1.DataSource = paiddt;
                            GridView1.DataBind();
                            SqlConnection con2 = new SqlConnection(s);
                            con2.Open();

                            SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                            DataSet ds1 = new DataSet();
                            cmd1.Fill(ds1);
                            Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                            con2.Close();
                        }
                        else
                        {
                            if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView1.DataSource = ds;
                               // GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                            else
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView1.DataSource = ds;
                               // GridView1.DataBind();
                                con1.Close();
                                DataTable paiddt = new DataTable();

                                paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                                      dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                        dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt.Rows.Add(dr1);
                                    }
                                }
                                GridView1.DataSource = paiddt;
                                GridView1.DataBind();
                                SqlConnection con2 = new SqlConnection(s);
                                con2.Open();

                                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block IN ('A','B','C') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                                DataSet ds1 = new DataSet();
                                cmd1.Fill(ds1);
                                Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                                con2.Close();
                            }
                        }
                    }
                    else
                    {

                        SqlConnection con1 = new SqlConnection(s);
                        con1.Open();

                        SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO,LEFT(ASCADDRESS,20) AS 'ASCADDRESS',AMOUNTR,DATE1,checkby from recipt3 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel'))) order by DATE1 ASC", con1);
                        DataSet ds = new DataSet();
                        cmd.Fill(ds);
                       // GridView1.DataSource = ds;
                       // GridView1.DataBind();
                        con1.Close();
                        DataTable paiddt = new DataTable();

                        paiddt.Columns.AddRange(new DataColumn[8] { new DataColumn("REGNO", typeof(string)),new DataColumn("ADDRESS", typeof(string)),
                            new DataColumn("DATE", typeof(string)),
                            new DataColumn("AMOUNT",typeof(string)),new DataColumn("LATE_EMI", typeof(int)),new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                        DataRow dr1 = paiddt.NewRow();
                        dr1 = null;
                        string reg = "";
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                reg = "";
                                reg = ds.Tables[0].Rows[i][0].ToString();
                                dr1 = paiddt.NewRow();
                                emical(reg);
                                dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                dr1["ADDRESS"] = ds.Tables[0].Rows[i][1].ToString();
                              dr1["DATE"] = Convert.ToDateTime( ds.Tables[0].Rows[i][3].ToString()).ToString("dd/MM/yyyy"); 
                                dr1["AMOUNT"] = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                                dr1["LATE_EMI"] = latemipay;
                                dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                payment = payment + lateemipayment;
                                dr1["BROKER"] = ds.Tables[0].Rows[i][4].ToString();
                                statusragistry(reg);
                                dr1["STATUS"] = status;
                                paiddt.Rows.Add(dr1);
                            }
                        }
                        GridView1.DataSource = paiddt;
                        GridView1.DataBind();
                        SqlConnection con2 = new SqlConnection(s);
                        con2.Open();

                        SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(AMOUNTR) from recipt3 where status='PAID' AND usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND (DATE1 BETWEEN '" + date1 + "' AND '" + date2 + "') AND (CUSTREGNO IN (select DISTINCT CUSTREGNO from customerreg3 where  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where  regstatus='Cancel')))", con2);
                        DataSet ds1 = new DataSet();
                        cmd1.Fill(ds1);
                        Label2.Text = ds1.Tables[0].Rows[0][0].ToString();
                        con2.Close();
                    }
                }
                else
                {

                    if (DropDownList1.Text == "NON PAID")
                    {
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        if (DropDownList2.Text != "ALL ARAZI")
                        {
                            if (DropDownList2.Text != "152")
                            {
                                SqlConnection con1 = new SqlConnection(s);
                                con1.Open();

                                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  APPNO='" + DropDownList2.Text + "' AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                DataSet ds = new DataSet();
                                cmd.Fill(ds);
                               // GridView2.DataSource = ds;
                               // GridView2.DataBind();
                                con1.Close();
                                DataTable paiddt1 = new DataTable();

                                paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                DataRow dr1 = paiddt1.NewRow();
                                dr1 = null;
                                string reg = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        reg = "";
                                        reg = ds.Tables[0].Rows[i][0].ToString();
                                        dr1 = paiddt1.NewRow();
                                        emical(reg);
                                        dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                        dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                        dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                        dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                        dr1["LATE_EMI"] = latemipay;
                                        dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                        payment = payment + lateemipayment;
                                        dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                        dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                        dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                        statusragistry(reg);
                                        dr1["STATUS"] = status;
                                        paiddt1.Rows.Add(dr1);
                                    }
                                }
                                GridView2.DataSource = paiddt1;
                                GridView2.DataBind();

                                Label2.Text = "000";
                            }
                            else
                            {
                                if (DropDownList4.Text == "E" || DropDownList4.Text == "D")
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block='" + DropDownList4.Text + "') AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                   // GridView2.DataSource = ds;
                                   // GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }
                                else
                                {
                                    SqlConnection con1 = new SqlConnection(s);
                                    con1.Open();

                                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO IN (select DISTINCT CUSTREGNO from arazi30beegha where block in('A','B','C')) AND CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                                    DataSet ds = new DataSet();
                                    cmd.Fill(ds);
                                    //GridView2.DataSource = ds;
                                    //GridView2.DataBind();
                                    con1.Close();
                                    DataTable paiddt1 = new DataTable();

                                    paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                                    DataRow dr1 = paiddt1.NewRow();
                                    dr1 = null;
                                    string reg = "";
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            reg = "";
                                            reg = ds.Tables[0].Rows[i][0].ToString();
                                            dr1 = paiddt1.NewRow();
                                            emical(reg);
                                            dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                            dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                            dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                            dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                            dr1["LATE_EMI"] = latemipay;
                                            dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                            payment = payment + lateemipayment;
                                            dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                            dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                            dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                            statusragistry(reg);
                                            dr1["STATUS"] = status;
                                            paiddt1.Rows.Add(dr1);
                                        }
                                    }
                                    GridView2.DataSource = paiddt1;
                                    GridView2.DataBind();

                                    Label2.Text = "000";
                                }

                            }
                        }
                        else
                        {
                            SqlConnection con1 = new SqlConnection(s);
                            con1.Open();

                            SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT CUSTREGNO, APPNO AS 'ARAZI NO',LEFT(NAMEDOBADDRESS,20) AS 'NAME',SUBDUEDATE AS 'DUE DATE',plotno AS 'PLOT NO',CONCAT(mobile,' , ',mobile2) AS 'MOBILE',CHECKBY from customerreg3 where CUSTREGNO in(select DISTINCT CUSTREGNO from recipt3 where  usertype IN ('heedrealestate','RAMAIPUROFFICE','MACHHARIYAOFFICE','Ashok8396','IMRAN7905') AND  CUSTREGNO not in(select DISTINCT CUSTREGNO from recipt3 where status='PAID' and DATE1 between '" + date1 + "' AND '" + date2 + "'))  AND  CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from customerreg3 where regstatus='completed'  OR regstatus='Cancel')", con1);
                            DataSet ds = new DataSet();
                            cmd.Fill(ds);
                           // GridView2.DataSource = ds;
                           // GridView2.DataBind();
                            con1.Close();
                            DataTable paiddt1 = new DataTable();

                            paiddt1.Columns.AddRange(new DataColumn[10] { new DataColumn("REGNO", typeof(string)),
            new DataColumn("ARAZI", typeof(string)),
                            new DataColumn("NAME", typeof(string)),
                            new DataColumn("DUE_DATE",typeof(string)),
                            new DataColumn("LATE_EMI", typeof(int)),
                            new DataColumn("LATE_EMI_PAYMENT", typeof(int)) ,
                             new DataColumn("PLOTNO",typeof(string)),
                              new DataColumn("MOBILE",typeof(string)),
                              new DataColumn("BROKER",typeof(string)),new DataColumn("STATUS",typeof(string))});
                            DataRow dr1 = paiddt1.NewRow();
                            dr1 = null;
                            string reg = "";
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    reg = "";
                                    reg = ds.Tables[0].Rows[i][0].ToString();
                                    dr1 = paiddt1.NewRow();
                                    emical(reg);
                                    dr1["REGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                    dr1["ARAZI"] = ds.Tables[0].Rows[i][1].ToString();
                                    dr1["NAME"] = ds.Tables[0].Rows[i][2].ToString();
                                    dr1["DUE_DATE"] = ds.Tables[0].Rows[i][3].ToString();
                                    dr1["LATE_EMI"] = latemipay;
                                    dr1["LATE_EMI_PAYMENT"] = lateemipayment;
                                    payment = payment + lateemipayment;
                                    dr1["PLOTNO"] = ds.Tables[0].Rows[i][4].ToString();
                                    dr1["MOBILE"] = ds.Tables[0].Rows[i][5].ToString();
                                    dr1["BROKER"] = ds.Tables[0].Rows[i][6].ToString();
                                    statusragistry(reg);
                                    dr1["STATUS"] = status;
                                    paiddt1.Rows.Add(dr1);
                                }
                            }
                            GridView2.DataSource = paiddt1;
                            GridView2.DataBind();

                            Label2.Text = "000";
                        }

                    }
                    else
                    {
                        Label1.Text = "Please select any mode";
                    }

                }
            }
            Label29.Text = payment.ToString();

        }
        catch (Exception t)
        {
            Label1.Text = "internal problem"+t;
        }

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.Text != "152")
        {
            DropDownList4.Visible = false;
            Label4.Visible = false;
        }
        else
        {
            DropDownList4.Visible =true;
            Label4.Visible = true;
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

            SqlDataAdapter da = new SqlDataAdapter("select LEFT(NAMEDOBADDRESS,20),CONSAMOUNT,plotno,PLOTSIZE,date3,APPNO,lastdate,regstatus FROM customerreg3 where CUSTREGNO='" + reg + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();

            SqlDataAdapter da2 = new SqlDataAdapter("select TOP 1 DATE1,AMOUNTR from recipt3 where CUSTREGNO='" + reg + "' order by DATE1 DESC", con1);
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
            SqlCommand cmd1 = new SqlCommand("select sum(AMOUNTR) from recipt3 where CUSTREGNO='" + reg + "'", con1);

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
                            arazisearch(Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()), Label2.Text, total,reg);
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
                            latemipay = 0;
                            lateemipayment = 0;
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
                    Label19.Text = "0";
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
        SqlDataAdapter da = new SqlDataAdapter("select DATEDIFF(MONTH,date3,lastdate),date3 from  customerreg3 where CUSTREGNO='" + reg + "'", con);
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

        SqlDataAdapter da1 = new SqlDataAdapter("select floor(DATEDIFF(DAY,(select date3 from  customerreg3 where CUSTREGNO='" + reg+ "'),getdate())/30.46) ", con);
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


        if (arazi == "37 JAJMAU" )
        {
            dp = custotalpayment * 0.50;
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
                Label19.Text = advancamount.ToString();
                Label12.Text = lateemi.ToString();
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
                Label17.Text = dp.ToString();
                Label18.Text = "0";
                Label21.Text = Convert.ToInt32(bal).ToString();
                Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                Label22.Text = balemi.ToString();
                Label19.Text = advancamount.ToString();
                Label12.Text = lateemi.ToString();
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
                Label9.Text = (custotalpayment - dp).ToString();
                Label10.Text = instpaid.ToString("N0");
                Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

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
                    Label19.Text = advancamount.ToString();
                    Label12.Text = lateemi.ToString();
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
                    Label17.Text = dp.ToString();
                    Label18.Text = "0";
                    Label21.Text = Convert.ToInt32(bal).ToString();
                    Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                    Label22.Text = balemi.ToString();
                    Label19.Text = advancamount.ToString();
                    Label12.Text = lateemi.ToString();
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
                        Label19.Text = advancamount.ToString();
                        Label12.Text = lateemi.ToString();
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
                        Label17.Text = dp.ToString();
                        Label18.Text = "0";
                        Label21.Text = Convert.ToInt32(bal).ToString();
                        Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                        Label22.Text = balemi.ToString();
                        Label19.Text = advancamount.ToString();
                        Label12.Text = lateemi.ToString();
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
                        Label9.Text = (custotalpayment - dp).ToString();
                        Label10.Text = instpaid.ToString("N0");
                        Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

                    }
                }
            }
        }
    }













}