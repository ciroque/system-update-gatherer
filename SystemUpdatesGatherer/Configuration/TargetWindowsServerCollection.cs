using System.Configuration;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    [ConfigurationCollection(typeof(TargetWindowsServer))]
    public class TargetWindowsServerCollection : TargetServerCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TargetServer();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TargetServer)element).ServerName;
        }
    }
}