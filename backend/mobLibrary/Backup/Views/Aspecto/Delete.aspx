<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Aspecto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Aspecto</legend>

    <div class="display-label">idAspecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idAspecto) %>
    </div>

    <div class="display-label">nbrAspecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrAspecto) %>
    </div>

    <div class="display-label">probabilidadAspecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.probabilidadAspecto) %>
    </div>

    <div class="display-label">impactoAspecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.impactoAspecto) %>
    </div>

    <div class="display-label">puntajeAspecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.puntajeAspecto) %>
    </div>

    <div class="display-label">descripcionAspecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionAspecto) %>
    </div>

    <div class="display-label">Elemento</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Elemento.nbrElemento) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
