using System.Reflection;
using System.Threading;
using System;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace MillionaireAssignment
{
    internal class Program
    {
        public struct Players()
        {
            public string lastName, firstName, interest;
            public int team;


        }
        static void Main()
        {
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
        public static void Quit()
        {

        }


        public static void Top10()
        {
            int[] lotto = new int[10];
            Random rand = new Random();

            for (int i = 0; i < lotto.Length; i++)
            {
                int tempInt;
                bool isdup = true;
                while (isdup)
                {
                    tempInt = rand.Next(1, 36);
                    isdup = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (lotto[j] == tempInt)
                        {
                            isdup = true;
                        }

                    }
                    if (!isdup)
                    {
                        lotto[i] = tempInt;
                    }

                }
            }
            Array.Sort(lotto);
            Console.WriteLine(string.Join(", ", lotto));
            Console.ReadLine();
            Clear();
            Main();
        }
        public static void PlayerMenu()
        {
            Players[] students = new Players[35];
            studentfile(students);
            Sort(students);
            Displayfile(students);
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
            Players[] students = new Players[35];
            Alter(students);

        }
        static void Alter(Players[] students)
        {
            bool play = true;

            studentfile(students);
            bool found = false;
            Console.WriteLine("Which player would you like to change?");
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
                Displayfile(students);
                Console.ReadLine();
                SaveFile(students);
                Console.WriteLine();
                Console.Clear();
                Main();
            }
        }
        static void studentfile(Players[] students)
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
        static void Sort(Players[] numbers)
        {
            Players temp;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int pos = 0; pos < numbers.Length - 1; pos++)
                {
                    if (numbers[pos + 1].lastName.CompareTo(numbers[pos].lastName) == -1)
                    {
                        temp = numbers[pos + 1];
                        numbers[pos + 1] = numbers[pos];
                        numbers[pos] = temp;
                    }
                }
            }
        }
        public static void Displayfile(Players[] students)
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
            int question = 1;
            Console.WriteLine($"\tQuestion {question}");
            Console.WriteLine();
        }
        public static void Questions()
        {

        }
    }
}
