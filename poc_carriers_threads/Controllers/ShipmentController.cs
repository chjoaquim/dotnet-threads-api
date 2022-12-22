using System.Net;
using Microsoft.AspNetCore.Mvc;
using poc_carriers_threads.Models;
using poc_carriers_threads.services;

namespace poc_carriers_threads.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipmentController : BaseController
{

    private readonly ILogger<ShipmentController> _logger;
    private readonly IShipmentService _service;

    public ShipmentController(ILogger<ShipmentController> logger, IShipmentService service)
    {
        _logger = logger;
        _service = service;
    }

   
    [HttpGet("async/routes/{routeID}/facilities/{facilityID}")]
    public async Task<JsonResult> GetAsync(
        [FromRoute] string routeID,
        [FromRoute] string facilityID,
        [FromQuery(Name = "access_token")] string token)
    {
        _logger.LogInformation("Received request to route", routeID);
        ShipmentsResponse response = new ShipmentsResponse();
        response.Descriptions = new List<string>();
        var result = await _service.GetRouteInformation(routeID, facilityID, token);
        response.Descriptions.AddRange(result.Descriptions);
        return ReturnOperationResult<ShipmentController>(response, "Success", HttpStatusCode.OK, "shipments returned", response.Descriptions.Count);        
    }
}

