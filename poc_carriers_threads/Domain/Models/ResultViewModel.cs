using System;
using Newtonsoft.Json;

namespace poc_carriers_threads.Models
{
	public class ResultViewModel
	{
            [JsonProperty(PropertyName = "status")]
            public string Status { get; set; }

            [JsonProperty(PropertyName = "message")]
            public string Message { get; set; }    

            [JsonProperty(PropertyName = "rowCount")]
            public int RowCount { get; set; }

            [JsonProperty(PropertyName = "data")]
            public object Data { get; set; }
        }    
}

