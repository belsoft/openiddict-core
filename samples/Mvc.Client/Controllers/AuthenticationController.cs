using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Authentication;

namespace Mvc.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet("~/signin")]
        public ActionResult SignIn()
        {
            // Instruct the OIDC client middleware to redirect the user agent to the identity provider.
            // Note: the authenticationType parameter must match the value configured in Startup.cs
            return new ChallengeResult(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = "/"
            });
        }

        [HttpGet("~/signout"), HttpPost("~/signout")]
        public async Task SignOut()
        {
            // Instruct the cookies middleware to delete the local cookie created when the user agent
            // is redirected from the identity provider after a successful authorization flow.
            await HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Instruct the OpenID Connect middleware to redirect the user agent to the identity provider to sign out.
            await HttpContext.Authentication.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
