using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Response.Ban;

public class BansResponseWrapper
{
    [JsonProperty("ip_address")]
    [Display("IP bans")]
    public List<IpBan> IpBans { get; set; }
    
    [JsonProperty("visitor")]
    [Display("Visitor bans")]
    public List<VisitorBan> VisitorBans { get; set; }
}