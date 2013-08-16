using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Configuration;
using Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Core;

namespace Ciroque.DevOps.Utilities.SystemUpdatesGatherer.Gatherers
{
    public class SqlServerVersionGatherer : IGatherUpdates
    {
        private readonly IList<ITargetSqlServer> m_SqlServers;
        private readonly Dictionary<string, string> m_VersionMap;

        public SqlServerVersionGatherer(ISqlServerList sqlServers, ISqlServerVersionMap versionMap)
        {
            m_SqlServers = sqlServers.SqlServers;
            m_VersionMap = versionMap.VersionMap;
        }

        public void GatherAndReport(IReportSink sink)
        {
            sink.WriteLine();
            sink.WriteLine("------------------------ ------------------------------------------------------");
            sink.WriteLine("{0, -24} SqlServerVersionGatherer", DateTime.Now.ToUniversalTime().ToString());
            sink.WriteLine();

            foreach (ITargetSqlServer targetSqlServer in m_SqlServers)
            {
                using (var connection = new SqlConnection(targetSqlServer.ConnectionString))
                {
                    var command = connection.CreateCommand();
                    var adapter = new SqlDataAdapter(command);
                    var table = new DataTable("MSVer");

                    command.CommandText = "xp_msver";
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        adapter.Fill(table);

                        var row = table.Select("[NAME] = 'ProductVersion'");
                        var version = row[0][3].ToString();

                        if (m_VersionMap.ContainsKey(version))
                        {
                            sink.WriteLine("{0, -30}\t{1, -12}\t{2}", targetSqlServer.ServerName, version, m_VersionMap[version]);
                        }
                        else
                        {
                            sink.WriteLine("{0, -30}\t{1, -12}\tNOT FOUND IN MAP", targetSqlServer.ServerName, version);
                        }
                    }
                    catch (Exception e)
                    {
                        sink.WriteLine("EXCEPTION! > {0} ==> {1}", targetSqlServer.ServerName, e.Message);
                    }
                }
            }
        }
    }
}