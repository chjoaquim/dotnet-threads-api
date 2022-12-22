using System;
namespace poc_carriers_threads.Clients
{
	public class RouteShipmentsResponse
	{
		public string ID { get; set; }
        public int TotalItems { get; set; }
        public List<RouteShipmentResponse> Shipments { get; set; }
    }

    public class RouteShipmentResponse
    {
        public string ID { get; set; }
    }
}
