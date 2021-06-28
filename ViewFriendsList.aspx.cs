using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ViewFriendsList : System.Web.UI.Page
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
        
            adp = new SqlDataAdapter("select * from regtable where uname in (select uname2 from frtable where uname1=@uname1) ", con);
            adp.SelectCommand.Parameters.AddWithValue("uname1", Session["UserName"].ToString());
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


   
}