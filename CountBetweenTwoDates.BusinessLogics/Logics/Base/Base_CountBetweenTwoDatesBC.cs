using CountBetweenTwoDates.BusinessLogics.Interfaces;
using CountBetweenTwoDates.BusinessLogics.Models;
using CountBetweenTwoDates.BusinessLogics.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountBetweenTwoDates.BusinessLogics.Logics.Base
{
    public class Base_CountBetweenTwoDatesBC : ICountBetweenTwoDatesBC
    {
        #region Constructors

        public Base_CountBetweenTwoDatesBC()
        {
        }

        #endregion

        #region Methods

        public LogicResponse<TRes> GetCountBusinessDays<TRes>(DateTime firstDate, DateTime secondDate, List<DateTime> publicHolidays) where TRes : DataCountBetweenTwoDates
        {
            try
            {
                long days = 0;
                DateTime currentDate = firstDate.AddDays(1).Date;

                while (currentDate.Date < secondDate.Date)
                {
                    if (ValidationWorkingDaysDate(currentDate, publicHolidays))
                        days++;

                    currentDate = currentDate.AddDays(1);
                }

                return new LogicResponse<TRes> { Success = true, Data = new DataCountBetweenTwoDates() { Result = days } as dynamic };

            }
            catch (Exception ex)
            {
                return new LogicResponse<TRes> { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public LogicResponse<TRes> GetCountWeekdays<TRes>(DateTime firstDate, DateTime secondDate) where TRes : DataCountBetweenTwoDates
        {
            return GetCountBusinessDays<TRes>(firstDate, secondDate, null);
        }

        private static bool ValidationWorkingDaysDate(DateTime currentDate, List<DateTime> publicHolidays)
        {
            if (currentDate.DayOfWeek == DayOfWeek.Saturday
                || currentDate.DayOfWeek == DayOfWeek.Sunday
                || (publicHolidays != null && publicHolidays.Any(x => x.Date == currentDate.Date)))
                return false;

            return true;
        }

        #endregion
    }
}
