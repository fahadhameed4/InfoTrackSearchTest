using HtmlAgilityPack;
using InfoTrackSearchTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSearchTest.Services
{
    public class GoogleEngineService : ISearchEngineService
    {
        private readonly IContentService _contentservice;

        public GoogleEngineService(IContentService contentService)
        {
            _contentservice = contentService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchUrl"></param>
        /// <param name="targetDomain"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public IEnumerable<ATagscs> GetATagscs(string searchUrl, string targetDomain, string searchString)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            string urlResponse = _contentservice.URLRequest(searchUrl);
            //Convert the Raw HTML into an HTML Object
            htmlDoc.LoadHtml(urlResponse);
            //Find all A tags in the document
            var anchorNodes = htmlDoc.DocumentNode.SelectNodes("//a");

            foreach (var tag in anchorNodes)
            {
                var hrefValue = tag.GetAttributeValue("href", "");
                var tempHref = hrefValue.ToUpper();
                var tempTargetDomain = targetDomain.ToUpper();
                if (tempHref.Contains(tempTargetDomain))
                {
                    var anchorTag = new ATagscs();
                    foreach (var attribute in tag.Attributes)
                        anchorTag.Attributes.Add(attribute.Name, attribute.Value);
                    anchorTag.InnerText = tag.InnerText;
                    yield return anchorTag;
                }
            }
        }

    }
}
