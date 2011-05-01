using System;
using System.Collections.Generic;
using System.Web.Routing;
using FubuFastPack.Persistence;
using FubuFastPack.StructureMap;
using FubuMusicStore.Domain;
using FubuMusicStore.Membership.Services;
using FubuMVC.Core;
using StructureMap;

namespace FubuMusicStore
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            FubuApplication.For<FubuMusicStoreRegistry>()
                .ContainerFacility(() =>
                                       {
                                           var container = DatabaseDriver.BootstrapContainer();

                                           return new TransactionalStructureMapContainerFacility(container);
                                       })
                .Packages(x => x.Assembly(typeof (IRepository).Assembly))
                .Bootstrap(RouteTable.Routes);
        

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }


}