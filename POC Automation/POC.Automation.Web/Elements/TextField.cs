using POC.Automation.Helpers.Enums;
using POC.Automation.Web.Interfaces;

namespace POC.Automation.Web.Elements
{
    public class TextField : WebElement, ITexteable
    {
        public TextField(string name, Locator locator) 
            : base(name, ElementType.TextField, locator)
        {
        }

        public string GetText()
        {
           return Element.Text;
        }

        public void SetText(string text)
        {
            Element.Clear();
            Element.SendKeys(text);
        }
    }
}
