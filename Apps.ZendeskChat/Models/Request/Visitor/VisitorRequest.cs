using Blackbird.Applications.Sdk.Common;

namespace Apps.ZendeskChat.Models.Request.Visitor;

public class VisitorRequest
{
    [Display("Visitor ID")]
    public string VisitorId { get; set; }
}