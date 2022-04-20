<%@ Page Title="" Language="C#" MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="ABM_Usuario.aspx.cs" Inherits="ABM_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 648px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table align="center" border="1" style="width: 605px">
            <tr>
                <td class="style1" colspan="3" style="text-align: center">
                    Mantenimiento de Usuario&nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="text-align: left">
                    Nombre de Usuario:</td>
                <td style="width: 460px; text-align: left;">
                    <asp:TextBox ID="txtNombUsu" runat="server" Width="190px"></asp:TextBox>
                </td>
                <td style="width: 460px; text-align: center;">
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" Width="112px" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="text-align: left">
                    Contraseña:</td>
                <td style="width: 460px; text-align: left;">
                    <asp:TextBox ID="txtPass" runat="server" Width="191px"></asp:TextBox>
                </td>
                <td style="width: 460px; text-align: left;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="text-align: left">
                    Nombre:</td>
                <td style="width: 460px; text-align: left;">
                    <asp:TextBox ID="txtNombre" runat="server" Width="191px"></asp:TextBox>
                </td>
                <td style="width: 460px; text-align: left;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td style="width: 460px">
                    <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                        Text="Agregar" />
                    &nbsp;
                    <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                        Text="Modificar" />
                    &nbsp;
                    <asp:Button ID="btnEliminar" runat="server" onclick="btnEliminar_Click" 
                        Text="Eliminar" />
                </td>
                <td style="width: 460px">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar / Deshacer" Width="153px" />
                &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Label ID="LblError" runat="server" Width="320px" style="font-size: medium"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

