using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ViewPost : System.Web.UI.Page
{
    SqlConnection con;
    
    SqlDataAdapter adp;
    DataTable dt;

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
        try
        {
            adp = new SqlDataAdapter("select * from ptable where uname<>@uname and uname in (select uname1 from frtable where uname2=@uname2)  and utype='User'", con);
           
            adp.SelectCommand.Parameters.AddWithValue("uname", Session["UserName"].ToString());
            adp.SelectCommand.Parameters.AddWithValue("uname2", Session["UserName"].ToString());
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try 
        {
            if (e.CommandName == "vc")
            {
                int pid =int.Parse(GridView1 .Rows [int.Parse (e.CommandArgument .ToString ())].Cells [0].Text) ;
                Response .Redirect ("ViewPostComment.aspx?PID="+pid );

            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}