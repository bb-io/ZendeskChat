using Apps.ZendeskChat.Models.Dto;

namespace Apps.ZendeskChat.Models.Response.Chat;

public class ChatsResponseWrapper
{
    public IEnumerable<ChatDto> Chats { get; set; }
}