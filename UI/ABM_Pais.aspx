<%@ Page Title="" Language="C#" MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="ABM_Pais.aspx.cs" Inherits="ABM_Pais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table align="center" border="1" style="width: 605px">
            <tr>
                <td class="style1" colspan="3" style="text-align: center">
                    Mantenimiento de Países&nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px; text-align: left">
                    &nbsp;Código de País:</td>
                <td style="width: 460px; text-align: left;">
                    <asp:TextBox ID="txtCodP" runat="server" Width="189px"></asp:TextBox>
                </td>
                <td style="width: 460px; text-align: center;">
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" Width="112px" />
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px; text-align: left">
                    &nbsp;Nombre País:</td>
                <td style="width: 460px; text-align: left;">
                    <asp:TextBox ID="txtNombreP" runat="server" Width="191px"></asp:TextBox>
                </td>
                <td style="width: 460px; text-align: left;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px; text-align: left">
                    &nbsp;</td>
                <td style="width: 460px; text-align: left;">
                    &nbsp;</td>
                <td style="width: 460px; text-align: left;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px">
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
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar / Deshacer" Width="154px" />
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="LblError" runat="server" Width="320px"></asp:Label>
                </td>
            </tr>
            </table>
    </div>
</asp:Content>

