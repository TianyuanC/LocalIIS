namespace IISSwitcher
{
    using System.Collections.Specialized;
    using System.Configuration;

    public static class Settings
    {
        private static readonly NameValueCollection Keys = ConfigurationManager.AppSettings;

        public static readonly string LocalAt = Keys["LocalAt"];

        public static readonly string LocalAh = Keys["LocalAh"];

        public static readonly string TfsPath = Keys["TfsPath"];

        public static readonly string GitPath = Keys["GitPath"];
    }
}
