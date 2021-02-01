<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KitapEkleme.aspx.cs" Inherits="Kutuphane.KitapEkleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style11 {
            font-size: large;
            text-align: center;
        }
        .auto-style13 {
            font-size: medium;
            text-align: center;
            height: 35px;
        }
        .auto-style14 {
            font-size: medium;
            text-align: center;
            height: 29px;
        }
        .auto-style15 {
            font-size: medium;
            text-align: center;
            height: 34px;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <table class="auto-style4">
        <tr>
            <td class="auto-style11"><strong>KİTAP EKLEME</strong></td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">Kitap Adı :
                <asp:TextBox ID="txt_kitapAdi" runat="server" Height="20px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">ISBN İçin Fotoğraf Seçin :
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style15">
                <asp:Button ID="btn_yukle" runat="server" OnClick="Button1_Click" Text="Yükle" />
            </td>
        </tr>
        <tr>
            <td class="auto-style15">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
                <asp:Image ID="Image2" runat="server" Height="480px" Width="362px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
            &nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td class="auto-style14">
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_kaydet" runat="server" Height="35px" Text="Kaydet" Width="95px" OnClick="btn_kaydet_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

