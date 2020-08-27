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
        //private readonly ILogger<HomeController> _logger;
        private readonly ISearchEngineService _searchEngineService;
        private readonly IConfiguration _configuration;
        public HomeController(ISearchEngineService searchEngineService, IConfiguration configuration)
        {
            _searchEngineService = searchEngineService;
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult Index(string keywords, string searchresult)
        {
            var listoftags = new List<ATagscs>();
            if (!string.IsNullOrEmpty(keywords) && !string.IsNullOrEmpty(searchresult))
            {
                try
                {
                    string url = _configuration.GetValue<string>("MySettings:SearchEngineGoogleUrl");
                    listoftags = _searchEngineService.GetATagscs(url, searchresult, keywords).ToList();
                    
                }
               
                catch(Exception)
                {

                }

                ViewData["countstring"] = listoftags.Count.ToString();
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
