using System.Configuration;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public class TargetSqlServer : TargetServer, ITargetSqlServer
    {
        private const string ConnectionStringKey = "connectionString";

        [ConfigurationProperty(ConnectionStringKey, IsRequired = true)]
        public string ConnectionString
        {
            get { return (string) this[ConnectionStringKey];  }
            set { this[ConnectionStringKey] = value; }
        }
    }
}