using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InfoTrackSearchTest.Models;
using InfoTrackSearchTest.Services;
using Microsoft.Extensions.Configuration;

namespace InfoTrackSearchTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISearchEngineService _searchEngineService;
        private IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, ISearchEngineService searchEngineService, IConfiguration configuration)
        {
            _searchEngineService = searchEngineService;
            _logger = logger;
            _configuration = configuration;
        }
        public IActionResult Index(string keywords, string searchresult)
        {
            if(!string.IsNullOrEmpty(keywords) && !string.IsNullOrEmpty(searchresult))
            {
                string url = _configuration.GetValue<string>("MySettings:SearchEngineGoogleUrl");
                var list = _searchEngineService.GetATagscs(url, searchresult, keywords).ToList();
                ViewData["countstring"] = list.Count.ToString();
            }
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
