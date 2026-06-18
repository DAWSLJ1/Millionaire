using Microsoft.VisualBasic;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using static System.Console;

namespace MillionaireAssignment
{
    internal class Program
    {
       public static Players[] students = new Players[35];
       public static Players[] finalist = new Players[10];
        public struct Players()
        {
            public string lastName, firstName, interest;
            public int team;


        }
        static void Main()
        {
            studentfile();
            string asciiArt = @"
 _    _ _                                 _           _          _
| |  | | |                               | |         | |        | |
| |  | | |__   ___   __      ____ _ _ __ | |_   ___  | |_ ___   | |__   ___
| |/\| | '_ \ / _ \  \ \ /\ / / _` | '_ \| __| / __| | __/ _ \  | '_ \ / _ \
\  /\  / | | | (_) |  \ V  V / (_| | | | | |_  \__ \ | || (_) | | |_) |  __/
 \/  \/|_| |_|\___/    \_/\_/ \__,_|_| |_|\__| |___/  \__\___/  |_.__/ \___|


                    _ _ _ _                   _
                   (_) | (_)                 (_)
  __ _    _ __ ___  _| | |_  ___  _ __   __ _ _ _ __ ___
 / _` |  | '_ ` _ \| | | | |/ _ \| '_ \ / _` | | '__/ _ \
| (_| |  | | | | | | | | | | (_) | | | | (_| | | | |  __/
 \__,_|  |_| |_| |_|_|_|_|_|\___/|_| |_|\__,_|_|_|  \___|
";

            Random rng = new Random();

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = (ConsoleColor)rng.Next(1, 16);
                Console.WriteLine(asciiArt);

                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("1. View Player List");
                Console.WriteLine("2. Change Player Interest");
                Console.WriteLine("3. View top 10 Contestants");
                Console.WriteLine("4. Play Game");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("Choice: ");

                DateTime endTime = DateTime.Now.AddMilliseconds(1000);

                while (DateTime.Now < endTime)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);

                        switch (key.KeyChar)
                        {
                            case '1':
                                Console.Clear();
                                PlayerMenu();
                                break;

                            case '2':
                                Console.Clear();
                                Change();
                                break;

                            case '3':
                                Console.Clear();
                                Top10();
                                break;
                            case '4':
                                Console.Clear();
                                Game();
                                break;

                            case '5':
                                Environment.Exit(0);
                                break;
                        }
                    }

                    Thread.Sleep(10);
                }
            }
        }


        public static void Top10()
        {

            
            List<int> Pastplayers = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < finalist.Length; i++)
            {
                int tempInt = 0;
                bool newrand = true;
                while (newrand)
                {
                    tempInt = rand.Next(1, 36);
                    newrand = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (Pastplayers[j] == tempInt)
                        {
                            newrand = true;
                        }

                    }

                }
                Pastplayers.Add(tempInt);
                finalist[i] = students[tempInt];
            }
            for (int i = 0; i < finalist.Length; i++)
            {
                
                    Console.WriteLine(finalist[i].firstName + " " + finalist[i].lastName);
                
            }
            Console.ReadLine();
            Clear();
            Main();
        }
        public static void PlayerMenu()
        {
            Players[] students = new Players[35];
            studentfile();
           Sort();
            Displayfile();
            Console.WriteLine();
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Console.Clear();
            Console.Write("\x1b[3Jm");
            Console.Clear();
            Main();
        }
        public static void Change()
        {
            Alter();

        }
        static void Alter()
        {
            bool play = true;

            studentfile();
            bool found = false;
            Console.WriteLine("Which player would you like to change? (Via Last Name)");
            string wanted = Console.ReadLine();
            while (play)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i].lastName == wanted)
                    {
                        found = true;
                        Console.WriteLine("What would you like to change it to?");
                        string alt = Console.ReadLine();
                        students[i].interest = (alt);
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("Not found");
                    Console.ReadLine();
                }
                Clear();
                Sort();
                Displayfile();
                Console.ReadLine();
                SaveFile(students);
                Console.WriteLine();
                Console.Clear();
                Main();
            }
        }
        static void studentfile()
        {
            StreamReader sr = new StreamReader(@"Millionaire.txt");
            int index = 0;
            Random rand = new Random();
            while (!sr.EndOfStream)
            {
                students[index].firstName = sr.ReadLine().Trim();
                students[index].lastName = sr.ReadLine().Trim();
                students[index].interest = sr.ReadLine().Trim();
                index++;
            }
            sr.Close();
        }
        static void Sort()
        {

            Array.Sort(students, (x, y) => y.lastName.CompareTo(x.lastName));
            Array.Reverse(students);


        }
        public static void Displayfile()
        {
            Console.WriteLine($"{"First Name",-14} | {"LastName",-14} | {"Interest",-14}");
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"{students[i].firstName,-14} | {students[i].lastName,-14} | {students[i].interest,-14}");
            }
        }
        static void SaveFile(Players[] students)
        {
            StreamWriter sw = new StreamWriter(@"Millionaire.txt");
            Console.WriteLine($"{"First Name",-14} | {"LastName",-14} | {"Interest",-14}");
            foreach (Players stu in students)
            {
                sw.WriteLine(stu.firstName);
                sw.WriteLine(stu.lastName);
                sw.WriteLine(stu.interest);
            }
            sw.Close();
        }
            public static void Game()
        {
            Random random = new Random();

            int question = 1;
            Console.WriteLine($"\tQuestion {question}");
            Console.WriteLine();
        }
        public static void Questions()
        {

        }
    }
}
