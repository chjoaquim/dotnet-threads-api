using System;
using Newtonsoft.Json;

namespace poc_carriers_threads.Clients
{
    public class MeliClient : IMeliClient
    {
        private ILogger<MeliClient> _logger;
        private HttpClient _client;
        private const string baseUrl = "https://api.mercadolibre.com/shipping/fiscal/MLM/";

        public MeliClient(ILogger<MeliClient> logger)
        {
            _logger = logger;            
            _client = new HttpClient();

            _client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<RouteShipmentsResponse?> GetRouteInfo(string routeID, string facilityID, string token)
        {
            try
            {
                string path = $"routes/{routeID}/middle-mile/facilities/{facilityID}/details?access_token={token}";
                var response = await _client.GetAsync(path);
                var responseJson = await response.Content.ReadAsStringAsync();
                var routeResponse = JsonConvert.DeserializeObject<RouteShipmentsResponse>(responseJson);

                return routeResponse;
            } catch (Exception ex)
            {
                _logger.LogError("Error when trying to feth route api. Err: {0}", ex.Message);
                throw;
            }            
        }

       public async Task<ShipmentResponse?> GetShipmentItem(string shipmentID, string token)
        {
            try
            {
                string path = $"shipments/{shipmentID}/items/details?item_source=shipment&access_token={token}";
                var response = await _client.GetAsync(path);
                var responseJson = await response.Content.ReadAsStringAsync();
                var shipmentResponse = JsonConvert.DeserializeObject<ShipmentResponse>(responseJson);

                return shipmentResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when trying to feth shipment api. Err: {0}", ex.Message);
                throw;
            }
        }
    }
}

