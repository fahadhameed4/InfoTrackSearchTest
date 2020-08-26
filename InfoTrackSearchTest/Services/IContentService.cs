using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackSearchTest.Services
{
   public  interface IContentService
    {
        public string GetContent(string url);
        public string URLRequest(string url);
    }
}
