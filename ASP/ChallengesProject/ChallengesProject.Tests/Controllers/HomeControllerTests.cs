using ChallengesProject.Controllers;
using ChallengesProject.Data;
using ChallengesProject.Services;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace ChallengesProject.Tests.Controllers
{
    public class HomeControllerTests : AssertionHelper
    {
        protected HomeController homeController;

        [SetUp]
        public void SetUp()
        {
            var data = new Mock<IChallengesData>();
            var service = new Mock<ChallengesService>(data.Object);
            homeController = new HomeController(service.Object);
        }

        [Test]
        public void HomeControllerTest()
        {
            Expect(homeController, Is.InstanceOf(typeof(HomeController)));
        }

        [Test]
        public void IndexTest()
        {            
            var result = homeController.Index() as ViewResult;
            Expect(result, Is.InstanceOf(typeof(ActionResult)));
            Assert.AreEqual("", result.ViewName); //Standard assertion
            Expect(result.ViewName, Is.EqualTo("")); //Comes from AssertionHelper. It's more readable!
        }

        [Test]
        public void AboutTest()
        {
            var result = homeController.Index() as ViewResult;
            Expect(result, Is.InstanceOf(typeof(ActionResult)));
            Expect(result.ViewName, Is.EqualTo(""));
        }

        [Test]
        public void ContactTest()
        {
            var result = homeController.Index() as ViewResult;
            Expect(result, Is.InstanceOf(typeof(ActionResult)));
            Expect(result.ViewName, Is.EqualTo(""));
        }
    }
}