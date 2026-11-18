using Apps.ZendeskChat.Api;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.ZendeskChat.Invocables;

public class ZendeskChatInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected ZendeskChatClient Client { get; }

    public ZendeskChatInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }
}