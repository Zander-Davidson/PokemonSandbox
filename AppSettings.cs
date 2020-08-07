using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonSandbox
{
    public class AppSettings
    {
        public Logging Logging { get; set; }
        public NeO4jConnectionSettings NeO4jConnectionSettings { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Warning { get; set; }
        public string Error { get; set; }
    }

    public class NeO4jConnectionSettings
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
