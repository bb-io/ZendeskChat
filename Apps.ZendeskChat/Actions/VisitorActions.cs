using Apps.ZendeskChat.Api;
using Apps.ZendeskChat.Constants;
using Apps.ZendeskChat.Models.Dto;
using Apps.ZendeskChat.Models.Request.Visitor;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.ZendeskChat.Actions;

[ActionList]
public class VisitorActions
{
    [Action("Create visitor", Description = "Create a new visitor")]
    public Task<VisitorDto> CreateVisitor(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] CreateVisitorRequest visitor)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest(ApiEndpoints.Visitors, Method.Post, creds)
            .WithJsonBody(visitor);

        return client.ExecuteWithErrorHandling<VisitorDto>(request);
    }

    [Action("Get visitor", Description = "Get details of specific visitor")]
    public Task<VisitorDto> GetVisitor(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] VisitorRequest visitor)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest($"{ApiEndpoints.Visitors}/{visitor.VisitorId}", Method.Get, creds);

        return client.ExecuteWithErrorHandling<VisitorDto>(request);
    }

    [Action("Update visitor", Description = "Update details of specific visitor")]
    public Task<VisitorDto> UpdateVisitor(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] VisitorRequest visitor,
        [ActionParameter] UpdateVisitorRequest input)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest($"{ApiEndpoints.Visitors}/{visitor.VisitorId}", Method.Put, creds)
            .WithJsonBody(input, new()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

        return client.ExecuteWithErrorHandling<VisitorDto>(request);
    }
}