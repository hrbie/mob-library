<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Categoria>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Categoria</legend>

    <div class="display-label">idCategoria</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idCategoria) %>
    </div>

    <div class="display-label">descripcionCategoria</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionCategoria) %>
    </div>

    <div class="display-label">nivelCategoria</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nivelCategoria) %>
    </div>

    <div class="display-label">valorMinimo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.valorMinimo) %>
    </div>

    <div class="display-label">valorMaximo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.valorMaximo) %>
    </div>

    <div class="display-label">EscalaPuntaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EscalaPuntaje.nbrEscala) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
