using System.Collections.Generic;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public interface ISqlServerList
    {
        IList<ITargetSqlServer> SqlServers { get; }
    }
}