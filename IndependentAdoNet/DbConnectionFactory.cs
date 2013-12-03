using System;
using System.Data;
using System.Data.SqlClient;

namespace IndependentAdoNet
{
    public enum DbConnectionType
    {
        MSSQL, ORACLE, MYSQL // so on
    }

    public class DbConnectionFactory
    {
        public static IDbConnection CreateDbConnection(DbConnectionType connectionType)
        {
            switch (connectionType)
            {
                case DbConnectionType.MSSQL:
                    return new SqlConnection("conStr");
                case DbConnectionType.ORACLE:
                    return null; // uygun tip dondurulur
                case DbConnectionType.MYSQL:
                    return null; // uygun tip dondurulur
            }

            throw new Exception("connection type not found");
        }
    }
}
