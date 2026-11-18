using Apps.ZendeskChat.Api;
using Apps.ZendeskChat.Constants;
using Apps.ZendeskChat.Invocables;
using Apps.ZendeskChat.Models.Dto;
using Apps.ZendeskChat.Models.Request.Chat;
using Apps.ZendeskChat.Models.Response.Chat;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.ZendeskChat.Actions;

[ActionList]
public class ChatActions : ZendeskChatInvocable
{
    public ChatActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List chats", Description = "List all chats")]
    public async Task<ListChatsResponse> ListChats()
    {
        var request = new ZendeskChatRequest(ApiEndpoints.Chats, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling<ChatsResponseWrapper>(request);

        return new(response.Chats.ToArray());
    }

    [Action("Get chat", Description = "Get specific chat")]
    public Task<ChatDto> GetChat([ActionParameter] ChatRequest chat)
    {
        var request = new ZendeskChatRequest($"{ApiEndpoints.Chats}/{chat.ChatId}", Method.Get, Creds);

        return Client.ExecuteWithErrorHandling<ChatDto>(request);
    }

    [Action("Create chat", Description = "Create new chat")]
    public Task<ChatDto> CreateChat([ActionParameter] CreateChatInput input)
    {
        var request = new ZendeskChatRequest(ApiEndpoints.Chats, Method.Post, Creds)
            .WithJsonBody(new CreateChatRequest(input), new()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

        return Client.ExecuteWithErrorHandling<ChatDto>(request);
    }

    [Action("Delete chat", Description = "Delete specific chat")]
    public Task DeleteChat([ActionParameter] ChatRequest chat)
    {
        var request = new ZendeskChatRequest($"{ApiEndpoints.Chats}/{chat.ChatId}", Method.Delete, Creds);

        return Client.ExecuteWithErrorHandling(request);
    }
}