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
using System.Globalization;


public partial class chequesms : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
			if(Session["ID"] != null)
			{
				Label4889.Text ="heedrealestate";
			   //Label13.Text = "heedrealestate";
			}
			else
				
			{
				Response.Redirect("~/home/usercredential/credential.aspx");
			}
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
           
            Button9.Visible = false;
            Label4889.Visible = false;
        }
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
    }
   
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Button9.Visible = false;
        Label4889.Visible = false;
        
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select LEFT(NAMEDOBADDRESS,15) AS 'NAME',plotno AS 'PLOT NO',PLOTSIZE,APPNO,lockreg from wjstar1.customerreg1 WHERE CUSTREGNO='" + TextBox1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count==0)
        {
            Label10.Text = "RECORD DOES NOT FOUNT";
        }
        else
        {
            Label1.Text = ds.Tables[0].Rows[0][0].ToString();
            Label2.Text = ds.Tables[0].Rows[0][1].ToString();
            Label3.Text = ds.Tables[0].Rows[0][2].ToString();
            Label4891.Text = ds.Tables[0].Rows[0][3].ToString();
           
            if (ds.Tables[0].Rows[0][4].ToString() == "UNLOCK")
            {
                Button7.Visible = true;
                Label4892.Text = "";
                binddatafun2();
            }
            else
            {
                Button7.Visible = false;
                Label4890.Text = "";
                Label10.Text = "";
                Label4892.Text = "Permission Not Allowed For ADD Record.Please Unlock REG.NO.";
            }

        }

    }
    public void binddatafun2()
    {
        Panel3.Visible = false;
        Panel2.Visible = false;
        Panel1.Visible = true;
        SqlConnection con = new SqlConnection(s);
        
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT ID,CDATE,CHEQUENO,CAMOUNT,CHEQUETYPE,STATUS,paiddate,deletevalue,BSTATUS,BDATE from chequedetails WHERE CUSTREGNO='" + TextBox1.Text + "' ORDER BY CDATE ASC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT sum(CAMOUNT) from chequedetails WHERE CUSTREGNO='" + TextBox1.Text + "' AND ID NOT IN(select ID from chequedetails WHERE CUSTREGNO='" + TextBox1.Text + "' AND deletevalue='DEL')", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        if (ds1.Tables[0].Rows.Count == 0)
        {
            Label10.Text = "RECORD DOES NOT FOUNT";
        }
        else
        {
            Label9.Text = "";
           /* Label5.Text = ds.Tables[0].Rows[0][1].ToString();
            Label6.Text = ds.Tables[0].Rows[0][0].ToString();
            Label7.Text = ds.Tables[0].Rows[0][2].ToString();
            Label8.Text = ds.Tables[0].Rows[0][3].ToString();*/
            GridView2.DataSource = ds1;
            GridView2.DataBind();
            Label4890.Text = "Amount = " + ds2.Tables[0].Rows[0][0].ToString();

        }
    }
    
    protected void Button5_Click(object sender, EventArgs e)
    {
        int i = 0;
        string dateString = TextBox2.Text;
        string format = "dd/mm/yyyy";
        DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        string strdate = dateTime.ToString("mm/dd/yyyy");
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into chequedetails(ARAZI,CUSTREGNO,NAME,PLOTNO,PLOTSIZE,CDATE,CHEQUENO,CAMOUNT,STATUS,CHEQUETYPE)values('"+Label4891.Text+"','"+TextBox1.Text+"','"+Label1.Text+"','"+Label2.Text+"','"+Label3.Text+"','"+strdate+"',"+TextBox3.Text+","+TextBox4.Text+",'"+TextBox5.Text+"','"+DropDownList2.Text+"')",con);
        i=cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label10.Text = "RECORD ADDED SUCCESSFULLY";
           // TextBox3.Text = "";
           // TextBox4.Text = "";
            binddatafun2();
        }
        else
        {
            Label10.Text = "ERROR";
        }
        
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
         binddatafun();
    }
    public void binddatafun()
{

 Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da9 = new SqlDataAdapter("select lockreg from wjstar1.customerreg1 WHERE CUSTREGNO='" + TextBox6.Text + "' ", con);
        DataSet ds9 = new DataSet();
        da9.Fill(ds9);
        con.Close();
        if (ds9.Tables[0].Rows.Count != 0)
        {
            if (ds9.Tables[0].Rows[0][0].ToString() == "UNLOCK")
            {
                Button11.BackColor = System.Drawing.Color.Green;
                Button10.BackColor = System.Drawing.Color.WhiteSmoke;
            }
            else
            {
                Button10.BackColor = System.Drawing.Color.Red;
                Button11.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SELECT ARAZI,NAME,PLOTNO,PLOTSIZE from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT ID,CDATE,CHEQUENO,CAMOUNT,CHEQUETYPE,STATUS,paiddate,deletevalue,BSTATUS,BDATE,finalstatus from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "' ORDER BY CDATE ASC", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT sum(CAMOUNT) from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "' AND ID NOT IN(select ID from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "' AND deletevalue='DEL')", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT sum(CAMOUNT) from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "'AND CHEQUETYPE='MENTION' AND ID NOT IN(select ID from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "' AND deletevalue='DEL')", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
       
        con.Open();
        SqlDataAdapter da4 = new SqlDataAdapter("SELECT sum(CAMOUNT) from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "'AND CHEQUETYPE='OTHER' AND ID NOT IN(select ID from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "' AND deletevalue='DEL')", con);
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
        con.Close();
        if (ds.Tables[0].Rows.Count == 0 || ds1.Tables[0].Rows.Count == 0)
        {
            Label4889.Visible = true;
            Label4889.Text = "RECORD DOES NOT FOUNT";
            GridView1.DataSource = null;
            GridView1.DataBind();
			Label9.Text = "0";
			Label4893.Text = "0";
			Label4894.Text = "0";
			Label5.Text =null;
            Label6.Text = null;
            Label7.Text =null;
            Label8.Text =null;
        }
        else
        {
            Label4889.Text = "";
            Label9.Text = "";
            Label5.Text = ds.Tables[0].Rows[0][1].ToString();
            Label6.Text = ds.Tables[0].Rows[0][0].ToString();
            Label7.Text = ds.Tables[0].Rows[0][2].ToString();
            Label8.Text = ds.Tables[0].Rows[0][3].ToString();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            Label9.Text = "Amount = " + ds2.Tables[0].Rows[0][0].ToString();
            if (ds3.Tables[0].Rows[0][0].ToString() != "")
            {
                Label4893.Text = ds3.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label4893.Text ="0";
        }
            if (ds4.Tables[0].Rows[0][0].ToString() != "")
            {
                Label4894.Text = ds4.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label4894.Text = "0";
            }


        }
}

    public void refreshdata()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID,CHEQUENO,CAMOUNT,CHEQUETYPE,STATUS,paiddate from chequedetails WHERE CUSTREGNO='" + TextBox7.Text + "' ORDER BY CDATE ASC", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView3.DataSource = dt;
        GridView3.DataBind();
        con.Close();

    } 
    protected void Button8_Click(object sender, EventArgs e)
    {
        Label14.Text = "";
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SELECT ARAZI,NAME,PLOTNO,PLOTSIZE from chequedetails WHERE CUSTREGNO='" + TextBox7.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        
      
        if (ds.Tables[0].Rows.Count == 0 )
        {
            Label14.Text = "RECORD DOES NOT FOUNT";
        }
        else
        {
            Label9.Text = "";
            Label4.Text = ds.Tables[0].Rows[0][1].ToString();
            Label13.Text = ds.Tables[0].Rows[0][0].ToString();
            Label11.Text = ds.Tables[0].Rows[0][2].ToString();
            Label12.Text = ds.Tables[0].Rows[0][3].ToString();
            refreshdata();
           

        }
    }
    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView3.EditIndex = -1;
        refreshdata();  
    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        
        int id = Convert.ToInt16(GridView3.DataKeys[e.RowIndex].Values["ID"].ToString());
        SqlCommand cmd = new SqlCommand("delete from chequedetails where ID=" + id + "", con);
        
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        refreshdata(); 
    }
    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        refreshdata();
    }
    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
      
        int id = Convert.ToInt16(GridView3.DataKeys[e.RowIndex].Values["ID"].ToString());

        DropDownList status = GridView3.Rows[e.RowIndex].FindControl("STATUS") as DropDownList;
        DropDownList type2 = GridView3.Rows[e.RowIndex].FindControl("CHEQUETYPE") as DropDownList;
        TextBox paid = GridView3.Rows[e.RowIndex].FindControl("CPAID") as TextBox;
        String date = paid.Text;
        string s2 = date;
        string date1;
        if (s2 != "")
        {
            string yy = s2.Substring(0, 4);
            string mm = s2.Substring(5, 2);
            string dd = s2.Substring(8, 2);
            date1 = mm + "/" + dd + "/" + yy;
        }
        else
        {
            date1 = null;
        }
		if(status.Text=="PAID")
		{

       SqlCommand cmd = new SqlCommand("update chequedetails set BSTATUS=null,BDATE=null,CHEQUETYPE='" + type2.Text + "',STATUS='" + status.Text + "',paiddate='"+date1+"' where ID=" + id + "", con);
        con.Open();
       cmd.ExecuteNonQuery();
        con.Close();
		}
		else
		{
			SqlCommand cmd = new SqlCommand("update chequedetails set CHEQUETYPE='" + type2.Text + "',STATUS='" + status.Text + "',paiddate=null where ID=" + id + "", con);
        con.Open();
       cmd.ExecuteNonQuery();
        con.Close();
			
		}
      
        GridView3.EditIndex = -1;  
        refreshdata();  
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Button9.Visible = true;
        Label4889.Visible = true;
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT sum(CAMOUNT) from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "' AND CHEQUETYPE='MENTION'  AND ID NOT IN(select ID from chequedetails WHERE CUSTREGNO='" + TextBox6.Text + "' AND deletevalue='DEL')", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        Double amount9 = 0;
        if (ds2.Tables[0].Rows[0][0].ToString() != "")
        {
            amount9 = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("update customerreg2 set CONSAMOUNT="+amount9+" WHERE CUSTREGNO='" + TextBox6.Text + "' ", con);
            int i=cmd.ExecuteNonQuery();       
            con.Close();
            if (i != 0)
            {

                Label4889.Text = "RECORD UPDATED";
            }
            else
            {

                Label4889.Text = "RECORD NOT UPDATED";
            }
        }
        else
        {
            Label4889.Text = "RECORD NOT UPDATED";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            // {
            string StatusValue = (e.Row.FindControl("id128") as Label).Text;
      //  e.Row.Cells[1].Text;    string f = 

            if (StatusValue == "DEL")
            {
               
              

               // ((Image)e.Row.FindControl("imgActive")).Visible = true;
                ((Image)e.Row.FindControl("imgActive")).ImageUrl = "delete.png";

            }
            else
            {
                ((Image)e.Row.FindControl("imgActive")).Visible = false;
            }


            

            // }
        }
    }
    protected void check(object sender, EventArgs e)
{
    Label4889.Text = "";
    SqlConnection con = new SqlConnection(s);

    foreach (GridViewRow row in GridView2.Rows)
    {
        Label status = row.FindControl("id1279") as Label;
        String st = status.Text;
        CheckBox chkRow = (row.Cells[8].FindControl("chkSelect1") as CheckBox);
        if (chkRow.Checked)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update chequedetails set deletevalue='DEL'  WHERE CUSTREGNO='" + TextBox1.Text + "' AND ID=" + st + "", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            
        }
        else
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update chequedetails set deletevalue=NULL  WHERE CUSTREGNO='" + TextBox1.Text + "' AND ID=" + st + "", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
    binddatafun2();
}

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            // {
            string StatusValue = (e.Row.FindControl("id1286") as Label).Text;
            //  e.Row.Cells[1].Text;    string f = 

            if (StatusValue == "DEL")
            {
                ((CheckBox)e.Row.FindControl("chkSelect1")).Checked = true;


                // ((Image)e.Row.FindControl("imgActive")).Visible = true;
                ((Image)e.Row.FindControl("imgActive0")).ImageUrl = "delete.png";

            }
            else
            {
                ((Image)e.Row.FindControl("imgActive0")).Visible = false;
            }
        }
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("update wjstar1.customerreg1 set lockreg='LOCK'  WHERE CUSTREGNO='" + TextBox6.Text + "'", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        binddatafun();

    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("update wjstar1.customerreg1 set lockreg='UNLOCK'  WHERE CUSTREGNO='" + TextBox6.Text + "'", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        binddatafun();
    }
}