using System;

namespace ChatClient
{
    public static class ServerConfig
    {
        private const int ServerPort = 5000;
        private const string DefaultServerIp = "10.11.160.75";

        public static string ServerIp { get; } = NormalizeServerIp(Environment.GetEnvironmentVariable("SERVER_IP"));

        public static string ServerBaseUrl => $"http://{ServerIp}:{ServerPort}";

        public static string HubUrl => $"{ServerBaseUrl}/chat";

        private static string NormalizeServerIp(string? serverIp)
        {
            if (string.IsNullOrWhiteSpace(serverIp))
            {
                return DefaultServerIp;
            }

            var trimmed = serverIp.Trim();
            if (trimmed.Equals("localhost", StringComparison.OrdinalIgnoreCase) || trimmed.Equals("127.0.0.1", StringComparison.OrdinalIgnoreCase))
            {
                return DefaultServerIp;
            }

            return trimmed;
        }
    }
}