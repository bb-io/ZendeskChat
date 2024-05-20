using System.Web;
using Apps.ZendeskChat.Constants;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.String;

namespace Apps.ZendeskChat.OAuth;

public class OAuth2AuthorizeService : BaseInvocable, IOAuth2AuthorizeService
{
    public OAuth2AuthorizeService(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public string GetAuthorizationUrl(Dictionary<string, string> values)
    {
        var parameters = new Dictionary<string, string>
        {
            { "client_id", ApplicationConstants.ClientId },
            { "redirect_uri", HttpUtility.UrlEncode(InvocationContext.UriInfo.ImplicitGrantRedirectUri.ToString()) },
            { "response_type", "token" },
            { "subdomain", values[CredsNames.Subdomain] },
            { "scope", HttpUtility.UrlEncode(ApplicationConstants.Scope) }
        };

        return Urls.OAuthUrl.WithQuery(parameters);
    }
}