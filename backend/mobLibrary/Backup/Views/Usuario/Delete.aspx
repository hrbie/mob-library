<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Usuario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Usuario</legend>

    <div class="display-label">idUsuario</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idUsuario) %>
    </div>

    <div class="display-label">nbrUsuario</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrUsuario) %>
    </div>

    <div class="display-label">apellido1</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.apellido1) %>
    </div>

    <div class="display-label">apellido2</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.apellido2) %>
    </div>

    <div class="display-label">email</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.email) %>
    </div>

    <div class="display-label">telefono</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.telefono) %>
    </div>

    <div class="display-label">Rol</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Rol.nbrRol) %>
    </div>

    <div class="display-label">nombre</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
