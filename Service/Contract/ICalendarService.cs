using testWebAPI.Dtos.Calendar;
using testWebAPI.Dtos.Student;

namespace testWebAPI.Service.Contract
{
    public interface ICalendarService
    {
        /// <summary>
        /// Return list of calendar events, after filters
        /// </summary>
        /// <param name="criterias">Criteria for filtering events</param>
        /// <returns>List of CalendarEventDto</returns>
        Task<ServiceResponse<List<CalendarEventDto>>> GetCalendarEventsAsync(CalendarEventFilterCriteriaDto criterias);

        /// <summary>
        /// Return list of calendar, after filters
        /// </summary>
        /// <param name="criterias">Criteria for filtering calendars</param>
        /// <returns>List of CalendarDto</returns>
        Task<ServiceResponse<List<CalendarEventDto>>> GetCalendarsAsync(CalendarFilterCriteriaDto criterias);
    }
}
