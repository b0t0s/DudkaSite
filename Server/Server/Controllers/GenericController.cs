using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Site.Server.Application;
using Site.Shared;

namespace Site.Server.Controllers;

public abstract class GenericController<T> : ControllerBase
{
    public GenericController(
        ILogger logger,
        IOptions<ControllersOptions> options,
        HttpClient httpClient)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    protected ILogger _logger { get; }
    protected IOptions<ControllersOptions> _options { get; }
    protected HttpClient _httpClient { get; }

    // Common methods for all controllers

    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        return Ok(null);
    }

    [HttpGet("{id:int}")]
    public virtual async Task<IActionResult> Get(int id)
    {
        return Ok(null);
    }

    [HttpGet("{name}")]
    public virtual async Task<IActionResult> Get(string name)
    {
        return Ok(null);
    }

    protected List<T> DeserializeResponse(JToken responseBody)
    {
        if (responseBody == null)
        {
            _logger.LogError("Response body is null.");
            return new List<T>();
        }

        try
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new BoolConverter());
            settings.Converters.Add(new StringToNumericConverter());

            var response = responseBody.ToObject<List<T>>(JsonSerializer.Create(settings));
            return response;
        }
        catch (JsonException je)
        {
            _logger.LogError($"JsonException during deserialization: {je.Message}");
            return new List<T>();
        }
    }

    public string CheckForError(JToken responseBody)
    {
        if (responseBody == null)
        {
            _logger.LogError("Response body is null.");
            return "Response body is null.";
        }

        try
        {
            // Check if the response contains an error
            if (responseBody["error"] != null && responseBody["error"].HasValues)
            {
                var errorCode = responseBody["error"]["code"].Value<int>();
                var errorMessage = responseBody["error"]["message"].Value<string>();

                var error = $"Poster Error Code: {errorCode}. Message: {errorMessage}";

                _logger.LogError(error);

                return error;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception in CheckForError: {ex.Message}");
            return $"Unexpected error: {ex.Message}";
        }

        return string.Empty;
    }
}
