using Apps.ZendeskChat.Api;
using Apps.ZendeskChat.Constants;
using Apps.ZendeskChat.Models.Dto;
using Apps.ZendeskChat.Models.Request.Ban;
using Apps.ZendeskChat.Models.Response.Ban;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.ZendeskChat.Actions;

[ActionList]
public class BanActions
{
    [Action("List bans", Description = "List all bans")]
    public Task<BansResponseWrapper> ListBans(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest(ApiEndpoints.Bans, Method.Get, creds);

        return client.ExecuteWithErrorHandling<BansResponseWrapper>(request);
    }

    [Action("List banned IP addresses", Description = "List all banned IP addresses")]
    public async Task<ListBannedIpsResponse> ListBannedIps(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest($"{ApiEndpoints.Bans}/ip", Method.Get, creds);

        var response = await client.ExecuteWithErrorHandling<List<string>>(request);

        return new(response);
    }
    
    [Action("Get ban", Description = "Get details of a specific ban")]
    public Task<BanDto> GetBan(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] BanRequest ban)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest($"{ApiEndpoints.Bans}/{ban.BanId}", Method.Get, creds);

        return client.ExecuteWithErrorHandling<BanDto>(request);
    }
    
    [Action("Ban visitor", Description = "Ban specific visitor")]
    public Task<BanDto> BanVisitor(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] BanVisitorRequest input)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest(ApiEndpoints.Bans, Method.Post, creds)
            .WithJsonBody(input);

        return client.ExecuteWithErrorHandling<BanDto>(request);
    }
    
    [Action("Ban IP", Description = "Ban specific IP address")]
    public Task<BanDto> BanIp(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] BanIpRequest input)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest(ApiEndpoints.Bans, Method.Post, creds)
            .WithJsonBody(input);

        return client.ExecuteWithErrorHandling<BanDto>(request);
    }
    
    [Action("Delete ban", Description = "Delete specific ban")]
    public Task DeleteBan(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] BanRequest ban)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest($"{ApiEndpoints.Bans}/{ban.BanId}", Method.Delete, creds);

        return client.ExecuteWithErrorHandling(request);
    }
}