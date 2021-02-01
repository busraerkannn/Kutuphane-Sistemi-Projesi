<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="KitapAlma.aspx.cs" Inherits="Kutuphane.KitapAlma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style10 {
        font-size: large;
    }
    .auto-style11 {
        text-align: center;
    }
    .auto-style12 {
        text-align: left;
    }
    .auto-style13 {
        font-size: medium;
    }
    .auto-style14 {
        text-align: left;
        height: 26px;
    }
    .auto-style15 {
        text-align: center;
        height: 26px;
    }
    .auto-style16 {
        text-align: center;
        height: 34px;
    }
    .auto-style17 {
        text-align: center;
        height: 44px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style4">
    <tr>
        <td class="auto-style11"><strong>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style10" Text="KİTAP ALMA"></asp:Label>
            </strong></td>
    </tr>
    <tr>
        <td class="auto-style15"></td>
    </tr>
    <tr>
        <td class="auto-style16">&nbsp;
            <asp:Label ID="Label2" runat="server" CssClass="auto-style13" Text="Kitap Adı:"></asp:Label>
&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" Width="269px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style14">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style17">&nbsp;<asp:Button ID="Button1" runat="server" Height="40px" Text="Kitabı Al" Width="109px" OnClick="Button1_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style12">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11"><strong>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style13" Text="Label"></asp:Label>
            </strong></td>
    </tr>
    <tr>
        <td class="auto-style11">&nbsp;</td>
    </tr>
</table>
</asp:Content>
