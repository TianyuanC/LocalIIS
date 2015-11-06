using Microsoft.Web.Administration;

namespace IISSwitcher.Extractions
{
    public static class SiteExtractions
    {
        public static string PhysicalPath(this Site site)
        {
            if (site.Applications.Count == 0 || site.Applications[0].VirtualDirectories.Count == 0)
            {
                return string.Empty;
            }
            return site.Applications[0].VirtualDirectories[0].PhysicalPath;
        }
    }
}
