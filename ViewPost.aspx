<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPost.aspx.cs" Inherits="ViewPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
        <tr>
            <th>
               
                <h1 style ="text-align :center ;">
                    Post Details</h1>
              
            </th>
        </tr>
        <tr>
            <td>
                    <center><asp:GridView ID="GridView1" runat="server" 
                        AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                        ForeColor="Black" 
                        PageSize="3" Width="702px" onrowcommand="GridView1_RowCommand">
                        <Columns>
                       
                            <asp:BoundField DataField ="pid" HeaderText ="ID" />
                            <asp:BoundField DataField ="pname" HeaderText ="Post Name" />
                           <asp:BoundField DataField ="ptype" HeaderText ="Type" />
                            <asp:HyperLinkField Text ="View Details" HeaderText ="View Post" DataNavigateUrlFields ="pid,ptype" DataNavigateUrlFormatString ="ViewPost1.aspx?PID={0}&PType={1}"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
                            <asp:ButtonField Text ="View" HeaderText ="View Comment" CommandName ="vc"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
                       
                         
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView></center>
            </td>
        </tr>
        <tr>
            <td style="text-align :center ;" class="style1" >
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

