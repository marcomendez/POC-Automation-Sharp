using POC.Automation.Helpers.Enums;
using POC.Automation.Web.Interfaces;

namespace POC.Automation.Web.Elements
{
    public class Button : WebElement, IButton
    {
        public Button(string name, Locator locator) : base(name, ElementType.Button, locator)
        {
        }

        public void Click()
        {
            Element.Click();
        }
    }
}
