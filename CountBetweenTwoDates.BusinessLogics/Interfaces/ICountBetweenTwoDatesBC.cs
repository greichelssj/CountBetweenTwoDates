using CountBetweenTwoDates.BusinessLogics.Models;
using CountBetweenTwoDates.BusinessLogics.Models.Data;
using System;
using System.Collections.Generic;

namespace CountBetweenTwoDates.BusinessLogics.Interfaces
{
    public interface ICountBetweenTwoDatesBC
    {
        LogicResponse<TRes> GetCountWeekdays<TRes>(DateTime firstDate, DateTime secondDate) where TRes : DataCountBetweenTwoDates;

        LogicResponse<TRes> GetCountBusinessDays<TRes>(DateTime firstDate, DateTime secondDate, List<DateTime> publicHolidays) where TRes : DataCountBetweenTwoDates;
    }
}
