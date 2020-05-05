using NUnit.Framework;
using POC.Automation.Base.Api;
using System;

namespace POC.Automation.Helpers.Tests.ClickUpTest
{
    [TestFixture]
    public class SpaceApiTest
    {
        private ApiRequestManager apiRequestManager;
        private dynamic team;

        [SetUp]
        public void Setup()
        {
            apiRequestManager = new ApiRequestManager();
            team = apiRequestManager.Get("team").ToDynamic();
        }

        [Test]
        [TestCase("3043881")]
        public void SpaceApi_GetSpaceNameByTeamId_ReturnSpaceName(string spaceId)
        {
            var response = apiRequestManager.Get($"team/{team.teams[0].id.ToString()}/space?archived=false");
            dynamic space = response.ToDynamic();

            Assert.AreEqual(spaceId, space.spaces[0].id.ToString());
        }

        [Test]
        public void SpaceApi_CreateSpace_ReturnBodyWithSpaceCreated()
        {
            string spaceName = DateTime.UtcNow.Ticks.ToString();
            string spaceBody = Env.SpaceBody.Replace("SPACENAME", spaceName);

            dynamic space = apiRequestManager.Post($"team/{team.teams[0].id.ToString()}/space", spaceBody).ToDynamic();
            apiRequestManager.Delete($"space/{space.id.ToString()}");

            Assert.AreEqual(spaceName, space.name.ToString());
        }

        [Test]
        public void SpaceApi_CreateSpace_ReturnBodyWithSpaceCreated2()
        {
            string spaceName = DateTime.UtcNow.Ticks.ToString();
            string spaceBody = Env.SpaceBody.Replace("SPACENAME", spaceName);

            dynamic space = apiRequestManager.Post($"team/{team.teams[0].id.ToString()}/space", spaceBody).ToDynamic();
            apiRequestManager.Delete($"space/{space.id.ToString()}");

            Assert.AreEqual(spaceName, space.name.ToString());
        }
    }
}
