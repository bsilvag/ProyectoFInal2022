<%@ Page Title="" Language="C#" MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="ABM_Ciudad.aspx.cs" Inherits="ABM_Ciudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 27px;
        }
        .style2
        {
            height: 62px;
        }
        .style3
        {
            height: 50px;
            width: 604px;
        }
        .style4
        {
            width: 460px;
            height: 50px;
        }
        .style6
        {
            width: 460px;
            height: 48px;
        }
        .style7
        {
            width: 732px;
        }
        .style8
        {
            height: 50px;
            width: 732px;
        }
        .style9
        {
            height: 48px;
            width: 732px;
        }
        .style10
        {
            height: 35px;
            text-align: center;
            text-decoration: underline;
            font-size: xx-large;
        }
        .style11
        {
            height: 27px;
            width: 1329px;
        }
        .style12
        {
            height: 50px;
            width: 1329px;
            text-align: center;
        }
        .style13
        {
            height: 48px;
            width: 1329px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table align="center" border="1" style="width: 605px; margin-bottom: 126px;">
            <tr>
                <td class="style1" colspan="3" style="text-align: center">
                    Mantenimiento de Ciudades</td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11" style="text-align: left">
                    Código de Ciudad:</td>
                <td class="style7" style="text-align: left;">
                    <asp:TextBox ID="txtCodC" runat="server"></asp:TextBox>
                </td>
                <td style="width: 460px; text-align: center;">
                    <asp:Button ID="btnBuscar" runat="server" 
                        Text="Buscar" Width="112px" onclick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td class="style11" style="text-align: left">
                    Código de País:</td>
                <td class="style7" style="text-align: left;">
                    <asp:TextBox ID="txtCodP" runat="server" Width="119px"></asp:TextBox>
                </td>
                <td style="width: 460px; text-align: left;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12" style="text-align: left">
                    Nombre Ciudad:</td>
                <td class="style8" style="text-align: left;">
                    <asp:TextBox ID="txtNombreC" runat="server" Width="155px"></asp:TextBox>
                </td>
                <td class="style4" style="text-align: left;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                </td>
                <td class="style9">
                    <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                        Text="Agregar" />
                    &nbsp;
                    <asp:Button ID="btnModificar" runat="server" 
                        Text="Modificar" />
                    &nbsp;
                    <asp:Button ID="btnEliminar" runat="server" 
                        Text="Eliminar" />
                </td>
                <td class="style6">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar / Deshacer" Width="158px" />
                </td>
            </tr>
            <tr>
                <td class="style10" colspan="3">
                    <asp:Label ID="LblError" runat="server" Width="320px" style="font-size: medium"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

