<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true"  Inherits="FubuMusicStore.Actions.api.Albums.ListAlbums" %>
<%@ Import Namespace="FubuMusicStore.Actions.api.Albums" %>
<%@ Import Namespace="FubuFastPack.JqGrid" %>
<%@ Import Namespace="HtmlTags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=this.FiltersFor<AlbumGrid>() %>
    <%= new HtmlTag("button",tag => tag.Text("Add").Id("add")) %>
    <%= new HtmlTag("button",tag => tag.Text("Clear").Id("clear")) %>
    <%= new HtmlTag("button",tag => tag.Text("Search").Id("search-criteria-search")) %>
    <%=this.SmartGridFor<AlbumGrid>(null) %>
</asp:Content>
