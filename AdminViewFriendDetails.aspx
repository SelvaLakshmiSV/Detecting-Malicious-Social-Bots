<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewFriendDetails.aspx.cs" Inherits="AdminViewFriendDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%">
<tr>
<th><h1>User Details</h1></th>

</tr>
<tr>
<td style ="text-align :center ;">
<center >
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" DataKeyNames ="uname" 
        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black">
    <Columns >
    <asp:BoundField DataField ="uname" HeaderText ="User Name" />

    <asp:ImageField DataImageUrlField ="PImage" DataImageUrlFormatString ="PImage\{0}" HeaderText ="Profile Image">
    <ControlStyle Width ="150" Height ="150" />

    </asp:ImageField>
    <asp:ButtonField Text ="View" HeaderText ="View Friends" CommandName ="vf" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
    
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
<td style ="text-align :center ;">
<center >
View Friends
<br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!"  DataKeyNames ="uname" 
        onrowcommand="GridView2_RowCommand" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black">
    <Columns >
    <asp:BoundField DataField ="uname" HeaderText ="User Name" />
    <asp:BoundField DataField ="emailid" HeaderText ="Email ID" />
    <asp:BoundField DataField ="gender" HeaderText ="Gender" />
    <asp:BoundField DataField ="dob" HeaderText ="Date of Birth" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
    <asp:BoundField DataField ="address" HeaderText ="Address" />
    <asp:BoundField DataField ="location" HeaderText ="Location" />
    <asp:BoundField DataField ="pcode" HeaderText ="Pin Code" />
    <asp:BoundField DataField ="cno" HeaderText ="Contact Number" />
    <asp:ImageField DataImageUrlField ="pimage" DataImageUrlFormatString ="PImage\{0}" HeaderText ="Profile Image">
    <ControlStyle Width ="150" Height ="150" />
    </asp:ImageField>
    <asp:ButtonField Text ="Delete" HeaderText ="Delete User" CommandName ="du" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
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
<td style ="text-align :center ;">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</td>
</tr>
</table>
</asp:Content>

