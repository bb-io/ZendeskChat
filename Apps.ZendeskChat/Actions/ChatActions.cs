using Apps.ZendeskChat.Api;
using Apps.ZendeskChat.Constants;
using Apps.ZendeskChat.Models.Dto;
using Apps.ZendeskChat.Models.Request.Chat;
using Apps.ZendeskChat.Models.Response.Chat;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.ZendeskChat.Actions;

[ActionList]
public class ChatActions
{
    [Action("List chats", Description = "List all chats")]
    public async Task<ListChatsResponse> ListChats(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest(ApiEndpoints.Chats, Method.Get, creds);

        var response = await client.ExecuteWithErrorHandling<ChatsResponseWrapper>(request);

        return new(response.Chats.ToArray());
    }
    
    [Action("Get chat", Description = "Get specific chat")]
    public Task<ChatDto> GetChat(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ChatRequest chat)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest($"{ApiEndpoints.Chats}/{chat.ChatId}", Method.Get, creds);

        return client.ExecuteWithErrorHandling<ChatDto>(request);
    }
    
    [Action("Create chat", Description = "Create new chat")]
    public Task<ChatDto> CreateChat(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] CreateChatRequest input)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest(ApiEndpoints.Chats, Method.Post, creds)
            .WithJsonBody(input, new()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

        return client.ExecuteWithErrorHandling<ChatDto>(request);
    }   
    
    [Action("Delete chat", Description = "Delete specific chat")]
    public Task DeleteChat(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ChatRequest chat)
    {
        var client = new ZendeskChatClient();
        var request = new ZendeskChatRequest($"{ApiEndpoints.Chats}/{chat.ChatId}", Method.Delete, creds);

        return client.ExecuteWithErrorHandling(request);
    }
}