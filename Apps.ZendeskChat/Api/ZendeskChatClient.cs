using Apps.ZendeskChat.Constants;
using Apps.ZendeskChat.Models.Response;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.ZendeskChat.Api;

public class ZendeskChatClient : BlackBirdRestClient
{
    public ZendeskChatClient() : base(new()
    {
        BaseUrl = Urls.ApiUrl.ToUri()
    })
    {
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
        return new(error.Description);
    }
}