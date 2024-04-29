using Apps.ZendeskChat.Api;
using Apps.ZendeskChat.Constants;
using Apps.ZendeskChat.Invocables;
using Apps.ZendeskChat.Models.Dto;
using Apps.ZendeskChat.Models.Request.Visitor;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.ZendeskChat.Actions;

[ActionList]
public class VisitorActions : ZendeskChatInvocable
{
    public VisitorActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("Create visitor", Description = "Create a new visitor")]
    public Task<VisitorDto> CreateVisitor([ActionParameter] CreateVisitorRequest visitor)
    {
        var request = new ZendeskChatRequest(ApiEndpoints.Visitors, Method.Post, Creds)
            .WithJsonBody(visitor);

        return Client.ExecuteWithErrorHandling<VisitorDto>(request);
    }

    [Action("Get visitor", Description = "Get details of specific visitor")]
    public Task<VisitorDto> GetVisitor([ActionParameter] VisitorRequest visitor)
    {
        var request = new ZendeskChatRequest($"{ApiEndpoints.Visitors}/{visitor.VisitorId}", Method.Get, Creds);

        return Client.ExecuteWithErrorHandling<VisitorDto>(request);
    }

    [Action("Update visitor", Description = "Update details of specific visitor")]
    public Task<VisitorDto> UpdateVisitor(
        [ActionParameter] VisitorRequest visitor,
        [ActionParameter] UpdateVisitorRequest input)
    {
        var request = new ZendeskChatRequest($"{ApiEndpoints.Visitors}/{visitor.VisitorId}", Method.Put, Creds)
            .WithJsonBody(input, new()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

        return Client.ExecuteWithErrorHandling<VisitorDto>(request);
    }
}