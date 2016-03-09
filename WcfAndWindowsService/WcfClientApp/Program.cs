using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfClientApp.CommunicatorReference;

namespace WcfClientApp
{
    class Program
    {
        private static CommunicatorClient serviceClient;

        static Program()
        {
            serviceClient = new CommunicatorClient();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                PrintMenu();
                var option = Console.ReadKey();
                Console.WriteLine("\n--------------------------\n");
                switch (option.KeyChar)
                {
                    case '0':
                        return;
                    case '1':
                        SetMultiplier();
                        break;
                    case '2':
                        GetLastResult();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Select one of the following options:\n");
            Console.WriteLine("|1| - Set multiplier");
            Console.WriteLine("|2| - Get last result");
            Console.WriteLine("|0| - Exit\n");
            Console.Write("Selected option: ");
        }

        private static void SetMultiplier()
        {
            Console.WriteLine("Type below the desired multiplier value.");
            Console.Write("Multiplier: ");
            var typedValue = Console.ReadLine();
            Console.WriteLine();
            int newMultiplier;

            try
            {
                newMultiplier = int.Parse(typedValue);
            }
            catch
            {
                Console.WriteLine("Invalid value. Multiplier must be an integer value. Aborting.");
                Thread.Sleep(2000);
                return;
            }

            serviceClient.SetMultiplier(newMultiplier);

            Console.WriteLine("Multiplier successfully changed");
            Thread.Sleep(2000);
        }

        private static void GetLastResult()
        {
            var result = serviceClient.GetLastResult();

            Console.WriteLine("Above is displayed data generated during last operation");
            Console.WriteLine(string.Format("Multiplicand: {0}",result.Multiplicand));
            Console.WriteLine(string.Format("Multiplier..: {0}", result.Multiplier));
            Console.WriteLine(string.Format("Product.....: {0}", result.Product));

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
