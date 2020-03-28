using System;

namespace BicyclesStores
{
    public class RunUserOptions
    {
        public static void Options()
        {
            char repeat;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Services available:");
                Console.WriteLine("[1] Get staff contact information.");
                Console.WriteLine("[2] Get store locations and contact information.");
                Console.WriteLine("[3] Check order status.");
                Console.WriteLine("[4] Check product availability.");
                Console.WriteLine("[5] Update your information.");

                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------");
                int userOpt;
                Console.Write("Operation to do: ");
                userOpt = Convert.ToInt32(Console.ReadLine());

                if (userOpt == 1)
                {
                    OptionOne();
                }
                else if (userOpt == 2)
                {
                    OptionTwo();
                }
                else if (userOpt == 3)
                {
                    OptionThree();
                }
                else if (userOpt == 4)
                {
                    OptionFour();
                }
                else if(userOpt == 5)
                {
                    OptionFive();
                }
                else
                {
                    Console.WriteLine("Input invalid.");
                    Console.WriteLine("");
                }

                Console.Write("New operation [Y/N]? ");
                repeat = Console.ReadKey().KeyChar;
            } while (repeat == 'y' || repeat == 'Y');
        }

        public static void OptionOne()
        {
            Console.WriteLine("-----------------------------------------");
            string firstName;
            Console.Write("Enter Staff's first name: ");
            firstName = Console.ReadLine();
            string lastName;
            Console.Write("Enter Staff's last name: ");
            lastName = Console.ReadLine();

            DataService.GetStaffContact(firstName, lastName);
        }

        public static void OptionTwo()
        {
            Console.WriteLine("-----------------------------------------");
            char funcTwo;
            Console.Write("Use [C]ity and State or [S]tore ID? ");
            funcTwo = Console.ReadKey().KeyChar;

            if (funcTwo == 'C' || funcTwo == 'c')
            {
                string cityName;
                Console.WriteLine("");
                Console.Write("Enter the City: ");
                cityName = Console.ReadLine();
                string stateName;
                Console.Write("Enter the State initial: ");
                stateName = Console.ReadLine();

                DataService.GetStoreAndContactViaCityState(cityName, stateName);
            }
            else if (funcTwo == 'S' || funcTwo == 's')
            {
                int theStoreID;
                Console.WriteLine("");
                Console.Write("Enter the Store ID: ");
                theStoreID = Convert.ToInt32(Console.ReadLine());

                DataService.GetStoreAndContactViaStoreID(theStoreID);
            }
            else
            {
                Console.WriteLine("Input invalid.");
                Console.WriteLine("");
            }
        }

        public static void OptionThree()
        {
            Console.WriteLine("-----------------------------------------");
            int theOrderID;
            Console.Write("Enter the Order ID: ");
            theOrderID = Convert.ToInt32(Console.ReadLine());

            DataService.GetOrderStatus(theOrderID);
        }

        public static void OptionFour()
        {
            Console.WriteLine("-----------------------------------------");
            char funcFour;
            Console.Write("Use [P]roduct ID or Product [N]ame? ");
            funcFour = Console.ReadKey().KeyChar;

            if (funcFour == 'P' || funcFour == 'p')
            {
                int theProdID;
                Console.WriteLine("");
                Console.Write("Enter the product ID: ");
                theProdID = Convert.ToInt32(Console.ReadLine());

                DataService.CheckProdAvailViaProdID(theProdID);
            }
            else if (funcFour == 'N' || funcFour == 'n')
            {
                string theProdName;
                Console.WriteLine("");
                Console.Write("Enter the product name: ");
                theProdName = Console.ReadLine();

                DataService.CheckAvailProdViaName(theProdName);
            }
            else
            {
                Console.WriteLine("Input invalid.");
                Console.WriteLine("");
            }
        }

        public static void OptionFive()
        {
            Console.WriteLine("-----------------------------------------");
            char funcFive;
            Console.Write("Use [C]ustomer ID or [N]ame? ");
            funcFive = Console.ReadKey().KeyChar;

            if (funcFive == 'C' || funcFive == 'c')
            {
                int custId;
                Console.WriteLine("");
                Console.Write("Enter customer's id number: ");
                custId = Convert.ToInt32(Console.ReadLine());

                DataService.UpdateCustInfoViaCustID(custId);
            }
            else if (funcFive == 'N' || funcFive == 'n')
            {
                string firstName;
                Console.WriteLine("");
                Console.Write("Enter customer first name: ");
                firstName = Console.ReadLine();
                string lastName;
                Console.Write("Enter customer last name: ");
                lastName = Console.ReadLine();

                DataService.UpdateCustInfoViaName(firstName, lastName);
            }
            else
            {
                Console.WriteLine("Input invalid.");
                Console.WriteLine("");
            }
        }
    }
}
