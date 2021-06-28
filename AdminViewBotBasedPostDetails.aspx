<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewBotBasedPostDetails.aspx.cs" Inherits="AdminViewBotBasedPostDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border ="1" align="center" width ="70%">
        <tr>
            <th>
                <h1>
                    Bot Based Post Details</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :center ;">
                <center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
                        EmptyDataText ="Record Not Found!!!" DataKeyNames ="pid" 
                        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black">
                        <Columns >
                            <asp:BoundField DataField ="uname" HeaderText ="User Name" />
                            <asp:BoundField DataField ="ptype" HeaderText ="Post Type" />
                            <asp:BoundField DataField ="pname" HeaderText ="Post Name" />
                            <asp:BoundField DataField ="pdesc" HeaderText ="Post Description" />
                            <asp:BoundField DataField ="pdate" HeaderText ="Post Date" />
                            <asp:ButtonField Text ="Content" HeaderText ="View Content" CommandName ="vc1" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
                         <%--   <asp:ButtonField Text ="Comment" HeaderText ="View Comment" CommandName ="vc2" />
                            <asp:ButtonField Text ="Like" HeaderText ="View Like" CommandName ="vl" />--%>
                            <asp:ButtonField Text ="Delete" HeaderText ="Delete Post" CommandName ="dp" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
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
                    </asp:GridView>
                    <br />
                    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" 
                        Font-Bold="True">Delete All</asp:LinkButton>
                </center>
            </td>
        </tr>
      <%--  <tr>
            <td style ="text-align :center ;">
    <center>View Comment<br />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="false" 
                    EmptyDataText ="Record Not Found!!!" DataKeyNames ="uname,pid" 
                    onrowcommand="GridView2_RowCommand">
                    <Columns >
                        <asp:BoundField DataField ="uname" HeaderText ="User Name" />
                        <asp:BoundField DataField ="ctext" HeaderText ="Comment Text" />
                        <asp:BoundField DataField ="cdate" HeaderText ="Comment Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                        <asp:ButtonField Text ="Delete" HeaderText ="Delete Comment" CommandName  ="dc" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Delete All</asp:LinkButton>
                </center>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;">
    <center>View Like<br />
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns ="false" 
                    EmptyDataText ="Record Not Found!!!" DataKeyNames ="uname,pid" 
                    onrowcommand="GridView3_RowCommand" style="margin-bottom: 0px">
                    <Columns >
                        <asp:BoundField DataField ="uname"  HeaderText ="User Name" />
                        <asp:BoundField DataField ="poption"  HeaderText ="Post Option" />
                        <asp:ButtonField Text ="Delete" HeaderText ="Delete Like"  CommandName ="dl" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Delete All</asp:LinkButton>
                </center>
            </td>
        </tr>--%>
        <tr>
            <td style ="text-align :center ;" class="style1">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

