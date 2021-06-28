using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class ViewPost1 : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter adp;
    DataTable dt;
    SqlDataReader rs;

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
                if (Request.QueryString.Get("PID") != null && Request .QueryString .Get ("PType")!=null  && Session ["UserName"]!=null)
                {
                    TextBox1.Text = Session["UserName"].ToString();
                    string ptype = Request.QueryString.Get("PType");
                    if (ptype.Equals("Message"))
                        MultiView1.ActiveViewIndex = -1;
                    else if (ptype.Equals("Image"))
                        MultiView1.ActiveViewIndex = 0;
                    else if (ptype.Equals("Video"))
                        MultiView1.ActiveViewIndex = 1;
                    else if (ptype.Equals("Audio"))
                        MultiView1.ActiveViewIndex = 2;

                    bindview();
                    showimage();
                    showparameter();

                    cmd = new SqlCommand("select * from pltable where uname=@uname and pid=@pid", con);
                    cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                    cmd.Parameters.AddWithValue("pid", Request.QueryString.Get("PID"));
                    rs = cmd.ExecuteReader();
                    string poption = "";
                    if (rs.Read())
                    {
                        poption = rs["poption"].ToString();
                        rs.Close();
                        cmd.Dispose();
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        LinkButton1.Text = "Like";
                        return;
                    }
                    if (poption.Equals("Like"))
                        LinkButton1.Text = "Dislike";
                    else if (poption.Equals("Dislike"))
                        LinkButton1.Text = "Like";

                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected string vpath = "";
    protected string apath = "";
    void bindview()
    {
        try
        {
            string pid = Request.QueryString.Get("PID");
            adp = new SqlDataAdapter("select * from ptable where pid=@pid ", con);
            adp.SelectCommand.Parameters.AddWithValue("pid", pid);
            dt = new DataTable();
            adp.Fill(dt);
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
            string ptype = Request.QueryString.Get("PType");
            if (ptype.Equals("Image"))
                Image1.ImageUrl = Server.MapPath("PostData\\" + dt.Rows[0]["pimage"].ToString());
            else if (ptype.Equals("Video"))
                vpath = Server.MapPath("PostData\\" + dt.Rows[0]["pimage"].ToString());
            else if (ptype.Equals("Audio"))
                apath = Server.MapPath("PostData\\" + dt.Rows[0]["pimage"].ToString());
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }


    void showimage()
    {
        if (ViewState["ImageID"] != null)
            ViewState.Remove("ImageID");
  

        adp = new SqlDataAdapter("select * from imgtable ", con);
        dt = new DataTable();
        adp.Fill(dt);
        Random r = new Random();
        int no = r.Next(dt.Rows.Count);
        ViewState.Add("ImageID", dt.Rows[no]["imgid"].ToString());
        ImageButton1.ImageUrl = Server.MapPath("CImage\\" + dt.Rows[no]["imgpath"].ToString());

    }

    void showparameter()
    {

        if (ViewState["ImageID"] != null)
        {
            if (ViewState["XPoint"] != null)
            {
                ViewState.Remove("XPoint");
            }
            if (ViewState["YPoint"] != null)
            {
                ViewState.Remove("YPoint");
            }

            adp = new SqlDataAdapter("select * from imgptable where imgid=@imgid", con);
            adp.SelectCommand.Parameters.AddWithValue("imgid", ViewState["ImageID"].ToString());
            dt = new DataTable();
            adp.Fill(dt);
            Random r = new Random();
            int n = r.Next(dt.Rows.Count);

            int xpoint = int.Parse(dt.Rows[n]["xpoint"].ToString());
            int ypoint = int.Parse(dt.Rows[n]["ypoint"].ToString());
            ViewState.Add("XPoint", xpoint);
            ViewState.Add("YPoint", ypoint);
            string pname = dt.Rows[n]["pname"].ToString();
            Label1.Text = "Click Stream is :" + pname;
        }
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            
            if (ViewState["XPoint"] != null && ViewState["YPoint"] != null)
            {
                int xpos = e.X;
                int ypos = e.Y;

                int xpoint = int.Parse(ViewState["XPoint"].ToString());
                int ypoint = int.Parse(ViewState["YPoint"].ToString());
                int x1 = xpoint + 10;
                int x2 = xpoint - 10;
                int y1 = ypoint + 10;
                int y2 = ypoint - 10;

                if ((xpos <= x1 && xpos >= x2) && (ypos <= y1 && ypos >= y2))
                {
                    ViewState.Add("UserType", "User");
                }
                else
                {
                    ViewState.Add("UserType", "Bot");
                }
            }
            else
            {
                Label1.Text = "Some Problem is Occured.So Not Verify Your Data......";

            }
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
            if (ViewState["UserType"] != null)
            {
                string data = LinkButton1.Text;
                cmd = new SqlCommand("delete from pltable where uname=@uname", con);
                cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = new SqlCommand("insert into pltable values (@uname,@pid,@poption,@utype)", con);
                cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                cmd.Parameters.AddWithValue("pid", Request.QueryString.Get("PID"));
                cmd.Parameters.AddWithValue("poption", LinkButton1.Text);
                cmd.Parameters.AddWithValue("utype", ViewState["UserType"].ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                if (data.Equals("Like"))
                {
                    LinkButton1.Text = "Dislike";
                }
                else if (data.Equals("Dislike"))
                {
                    LinkButton1.Text = "Like";
                }
            }

            

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }


    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Get("PID") != null && ViewState["UserType"]!=null )
       {
           int pid =int.Parse (Request .QueryString .Get ("PID"));
           string utype = ViewState["UserType"].ToString();
           Response.Redirect("SendComment.aspx?PID=" + pid+"&UType="+ utype );
       }
    }
}