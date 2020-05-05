using POC.Automation.Web.Interfaces;
using POC.Automation.Helpers.Enums;

namespace POC.Automation.Web.Elements
{
    public class Label : WebElement, ILabel
    {
        public Label(string name,  Locator locator) : base(name, ElementType.Label, locator)
        {
        }

        public bool Displayed()
        {
            try
            {
                return Element.Displayed;
            }
            catch 
            {
                return false;
            }
        }

        public string GetText()
        {
            return Element.Text;
        }
    }
}
