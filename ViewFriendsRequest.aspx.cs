using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ViewFriendsRequest : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt ;
    SqlCommand cmd;
     protected void Page_Load(object sender, EventArgs e)
    {
         try 
         {
 
            Label1.Text = "";
            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["UserName"] != null )
                {
                    TextBox1.Text = Session["UserName"].ToString();
                         bindgrid();
                }

            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void bindgrid()
    {
        try
        {
            adp = new SqlDataAdapter("select rfrom ,pimage,id  from reqtable r1,regtable r2 where  r1.rfrom=r2.uname and rto=@rto and r1.status='request'", con);
            adp.SelectCommand.Parameters.AddWithValue("rto", Session["UserName"].ToString());
            dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgrid();
    }

   
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
          

           if (e.CommandName == "aa")
            {

                int id = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());

                cmd = new SqlCommand("update reqtable set status='Accept' where id=@id", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("insert into frtable values (@uname1,@uname2)", con);
                cmd.Parameters.AddWithValue("uname1", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("uname2", GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = new SqlCommand("insert into frtable values (@uname1,@uname2)", con);
                cmd.Parameters.AddWithValue("uname1", GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);
                cmd.Parameters.AddWithValue("uname2", Session["UserName"].ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid();
            }
            else if (e.CommandName == "rr")
            {
                int id = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());

                cmd = new SqlCommand("update reqtable set status='Reject' where id=@id", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid();
            }

         
          
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

  
}