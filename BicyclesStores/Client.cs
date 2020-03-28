using System;

namespace BicyclesStores
{
    public class Client
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Welcome to Bicycles Stores Company");
            Console.WriteLine("**********************************");

            RunUserOptions.Options();
            
            Console.ReadKey();
        }
    }
}
