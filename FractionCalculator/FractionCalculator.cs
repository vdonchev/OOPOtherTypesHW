namespace FractionCalculator
{
    using System;

    public static class FractionCalculator
    {
        public static void Main()
        {
            Fraction a = new Fraction(6, 18);
            Fraction b = new Fraction(7, 8);
            Console.WriteLine(a + b);
            Console.WriteLine((a + b).Simplify);
        }
    }
}
 