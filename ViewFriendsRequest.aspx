<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFriendsRequest.aspx.cs" Inherits="ViewFriendsRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1"  width="70%" align="center" >
        <tr>
            <th colspan ="2"  >
             
                <h1 style ="text-align :center ;">
                    Friends Request</h1>
              
            </th>
        </tr>
        <tr>
        <td style ="text-align :right ;">User Name</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" ReadOnly ="true" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td style ="text-align :center ;" colspan="2">
            <center>
                <asp:GridView ID="GridView1" runat="server" AllowPaging ="True" 
                AutoGenerateColumns ="False" onpageindexchanging="GridView1_PageIndexChanging" 
                PageSize="5" DataKeyNames ="id" onrowcommand="GridView1_RowCommand" 
                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                CellPadding="4" CellSpacing="2" ForeColor="Black" Width="525px" >
            <Columns>
            <asp:ImageField DataImageUrlField ="pimage" DataImageUrlFormatString ="PImage/{0}" HeaderText ="Image" >
            <ControlStyle Width ="100" Height ="100" />
            </asp:ImageField>
            <asp:BoundField DataField ="rfrom" HeaderText ="Request From" />
      
              <asp:ButtonField Text ="Accept" CommandName ="aa" ControlStyle-Font-Size="Small"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
                <asp:ButtonField Text ="Reject"  CommandName ="rr" ControlStyle-Font-Size="Small"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />



            
           
          
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
        <td style ="text-align :center ;" colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
             </td> 
        </tr>
        </table>
</asp:Content>

