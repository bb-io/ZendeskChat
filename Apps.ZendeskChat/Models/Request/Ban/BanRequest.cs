using Apps.ZendeskChat.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.ZendeskChat.Models.Request.Ban;

public class BanRequest
{
    [Display("Ban")]
    [DataSource(typeof(BanDataHandler))]
    public string BanId { get; set; }
}