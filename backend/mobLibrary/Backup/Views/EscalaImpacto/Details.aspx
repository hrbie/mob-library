<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.EscalaImpacto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>EscalaImpacto</legend>

    <div class="display-label">idEscalaImpacto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idEscalaImpacto) %>
    </div>

    <div class="display-label">nbrEscalaImpacto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrEscalaImpacto) %>
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
