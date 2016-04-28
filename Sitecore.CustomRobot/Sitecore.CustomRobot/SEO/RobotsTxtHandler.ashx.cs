
namespace Sitecore.CustomRobot.SEO
{
    using System.Web;
    using Sitecore.CustomRobot.Provider;

    public class RobotsTxtHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var siteRoot = Context.Database.Items.GetItem(string.Format("{0}{1}", Context.Site.RootPath, Context.Site.StartItem));
            
            if (siteRoot != null)
            {
                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.ContentEncoding = System.Text.Encoding.UTF8;

                if (Provider.RobotsTxtProvider != null)
                {
                    context.Response.Write(Provider.RobotsTxtProvider.GetRobotsTxtFileContent(siteRoot));
                }
            }

            context.Response.End();
        }
    }
}