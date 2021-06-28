using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class AdminSetParameters : System.Web.UI.Page
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

        adp = new SqlDataAdapter("select * from imgtable", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }

    void bindgrid2(int imgid)
    {
        adp = new SqlDataAdapter("Select * from imgptable where imgid=@imgid", con);
        adp.SelectCommand.Parameters.AddWithValue("imgid", imgid);
        dt = new DataTable();
        adp.Fill(dt);
        GridView2.Visible = true;
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try 
        {
            ViewState.Clear();
            int imgid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            GridView2.Visible = false;
            if (e.CommandName == "di")
            {
                cmd = new SqlCommand("delete from imgtable where imgid=@imgid", con);
                cmd.Parameters.AddWithValue("imgid", imgid);
                int no =cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (no != 0)
                {
                    cmd = new SqlCommand("delete from imgptable where imgid=@imgid", con);
                    cmd.Parameters.AddWithValue("imgid", imgid);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    bindgrid1();
                  

                }
            }
            else if (e.CommandName == "pp")
            {
                GridView2.Visible = true;
                ViewState.Add("ImgID", imgid);
                bindgrid2(imgid);
            }
            else if (e.CommandName == "cn")
            {
                Response.Redirect("AdminCreateNewParameter.aspx?ImgID=" + imgid);
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
            if (e.CommandName == "dp")
            {
                if (ViewState["ImgID"] != null)
                {
                    int imgid = int.Parse(ViewState["ImgID"].ToString());
                    int xpoint = int.Parse(GridView2.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                    int ypoint = int.Parse(GridView2.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);
                    string pname = GridView2.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text;

                    cmd = new SqlCommand("delete from imgptable where imgid=@imgid and xpoint=@xpoint and ypoint=@ypoint and pname=@pname", con);
                    cmd.Parameters.AddWithValue("imgid", imgid);
                    cmd.Parameters.AddWithValue("xpoint", xpoint);
                    cmd.Parameters.AddWithValue("ypoint", ypoint);
                    cmd.Parameters.AddWithValue("pname", pname);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    bindgrid2(imgid);

                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}