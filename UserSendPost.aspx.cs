using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UserSendPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    TextBox1.Text = Session["UserName"].ToString();
                }
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
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Option......";
                return;
            }

            if (DropDownList1.SelectedIndex == 1)
            {
                Response.Redirect("SendMessage.aspx");
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                Response.Redirect("SendImage.aspx");
            }
            else if (DropDownList1.SelectedIndex == 3)
            {
                Response.Redirect("SendAudioVideo.aspx?AVType=Audio");
            }
            else if (DropDownList1.SelectedIndex == 4)
            {
                Response.Redirect("SendAudioVideo.aspx?AVType=Video");
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}