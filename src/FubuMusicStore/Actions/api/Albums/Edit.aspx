<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditAlbum.aspx.cs" Inherits="FubuMusicStore.Actions.api.Albums.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<% this.Script("validation"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--<%=this.FormFor(Model) %>--%>
<form action="/api/albums?fubudebug=true" method="post">
    <%=this.Edit(x => x.Album.Name).AlterBody(tag => tag.AddClass("required")) %>
    <%=this.Edit(x => x.Album.Price).AlterBody(tag => tag.AddClass("required"))%>
    <%=this.Edit(x => x.Album.Slug).AlterBody(tag => tag.AddClass("required"))%>
    <%=this.Edit(x => x.Album.ArtSmall).AlterBody(tag => tag.AddClass("required"))%>
    <%=this.Edit(x => x.Album.ArtMedium).AlterBody(tag => tag.AddClass("required"))%>
    <%=this.Edit(x => x.Album.ArtLarge).AlterBody(tag => tag.AddClass("required"))%>
    <input type="submit" value="Save" />
<%=this.EndForm() %>
</asp:Content>
