using GigaBankLab.Data;
using GigaBankLab.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaBankLab.Services
{
    public class CurrentDateService
    {
        private readonly GigaBankLabContext context;

        public CurrentDateService(GigaBankLabContext context)
        {
            this.context = context;
        }

        public async Task<DateTime> GetTodayAsync()
        {
            var date = (await context.CurrentDates.FirstAsync()).Value;
            var now = DateTime.UtcNow;
            return new DateTime(date.Year, date.Month, date.Day, now.Hour, now.Minute, now.Second, now.Millisecond, DateTimeKind.Utc);
        }

        public async Task SetToday(DateTime newToday)
        {
            var date = await context.CurrentDates.FirstAsync();
            date.Value = new DateTime(newToday.Year, newToday.Month, newToday.Day, 12, 00, 00, DateTimeKind.Utc);
            await context.SaveChangesAsync();
        }
    }
}
