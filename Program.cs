namespace MillionaireAssignment
{
    internal class Program
    {
        public struct Players()
        {
            public string Last_Name, First_Name, Interest;
            public int team;


        }
        static void Main()
        {
            
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("-----     WHO WANTS TO BE A MILLIONAIRE      -----");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. View Player List");
            Console.WriteLine("2. Change Player Interest");
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
            Players[] icecream = new Players[22];
            studentfile(students);
            bool found = false;
            Console.WriteLine("Which player would you like to change?");
            string wanted = Console.ReadLine();
            while (play)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i].Last_Name == wanted)
                    {
                        found = true;
                        Console.WriteLine("What would you like to change it to?");
                        string alt = Console.ReadLine();
                        students[i].Interest = (alt);
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("Not found");
                    Console.ReadLine();
                }
                SaveFile(students);
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
                students[index].First_Name = sr.ReadLine().Trim();
                students[index].Last_Name = sr.ReadLine().Trim();
                students[index].Interest = sr.ReadLine().Trim();
                index++;
            }
        }
        static void Sort(Players[] numbers)
        {
            Players temp;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int pos = 0; pos < numbers.Length - 1; pos++)
                {
                    if (numbers[pos + 1].Last_Name.CompareTo(numbers[pos].Last_Name) == -1)
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
            Console.WriteLine($"{"First Name",-14} | {"Last_Name",-14} | {"Interest",-14}");
            foreach (Players stu in students)
            {
                Console.WriteLine($"{stu.First_Name,-14} | {stu.Last_Name,-14} | {stu.Interest,-14}");
            }
        }
        static void SaveFile(Players[] students)
        {
            StreamWriter sw = new StreamWriter(@"NewMillionaire.txt");
            Console.WriteLine($"{"First Name",-14} | {"Last_Name",-14} | {"Interest",-14}");
            foreach (Players stu in students)
            {
                sw.WriteLine($"{stu.First_Name,-14} | {stu.Last_Name,-14} | {stu.Interest,-14}");
            }
            sw.Close();
        }
    }
}
