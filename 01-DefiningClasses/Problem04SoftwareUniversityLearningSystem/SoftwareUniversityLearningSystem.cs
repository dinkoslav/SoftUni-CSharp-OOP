using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem04SoftwareUniversityLearningSystem
    {
    class SoftwareUniversityLearningSystem
        {
        static void Main(string[] args)
            {

            List<CurrentStudent> students = new List<CurrentStudent>()
            {
                new OnlineStudent("Dinko", "Minkov", 32, 54613, 6.00, "OOP"),
                new OnlineStudent("Steff", "Meff", 23, 24564, 6.00, "OOP"),
                new OnlineStudent("Toli", "Boli", 33, 24626, 2.00, "OOP"),
                new OnlineStudent("Icho", "Micho", 21, 57673, 3.33, "OOP"),
                new OnsiteStudent("Gosho", "Mosho", 26, 77567, 4.30, "OOP", 3),
                new OnsiteStudent("Pencho", "Mencho", 29, 12355, 4.00, "OOP", 8),
                new OnsiteStudent("Minka", "Pinka", 40, 09985, 5.50, "OOP", 4),
                new OnsiteStudent("Toz", "Onzi", 18, 23456, 5.00, "OOP", 4)
            };

            var orderedStudents = students.OrderByDescending(s => s.AverageGrade);
            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student.ToString());
            }
            }
        }
    }
