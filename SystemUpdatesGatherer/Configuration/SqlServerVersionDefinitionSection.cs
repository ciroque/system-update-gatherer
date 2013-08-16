using System.Collections.Generic;
using System.Configuration;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public class SqlServerVersionDefinitionSection : ConfigurationSection, ISqlServerVersionMap
    {
        internal const string ConfigurationSectionName = "Versions";

        [ConfigurationProperty(ConfigurationSectionName)]
        [ConfigurationCollection(typeof(SqlServerVersionDefinitionCollection))]
        public SqlServerVersionDefinitionCollection SqlServerVersions  
        {
            get { return (SqlServerVersionDefinitionCollection)base[ConfigurationSectionName]; }
            set { base[ConfigurationSectionName] = value; }
        }

        public Dictionary<string, string> VersionMap
        {
            get 
            { 
                var map = new Dictionary<string, string>();
                foreach (SqlServerVersionDefinition entry in SqlServerVersions)
                {
                    map[entry.VersionString] = entry.VersionName;
                }

                return map;
            }
        }
    }
}