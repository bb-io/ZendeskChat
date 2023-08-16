using Apps.ZendeskChat.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Request.Chat;

public class CreateChatRequest
{
    [JsonProperty("visitor")]
    public VisitorData Visitor { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("type")]
    [DataSource(typeof(ChatTypeDataHandler))]
    public string Type { get; set; }

    [JsonProperty("timestamp")]
    public long? Timestamp { get; set; }

    [JsonProperty("session")] public SessionData Session { get; set; } = new();
}