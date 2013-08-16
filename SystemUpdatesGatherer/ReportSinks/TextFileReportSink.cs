using System;
using System.IO;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Core;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.ReportSinks
{
    public class TextFileReportSink : IReportSink, IDisposable
    {
        private readonly StreamWriter m_File;


        public TextFileReportSink(string filename)
        {
            m_File = File.CreateText(filename);
        }

        public void WriteLine()
        {
            m_File.WriteLine();
        }

        public void WriteLine(string format, params object[] fieldValues)
        {
            m_File.WriteLine(format, fieldValues);
            m_File.Flush();
        }

        public void Dispose()
        {
            if (m_File != null)
            {
                m_File.Flush();
                m_File.Close();
            }
        }
    }
}