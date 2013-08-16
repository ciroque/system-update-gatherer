using System;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Core;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.ReportSinks
{
    public class CompositeSink : IReportSink, IDisposable
    {
        private readonly TextFileReportSink m_TextFileReportSink;
        private readonly ConsoleReportSink m_ConsoleReportSink;

        public CompositeSink(string filename)
        {
            m_ConsoleReportSink = new ConsoleReportSink();
            m_TextFileReportSink = new TextFileReportSink(filename);
        }

        public void WriteLine()
        {
            m_TextFileReportSink.WriteLine();
            m_ConsoleReportSink.WriteLine();
        }

        public void WriteLine(string format, params object[] fieldValues)
        {
            m_TextFileReportSink.WriteLine(format, fieldValues);
            m_ConsoleReportSink.WriteLine(format, fieldValues);
        }

        public void Dispose()
        {
            m_TextFileReportSink.Dispose();
        }
    }
}