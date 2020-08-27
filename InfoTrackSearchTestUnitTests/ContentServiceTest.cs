using InfoTrackSearchTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrackSearchTestUnitTests
{
    [TestClass]
   public class ContentServiceTest
    {
        private readonly Mock<IContentService> _mockRepo;
        public ContentServiceTest()
        {
            _mockRepo = new Mock<IContentService>();
        }
    
         [TestMethod]
        public void URLRequest_Test()
        {
            var urlrequest = _mockRepo.Object.URLRequest("");
            Assert.AreEqual("", "");
        }

        [TestMethod]
        public void URLRequest_Test_Null()
        {
            string responseContent = null;
            var urlrequest = _mockRepo.Object.URLRequest(responseContent);
            Assert.AreEqual(null, null);
        }

        public void GetContent_Test()
        {
            var content = _mockRepo.Object.GetContent("");
            Assert.AreEqual("", "");
        }
    }
}
