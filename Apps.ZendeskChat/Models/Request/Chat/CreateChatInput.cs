using Blackbird.Applications.Sdk.Common;

namespace Apps.ZendeskChat.Models.Request.Chat;

public class CreateChatInput
{
    public string Message { get; set; }

    [Display("Visitor ID")] public string Id { get; set; }

    [Display("Visitor notes")] public string Notes { get; set; }

    [Display("Visitor name")] public string Name { get; set; }

    [Display("Visitor email")] public string Email { get; set; }

    [Display("Visitor phone")] public string? Phone { get; set; }

    public long? Timestamp { get; set; }
}