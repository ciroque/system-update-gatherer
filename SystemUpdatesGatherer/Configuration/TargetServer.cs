using System.Configuration;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public class TargetServer : ConfigurationElement, ITargetServer
    {
        private const string NameKey = "serverName";

        [ConfigurationProperty(NameKey, IsRequired = true, IsKey= true)]
        public string ServerName
        {
            get { return (string) this[NameKey];  }
            set { this[NameKey] = value; }
        }
    }
}