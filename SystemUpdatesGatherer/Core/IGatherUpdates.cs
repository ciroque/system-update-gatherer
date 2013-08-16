namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Core
{
    public interface IGatherUpdates
    {
        void GatherAndReport(IReportSink sink);
    }
}