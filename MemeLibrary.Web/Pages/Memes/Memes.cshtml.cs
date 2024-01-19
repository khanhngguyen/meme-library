using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using MemeLibrary.Application.src.ServiceInterfaces;
using MemeLibrary.Domain.src.Entities;

namespace MemeLibrary.Web.Pages.Memes
{
    public class Memes : PageModel
    {
        private readonly ILogger<Memes> _logger;
        private readonly IMemeService _memeService;
        public IEnumerable<Meme> MemeList { get; set; } = default!; 
        public QueryOptions QueryOptions { get; set; } = new QueryOptions {
            Search =  string.Empty,
            OrderBy  = string.Empty,
            PageNumber = 0,
            PageSize = 20,
        };

        public Memes(ILogger<Memes> logger, IMemeService memeService)
        {
            _logger = logger;
            _memeService = memeService;
        }

        public async Task<IActionResult> OnGet()
        {
            MemeList = await _memeService.GetAll(QueryOptions);
            return Page();
        }
    }
}