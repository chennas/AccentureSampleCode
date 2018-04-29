using System;

namespace SampleCode_Accenture.OCP
{
    public class Openclosed
    {
        //2. Open Close Principle
        // Here DataAccessProvider is open for extension (extends to Sql, Oracle, etc..) and closed for manipulation
        abstract class DataAccessProvider
        {
            public abstract int OpenConnection();
            public abstract int CloseConnection();
            public abstract int ExecuteCommand();
        }
        class SqlDataProvider : DataAccessProvider
        {
            public override int OpenConnection()
            {
                Console.WriteLine("\nSql Connection opened successfully");
                return 1;
            }
            public override int CloseConnection()
            {
                Console.WriteLine("Sql Connection closed successfully");
                return 1;
            }
            public override int ExecuteCommand()
            {
                Console.WriteLine("Sql Command Executed successfully");
                return 1;
            }
        }
        class OracleDataProvider : DataAccessProvider
        {
            public override int OpenConnection()
            {
                Console.WriteLine("Oracle Connection opened successfully");
                return 1;
            }
            public override int CloseConnection()
            {
                Console.WriteLine("Oracle Connection closed successfully");
                return 1;
            }
            public override int ExecuteCommand()
            {
                Console.WriteLine("Oracle Command Executed successfully");
                return 1;
            }
        }

        class OpenClosePrincipleDemo
        {
            public static void OSPDemo()
            {
                Console.WriteLine("\n\nOpen Close Principle Demo ");

                DataAccessProvider dataAccessProviderObject = new SqlDataProvider();
                dataAccessProviderObject.OpenConnection();
                dataAccessProviderObject.ExecuteCommand();
                dataAccessProviderObject.CloseConnection();

                dataAccessProviderObject = new OracleDataProvider();
                dataAccessProviderObject.OpenConnection();
                dataAccessProviderObject.ExecuteCommand();
                dataAccessProviderObject.CloseConnection();
            }
        }
    }
}
