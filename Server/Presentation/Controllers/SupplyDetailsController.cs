﻿using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Site.Server.Application;
using Site.Shared.Dto;

namespace Site.Server.Controllers;

[ApiController]
[Route("[Controller]")]
public class SupplyDetailsController : GenericController<SupplyItem>
{
    public SupplyDetailsController(
        ILogger<SuppliesController> logger,
        IOptions<ControllersOptions> options,
        HttpClient httpClient)
        : base(logger, options, httpClient) { }

    [HttpGet("{id:int}")]
    public override async Task<IActionResult> Get(int id)
    {
        var endpoint = new PosterEndpoint($"{_options.Value.Domain}", "storage.getSupplyIngredients", $"{_options.Value.Token}");
        endpoint.AddParam("supply_id", $"{id}");
        string endpointUrl = endpoint.ToString();

        try
        {
            var response = await _httpClient.GetAsync(endpointUrl).ConfigureAwait(false);
            var responseBody = JObject.Parse(await response.Content.ReadAsStringAsync());

            var error = CheckForError(responseBody);
            if (!string.IsNullOrEmpty(error)) return StatusCode(422, error); // Handle the error

            var supplyItems = DeserializeResponse(responseBody["response"]);

            if (response.IsSuccessStatusCode)
            {
                if (supplyItems.IsNullOrEmpty()) NoContent();

                return Ok(supplyItems);
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