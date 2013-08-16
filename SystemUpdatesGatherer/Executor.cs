using System;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Core;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Gatherers;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer
{
    public class Executor
    {
        private readonly IServerList m_WindowsServers;
        private readonly ISqlServerList m_SqlServers;
        private readonly ISqlServerVersionMap m_SqlServerVersionMap;
        private readonly IReportSink m_Sink;

        public Executor(
            IServerList windowsServers, 
            ISqlServerList sqlServers, 
            ISqlServerVersionMap sqlServerVersionMap,
            IReportSink sink)
        {
            m_WindowsServers = windowsServers;
            m_SqlServers = sqlServers;
            m_SqlServerVersionMap = sqlServerVersionMap;
            m_Sink = sink;
        }

        public void Execute()
        {
            if (m_WindowsServers != null)
            {
                Gather(new WindowsServerUpdateGatherer(m_WindowsServers));
            }

            if (
                m_SqlServerVersionMap != null
                && m_SqlServers != null
               )
            {
                Gather(new SqlServerVersionGatherer(m_SqlServers, m_SqlServerVersionMap));
            }
        }

        private void Gather(IGatherUpdates gatherer)
        {
            try
            {
                gatherer.GatherAndReport(m_Sink);
            }
            catch (Exception e)
            {
                m_Sink.WriteLine("Exception occurred executing the {0} => {1}", gatherer.GetType().ToString(), e.Message);
            }
        }
    }
}