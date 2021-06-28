using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class SendMessage1 : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    
    SqlDataAdapter adp;
    DataSet ds;

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
                if (Session["UserName"] != null)
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
            adp = new SqlDataAdapter("select * from frtable where uname1=@uname1", con);
            adp.SelectCommand.Parameters.AddWithValue("uname1", Session["UserName"].ToString());
            ds = new DataSet();
            adp.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
   

    static int rindex = 0;

    void senddata()
    {
        try
        {
            TextBox tdata = (TextBox)GridView1.Rows[rindex].Cells[2].Controls[1];
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
                GridView1.Rows[rindex].Cells[2].Controls[1].Visible = false;

                GridView1.Rows[rindex].Cells[2].Controls[3].Visible = false;
                GridView1.Rows[rindex].Cells[2].Controls[5].Visible = false;

                bindgrid();
                Label1.Text = "Successfully Send Your Message...";

            }
            else
            {

                GridView1.Rows[rindex].Cells[2].Controls[1].Visible = false;

                GridView1.Rows[rindex].Cells[2].Controls[3].Visible = false;
                GridView1.Rows[rindex].Cells[2].Controls[5].Visible = false;

                bindgrid();
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

  





    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cc")
            {
                rindex = int.Parse(e.CommandArgument.ToString());
                GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Controls[1].Visible = true;

                GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Controls[3].Visible = true;

                GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Controls[5].Visible = true;
                //  bindgrid();

            }

            else if (e.CommandName == "ss")
            {
                senddata();               
            }
            else if (e.CommandName == "cc1")
            {
                GridView1.Rows[rindex].Cells[2].Controls[1].Visible = false;
                GridView1.Rows[rindex].Cells[2].Controls[3].Visible = false;
                GridView1.Rows[rindex].Cells[2].Controls[5].Visible = false;
                bindgrid();
            }
        }
        catch (Exception ex)
        {

            Label1.Text = ex.Message;
        }

    }
    

}