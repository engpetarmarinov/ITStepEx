using ChallengesProject.Data;
using ChallengesProject.Services;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace ChallengesProject.Controllers.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void HomeControllerTest()
        {
            var data = new Mock<IChallengesData>();
            var service = new Mock<ChallengesService>(data.Object);
            var controller = new HomeController(service.Object);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Home", result.ViewName);
        }

        [Test]
        public void IndexTest()
        {

        }

        [Test]
        public void AboutTest()
        {

        }

        [Test]
        public void ContactTest()
        {

        }
    }
}