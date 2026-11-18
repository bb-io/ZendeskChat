using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Request.Chat;

public class CreateChatRequest
{
    [JsonProperty("visitor")] public VisitorData Visitor { get; set; }

    [JsonProperty("message")] public string Message { get; set; }

    [JsonProperty("type")] public string Type = "offline_msg";

    [JsonProperty("timestamp")] public long? Timestamp { get; set; }

    [JsonProperty("session")] public SessionData Session { get; set; } = new();

    public CreateChatRequest(CreateChatInput input)
    {
        Message = input.Message;
        Timestamp = input.Timestamp;
        Visitor = new VisitorData()
        {
            Name = input.Name,
            Id = input.Id,
            Email = input.Email,
            Notes = input.Notes,
            Phone = input.Phone
        };
    }
}