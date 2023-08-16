using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Request.Ban;

public class BanVisitorRequest
{
    [JsonProperty("reason")]
    public string Reason { get; set; }
    
    [JsonProperty("visitor_id")]
    [Display("Visitor ID")]
    public string VisitorId { get; set; }
}