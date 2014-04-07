<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.EscalaPuntaje>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Escala Puntaje</h2>

<p>
    <%: Html.ActionLink("Crear Nueva Escala Puntaje", "Create") %>
</p>
<table>
    <tr>
        <th>
            Nombre de la Escala
        </th>
        <th>
            Descripcion
        </th>
        <th>
            Valor Minimo
        </th>
        <th>
            Valor Maximo
        </th>
        <th>
            Escala de Probabilidad Asociada
        </th>
        <th>
            Escala de Impacto Asociada
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrEscala) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionEscala) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.valorMinimo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.valorMaximo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.EscalaProbabilidad.nbrEscalaProbabilidad) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.EscalaImpacto.nbrEscalaImpacto) %>
        </td>
        <td>
            <%: Html.ActionLink("Modificar", "Edit", new { id = item.idEscala }) %> |
            <!--<%: Html.ActionLink("Details", "Details", new { id = item.idEscala })%> |-->
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.idEscala } )%> |
            <%: Html.ActionLink("Ver Esc. Probabilidad", "Index", "EscalaProbabilidad", new { id = item.idEscalaProbabilidad_fk }, null)%> |
            <%: Html.ActionLink("Ver Esc. Impacto", "Index", "EscalaImpacto", new { id = item.idEscalaImpacto_fk }, null)%>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
