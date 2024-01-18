using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MemeLibrary.Web.Pages.Memes
{
    public class Memes : PageModel
    {
        private readonly ILogger<Memes> _logger;

        public Memes(ILogger<Memes> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}