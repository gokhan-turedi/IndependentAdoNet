namespace IndependentAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var con = DbConnectionFactory.CreateDbConnection(DbConnectionType.MSSQL);
            var db = new IndependentAdoNet(con);
            var result = db.GetData("select * from ..");
        }
    }
}
