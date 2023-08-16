﻿using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;

namespace Apps.ZendeskChat.OAuth;

public class OAuth2TokenService : IOAuth2TokenService
{

    public bool IsRefreshToken(Dictionary<string, string> values)
    {
        return false;
    }

    public async Task<Dictionary<string, string>> RefreshToken(Dictionary<string, string> values,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Dictionary<string, string?>> RequestToken(
        string state,
        string code,
        Dictionary<string, string> values,
        CancellationToken cancellationToken)
    {
        return values;
    }

    public Task RevokeToken(Dictionary<string, string> values)
    {
        throw new NotImplementedException();
    }
}