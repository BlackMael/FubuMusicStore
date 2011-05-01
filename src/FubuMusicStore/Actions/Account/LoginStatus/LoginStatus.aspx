<%@ Page Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Account.LoginStatus.LoginStatus" Title="Fieldbook - LoginStatus"%>

<%@ Import Namespace="FubuMusicStore.Actions.Account.ChangePassword" %>
<%@ Import Namespace="FubuMusicStore.Actions.Account.Login" %>
<ul id="user-menu" class="menu-nav rootVoices">
    <li class="rootVoice" menu="user_menu">
       
     <%if ( Model.IsAuthenticated)
          {%>
    <a class="menu-button menu-nav-item">
        <span><%= Model.UserName%></span><div class="loginarrow">e</div>
    </a>
     <%
            }
          else
          {%>
       <a class="menu-button menu-nav-item" href="<%=Urls.UrlFor(new LoginRequest()) %>"><span>Login</span></a>
        <%}%>
    </li>
</ul>
<div id="user_menu" class="menu">
    <a class="" href="<%=Urls.UrlFor(new ChangePasswordRequest()) %>">
        <span>Change Password</span>
    </a>
    <a class="" href="<%= Model.RawUrl %>">
        <span><%= Model.IsAuthenticated ? "Log Off" : "Log In"%></span>
    </a> 
</div>
