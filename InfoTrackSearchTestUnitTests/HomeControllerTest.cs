//using Castle.Core.Configuration;
using Castle.Core.Logging;
using InfoTrackSearchTest.Controllers;
using InfoTrackSearchTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace InfoTrackSearchTestUnitTests
{
    [TestClass]
    public class HomeControllerTests
    {
        private readonly Mock<ISearchEngineService> _mockRepo;
        private readonly Mock<IConfiguration> _mockConfiguration;
        //private readonly Mock<ILogger<HomeController>> _mockRepoLogger;
        private readonly HomeController _controller;
        public HomeControllerTests()
        {
            _mockRepo = new Mock<ISearchEngineService>();
            _mockConfiguration = new Mock<IConfiguration>();
            _controller = new HomeController(_mockRepo.Object, _mockConfiguration.Object);
        }
        [TestMethod]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Index("", "");
            Assert.AreEqual(0, 0);
        }


        [TestMethod]
        public void Index_ActionExecutes_ReturnsViewForIndex1()
        {
            var result = _controller.Index("Infotrack", "online Test result");
            Assert.Fail();
        }

    }


}
