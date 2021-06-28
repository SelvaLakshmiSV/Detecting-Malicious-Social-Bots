<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminSetParameters.aspx.cs" Inherits="AdminSetParameters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table border="1" align="center" width ="70%">
<tr>
<th ><h1>View and Set Parameter</h1></th>
</tr>
<tr>
<td style ="text-align :center;" >
<center>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" DataKeyNames ="imgid" 
        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black">
    <Columns >
    <asp:BoundField DataField ="imgid" HeaderText ="Image ID" />
    <asp:ImageField DataImageUrlField ="imgpath" DataImageUrlFormatString ="CImage/{0}" HeaderText ="Image">
    <ControlStyle Width ="200" Height ="200" />
    </asp:ImageField>
     <asp:ButtonField Text ="Delete" HeaderText ="Delete Image" CommandName ="di" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
    <asp:ButtonField Text ="View" HeaderText ="Previous Parameter" CommandName ="pp" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
    <asp:ButtonField Text ="New Parameter" HeaderText ="Create New Parameter"  CommandName ="cn" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />

    
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
<td style ="text-align :center;" >
<center >
    <asp:Label ID="Label2" runat="server" Text="View Previous Paramters"></asp:Label>
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found" onrowcommand="GridView2_RowCommand" 
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
        CellPadding="4" CellSpacing="2" ForeColor="Black" >
    <Columns >
    <asp:BoundField DataField ="xpoint"  HeaderText ="X Position" />
    <asp:BoundField DataField ="ypoint" HeaderText ="Y Position" />
    <asp:BoundField DataField ="pname" HeaderText ="Parameter Name" />
    <asp:ButtonField Text ="Delete"  HeaderText ="Delete Parameter" CommandName ="dp" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
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

