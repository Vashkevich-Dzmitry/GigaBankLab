using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using GigaBankLab.Services;

namespace GigaBankLab.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly BankOperationsService _bankOperationsService;
        private readonly CurrentDateService _dateService;

        public readonly int SomeDaysAmount = 10;
        public readonly int ManyDaysAmount = 100;
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

        public async Task OnGetCloseSomeBankDaysAsync()
        {
            for (int i = 0; i < SomeDaysAmount; i++)
            {
                await _bankOperationsService.CloseDayAsync();
            }
            
            Today = await _dateService.GetTodayAsync();
        }

        public async Task OnGetCloseManyBankDaysAsync()
        {
            for (int i = 0; i < ManyDaysAmount; i++)
            {
                await _bankOperationsService.CloseDayAsync();
            }
            
            Today = await _dateService.GetTodayAsync();
        }
    }
}
