<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="KitapVerme.aspx.cs" Inherits="Kutuphane.KitapVerme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style10 {
        font-size: large;
    }
    .auto-style11 {
        text-align: center;
    }
        .auto-style12 {
            text-align: center;
            height: 29px;
        }
        .auto-style13 {
            text-align: center;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style4">
    <tr>
        <td class="auto-style11"><strong>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style10" Text="KİTAP VERME"></asp:Label>
            </strong></td>
    </tr>
    <tr>
        <td class="auto-style11">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">
            <asp:Label ID="Label2" runat="server" Text="Teslim Edeceğiniz Kitabın Resmini Seçin"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style12">
            <asp:FileUpload ID="FileUpload1" runat="server" Width="322px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style11">
            <asp:Button ID="btn_yukle" runat="server" OnClick="btn_yukle_Click" Text="Yükle" />
        </td>
    </tr>
    <tr>
        <td class="auto-style11">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style11">
            <asp:Image ID="Image2" runat="server" Height="480px" Width="362px" />
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style11">
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style11">
            <asp:Button ID="btn_teslimEt" runat="server" Height="31px" Text="Teslim Et" Width="116px" OnClick="btn_teslimEt_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style11">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
