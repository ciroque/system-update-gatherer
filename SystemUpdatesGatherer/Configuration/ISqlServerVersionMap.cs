using System.Collections.Generic;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public interface ISqlServerVersionMap
    {
        Dictionary<string, string> VersionMap { get; }
    }
}