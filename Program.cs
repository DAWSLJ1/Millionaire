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
        public static Random rand = new Random();
        public static int previousQuestionIndex = -1;
        public static Players[] students = new Players[35];
        public static Players[] finalist = new Players[10];
       public static int question = 1, correct = 0;
        public static bool win = false;
        public static List<int> usedQuestions = new List<int>();

        public struct Question
        {
            public string questionText;
            public string optionA;
            public string optionB;
            public string optionC;
            public string optionD;
            public char correctAnswer;
        }
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
                    tempInt = rand.Next(1, students.Length);
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
                Thread.Sleep(25);
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
            Console.WriteLine($"\tQuestion {question}");
            Console.WriteLine();

            Questions();

            Console.ReadLine();
        }
        public static void Questions()
        {
           
            Question[] questions =
            {
        new Question
        {
            questionText = "What is the capital of New Zealand?",
            optionA = "A) Auckland",
            optionB = "B) Christchurch",
            optionC = "C) Wellington",
            optionD = "D) Hamilton",
            correctAnswer = 'C'
        },

        new Question
        {
            questionText = "How many continents are there?",
            optionA = "A) 5",
            optionB = "B) 6",
            optionC = "C) 7",
            optionD = "D) 8",
            correctAnswer = 'C'
        },

        new Question
        {
            questionText = "Who wrote Romeo and Juliet?",
            optionA = "A) Charles Dickens",
            optionB = "B) William Shakespeare",
            optionC = "C) Mark Twain",
            optionD = "D) Jane Austen",
            correctAnswer = 'B'
        },

        new Question
        {
            questionText = "What is 5 x 6?",
            optionA = "A) 25",
            optionB = "B) 30",
            optionC = "C) 35",
            optionD = "D) 40",
            correctAnswer = 'B'
        },
         new Question
        {
            questionText = "What colour is an orange?",
            optionA = "A) Orange",
            optionB = "B) Yellow",
            optionC = "C) Green",
            optionD = "D) Apple",
            correctAnswer = 'A'
        }
    };
            if (usedQuestions.Count == questions.Length)
            {
                usedQuestions.Clear();
            }

            int randomIndex;

            do
            {
                randomIndex = rand.Next(questions.Length);
            }
            while (usedQuestions.Contains(randomIndex));

            usedQuestions.Add(randomIndex);

            Question selectedQuestion = questions[randomIndex];

            Console.WriteLine();
            Console.WriteLine(selectedQuestion.questionText);
            Console.WriteLine();
            Console.WriteLine(selectedQuestion.optionA);
            Console.WriteLine(selectedQuestion.optionB);
            Console.WriteLine(selectedQuestion.optionC);
            Console.WriteLine(selectedQuestion.optionD);
            Console.WriteLine();
            Console.Write("Final Answer (A, B, C, D): ");

            char userAnswer = Char.ToUpper(Console.ReadKey().KeyChar);

            Console.WriteLine();

            if (userAnswer == selectedQuestion.correctAnswer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Correct! You've won money!");
                question++;
                correct++;
                Console.ResetColor();
                Console.WriteLine();
                money();
                Console.ReadLine();
                Console.ResetColor();
                if (correct >= 5)
                {
                    question = 1;
                    correct = 0;
                    Win();
                }
                if (correct <= 5)
                { 
                    Clear();
                    Game();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\tIncorrect!");
                Console.WriteLine($"The correct answer was {selectedQuestion.correctAnswer}.");
                Console.ResetColor ();
                Console.ReadLine();
                question++;
                question = 1;
                correct = 0;
                Main();
            }

            Console.ResetColor();
        }
        public static void money()
        {
            if (correct == 1)
            {
                Console.WriteLine("Winnings");
                Console.WriteLine("");
                Console.WriteLine("1,000,000");
                Console.WriteLine("100,000");
                Console.WriteLine("1,000");
                Console.WriteLine("100");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1");
                Console.ResetColor();
            }
            if (correct == 2)
            {
                Console.WriteLine("Winnings");
                Console.WriteLine("");
                Console.WriteLine("1,000,000");
                Console.WriteLine("100,000");
                Console.WriteLine("1,000");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("100");
                Console.WriteLine("1");
                Console.ResetColor();
            }
            if (correct == 3)
            {
                Console.WriteLine("Winnings");
                Console.WriteLine("");
                Console.WriteLine("1,000,000");
                Console.WriteLine("100,000");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1,000");
                Console.WriteLine("100");
                Console.WriteLine("1");
                Console.ResetColor();
            }
            if (correct == 4)
            {
                Console.WriteLine("Winnings");
                Console.WriteLine("");
                Console.WriteLine("1,000,000");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("100,000");
                Console.WriteLine("1,000");
                Console.WriteLine("100");
                Console.WriteLine("1");
                Console.ResetColor();
            }
            if (correct == 5)
            {
                Console.WriteLine("Winnings");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1,000,000");
                Console.WriteLine("100,000");
                Console.WriteLine("1,000");
                Console.WriteLine("100");
                Console.WriteLine("1");
                Console.ResetColor();
                win = true;
            }
        }
        public static void Win()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@"/================================================\");
            Console.WriteLine(@"||__   __           __        ___         _   _ ||");
            Console.WriteLine(@"||\ \ / /__  _   _  \ \      / (_)_ __   | | | |||");
            Console.WriteLine(@"|| \ V / _ \| | | |  \ \ /\ / /| | '_ \  | | | |||");
            Console.WriteLine(@"||  | | (_) | |_| |   \ V  V / | | | | | |_| |_|||");
            Console.WriteLine(@"||  |_|\___/ \__,_|    \_/\_/  |_|_| |_| (_) (_)||");
            Console.WriteLine(@"||                                              ||");
            Console.WriteLine(@"\================================================/");
            Console.ReadLine();
            Main();
        }
    }
}
