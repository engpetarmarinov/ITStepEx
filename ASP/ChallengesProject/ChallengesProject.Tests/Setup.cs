using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChallengesProject.Tests
{
    /// <summary>
    /// Run once to setup test fixtures
    /// </summary>
    [SetUpFixture]
    class Setup
    {
        public Setup()
        {
            //TODO: maybe mock IMapper instead of doing integration testing
            AutoMapperWebConfig.Configure();
            // Clears all previously registered view engines.
            ViewEngines.Engines.Clear();
            // Registers our Razor C# specific view engine.
            // This can also be registered using dependency injection through the new IDependencyResolver interface.
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
