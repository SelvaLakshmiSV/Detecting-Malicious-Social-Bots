<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFriendsList.aspx.cs" Inherits="ViewFriendsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
        <table border="1"  width="70%" align="center" >
            <tr>
                <th colspan="2" >
                  
                    <h1 style ="text-align :center ;">
                        View Friends List</h1>
                
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
                        <center><asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns ="False" 
                PageSize="5" 
                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                CellPadding="4" CellSpacing="2" ForeColor="Black" Width="849px" >
                        <Columns>
                       
                        <asp:BoundField DataField ="uname" HeaderText ="User Name" />
                        <asp:BoundField DataField ="emailid" HeaderText ="EMailID" />
                         <asp:BoundField DataField ="cno" HeaderText ="Contact Number" />
                           <asp:BoundField DataField ="gender" HeaderText ="Gender" />
                            
                              <asp:BoundField DataField ="dob" HeaderText ="Date Of Birth" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                         <asp:ImageField DataImageUrlField ="pimage" DataImageUrlFormatString ="PImage/{0}" HeaderText ="Profile Photo">
                                <ControlStyle  Width ="100" Height ="100" />
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

