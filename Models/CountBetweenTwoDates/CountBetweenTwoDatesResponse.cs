using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace CountBetweenTwoDates.API.Models.CountBetweenTwoDates
{
    public class CountBetweenTwoDatesResponse : BaseOperationResponse
    {
        public CountBetweenTwoDatesResponse(HttpStatusCode statusCode, List<string> errors) : base(statusCode, errors) { }
        public CountBetweenTwoDatesResponse() : base() { }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("entityUrl")]
        public string EntityUrl { get; set; }
    }
}
