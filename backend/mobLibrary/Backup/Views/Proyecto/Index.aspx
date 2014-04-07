<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.Proyecto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Proyectos</h2>

<p>
    <%: Html.ActionLink("Crear Nuevo Proyecto", "Create") %>
</p>
<table>
    <%if (Model.Count() != 0)
      { %>
    <tr>
        <th>
            Nombre del Proyecto
        </th>
        <th>
            Descripción
        </th>
        <th>
            Portafolio de Proyectos al que pertenece
        </th>
        <th>
            Escala Puntaje
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model)
   { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrProyecto)%>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionProyecto)%>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.PortafolioProyectos.nbrPortafolioProyecto)%>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.EscalaPuntaje.nbrEscala)%>
        </td>
        <td>
            <%: Html.ActionLink("Modificar", "Edit", new { id = item.idProyecto })%> |
        <!--<%: Html.ActionLink("Detalles", "Details", new { id=item.idProyecto })%> |-->
            <%: Html.ActionLink("Elminar", "Delete", new { id = item.idProyecto })%> | 
            <%: Html.ActionLink("Ver Riesgos", "IndexRiesgos", "Riesgo", new { proyecto = item.idProyecto }, null)%>
        </td>
    </tr>
<% } %>
<% } else { %>
  <tr>
        <th>
            <%: ViewBag.mensajeProyecto %>
        </th>
    </tr>
 <% } %>

</table>

</asp:Content>
