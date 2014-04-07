<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.Usuario>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Register","Account") %>
</p>
<table>
    <tr>
        <th>
            idUsuario
        </th>
        <th>
            nbrUsuario
        </th>
        <th>
            apellido1
        </th>
        <th>
            apellido2
        </th>
        <th>
            email
        </th>
        <th>
            telefono
        </th>
        <th>
            Rol
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.idUsuario) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrUsuario) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.apellido1) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.apellido2) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.email) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.telefono) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Rol.nbrRol) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id = item.idUsuario }) %> |                 
            <%: Html.ActionLink("Delete", "Delete", new { id = item.idUsuario })%> |
            <%: Html.ActionLink("Cambiar Contraseña", "ChangePassword", "Account", new { id = item.idUsuario },null)%>
           
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
