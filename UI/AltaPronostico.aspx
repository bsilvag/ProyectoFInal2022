<%@ Page Title="" Language="C#" MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="AltaPronostico.aspx.cs" Inherits="AltaPronostico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            text-decoration: underline;
            font-family: "Century Gothic";
            font-size: large;
        }
        .style4
        {
            font-family: Calibri;
            background-color: #FFCC99;
            font-size: small;
            text-decoration: underline;
        }
        .style5
        {
            font-size: small;
        }
        .style6
        {
            text-align: center;
            text-decoration: underline;
            font-size: small;
        }
        .style7
        {
            text-align: center;
            font-size: large;
        }
        .style8
        {
            width: 256px;
        }
        .style9
        {
            width: 256px;
            font-size: small;
            text-align: left;
        }
        .style11
        {
            font-size: small;
            text-decoration: underline;
            width: 146px;
            height: 38px;
        }
        .style12
        {
            font-size: small;
            width: 151px;
            height: 38px;
        }
        .style13
        {
            font-size: small;
            text-decoration: underline;
            width: 146px;
            height: 44px;
        }
        .style14
        {
            font-size: small;
            width: 151px;
            height: 44px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
        <span class="style1"><strong>Agregar Pronóstico</strong></span><strong><br 
            class="style7" />
        </strong>
        <br class="style5" />
        <table style="background-color: #FFCC99">
            <tr>
                <td class="style6">
                    Fecha del Ponóstico</td>
                <td colspan="2" style="width: 151px">
                    <asp:Calendar ID="clnFecha" runat="server" BackColor="White" 
                        BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                        ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                            VerticalAlign="Bottom" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                            Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Temperatura:</td>
                <td class="style8">
                    <span class="style5">Temperatura máxima en °C<br />
                    <br />
                    <br />
                    Temperatura mínima en °C</span></td>
                <td style="width: 151px">
                    <span class="style5">
                    <asp:TextBox ID="txtTempMax" runat="server" EnableTheming="True"></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox ID="txtTempMin" runat="server"></asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Velocidad:</td>
                <td colspan="2" style="width: 151px">
                    <asp:TextBox ID="txtVelocidad" runat="server" CssClass="style6" Height="25px" 
                        Width="159px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 146px; ">
                    Tipo de cielo:</td>
                <td colspan="2" style="width: 151px">
                    <asp:RadioButtonList ID="RblTipoCielo" runat="server" 
                        style="font-size: small; text-align: left" Width="181px">
                        <asp:ListItem>Despejado</asp:ListItem>
                        <asp:ListItem>Parcialmente Nuboso</asp:ListItem>
                        <asp:ListItem>Nuboso</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Probabilidades:</td>
                <td class="style9">
                    Probabilidad de lluvia (0 a 100%)<br />
                    <br />
                    Probabilidad de tormenta (0 a 100%)</td>
                <td style="width: 151px">
                    <span class="style5">
                    <asp:TextBox ID="txtProbL" runat="server" EnableTheming="True"></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox ID="txtProbT" runat="server"></asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    País:</td>
                <td class="style12" colspan="2">
                    <asp:DropDownList ID="cboPais" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Ciudad:</td>
                <td class="style14" colspan="2">
                    <asp:DropDownList ID="cboCiudad" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="height: 26px">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="style5" Font-Bold="True" 
                        OnClick="btnAgregar_Click" Text="Agregar" />
                </td>
            </tr>
        </table>
    </div>
    <span class="style5">&nbsp; </span>
                    <asp:Label ID="LblError" runat="server" Width="320px" 
        style="font-size: medium"></asp:Label>
    <br class="style5" />
</asp:Content>

