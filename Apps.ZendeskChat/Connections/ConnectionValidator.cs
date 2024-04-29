using Apps.ZendeskChat.Api;
using Apps.ZendeskChat.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.ZendeskChat.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
    {
        var client = new ZendeskChatClient();

        var request = new ZendeskChatRequest(ApiEndpoints.Chats, Method.Get, authProviders);
        await client.ExecuteWithErrorHandling(request);

        return new()
        {
            IsValid = true
        };
    }
}