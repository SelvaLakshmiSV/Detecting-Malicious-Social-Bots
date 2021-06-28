<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserViewProfile.aspx.cs" Inherits="UserViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
        <tr>
            <th>
                <h1>
                    Profile Details</h1>
            </th>
        </tr>
        <tr>
            <td>
                <center>
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="105px" Width="285px" 
                    AutoGenerateRows ="False" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black" >
                        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <Fields>

                         <asp:ImageField DataImageUrlField ="pimage" DataImageUrlFormatString ="PImage/{0}" HeaderText ="Profile Photo">
                                <ControlStyle  Width ="200" Height ="200" />
                            </asp:ImageField>
                        
                        <asp:BoundField DataField ="uname" HeaderText ="UserName" />
                        <asp:BoundField DataField ="emailid" HeaderText ="EMailID" />
                        <asp:BoundField DataField ="gender" HeaderText ="Gender" />
                        <asp:BoundField DataField ="dob" HeaderText ="Date Of Birth" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField ="address" HeaderText ="Address" />
                        <asp:BoundField DataField ="location" HeaderText ="Location" />
                        <asp:BoundField DataField ="pcode"  HeaderText  ="Pin Code" />
                        <asp:BoundField DataField ="cno" HeaderText ="Contact Number" />
                        <asp:BoundField DataField ="squestion" HeaderText ="Security Question" />
                        <asp:BoundField DataField ="sanswer" HeaderText ="Security Answer" />
                        
                           
                        </Fields>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                    </asp:DetailsView>
                </center>
            </td>
        </tr>
        <tr>
            <td style="text-align :center ;" >
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                    Font-Bold="True">Edit</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="text-align :center ;" >
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

