using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public class TargetSqlServerSection : ConfigurationSection, ISqlServerList
    {
        internal const string ConfigurationSectionName = "Servers";

        [ConfigurationProperty(ConfigurationSectionName)]
        [ConfigurationCollection(typeof(TargetSqlServerCollection))]
        public TargetSqlServerCollection TargetSqlServers
        {
            get { return (TargetSqlServerCollection)base[ConfigurationSectionName]; }
            set { base[ConfigurationSectionName] = value; }
        }

        public IList<ITargetSqlServer> SqlServers
        {
            get
            {
                return ((TargetSqlServerCollection)base[ConfigurationSectionName]).Cast<ITargetSqlServer>().ToList();
            }
        }
    }
}