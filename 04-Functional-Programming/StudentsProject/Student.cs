using System;
using System.Collections;
using System.Collections.Generic;

public class Student
    {
    private string firstName;
    private string lastName;
    private int age;
    private int facultyNumber;
    private string phone;
    private string email;
    private IList<int> marks;
    private int groupNumber;

    public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email, IList<int> marks, int groupNumber)
        {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.FacultyNumber = facultyNumber;
        this.Phone = phone;
        this.Email = email;
        this.Marks = marks;
        this.GroupNumber = groupNumber;
        }

    public string FirstName
        {
        get { return this.firstName; }
        set { this.firstName = value; }
        }

    public string LastName
        {
        get { return this.lastName; }
        set { this.lastName = value; }
        }

    public int Age
        {
        get { return this.age; }
        set { this.age = value; }
        }

    public int FacultyNumber
        {
        get { return this.facultyNumber; }
        set { this.facultyNumber = value; }
        }

    public string Phone
        {
        get { return this.phone; }
        set { this.phone = value; }
        }

    public string Email
        {
        get { return this.email; }
        set { this.email = value; }
        }

    public IList<int> Marks
        {
        get { return this.marks; }
        set { this.marks = value; }
        }

    public int GroupNumber
        {
        get { return this.groupNumber; }
        set { this.groupNumber = value; }
        }

    public override string ToString()
        {
        string student = this.firstName + " " + this.lastName + " is " + this.age + " years old. Faculty number is " + this.facultyNumber + ", phone number is " + this.phone + ", email is " + this.email + ". Marks : \n";
        foreach (var mark in this.marks)
            {
            student += mark + "\n";
            }
        student += "Group Number is : " + this.groupNumber;
        return student;
        }
    }
