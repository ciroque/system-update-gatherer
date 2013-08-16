using System;
using System.Configuration;
using System.Linq;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    [ConfigurationCollection(typeof(SqlServerVersionDefinition))]
    public class SqlServerVersionDefinitionCollection : ConfigurationElementCollection
    {
        internal const string ConfigurationElementPropertyElementName = "version";

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMapAlternate; }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(ConfigurationElementPropertyElementName, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override string ElementName
        {
            get { return ConfigurationElementPropertyElementName; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SqlServerVersionDefinition();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SqlServerVersionDefinition) element).VersionString;
        }

        public SqlServerVersionDefinition this[int index]
        {
            get { return (SqlServerVersionDefinition) BaseGet(index); }
        }

        public string LookUpVersion(string versionString)
        {
            var versionQuery =
                (from SqlServerVersionDefinition v 
                 in this 
                 where v.VersionString.Equals(versionString) 
                 select v).DefaultIfEmpty(new EmptySqlServerVersionDefinition(versionString));

            return versionQuery.FirstOrDefault().VersionName;
        }
    }
}