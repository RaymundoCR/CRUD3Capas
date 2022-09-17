<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Alumnos.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div>
    
    <div>
		<!-- Par de label html - Control asp por cada propiedad -->
        <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList>
    </div>
    <div>

    </div>
    <div style="display : contents; margin : 30px ">
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" BackColor="#a2ffa2"/>
        <asp:Button ID="btnDetalles" runat="server" Text="Detalles" BackColor="#bbd1ff" />
        <asp:Button ID="btnEditar" runat="server" Text="Editar" BackColor="#cefec5"/>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" BackColor="#ff5e5e"/>
    </div>
    </div>--%>
    <h2>Indice</h2>
	<!-- Control asp Label para mensajes -->		
    <hr />
    <div class="container">
        <asp:GridView class="table table-bordered table-condensed table-responsive table-hover " ID="gvAlumnos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvAlumnos_RowCommand" AllowPaging="True" OnPageIndexChanging="gvAlumnos_PageIndexChanging" PageSize="3">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="primerApellido" HeaderText="Primer Apellido" />
                <asp:BoundField DataField="segundoApellido" HeaderText="Segundo Apellido" />
                <asp:BoundField DataField="correo" HeaderText="Correo" />
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="idEstado" HeaderText="Estado" />
                <asp:BoundField DataField="idEstatus" HeaderText="Estatus" />
                <asp:ButtonField CommandName="btnDetalles" Text="Detalles" >
                <ControlStyle CssClass="btn btn-warning btn-sm" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="btnEditar" Text="Editar" >
                <ControlStyle CssClass="btn btn-success btn-sm" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="btnEliminar" Text="Eliminar" >
                <ControlStyle CssClass="btn btn-danger btn-sm" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="container">
        <asp:Button class="btn btn-primary btn-block" ID="btnCrear" runat="server" Text="Crear un nuevo Alumno" OnClick="btnCrear_Click" />
    </div>
    <div>
        <div>
            <a href="Index.aspx">Ir a lista alumnos</a>
            </div>
    </div>

</asp:Content>
