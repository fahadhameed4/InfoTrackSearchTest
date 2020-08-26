using InfoTrackSearchTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackSearchTest.Services
{
    public  interface ISearchEngineService
    {
        public IEnumerable<ATagscs> GetATagscs(string searchUrl, string targetDomain, string searchString);

    }
}
