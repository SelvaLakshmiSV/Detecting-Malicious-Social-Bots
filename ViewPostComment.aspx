<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPostComment.aspx.cs" Inherits="ViewPostComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%">
<tr>
<th ><h1>View Comment Details</h1></th>
</tr>
<tr>
<td style ="text-align : center ;">
<center>
    <asp:DetailsView ID="DetailsView1" runat="server" Height="217px" Width="283px" 
        AutoGenerateRows ="False" EmptyDataText ="Record Not Found!!!" 
        onitemcommand="DetailsView1_ItemCommand" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black">
        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    <Fields >

    <asp:BoundField DataField ="uname" HeaderText ="User Name" />
    <asp:BoundField DataField ="ptype" HeaderText ="Post Type" />
    <asp:BoundField DataField ="pname" HeaderText ="Post Name" />
    <asp:BoundField DataField ="pdesc" HeaderText ="Post Description" />
    <asp:BoundField DataField ="pdate" HeaderText ="Post Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
    <asp:ButtonField Text ="View Content" HeaderText ="View Content" CommandName ="vc"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
    
    </Fields>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle HorizontalAlign="Left" BackColor="White" />
    </asp:DetailsView>

</center>

</td>

</tr>

<tr>
<td style ="text-align : center ;">
<center>
User Comment<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
        ForeColor="Black">
    <Columns >
    
    <asp:BoundField DataField ="uname" HeaderText ="User Name" />
    <asp:BoundField DataField ="ctext" HeaderText ="Comment Text" />
    <asp:BoundField DataField ="cdate" HeaderText ="Comment Date" />
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
<td style ="text-align : center ;">
<center>
Bot Comment
<br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
        ForeColor="Black">
    <Columns >
     <asp:BoundField DataField ="uname" HeaderText ="User Name" />
    <asp:BoundField DataField ="ctext" HeaderText ="Comment Text" />
    <asp:BoundField DataField ="cdate" HeaderText ="Comment Date" />
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
<td style ="text-align : center ;">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

</td>

</tr>

</table>
</asp:Content>

