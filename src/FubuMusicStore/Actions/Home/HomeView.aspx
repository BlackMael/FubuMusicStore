<%@ Page Inherits="FubuMusicStore.Actions.Home.HomeView" Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/Home.Master" %>
<asp:Content ContentPlaceHolderID="HomeContent" runat="server">


<ul id="album-list">
<% foreach (var album in Model.Albums)
{
  %>
  <li><%=album.Name %></li>
  <%
} %>
</ul>
</asp:Content>