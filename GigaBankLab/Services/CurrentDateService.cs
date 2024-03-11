using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Services
{
    public class CurrentDateService
    {
        private readonly GigaBankLabContext _context;

        public CurrentDateService(GigaBankLabContext context)
        {
            _context = context;
        }

        public async Task<DateTime> GetTodayAsync()
        {
            var date = (await _context.CurrentDates.FirstAsync()).Value;
            var now = DateTime.UtcNow;
            return new DateTime(date.Year, date.Month, date.Day, now.Hour, now.Minute, now.Second, now.Millisecond, DateTimeKind.Utc);
        }

        public async Task<DateTime> GetBankDayAsync()
        {
            var date = await _context.CurrentDates.FirstAsync();
            date.Value = date.Value.AddMilliseconds(1);
            await _context.SaveChangesAsync();
            return date.Value;
        }

        public async Task NextDay()
        {
            var date = await _context.CurrentDates.FirstAsync();
            date.Value = date.Value.AddDays(1);
            await _context.SaveChangesAsync();
        }
    }
}
