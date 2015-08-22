namespace FractionCalculator
{
    using System;
    using System.Numerics;

    public struct Fraction
    {
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator { get; set; }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException("denumerator", "Denumerator can't be 0");
                }

                this.denominator = value;
            }
        }

        public Fraction Simplify
        {
            get
            {
                return this.Simpliyfy();
            }
        }

        public static Fraction operator +(Fraction frA, Fraction frB)
        {
            BigInteger newNumerator = ((BigInteger)frA.Numerator * frB.Denominator) + ((BigInteger)frA.Denominator * frB.Numerator);
            BigInteger newDenumerator = (BigInteger)frA.Denominator * frB.Denominator;

            if (newNumerator > long.MaxValue ||
                newNumerator < long.MinValue ||
                newDenumerator > long.MaxValue ||
                newDenumerator < long.MinValue)
            {
                throw new ArithmeticException("Addition of two fractions resulted in overflow of the numerator/denumerator limits");
            }

            return new Fraction((long)newNumerator, (long)newDenumerator);
        }

        public static Fraction operator -(Fraction frA, Fraction frB)
        {
            BigInteger newNumerator = ((BigInteger)frA.Numerator * frB.Denominator) - ((BigInteger)frA.Denominator * frB.Numerator);
            BigInteger newDenumerator = (BigInteger)frA.Denominator * frB.Denominator;

            if (newNumerator > long.MaxValue ||
                newNumerator < long.MinValue ||
                newDenumerator > long.MaxValue ||
                newDenumerator < long.MinValue)
            {
                throw new ArithmeticException("Substraction of two fractions resulted in overflow of the numerator/denumerator limits");
            }

            return new Fraction((long)newNumerator, (long)newDenumerator);
        }

        public override string ToString()
        {
            decimal fraction = (decimal)this.Numerator / this.Denominator;
            return string.Format("{0}/{1} = {2}", this.Numerator, this.Denominator, fraction);
        }

        private Fraction Simpliyfy()
        {
            long gCD = this.FindGCD(this.Numerator, this.Denominator);
            return new Fraction(this.Numerator / gCD, this.Denominator / gCD);
        }

        private long FindGCD(long a, long b)
        {
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }
    }
}