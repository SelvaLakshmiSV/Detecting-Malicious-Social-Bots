using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class UserViewProfile : System.Web.UI.Page
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
                 
                    bindview();
                }

            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void bindview()
    {
        try
        {
            adp = new SqlDataAdapter("select * from regtable where uname=@uname", con);
            adp.SelectCommand.Parameters.AddWithValue("uname", Session["UserName"].ToString());
            dt = new DataTable();
            adp.Fill(dt);
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditProfile.aspx");
    }
}