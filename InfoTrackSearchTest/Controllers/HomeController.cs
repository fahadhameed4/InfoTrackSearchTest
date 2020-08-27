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
using System.Text;

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
            var countoftags=new System.Text.StringBuilder();
            var result = string.Empty;
            if (!string.IsNullOrEmpty(keywords) && !string.IsNullOrEmpty(searchresult))
            {
                try
                {
                   
                    var numberofpages = _configuration.GetValue<int>("MySettings:NumberOfPages");
                    for(int inc=1;inc<=numberofpages;inc++)
                    {
                        //this is only cover the static pages however it can be retrieve dynamically if we will use google/bing api 
                        string url = _configuration.GetValue<string>("MySettings:SearchEngineGoogleUrl");
                        if(inc==10)
                        { url = url + "Page"  + inc + ".html"; }
                        else
                        url = url + "Page" + "0" + inc + ".html";
                        listoftags = _searchEngineService.GetATagscs(url, searchresult, keywords).ToList();
                        countoftags.Append(listoftags.Count.ToString());
                        countoftags.Append(",");
                    }
                   
                }
               
                catch(Exception ex)
                {

                }
                if(countoftags.Capacity>0)
                {
                     result = countoftags.ToString(0, countoftags.Length - 2);
                }
                ViewData["result"] = result;
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
