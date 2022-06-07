using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.EF;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Website_BackgroundContext>();
            using (var db = new Website_BackgroundContext(optionsBuilder.Options))
            {
                try
                {
                    // 分層命名參考 https://hackmd.io/@MonsterLee/HJyAdgRBB
                    var TestsPOC = db.Tests.ToList();
                    ViewData["TestsPOCcount"] = TestsPOC.Count();
                }
                catch (Exception ex)
                {
                    var tt = ex;
                }
            }
        }
    }
}