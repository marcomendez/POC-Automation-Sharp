using POC.Automation.Base.Api;
using POC.Automation.Helpers;
using POC.Automation.Helpers.Attributes;

namespace POC.Automation.Requests.Api
{
    [Page("Space")]
    public class SpaceAPI : ApiRequestManager
    {
        public dynamic GetTeamById(dynamic team)
        {
            return Get($"team/{team.teams[0].id.ToString()}/space?archived=false").ToDynamic();
        }

        public dynamic CreateSpace(string spaceName, dynamic team)
        {
            string spaceBody = Env.SpaceBody.Replace("SPACENAME", spaceName);

            return Post($"team/{team.teams[0].id.ToString()}/space", spaceBody).ToDynamic();
        }

        public dynamic DeleteSpace(dynamic space)
        {
            return Delete($"space/{space.id.ToString()}");
        }

        public bool SpaceID(string teamId, dynamic space)
        {
            return teamId == space.spaces[0].id.ToString();
        }

        public bool SpaceName(string spaceName, dynamic space)
        {
            return spaceName == space.name.ToString();
        }
    }
}
