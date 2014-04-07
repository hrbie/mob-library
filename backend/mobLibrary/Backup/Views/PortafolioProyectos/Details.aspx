<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.PortafolioProyectos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>
<br />
<fieldset>
    <legend>Portafolio de Proyectos</legend>

    <%: Html.HiddenFor(model => model.idPortafolioProyecto) %>

    <div class="display-label">nbrPortafolioProyecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrPortafolioProyecto) %>
    </div>

    <div class="display-label">descripcionPortafolioProyectos</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionPortafolioProyectos) %>
    </div>
</fieldset>
<br />
<p>
    <%: Html.ActionLink("Edit", "Edit", new { id = Model.idPortafolioProyecto }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
