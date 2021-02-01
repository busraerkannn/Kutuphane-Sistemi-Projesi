<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="KitapArama.aspx.cs" Inherits="Kutuphane.KitapArama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style10 {
            font-size: large;
            text-align: center;
        }
        .auto-style11 {
            font-size: medium;
            text-align: center;
        }
        .auto-style12 {
            font-size: medium;
            text-align: center;
            height: 26px;
        }
        .auto-style13 {
            font-size: medium;
            text-align: center;
            height: 34px;
        }
        .auto-style14 {
            font-size: large;
            text-align: center;
            height: 30px;
        }
        .auto-style15 {
            font-size: medium;
            text-align: right;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style4">
        <tr>
            <td class="auto-style10"><strong>KİTAP ARAMA</strong></td>
        </tr>
        <tr>
            <td class="auto-style14"></td>
        </tr>
        <tr>
            <td class="auto-style15">&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Kitap Adına Göre Arama" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" Text="ISBN'e Göre Arama" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;<asp:Label ID="Label1" runat="server" Text="Label : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:Button ID="btn_ara" runat="server" Text="Ara" OnClick="btn_ara_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">
                <strong>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </strong>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
