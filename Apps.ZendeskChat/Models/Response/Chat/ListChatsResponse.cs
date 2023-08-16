using Apps.ZendeskChat.Models.Dto;

namespace Apps.ZendeskChat.Models.Response.Chat;

public record ListChatsResponse(ChatDto[] Chats);