using System;
namespace poc_carriers_threads.Clients
{
    public class ShipmentResponse
    {
        public PackageResponse Package { get; set; }
    }

    public class PackageResponse
    {
        public List<ItemResponse> Items { get; set; }
    }

    public class ItemResponse
    {
        public string Category { get; set; }
        public string Description { get; set; }
    }
}

