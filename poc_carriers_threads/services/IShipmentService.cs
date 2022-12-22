using System;
using poc_carriers_threads.Clients;
using poc_carriers_threads.Domain.Models;
using poc_carriers_threads.Models;

namespace poc_carriers_threads.services
{
	public interface IShipmentService
	{
        Task<ShipmentsResponse> GetRouteInformation(string routeID, string facilityID, string token);
        Task<Shipment> GetShipment(string routeID, string token);
    }
}

