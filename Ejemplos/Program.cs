using Ejemplos.BLL;
using System;
using System.Runtime.CompilerServices;

namespace Ejemplos
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;

           

            do
            {
                Console.Clear();
                Console.WriteLine("MENU: \n\n");
                Console.WriteLine("1. Save Student in DB");
                Console.WriteLine("2. Simple Querying");
                Console.WriteLine("3. Update Data");
                Console.WriteLine("4. Delete Data");
                Console.WriteLine("5. Updating Data on Disconnected Scenario");
                Console.WriteLine("6. ChangeTracker");
                Console.WriteLine("7. Exit\n");

   
                menu = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                switch (menu)
                {
                    case 1:
                        SchoolBLL.SaveGradeDB();
                        SchoolBLL.SaveStudentDB();
                        Console.ReadLine();
                        break;

                    case 2:
                        SchoolBLL.SimpleQuerying();
                        Console.ReadLine();
                        break;
                    case 3:
                        SchoolBLL.UpdatingData();
                        Console.ReadLine();
                        break;

                    case 4:
                        SchoolBLL.DeletingData();
                        Console.ReadLine();
                        break;

                    case 5:
                        SchoolBLL.UpdatingOnDisconnectedScenario();
                        Console.ReadLine();
                        break;

                    case 6:
                        SchoolBLL.ChangeTracker();
                        Console.ReadLine();
                        break;
                }

            } while (menu != 7);

        }
    }
}
