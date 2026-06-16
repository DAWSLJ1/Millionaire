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
            
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("-----     WHO WANTS TO BE A MILLIONAIRE      -----");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. View Player List");
            Console.WriteLine("2. Change Player interest");
            Console.WriteLine("3. Play Game");
            Console.WriteLine("4. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    PlayerMenu();
                    break;
                    case 2:
                    Console.Clear();
                    Change();
                    break;
                    case 3:

                    break;
                    case 4:

                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    Thread.Sleep(500);
                    Console.Clear();
                    Main();
                    break;
            }
            

        }
        public static void PlayerMenu()
        {
            Players[] students = new Players[35];
            studentfile(students);
            Sort(students);
            Displayfile(students);
            Console.WriteLine() ;
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Console.Clear() ;
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
            Console.WriteLine($"{"First Name",-14} | {"lastName",-14} | {"interest",-14}");
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"{students[i].firstName,-14} | {students[i].lastName,-14} | {students[i].interest,-14}");
            }
        }
        static void SaveFile(Players[] students)
        {
            StreamWriter sw = new StreamWriter(@"Millionaire.txt");
            Console.WriteLine($"{"First Name",-14} | {"lastName",-14} | {"interest",-14}");
            foreach (Players stu in students)
            {
                sw.WriteLine(stu.firstName);
                sw.WriteLine(stu.lastName);
                sw.WriteLine(stu.interest);
            }
            sw.Close();
        }
    }
}
