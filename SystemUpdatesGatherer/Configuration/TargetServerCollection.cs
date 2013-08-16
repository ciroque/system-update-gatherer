using System;
using System.Configuration;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public abstract class TargetServerCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "targetServer";

        protected override string ElementName
        {
            get { return PropertyName; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMapAlternate; }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
        }

//        public TargetSqlServer this[int index]
//        {
//            get { return (TargetSqlServer)BaseGet(index); }
//        }
    }
}