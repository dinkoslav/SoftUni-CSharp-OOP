using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanStudentWorker
{
    class Test
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Pesho", "Goshev", "237EHD"),
                new Student("Marijka", "Nikolova", "5WGEG7EHD"),
                new Student("Yanko", "Petrov", "MKGV54D"),
                new Student("Philip", "Bogdanov", "HEJ356SD"),
                new Student("Nencho", "Zambov", "789KYIMH"),
                new Student("Stolichani", "Vpoveche", "RTHDFH4846"),
                new Student("Matilda", "Rozova", "9853G"),
                new Student("Bendji", "Zaks", "HDSRHUG45"),
                new Student("Toshko", "Rosenov", "KY5J5"),
                new Student("Bogdan", "Motev", "T586D")
            };

            // Sorting with LINQ expression:
            //var sortedStudents =
            //    from student in students
            //    orderby student.FacultiNumber ascending
            //    select student;

            // Sorting with OrderBy():
            var sortedStudents = students.OrderBy(s => s.FacultiNumber);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            List<Worker> workers = new List<Worker>()
            {
                new Worker("Pesho", "Goshev", 200m, 8),
                new Worker("Marijka", "Nikolova", 150m, 7),
                new Worker("Yanko", "Petrov", 165m, 10),
                new Worker("Philip", "Bogdanov", 120m, 5),
                new Worker("Nencho", "Zambov", 123.50m, 6),
                new Worker("Stolichani", "Vpoveche", 99m, 4),
                new Worker("Matilda", "Rozova", 111m, 2),
                new Worker("Bendji", "Zaks", 250m, 11),
                new Worker("Toshko", "Rosenov", 204m, 9),
                new Worker("Bogdan", "Motev", 50m, 1)
            };

            // Sorting with LINQ expression:
            //var sortedWorkers =
            //    from worker in workers
            //    orderby worker.MoneyPerHour() descending 
            //    select worker;

            // Sorting with OrderBy():
            var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour());

            foreach (var sortedWorker in sortedWorkers)
            {
                Console.WriteLine(sortedWorker);
            }
            Console.WriteLine();

            // Mergig Lists of Students and Workers and sorting them:
            List<Human> humans = new List<Human>();
            foreach (Student student in students)
            {
                humans.Add(student);
            }

            foreach (Worker worker in workers)
            {
                humans.Add(worker);
            }


            // Sorting with LINQ expression:
            //var sortedHumans =
            //    from human in humans
            //    orderby human.FirstName ascending, human.LastName ascending 
            //    select human;

            // Sorting with OrderBy():
            var sortedHumans = humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);

            foreach (var human in sortedHumans)
            {
                Console.WriteLine(human);
            }
        }
    }
}
