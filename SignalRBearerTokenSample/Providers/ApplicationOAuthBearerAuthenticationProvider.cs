using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;

namespace SignalRBearerTokenSample.Providers
{
    public class ApplicationOAuthBearerAuthenticationProvider 
        : OAuthBearerAuthenticationProvider
    {
        // method copied from Owin.AppBuilderExtensions.ApplicationOAuthBearerProvider (private class)
        public override Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (context.Ticket.Identity.Claims
                .Any(c => c.Issuer != ClaimsIdentity.DefaultIssuer))
            {
                context.Rejected();
            }
            return Task.FromResult<object>(null);
        }

        public override Task RequestToken(OAuthRequestTokenContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            // try to find bearer token in a cookie 
            // (by default OAuthBearerAuthenticationHandler 
            // only checks Authorization header)
            var tokenCookie = context.OwinContext.Request.Cookies["BearerToken"];
            if (!string.IsNullOrEmpty(tokenCookie))
                context.Token = tokenCookie;
            return Task.FromResult<object>(null);
        }

    }
}