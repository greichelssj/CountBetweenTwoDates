using System;
using Xunit;
using CountBetweenTwoDates.API.Controllers;
using CountBetweenTwoDates.BusinessLogics.Interfaces;
using System.Linq;
using System.Collections.Generic;
using CountBetweenTwoDates.BusinessLogics.Logics.Base;
using CountBetweenTwoDates.BusinessLogics.Models.Data;

namespace CountBetweenTwoDates.XUnit
{
    public class UnitTestAPI
    {
        [Theory]
        [InlineData("2019-10-07", "2019-10-09", "1")]
        [InlineData("2019-10-05", "2019-10-14", "5")]
        [InlineData("2019-10-07", "2020-01-01", "61")]
        [InlineData("2019-10-07", "2019-10-05", "0")]
        public void ReturnTestWeekdays(string firstDate, string secondDate, string value)
        {
            Base_CountBetweenTwoDatesBC weekdays = new Base_CountBetweenTwoDatesBC();
            Assert.Equal(weekdays.GetCountWeekdays<DataCountBetweenTwoDates>(Convert.ToDateTime(firstDate), Convert.ToDateTime(secondDate))?.Data?.Result.ToString(), value);
        }

        [Theory]
        [InlineData("2019-10-07", "2019-10-09", "2019-10-25,2019-12-26,2019-01-01", "1")]
        [InlineData("2019-12-24", "2020-12-27", "2019-10-25,2019-12-26,2019-01-01", "0")]
        [InlineData("2019-10-07", "2020-01-01", "2019-10-25,2019-12-26,2019-01-01", "59")]
        public void ReturnTestBusinessDay(string firstDate, string secondDate, string datesList, string value)
        {
            Base_CountBetweenTwoDatesBC businessDay = new Base_CountBetweenTwoDatesBC();
            string[] datesString = datesList.Split(",");
            List<DateTime> dates = datesString.Select(date => DateTime.Parse(date)).ToList();
            Assert.Equal(businessDay.GetCountBusinessDays<DataCountBetweenTwoDates>(Convert.ToDateTime(firstDate), Convert.ToDateTime(secondDate), dates)?.Data?.Result.ToString(), value);
        }
    }
}
