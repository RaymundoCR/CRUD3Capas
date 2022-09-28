<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Presentacion.Alumnos.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h2 class ="dl-horizaontal">Datos del Alumno</h2>
    <h3>Esta seguro que desea eliminar el Alumno?</h3>
	<!-- Control asp Label para mensajes -->		
    <hr />
    <div class="container">
        <dl class="dl-horizontal">
            <dt><asp:Label ID="label1" runat="server" Text="Idenatificador"></asp:Label></dt>
            <dd><asp:Label ID="lbId" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label2" runat="server" Text="Nombre"></asp:Label></dt>
            <dd><asp:Label ID="lbNombre" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label3" runat="server" Text="Primer Apeliido"></asp:Label></dt>
            <dd><asp:Label ID="lbPApellido" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label4" runat="server" Text="Segundo Apellido"></asp:Label></dt>
            <dd><asp:Label ID="lbSApellido" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label5" runat="server" Text="Fecha de Nacimiento"></asp:Label></dt>
            <dd><asp:Label ID="lbFechaNacimiento" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label6" runat="server" Text="CURP"></asp:Label></dt>
            <dd><asp:Label ID="lbCurp" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label7" runat="server" Text="Correo"></asp:Label></dt>
            <dd><asp:Label ID="lbCorreo" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label8" runat="server" Text="Telefono"></asp:Label></dt>
            <dd><asp:Label ID="lbTelefono" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label9" runat="server" Text="Sueldo"></asp:Label></dt>
            <dd><asp:Label ID="lbSueldo" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label10" runat="server" Text="Estado"></asp:Label></dt>
            <dd><asp:Label ID="lbEstado" runat="server" Text=" "></asp:Label></dd>
            <dt><asp:Label ID="label11" runat="server" Text="Estatus"></asp:Label></dt>
            <dd><asp:Label ID="lbEstatus" runat="server" Text=" "></asp:Label></dd>
        </dl>
    <div>
        <div>
            <asp:Button class="btn-danger" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </div>
        <div>
        </div>
    </div>
    <div>
        <div>
            <a href="Index.aspx">Regresar a Lista</a>
        </div>
    </div>
    </div>
</asp:Content>
