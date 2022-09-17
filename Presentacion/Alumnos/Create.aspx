<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Presentacion.Alumnos.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h2>Crear</h2>
	<!-- Control asp Label para mensajes -->		
    <hr />
    <%--<div>
        <asp:Label ID="lbId" runat="server" Text="Idenatificador"></asp:Label>
        <div>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        </div>
    </div>--%>
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div> 
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="El campo Nombre es requerido" ControlToValidate="txtNombre" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="Entrada de caracteres no valida" ControlToValidate="txtNombre" CssClass="text-danger" ValidationExpression="[A-z À-ÿ]+"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbPApellido" runat="server" Text="Primer Apeliido"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtPApellido" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:RegularExpressionValidator ID="revPapellido" runat="server" ErrorMessage="Entrada de caracteres no valida" CssClass="text-danger" ControlToValidate="txtPApellido" ValidationExpression="[A-z À-ÿ]+"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="rfvPApellido" runat="server" ErrorMessage="El campo Primer Apellido es requerido" CssClass="text-danger" ControlToValidate="txtPApellido"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbSApellido" runat="server" Text="Segundo Apellido"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtSApellido" runat="server" ControlToValidate="txtSApellido"></asp:TextBox>
            </div>
            <div>
                <asp:RegularExpressionValidator ID="revSapellido" runat="server" ErrorMessage="Entrada de caracteres no valida" CssClass="text-danger" ControlToValidate="txtSApellido" ValidationExpression="[A-z À-ÿ]+"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtFNacimiento" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="rfvFnacimiento" runat="server" ErrorMessage="El campo Fecha de nacimiento es requerido" ControlToValidate="txtFNacimiento" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:RangeValidator ID="rvFnacimiento" runat="server" ErrorMessage="Fecha debe estar entre 01-01-1990 y 31-12-2000" CssClass="text-danger" ControlToValidate="txtFNacimiento" Type="Date" MaximumValue="31-12-2000" MinimumValue="01-01-1990"></asp:RangeValidator>
            </div>
            <div>
                <asp:CustomValidator ID="cvFnaciminetoCurp" runat="server" ErrorMessage="La curp no conincide con la fecha de nacimiento" ControlToValidate="txtFNacimiento" ClientValidationFunction="cvFechaCurp" CssClass="text-danger"></asp:CustomValidator>
            </div>
            
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbCurp" runat="server" Text="CURP"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtCurp" runat="server"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="rfvCurp" runat="server" ErrorMessage="El campo Curp es requerido" ControlToValidate="txtCurp" CssClass="text-danger"></asp:RequiredFieldValidator>
            <div>
                <asp:RegularExpressionValidator ID="revCurp" runat="server" ErrorMessage="CURP invalido" CssClass="text-danger" ControlToValidate="txtCurp" ValidationExpression="[A-Z]{4}[0-9]{2}[0-9]{2}[0-9]{2}[HM]{1}(AS|BS|CL|CS|DF|GT|HG|MC|MS|NL|PL|QR|SL|TC|TL|YN|NE|BC|CC|CM|CH|DG|GR|JC|MN|NT|OC|QT|SP|SR|TS|VZ|ZS){1}[^AEIOU\d\W]{3}[0-9]{2}"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label class="control-label col-sm-2" ID="lbCorreo" runat="server" Text="Correo"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" ID="txtCorreo" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ErrorMessage="El campo Correo es requerido" ControlToValidate="txtCorreo" CssClass="text-danger"></asp:RequiredFieldValidator>
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
            <div>
                <asp:RangeValidator ID="rvSueldo" runat="server" ErrorMessage="El Sueldo debe ser entre 10000 a 40000" ControlToValidate="txtSueldo" CssClass="text-danger" Type="Double" MinimumValue="10000" MaximumValue="40000"></asp:RangeValidator>
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
    <div>
        <div>
            <asp:Button class="btn-primary" ID="btnGuardarAgregar" runat="server" Text="Guardar" OnClick="btnGuardarAgregar_Click" />
        </div>
    </div>
    <div>
        <div>
            <a href="Index.aspx">Regresar a Lista</a>
        </div>
    </div>
</div>
    </div>
<script type="text/javascript">
    function cvFechaCurp(source, args) {
        var fechaNC = $("#<% =txtFNacimiento.ClientID %>").val();
        var CurpPARTfecha = $("#<% =txtCurp.ClientID%>").val().substr(4, 6);
        var FechNacFormCurp = fechaNC.substr(2, 2) + fechaNC.substr(5, 2) + fechaNC.substr(8, 2);
        args.IsValid = CurpPARTfecha == FechNacFormCurp;
    }
</script>
</asp:Content>

