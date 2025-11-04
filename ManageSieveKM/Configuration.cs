using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSieveKM
{
    public static class Configuration
    {
        private static string _host, _email, _password, _serverUpdate = "https://raw.githubusercontent.com/kamilmroczkowski/ManageSieveKM/refs/heads/main/Releases/";
        private static string _encryptionKey;
        private static bool _tls = true, _ignoreCert = false, _checkUpdate = true, _silentUpdate = false, _debug = false, _showOnlyAutoresponder = false;
        private static int _port = 4190;
        private static float _fontSize = 10;

        public static string Host { get => _host; set => _host = value; }
        public static string Email { get => _email; set => _email = value; }
        public static string Password { get => _password; set => _password = value; }
        public static string ServerUpdate { get => _serverUpdate; set => _serverUpdate = value; }
        public static bool Tls { get => _tls; set => _tls = value; }
        public static bool IgnoreCert { get => _ignoreCert; set => _ignoreCert = value; }
        public static bool CheckUpdate { get => _checkUpdate; set => _checkUpdate = value; }
        public static bool SilentUpdate { get => _silentUpdate; set => _silentUpdate = value; }
        public static bool Debug { get => _debug; set => _debug = value; }
        public static bool ShowOnlyAutoresponder { get => _showOnlyAutoresponder; set => _showOnlyAutoresponder = value; }
        public static int Port { get => _port; set => _port = value; }
        public static float FontSize { get => _fontSize; set => _fontSize = value; }
        public static string EncryptionKey { get => _encryptionKey; set => _encryptionKey = value; }
    }
}
