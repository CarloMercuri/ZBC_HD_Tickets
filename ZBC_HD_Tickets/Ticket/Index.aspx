<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" MasterPageFile="../MasterPages/Main.Master" Inherits="ZBC_HD_Tickets.Ticket.Index" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div id="tableDiv">
        <table class="styled-table">
            <thead>
              <tr>
                  <th>ID</th>
                  <th>First Name</th>
                  <th>Last Name</th>
                  <th>Email</th>
                  <th>Authorization</th>
                  <th>Action</th>
              </tr>
            </thead>
              <asp:Repeater ID="repPeople" runat="server">
                 <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %> </td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("LastName") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Authorization") %></td>
                        <td>
                            <asp:Button ID="test" runat="server" CssClass="action-button" Text="Edit" CommandArgument='<%# Eval("ID")%>' CommandName="EditBtnClick" OnClick="ActionButtonPress" />
                            <asp:Button ID="test2" runat="server" CssClass="action-button" Text="Delete" CommandArgument='<%# Eval("ID")%>' CommandName="DeleteBtnClick" OnClick="ActionButtonPress" />
                        </td>

                    </tr>
                 </ItemTemplate>
              </asp:Repeater>
        </table>
</div>
     
</asp:Content>


