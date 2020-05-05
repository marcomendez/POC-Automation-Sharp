using POC.Automation.Helpers.Attributes;
using POC.Automation.Helpers.Enums;
using POC.Automation.Web.Interfaces;

namespace POC.Automation.Web.Pages
{
    [Page("Login")]
    public class Login
    {
        [Element("UserName", ElementType.TextField)]
        [Locator(LocatorType.Id, "email-input")]
        public ITextField UserName { get; }

        [Element("Password", ElementType.TextField)]
        [Locator(LocatorType.Id, "password-input")]
        public ITextField Password { get; }

        [Element("Login", ElementType.Button)]
        [Locator(LocatorType.Id, "login-submit")]
        public IButton LoginBtn { get; }
    }
}
