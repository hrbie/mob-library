<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.EscalaPuntaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>EscalaPuntaje</legend>

    <div class="display-label">idEscala</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idEscala) %>
    </div>

    <div class="display-label">nbrEscala</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrEscala) %>
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

    <div class="display-label">EscalaProbabilidad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EscalaProbabilidad.nbrEscalaProbabilidad) %>
    </div>

    <div class="display-label">EscalaImpacto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EscalaImpacto.nbrEscalaImpacto) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
