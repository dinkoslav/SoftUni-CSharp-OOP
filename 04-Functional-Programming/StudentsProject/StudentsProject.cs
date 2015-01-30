using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class StudentsProject
    {
    static void Main()
        {
        List<Student> students = new List<Student>()
        {
            new Student("Petyr", "Divanov", 32, 203114, "02 877-97-05-05", "petyr@abv.bg", 
                new List<int>{3, 3, 4, 5, 5}, 3),
            new Student("Katq", "Misheva", 26, 202011, "+3592 878-91-11-15", "kateto@gmail.bg", 
                new List<int>{3, 2, 2}, 2),
            new Student("Emo", "Emilov", 21, 203021, "+359 2899-91-99-22", "emilestiq@yahoo.bg", 
                new List<int>{3, 3, 4, 2}, 2),
            new Student("Petyrcho", "Ivanchev", 33, 204124, "877-97-15-15", "petyraki@yahoo.bg", 
                new List<int>{6, 3, 4, 6, 6}, 2),
            new Student("Katerina", "Mihailova", 21, 223414, "878-11-11-15", "katerinka@mail.bg", 
                new List<int>{3, 2, 4, 6, 2}, 2),
            new Student("Valio", "Valev", 28, 203421, "899-11-99-22", "valkata@abv.bg", 
                new List<int>{5, 3, 2, 2}, 3)
        };

        // Problem 4.Students by Group
        var studentsByGroup =
            from student in students
            where student.GroupNumber == 2
            orderby student.FirstName
            select student;

        //PrintStudents(studentsByGroup);

        // Problem 5.Students by First and Last Name
        var studentsByName =
            from student in students
            where student.FirstName.CompareTo(student.LastName) == -1
            orderby student.FirstName
            select student;

        //PrintStudents(studentsByName);

        // Problem 6.Students by Age
        var studentsByAge =
            from student in students
            where student.Age >= 18 && student.Age <= 24
            select new { FName = student.FirstName, LName = student.LastName, Age = student.Age };

        //foreach (var studentByAge in studentsByAge)
        //    {
        //    Console.WriteLine(studentByAge.FName + " " + studentByAge.LName + " is " + studentByAge.Age + " years old.");
        //    }

        // Problem 7.Sort Students

        var sortedStudents = students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);

        var linqSortedStudents =
            from student in students
            orderby student.FirstName descending, student.LastName descending
            select student;
        //PrintStudents(sortedStudents);
        //PrintStudents(linqSortedStudents);

        // Problem 8.Filter Students by Email Domain
        var studentsByMail =
            from student in students
            where student.Email.IndexOf("@abv.bg") > -1
            select student;

        //PrintStudents(studentsByMail);

        // Problem 9.Filter Students by Phone

        var studentsByPhone =
            from student in students
            where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2")
            select student;

        //PrintStudents(studentsByPhone);

        // Problem 10.Excellent Students

        var studentsByMaxGrade =
            from student in students
            where student.Marks.Contains(6)
            select new { FName = student.FirstName, LName = student.LastName, Marks = student.Marks };

        //foreach (var studentByMaxGrade in studentsByMaxGrade)
        //    {
        //    Console.Write(studentByMaxGrade.FName + " " + studentByMaxGrade.LName + " has: ");
        //    foreach (var mark in studentByMaxGrade.Marks)
        //        {
        //        Console.Write(mark + " ");
        //        }
        //    Console.WriteLine(" marks.");
        //    }

        // Problem 11.Weak Students

        var studentsByMinGrade =
            students.Where(s => s.Marks.Contains(2))
                .Select(st => new{FName = st.FirstName, LName = st.LastName, Marks = st.Marks});


        //foreach (var studentByMinGrade in studentsByMinGrade)
        //    {
        //    Console.Write(studentByMinGrade.FName + " " + studentByMinGrade.LName + " has: ");
        //    foreach (var mark in studentByMinGrade.Marks)
        //        {
        //        Console.Write(mark + " ");
        //        }
        //    Console.WriteLine(" marks.");
        //    }

        // Problem 12.Students Enrolled in 2014

        var studentsFacNum = students.Where(s => s.FacultyNumber.ToString().EndsWith("14"));

        //PrintStudents(studentsFacNum);


        }



    public static void PrintStudents(dynamic givenStudents)
        {
        foreach (var student in givenStudents)
            {
            Console.WriteLine(student);
            }
        }
    }