using System;
namespace poc_carriers_threads.Domain.Models
{
	public class Shipment
	{
        public Package Package { get; set; }

    }

    public class Package
    {
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string Category { get; set; }
        public string Description { get; set; }
    }
}


