<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Riesgo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Riesgo</legend>

    <div class="display-label">idRiesgo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idRiesgo) %>
    </div>

    <div class="display-label">nbrRiesgo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrRiesgo) %>
    </div>

    <div class="display-label">puntajeRiesgo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.puntajeRiesgo) %>
    </div>

    <div class="display-label">status</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.status) %>
    </div>

    <div class="display-label">Estrategia</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Estrategia.nbrEstrategia) %>
    </div>

    <div class="display-label">TipoRiesgo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TipoRiesgo.nbrTipoRiesgo) %>
    </div>

    <div class="display-label">planRespuesta</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.planRespuesta) %>
    </div>

    <div class="display-label">descripcionRiesgo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionRiesgo) %>
    </div>

    <div class="display-label">nivelRiesgo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nivelRiesgo) %>
    </div>

    <div class="display-label">Proyecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Proyecto.nbrProyecto) %>
    </div>

    <div class="display-label">Usuario</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Usuario.nbrUsuario) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
