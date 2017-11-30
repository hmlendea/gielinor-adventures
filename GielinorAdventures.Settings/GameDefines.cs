namespace GielinorAdventures.Settings
{
    /// <summary>
    /// Configuration constants class.
    /// </summary>
    public static class GameDefines
    {
        public static string ApplicationName => $"RuneScape Solo v{CLIENT_VERSION}";

        public const int GUI_TILE_SIZE = 32;

        /// <summary>
        /// The client version.
        /// </summary>
        public const int CLIENT_VERSION = 3;

        /// <summary>
        /// The IP address of the server.
        /// </summary>
        public const string SERVER_IP = "127.0.0.1";

        /// <summary>
        /// The port of the server.
        /// </summary>
        public const int SERVER_PORT = 43594;

        /// <summary>
        /// The cache URL.
        /// </summary>
        public const string CACHE_URL = "http://216.24.201.81/cache/";

        /// <summary>
        /// The crash URL.
        /// </summary>
        public const string CRASH_URL = "http://216.24.201.81/crash.php";
    }
}
