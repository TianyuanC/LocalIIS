using Microsoft.Web.Administration;
using IISSwitcher.Extractions;

namespace IISSwitcher.Extensions
{
    public static class SiteExtensions
    {
        public static void UpdatePhysicalPath(this Site site, string path)
        {
            if (site.Applications.Count == 0 || site.Applications[0].VirtualDirectories.Count == 0)
            {
                return;
            }
            site.Applications[0].VirtualDirectories[0].PhysicalPath = path;
        }

        public static bool IsGit(this Site site)
        {
            return site.PhysicalPath() == Settings.GitPath;
        }

        public static bool IsTfs(this Site site)
        {
            return site.PhysicalPath() == Settings.TfsPath;
        }
    }
}
