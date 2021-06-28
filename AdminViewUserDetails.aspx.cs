using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AdminViewUserDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter adp;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
                bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid()
    {
        adp = new SqlDataAdapter("Select * from regtable", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "dd")
            {

                string uname = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();

                cmd = new SqlCommand("delete from regtable where uname=@uname", con);
                cmd.Parameters.AddWithValue("uname", uname);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid();
               
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message ; 
        }
    }
}