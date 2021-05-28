using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestConsoleApp

{
    class Program
    {
        static void Main(string[] args)
        {
            bool startWizardQuest = true;
            while (startWizardQuest)
            {
                startWizardQuest = WizardQuest();
            }
        }

        private static bool WizardQuest()
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("     Wizard Quest\t\tTest Console");
            Console.WriteLine("=================================================");
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("\t1  - User Registration");
            Console.WriteLine("\t2  - User login");
            Console.WriteLine("\t3  - User logout");
            Console.WriteLine("\t4  - User Delete");
            Console.WriteLine("\t5  - New Quest");
            Console.WriteLine("\t6  - Join Quest");
            Console.WriteLine("\t7  - User Move");
            Console.WriteLine("\t8  - User Chat");
            Console.WriteLine("\t9  - Leave Quest");
            Console.WriteLine("\t10 - Administrator Adds User");
            Console.WriteLine("\t11 - Administrator Modifies User");
            Console.WriteLine("\t12 - Administrator Deletes User");
            Console.WriteLine("\t13 - Administrator Kills Quest");
            Console.WriteLine("\t14 - Top 10 High Scores");
            Console.WriteLine("\t15 - User List");
            Console.WriteLine("\t16 - User Inventory");
            Console.WriteLine("-------------------------------------------------");
            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {
                default:
                    return true;
                case "1":
                    UserRegistration();
                    return true;
                case "2":
                    UserLogin();
                    return true;
                case "3":
                    UserLogout();
                    return true;
                case "4":
                    UserDelete();
                    return true;
                case "5":
                    NewQuest();
                    return true;
                case "6":
                    JoinQuest();
                    return true;
                case "7":
                    UserMove();
                    return true;
                case "8":
                    UserChat();
                    return true;
                case "9":
                    LeaveQuest();
                    return true;
                case "10":
                    AdministratorAdd();
                    return true;
                case "11":
                    AdministratorModify();
                    return true;
                case "12":
                    AdministratorDelete();
                    return true;
                case "13":
                    AdministratorKill();
                    return true;
                case "14":
                    GetHighScores();
                    return true;
                case "15":
                    GetAllUsers();
                    return true;
                case "16":
                    GetUserInventory();
                    return true;
            }
        }

        private static void UserRegistration()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Registration");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserRegistration("Fred", "1234", "fred@emailaddress.com"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserLogin()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Login");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserLogin("Xavier", "1234"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserLogout()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Logout");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserLogout("7"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserDelete()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Delete");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserDelete("Tom", "1234"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void NewQuest()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting New Quest");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.NewQuest(7, "Xavs Super Quest"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void JoinQuest()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Join Quest");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.JoinQuest(10, 2));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserMove()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Move");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserMove(2, 3, 1, 2));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserChat()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Chat");
            Console.WriteLine("=================================================");
            Console.WriteLine("Chat = " + dataAccess.UserChat(1, 1, "I love WizardQuest!"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void LeaveQuest()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Leave Quest");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.LeaveQuest(1, 1));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void AdministratorAdd()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Administrator Adds User");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.AdministratorAdd("Jen", "1234", "jen@emailaddress.com", false));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void AdministratorModify()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Administrator Modifies User");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.AdministratorModify(3, "Sally", "1234", "sally@emailaddress.com", 0, false, true, 1000));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void AdministratorDelete()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Administrator Deletes User");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.AdministratorDelete(10));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void AdministratorKill()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Administrator Kills Quest");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.AdministratorKill(1));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void GetAllUsers()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Get All Users");
            Console.WriteLine("=================================================");
            Console.WriteLine("\tUsername");
            Console.WriteLine("-------------------------------------------------");

            foreach (var parameter in dataAccess.GetAllUsers())
            {
                Console.WriteLine("\t" + parameter.UserName);
            }

            Console.WriteLine("-------------------------------------------------");
            Pause();
        }
        private static void GetHighScores()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Get High Scores");
            Console.WriteLine("=================================================");
            Console.WriteLine("\tUsername \t\t Total Score");
            Console.WriteLine("-------------------------------------------------");

            foreach (var parameter in dataAccess.GetHighScores())
            {
                Console.WriteLine("\t" + parameter.UserName + " \t\t\t " + parameter.TotalScore);
            }

            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void GetUserInventory()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Get User Inventory");
            Console.WriteLine("=================================================");
            Console.WriteLine("\tItem \t\t\tQuantity");
            Console.WriteLine("-------------------------------------------------");

            foreach (var parameter in dataAccess.GetUserInventory(2))
            {
                Console.WriteLine("\t" + parameter.Item + " \t\t    " + parameter.Quantity);
            }

            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine("\npress any key to exit the process...");
            Console.ReadKey();
        }
    }
}
