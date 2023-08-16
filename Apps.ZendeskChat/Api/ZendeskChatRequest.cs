using Apps.ZendeskChat.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using RestSharp;

namespace Apps.ZendeskChat.Api;

public class ZendeskChatRequest : BlackBirdRestRequest
{
    public ZendeskChatRequest(string resource, Method method, IEnumerable<AuthenticationCredentialsProvider> creds) : base(resource, method, creds)
    {
    }

    protected override void AddAuth(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var token = creds.Get(CredsNames.Token);
        this.AddHeader("Authorization", $"Bearer {token.Value}");
    }
}