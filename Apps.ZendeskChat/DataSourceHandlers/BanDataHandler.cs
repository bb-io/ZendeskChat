using Apps.ZendeskChat.Api;
using Apps.ZendeskChat.Constants;
using Apps.ZendeskChat.Models.Response.Ban;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.ZendeskChat.DataSourceHandlers;

public class BanDataHandler : BaseInvocable, IAsyncDataSourceHandler
{
    private IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;

    public BanDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest(ApiEndpoints.Bans, Method.Get, Creds);

        var response = await client.ExecuteWithErrorHandling<BansResponseWrapper>(request);

        var ipBans = response.IpBans.ToDictionary(x => x.Id, x => $"{x.IpAddress}: {x.Reason}");
        var visitorBans = response.VisitorBans.ToDictionary(x => x.Id, x => $"{x.VisitorName}: {x.Reason}");
      
        return ipBans
            .Concat(visitorBans)
            .Where(x => context.SearchString == null ||
                        x.Value.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Take(20)
            .ToDictionary(x => x.Key, x => x.Value);
    }
}