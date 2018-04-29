using System;

namespace SampleCode_Accenture.SRP
{
    public class SinlgeResponsibility
    {
        //1. Single Responsibility Principle

        // Data access class is only responsible for data base related operations
        class DataAccess
        {
            public static void SaveData()
            {
                Console.WriteLine("Data saved into database successfully");
            }
        }
        // Validation class is only responsible for validation related operations
        class Validation
        {
            public static void WriteLog()
            {
                Console.WriteLine("Validated Successfully");
            }
        }
    }
}
