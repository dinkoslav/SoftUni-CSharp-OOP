using System;

public class Test
{
    static void Main()
    {
        GenericList<int> nums = new GenericList<int>(2);
        // Add elements
        nums.AddElement(5);
        nums.AddElement(10);
        nums.AddElement(1);
        nums.AddElement(8);
        Console.WriteLine("List after adding elements: " + nums + "\n");

        // Remove elements
        nums.RemoveElement(1);
        nums.RemoveElement(2);
        Console.WriteLine("List after removing elements: " + nums + "\n");

        // show element at index
        Console.WriteLine("Element at given index: " + nums.ElementAtIndex(0) + "\n");

        // insert elements at index
        nums.InsertElementAtIndex(10, 50);
        Console.WriteLine(nums);
        nums.InsertElementAtIndex(1, 999);
        Console.WriteLine(nums + "\n");

        // find index of given element
        nums.FindIndex(999);
        nums.FindIndex(444);
        Console.WriteLine();

        // check if list contains element
        Console.WriteLine(nums.Contains(999));
        Console.WriteLine(nums.Contains(444));
        Console.WriteLine();

        // find min element
        Console.WriteLine("Min element is: " + GenericList<int>.Min(10, 7) + "\n");
        // find max element
        Console.WriteLine("Max element is: " + GenericList<string>.Max("Albena", "Ruse"));

        // clear list
        nums.ClearList();
        Console.WriteLine(nums);
    }
}
