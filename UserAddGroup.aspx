<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserAddGroup.aspx.cs" Inherits="UserAddGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%">
<tr>
<th colspan ="2">
<h1>Join Group</h1>
</th>
</tr>
<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
</td>

</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
<center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" DataKeyNames ="gname" 
        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black">
    <Columns>
    <asp:BoundField DataField ="gname" HeaderText ="Group Name" />
    <asp:BoundField DataField ="gdesc" HeaderText ="Description" />
    <asp:BoundField DataField ="gcdate" HeaderText ="Creation Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
    <asp:ButtonField Text ="View" HeaderText ="View Group Member" CommandName ="vg"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
    <asp:ButtonField Text ="Join" HeaderText ="Join Group" CommandName ="jg"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
    
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
<center>
Group Member<br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
        ForeColor="Black">
    <Columns>
    <asp:BoundField DataField ="uname" HeaderText ="User Name" />
    <asp:ImageField DataImageUrlField ="pimage" DataImageUrlFormatString ="PImage\{0}" HeaderText ="Profile Image">
    <ControlStyle Width ="150" Height ="150" />
    </asp:ImageField>
    
    
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

