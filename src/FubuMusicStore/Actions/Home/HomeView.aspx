<%@ Page Inherits="FubuMusicStore.Actions.Home.HomeView" Language="C#" AutoEventWireup="true" %>
<ul id="album-list">
<% foreach (var album in Model.Albums)
{
  %>
  <li><%=album.Name %></li>
  <%
} %>
</ul>