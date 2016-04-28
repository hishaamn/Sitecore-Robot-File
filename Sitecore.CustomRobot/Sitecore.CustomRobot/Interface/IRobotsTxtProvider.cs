
namespace Sitecore.CustomRobot.Interface
{
    using Sitecore.Data.Items;

    public interface IRobotsTxtProvider
    {
        string GetRobotsTxtFileContent(Item siteRoot);
    }
}
