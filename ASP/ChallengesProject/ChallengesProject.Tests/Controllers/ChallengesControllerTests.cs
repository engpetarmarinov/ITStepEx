using NUnit.Framework;
using ChallengesProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ChallengesProject.Services;
using ChallengesProject.Data;
using ChallengesProject.Models;
using System.Linq.Expressions;
using System.Web.Mvc;
using ChallengesProject.ViewModels;
using ChallengesProject.Tests;
using PagedList;
using System.Web;
using System.Web.Routing;

namespace ChallengesProject.Tests.Controllers
{
    public class ChallengesControllerTests : AssertionHelper
    {
        protected ChallengesController challengesController;
        protected Mock<ChallengesService> challengesServiceMocked;
        protected Mock<UsersChallengesService> usersChallengesServiceMocked;
        
        [SetUp]
        public void SetUp()
        {
            var data = new Mock<IChallengesData>();
            challengesServiceMocked = new Mock<ChallengesService>(data.Object);
            usersChallengesServiceMocked = new Mock<UsersChallengesService>(data.Object);
            challengesController = new ChallengesController(challengesServiceMocked.Object, usersChallengesServiceMocked.Object);
        }

        [Test]
        public void ChallengesControllerTest()
        {
            Expect(challengesController, Is.InstanceOf(typeof(ChallengesController)));            
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(12, 2)]
        [TestCase(51, 0)]
        public void IndexTest(int page, int numberOfChallengesExpected)
        {
            var queryableList = GetStubChallenges();
            challengesServiceMocked
                .Setup(c => c.GetChallengesOrderedByDate())
                .Returns(queryableList);

            var result = challengesController.Index(page) as ViewResult;
            var model = result.Model as IPagedList<ChallengeViewModel>;
            Expect(model.Count(), Is.EqualTo(numberOfChallengesExpected));
        }

        [Test]
        [TestCase(1,2, 2)]
        [TestCase(12, 5, 5)]
        [TestCase(51, 2, 0)]
        [TestCase(34, 3, 1)]
        public void GetChallengesPageTest(int page, int perPage, int numberOfChallengesExpected)
        {
            var queryableList = GetStubChallenges();
            challengesServiceMocked
                .Setup(c => c.GetChallengesOrderedByDate())
                .Returns(queryableList);

            var challenges = challengesController.GetChallengesPage(page, perPage);
            Expect(challenges.Count(), Is.EqualTo(numberOfChallengesExpected));
            if (numberOfChallengesExpected > 0)
            {
                Expect(challenges[0].Id, Is.EqualTo(page * perPage - (perPage - 1)), "User id's are not correct");
            }
        }

        protected IQueryable<Challenge> GetStubChallenges()
        {
            var list = new List<Challenge>();
            for (var i = 1; i <= 100; i++)
            {
                list.Add(new Challenge()
                {
                    Id = i,
                    Name = "test " + i,
                    Description = "desc " + i,
                    Duration = 30,
                    UserId = i.ToString(),
                    User = new ApplicationUser() { Id = "user" + i, UserName = "username" + i },
                    Created = DateTime.Now.AddDays(-i)
                });
            }
            var queryableList = list.AsQueryable();
            return queryableList;
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(12, 2)]
        [TestCase(51, 0)]
        [TestCase(151, 0)]
        public void ChallengesTest(int page, int numberOfChallengesExpected)
        {
            var queryableList = GetStubChallenges();
            challengesServiceMocked
                .Setup(c => c.GetChallengesOrderedByDate())
                .Returns(queryableList);

            //Mock AJAX Request
            var request = new Mock<HttpRequestBase>();
            // Not working - IsAjaxRequest() is static extension method and cannot be mocked
            // request.Setup(x => x.IsAjaxRequest()).Returns(true /* or false */);
            // use this
            request.SetupGet(x => x.Headers).Returns(
                new System.Net.WebHeaderCollection {
                    //jQuery actually sets the 'X-Requested-With' header to 'XMLHttpRequest' by default.
                    {"X-Requested-With", "XMLHttpRequest"}
                }
            );
            // Mock RouteData
            var routeData = new RouteData();
            routeData.Values.Add("action", "Challenges");

            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            
            challengesController.ControllerContext = new ControllerContext(context.Object, routeData, challengesController);
                        
            var result = challengesController.Challenges(page) as PartialViewResult;
            var model = result.Model as IPagedList<ChallengeViewModel>;
            Expect(model.Count(), Is.EqualTo(numberOfChallengesExpected));
        }

        [Test]
        public void CreateTest()
        {

        }

        [Test]
        public void CreateTest1()
        {

        }

        [Test]
        public void DetailsTest()
        {

        }

        [Test]
        public void MyTest()
        {

        }

        [Test]
        public void MyChallengesTest()
        {

        }
    }
}