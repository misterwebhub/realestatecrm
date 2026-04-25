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
using System.Globalization;
public partial class kishan_Bin_datewisepayment : System.Web.UI.Page
{
    public int ctotal = 0, btotal = 0, cpending = 0, bpending = 0;
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cpending = 0;
            bpending = 0;
            String id = "";
            // Label4.Visible = false;
            // DropDownList4.Visible = false;
            Session["ID"] = "xdc";
            if (Session["ID"] != null)
            {
              id = "heedrealestate";
                // id = Session["idr"].ToString();
                //Label13.Text = 
                Session["idr"] = id;
            }
            else
            {
                Response.Redirect("~/telelogin/dist/telelogin.aspx");
            }

            id = Session["idr"].ToString();
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


            // Button2.Visible = false;
            TextBox4.Text = id;





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


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT APPNO FROM wjstar1.customerreg1", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                // DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                DropDownList2.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
                DropDownList3.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label1.Text = "internal problem";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
			int paid=0;
            string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string start = mm + "/" + dd + "/" + yy;
            string end;
            if (Convert.ToInt32(mm) != 2)
            {
                end = mm + "/" + dd + "/" + yy;
            }
            else
            {
                end = mm + "/" + dd + "/" + yy;
            }


            if (DropDownList1.Text == "NON PAID")
            {
                // GridView1.Visible = false;
                GridView2.Visible = true;
                SqlConnection con1 = new SqlConnection(s);
                con1.Open();
				SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate AS 'feeddate',r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1   from wjstar1.customerreg1 c left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback where date='" + start + "' AND userid='" + TextBox4.Text + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + start + "' AND userid='" + TextBox4.Text + "' group By CUSTREGNO) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND  c.APPNO='" + DropDownList2.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')  order by r.entrytime1 ASC", con1);
                //SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1   from wjstar1.customerreg1 c  join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + start + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))  AND  c.APPNO='" + DropDownList2.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                //  SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND  c.APPNO='" + DropDownList2.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con1.Close();
                con1.Open();
               SqlDataAdapter cmd2 = new SqlDataAdapter("select count(c.CUSTREGNO) from wjstar1.customerreg1 c left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback where date='" + start + "' AND userid='" + TextBox4.Text + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + start + "' AND userid='" + TextBox4.Text + "' group By CUSTREGNO) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND  c.APPNO='" + DropDownList2.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);

                DataSet ds2 = new DataSet();
                cmd2.Fill(ds2);
                con1.Close();
				  con1.Open();
				SqlDataAdapter cmd5 = new SqlDataAdapter("Select count(DISTINCT CUSTREGNO) from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "' AND usertype='" + TextBox4.Text + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from wjstar1.customerreg1 where DAY(date3)='" + dd + "' AND c.APPNO='" + DropDownList2.Text + "')", con1);
				
              DataSet ds5 = new DataSet();
                cmd5.Fill(ds5);
				con1.Close();
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds2.Tables[0].Rows[0][0].ToString() != "")
                    {
                        // Label3.Text = "";
                        ctotal = 0;
                        ctotal = Convert.ToInt32(ds2.Tables[0].Rows[0][0].ToString());

                        
                    }
                    else
                    {
                        // Label3.Text = "No Record Found";
                        ctotal=0;

                    }
					if (ds5.Tables[0].Rows[0][0].ToString() != "")
                    {
                        // Label3.Text = "";
                       
                        paid = Convert.ToInt32(ds5.Tables[0].Rows[0][0].ToString());

                       // Label5.Text = ctotal.ToString();
                    }
                    else
                    {
                        // Label3.Text = "No Record Found";
                       paid=0;

                    }
                }
                Label6.Text = cpending.ToString();
