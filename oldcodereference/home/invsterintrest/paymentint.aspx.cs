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

public partial class invsterintrest_paymentint : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public static string mode,date5;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fetchinv();

            Panel7.Visible = false;

        }
    }
    public void fetchinv()
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select invid,ivname from newintinvester", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            GridView3.DataSource = ds;
            GridView3.DataBind();

        }
        catch (Exception t)
        {
            Label18.Text = "Due to error";
        }
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
        GridViewRow selectedRow = GridView3.Rows[Convert.ToInt32(e.CommandArgument)];
        string kid = selectedRow.Cells[0].Text;
        fetchdata(kid);
       
    
    }
    public void fetchdata(string kid)
    {
        invester(kid);
        
    }
    public void fetchinesterrecipt()
    {

        try
        {
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            int rcid = 0;
            SqlCommand cmd = new SqlCommand("select max(ID) from intinvesterrecipt", con1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    rcid = Convert.ToInt32(dr.GetValue(0));
                }
                rcid = rcid + 1;
                Label19.Text = "IV00" + rcid.ToString();

            }
            con1.Close();
        }
        catch (Exception t)
        {
            Label19.Text = "Due to error";
        }

    }
    static Double totalwallet = 0, usewallet = 0, balwallet = 0;
    String type="";
   static Double ktotal = 0, kpaid = 0, kbal = 0, btotal = 0, bpaid = 0, bbal = 0, unpaid = 0, retamt = 0;
    public void invester(string id)
    {
		date5=null;
        string kid = id;
        fetchinesterrecipt();
    
        
        invwallet(kid);
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select invid,ivname,totalinvestamt,returnamt,brokername,btotal,date from newintinvester where invid='" + kid + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        Label20.Text = ds.Tables[0].Rows[0][0].ToString();
        Label22.Text = ds.Tables[0].Rows[0][1].ToString();
        Label23.Text = ds.Tables[0].Rows[0][2].ToString();
        Label24.Text = ds.Tables[0].Rows[0][3].ToString();
        Label27.Text = ds.Tables[0].Rows[0][4].ToString();
        Label33.Text = ds.Tables[0].Rows[0][5].ToString();
		 date5 = ds.Tables[0].Rows[0][6].ToString();
        btotal = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());

        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount) from intinvesterrecipt where invid='" + kid + "' AND status='PAID' AND type='RECEIVE' AND bpaid=0  ", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            kpaid = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            kpaid = 0;
        }
        Label38.Text = kpaid.ToString();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(dramount) from intinvesterrecipt where invid='" + kid + "' AND status='PAID' AND  type='RETURN' AND bpaid=0 ", con);
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
        Label39.Text = retamt.ToString();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select sum(bpaid) from intinvesterrecipt where invid='" + kid + "' AND status='PAID' AND bpaid NOT IN(0) ", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        if (ds3.Tables[0].Rows[0][0].ToString() != "")
        {
            bpaid = Convert.ToDouble(ds3.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            bpaid = 0;
        }
        bbal = btotal - bpaid;
        Label34.Text = bpaid.ToString();
        Label35.Text = bbal.ToString();

    }
    public void invwallet(string kid)
    {
        usewallet = 0; totalwallet = 0; balwallet = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sum(usewalletamt),sum(totalamt) from invwallet where invid='" + kid + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                usewallet = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                usewallet = 0;
            }
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                totalwallet = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                totalwallet = 0;
            }
            balwallet = totalwallet - usewallet;
            Label40.Text = balwallet.ToString();
            Label41.Text ="0";

        }
    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
        mode = RadioButton5.Text;
        Panel7.Visible = false;

    }
    protected void RadioButton6_CheckedChanged(object sender, EventArgs e)
    {

        mode = RadioButton6.Text;
        Panel7.Visible = true;
    }
    String chkdate, chknn, refno, status;
    protected void Button3_Click(object sender, EventArgs e)
    {
       
    }
   static Double totalbalamt = 0,paidamount=0,balwalletafetrpaid=0,usewalletafterpay=0,totalpayamt=0;
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList4.Text == "RECEIVE")
        {
            
            type=DropDownList4.Text;
            balwallet = balwallet;
            Label41.Text ="0";
            
            Label40.Text = balwallet.ToString();
        }
          if (DropDownList4.Text == "RETURN")
            {
                Double balval = 0;
               type=DropDownList4.Text;
               if (balwallet != 0)
               {
                   if (Convert.ToDouble(TextBox16.Text) <= balwallet)
                   {
                       paidamount = Convert.ToDouble(TextBox16.Text);
                       balwalletafetrpaid = balwallet - paidamount;
                       usewalletafterpay = paidamount;
                       Label41.Text = paidamount.ToString();
                       totalpayamt = 0;
                       Label40.Text = balwalletafetrpaid.ToString();

                   }
                   else
                   {
                       balval = Convert.ToDouble(TextBox16.Text) - balwallet;
                       paidamount = balwallet;
                       balwalletafetrpaid = paidamount - balwallet;
                       usewalletafterpay = paidamount;
                       Label41.Text = paidamount.ToString();
                       totalpayamt = balval;
                       Label40.Text = balwalletafetrpaid.ToString();
                   }
               }
               else
               {
                   balval = Convert.ToDouble(TextBox16.Text) - balwallet;
                   paidamount = balwallet;
                   balwalletafetrpaid =0;
                   usewalletafterpay =0;
                   Label41.Text = paidamount.ToString();
                   totalpayamt = balval;
                   Label40.Text = balwalletafetrpaid.ToString();
               }
              

            }
            
        
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        string s2 = TextBox15.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
		 string date1 ="";
		 String dy = Convert.ToDateTime(date5).ToString("dd/MM/yyyy");
		 
                    string ddy = dy.Substring(0, 2);
                    string mmy = dy.Substring(3, 2);
                    string yyy = dy.Substring(6, 4);
		if(Convert.ToInt32(dd)==Convert.ToInt32(ddy))
		{
			date1= mm + "/" + (Convert.ToInt32(dd)-1).ToString() + "/" + yy;
		}
		else
		
		{
			date1= mm + "/" +dd+ "/" + yy;
		}
       
        if (DropDownList4.Text == "RECEIVE")
        {
            if (mode == "CASH")
            {
                chkdate = null;
                chknn = null;
                refno = null;
                status = "PAID";
                mode = "CASH";
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into intinvesterrecipt(invrecipt,invid,name,totalinvamt,totalreturn,date,amount,type,paymode,chekdate, chkno,refby,status,reason,bname,btotal,bpaid,breason,unpamt,wallet,dramount )values('" + Label19.Text + "','" + Label20.Text + "','" + Label22.Text + "'," + Label23.Text + "," + Label24.Text + ",'" + date1 + "'," + TextBox16.Text + ",'" + DropDownList4.Text + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "','" + TextBox20.Text + "','" + Label27.Text + "'," + Label33.Text + "," + TextBox21.Text + ",'" + TextBox22.Text + "',0,0,0)", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    Label36.Text = "Record Added";
                }
                else
                {
                    Label36.Text = "Error";
                }

            }
            if (mode == "CHEQUE")
            {
                string s3 = TextBox17.Text;
                string dd1 = s3.Substring(0, 2);
                string mm1 = s3.Substring(3, 2);
                string yy1 = s3.Substring(6, 4);
                string ck = mm1 + "/" + dd1 + "/" + yy1;
                chkdate = ck;
                chknn = TextBox18.Text;
                refno = TextBox19.Text;
                mode = "CHEQUE";
                status = DropDownList3.Text;
                if (status == "PAID")
                {
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into intinvesterrecipt(invrecipt,invid,name,totalinvamt,totalreturn,date,amount,type,paymode,chekdate, chkno,refby,status,reason,bname,btotal,bpaid,breason,unpamt,wallet,dramount )values('" + Label19.Text + "','" + Label20.Text + "','" + Label22.Text + "'," + Label23.Text + "," + Label24.Text + ",'" + date1 + "'," + TextBox16.Text + ",'" + DropDownList4.Text + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "','" + TextBox20.Text + "','" + Label27.Text + "'," + Label33.Text + "," + TextBox21.Text + ",'" + TextBox22.Text + "',0,0,0)", con);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                        Label36.Text = "Record Added";
                    }
                    else
                    {
                        Label36.Text = "Error";
                    }
                }
                if (status == "UNPAID")
                {
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into intinvesterrecipt(invrecipt,invid,name,totalinvamt,totalreturn,date,amount,type,paymode,chekdate, chkno,refby,status,reason,bname,btotal,bpaid,breason,unpamt,wallet,dramount )values('" + Label19.Text + "','" + Label20.Text + "','" + Label22.Text + "'," + Label23.Text + "," + Label24.Text + ",'" + date1 + "',0,'" + DropDownList4.Text + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "','" + TextBox20.Text + "','" + Label27.Text + "'," + Label33.Text + "," + TextBox21.Text + ",'" + TextBox22.Text + "'," + TextBox16.Text + ",0,0)", con);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                        Label36.Text = "Record Added";
                    }
                    else
                    {
                        Label36.Text = "Error";
                    }
                }


            }
        }
        else
        {
            if (mode == "CASH")
            {
                chkdate = null;
                chknn = null;
                refno = null;
                status = "PAID";
                mode = "CASH";
                SqlConnection con = new SqlConnection(s);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into intinvesterrecipt(invrecipt,invid,name,totalinvamt,totalreturn,date,dramount,type,paymode,chekdate, chkno,refby,status,reason,bname,btotal,bpaid,breason,unpamt,wallet,amount )values('" + Label19.Text + "','" + Label20.Text + "','" + Label22.Text + "'," + Label23.Text + "," + Label24.Text + ",'" + date1 + "'," + totalpayamt + ",'" + DropDownList4.Text + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "','" + TextBox20.Text + "','" + Label27.Text + "'," + Label33.Text + "," + TextBox21.Text + ",'" + TextBox22.Text + "',0,"+paidamount+",0)", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                   
                    int j=0;
                    if (paidamount != 0)
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into invwallet(invid,date,totalamt,usewalletamt)values('" + Label20.Text + "','" + date1 + "',0," + paidamount + ")", con);
                        con.Open();
                        j = cmd1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (j != 0 || i!=0)
                    {
                        Label36.Text = "Record Added";
                    }
                    else
                    {
                        Label36.Text = "wallet Error";
                    }
                   
                }
                else
                {
                    Label36.Text = "Error";
                }

            }
            if (mode == "CHEQUE")
            {
                string s3 = TextBox17.Text;
                string dd1 = s3.Substring(0, 2);
                string mm1 = s3.Substring(3, 2);
                string yy1 = s3.Substring(6, 4);
                string ck = mm1 + "/" + dd1 + "/" + yy1;
                chkdate = ck;
                chknn = TextBox18.Text;
                refno = TextBox19.Text;
                mode = "CHEQUE";
                status = DropDownList3.Text;
                if (status == "PAID")
                {
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into intinvesterrecipt(invrecipt,invid,name,totalinvamt,totalreturn,date,dramount,type,paymode,chekdate, chkno,refby,status,reason,bname,btotal,bpaid,breason,unpamt,wallet,amount )values('" + Label19.Text + "','" + Label20.Text + "','" + Label22.Text + "'," + Label23.Text + "," + Label24.Text + ",'" + date1 + "'," + totalpayamt+ ",'" + DropDownList4.Text + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "','" + TextBox20.Text + "','" + Label27.Text + "'," + Label33.Text + "," + TextBox21.Text + ",'" + TextBox22.Text + "',0,"+paidamount+",0)", con);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                         int j=0;
                    if (paidamount != 0)
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into invwallet(invid,date,totalamt,usewalletamt)values('" + Label20.Text + "','" + date1 + "',0," + paidamount + ")", con);
                        con.Open();
                        j = cmd1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (j != 0 || i!=0)
                    {
                        Label36.Text = "Record Added";
                    }
                    else
                    {
                        Label36.Text = "wallet Error";
                    }
                    }
                    else
                    {
                        Label36.Text = "Error";
                    }
                }
                if (status == "UNPAID")
                {
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into intinvesterrecipt(invrecipt,invid,name,totalinvamt,totalreturn,date,dramount,type,paymode,chekdate, chkno,refby,status,reason,bname,btotal,bpaid,breason,unpamt,wallet,amount )values('" + Label19.Text + "','" + Label20.Text + "','" + Label22.Text + "'," + Label23.Text + "," + Label24.Text + ",'" + date1 + "',0,'" + DropDownList4.Text + "','" + mode + "','" + chkdate + "','" + chknn + "','" + refno + "','" + status + "','" + TextBox20.Text + "','" + Label27.Text + "'," + Label33.Text + "," + TextBox21.Text + ",'" + TextBox22.Text + "'," + TextBox16.Text + ",0,0)", con);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                        Label36.Text = "Record Added";
                    }
                    else
                    {
                        Label36.Text = "Error";
                    }
                }


            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        String id = Label20.Text;
        totalbalamt = 0; paidamount = 0; balwalletafetrpaid = 0; usewalletafterpay = 0; totalpayamt = 0;
        invester(id);
        Label36.Text = "";
    }
}