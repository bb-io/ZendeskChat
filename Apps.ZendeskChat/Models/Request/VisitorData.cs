using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Request;

public class VisitorData
{
    [JsonProperty("id")]
    [Display("Visitor ID")]
    public string Id { get; set; }
    
    [JsonProperty("phone")]
    [Display("Visitor phone")]
    public string? Phone { get; set; }
    
    [JsonProperty("notes")]
    [Display("Visitor notes")]
    public string Notes { get; set; }

    [JsonProperty("name")]
    [Display("Visitor name")]
    public string Name { get; set; }

    [JsonProperty("email")]
    [Display("Visitor email")]
    public string Email { get; set; }
}