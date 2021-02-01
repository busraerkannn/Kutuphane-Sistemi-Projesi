<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KullaniciListeleme.aspx.cs" Inherits="Kutuphane.KullaniciListeleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style11 {
            text-align: left;
            font-size: large;
        }
        .auto-style12 {
            height: 30px;
        }
        .auto-style13 {
            width: 685px;
        }
        .auto-style14 {
            width: 685px;
            font-size: large;
            
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <table class="auto-style4">
        <tr>
            <td class="auto-style11"><strong>
                <asp:Label ID="Label3" runat="server" Text="Kullanıcı Adı" Width="326px"></asp:Label>
                &nbsp;<asp:Label ID="Label4" runat="server" Text="Kitap Adı" Width="326px"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:DataList ID="DataList1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" GridLines="Both" Width="685px" Height="98px">
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <ItemTemplate>
                        <table class="auto-style4">
                            <tr>
                                <td class="auto-style12">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("KullaniciAd") %>' Width="326px"></asp:Label>
                                </td>
                                <td class="auto-style12">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("KitapAd") %>' Width="326px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
            </td>
        </tr>
        </table>
    <table>

        <tr>
            <td class="auto-style14">
                <asp:DataList ID="DataList2" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" GridLines="Both" Height="66px" Width="685px">
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <ItemTemplate>
                        &nbsp;<asp:Label ID="Label5" runat="server" Text='<%# Eval("KullaniciAd") %>' Width="326px" CssClass="auto-style12"></asp:Label>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
            </td>
        </tr>
        

    </table>
</asp:Content>

