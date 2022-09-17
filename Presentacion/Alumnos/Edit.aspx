<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Presentacion.Alumnos.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h2>Editar</h2>
	<!-- Control asp Label para mensajes -->
    </div>
    <hr />
    <div class="form-horizontal">

        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbId" runat="server" Text="Idenatificador"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtId" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtNombre" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbPApellido" runat="server" Text="Primer Apeliido"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtPApellido" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbSApellido" runat="server" Text="Segundo Apellido"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtSApellido" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtFNacimineto" runat="server" TextMode="Date" ClientIDMode="Inherit"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbCurp" runat="server" Text="CURP"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtCurp" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:CustomValidator ID="cvFnacimientoEdit" runat="server" ErrorMessage="La curp no coninicde con la fecha de nacimiento" ControlToValidate="txtCurp" ValidateEmptyText="False" OnServerValidate="cvFnacimientoEdit_ServerValidate" CssClass="text-danger"></asp:CustomValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbCorreo" runat="server" Text="Correo"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtCorreo" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbTelefono" runat="server" Text="Telefono"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbSueldo" runat="server" Text="Sueldo"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtSueldo" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbEstado" runat="server" Text="Estado"></asp:Label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbEstatus" runat="server" Text="Estatus"></asp:Label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList>
            </div>
        </div>
    </div>
    <div>
        <div>
            <asp:Button ID="btnGuardarActualizar" runat="server" Text="Guardar" OnClick="btnGuardarActualizar_Click" />
        </div>
    </div>
    <div>
        <div>
            <a href="Index.aspx">Regresar a Lista</a>
        </div>
    </div>
</asp:Content>
