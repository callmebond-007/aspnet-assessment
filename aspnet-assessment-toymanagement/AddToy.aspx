<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToy.aspx.cs" Inherits="aspnet_assessment.AddToy" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
    <br />
    <asp:TextBox ID="txtToyName" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator runat="server" ID="Name" ControlToValidate="txtToyName" ErrorMessage ="Toy Name is mandatory" ForeColor="Red"></asp:RequiredFieldValidator>

    <br />
     <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlCategories" runat="server"></asp:DropDownList>
    <br />
     <asp:RequiredFieldValidator runat="server" ID="Category" ControlToValidate="ddlCategory" ErrorMessage ="Category is mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LblDescription" runat="server" Text="Description"></asp:Label>
    <br />
    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator runat="server" ID="Description" ControlToValidate="txtDescription" ErrorMessage ="Description is mandatory" ForeColor="Red"></asp:RequiredFieldValidator>

    <br />
    <asp:Label ID="LblAmount" runat="server" Text="Amount"></asp:Label>
    <br />
    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator runat="server" ID="Amount" ControlToValidate="txtAmount" ErrorMessage ="Amount is mandatory" ForeColor="Red"></asp:RequiredFieldValidator>

    <br />

    

    <asp:Button ID="btnAddToy" runat="server" Text="Add Toy" OnClick="btnAddToy_Click" />

</asp:Content>


