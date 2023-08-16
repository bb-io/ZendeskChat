using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Response.Ban;

public class IpBan
{
    [JsonProperty("created_at")]
    [Display("Created at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("id")]
    [Display("ID")]
    public string Id { get; set; }

    [JsonProperty("ip_address")]
    [Display("IP address")]
    public string IpAddress { get; set; }

    [JsonProperty("reason")]
    [Display("Reason")]
    public string Reason { get; set; }

    [JsonProperty("type")]
    [Display("Type")]
    public string Type { get; set; }
}