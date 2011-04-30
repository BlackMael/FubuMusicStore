<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true"  Inherits="FubuMusicStore.Actions.api.Albums.ListAlbums" %>
<%@ Import Namespace="FubuMusicStore.Actions.api.Albums" %>
<%@ Import Namespace="FubuFastPack.JqGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=this.SmartGridFor<AlbumGrid>(null) %>
</asp:Content>
