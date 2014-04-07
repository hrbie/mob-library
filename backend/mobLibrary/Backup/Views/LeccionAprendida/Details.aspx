<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.LeccionAprendida>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>LeccionAprendida</legend>

    <div class="display-label">idLeccionAprendida</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idLeccionAprendida) %>
    </div>

    <div class="display-label">nbrLeccionAprendida</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrLeccionAprendida) %>
    </div>

    <div class="display-label">descripcionLeccionAprendida</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionLeccionAprendida) %>
    </div>

    <div class="display-label">fchCreacion</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.fchCreacion) %>
    </div>

    <div class="display-label">Proyecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Proyecto.nbrProyecto) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
