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
public class OrdersController : GenericController<Orders>
{
    public OrdersController(
        ILogger<OrdersController> logger,
        IOptions<ControllersOptions> options,
        HttpClient httpClient)
        : base(logger, options, httpClient)
    {
        _baseEndpointUrl =
            $"https://{_options.Value.Domain}.joinposter.com/api/menu.getOrders?format=json&token={_options.Value.Token}";
    }

    private string _baseEndpointUrl { get; }

    [HttpGet]
    public override async Task<IActionResult> Get()
    {
        var endpoint = new PosterEndpoint($"{_options.Value.Domain}", "storage.getSupplies", $"{_options.Value.Token}").ToString();

        try
        {
            var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);
            var responseBody = JObject.Parse(await response.Content.ReadAsStringAsync());

            var error = CheckForError(responseBody);
            if (!string.IsNullOrEmpty(error)) return StatusCode(422, error); // Handle the error

            var orders = DeserializeResponse(responseBody["response"]);

            if (response.IsSuccessStatusCode)
            {
                if (orders.IsNullOrEmpty()) return NoContent();

                return Ok(orders);
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