using System.Collections.Generic;

namespace CountBetweenTwoDates.BusinessLogics.Models
{
    public class LogicResponse<T> : LogicResponse
    {
        public T Data { get; set; }
    }

    public class LogicResponse
    {
        public bool Success { get; set; }
        public int EntityID { get; set; }
        public List<string> Errors { get; set; }
    }
}
