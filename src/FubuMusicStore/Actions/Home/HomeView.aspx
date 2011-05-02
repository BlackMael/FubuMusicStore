<%@ Page Inherits="FubuMusicStore.Actions.Home.HomeView" Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/Home.Master" %>
<%@ Import Namespace="FubuMusicStore.Actions.Home" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.album-covers .album').first().show();
            $('.track-names-home li:first').addClass('select');
            $('.track-names-home li').click(function () {
                $('.album-covers .album:visible').hide();
                $('.track-names-home .select').removeClass('select');
                $(this).addClass('select');
                var art = $('.album-covers .album')[$(this).index()];
                $(art).show();
            });
        });
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="HomeContent" runat="server">
<div class="stripe"></div>
<div class="grid_12">
    <div class="mod home-box bg-color0">
        <div class="bd content bg-color4">
            <div class="grid_8 alpha omega" >
                <div class="album-covers">
                    <%= this.PartialForEach(x => x.Tracks).Using<HomeAlbumArtControl>() %>
                </div>
            </div>
            <div class="grid_4 omega alpha">
                <ul class="track-names-home">
                   <%= this.PartialForEach(x => x.Tracks).Using<HomeTrackNameControl>() %>
                </ul>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</div>
</asp:Content>
