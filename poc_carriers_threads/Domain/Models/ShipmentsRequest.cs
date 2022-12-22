using System;
using Microsoft.AspNetCore.Mvc;

namespace poc_carriers_threads.Models
{    
    public class ShipmentsRequest
	{
        [FromBody]
        public string Route { get; set; }
        [FromBody]
        public string Type { get; set; }
	}
}

