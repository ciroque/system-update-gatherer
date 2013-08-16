using System;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Core;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.ReportSinks
{
    public class ConsoleReportSink : IReportSink
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string format, params object[] fieldValues)
        {
            Console.WriteLine(format, fieldValues);
        }
    }
}