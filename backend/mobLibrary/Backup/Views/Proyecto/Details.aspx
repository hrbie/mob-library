<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Proyecto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

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

    <div class="display-label">PortafolioProyectos</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.PortafolioProyectos.nbrPortafolioProyecto) %>
    </div>

    <div class="display-label">EscalaPuntaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EscalaPuntaje.nbrEscala) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { id = Model.idProyecto }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
