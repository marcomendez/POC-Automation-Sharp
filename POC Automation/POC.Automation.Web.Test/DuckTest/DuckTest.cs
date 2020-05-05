using NUnit.Framework;
using OpenQA.Selenium;
using POC.Automation.Web.Drivers;

namespace POC.Automation.Web.Tests.DuckTest
{
    [TestFixture]
    public class DuckTest
    {
        [Test]
        public void DuckTest_VerifyIsSearch_Displayed()
        {
            WebDriverManager.Instance.Start();
            By search = By.Id("search_form_input_homepage");

            IWebElement searchField = WebDriverManager.Instance.WebDriver.FindElement(search);
            Assert.IsTrue(searchField.Displayed, "Search field was not displiyed");
        }
    }
}
