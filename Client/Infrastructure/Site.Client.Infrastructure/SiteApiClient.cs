using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Site.Shared;

namespace Site.Client.Infrastructure;

public class SiteApiClient
{
    public SiteApiClient(ILogger<SiteApiClient> logger, IOptions<SiteApiOptions> options)
    {
        Logger = logger;
        BaseUrl = options.Value.BaseUrl;
    }

    private ILogger<SiteApiClient> Logger { get; }

    private string BaseUrl { get; }

    public async Task<HttpResponseMessage> MakeRequest(RequestType method, string relativePath, object payload = null)
    {
        var url = BaseUrl + relativePath;
        Logger.LogInformation("Making {Method} request to {Url} with payload: {Payload}", method, url,
            payload); // Log the request details

        using (var client = new HttpClient())
        {
            HttpResponseMessage response = null;
            try
            {
                response = method switch
                {
                    RequestType.Get => await client.GetAsync(url),
                    RequestType.Post => await client.PostAsync(url, SerializePayload(payload)),
                    RequestType.Put => await client.PutAsync(url, SerializePayload(payload)),
                    RequestType.Delete => await client.DeleteAsync(url),
                    _ => null
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Exception occurred while making {Method} request to {Url}", method,
                    url); // Log exceptions
                throw;
            }

            if (response is { IsSuccessStatusCode: true })
            {
                Logger.LogInformation("Successfully received response for {Method} request to {Url}", method,
                    url); // Log successful response
                return response;
            }

            Logger.LogWarning("Failed {Method} request to {Url}. Reason: {Reason}", method, url,
                response.ReasonPhrase); // Log failed response
            throw new Exception($"Request catch exception! Message: {response.ReasonPhrase}");
        }
    }

    private static StringContent SerializePayload(object payload)
    {
        return new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
    }
}