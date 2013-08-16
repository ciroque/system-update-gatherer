using System.Configuration;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public class SqlServerVersionDefinition : ConfigurationElement
    {
        public SqlServerVersionDefinition()
        {
        }

        protected SqlServerVersionDefinition(string versionString, string versionName)
        {
            VersionString = versionString;
            VersionName = versionName;
        }

        private const string VersionKey = "versionString";
        private const string VersionNameKey = "versionName";

        [ConfigurationProperty(VersionKey, IsRequired = true, DefaultValue = "0.0.0.0", IsKey = true)]
        public string VersionString
        {
            get { return (string) this[VersionKey];  }
            set { this[VersionKey] = value; }
        }

        [ConfigurationProperty(VersionNameKey, IsRequired = true, DefaultValue = "SqlServer")]
        public string VersionName
        {
            get { return (string) this[VersionNameKey];  }
            set { this[VersionNameKey] = value; }
        }
    }
}