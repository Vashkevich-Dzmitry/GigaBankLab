using GigaBankLab.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GigaBankLab.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly BankOperationsService _bankOperationsService;
        private readonly CurrentDateService _dateService;

        public DateTime Today { get; set; }

        public IndexModel(ILogger<IndexModel> logger, BankOperationsService bankOperationsService, CurrentDateService dateService)
        {
            _logger = logger;

            _bankOperationsService = bankOperationsService;
            _dateService = dateService;
        }

        public async Task OnGetAsync()
        {
            Today = await _dateService.GetTodayAsync();
        }

        public async Task OnGetCloseBankDayAsync()
        {
            await _bankOperationsService.CloseDayAsync();
            Today = await _dateService.GetTodayAsync();
        }
    }
}
