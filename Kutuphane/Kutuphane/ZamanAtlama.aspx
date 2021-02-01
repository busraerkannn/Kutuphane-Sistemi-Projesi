<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ZamanAtlama.aspx.cs" Inherits="Kutuphane.ZamanAtlama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style11 {
            height: 26px;
            text-align: center;
        }
        .auto-style12 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <table class="auto-style4">
        <tr>
            <td class="auto-style11"><strong>
                <asp:Label ID="Label1" runat="server" CssClass="auto-style12" Text="ZAMAN ATLAMA"></asp:Label>
                </strong></td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:Label ID="Label2" runat="server" Text="Eklenecek Gün Sayısı :"></asp:Label>
&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Width="55px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Zaman Atla" Width="114px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>




