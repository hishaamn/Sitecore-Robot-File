
namespace Sitecore.CustomRobot.Provider
{
    using System;
    using Sitecore.Configuration;
    using Sitecore.CustomRobot.Interface;

    public static class Provider
    {
        public static IRobotsTxtProvider robotsTxtProvider = InitializeProvider<IRobotsTxtProvider>("robotsTxtSection/robotsTxtProvider");

        public static IRobotsTxtProvider RobotsTxtProvider
        {
            get
            {
                return robotsTxtProvider;
            }
        }

        public static T InitializeProvider<T>(string providerConfigElement) where T : class
        {
            try
            {
                var config = Factory.GetConfigNode(providerConfigElement);

                return Factory.CreateObject<T>(config);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
