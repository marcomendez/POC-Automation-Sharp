using POC.Automation.Helpers.Attributes;
using POC.Automation.Helpers.Enums;
using POC.Automation.Web.Interfaces;

namespace POC.Automation.Web.Pages
{
    [Page("Home")]
    public class Home
    {
        [Element("View", ElementType.Label)]
        [Locator(LocatorType.XPath, "//*[@class='cu-data-view-list__add-text']")]
        public ILabel View { get; }
    }
}