Label5.Text = (ctotal+paid).ToString();
				 Label9.Text = paid.ToString();
                int cbal = ctotal - cpending;
                Label7.Text = cbal.ToString();
				string start1 = dd + "/" + mm + "/" + yy;
                backdetails1(start);



            }
            else
            {
                if (DropDownList1.Text == "ALL ARAZI NON PAID")
                {
                    // GridView1.Visible = false;
                    GridView2.Visible = true;
                    SqlConnection con1 = new SqlConnection(s);
                    con1.Open();


                    /* SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime+'-'+count(r1.ID)  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO join callerfeedback r1  on r1.CUSTREGNO=c.CUSTREGNO  group by r1.CUSTREGNO  where DAY(c.date3)='" + dd + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);*/

                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate AS 'feeddate',r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1   from wjstar1.customerreg1 c left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback where date='" + start + "' AND userid='" + TextBox4.Text + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + start + "' AND userid='" + TextBox4.Text + "' group By CUSTREGNO) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') order by r.entrytime1 ASC", con1);
                    DataSet ds = new DataSet();
                    cmd.Fill(ds);
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    con1.Close();
                   SqlDataAdapter cmd2 = new SqlDataAdapter("select count(c.CUSTREGNO)   from wjstar1.customerreg1 c left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback where date='" + start + "' AND userid='" + TextBox4.Text + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + start + "' AND userid='" + TextBox4.Text + "' group By CUSTREGNO) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                    DataSet ds2 = new DataSet();
                    cmd2.Fill(ds2);

                    con1.Close();
					con1.Open();
				SqlDataAdapter cmd5 = new SqlDataAdapter("Select count(DISTINCT CUSTREGNO) from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "' AND usertype='" + TextBox4.Text + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from wjstar1.customerreg1 where DAY(date3)='" + dd + "')", con1);
				
              DataSet ds5 = new DataSet();
                cmd5.Fill(ds5);
				con1.Close();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        if (ds2.Tables[0].Rows[0][0].ToString() != "")
                        {
                            ctotal = 0;
                            ctotal = Convert.ToInt32(ds2.Tables[0].Rows[0][0].ToString());
if (ds5.Tables[0].Rows[0][0].ToString() != "")
                    {
                        // Label3.Text = "";
                       
                        paid = Convert.ToInt32(ds5.Tables[0].Rows[0][0].ToString());

                       // Label5.Text = ctotal.ToString();
                    }
                    else
                    {
                        // Label3.Text = "No Record Found";
                       paid=0;

                    }
                            

                        }
                        else
                        {
                            // Label3.Text = "No Record Found";
                           ctotal=0;

                        }
                    }
                    Label6.Text = cpending.ToString();
Label5.Text =( ctotal+paid).ToString();
                    int cbal = ctotal - cpending;
					 Label9.Text = paid.ToString();
                    Label7.Text = cbal.ToString();
                  string start1 = dd + "/" + mm + "/" + yy;
                backdetails1(start);
                



                }
                else
                {
                    Label1.Text = "Please select any mode";
                }
            }

        }
        // DataTable dt = new DataTable();



        catch (Exception t)
        {
            Label1.Text = "internal problem" + t;
        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gr = GridView2.SelectedRow;
        String id = gr.Cells[1].Text;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO AS 'REGNO',LEFT(r.ASSADDRESS,20) AS 'ADDRESS',r.PLANTERM AS 'PLAN',r.EXPLANDVALUE AS 'VALUE',r.RECIPT,r.DATE,r.INSTNO,r.AMOUNTR,u.APPNO from wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + id + "'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        GridView3.DataSource = ds;
        GridView3.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string s2 = TextBox2.Text;
            string s4 = TextBox3.Text;
            string dd = s2.Substring(0, 2);
            string dd1 = s4.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string mm1 = s4.Substring(3, 2);
            string yy1 = s4.Substring(6, 4);
            string start = mm + "/" + dd + "/" + yy;
            string end;
            if (Convert.ToInt32(mm) != 2)
            {
                end = mm1 + "/" + dd1 + "/" + yy1;
            }
            else
            {
                end = mm1 + "/" + dd1 + "/" + yy1;
            }


            if (DropDownList4.Text == "NON PAID")
            {
                // GridView1.Visible = false;
                GridView2.Visible = true;
                SqlConnection con1 = new SqlConnection(s);
                con1.Open();

                //   SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) BETWEEN '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND  c.APPNO='" + DropDownList3.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);


                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1   from wjstar1.customerreg1 c left join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date between '" + start + "' AND '" + end + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) between '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))  AND  c.APPNO='" + DropDownList2.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con1.Close();

                backdetails(start, end);


            }
            else
            {
                if (DropDownList4.Text == "ALL ARAZI NON PAID")
                {
                    // GridView1.Visible = false;
                    GridView2.Visible = true;
                    SqlConnection con1 = new SqlConnection(s);
                    con1.Open();


                    //  SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) BETWEEN '" + dd + "' AND '" + dd1 + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);


                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c left join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date between '" + start + "' AND '" + end + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) between '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))  AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                    DataSet ds = new DataSet();
                    cmd.Fill(ds);
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    con1.Close();
                    backdetails(start, end);



                }
                else
                {
                    Label1.Text = "Please select any mode";
                }
            }

        }
        // DataTable dt = new DataTable();



        catch (Exception t)
        {
            Label1.Text = "internal problem" + t;
        }
    }


    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string s2 = TextBox1.Text;
        // string s4 = TextBox3.Text;
        string dd = s2.Substring(0, 2);
        // string dd1 = s4.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        // string mm1 = s4.Substring(3, 2);
        // string yy1 = s4.Substring(6, 4);
        string start = dd + "/" + mm + "/" + yy;
        string end;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string dateString1 = e.Row.Cells[9].Text;
            string dateString2 = e.Row.Cells[11].Text;

            CultureInfo provider = CultureInfo.InvariantCulture;
            // It throws Argument null exception  

            string h = e.Row.Cells[9].Text;
            string h2 = e.Row.Cells[11].Text;
            if (h != "&nbsp;" && h2 != "&nbsp;")
            {
                // DateTime d1 = Convert.ToDateTime(e.Row.Cells[9].Text);
                DateTime d1 = DateTime.ParseExact(dateString1, "mm/dd/yyyy", provider);

                DateTime d2 = DateTime.ParseExact(dateString2, "mm/dd/yyyy", provider);
                /* if (birthDate.ToShortDateString() == "1/1/1900")
                 {
                     e.Row.Cells[1].Text = "null";
                 }*/
                int res = DateTime.Compare(d1, d2);
                // returns <0 since d1 is earlier than d2
                if (res == 0)
                {
                  
                }
            }

            if (h != "&nbsp;")
            {
                // DateTime d1 = Convert.ToDateTime(e.Row.Cells[9].Text);
                DateTime d1 = DateTime.ParseExact(dateString1, "mm/dd/yyyy", provider);

                DateTime d2 = DateTime.ParseExact(start, "mm/dd/yyyy", provider);
                /* if (birthDate.ToShortDateString() == "1/1/1900")
                 {
                     e.Row.Cells[1].Text = "null";
                 }*/
                int res = DateTime.Compare(d1, d2);
                // returns <0 since d1 is earlier than d2
                // Label1.Text = d2.ToString();

                if (res != 0)
                {
                    e.Row.Cells[12].Text = "";
                    e.Row.Cells[9].Text = "";
                }

                if (res == 0)
                {
                    cpending = cpending + 1;
                }
            }
			else
				
			{
				e.Row.Cells[10].Text = "";
				e.Row.Cells[11].Text = "";
			}


        }

    }
    public void backdetails(string date1, string date2)
    {
        //   Label3.Text = "";

        GridView4.Visible = true;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        int c = 0;
        DateTime es = DateTime.Now;
        int mon = es.Month;
        int year = es.Year;
        DateTime lastDate = new DateTime(es.Year, es.Month, 1).AddMonths(1).AddDays(-1);

        SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date BETWEEN '" + date1 + "' AND '" + date2 + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where r.feeddate BETWEEN '" + date1 + "' AND '" + date2 + "' AND r.CUSTREGNO in(select DISTINCT CUSTREGNO from calldemo where  userid='" + TextBox4.Text + "' ) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.recipt1 where MONTH(DATE1)=" + mon + " AND YEAR(DATE1)=" + year + " )", con1);

        // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime+' - '+CONVERT(varchar(10), r1.pmt1) AS entrytime  from wjstar1.customerreg1 c left join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='"+start+"' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='"+dd+"' AND year(DATE1)='"+yy+"'))AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);

        DataSet ds = new DataSet();
        cmd.Fill(ds);


        con1.Close();
        con1.Open();

        SqlDataAdapter cmd1 = new SqlDataAdapter("select count(c.CUSTREGNO) from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date BETWEEN '" + date1 + "' AND '" + date2 + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where r.feeddate BETWEEN '" + date1 + "' AND '" + date2 + "' AND r.CUSTREGNO in(select DISTINCT CUSTREGNO from calldemo where  userid='" + TextBox4.Text + "' ) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.recipt1 where MONTH(DATE1)=" + mon + " AND YEAR(DATE1)=" + year + " )", con1);
        /* SqlDataAdapter cmd1 = new SqlDataAdapter("select count( r.CUSTREGNO)  from  calldemo r  where r.date BETWEEN '" + date1 + "' AND '" + date2 + "' AND r.userid='" + TextBox4.Text + "'  AND r.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);*/
        DataSet ds1 = new DataSet();
        cmd1.Fill(ds1);


        con1.Close();
        if (ds.Tables[0].Rows.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "" && ds1.Tables[0].Rows[0][0].ToString() != "")
            {
                // Label3.Text = "";

                btotal = Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString());
                Label2.Text = btotal.ToString();
                GridView4.DataSource = ds;
                GridView4.DataBind();
            }
            else
            {
                // Label3.Text = "No Record Found";
                Label2.Text = "";
                btotal = 0;
                GridView4.DataSource = null;
                GridView4.DataBind();
            }
        }
        else
        {
            // Label3.Text = "No Record Found";
            Label2.Text = "";
            btotal = 0;
            GridView4.DataSource = null;
            GridView4.DataBind();
        }
        Label3.Text = bpending.ToString();

        int bbal = btotal - bpending;
        Label4.Text = bbal.ToString();
    }
    public void backdetails1(string date111)
    {
        //   Label3.Text = "";
		int paid=0;
		 string s2 = TextBox1.Text;
            string dd = s2.Substring(0, 2);
		int dd1=Convert.ToInt32(dd);
            string mm = s2.Substring(3, 2);
		int mm1=Convert.ToInt32(mm);
            string yy = s2.Substring(6, 4);
		int yy1=Convert.ToInt32(yy);
            string date11 = mm + "/" + dd + "/" + yy;
	 
        string date2 = date11;
        GridView4.Visible = true;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        int c = 0;
        DateTime es = DateTime.Today;
        int mon = es.Month;
		
        int year = es.Year;
		
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime lastDate = new DateTime(es.Year, es.Month, 1).AddMonths(1).AddDays(-1);
		DateTime d23 =new  DateTime(yy1,mm1,dd1);  
       // DateTime d2 = DateTime.ParseExact(es, "mm/dd/yyyy", provider);
        /* if (birthDate.ToShortDateString() == "1/1/1900")
         {
             e.Row.Cells[1].Text = "null";
         }*/
        int res = DateTime.Compare(d23,es);
        // returns <0 since d1 is earlier than d2
         Label1.Text =res.ToString();

        if (res == 0)
        {
            SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY ,r.date,r.reason,r.feeddate AS 'feeddate',r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c  join backcall r3  on r3.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback where date<='" + date11 + "' AND userid='" + TextBox4.Text + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + date11 + "' AND userid='" + TextBox4.Text + "' group By CUSTREGNO) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where r3.date='"+date11+"' AND r3.userid='" + TextBox4.Text + "' AND c.CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mon + "' AND year(DATE1)='" + year + "') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);

            // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime+' - '+CONVERT(varchar(10), r1.pmt1) AS entrytime  from wjstar1.customerreg1 c left join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='"+start+"' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='"+dd+"' AND year(DATE1)='"+yy+"'))AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);

            DataSet ds = new DataSet();
            cmd.Fill(ds);


            con1.Close();
            con1.Open();

            SqlDataAdapter cmd1 = new SqlDataAdapter("select count( DISTINCT CUSTREGNO) from backcall where date='"+date11+"' AND userid='"+TextBox4.Text+"'", con1);
            /* SqlDataAdapter cmd1 = new SqlDataAdapter("select count( r.CUSTREGNO)  from  calldemo r  where r.date BETWEEN '" + date1 + "' AND '" + date2 + "' AND r.userid='" + TextBox4.Text + "'  AND r.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);*/
            DataSet ds1 = new DataSet();
            cmd1.Fill(ds1);


            con1.Close();
			SqlDataAdapter cmd3 = new SqlDataAdapter("Select count(DISTINCT CUSTREGNO) from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "' AND usertype='" + TextBox4.Text + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from backcall where date='" + date11 + "')", con1);
			   con1.Open();
			DataSet ds3 = new DataSet();
            cmd3.Fill(ds3);


            con1.Close();
            if (ds.Tables[0].Rows.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "" && ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    // Label3.Text = "";

                    btotal = Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString());
                    Label2.Text = btotal.ToString();
					if(ds3.Tables[0].Rows[0][0].ToString() != "")
					{
						paid = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());
					}
					else
						
					{
						paid=0;
					}
                    GridView4.DataSource = ds;
                    GridView4.DataBind();
                }
                else
                {
                    // Label3.Text = "No Record Found";
                    Label2.Text = "";
                    btotal = 0;
					paid=0;
                    GridView4.DataSource = null;
                    GridView4.DataBind();
                }
            }
            else
            {
                // Label3.Text = "No Record Found";
                Label2.Text = "";
                btotal = 0;
				paid=0;
                GridView4.DataSource = null;
                GridView4.DataBind();
            }
            Label3.Text = bpending.ToString();

            int bbal = btotal-paid - bpending;
			Label8.Text = paid.ToString();
            Label4.Text = bbal.ToString();
        }
        else
        {
           // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c  join callback r  on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date BETWEEN '" + date11 + "' AND '" + date2 + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO  where r.CUSTREGNO NOT IN(select c1.CUSTREGNO from wjstar1.customerreg1 c1  join calldemo r1 on r1.CUSTREGNO=c1.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + date11 + "' group By CUSTREGNO ) as  r2  on r2.CUSTREGNO=c1.CUSTREGNO where DAY(c1.date3)='" + dd + "' AND c1.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))AND c1.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')) AND r.date BETWEEN '" + date11 + "' AND '" + date2 + "' AND r.CUSTREGNO in(select DISTINCT CUSTREGNO from calldemo where  userid='" + TextBox4.Text + "' ) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.recipt1 where MONTH(DATE1)=" + mon + " AND YEAR(DATE1)=" + year + " ) ", con1);
			 SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY ,r.date,r.reason,r.feeddate AS 'feeddate',r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c  join backcall r3  on r3.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback where date<='" + date11 + "' AND userid='" + TextBox4.Text + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + date11 + "' AND userid='" + TextBox4.Text + "' group By CUSTREGNO) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where r3.date='"+date11+"' AND r3.userid='" + TextBox4.Text + "' AND c.CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mon + "' AND year(DATE1)='" + year + "') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);

            // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime+' - '+CONVERT(varchar(10), r1.pmt1) AS entrytime  from wjstar1.customerreg1 c left join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='"+start+"' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='"+dd+"' AND year(DATE1)='"+yy+"'))AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);

            DataSet ds = new DataSet();
            cmd.Fill(ds);


            con1.Close();
            con1.Open();

            SqlDataAdapter cmd1 = new SqlDataAdapter("select count(DISTINCT CUSTREGNO) from backcall where date='"+date11+"' AND userid='"+TextBox4.Text+"'", con1);
            /* SqlDataAdapter cmd1 = new SqlDataAdapter("select count( r.CUSTREGNO)  from  calldemo r  where r.date BETWEEN '" + date1 + "' AND '" + date2 + "' AND r.userid='" + TextBox4.Text + "'  AND r.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);*/
            DataSet ds1 = new DataSet();
            cmd1.Fill(ds1);


            con1.Close();
			/*SqlDataAdapter cmd3 = new SqlDataAdapter("select count(DISTINCT CUSTREGNO) from backcall  where CUSTREGNO  IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')  AND userid='"+TextBox4.Text+"'", con1);
			   con1.Open();*/
			SqlDataAdapter cmd3 = new SqlDataAdapter("Select count(DISTINCT CUSTREGNO) from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "' AND usertype='" + TextBox4.Text + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from backcall where date='" + date11 + "')", con1);
			DataSet ds3 = new DataSet();
            cmd3.Fill(ds3);


            con1.Close();
            if (ds.Tables[0].Rows.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "" && ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    // Label3.Text = "";

                    btotal = Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString());
                    Label2.Text = btotal.ToString();
					if(ds3.Tables[0].Rows[0][0].ToString() != "")
					{
						paid = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());
					}
					else
						
					{
						paid=0;
					}
                    GridView4.DataSource = ds;
                    GridView4.DataBind();
                }
                else
                {
                    // Label3.Text = "No Record Found";
                    Label2.Text = "";
                    btotal = 0;
					paid=0;
                    GridView4.DataSource = null;
                    GridView4.DataBind();
                }
            }
            else
            {
                // Label3.Text = "No Record Found";
                Label2.Text = "";
                btotal = 0;
				paid=0;
                GridView4.DataSource = null;
                GridView4.DataBind();
            }
            Label3.Text = bpending.ToString();
