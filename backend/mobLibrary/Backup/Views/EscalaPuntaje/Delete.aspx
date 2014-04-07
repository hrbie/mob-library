<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.EscalaPuntaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar la Escala de Puntaje</h2>

<h3>¿Esta seguro que desea borrar la Escala de Puntaje?</h3>
<fieldset>
    <legend>Escala de Puntaje</legend>

    <%: Html.HiddenFor(model => model.idEscala) %>

    <div class="display-label">Nombre de la Escala Puntaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrEscala) %>
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

    <div class="display-label">Escala de Probabilidad asociada</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EscalaProbabilidad.nbrEscalaProbabilidad) %>
    </div>

    <div class="display-label">Escala de Impacto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EscalaImpacto.nbrEscalaImpacto) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Volver a la lista", "Index") %>
    </p>
<% } %>

</asp:Content>
