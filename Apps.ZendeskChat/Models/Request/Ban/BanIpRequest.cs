using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Request.Ban;

public class BanIpRequest
{
    [JsonProperty("reason")]
    public string Reason { get; set; }
    
    [JsonProperty("ip_address")]
    [Display("IP address")]
    public string IpAddress { get; set; }
}