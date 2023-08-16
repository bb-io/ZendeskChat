using Apps.ZendeskChat.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.ZendeskChat.Models.Request.Chat;

public class ChatRequest
{
    [Display("Chat")]
    [DataSource(typeof(ChatDataHandler))]
    public string ChatId { get; set; }
}