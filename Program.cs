namespace MillionaireAssignment
{
    internal class Program
    {
        public struct Players()
        {
            public string Last_Name, First_Name, Interest;
            public int team;


        }
        static void Main(string[] args)
        {
            Players[] students = new Players[35];
            studentfile(students);
            Sort(students);
            Displayfile(students);
            SaveFile(students);

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
            Console.ReadLine();
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
        static void Displayfile(Players[] students)
        {
            Console.WriteLine($"{"First Name",-14} | {"Last_Name",-14} | {"Interest",-14}");
            foreach (Players stu in students)
            {
                Console.WriteLine($"{stu.First_Name,-14} | {stu.Last_Name,-14} | {stu.Interest,-14}");
            }
            Console.ReadLine();
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
