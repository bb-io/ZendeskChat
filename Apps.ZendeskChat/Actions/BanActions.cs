using Apps.ZendeskChat.Api;
using Apps.ZendeskChat.Constants;
using Apps.ZendeskChat.Invocables;
using Apps.ZendeskChat.Models.Dto;
using Apps.ZendeskChat.Models.Request.Ban;
using Apps.ZendeskChat.Models.Response.Ban;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.ZendeskChat.Actions;

[ActionList]
public class BanActions : ZendeskChatInvocable
{
    public BanActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("List bans", Description = "List all bans")]
    public Task<BansResponseWrapper> ListBans()
    {
        var request = new ZendeskChatRequest(ApiEndpoints.Bans, Method.Get, Creds);

        return Client.ExecuteWithErrorHandling<BansResponseWrapper>(request);
    }

    [Action("List banned IP addresses", Description = "List all banned IP addresses")]
    public async Task<ListBannedIpsResponse> ListBannedIps()
    {
        var request = new ZendeskChatRequest($"{ApiEndpoints.Bans}/ip", Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling<List<string>>(request);

        return new(response);
    }
    
    [Action("Get ban", Description = "Get details of a specific ban")]
    public Task<BanDto> GetBan([ActionParameter] BanRequest ban)
    {
        var request = new ZendeskChatRequest($"{ApiEndpoints.Bans}/{ban.BanId}", Method.Get, Creds);

        return Client.ExecuteWithErrorHandling<BanDto>(request);
    }
    
    [Action("Ban visitor", Description = "Ban specific visitor")]
    public Task<BanDto> BanVisitor([ActionParameter] BanVisitorRequest input)
    {
        var request = new ZendeskChatRequest(ApiEndpoints.Bans, Method.Post, Creds)
            .WithJsonBody(input);

        return Client.ExecuteWithErrorHandling<BanDto>(request);
    }
    
    [Action("Ban IP", Description = "Ban specific IP address")]
    public Task<BanDto> BanIp([ActionParameter] BanIpRequest input)
    {
        var request = new ZendeskChatRequest(ApiEndpoints.Bans, Method.Post, Creds)
            .WithJsonBody(input);

        return Client.ExecuteWithErrorHandling<BanDto>(request);
    }
    
    [Action("Delete ban", Description = "Delete specific ban")]
    public Task DeleteBan([ActionParameter] BanRequest ban)
    {
        var request = new ZendeskChatRequest($"{ApiEndpoints.Bans}/{ban.BanId}", Method.Delete, Creds);

        return Client.ExecuteWithErrorHandling(request);
    }
}