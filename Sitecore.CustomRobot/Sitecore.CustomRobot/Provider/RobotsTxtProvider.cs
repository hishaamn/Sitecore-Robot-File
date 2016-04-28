
namespace Sitecore.CustomRobot.Provider
{
    using System.Web;
    using Sitecore.CustomRobot.Interface;
    using Sitecore.Data.Items;

    public class RobotsTxtProvider : IRobotsTxtProvider
    {
        public string GetRobotsTxtFileContent(Item siteRoot)
        {
            if (siteRoot != null)
            {
                var robotSettings = Context.Database.Items.GetItem(string.Format("{0}/Robot Settings", siteRoot.Paths.FullPath));

                if (robotSettings != null)
                {
                    var robotField = robotSettings.Fields["Robots File Content"].Value;

                    return robotField.Replace("[site domain]", HttpContext.Current.Request.Url.Host);
                }
            }
            return string.Empty;
        }
    }
}
