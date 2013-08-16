using System.Collections.Generic;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public interface IServerList
    {
        IList<ITargetServer> Servers { get; } 
    }
}