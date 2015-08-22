namespace GenericList
{
    using System;
    using System.Collections.Generic;

    public class Test
    {
        public static void Main()
        {
            GenericList<int> a = new GenericList<int>();
            a.Add(15);
            a.Add(20);
            a.Add(30);
            a.Add(40);
            a.Add(55);
            a.Add(60);
            a.Add(70);
            a.Add(100);
            a.Add(100);
            Console.WriteLine(a.Capacity);
            a.Add(15);
            a[2] = 500;
            Console.WriteLine(a);
            Console.WriteLine(a.IndexOf(30));
            Console.WriteLine(a.Contains(500));
            a.InsertAt(10, 59);
            a.InsertAt(11, 59);
            a.InsertAt(12, 59);
            a.InsertAt(13, 59);
            a.InsertAt(14, 59);
            a.InsertAt(15, 59);
            a.InsertAt(16, 59);
            Console.WriteLine(a);
            Console.WriteLine(a.Capacity);
            Console.WriteLine(a.IsEmpty);
            Console.WriteLine(a.Min());
            Console.WriteLine(a.Max());
            a.Clear();
        }
    }
}
