<%@ Page Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Account.ChangePassword.ChangePassword" Title="Fieldbook - ChangePassword" %>
<%@ Import Namespace="FubuMusicStore.Actions.Account.ChangePassword" %>
<%@ Import Namespace="FubuMusicStore.Actions.Account.Logoff" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
</head>
<body>
    <div class="container_16">
        <div class="prefix_5 grid_6 suffix_5">
            <img src="/content/images/companylogo.png" />
        </div>
        <div class="clear">
        </div>
        <div class="prefix_5 grid_6 suffix_5">
            <div class="mod basic login bg-color8">
                <div class="inner">
                    <div class="hd">
                        <h3 class="hdr-font">
                        </h3>
                    </div>
                    <div class="bd">
                        <%=this.FormFor(new ChangePasswordModel()) %>
                        <%=this.InputFor(x => x.UserName).Hide() %>
                        <%=this.Edit(x => x.OldPassword) %>
                        <%=this.Edit(x => x.Password) %>
                        <%=this.Edit(x => x.ConfirmPassword) %>
                        <div id="validation-summary">
                        </div>
                        <fieldset>
                            <a class="button button-secondary" href="<%= Urls.UrlFor(new LogoffRequest()) %>">
                                <input type="button" name="SubmitButton" value="Cancel" /></a> <a class="button button-secondary f-right">
                                    <input type="submit" value="Submit" /></a>
                        </fieldset>
                        <%=this.EndForm() %>
                    </div>
                </div>
            </div>
            </>
        </div>
    </div>
</body>
</html>
