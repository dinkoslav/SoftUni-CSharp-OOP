using System;

public class Student
{
    private string name;
    private int age;

    public event PropertyChangedEventHandler PropertyChanged;



    public Student(string name, int age)
    {
        this.Name = name;
        this.age = age;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Name can not be empty!");
                throw new ArgumentException();
            }
            PropertyChangedEventArgs ev = new PropertyChangedEventArgs("Name", this.name, value);
            this.name = value;
            OnPropertyChanged(this, ev);
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (0 > value || value >= 100)
            {
                throw new ArgumentOutOfRangeException("age", "Age must be in range [0 ... 100]!");
            }
            PropertyChangedEventArgs ev = new PropertyChangedEventArgs("Age", this.age, value);
            this.age = value;
            OnPropertyChanged(this, ev);
        }
    }

    protected void OnPropertyChanged(object sender, PropertyChangedEventArgs ev)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(sender, ev);
        }
    }

}

