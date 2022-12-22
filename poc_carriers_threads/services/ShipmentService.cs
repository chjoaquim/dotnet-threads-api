using System.Collections.Concurrent;
using System.Threading;
using poc_carriers_threads.Clients;
using poc_carriers_threads.Domain.Models;
using poc_carriers_threads.Models;
using Dasync.Collections;


namespace poc_carriers_threads.services
{
    
	public class ShipmentService : IShipmentService
	{
        private readonly ILogger<ShipmentService> _logger;
        private readonly IMeliClient _client;
        
        public ShipmentService(ILogger<ShipmentService> logger, IMeliClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<ShipmentsResponse> GetRouteInformation(string routeID, string facilityID, string token)
        {
            try
            {
                var response = await _client.GetRouteInfo(routeID, facilityID, token);
                var shipmentIDs = response?.Shipments.ConvertAll(s => s.ID.ToString());
                if (shipmentIDs == null) {                   
                    return new ShipmentsResponse();
                }

                ShipmentsResponse shipmentsResponse = new ShipmentsResponse();
                shipmentsResponse.Descriptions = new List<string>();

                var bag = new ConcurrentBag<string>();
                await shipmentIDs.ParallelForEachAsync(async id =>
                {
                    _logger.LogInformation("Trying to get shipment by id {0}", id);
                    var shipment = await GetShipment(id, token);
                    var description = shipment?.Package?.Items?.FirstOrDefault()?.Description;
                    bag.Add($"Shipment ID: {id} - Description: {description}");
                    
                }, maxDegreeOfParallelism: 6);
                
                shipmentsResponse.Descriptions.AddRange(bag);
                return shipmentsResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when trying to get shipmentInfo - {0}", ex.Message);
                throw;
            }
        }


        public async Task<Shipment> GetShipment(string routeID, string token)
        {            
            try
            {
                var response = await _client.GetShipmentItem(routeID, token);
                Shipment shipment = new Shipment();
                shipment.Package = new Package();
                shipment.Package.Items = new List<Item>();

                response?.Package?.Items?.ForEach(i =>
                {
                    Item item = new Item();
                    item.Category = i.Category;
                    item.Description = i.Description;

                    shipment.Package.Items.Add(item);
                });
                
                return shipment;
            } catch(Exception ex)
            {
                Shipment shipment = new Shipment();
                shipment.Package = new Package();
                shipment.Package.Items = new List<Item>();
                Item item = new Item();
                item.Category = "error";
                item.Description = $"Error: {ex.Message}";

                shipment.Package.Items.Add(item);
                return shipment;
            }
        }
    }
}

