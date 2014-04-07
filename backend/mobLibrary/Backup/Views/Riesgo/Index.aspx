<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.Riesgo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            idRiesgo
        </th>
        <th>
            nbrRiesgo
        </th>
        <th>
            puntajeRiesgo
        </th>
        <th>
            status
        </th>
        <th>
            Estrategia
        </th>
        <th>
            TipoRiesgo
        </th>
        <th>
            planRespuesta
        </th>
        <th>
            descripcionRiesgo
        </th>
        <th>
            nivelRiesgo
        </th>
        <th>
            Proyecto
        </th>
        <th>
            Usuario
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.idRiesgo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrRiesgo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.puntajeRiesgo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.status) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Estrategia.nbrEstrategia) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoRiesgo.nbrTipoRiesgo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.planRespuesta) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionRiesgo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nivelRiesgo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Proyecto.nbrProyecto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Usuario.nbrUsuario) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id = item.idRiesgo }) %> |
            <%: Html.ActionLink("Calificar", "Dot", new { id = item.idRiesgo }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
