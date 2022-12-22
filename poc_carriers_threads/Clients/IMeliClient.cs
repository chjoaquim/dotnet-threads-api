using System;
using Newtonsoft.Json.Linq;

namespace poc_carriers_threads.Clients
{
	public interface IMeliClient
    {
        Task<RouteShipmentsResponse?> GetRouteInfo(string routeID, string facilityID, string token);
        Task<ShipmentResponse?> GetShipmentItem(string shipmentID, string token);
    }
}

