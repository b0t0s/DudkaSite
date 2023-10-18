using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Site.Server.Application;
using Site.Shared.Dto;

namespace Site.Server.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductsController : GenericController<Products>
{
    public ProductsController(
        ILogger<ProductsController> logger,
        IOptions<ControllersOptions> options,
        HttpClient httpClient)
        : base(logger, options, httpClient)
    {
    }

    [HttpGet]
    public override async Task<IActionResult> Get()
    {
        var endpoint = new PosterEndpoint($"{_options.Value.Domain}", "menu.getProducts", $"{_options.Value.Token}").ToString();

        try
        {
            var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);
            var responseBody = JObject.Parse(await response.Content.ReadAsStringAsync());

            var error = CheckForError(responseBody);
            if (!string.IsNullOrEmpty(error)) return StatusCode(422, error); // Handle the error

            var products = DeserializeResponse(responseBody["response"]);

            if (response.IsSuccessStatusCode)
            {
                if (products.IsNullOrEmpty()) NoContent();

                return Ok(products);
            }

            var errorMessage = $"HTTP Status Code: {response.StatusCode}. Reason Phrase: {response.ReasonPhrase}";

            _logger.LogError(errorMessage);

            return StatusCode(500, errorMessage);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError($"HttpRequestException: {e.Message}");

            throw;
        }
        catch (JsonException e)
        {
            _logger.LogError($"JsonException: {e.Message}");

            throw;
        }
        catch (Exception e)
        {
            _logger.LogError($"Exception: {e.Message}");

            throw;
        }
    }

    [HttpGet("{id:int}")]
    public override async Task<IActionResult> Get(int id)
    {
        var endpoint = new PosterEndpoint($"{_options.Value.Domain}", "menu.getProducts", $"{_options.Value.Token}").ToString();

        try
        {
            var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);
            var responseBody = JObject.Parse(await response.Content.ReadAsStringAsync());

            var error = CheckForError(responseBody);
            if (!string.IsNullOrEmpty(error)) return StatusCode(422, error); // Handle the error

            var products = DeserializeResponse(responseBody["response"]).Where(x => x.Id == id).ToList();

            if (response.IsSuccessStatusCode)
            {
                if (products.IsNullOrEmpty()) NoContent();

                return Ok(products);
            }

            var errorMessage = $"HTTP Status Code: {response.StatusCode}. Reason Phrase: {response.ReasonPhrase}";

            _logger.LogError(errorMessage);

            return StatusCode(500, errorMessage);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError($"HttpRequestException: {e.Message}");

            throw;
        }
        catch (JsonException e)
        {
            _logger.LogError($"JsonException: {e.Message}");

            throw;
        }
        catch (Exception e)
        {
            _logger.LogError($"Exception: {e.Message}");

            throw;
        }
    }

    [HttpGet("{category}")]
    public override async Task<IActionResult> Get(string category)
    {
        var endpoint = new PosterEndpoint($"{_options.Value.Domain}", "menu.getProducts", $"{_options.Value.Token}").ToString();

        try
        {
            var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);
            var responseBody = JObject.Parse(await response.Content.ReadAsStringAsync());

            var error = CheckForError(responseBody);
            if (!string.IsNullOrEmpty(error)) return StatusCode(422, error); // Handle the error

            var products = DeserializeResponse(responseBody["response"]).Where(x => x.CategoryName == category)
                .ToList();

            if (response.IsSuccessStatusCode)
            {
                if (products.IsNullOrEmpty()) NoContent();

                return Ok(products);
            }

            var errorMessage = $"HTTP Status Code: {response.StatusCode}. Reason Phrase: {response.ReasonPhrase}";

            _logger.LogError(errorMessage);

            return StatusCode(500, errorMessage);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError($"HttpRequestException: {e.Message}");

            throw;
        }
        catch (JsonException e)
        {
            _logger.LogError($"JsonException: {e.Message}");

            throw;
        }
        catch (Exception e)
        {
            _logger.LogError($"Exception: {e.Message}");

            throw;
        }
    }
}