using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.ZendeskChat.DataSourceHandlers.EnumHandlers;

public class ChatTypeDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        {"offline_msg", "Offline message"},
        {"chat", "Chat"},
    };
}