Label8.Text = paid.ToString();
            int bbal = btotal -paid- bpending;
            Label4.Text = bbal.ToString();
        }
       
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string s2 = TextBox1.Text;
        // string s4 = TextBox3.Text;
        string dd = s2.Substring(0, 2);
        // string dd1 = s4.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
        // string mm1 = s4.Substring(3, 2);
        // string yy1 = s4.Substring(6, 4);
        string start = dd + "/" + mm + "/" + yy;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string dateString1 = e.Row.Cells[9].Text;
            string dateString2 = e.Row.Cells[11].Text;

            CultureInfo provider = CultureInfo.InvariantCulture;
            // It throws Argument null exception  

            string h = e.Row.Cells[9].Text;
            string h2 = e.Row.Cells[11].Text;
            if (h != "&nbsp;" && h2 != "&nbsp;")
            {
                // DateTime d1 = Convert.ToDateTime(e.Row.Cells[9].Text);
                DateTime d1 = DateTime.ParseExact(dateString1, "mm/dd/yyyy", provider);
                DateTime d2 = DateTime.ParseExact(dateString2, "mm/dd/yyyy", provider);
                /* if (birthDate.ToShortDateString() == "1/1/1900")
                 {
                     e.Row.Cells[1].Text = "null";
                 }*/
                int res = DateTime.Compare(d1, d2);
                // returns <0 since d1 is earlier than d2
                /* if (res == 0)
                 {
                     e.Row.Cells[11].Text = "";
                 }*/
            }
            if (h != "&nbsp;")
            {
                // DateTime d1 = Convert.ToDateTime(e.Row.Cells[9].Text);
                DateTime d1 = DateTime.ParseExact(dateString1, "mm/dd/yyyy", provider);

                DateTime d2 = DateTime.ParseExact(start, "mm/dd/yyyy", provider);
                /* if (birthDate.ToShortDateString() == "1/1/1900")
                 {
                     e.Row.Cells[1].Text = "null";
                 }*/
                int res = DateTime.Compare(d1, d2);
                // returns <0 since d1 is earlier than d2
               // Label1.Text = d2.ToString();

                if (res != 0)
                {
                    e.Row.Cells[12].Text = "";


                }
                if (res == 0)
                {
                    bpending = bpending + 1;

                }
            }



        }
    }
    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gr = GridView4.SelectedRow;
        String id = gr.Cells[1].Text;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO AS 'REGNO',LEFT(r.ASSADDRESS,20) AS 'ADDRESS',r.PLANTERM AS 'PLAN',r.EXPLANDVALUE AS 'VALUE',r.RECIPT,r.DATE,r.INSTNO,r.AMOUNTR,u.APPNO from wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + id + "'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        GridView3.DataSource = ds;
        GridView3.DataBind();
    }
}