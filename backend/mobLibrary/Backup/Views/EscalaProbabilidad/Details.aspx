<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.EscalaProbabilidad>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>EscalaProbabilidad</legend>

    <div class="display-label">idEscalaProbabilidad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idEscalaProbabilidad) %>
    </div>

    <div class="display-label">nbrEscalaProbabilidad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrEscalaProbabilidad) %>
    </div>

    <div class="display-label">descripcionEscala</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionEscala) %>
    </div>

    <div class="display-label">valorMinimo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.valorMinimo) %>
    </div>

    <div class="display-label">valorMaximo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.valorMaximo) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
