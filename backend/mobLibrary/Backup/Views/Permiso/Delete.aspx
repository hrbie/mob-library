<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Permiso>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Permiso</legend>

    <div class="display-label">idPermiso</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idPermiso) %>
    </div>

    <div class="display-label">nbrPermiso</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrPermiso) %>
    </div>

    <div class="display-label">descripcionPermiso</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionPermiso) %>
    </div>

    <div class="display-label">codigoPermiso</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.codigoPermiso) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
