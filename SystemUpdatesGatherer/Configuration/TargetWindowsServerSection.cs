using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public class TargetWindowsServerSection : ConfigurationSection, IServerList
    {
        internal const string ConfigurationSectionName = "WindowsServers";

        [ConfigurationProperty(ConfigurationSectionName)]
        [ConfigurationCollection(typeof(TargetWindowsServerCollection))]
        public TargetWindowsServerCollection SqlServerVersions
        {
            get { return (TargetWindowsServerCollection)base[ConfigurationSectionName]; }
            set { base[ConfigurationSectionName] = value; }
        }

        public IList<ITargetServer> Servers 
        { 
            get
            {
                return ((TargetWindowsServerCollection)base[ConfigurationSectionName]).Cast<ITargetServer>().ToList();
            } 
        }
    }
}