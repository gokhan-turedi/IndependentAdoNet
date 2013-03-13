using System;
using System.Data;

namespace ClientApp
{
    class IndependentAdoNet:IDisposable
    {
        private IDbConnection _connection;
        private IDbCommand _command;

        public IndependentAdoNet(IDbConnection connection)
        {
            _connection = connection;
            
            connection.Open();

            _command = _connection.CreateCommand();
        }

        public int ExecuteQuery(string query)
        {
            _command.CommandText = query;

            var affectedRows = _command.ExecuteNonQuery();
            _command.Parameters.Clear();

            return affectedRows;
        }

        public DataTable GetData(string query)
        {
            var resultTable = new DataTable();

            _command.CommandText = query;

            using (var reader = _command.ExecuteReader())
                resultTable.Load(reader);

            _command.Parameters.Clear();

            return resultTable;
        }

        public void Dispose()
        {
            if (_connection != null) 
                _connection.Close();
        }
    }
}
