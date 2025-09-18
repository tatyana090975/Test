using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class DatabaseSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; }
        public bool Pooling { get; set; }

        public DatabaseSettings()
        {
            Host = "localhost";
            Port = 5432;
            Timeout = 30;
            Pooling = true;
        }

        public string BuildConnectionString()
        {
            return $"Host={Host};Port={Port};Database={Database};" +
                   $"Username={Username};Password={Password};" +
                   $"Timeout={Timeout};Pooling={Pooling};";
        }
    }
}
