using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class DeleteAllRecords : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
           
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
            try 
            {
                cmd = new SqlCommand("delete from cmdtable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from frtable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from gmtable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from gtable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from imgptable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from imgtable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from mtable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from pctable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from pltable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from ptable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from regtable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from reqtable", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                Label1.Text = "All Table Records are Deleted.....";

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }

    }
}