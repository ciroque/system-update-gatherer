using System;
using System.Configuration;
using System.Diagnostics;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Core;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.ReportSinks;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer
{
    class Program
    {
        static void Main()
        {
            var targetSqlServers = (TargetSqlServerSection)ConfigurationManager.GetSection("TargetSqlServers");
            var sqlServerVersionDefinitionSection = (SqlServerVersionDefinitionSection)ConfigurationManager.GetSection("SqlServerVersionStringMap");
            var targetWindowsServers = (TargetWindowsServerSection)ConfigurationManager.GetSection("TargetWindowsServers");

            var filename = ConfigurationManager.AppSettings["OutputFilename"];
            var haveFilename = !string.IsNullOrEmpty(filename);
            var sink = haveFilename ? (IReportSink)new CompositeSink(filename) : new ConsoleReportSink();

            var executor = new Executor(targetWindowsServers, targetSqlServers, sqlServerVersionDefinitionSection, sink);
            executor.Execute();

            Console.WriteLine();
            if (haveFilename)
            {
                Console.WriteLine("Output written to {0}", filename);
                Console.Write("Would you like to view the file? (Y|N): ");
                char read = (char) Console.Read();
                if (read == 'Y' || read == 'y')
                {
                    Process.Start("NOTEPAD.EXE", filename);
                }
            }
        }
    }
}
