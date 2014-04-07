<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.EscalaPuntaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Modificar la Escala de Puntaje</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Escala de Puntaje</legend>

        <%: Html.HiddenFor(model => model.idEscala) %>

         <div class="display-label">Nombre de la Escala Puntaje</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrEscala) %>
            <%: Html.ValidationMessageFor(model => model.nbrEscala) %>
        </div>

        <div class="display-label">Descripcion</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionEscala) %>
            <%: Html.ValidationMessageFor(model => model.descripcionEscala) %>
        </div>

        <!--<div class="display-label">Valor Minimo</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.valorMinimo) %>
            <%: Html.ValidationMessageFor(model => model.valorMinimo) %>
        </div>

        <div class="display-label">Valor Maximo</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.valorMaximo) %>
            <%: Html.ValidationMessageFor(model => model.valorMaximo) %>
        </div>-->

        <div class="display-label">Escala Probabilidad Asociada</div>
        <div class="editor-field">
            <%: Html.DropDownList("idEscalaProbabilidad_fk") %>
            <%: Html.ValidationMessageFor(model => model.idEscalaProbabilidad_fk) %>
        </div>

        <div class="display-label">Escala Impacto Asociada</div>
        <div class="editor-field">
            <%: Html.DropDownList("idEscalaImpacto_fk") %>
            <%: Html.ValidationMessageFor(model => model.idEscalaImpacto_fk) %>
        </div>

        <p>
            <input type="submit" value="Guardar los Cambios" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Volver a la lista", "Index") %>
</div>

</asp:Content>
