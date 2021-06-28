﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ViewGroupMessage : System.Web.UI.Page
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
                if (Session["UserName"] != null  )
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

            adp = new SqlDataAdapter("select * from mtable where gname in (select distinct(gname) from gmtable where uname=@uname)", con);
            adp.SelectCommand.Parameters.AddWithValue("uname", Session["UserName"].ToString());
            ds = new DataSet();
            adp.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }

    void checkdata()
    {
        try
        {
            TextBox tdata = (TextBox)GridView1.Rows[rindex].Cells[5].Controls[1];


            cmd = new SqlCommand("select isnull(max(mid),0)+1 from mtable ", con);
            int mid = int.Parse(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            cmd = new SqlCommand("insert into mtable values(@mid,@gname,@uname,@msginfo,@msgdate)", con);
            cmd.Parameters.AddWithValue("mid", mid);
            cmd.Parameters.AddWithValue("gname", GridView1.Rows[rindex].Cells[0].Text);
            
            cmd.Parameters.AddWithValue("uname", Session["UserName"].ToString());

            cmd.Parameters.AddWithValue("msginfo", tdata.Text);
            cmd.Parameters.AddWithValue("msgdate", DateTime.Now.ToString ("dd-MMM-yyyy hh:mm:ss tt"));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Successfully Send Your Message...";
            bindgrid();

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


          if (e.CommandName == "rr")
            {
                rindex = int.Parse(e.CommandArgument.ToString());

                string uname = GridView1.Rows[rindex].Cells[1].Text;
                if (Session["UserName"].ToString().Equals(uname))
                {
                    Label1.Text = "Owner of the Message.Can't Send Reply Message.....";
                    return;
                }



                GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Controls[1].Visible = true;

                GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Controls[3].Visible = true;
                GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Controls[5].Visible = true;
            }


            else if (e.CommandName == "ss")
            {
                checkdata();
            }


            else if (e.CommandName == "cc")
            {


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


}