using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using IdentityTest.App_Start;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartupAttribute(typeof(IdentityTest.Startup))]
namespace IdentityTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
            
        }

        //also in Startup.Auth.cs
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            // clientId: "",
            // clientSecret: "");

            //app.UseTwitterAuthentication(
            // consumerKey: "",
            // consumerSecret: "");

            //app.UseFacebookAuthentication(
            // appId: "",
            // appSecret: "");

            //app.UseGoogleAuthentication();
        }


    }
}