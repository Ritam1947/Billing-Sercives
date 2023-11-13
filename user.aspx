<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="ERP.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="form-group">
        <label for="prodname">NAME</label>
        <asp:TextBox ID="name" runat="server" class="form-control" placeholder="Enter your name" name="prodname"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="code">USERNAME</label>
        <asp:TextBox ID="usrname" runat="server" class="form-control" placeholder="Enter your username" name="code"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="des">PASSWORD</label>
        <asp:TextBox ID="txtpwd" runat="server" class="form-control" placeholder="Enter your Password" name="des"></asp:TextBox>
    </div>

    

    <asp:Button ID="Button1" runat="server" Text="SAVE" class="btn btn-success" OnClick="Button1_Click"/>


</asp:Content>
