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
  static  DataTable advance = new DataTable();
   static DataTable fresh = new DataTable();
   static DataTable backadvance = new DataTable();
   static DataTable backfresh = new DataTable();
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
            if (Session["idr"] != null)
            {
               // id = "heedrealestate";
                 id = Session["idr"].ToString();
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
            Label1111.Text = "internal problem" + t;
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

               // DropDownList2.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
                DropDownList3.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label1111.Text = "internal problem";
        }
    }
   
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
       /* GridViewRow gr = GridView2.SelectedRow;
        String id = gr.Cells[1].Text;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO AS 'REGNO',LEFT(r.ASSADDRESS,20) AS 'ADDRESS',r.PLANTERM AS 'PLAN',r.EXPLANDVALUE AS 'VALUE',r.RECIPT,r.DATE,r.INSTNO,r.AMOUNTR,u.APPNO from wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + id + "'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        GridView3.DataSource = ds;
        GridView3.DataBind();*/
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataRow dr11, dr1;
        advance.Clear();
        fresh.Clear();
        for (int col = advance.Columns.Count - 1; col >= 0; col--)
        {

            advance.Columns.RemoveAt(col);
        }
        for (int col = fresh.Columns.Count - 1; col >= 0; col--)
        {

            fresh.Columns.RemoveAt(col);
        }
        advance.Columns.AddRange(new DataColumn[15] { new DataColumn("CUSTREGNO", typeof(string)),new DataColumn("NAME", typeof(string)),
                            new DataColumn("APPNO", typeof(string)),
                            new DataColumn("plotno",typeof(string)),new DataColumn("PLOTSIZE",typeof(string)),new DataColumn("date3", typeof(string)),new DataColumn("MOBILE", typeof(string)) ,new DataColumn("CHECKBY",typeof(string)),new DataColumn("date",typeof(string)),new DataColumn("reason",typeof(string)),new DataColumn("feeddate",typeof(string)),new DataColumn("entrytime",typeof(string)),new DataColumn("demo",typeof(string)),new DataColumn("entrytime1",typeof(string)),new DataColumn("advance",typeof(string))});
        dr1 = advance.NewRow();
        dr1 = null;

        fresh = new DataTable();

        fresh.Columns.AddRange(new DataColumn[14] { new DataColumn("CUSTREGNO", typeof(string)),new DataColumn("NAME", typeof(string)),
                            new DataColumn("APPNO", typeof(string)),
                            new DataColumn("plotno",typeof(string)),new DataColumn("PLOTSIZE",typeof(string)),new DataColumn("date3", typeof(string)),new DataColumn("MOBILE", typeof(string)) ,new DataColumn("CHECKBY",typeof(string)),new DataColumn("date",typeof(string)),new DataColumn("reason",typeof(string)),new DataColumn("feeddate",typeof(string)),new DataColumn("entrytime",typeof(string)),new DataColumn("demo",typeof(string)),new DataColumn("entrytime1",typeof(string))});
        dr11 = fresh.NewRow();
        dr11 = null; 
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
            if (Convert.ToInt32(mm1) != 2)
            {
                end = mm1 + "/" + dd1 + "/" + yy1;
            }
            else
            {
                end = mm1 + "/" + dd1 + "/" + yy1;
            }


            if (DropDownList4.Text == "NON PAID")
            {
                int c=0;
                GridView2.Visible = true;
                SqlConnection con1 = new SqlConnection(s);
                con1.Open();

                //   SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) BETWEEN '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND  c.APPNO='" + DropDownList3.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);

                SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback1 where ID in(select MAX(ID) from callerfeedback1 where date between '" + start + "' AND '" + end + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback1 where date between '" + start + "' AND '" + end + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) between '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND  c.APPNO='" + DropDownList3.Text + "'   AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
               // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1   from wjstar1.customerreg1 c left join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date between '" + start + "' AND '" + end + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) between '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))  AND  c.APPNO='" + DropDownList3.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                string reg1 = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count != null)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            reg1 = "";
                            reg1 = ds.Tables[0].Rows[i][0].ToString();
                            TextBox5.Text = reg1;
                            int rty = search(reg1);
                            if (rty != 0)
                            {
                                dr1 = advance.NewRow();
                                dr1["CUSTREGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                dr1["NAME"] = ds.Tables[0].Rows[i][1].ToString();
                                dr1["APPNO"] = ds.Tables[0].Rows[i][2].ToString();
                                dr1["plotno"] = ds.Tables[0].Rows[i][3].ToString();
                                dr1["PLOTSIZE"] = ds.Tables[0].Rows[i][4].ToString();
                                dr1["date3"] = Convert.ToDateTime(ds.Tables[0].Rows[i][5].ToString()).ToString("dd/MM/yyyy");
                                dr1["MOBILE"] = ds.Tables[0].Rows[i][6].ToString();
                                dr1["CHECKBY"] = ds.Tables[0].Rows[i][7].ToString();
                                if (ds.Tables[0].Rows[i][8].ToString() != "")
                                {
                                    dr1["date"] =  Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    dr1["date"] = ds.Tables[0].Rows[i][8].ToString();
                                }
                                dr1["reason"] = ds.Tables[0].Rows[i][9].ToString();
                                if (ds.Tables[0].Rows[i][10].ToString() != "")
                                {
                                    dr1["feeddate"] = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    dr1["feeddate"] = ds.Tables[0].Rows[i][10].ToString();
                                }
                               
                                dr1["entrytime"] = ds.Tables[0].Rows[i][11].ToString();
                                dr1["demo"] = ds.Tables[0].Rows[i][12].ToString();
                                dr1["entrytime1"] = ds.Tables[0].Rows[i][13].ToString();

                                 dr1["advance"] =rty;


                                advance.Rows.Add(dr1);
                            }
                            else
                            {
                                dr11 = fresh.NewRow();
                                dr11["CUSTREGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                dr11["NAME"] = ds.Tables[0].Rows[i][1].ToString();
                                dr11["APPNO"] = ds.Tables[0].Rows[i][2].ToString();
                                dr11["plotno"] = ds.Tables[0].Rows[i][3].ToString();
                                dr11["PLOTSIZE"] = ds.Tables[0].Rows[i][4].ToString();
                                dr11["date3"] = Convert.ToDateTime(ds.Tables[0].Rows[i][5].ToString()).ToString("dd/MM/yyyy");
                                dr11["MOBILE"] = ds.Tables[0].Rows[i][6].ToString();
                                dr11["CHECKBY"] = ds.Tables[0].Rows[i][7].ToString();
                                if (ds.Tables[0].Rows[i][8].ToString() != "")
                                {
                                    dr11["date"] = Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    dr11["date"] = ds.Tables[0].Rows[i][8].ToString();
                                }
                                dr11["reason"] = ds.Tables[0].Rows[i][9].ToString();
                                if (ds.Tables[0].Rows[i][10].ToString() != "")
                                {
                                    dr11["feeddate"] = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    dr11["feeddate"] = ds.Tables[0].Rows[i][10].ToString();
                                }
                                if (ds.Tables[0].Rows[i][8].ToString() != "")
                                {
                                    string h = Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy"); ;
                                    //  string h2 = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");;
                                    if (h != "")
                                    {
                                        string s44 = h;
                                        string dd00 = s44.Substring(0, 2);
                                        string mm00 = s44.Substring(3, 2);
                                        string yy00 = s44.Substring(6, 4);
                                        string s222 = TextBox2.Text;
                                        string s555 = TextBox3.Text;
                                        string dd111 = s222.Substring(0, 2);
                                        string dd222 = s555.Substring(0, 2);
                                        string mm111 = s222.Substring(3, 2);
                                        string yy111 = s222.Substring(6, 4);
                                        string mm222 = s555.Substring(3, 2);
                                        string yy222 = s555.Substring(6, 4);
                                        //  string start = mm + "/" + dd + "/" + yy;
                                        // string end;

                                        DateTime d2 = new DateTime(Convert.ToInt32(yy00), Convert.ToInt32(mm00), Convert.ToInt32(dd00));
                                        DateTime d3 = new DateTime(Convert.ToInt32(yy111), Convert.ToInt32(mm111), Convert.ToInt32(dd111));
                                        DateTime d4 = new DateTime(Convert.ToInt32(yy222), Convert.ToInt32(mm222), Convert.ToInt32(dd222));
                                        int res4 = 0;
                                        if (d3 <= d2 && d2 <= d4)
                                        {
                                            res4 = 1;
                                        }
                                        else
                                        {
                                            res4 = 0;
                                        }
                                        // returns <0 since d1 is earlier than d2
                                        if (res4 == 1)
                                        {
                                            c = c + 1;
                                        }
                                    }

                                }


                                dr11["entrytime"] = ds.Tables[0].Rows[i][11].ToString();
                                dr11["demo"] = ds.Tables[0].Rows[i][12].ToString();
                                dr11["entrytime1"] = ds.Tables[0].Rows[i][13].ToString();




                                fresh.Rows.Add(dr11);
                                // dr11 = fresh.NewRow();
                            }
                        }
                    }
                }
                GridView2.DataSource = fresh;
                GridView2.DataBind();

                con1.Close();
              /*  con1.Open();
                SqlDataAdapter cmd5 = new SqlDataAdapter("Select count(DISTINCT CUSTREGNO) from wjstar1.recipt1 where month(DATE1)=" + mm + " AND year(DATE1)=" + yy + " AND usertype='" + TextBox4.Text + "' AND CUSTREGNO IN(select DISTINCT CUSTREGNO from wjstar1.customerreg1 where DAY(date3) between " + dd + " AND "+dd1+" AND c.APPNO='" + DropDownList3.Text + "')", con1);

                DataSet ds5 = new DataSet();
                cmd5.Fill(ds5);
                int pad = 0;
                if (ds5.Tables[0].Rows.Count > 0)
                {

                    if (ds5.Tables[0].Rows[0][0].ToString() != "")
                    {
                        pad = Convert.ToInt32(ds5.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        pad = 0;
                    }
                }*/
               // Label9999.Text = pad.ToString();
                Label5555.Text = fresh.Rows.Count.ToString();
                     Label6666.Text = c.ToString();
                     int pending = Convert.ToInt32(fresh.Rows.Count.ToString()) - c ;
                     Label7777.Text= pending.ToString();
                backdetails(start, end);


            }
            else
            {
                if (DropDownList4.Text == "ALL ARAZI NON PAID")
                {
                    int c = 0;
                    
                    GridView2.Visible = true;
                    SqlConnection con1 = new SqlConnection(s);
                    con1.Open();


                    //  SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) BETWEEN '" + dd + "' AND '" + dd1 + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);


                    SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback1 where ID in(select MAX(ID) from callerfeedback1 where date between '" + start + "' AND '" + end + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback1 where date between '" + start + "' AND '" + end + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) between '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))  AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
                    DataSet ds = new DataSet();
                    cmd.Fill(ds);
                    string reg1 = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                reg1 = "";
                                reg1 = ds.Tables[0].Rows[i][0].ToString();
                                TextBox5.Text = reg1;
                                int rty = search(reg1);
                                if (rty != 0)
                                {
                                    dr1 = advance.NewRow();
                                    dr1["CUSTREGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                    dr1["NAME"] = ds.Tables[0].Rows[i][1].ToString();
                                    dr1["APPNO"] = ds.Tables[0].Rows[i][2].ToString();
                                    dr1["plotno"] = ds.Tables[0].Rows[i][3].ToString();
                                    dr1["PLOTSIZE"] = ds.Tables[0].Rows[i][4].ToString();
                                    dr1["date3"] = Convert.ToDateTime(ds.Tables[0].Rows[i][5].ToString()).ToString("dd/MM/yyyy");
                                    dr1["MOBILE"] = ds.Tables[0].Rows[i][6].ToString();
                                    dr1["CHECKBY"] = ds.Tables[0].Rows[i][7].ToString();
                                    if (ds.Tables[0].Rows[i][8].ToString() != "")
                                    {
                                        dr1["date"] = Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        dr1["date"] = ds.Tables[0].Rows[i][8].ToString();
                                    }
                                    dr1["reason"] = ds.Tables[0].Rows[i][9].ToString();
                                    if (ds.Tables[0].Rows[i][10].ToString() != "")
                                    {
                                        dr1["feeddate"] = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        dr1["feeddate"] = ds.Tables[0].Rows[i][10].ToString();
                                    }
                                    dr1["entrytime"] = ds.Tables[0].Rows[i][11].ToString();
                                    dr1["demo"] = ds.Tables[0].Rows[i][12].ToString();
                                    dr1["entrytime1"] = ds.Tables[0].Rows[i][13].ToString();
                                    dr1["advance"] =rty;
                                    if (ds.Tables[0].Rows[i][8].ToString() != "")
                                    {
                                        string h = Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy"); ;
                                        //  string h2 = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");;
                                        if (h != "")
                                        {
                                            string s41 = h;
                                            string dd23 = s41.Substring(0, 2);
                                            string mm23 = s41.Substring(3, 2);
                                            string yy23 = s41.Substring(6, 4);

                                           DateTime d1 = DateTime.Today;
                                            //DateTime d1 = new DateTime(2023, 06, 13);
                                            DateTime d2 = new DateTime(Convert.ToInt32(yy23), Convert.ToInt32(mm23), Convert.ToInt32(dd23));
                                           
                                        }
                                    }


                                    advance.Rows.Add(dr1);
                                }
                                else
                                {
                                    dr11 = fresh.NewRow();
                                    dr11["CUSTREGNO"] = ds.Tables[0].Rows[i][0].ToString();
                                    dr11["NAME"] = ds.Tables[0].Rows[i][1].ToString();
                                    dr11["APPNO"] = ds.Tables[0].Rows[i][2].ToString();
                                    dr11["plotno"] = ds.Tables[0].Rows[i][3].ToString();
                                    dr11["PLOTSIZE"] = ds.Tables[0].Rows[i][4].ToString();
                                    dr11["date3"] = Convert.ToDateTime(ds.Tables[0].Rows[i][5].ToString()).ToString("dd/MM/yyyy");
                                    dr11["MOBILE"] = ds.Tables[0].Rows[i][6].ToString();
                                    dr11["CHECKBY"] = ds.Tables[0].Rows[i][7].ToString();
                                    if (ds.Tables[0].Rows[i][8].ToString() != "")
                                    {
                                        dr11["date"] = Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        dr11["date"] = ds.Tables[0].Rows[i][8].ToString();
                                    }
                                    dr11["reason"] = ds.Tables[0].Rows[i][9].ToString();
                                    if (ds.Tables[0].Rows[i][10].ToString() != "")
                                    {
                                        dr11["feeddate"] = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        dr11["feeddate"] = ds.Tables[0].Rows[i][10].ToString();
                                    }
                                    dr11["entrytime"] = ds.Tables[0].Rows[i][11].ToString();
                                    dr11["demo"] = ds.Tables[0].Rows[i][12].ToString();
                                    dr11["entrytime1"] = ds.Tables[0].Rows[i][13].ToString();
                                    if (ds.Tables[0].Rows[i][8].ToString() != "")
                                    {
                                        string h = Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy"); ;
                                        //  string h2 = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");;
                                        if (h != "")
                                        {
                                            string s44 = h;
                                            string dd00 = s44.Substring(0, 2);
                                            string mm00 = s44.Substring(3, 2);
                                            string yy00 = s44.Substring(6, 4);
                                            string s222 = TextBox2.Text;
                                            string s555 = TextBox3.Text;
                                            string dd111 = s222.Substring(0, 2);
                                            string dd222 = s555.Substring(0, 2);
                                            string mm111 = s222.Substring(3, 2);
                                            string yy111 = s222.Substring(6, 4);
                                            string mm222 = s555.Substring(3, 2);
                                            string yy222 = s555.Substring(6, 4);
                                          //  string start = mm + "/" + dd + "/" + yy;
                                           // string end;

                                            DateTime d2 = new DateTime(Convert.ToInt32(yy00), Convert.ToInt32(mm00), Convert.ToInt32(dd00));
                                            DateTime d3 = new DateTime(Convert.ToInt32(yy111), Convert.ToInt32(mm111), Convert.ToInt32(dd111));
                                            DateTime d4 = new DateTime(Convert.ToInt32(yy222), Convert.ToInt32(mm222), Convert.ToInt32(dd222));
                                            int res3 = 0;
                                            if (d3 <= d2 && d2 <= d4)
                                            {
                                                res3 = 1;
                                            }
                                            else
                                            {
                                                res3 = 0;
                                            }
                                            // returns <0 since d1 is earlier than d2
                                            if (res3 == 1)
                                            {
                                                c = c + 1;
                                            }
                                        }

                                    }


                                    fresh.Rows.Add(dr11);
                                    // dr11 = fresh.NewRow();
                                }
                            }
                        }
                    }
                    GridView2.DataSource = fresh;
                    GridView2.DataBind();

                    con1.Close();
                    Label5555.Text = fresh.Rows.Count.ToString();
                    Label6666.Text = c.ToString();
                    int pending = Convert.ToInt32(fresh.Rows.Count.ToString()) - c;
                    Label7777.Text = pending.ToString();
                    backdetails(start, end);



                }
                else
                {
                    Label1111.Text = "Please select any mode";
                }
            }

        }
        // DataTable dt = new DataTable();



        catch (Exception t)
        {
            Label1111.Text = "internal problem" + t;
        }
    }


    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int c = 0;
            string h = e.Row.Cells[8].Text;
         //   string h2 = e.Row.Cells[11].Text;
            if (h == "&nbsp;")
            {
               // c = c + 1;
                
            }
            else
            {
                string s4 = h;
                string dd = s4.Substring(0, 2);
                string mm = s4.Substring(3, 2);
                string yy = s4.Substring(6, 4);
                string s2 = TextBox2.Text;
                string s5 = TextBox3.Text;
                string dd1 = s2.Substring(0, 2);
                string dd2 = s5.Substring(0, 2);
                string mm1 = s2.Substring(3, 2);
                string yy1 = s2.Substring(6, 4);
                string mm2 = s5.Substring(3, 2);
                string yy2 = s5.Substring(6, 4);
                string start = mm + "/" + dd + "/" + yy;
                string end;

                DateTime d2 = new DateTime(Convert.ToInt32(yy), Convert.ToInt32(mm), Convert.ToInt32(dd));
                DateTime d3 = new DateTime(Convert.ToInt32(yy1), Convert.ToInt32(mm1), Convert.ToInt32(dd1));
                DateTime d4 = new DateTime(Convert.ToInt32(yy2), Convert.ToInt32(mm2), Convert.ToInt32(dd2));
                int res = 0;
                if (d3 <= d2 && d2 <= d4)
                {
                    res = 1; 
                }
                else
                {
                    res = 0 ;
                }  
                // returns <0 since d1 is earlier than d2
                if (res == 0)
                {
                    e.Row.Cells[11].Text = "";
                    e.Row.Cells[8].Text = "";
                    e.Row.Cells[9].Text = "";
                    e.Row.Cells[10].Text = "";
                }

            }
            //Label3333.Text = c.ToString();
        }
           
    }
    public void backdetails(string date1, string date2)
    {
        //   Label3.Text = "";

        DataRow dr11, dr1;
        backadvance.Clear();
        backfresh.Clear();
        for (int col = backadvance.Columns.Count - 1; col >= 0; col--)
        {

            backadvance.Columns.RemoveAt(col);
        }
        for (int col = backfresh.Columns.Count - 1; col >= 0; col--)
        {

            backfresh.Columns.RemoveAt(col);
        }
        backadvance.Columns.AddRange(new DataColumn[15] { new DataColumn("CUSTREGNO", typeof(string)),new DataColumn("NAME", typeof(string)),
                            new DataColumn("APPNO", typeof(string)),
                            new DataColumn("plotno",typeof(string)),new DataColumn("PLOTSIZE",typeof(string)),new DataColumn("date3", typeof(string)),new DataColumn("MOBILE", typeof(string)) ,new DataColumn("CHECKBY",typeof(string)),new DataColumn("date",typeof(string)),new DataColumn("reason",typeof(string)),new DataColumn("feeddate",typeof(string)),new DataColumn("entrytime",typeof(string)),new DataColumn("demo",typeof(string)),new DataColumn("entrytime1",typeof(string)),new DataColumn("advance",typeof(string))});
        dr1 = backadvance.NewRow();
        dr1 = null;

        backfresh = new DataTable();

        backfresh.Columns.AddRange(new DataColumn[14] { new DataColumn("CUSTREGNO", typeof(string)),new DataColumn("NAME", typeof(string)),
                            new DataColumn("APPNO", typeof(string)),
                            new DataColumn("plotno",typeof(string)),new DataColumn("PLOTSIZE",typeof(string)),new DataColumn("date3", typeof(string)),new DataColumn("MOBILE", typeof(string)) ,new DataColumn("CHECKBY",typeof(string)),new DataColumn("date",typeof(string)),new DataColumn("reason",typeof(string)),new DataColumn("feeddate",typeof(string)),new DataColumn("entrytime",typeof(string)),new DataColumn("demo",typeof(string)),new DataColumn("entrytime1",typeof(string))});
        dr11 = backfresh.NewRow();
        dr11 = null;
        int paid = 0;
        DateTime es = DateTime.Now;
        int mon = es.Month;
        int ft = mon;
        int year = es.Year;

      //  string date2 = date11;
        GridView4.Visible = true;
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        int c = 0;
       

        CultureInfo provider = CultureInfo.InvariantCulture;
        string s4 = date1;
        string mm1 = s4.Substring(0, 2);
        string dd1 = s4.Substring(3, 2);
        string yy1 = s4.Substring(6, 4);
        string s5 = date2;
        DateTime date12 = new DateTime(Convert.ToInt32(yy1), Convert.ToInt32(mm1), Convert.ToInt32(dd1));  
        string mm3 = s5.Substring(0, 2);
        string dd3 = s5.Substring(3, 2);
        string yy3 = s5.Substring(6, 4);
        DateTime date13 = new DateTime(Convert.ToInt32(yy3), Convert.ToInt32(mm3), Convert.ToInt32(dd3)); 
        // DateTime d2 = DateTime.ParseExact(date1, "mm/dd/yyyy", provider);
        // DateTime d3 = DateTime.ParseExact(date2, "mm/dd/yyyy", provider);
        /* if (birthDate.ToShortDateString() == "1/1/1900")
         {
             e.Row.Cells[1].Text = "null";
         }*/
        int res = DateTime.Compare(date12,date13);
        // returns <0 since d1 is earlier than d2
        Label1111.Text = res.ToString();

        
            // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c  join callback r  on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date BETWEEN '" + date11 + "' AND '" + date2 + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO  where r.CUSTREGNO NOT IN(select c1.CUSTREGNO from wjstar1.customerreg1 c1  join calldemo r1 on r1.CUSTREGNO=c1.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + date11 + "' group By CUSTREGNO ) as  r2  on r2.CUSTREGNO=c1.CUSTREGNO where DAY(c1.date3)='" + dd + "' AND c1.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))AND c1.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')) AND r.date BETWEEN '" + date11 + "' AND '" + date2 + "' AND r.CUSTREGNO in(select DISTINCT CUSTREGNO from calldemo where  userid='" + TextBox4.Text + "' ) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.recipt1 where MONTH(DATE1)=" + mon + " AND YEAR(DATE1)=" + year + " ) ", con1);
           // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY ,r.date,r.reason,r.feeddate AS 'feeddate',r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c  join backcall r3  on r3.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback where date BETWEEN '" + date1 + "' AND '" + date2 + "' AND userid='" + TextBox4.Text + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date BETWEEN '" + date1 + "' AND '" + date2 + "' AND userid='" + TextBox4.Text + "' group By CUSTREGNO) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where r3.date BETWEEN '" + date1 + "' AND '" + date2 + "' AND r3.userid='" + TextBox4.Text + "' AND c.CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)=" + mon + " AND year(DATE1)=" + year + ") AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
       // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY ,r.date,r.reason,r.feeddate AS 'feeddate',r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c  join backcall r3  on r3.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback where date<='" + date13 + "' AND userid='" + TextBox4.Text + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date  BETWEEN '" + date1 + "' AND '" + date2 + "' AND userid='" + TextBox4.Text + "' group By CUSTREGNO) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where r3.date  BETWEEN '" + date1 + "' AND '" + date2 + "' AND r3.userid='" + TextBox4.Text + "' AND c.CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mon + "' OR MONTH(DATE1)=" + ft + " AND year(DATE1)='" + year + "') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
            // SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime+' - '+CONVERT(varchar(10), r1.pmt1) AS entrytime  from wjstar1.customerreg1 c left join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='"+start+"' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3)='" + dd + "' AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='"+dd+"' AND year(DATE1)='"+yy+"'))AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
        SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY,r.date,r.reason,r.feeddate,r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c INNER join calldemo1 r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback1 where date BETWEEN '" + date12 + "' AND '" + date13 + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where r.date BETWEEN '" + date12 + "' AND '" + date13 + "' OR r.feeddate BETWEEN '" + date12 + "' AND '" + date13 + "' AND userid='" + TextBox4.Text + "' AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.recipt1 where MONTH(DATE1)=" + ft + " AND YEAR(DATE1)=" + year + " ) AND c.CUSTREGNO NOT IN(select DISTINCT c.CUSTREGNO  from wjstar1.customerreg1 c left join calldemo1 r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback1 where date between '" + date12 + "' AND '" + date13 + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) between '" + dd1 + "' AND '" + dd3 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + ft + "' AND year(DATE1)='" + year + "'))  AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') AND c.CUSTREGNO NOT IN(select DISTINCT c1.CUSTREGNO  from wjstar1.customerreg1 c1 left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback1 where ID in(select MAX(ID) from callerfeedback1 where date between '" + date12 + "' AND '" + date13 + "'   group By CUSTREGNO)) as r on r.CUSTREGNO=c1.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback1 where date between '" + date12 + "' AND '" + date13 + "'  group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c1.CUSTREGNO where DAY(c1.date3) between '" + dd1 + "' AND '" + dd3 + "'  AND c1.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + TextBox4.Text + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + ft + "' AND year(DATE1)='" + year + "'))  AND c1.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')))", con1);	
		
		
		//SqlDataAdapter cmd = new SqlDataAdapter("select DISTINCT c.CUSTREGNO,LEFT(c.NAMEDOBADDRESS,20) AS 'NAME', c.APPNO,c.plotno,c.PLOTSIZE,c.date3,CONCAT(c.mobile,' , ',c.mobile2) AS 'MOBILE',c.CHECKBY ,r.date,r.reason,r.feeddate AS 'feeddate',r.entrytime AS 'entrytime',CONVERT(varchar(10), r1.pmt1) AS 'demo',r.entrytime1  from wjstar1.customerreg1 c  join calldemo r3  on r3.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback1 where date<='" + date13 + "' AND userid='" + TextBox4.Text + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback1 where date='" + date13 + "' AND userid='" + TextBox4.Text + "' group By CUSTREGNO) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where r3.date<='" + date13 + "' AND r3.userid='" + TextBox4.Text + "' AND c.CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mon + "' OR MONTH(DATE1)=" + ft + " AND year(DATE1)='" + year + "') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')", con1);
            DataSet ds = new DataSet();
            cmd.Fill(ds);


            con1.Close();
            string reg1 = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        reg1 = "";
                        reg1 = ds.Tables[0].Rows[i][0].ToString();
                        TextBox5.Text = reg1;
                        int rty = search(reg1);
                        if (rty != 0)
                        {
                            dr1 = backadvance.NewRow();
                            dr1["CUSTREGNO"] = ds.Tables[0].Rows[i][0].ToString();
                            dr1["NAME"] = ds.Tables[0].Rows[i][1].ToString();
                            dr1["APPNO"] = ds.Tables[0].Rows[i][2].ToString();
                            dr1["plotno"] = ds.Tables[0].Rows[i][3].ToString();
                            dr1["PLOTSIZE"] = ds.Tables[0].Rows[i][4].ToString();
                            dr1["date3"] = Convert.ToDateTime(ds.Tables[0].Rows[i][5].ToString()).ToString("dd/MM/yyyy");
                            dr1["MOBILE"] = ds.Tables[0].Rows[i][6].ToString();
                            dr1["CHECKBY"] = ds.Tables[0].Rows[i][7].ToString();
                            if (ds.Tables[0].Rows[i][8].ToString() != "")
                            {
                                dr1["date"] = Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                dr1["date"] = ds.Tables[0].Rows[i][8].ToString();
                            }
                            dr1["reason"] = ds.Tables[0].Rows[i][9].ToString();
                            if (ds.Tables[0].Rows[i][10].ToString() != "")
                            {
                                dr1["feeddate"] = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                dr1["feeddate"] = ds.Tables[0].Rows[i][10].ToString();
                            }
                            dr1["entrytime"] = ds.Tables[0].Rows[i][11].ToString();
                            dr1["demo"] = ds.Tables[0].Rows[i][12].ToString();
                            dr1["entrytime1"] = ds.Tables[0].Rows[i][13].ToString();
                            dr1["advance"] = rty;




                            backadvance.Rows.Add(dr1);
                        }
                        else
                        {
                            dr11 = backfresh.NewRow();
                            dr11["CUSTREGNO"] = ds.Tables[0].Rows[i][0].ToString();
                            dr11["NAME"] = ds.Tables[0].Rows[i][1].ToString();
                            dr11["APPNO"] = ds.Tables[0].Rows[i][2].ToString();
                            dr11["plotno"] = ds.Tables[0].Rows[i][3].ToString();
                            dr11["PLOTSIZE"] = ds.Tables[0].Rows[i][4].ToString();
                            dr11["date3"] = Convert.ToDateTime(ds.Tables[0].Rows[i][5].ToString()).ToString("dd/MM/yyyy");
                            dr11["MOBILE"] = ds.Tables[0].Rows[i][6].ToString();
                            dr11["CHECKBY"] = ds.Tables[0].Rows[i][7].ToString();
                            if (ds.Tables[0].Rows[i][8].ToString() != "")
                            {
                                dr11["date"] = Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                dr11["date"] = ds.Tables[0].Rows[i][8].ToString();
                            }
                            if (ds.Tables[0].Rows[i][8].ToString() != "")
                            {
                                string h = Convert.ToDateTime(ds.Tables[0].Rows[i][8].ToString()).ToString("dd/MM/yyyy"); ;
                                //  string h2 = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");;
                                if (h != "")
                                {
                                    string s44 = h;
                                    string dd00 = s44.Substring(0, 2);
                                    string mm00 = s44.Substring(3, 2);
                                    string yy00 = s44.Substring(6, 4);
                                    string s222 = TextBox2.Text;
                                    string s555 = TextBox3.Text;
                                    string dd111 = s222.Substring(0, 2);
                                    string dd222 = s555.Substring(0, 2);
                                    string mm111 = s222.Substring(3, 2);
                                    string yy111 = s222.Substring(6, 4);
                                    string mm222 = s555.Substring(3, 2);
                                    string yy222 = s555.Substring(6, 4);
                                    //  string start = mm + "/" + dd + "/" + yy;
                                    // string end;

                                    DateTime d2 = new DateTime(Convert.ToInt32(yy00), Convert.ToInt32(mm00), Convert.ToInt32(dd00));
                                    DateTime d3 = new DateTime(Convert.ToInt32(yy111), Convert.ToInt32(mm111), Convert.ToInt32(dd111));
                                    DateTime d4 = new DateTime(Convert.ToInt32(yy222), Convert.ToInt32(mm222), Convert.ToInt32(dd222));
                                    int res1 = 0;
                                    if (d3 <= d2 && d2 <= d4)
                                    {
                                        res1 = 1;
                                    }
                                    else
                                    {
                                        res1 = 0;
                                    }
                                    // returns <0 since d1 is earlier than d2
                                    if (res1 == 1)
                                    {
                                        c = c + 1;
                                    }
                                }

                            }


                            dr11["reason"] = ds.Tables[0].Rows[i][9].ToString();
                            if (ds.Tables[0].Rows[i][10].ToString() != "")
                            {
                                dr11["feeddate"] = Convert.ToDateTime(ds.Tables[0].Rows[i][10].ToString()).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                dr11["feeddate"] = ds.Tables[0].Rows[i][10].ToString();
                            }
                            dr11["entrytime"] = ds.Tables[0].Rows[i][11].ToString();
                            dr11["demo"] = ds.Tables[0].Rows[i][12].ToString();
                            dr11["entrytime1"] = ds.Tables[0].Rows[i][13].ToString();




                            backfresh.Rows.Add(dr11);
                            // dr11 = fresh.NewRow();
                        }
                    }
                }
            }
            con1.Open();

            


            con1.Close();
            /*SqlDataAdapter cmd3 = new SqlDataAdapter("select count(DISTINCT CUSTREGNO) from backcall  where CUSTREGNO  IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')  AND userid='"+TextBox4.Text+"'", con1);
               con1.Open();*/
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    // Label3.Text = "";
                    if (backfresh.Rows.Count > 0)
                    {
                        GridView4.DataSource = backfresh;
                        GridView4.DataBind();
                    }
                    else
                    {
                        GridView4.DataSource = null;
                        GridView4.DataBind();
                    }

                    
                   
                    
                }
                
            }
            else
            {
                GridView4.DataSource = null;
                GridView4.DataBind();
            }
            
            Label3333.Text = c.ToString();
            //Label8888.Text = paid.ToString();
            int pending = Convert.ToInt32(backfresh.Rows.Count.ToString()) - c;
            
            Label4444.Text = pending.ToString();
        
        Label2222.Text = backfresh.Rows.Count.ToString();
       
    }
    
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int c = 0;
            string h = e.Row.Cells[8].Text;
          //  string h2 = e.Row.Cells[11].Text;
            if (h == "&nbsp;")
            {
                
            }
            else
            {
                string s4 = h;
                string dd = s4.Substring(0, 2);
                string mm = s4.Substring(3, 2);
                string yy = s4.Substring(6, 4);
                string s2 = TextBox2.Text;
                string s5 = TextBox3.Text;
                string dd1 = s2.Substring(0, 2);
                string dd2 = s5.Substring(0, 2);
                string mm1 = s2.Substring(3, 2);
                string yy1 = s2.Substring(6, 4);
                string mm2 = s5.Substring(3, 2);
                string yy2 = s5.Substring(6, 4);
                //string start = mm + "/" + dd + "/" + yy;
                //string end;

                DateTime d2 = new DateTime(Convert.ToInt32(yy), Convert.ToInt32(mm), Convert.ToInt32(dd));
                DateTime d3 = new DateTime(Convert.ToInt32(yy1), Convert.ToInt32(mm1), Convert.ToInt32(dd1));
                DateTime d4 = new DateTime(Convert.ToInt32(yy2), Convert.ToInt32(mm2), Convert.ToInt32(dd2));
                int res = 0;
                if (d3 <= d2 && d2 <= d4)
                {
                    res = 1;
                }
                else
                {
                    res = 0;
                }  
                if (res == 0)
                {
                    e.Row.Cells[11].Text = "";
                    e.Row.Cells[8].Text = "";
                   
                   
                }

            }
            // Label6666.Text=c.ToString();
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









    public int search(String reg)
    {
        int y = 0;
        int total1 = 0, total = 0, balance = 0;
        Label1.Text = "";

        try
        {
            
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
                           y= arazisearch(Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()), Label2.Text, total,reg);
                          
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
                            y = 0;
                            
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
                        y = 0;
                        

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
                    y=0;
                    
                }
            }

           
        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
        return y;
    }

    public int arazisearch(Double custotalpayment, string arazi, Double totalrecieve,string reg)
    {
        int st = 0;
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

            Label20.Text = mont.ToString();
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
                    Double bal11 = Convert.ToDouble(Label8.Text);
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
                    Double bal11 = Convert.ToDouble(Label8.Text);
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
                        Double bal11 = Convert.ToDouble(Label8.Text);
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
                        Double bal11 = Convert.ToDouble(Label8.Text);
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
                        Label19.Text = Convert.ToInt32(advancamount).ToString();



                        Label12.Text = lateemi.ToString();
                        Double bal11 = Convert.ToDouble(Label8.Text);
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
                        Double bal11 = Convert.ToDouble(Label8.Text);
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
        if (Convert.ToInt32(Label19.Text) > 0)
        {
            st = Convert.ToInt32(Label19.Text);
        }
        else
        {
            st = 0;
        }

        return st;



    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        Session["data"] = advance;
        Session["data1"] = backadvance;
        Response.Redirect("advance.aspx");
    }
}