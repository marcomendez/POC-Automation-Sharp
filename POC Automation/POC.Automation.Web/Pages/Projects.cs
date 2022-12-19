using POC.Automation.Helpers.Attributes;
using POC.Automation.Helpers.Enums;
using POC.Automation.Web.Elements;
using POC.Automation.Web.Interfaces;

namespace POC.Automation.Web.Pages
{
    [Page("Projects")]
    public class Projects
    {
        [Element("Projects", ElementType.Label)]
        [Locator(LocatorType.Id, "containerTitle")]
        public ILabel View { get; }

        [Element("Create Project", ElementType.Button)]
        [Locator(LocatorType.Id, "createProjectButton")]
        public IClickeable createProject{ get; }

        [Element("Search", ElementType.TextField)]
        [Locator(LocatorType.Id, "search")]
        public ITexteable Search{ get; }


        [Element("More", ElementType.Button)]
        [Locator(LocatorType.XPath, "//*[ contains (text(), 'More' ) ]")]
        public Button More { get; }
    }
}