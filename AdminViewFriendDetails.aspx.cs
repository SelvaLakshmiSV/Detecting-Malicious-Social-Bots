using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AdminViewFriendDetails : System.Web.UI.Page
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
            {
                bindgrid1();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid1()
    {
        adp = new SqlDataAdapter("select * from regtable", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    void bindgrid2(string uname)
    {
        adp = new SqlDataAdapter("Select * from regtable where uname in (select uname2 from frtable where uname1=@uname1)", con);
        adp.SelectCommand.Parameters.AddWithValue("uname1", uname);
        dt = new DataTable();
        adp.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try 
        {
            if (e.CommandName == "vf")
            {
                if (ViewState["UName"] != null)
                    ViewState.Remove("UName");


                string uname = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();
                ViewState.Add("UName", uname);
                bindgrid2(uname);            

            
            
            }
         }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (ViewState ["UName"]!=null )
            {
            if (e.CommandName == "du")
            {
       
                string uname = GridView2.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();
                cmd = new SqlCommand("delete from frtable where (uname1=@uname1 and uname2=@uname2) or(uname1=@uname3 and uname2=@uname4)", con);
                cmd.Parameters.AddWithValue("uname1", ViewState["UName"].ToString());
                cmd.Parameters.AddWithValue("uname2", uname);
                cmd.Parameters.AddWithValue("uname3", uname);
                cmd.Parameters.AddWithValue("uname4", ViewState["UName"].ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                bindgrid2(ViewState ["UName"].ToString ());
            }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }
}