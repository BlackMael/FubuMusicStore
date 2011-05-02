<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditAlbum.aspx.cs" Inherits="FubuMusicStore.Actions.api.Albums.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<% this.Script("validation"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%=this.FormFor(Model.Album) %>
    <%=this.Edit(x => x.Album.Name) %>
    <%=this.Edit(x => x.Album.Price) %>
<%=this.EndForm() %>
</asp:Content>
