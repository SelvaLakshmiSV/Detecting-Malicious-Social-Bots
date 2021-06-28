using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;

public partial class ViewMessage : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataSet ds;
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
        if (Session["UserName"] != null)
        {
           
            adp = new SqlDataAdapter("select * from cmdtable where cmdto=@cmdto", con);
            adp.SelectCommand.Parameters.AddWithValue("cmdto", Session["UserName"].ToString());
            ds = new DataSet();
            adp.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
   
    void senddata()
    {
        try
        {
            TextBox tdata = (TextBox)GridView1.Rows[rindex].Cells[5].Controls[1];
            if (tdata.Text.Length != 0)
            {

                cmd = new SqlCommand("select isnull(max(cid),0)+1 from cmdtable ", con);
                int cid = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = new SqlCommand("insert into cmdtable values(@cid,@cmdfrom,@cmdto,@cmdinfo,@cmddate)", con);
                cmd.Parameters.AddWithValue("cid", cid);
                cmd.Parameters.AddWithValue("cmdfrom", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("cmdto", GridView1.Rows[rindex].Cells[0].Text);
                cmd.Parameters.AddWithValue("cmdinfo", tdata.Text);
                cmd.Parameters.AddWithValue("cmddate", DateTime.Now);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Label1.Text = "Successfully Send Your Message...";
                GridView1.Rows[rindex].Cells[5].Controls[1].Visible = false;

                GridView1.Rows[rindex].Cells[5].Controls[3].Visible = false;
                GridView1.Rows[rindex].Cells[5].Controls[5].Visible = false;

                bindgrid();


            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
   




    
    static int rindex = 0;
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
          

             if (e.CommandName == "dd")
            {

                int cid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                cmd = new SqlCommand("delete from cmdtable where cid=@cid", con);
                cmd.Parameters.AddWithValue("cid", cid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            
                bindgrid();
            }
            else if (e.CommandName == "rr")
            {
                rindex = int.Parse(e.CommandArgument.ToString());
                GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Controls[1].Visible = true;

                GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Controls[3].Visible = true;
                GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Controls[5].Visible = true;
            }


             else if (e.CommandName == "ss")
             {

               
                 senddata();


                


             }//check


             else if (e.CommandName == "cc")
             {

                
                 GridView1.Rows[rindex].Cells[5].Controls[1].Visible =false;

                 GridView1.Rows[rindex].Cells[5].Controls[3].Visible = false;
                 GridView1.Rows[rindex].Cells[5].Controls[5].Visible = false;

                 bindgrid();
             }



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

   
}