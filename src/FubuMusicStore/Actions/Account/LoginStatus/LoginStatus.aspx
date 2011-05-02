<%@ Page Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Account.LoginStatus.LoginStatus" Title="Fieldbook - LoginStatus"%>

<%@ Import Namespace="FubuMusicStore.Actions.Account.Login" %>
     <%if ( Model.IsAuthenticated)
          {%>
    <a class="menu-button menu-nav-item">
        <span><%= Model.UserName%></span><div class="loginarrow">e</div>
    </a>
     <%
            }
          else
          {%>
       <a class="" href="<%=Urls.UrlFor(new LoginRequest()) %>"><span>Login</span></a>
        <%}%>
