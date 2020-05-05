using NUnit.Framework;
using POC.Automation.Base.Api;
using System;

namespace POC.Automation.Helpers.Tests.ClickUpTest
{
    public class FolderApiTest
    {
        private ApiRequestManager apiRequestManager;
        private dynamic space;

        [SetUp]
        public void Setup()
        {
            apiRequestManager = new ApiRequestManager();
            dynamic team = apiRequestManager.Get("team").ToDynamic();

            string spaceBody = Env.SpaceBody.Replace("SPACENAME", DateTime.UtcNow.Ticks.ToString());
            space = apiRequestManager.Post($"team/{team.teams[0].id.ToString()}/space", spaceBody).ToDynamic();
        }

        [Test]
        public void VerifyCreateFolder()
        {
            // Create a new Folder
            dynamic folder = apiRequestManager.Post($"space/{space.id.ToString()}/folder", new { name = $"{DateTime.UtcNow.Ticks}" }).ToDynamic();

            // Update the Folder created
            var editBody = new { name = "Updated Folder" };
            dynamic editedFolder = apiRequestManager.Put($"folder/{folder.id.ToString()}", editBody).ToDynamic();

            // Verification
            Assert.AreEqual(editBody.name, editedFolder.name.ToString());
        }

        [Test]
        public void VerifyGetFoldersBySpaceId()
        {
            // Folders Bodies
            var folderBody1 = new { name = $"folder1-{DateTime.UtcNow.Ticks}" };
            var folderBody2 = new { name = $"folder2-{DateTime.UtcNow.Ticks}" };

            // Create Folders
            apiRequestManager.Post($"space/{space.id.ToString()}/folder", folderBody1).ToDynamic();
            apiRequestManager.Post($"space/{space.id.ToString()}/folder", folderBody2).ToDynamic();

            // Get Folders
            dynamic folders = apiRequestManager.Get($"space/{space.id.ToString()}/folder?archived=false").ToDynamic();

            // Verification
            Assert.AreEqual(folders.folders[0].name.ToString(), folderBody1.name);
            Assert.AreEqual(folders.folders[1].name.ToString(), folderBody2.name);
        }

        [TearDown]
        public void TearDown()
        {
            apiRequestManager.Delete($"space/{space.id.ToString()}");
        }
    }
}
