using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_pages_ef.Models;


using Microsoft.Extensions.Logging;



namespace razor_pages_ef.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly StoreGameContext _context;


        [BindProperty(Name = "bob", SupportsGet = true)]
        public string Message { get; set; } = "";


        [FromQuery(Name = "release-date")]
        public DateTime Date { get; set; } = DateTime.Now;

        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(StoreGameContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, DateTime? date, string msg)
        {
            Message += Request.Query["bob"];

            _logger.Log(LogLevel.Information, Request.QueryString.ToString());

            if (id == null)
            {
                return NotFound();
            }

            Message+= msg;

            if(date != null) {

                Date = date.Value;
                //Message+= date.Value.ToString("yyyy-mm-dd");
            }

            Game = await _context.Game.FirstOrDefaultAsync(m => m.GameID == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
