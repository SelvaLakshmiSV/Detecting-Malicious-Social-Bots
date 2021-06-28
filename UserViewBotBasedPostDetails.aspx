<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserViewBotBasedPostDetails.aspx.cs" Inherits="UserViewBotBasedPostDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>Bot Based Post Details</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox></td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
<center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" DataKeyNames ="pid" 
        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black" >
    <Columns >
    <asp:BoundField DataField ="uname" HeaderText ="User Name" />
    <asp:BoundField DataField ="ptype" HeaderText ="Post Type" />
    <asp:BoundField DataField ="pid" HeaderText ="Post ID" />
    <asp:BoundField DataField ="pname" HeaderText ="Post Name" />
    <asp:BoundField DataField ="pdesc" HeaderText ="Post Description" />
    <asp:BoundField DataField ="pdate" HeaderText ="Post Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
    <asp:ButtonField Text ="View" HeaderText ="View Content" CommandName ="vc"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
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
</center>

</td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>

</tr>

</table>
</asp:Content>

