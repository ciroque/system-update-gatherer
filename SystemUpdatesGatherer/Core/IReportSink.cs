namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Core
{
    public interface IReportSink
    {
        void WriteLine();
        void WriteLine(string format, params object[] fieldValues);
    }
}