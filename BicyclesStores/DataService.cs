using System;
using System.Data.SqlClient;

namespace BicyclesStores
{
    public class DataService
    {
        const string connectionString = @"Server = .;"
                                        + "Database = BicycleStores_Midterm;"
                                        + "Integrated Security = true";
        public static void GetStaffContact(string fName, string lName)
        {
            var queryStaffContact =
                "SELECT FirstName, LastName, Email, Phone " +
                "FROM Sales.Staff " +
                "WHERE FirstName = @fname AND LastName = @lname ";

            string param1 = fName;
            string param2 = lName;

            using (var connection = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryStaffContact, connection);
                commandline.Parameters.AddWithValue("@fname", param1);
                commandline.Parameters.AddWithValue("@lname", param2);

                try
                {
                    connection.Open();
                    var reader = commandline.ExecuteReader();
                    Console.WriteLine("Result: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["FirstName"]}, " +
                                          $"{reader["LastName"]}, " +
                                          $"{reader["Email"]}, " +
                                          $"{reader["Phone"]}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }
            }
        }
        public static void GetStoreAndContactViaCityState(string inCity, string inState)
        {
            var queryStoreContactViaCityState =
                "SELECT StoreName, Phone, Email, Street, City, State, ZipCode " +
                "FROM Sales.Stores " +
                "WHERE City = @city AND State = @state ";

            string param1 = inCity;
            string param2 = inState;
       
            using (var connection = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryStoreContactViaCityState, connection);
                commandline.Parameters.AddWithValue("@city", param1);
                commandline.Parameters.AddWithValue("@state", param2);
         
                try
                {
                    connection.Open();
                    var reader = commandline.ExecuteReader();
                    Console.WriteLine("Result: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["StoreName"]}, " +
                                          $"{reader["Phone"]}, " +
                                          $"{reader["Email"]}, " +
                                          $"{reader["Street"]}, " +
                                          $"{reader["City"]}, " +
                                          $"{reader["State"]}, " +
                                          $"{reader["ZipCode"]}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }
            }
        }
        public static void GetStoreAndContactViaStoreID(int inStoreID)
        {
            var queryStoreContactViaStoreID =
                "SELECT StoreName, Phone, Email, Street, City, State, ZipCode " +
                "FROM Sales.Stores " +
                "WHERE StoreId = @storeid ";

            int param1 = inStoreID;

            using (var connection = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryStoreContactViaStoreID, connection);
                commandline.Parameters.AddWithValue("@storeid", param1);

                try
                {
                    connection.Open();
                    var reader = commandline.ExecuteReader();
                    Console.WriteLine("Result: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["StoreName"]}, " +
                                          $"{reader["Phone"]}, " +
                                          $"{reader["Email"]}, " +
                                          $"{reader["Street"]}, " +
                                          $"{reader["City"]}, " +
                                          $"{reader["State"]}, " +
                                          $"{reader["ZipCode"]}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }
            }
        }
        public static void GetOrderStatus(int inOrderID)
        {
            var queryGetOrderStatus =
                "SELECT OrderID, " +
                "CASE OrderStatus " +
                "WHEN 4 THEN 'Completed' " +
                "WHEN 3 THEN 'Rejected' " +
                "WHEN 2 THEN 'Processing' " +
                "ELSE 'Pending' " +
                "END AS CurrentStatus, " +
                "OrderDate, RequiredDate, ShippedDate " +
                "FROM Sales.Orders " +
                "WHERE OrderID = @orderid ";

            int param1 = inOrderID;

            using (var connectionOne = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryGetOrderStatus, connectionOne);
                commandline.Parameters.AddWithValue("@orderid", param1);

                try
                {
                    connectionOne.Open();
                    var reader = commandline.ExecuteReader();
                    Console.WriteLine("Result: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["OrderID"]}, " +
                                          $"{reader["CurrentStatus"]}");
                                        
                        Console.WriteLine($"{reader["OrderDate"]}, " +
                                          $"{reader["RequiredDate"]}, " +
                                          $"{reader["ShippedDate"]}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }
            }
        }

        public static void CheckProdAvailViaProdID(int inProdID)
        {
            var queryProdAvailabilityViaProdID =
                "SELECT Quantity, StoreName, Phone, Email, Street, City, State, ZipCode " +
                "FROM Sales.Stores ss JOIN Production.Stocks ps ON ss.StoreId = ps.StoreId " +
                "WHERE ProductId = @prodid " +
                "GROUP BY ProductId, Quantity, StoreName, Phone, Email, Street, City, State, ZipCode ";

            int param1 = inProdID;

            using (var connectionOne = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryProdAvailabilityViaProdID, connectionOne);
                commandline.Parameters.AddWithValue("@prodid", param1);

                try
                {
                    connectionOne.Open();
                    var reader = commandline.ExecuteReader();
                    Console.WriteLine("Result: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Quantity: {reader["Quantity"]}, " +
                                          $"{reader["StoreName"]}, " +
                                          $"{reader["Phone"]}, " +
                                          $"{reader["Email"]}, " +
                                          $"{reader["Street"]}, " +
                                          $"{reader["City"]}, " +
                                          $"{reader["State"]}, " +
                                          $"{reader["ZipCode"]}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }
            }
        }
        public static void CheckAvailProdViaName(String inProdName)
        {
            var queryProdAvailabilityViaProdName =
                "SELECT Quantity, StoreName, Phone, Email, Street, City, State, ZipCode " +
                "FROM Sales.Stores ss JOIN Production.Stocks ps ON ss.StoreId = ps.StoreId " +
                "JOIN Production.Products pp ON ps.ProductId = pp.ProductId " +
                "WHERE ProductName = @prodname " +
                "GROUP BY Quantity, StoreName, Phone, Email, Street, City, State, ZipCode ";

            string param1 = inProdName;

            using (var connectionOne = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryProdAvailabilityViaProdName, connectionOne);
                commandline.Parameters.AddWithValue("@prodname", param1);

                try
                {
                    connectionOne.Open();
                    var reader = commandline.ExecuteReader();
                    Console.WriteLine("Result: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Quantity: {reader["Quantity"]}, " +
                                          $"{reader["StoreName"]}, " +
                                          $"{reader["Phone"]}, " +
                                          $"{reader["Email"]}, " +
                                          $"{reader["Street"]}, " +
                                          $"{reader["City"]}, " +
                                          $"{reader["State"]}, " +
                                          $"{reader["ZipCode"]}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }
            }
        }
        public static void UpdateCustInfoViaCustID(int inCustID)
        {
            var queryGetCustInfoViaID =
                "SELECT FirstName, LastName, ISNULL(Phone, 'NoPhoneAvail') AS PhoneNumber, " +
                "Email, Street, City, State, ZipCode " +
                "FROM Sales.Customers " +
                "WHERE CustomerId = @custid";

            int param1 = inCustID;

            using (var connectionOne = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryGetCustInfoViaID, connectionOne);
                commandline.Parameters.AddWithValue("@custid", param1);

                try
                {
                    connectionOne.Open();
                    var reader = commandline.ExecuteReader();
                    Console.WriteLine("Result: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["FirstName"]}, " +
                                          $"{reader["LastName"]}");
                        Console.WriteLine($"{reader["PhoneNumber"]}, " +
                                          $"{reader["Email"]}");
                        Console.WriteLine($"{reader["Street"]}, " +
                                          $"{reader["City"]}, " +
                                          $"{reader["State"]}, " +
                                          $"{reader["ZipCode"]}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }
            }
            
            Console.WriteLine("");
            Console.WriteLine("[1] FirstName, [2] LastName, [3] Phone, [4] Email");
            Console.WriteLine("[5] Street, [6] City, [7] State, [8] ZipCode");
            int toUpdate;
            Console.Write("Data to be updated: ");
            toUpdate = Convert.ToInt32(Console.ReadLine());
            string newData;
            Console.Write("Replaced with: ");
            newData = Console.ReadLine();

            ChoiceOfUpdateViaID(inCustID, toUpdate, newData);
        }
        public static void ChoiceOfUpdateViaID(int inCustID, int toUpdate, string inNewData)
        {
            int param1 = inCustID;
            string param2 = inNewData;
            string param3 = "";
            switch (toUpdate)
            {
                case 1:
                    param3 = "FirstName";
                    break;
                case 2:
                    param3 = "LastName";
                    break;
                case 3:
                    param3 = "Phone";
                    break;
                case 4:
                    param3 = "Email";
                    break;
                case 5:
                    param3 = "Street";
                    break;
                case 6:
                    param3 = "City";
                    break;
                case 7:
                    param3 = "State";
                    break;
                case 8:
                    param3 = "ZipCode";
                    break;
                default:
                    param3 = "FirstName";
                    break;
            }

            var queryUpdateThisData =
                string.Format("UPDATE Sales.Customers " +
                              "SET {0} = @newData " +
                              "WHERE CustomerId = @custid ", param3);

            using (var connectionOne = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryUpdateThisData, connectionOne);
                commandline.Parameters.AddWithValue("@custid", param1);
                commandline.Parameters.AddWithValue("@newData", param2);

                try
                {
                    connectionOne.Open();
                    commandline.ExecuteNonQuery();
                    Console.WriteLine("Result: Data has been updated.");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }
            }
        }
        public static void UpdateCustInfoViaName(string fName, string lName)
        {
            var queryGetCustInfoViaName =
                "SELECT FirstName, LastName, ISNULL(Phone, 'NoPhoneAvail') AS PhoneNumber, " +
                "Email, Street, City, State, ZipCode " +
                "FROM Sales.Customers " + 
                "WHERE FirstName = @fname AND LastName = @lname ";

            string param1 = fName;
            string param2 = lName;

            using (var connectionOne = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryGetCustInfoViaName, connectionOne);
                commandline.Parameters.AddWithValue("@fname", param1);
                commandline.Parameters.AddWithValue("@lname", param2);

                try
                {
                    connectionOne.Open();
                    var reader = commandline.ExecuteReader();
                    Console.WriteLine("Result: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["FirstName"]}, " +
                                          $"{reader["LastName"]}");
                        Console.WriteLine($"{reader["PhoneNumber"]}, " +
                                          $"{reader["Email"]}");
                        Console.WriteLine($"{reader["Street"]}, " +
                                          $"{reader["City"]}, " +
                                          $"{reader["State"]}, " +
                                          $"{reader["ZipCode"]}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }

                Console.WriteLine("");
                Console.WriteLine("[1] FirstName, [2] LastName, [3] Phone, [4] Email");
                Console.WriteLine("[5] Street, [6] City, [7] State, [8] ZipCode");
                int toUpdate;
                Console.Write("Data to be updated: ");
                toUpdate = Convert.ToInt32(Console.ReadLine());
                string newData;
                Console.Write("Replaced with: ");
                newData = Console.ReadLine();

                ChoiceOfUpdateViaName(fName, lName, toUpdate, newData);
            }
        }

       public static void ChoiceOfUpdateViaName(string fName, string lName, int toUpdate, string inNewData)
       {
            string param1 = fName;
            string param2 = lName;
            string param3 = inNewData;
            string param4 = "";
            switch (toUpdate)
            {
                case 1:
                    param4 = "FirstName";
                    break;
                case 2:
                    param4 = "LastName";
                    break;
                case 3:
                    param4 = "Phone";
                    break;
                case 4:
                    param4 = "Email";
                    break;
                case 5:
                    param4 = "Street";
                    break;
                case 6:
                    param4 = "City";
                    break;
                case 7:
                    param4 = "State";
                    break;
                case 8:
                    param4 = "ZipCode";
                    break;
                default:
                    param3 = "FirstName";
                    break;
            }

           var queryUpdateThisData =
               String.Format("UPDATE Sales.Customers " +
                             "SET {0} = @newData " +
                             "WHERE FirstName = @firstName " +
                             "AND LastName = @lastName ", param4);

            using (var connectionOne = new SqlConnection(connectionString))
            {
                var commandline = new SqlCommand(queryUpdateThisData, connectionOne);
                commandline.Parameters.AddWithValue("@firstName", param1);
                commandline.Parameters.AddWithValue("@lastname", param2);
                commandline.Parameters.AddWithValue("@newData", param3);

                try
                {
                    connectionOne.Open();
                    commandline.ExecuteNonQuery();
                    Console.WriteLine("Result: Data has been updated.");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                }
            }
       }
    }
}