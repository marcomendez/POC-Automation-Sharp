using POC.Automation.Base.Api;
using POC.Automation.Helpers;
using POC.Automation.Helpers.Attributes;

namespace POC.Automation.Requests.Api
{
    [Page("Team")]
    public class Team : ApiRequestManager
    {
        public dynamic GetTeam()
        {
            return Get("team").ToDynamic();
        }
    }
}
