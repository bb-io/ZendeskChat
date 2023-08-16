using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Request.Visitor;

public class UpdateVisitorRequest
{
    [JsonProperty("phone")]
    public string? Phone { get; set; }

    [JsonProperty("notes")]
    public string? Notes { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }
}