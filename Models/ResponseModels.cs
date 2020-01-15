using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace CountBetweenTwoDates.API.Models
{
    public class BaseOperationResponse
    {
        public BaseOperationResponse(HttpStatusCode statusCode, List<string> errors)
        {
            Status = (int)statusCode;
            Errors = errors;
        }
        public BaseOperationResponse() { }

        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("errors")]
        public List<string> Errors { get; set; }
    }
}
