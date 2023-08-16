using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Dto;

public class BanDto
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

    [JsonProperty("visitor_id")]
    [Display("Visitor ID")]
    public string VisitorId { get; set; }

    [JsonProperty("visitor_name")]
    [Display("Visitor name")]
    public string VisitorName { get; set; }
}