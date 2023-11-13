<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="updatecustomer.aspx.cs" Inherits="ERP.updatecustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <div class="form-group">
        <label for="custname">CUSTOMER NAME</label>
        <asp:TextBox ID="custname" runat="server" class="form-control" placeholder="Enter Your Name" name="custname">
        </asp:TextBox>
    </div>

     <div class="form-group">
        <label for="phno">PHONE NO.</label>
        <asp:TextBox ID="phno" runat="server" class="form-control" placeholder="Enter Your Phone no." name="phno">
        </asp:TextBox>
    </div>

     <div class="form-group">
        <label for="emid">EMAIL ID</label>
        <asp:TextBox ID="emid" runat="server" class="form-control" placeholder="Enter Your Email Id" name="emid">
        </asp:TextBox>
    </div>

    <div class="form-group">
        <label for="add">ADDRESS</label>
        <asp:TextBox ID="add" runat="server" class="form-control" placeholder="Enter Your Address" name="add">
        </asp:TextBox>
    </div>

    <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="UPDATE" OnClick="Button1_Click"  />





















</asp:Content>
