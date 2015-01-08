using System;

[Version(2, 11)]

public class GenericList<T>
{
    const int Capacity = 16;
    private T[] elements;
    private int count = 0;

    public GenericList(int capacity = Capacity)
    {
        this.elements = new T[capacity];
    }

    public int Count
    {
        get { return this.count; }
    }

    public static T Min<T>(T first, T second)
        where T : IComparable<T>
    {
        if (first.CompareTo(second) > 0)
        {
            return second;
        }
        else
        {
            return first;
        }
    }

    public static T Max<T>(T first, T second)
        where T : IComparable<T>
    {
        if (first.CompareTo(second) > 0)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    public void AddElement(T value)
    {
        if (this.count == this.elements.Length)
        {
            T[] newList = new T[this.elements.Length * 2];
            for (int i = 0; i < this.count; i++)
            {
                newList[i] = this.elements[i];
            }
            this.elements = newList;
        }
        this.elements[this.count] = value;
        this.count++;
    }

    public T ElementAtIndex(int index)
    {
        ValidateIndex(index);
        return this.elements[index];
    }

    public void RemoveElement(int index)
    {
        ValidateIndex(index);

        T[] newList = new T[this.elements.Length];
        int tempIndex = 0;
        for (int i = 0; i < this.elements.Length; i++)
        {
            if (i != index)
            {
                newList[tempIndex] = this.elements[i];
                tempIndex++;
            }
        }

        this.elements = newList;
        this.count--;
    }

    public void InsertElementAtIndex(int index, T value)
    {
        if (index >= this.count)
        {
            this.AddElement(value);
        }
        else if (index < 0)
        {
            throw new IndexOutOfRangeException("Index can not be negative number!");
        }
        else
        {
            T[] newList = new T[this.count + 1];
            for (int i = 0; i < newList.Length; i++)
            {
                if (i < index)
                {
                    newList[i] = this.elements[i];
                }
                else if (i == index)
                {
                    newList[i] = value;
                }
                else
                {
                    newList[i] = this.elements[i - 1];
                }
            }

            this.elements = newList;
            this.count++;
        }
    }

    public void ClearList()
    {
        this.elements = new T[this.elements.Length];
        this.count = 0;
    }

    public void FindIndex(T value)
    {
        bool elementFound = false;

        for (int i = 0; i < this.count; i++)
        {
            if (this.elements[i].Equals(value))
            {
                Console.WriteLine(i);
                elementFound = true;
            }
        }

        if (!elementFound)
        {
            Console.WriteLine("There is no element with value: {0}", value);
        }
    }

    public bool Contains(T value)
    {
        bool elementFound = false;

        for (int i = 0; i < this.count; i++)
        {
            if (this.elements[i].Equals(value))
            {
                elementFound = true;
            }
        }

        return elementFound;
    }

    public override string ToString()
    {
        string list = "";
        for (int i = 0; i < this.count; i++)
        {
            list += elements[i] + " ";
        }

        return list;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new IndexOutOfRangeException("Index is out of range!");
        }
    }
}
