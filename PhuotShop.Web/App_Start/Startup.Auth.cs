﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PhuotShop.Data;
using PhuotShop.Model.Models;
using System;

[assembly: OwinStartup(typeof(PhuotShop.Web.App_Start.Startup))]

namespace PhuotShop.Web.App_Start
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(PhuotShopDbContext.Create);

            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            //app.CreatePerOwinContext<UserManager<ApplicationUser>>(CreateManager);

            //app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/oauth/token"),
            //    Provider = new AuthorizationServerProvider(),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
            //    AllowInsecureHttp = true,
            //});
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/dang-nhap.html"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager, DefaultAuthenticationTypes.ApplicationCookie))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "1724156397871880",
            //   appSecret: "398039cc7588d52f87a7adcefecc3210");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "712161982861-4d9bdgfvf6pti1vviifjogopqdqlft56.apps.googleusercontent.com",
            //    ClientSecret = "T0cgiSG6Gi7BKMr-fCCkdErO"
            //});
        }
    }
}