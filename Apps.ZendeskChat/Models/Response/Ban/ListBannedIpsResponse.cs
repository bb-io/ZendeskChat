using Blackbird.Applications.Sdk.Common;

namespace Apps.ZendeskChat.Models.Response.Ban;

public record ListBannedIpsResponse([property: Display("IPs")] List<string> Ips);