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
public class SuppliesController : GenericController<Supply>
{
    public SuppliesController(
        ILogger<SuppliesController> logger,
        IOptions<ControllersOptions> options,
        HttpClient httpClient)
        : base(logger, options, httpClient) { }

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

            var supplies = DeserializeResponse(responseBody["response"]);

            if (response.IsSuccessStatusCode)
            {
                if (supplies.IsNullOrEmpty()) return NoContent();

                return Ok(supplies);
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