<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewGroupDetails.aspx.cs" Inherits="AdminViewGroupDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" align="center" width ="70%">
<tr>
<th ><h1>View Group Details</h1></th>
</tr>
<tr>
<td style ="text-align :center ;">
    <center><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" DataKeyNames ="gname" 
        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
            ForeColor="Black">
    <Columns >
    <asp:BoundField DataField ="gname" HeaderText ="Group Name" />
    <asp:BoundField DataField ="gdesc" HeaderText ="Group Description" />
    <asp:BoundField DataField ="gcdate" HeaderText ="Group Creation Date" />
    <asp:ButtonField Text ="View"  HeaderText ="View Member" CommandName ="vm" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
    <asp:ButtonField Text ="Delete"  HeaderText ="Delete Group" CommandName ="dg"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true"/>
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
<td style ="text-align :center ;">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

</td>

</tr>

</table>
</asp:Content>

