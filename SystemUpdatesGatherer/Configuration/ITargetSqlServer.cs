namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public interface ITargetSqlServer : ITargetServer
    {
        string ConnectionString { get; }
    }
}