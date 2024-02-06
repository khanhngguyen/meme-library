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

        [BindProperty(SupportsGet = true)]
        public QueryOptions QueryOptions { get; set; } = new QueryOptions {
            Search =  string.Empty,
            OrderBy  = string.Empty,
            PageNumber = 0,
            PageSize = 20,
        };

        // props for pagination
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; } = 20;
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => PageIndex > 0;

        public bool HasNextPage => PageIndex < (TotalPages - 1);

        public Memes(ILogger<Memes> logger, IMemeService memeService)
        {
            _logger = logger;
            _memeService = memeService;
        }

        public async Task<IActionResult> OnGet()
        {
            MemeList = await _memeService.GetAll(QueryOptions);

            // get total pages for pagination
            GetTotalPages();
            
            // get current page index from query
            string pageNumberQueryParam = Request.Query["pagenumber"];
            if (!int.TryParse(pageNumberQueryParam, out int pageNumber))
            {
                // If parsing fails, set a default value to 0
                pageNumber = 0;
            }
            PageIndex = pageNumber;

            return Page();
        }

        public async Task<IActionResult> OnSearch (string searchQuery)
        {
            QueryOptions.Search = searchQuery;
            MemeList = await _memeService.GetAll(QueryOptions);
            return Page();
        }

        public async Task<IActionResult> OnOrderBy (string orderByQuery)
        {
            QueryOptions.OrderBy = orderByQuery;
            MemeList = await _memeService.GetAll(QueryOptions);
            return Page();
        }

        // get Total Pages from total entities count 
        private async void GetTotalPages()
        {
            double entityCount =  await _memeService.GetEntityCount();
            TotalPages = (int) Math.Ceiling(entityCount / PageSize);
        }

        public async Task<IActionResult> OnSelectPage(int pageNumber)
        {
            PageIndex = pageNumber;
            QueryOptions.PageNumber = pageNumber;
            // QueryOptions.PageSize = 5;
            MemeList = await _memeService.GetAll(QueryOptions);
            return Page();
        }
        
        // public async Task<IActionResult> OnSelectPageSize(int pageSize)
        // {
        //     PageSize = pageSize;
        //     QueryOptions.PageSize = pageSize;

        //     // recount Total Pages
        //     GetTotalPages();
        //     MemeList = await _memeService.GetAll(QueryOptions);
        //     return Page();
        // }
    }
}