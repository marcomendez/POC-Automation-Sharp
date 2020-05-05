using POC.Automation.Helpers.Enums;
using POC.Automation.Web.Drivers;
using POC.Automation.Web.Interfaces;

namespace POC.Automation.Web.Elements
{
    public class WebElement : IUIElement
    {
        public string Name { get; set; }
        public ElementType ElementType { get; set; }
        public Locator Locator { get; set; }

        public WebElement(string name, ElementType type, Locator locator)
        {
            Name = name;
            ElementType = type;
            Locator = locator;
        }
        public virtual OpenQA.Selenium.IWebElement Element
        {
            get => WebDriverManager.Instance.WebDriver.FindElement(Locator.GetBy());
        }
    }
}


