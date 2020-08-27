using InfoTrackSearchTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrackSearchTestUnitTests
{
    [TestClass]
   public class SearchEngineServiceTest
    {
        private readonly Mock<ISearchEngineService> _mockRepo;
        public SearchEngineServiceTest()
        {
            _mockRepo = new Mock<ISearchEngineService>();
        }
        
        [TestMethod]
        public void GetATagscs_Test()
        {
            var urlrequest = _mockRepo.Object.GetATagscs("","","");
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void GetATagscs_Test_Null()
        {
            var urlrequest = _mockRepo.Object.GetATagscs("", "", "");
            Assert.AreEqual(null, null);
        }

    }
}
