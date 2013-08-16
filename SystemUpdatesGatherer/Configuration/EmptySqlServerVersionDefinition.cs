namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration
{
    public class EmptySqlServerVersionDefinition : SqlServerVersionDefinition
    {
        public EmptySqlServerVersionDefinition(string versionString) : base(versionString, "Version string was not found!")
        {
        }
    }
}