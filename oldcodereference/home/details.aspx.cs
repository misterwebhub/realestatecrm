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

public partial class demo : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Button2.Visible = false;
            bindlinvname();
        }
    }
    public void grdbind()
    {
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        con.Close();
       
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        grdbind();
    }
    public void bindl3()
    {

        DropDownList3.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid,ivname from newinvester where invid in(select invid from assignnameid where name='"+DropDownList5.Text+"')", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList3.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i][0].ToString() == "I0021")
            {
                continue;
            }
            else
            {
                DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString() + "---" + ds.Tables[0].Rows[i][1].ToString());

            }
        }
        //DropDownList3.Items.Add("I001---Alok Kumar Pandey (HISHAB)");

    }
    public void bindlinvname()
    {

        DropDownList5.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select name from assignname", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList5.Items.Add("--SELECT--");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            
                DropDownList5.Items.Add(ds.Tables[0].Rows[i][0].ToString());

           
        }
        DropDownList5.Items.Add("I001---Alok Kumar Pandey (HISHAB)");

    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        Panel5.Visible = false;
        //bindl3();
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = true;
        Panel5.Visible = false;
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = true;
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select kname from newkishan where arazi='"+DropDownList1.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
		DropDownList2.Items.Insert(0, "---select---");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            
        }
        con.Close();
    }
    public void databindf()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select reciptid,date,amount,bpaid,unpaidamt,paymode,cheqdate,cheqno,refno,status,reason AS 'reason' from kishanrecipt where bpaid=0 AND kid IN(select id from newkishan where arazi='" + DropDownList1.Text + "' AND kname='" + DropDownList2.Text + "') order by date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    public void kishandetails()
    {
        Double kipaid = 0, bpaid = 0, ktotal = 0, btotal = 0, kbal = 0, bbal = 0, cheque = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazi,kname,landsize,lastdate,landamount,brokername,btotal from newkishan where arazi='" + DropDownList1.Text + "' AND kname='" + DropDownList2.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
           Label2.Text = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            Label2.Text = "0";
        }
        if (ds.Tables[0].Rows[0][1].ToString() != "")
        {
            Label3.Text = ds.Tables[0].Rows[0][1].ToString();
        }
        else
        {
            Label3.Text = "0";
        }
         if (ds.Tables[0].Rows[0][2].ToString() != "")
        {
           Label4.Text = ds.Tables[0].Rows[0][2].ToString();
        }
        else
        {
            Label4.Text = "0";
        }
         string dr = "";
         if (ds.Tables[0].Rows[0][3].ToString() != "")
        {
             dr=ds.Tables[0].Rows[0][3].ToString();
             dr=dr.Substring(0, 10);
             Label5.Text = dr;
            
        }
        else
        {
            Label5.Text = "0";
        }
         if (ds.Tables[0].Rows[0][4].ToString() != "")
        {
           Label6.Text = ds.Tables[0].Rows[0][4].ToString();
           ktotal = Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
        }
        else
        {
            Label6.Text = "0";
            ktotal = 0;
        }
         if (ds.Tables[0].Rows[0][5].ToString() != "")
        {

           Label10.Text = ds.Tables[0].Rows[0][5].ToString();
        }
        else
        {
            Label10.Text = "0";
        }
         if (ds.Tables[0].Rows[0][6].ToString() != "")
        {
           Label11.Text = ds.Tables[0].Rows[0][6].ToString();
           btotal = Convert.ToDouble(ds.Tables[0].Rows[0][6].ToString());

        }
        else
        {
            Label11.Text = "0";
            btotal = 0;
        }
         con.Open();
         SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount),sum(bpaid) from kishanrecipt where kid IN(select id from newkishan where arazi='" + DropDownList1.Text + "' AND kname='" + DropDownList2.Text + "') AND status='PAID' ", con);
         DataSet ds1 = new DataSet();
         da1.Fill(ds1);
         con.Close();

         SqlDataAdapter da3 = new SqlDataAdapter("select sum(unpaidamt) from kishanrecipt where kid IN(select id from newkishan where arazi='" + DropDownList1.Text + "' AND kname='" + DropDownList2.Text + "') AND status='UNPAID'", con);
         DataSet ds3 = new DataSet();
         da3.Fill(ds3);
         con.Close();
         
         if (ds1.Tables[0].Rows[0][0].ToString() != "")
         {
             kipaid =Convert.ToDouble( ds1.Tables[0].Rows[0][0].ToString());
         }
         else
         {
             kipaid =0;
         }
         if (ds1.Tables[0].Rows[0][1].ToString() != "")
         {
             bpaid = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
         }
         else
         {
             bpaid = 0;
         }
         if (ds3.Tables[0].Rows[0][0].ToString() != "")
         {
             cheque = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
         }
         else
         {
             cheque = 0;
         }
         Label9.Text = cheque.ToString();
         kbal = ktotal - kipaid;
         Label7.Text = kipaid.ToString();
         Label8.Text = kbal.ToString();
         bbal = btotal - bpaid;
         Label12.Text = bpaid.ToString();
         Label13.Text = bbal.ToString();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        databindf();
        kishandetails();
        paymentkishanmention();
        Button2.Visible = true;
    }

    public void paymentkishanmention()
    {
        Double pay=0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
		 SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(CAMOUNT) FROM chequedetails WHERE CHEQUETYPE='MENTION' AND STATUS='UNPAID' AND ID NOT IN(SELECT ID from chequedetails where CHEQUETYPE='MENTION' AND STATUS='UNPAID' AND BSTATUS='BOUNCE') and custregno IN(select CUSTREGNO from customerdeed where  deedno IN(select deedno from getpayment where pid='" + DropDownList1.Text + "' AND name='" + DropDownList2.Text + "'))", con);
		//SqlDataAdapter da = new SqlDataAdapter("SELECT sum(CAMOUNT) FROM chequedetails WHERE CHEQUETYPE='MENTION' AND STATUS='UNPAID' AND ID NOT IN(SELECT ID from chequedetails where CHEQUETYPE='MENTION' AND STATUS='UNPAID' AND BSTATUS='BOUNCE') and CUSTREGNO IN(select CUSTREGNO from customerdeed where  deedno IN(select deedno from getpayment where pid='" + DropDownList1.Text + "' AND name='" + DropDownList2.Text + "'))", con);
       // SqlDataAdapter da = new SqlDataAdapter("select sum(CAMOUNT) from chequedetails where CHEQUETYPE='MENTION' AND STATUS='UNPAID' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where  deedno IN(select deedno from getpayment where pid='" + DropDownList1.Text + "' AND name='" + DropDownList2.Text + "'))", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                pay = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                pay = 0;
            }
        }
        else
        {
            pay = 0;
        }
        Label32.Text = pay.ToString("N0");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select reciptid,date,amount,bpaid,unpaidamt,paymode,cheqdate,cheqno,refno,status,breason AS 'reason' from kishanrecipt where bpaid NOT IN(0) AND kid IN(select id from newkishan where arazi='" + DropDownList1.Text + "' AND kname='" + DropDownList2.Text + "') order by date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    public void paymentinvmention()
    {
        Double pay = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(CAMOUNT) from chequedetails where CHEQUETYPE='MENTION' AND STATUS='UNPAID' AND CUSTREGNO IN(select CUSTREGNO from customerdeed where  deedno IN(select deedno from getpayment where pid='" + TextBox1.Text + "'))", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                pay = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                pay = 0;
            }
        }
        else
        {
            pay = 0;
        }
        Label33.Text = pay.ToString("N0");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "I001" || TextBox1.Text == "i001")
        {
            string pageurl = "https://heedrealestate.com/demo5/investerreturn.aspx";

            Page.ClientScript.RegisterStartupScript(
         this.GetType(), "OpenWindow", "window.open('"+pageurl+"','_newtab');", true);
        }
        else
        {

            Double recamt = 0, retamt = 0, bpaid = 0, unpaid = 0, trecamt = 0, tretamt = 0, balrec = 0, balret = 0, brtotal = 0, brbal = 0;
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select invid,ivname,date,lastdate,totalinvestamt,returnamt,brokername,btotal from newinvester where invid='" + TextBox1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label15.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Label15.Text = "0";
                }
                if (ds.Tables[0].Rows[0][1].ToString() != "")
                {
                    Label16.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    Label16.Text = "0";
                }
                String dt;
                if (ds.Tables[0].Rows[0][2].ToString() != "")
                {
                    dt = ds.Tables[0].Rows[0][2].ToString();
                    dt = dt.Substring(0, 10);
                    Label19.Text = dt;
                }
                else
                {
                    Label19.Text = "0";
                }
                String ltdt;
                if (ds.Tables[0].Rows[0][3].ToString() != "")
                {

                    ltdt = ds.Tables[0].Rows[0][3].ToString();
                    ltdt = ltdt.Substring(0, 10);
                    Label20.Text = ltdt;
                }
                else
                {
                    Label20.Text = "0";
                }
                if (ds.Tables[0].Rows[0][4].ToString() != "")
                {
                    Label17.Text = ds.Tables[0].Rows[0][4].ToString();
                    trecamt = Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
                }
                else
                {
                    Label17.Text = "0";
                    trecamt = 0;
                }
                if (ds.Tables[0].Rows[0][5].ToString() != "")
                {
                    Label18.Text = ds.Tables[0].Rows[0][5].ToString();
                    tretamt = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());
                }
                else
                {
                    Label18.Text = "0";
                    tretamt = 0;
                }
                if (ds.Tables[0].Rows[0][6].ToString() != "")
                {
                    Label27.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    Label27.Text = "0";
                }
                if (ds.Tables[0].Rows[0][7].ToString() != "")
                {
                    Label28.Text = ds.Tables[0].Rows[0][7].ToString();
                    brtotal = Convert.ToDouble(ds.Tables[0].Rows[0][7].ToString());
                }
                else
                {
                    Label28.Text = "0";
                    brtotal = 0;
                }
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount) from investerrecipt where bpaid=0 AND invid IN(select invid from investerrecipt where invid='" + TextBox1.Text + "') AND status='PAID' AND type='RECEIVE'", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con.Close();
                if (ds1.Tables[0].Rows[0][0].ToString() != "")
                {
                    recamt = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    recamt = 0;
                }
                Label21.Text = recamt.ToString();
                con.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select sum(amount) from investerrecipt where  bpaid=0 AND invid IN(select invid from investerrecipt where invid='" + TextBox1.Text + "') AND status='PAID' AND type='RETURN'", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                con.Close();
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    retamt = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    retamt = 0;
                }
                Label22.Text = retamt.ToString();
                con.Open();
                SqlDataAdapter da4 = new SqlDataAdapter("select sum(bpaid) from investerrecipt where bpaid NOT IN(0) AND invid IN(select invid from investerrecipt where invid='" + TextBox1.Text + "') AND status='PAID'", con);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                con.Close();
                if (ds4.Tables[0].Rows[0][0].ToString() != "")
                {
                    bpaid = Convert.ToDouble(ds4.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    bpaid = 0;
                }
                Label24.Text = bpaid.ToString();
                SqlDataAdapter da3 = new SqlDataAdapter("select sum(unpamt) from investerrecipt where invid IN(select invid from investerrecipt where invid='" + TextBox1.Text + "') AND status='UNPAID'", con);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                con.Close();
                if (ds3.Tables[0].Rows[0][0].ToString() != "")
                {
                    unpaid = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    unpaid = 0;
                }
                Label30.Text = unpaid.ToString();
                balrec = trecamt - recamt;
                Label25.Text = balrec.ToString();
                balret = tretamt - retamt;
                Label26.Text = balret.ToString();
                brbal = brtotal - bpaid;
                Label29.Text = brbal.ToString();
                paymentinvmention();

            }
            else
            {
                Label14.Text = "Error";
            }
        }
    }
    public void databindinvesterrec()
    {
       
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invrecipt,date,type,amount,bpaid,unpamt,paymode,chekdate,chkno,refby,status,reason from investerrecipt where type='RECEIVE' AND bpaid=0 AND invid IN(select invid from newinvester where invid='" + TextBox1.Text + "') order by date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label31.Text = "";
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }
        else
        {
            Label31.Text = "Record Not Found";
        }
    }
    public void databindinvesterret()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invrecipt,date,type,amount,bpaid,unpamt,paymode,chekdate,chkno,refby,status,reason from investerrecipt where type='RETURN' AND bpaid=0 AND invid IN(select invid from newinvester where invid='" + TextBox1.Text + "') order by date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label31.Text = "";
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }
        else
        {
            Label31.Text = "Record Not Found";
        }
    }
    public void databindinv()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invrecipt,date,type,amount,bpaid,unpamt,paymode,chekdate,chkno,refby,status,reason from investerrecipt where bpaid=0 AND invid IN(select invid from newinvester where invid='" + TextBox1.Text + "') order by date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label31.Text = "";
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }
        else
        {
            Label31.Text = "Record Not Found";
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (DropDownList4.Text == "RECEIVE")
        {
            databindinvesterrec();
        }
        else
        {
            if (DropDownList4.Text == "RETURN")
            {
                databindinvesterret();
            }
            else
            {
                if (DropDownList4.Text == "ALL DETAILS")
                {
                    databindinv();
                }
                else
                {
                    Label31.Text = "Please select any option";
                }
            }
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           /* e.Row.Cells[2].ForeColor = System.Drawing.Color.Blue;
            e.Row.Cells[4].ForeColor = System.Drawing.Color.Blue;
            e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;*/
            string f = e.Row.Cells[2].Text;
string f2 = e.Row.Cells[7].Text;
            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "RECEIVE")
                {
                     //cell.ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
                }
                if (f == "RETURN")
                {
                    //cell.BackColor = System.Drawing.Color.Red;
                   // cell.ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                }
				if (f2 == "01/01/1900")
                {
                    //cell.ForeColor = System.Drawing.Color.Red;
                   // e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                     e.Row.Cells[7].Text ="";
                    //e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;

                }


            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invrecipt,date,type,amount,bpaid,paymode,chekdate,chkno,refby,status,reason from investerrecipt where bpaid NOT IN(0) AND invid IN(select invid from newinvester where invid='" + TextBox1.Text + "') order by date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView2.DataSource = ds;
        GridView2.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            /* e.Row.Cells[2].ForeColor = System.Drawing.Color.Blue;
             e.Row.Cells[4].ForeColor = System.Drawing.Color.Blue;
             e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;*/
            string f = e.Row.Cells[9].Text;
            string f2 = e.Row.Cells[6].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "UNPAID")
                {
                    //cell.ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;

                }
				if (f2 == "01/01/1900")
                {
                    //cell.ForeColor = System.Drawing.Color.Red;
                   // e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                     e.Row.Cells[6].Text ="";
                    //e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;

                }
                
                
                


            }
        }
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindl3();
    }
}