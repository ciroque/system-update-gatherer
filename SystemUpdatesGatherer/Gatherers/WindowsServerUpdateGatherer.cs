using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Core;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Gatherers
{
    public class WindowsServerUpdateGatherer : IGatherUpdates
    {
        private readonly IList<ITargetServer> m_Servers;

        public WindowsServerUpdateGatherer(IServerList servers)
        {
            m_Servers = servers.Servers;
        }

        public void GatherAndReport(IReportSink sink)
        {
            sink.WriteLine();
            sink.WriteLine("------------------------ ------------------------------------------------------");
            sink.WriteLine("{0, -24} WindowsServerUpdateGatherer", DateTime.Now.ToUniversalTime().ToString());
            sink.WriteLine();

            foreach (ITargetServer targetServer in m_Servers)
            {
                try
                {
                    sink.WriteLine();
                    sink.WriteLine(">>> {0}", targetServer.ServerName);

                    RetrieveAndReportUpdates(sink, targetServer);
                }
                catch (Exception e)
                {
                    sink.WriteLine("EXCEPTION! > {0} ==> {1}", targetServer.ServerName, e.Message);
                }
            }
        }

        private static void RetrieveAndReportUpdates(IReportSink sink, ITargetServer targetServer)
        {
            var wmiNamespace = string.Format("\\\\{0}\\root\\CIMV2", targetServer.ServerName);
            var searcher = new ManagementObjectSearcher(wmiNamespace, "select * from Win32_QuickFixEngineering");
            searcher.Options.UseAmendedQualifiers = true;
            searcher.Scope.Options.Locale = "MS_" + CultureInfo.CurrentCulture.LCID.ToString("X");
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject item in results)
            {
                sink.WriteLine("{0, -14}\t{1, -12}\t{2}", item["HotFixID"].ToString(), item["InstalledOn"].ToString(),
                               item["Caption"].ToString());
            }
        }
    }
}