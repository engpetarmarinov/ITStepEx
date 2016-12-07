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
        public void IndexTest()
        {
            var list = new List<Challenge>();
            for(var i = 1;  i <= 100; i++)
            {
                list.Add(new Challenge()
                {
                    Id = i,
                    Name = "test " + i,
                    Description = "desc " + i,
                    UserId = i.ToString()
                });
            }
            var queryableList = list.AsQueryable();
            challengesServiceMocked
                .Setup(c => c.GetChallengesOrderedByDate())
                .Returns(queryableList);
            //TODO: debug
            var result = challengesController.Index() as ViewResult;
            var model = result.Model as IList<ChallengeViewModel>;
            Expect(model.Count(), Is.EqualTo(2));
        }

        [Test]
        public void ChallengesTest()
        {

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