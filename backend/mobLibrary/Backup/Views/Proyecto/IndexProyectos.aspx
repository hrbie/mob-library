<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.Proyecto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    IndexProyectos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Proyectos</h2>

<p>
    <!--<% foreach (var item in Model) { %>
    <%: Html.ActionLink("Crear Nuevo Proyecto", "CreateProyecto", new { portafolio = item.idPortafolioProyecto_fk})%>
    <% break;       } %>-->
    <%: Html.ActionLink("Crear Nuevo Proyecto", "CreateProyecto", new { portafolio = TempData["idPortafolio"] })%>
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

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrProyecto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionProyecto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.PortafolioProyectos.nbrPortafolioProyecto)%>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.EscalaPuntaje.nbrEscala)%>
        </td>
        <td>
            <%: Html.ActionLink("Modificar", "Edit", new { id=item.idProyecto, portafolio = item.idPortafolioProyecto_fk}) %> |
        <!--<%: Html.ActionLink("Detalles", "Details", new { id = item.idProyecto, portafolio = item.idPortafolioProyecto_fk})%> |-->
            <%: Html.ActionLink("Eliminar", "Delete", new { id=item.idProyecto, portafolio = item.idPortafolioProyecto_fk }) %> |
            <%: Html.ActionLink("Ver Riesgos", "IndexRiesgos", "Riesgo", new { proyecto = item.idProyecto}, null)%>
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

<div>
    <%: Html.ActionLink("Volver a la lista", "Index","PortafolioProyectos")%>
</div>

</asp:Content>
