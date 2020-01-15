using CountBetweenTwoDates.API.Configurations;
using CountBetweenTwoDates.API.Models.CountBetweenTwoDates;
using CountBetweenTwoDates.BusinessLogics.Interfaces;
using CountBetweenTwoDates.BusinessLogics.Models;
using CountBetweenTwoDates.BusinessLogics.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace CountBetweenTwoDates.API.Controllers
{
    [ApiController]
    [Produces(ApiBaseRouteConfig.ControllerProduces)]
    [Route(ApiBaseRouteConfig.ControllerRoute)]
    public class CountBetweenTwoDatesController : Controller
    {
        ICountBetweenTwoDatesBC _countBetweenTwoDatesBC;

        public CountBetweenTwoDatesController(ICountBetweenTwoDatesBC countBetweenTwoDatesBC) 
        {
            _countBetweenTwoDatesBC = countBetweenTwoDatesBC;
        }

        [HttpGet("user")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(new { name = "Test" });
        }

        [HttpPost("weekdays/{firstDate}/{secondDate}")]
        public IActionResult GetCountWeekdays(DateTime firstDate, DateTime secondDate)
        {
            LogicResponse<DataCountBetweenTwoDates> logicResponse = _countBetweenTwoDatesBC.GetCountWeekdays<DataCountBetweenTwoDates>(firstDate, secondDate);
            if (logicResponse.Success)
                return Ok(new { Results = logicResponse.Data.Result });
            else
                return StatusCode (500, $"Error: {logicResponse.Errors}");
        }

        [HttpPost("businessDays/{firstDate}/{secondDate}")]
        public IActionResult GetCountBusinessDays(DateTime firstDate, DateTime secondDate, [FromBody]dynamic publicHolidays)
        {
            List<DateTime> dateList = null;
            if (publicHolidays != null && publicHolidays.Count > 0)
                dateList = JsonConvert.DeserializeObject<List<DateTime>>(publicHolidays.ToString());

            LogicResponse<DataCountBetweenTwoDates> logicResponse = _countBetweenTwoDatesBC.GetCountBusinessDays<DataCountBetweenTwoDates>(firstDate, secondDate, dateList);
            if (logicResponse.Success)
                return Ok(new { Results = logicResponse.Data.Result });
            else
                return StatusCode(500, $"Error: {logicResponse.Errors}");
        }

    }
}