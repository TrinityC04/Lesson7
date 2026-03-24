namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Mini Exercise 1: Safe Division");
            Console.WriteLine("------------------------------");

            Mini_SafeDivision();

            //2
            Console.WriteLine("Mini Exercise 2: Top 3 Numbers");
            Console.WriteLine("------------------------------");

            Mini_TopThree();

            //3
            Console.WriteLine("Mini Exercise 3: Active User Count");
            Console.WriteLine("----------------------------------");

            Mini_ActiveUserCount();

            //4
            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var grouped = nums.GroupBy(n => n % 2 == 0 ? "Even" : "Odd");

            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Key} numbers:");
                Console.WriteLine(string.Join(", ", group));
                Console.WriteLine("");
            }


            //5
            Console.WriteLine("Mini Exercise 5: Student Marks Report");
            Console.WriteLine("-------------------------------------");

            Run();

            Console.ReadKey();
        }
        //Exercise 1
        static void Mini_SafeDivision()
        {
            Console.Write("Enter the numerator: ");
            string numeratorInput = Console.ReadLine();

            if (!int.TryParse(numeratorInput, out int numerator))
            {
                Console.WriteLine("Invalid input. Please enter a valid whole number for the numerator.");
                return;
            }

            Console.Write("Enter the denominator: ");
            string denominatorInput = Console.ReadLine();

            if (!int.TryParse(denominatorInput, out int denominator))
            {
                Console.WriteLine("Invalid input. Please enter a valid whole number for the denominator.");
                return;
            }

            try
            {
                int result = numerator / denominator;
                Console.WriteLine($"Result: {numerator} / {denominator} = {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero. Please use a non-zero denominator.");
            }
        }

        //Exercise 2
        static void Mini_TopThree()
        {
            var nums = new List<int> { 3, 99, 12, 44, 5, 44 };

            Console.WriteLine("Original numbers:");
            Console.WriteLine(string.Join(", ", nums));

            var topThree = nums
                .OrderByDescending(n => n)
                .Take(3)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Top 3 numbers:");
            Console.WriteLine(string.Join(", ", topThree));
        }

        //Exercise 3
        static void Mini_ActiveUserCount()
        {
            var users = new List<User>
            {
                new User("trini@example.com", true),
                new User("nyiko@example.com", false),
                new User("banele@example.com", true),
                new User("nstika@example.com", false),
                new User("tshepi@example.com", true)
            };

            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                string status = user.IsActive ? "Active" : "Inactive";
                Console.WriteLine($"- {user.Email} | {status}");
            }

            int activeUserCount = users.Count(u => u.IsActive);

            Console.WriteLine();
            Console.WriteLine($"Number of active users: {activeUserCount}");
        }

        //Exercise 5
        public static void Run()
        {
            var students = new List<Student>
            {
                new Student("Alice",  78),
                new Student("Bob",    92),
                new Student("Charlie",65),
                new Student("Diana",  88),
                new Student("Ethan",  55),
                new Student("Farah",  81),
                new Student("Greg",   49),
                new Student("Hannah", 73)
            };


            Console.WriteLine("Students with marks >= 80 (for loop):");
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Mark >= 80)
                {
                    Console.WriteLine($"{students[i].Name} - {students[i].Mark}");
                }
            }
            Console.WriteLine("");


            var passedStudents = students.Where(s => s.Mark >= 70);


            Console.WriteLine("Passed students (>= 70):");
            foreach (var student in passedStudents)
            {
                Console.WriteLine($"{student.Name} - {student.Mark}");
            }
            Console.WriteLine("");

            var passedNames = passedStudents
                .Select(s => s.Name)
                .ToList();

            var sortedStudents = students
                .OrderByDescending(s => s.Mark)
                .ThenBy(s => s.Name);

            Console.WriteLine("All students sorted by mark desc, name asc:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Name} - {student.Mark}");
            }
            Console.WriteLine("");

            Console.WriteLine($"Total students: {students.Count}");
            Console.WriteLine($"Any students passed (>=70): {students.Any(s => s.Mark >= 70)}");
            Console.WriteLine($"Average mark: {students.Average(s => s.Mark):F2}");
            Console.WriteLine("");


            var topMarks =
                from s in students
                where s.Mark >= 80
                select s.Mark;

            Console.WriteLine("Marks >= 80 (query syntax):");
            foreach (var mark in topMarks)
            {
                Console.WriteLine(mark);
            }

            Console.WriteLine($"Number of marks >= 80: {topMarks.Count()}");
        }
    }
}
