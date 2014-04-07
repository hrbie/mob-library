<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.EscalaProbabilidad>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar Escala de Probabilidad</h2>

<h3>¿Esta seguro que desea eliminar la Escala de Probabilidad?</h3>
<fieldset>
    <legend>Escala de Probabilidad</legend>

        <%: Html.HiddenFor(model => model.idEscalaProbabilidad) %>

        <div class="display-label">Nombre de la Escala de Probabilidad</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.nbrEscalaProbabilidad) %>
        </div>

        <div class="display-label">Descripcion</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.descripcionEscala) %>
        </div>

        <div class="display-label">Valor Minimo</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.valorMinimo) %>
        </div>

        <div class="display-label">Valor Maximo</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.valorMaximo) %>
        </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Volver a la Lista", "Index") %>
    </p>
<% } %>

</asp:Content>
