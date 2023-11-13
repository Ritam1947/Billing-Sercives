<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="Updateproduct.aspx.cs" Inherits="ERP.Updateproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="form-group">
        <label for="prodname">PRODUCT NAME</label>
        <asp:TextBox ID="prodname" runat="server" class="form-control" placeholder="Enter product name" name="prodname">
        </asp:TextBox>
    </div>

    <div class="form-group">
        <label for="code">CODE</label>
        <asp:TextBox ID="code" runat="server" class="form-control" placeholder="Enter product code" name="code">
        </asp:TextBox>
    </div>

    <div class="form-group">
        <label for="des">PRODUCT DESCRIPTION</label>
        <asp:TextBox ID="des" runat="server" class="form-control" placeholder="Enter product description" name="des">
        </asp:TextBox>
    </div>

    <div class="form-group">
        <label for="mrp">PRODUCT MRP</label>
        <asp:TextBox ID="mrp" runat="server" class="form-control" placeholder="Enter MRP" name="mrp">
        </asp:TextBox>
    </div>

    <div class="form-group">
        <label for="tax">PRODUCT TAX</label>
        <asp:TextBox ID="tax" runat="server" class="form-control" placeholder="Enter Product Tax" name="tax">
        </asp:TextBox>
    </div>

    <div class="form-group">
        <label for="GST">PRODUCT GST</label>
        <asp:TextBox ID="GST" runat="server" class="form-control" placeholder="Enter Product GST" name="GST">
        </asp:TextBox>
    </div>
    <asp:Button ID="Button1" runat="server" Text="UPDATE" class="btn btn-success" OnClick="Button1_Click" />








</asp:Content>
