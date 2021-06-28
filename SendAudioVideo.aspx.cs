using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

public partial class SendAudioVideo : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
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
                if (Session["UserName"] != null)
                {
                    TextBox5.Text = Session["UserName"].ToString();
                    TextBox4.Text = DateTime.Now.ToString("dd-MMM-yyyy");

                    autopostid();
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void autopostid()
    {
        try
        {
            cmd = new SqlCommand("select isnull(max(pid),0)+1 from ptable", con);
            TextBox1.Text = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
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

            if (Request.QueryString.Get("AVType") != null)
            {
                string avtype = Request.QueryString.Get("AVType");
                string fname = FileUpload1.FileName;

                string ext = fname.Substring(fname.LastIndexOf(".")).ToLower();
                if (avtype.Equals("Audio"))
                {
                    if (!(ext.Equals(".mp3") || ext.Equals(".wav")))
                    {
                        Label1.Text = "Select mp3 Type Files.....";
                        return;
                    }
                }

                else if (avtype.Equals("Video"))
                {
                    if (!(ext.Equals(".mp4") || ext.Equals (".avi")))
                    {
                        Label1.Text = "Select mp4 or avi Type Files.....";
                        return;
                    }
                }
               

                fname = DateTime.Now.Ticks + "_" + fname;

                FileUpload1.PostedFile.SaveAs(Server.MapPath("PostData\\" + fname));

                cmd = new SqlCommand("select * from ptable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", TextBox1.Text);
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                    Label1.Text = "PostID Already Found......";
                    return;
                }

                if (avtype.Equals("Audio"))
                {

                    ArrayList p = new ArrayList();
                    p.Add(Session["UserName"].ToString());
                    p.Add("Audio" );
                    p.Add(TextBox1.Text);
                    p.Add(TextBox2.Text);
                    p.Add(fname );
                    p.Add(TextBox3.Text);
                    p.Add(TextBox4.Text);
                    Session.Add("PData1", p);
                    Response.Redirect("SelectClickStreamOption.aspx?PType=Audio");
                }

                else if (avtype.Equals("Video"))
                {

                    ArrayList p = new ArrayList();
                    p.Add(Session["UserName"].ToString());
                    p.Add("Video");
                    p.Add(TextBox1.Text);
                    p.Add(TextBox2.Text);
                    p.Add(fname);
                    p.Add(TextBox3.Text);
                    p.Add(TextBox4.Text);
                    Session.Add("PData2", p);
                    Response.Redirect("SelectClickStreamOption.aspx?PType=Video");
                }
            }



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

}