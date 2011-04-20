<%@ Page AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Store.StoreIndexView" Language="C#" MasterPageFile="~/Shared/Store.Master" %>
<%@ Import Namespace="FubuMusicStore.Actions.Partials" %>

<asp:Content ContentPlaceHolderID="LeftPane" runat="server">
<% this.PartialFor(new GenreListRequest()); %>
</asp:Content>

<asp:Content ContentPlaceHolderID="RightPane" runat="server">

</asp:Content>