using System.Configuration;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    [ConfigurationCollection(typeof(TargetSqlServer))]
    public class TargetSqlServerCollection : TargetServerCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TargetSqlServer();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TargetSqlServer)element).ServerName;
        }
    }
}