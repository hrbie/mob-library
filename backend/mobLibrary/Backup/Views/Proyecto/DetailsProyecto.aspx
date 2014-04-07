<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Proyecto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    DetailsProyecto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>DetailsProyecto</h2>

<fieldset>
    <legend>Proyecto</legend>

    <%: Html.HiddenFor(model => model.idProyecto) %>
    
    <div class="display-label">nbrProyecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrProyecto) %>
    </div>

    <div class="display-label">descripcionProyecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionProyecto) %>
    </div>

    <div class="display-label">idPortafolioProyecto_fk</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idPortafolioProyecto_fk) %>
    </div>

    <div class="display-label">idEscalaPuntaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EscalaPuntaje.nbrEscala) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { id = Model.idProyecto, portafolio = Model.idPortafolioProyecto_fk}) %> |
    <%: Html.ActionLink("Back to List", "IndexProyecto", new { portafolio = Model.idPortafolioProyecto_fk})%>
</p>

</asp:Content>
