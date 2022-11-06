using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Fraction
    {
        private int numerator, denominator;

        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction(int numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }

        public Fraction(Fraction x)
        {
            this.numerator = x.numerator;
            this.denominator = x.denominator;
        }

        public Fraction times(Fraction other)
        {
            if (other.denominator == 0)
            {
                throw new Exception("Denominator can't be a 0!");
            }
            Fraction result = new Fraction();
            result.numerator = this.numerator * other.numerator;
            result.denominator = this.denominator * other.denominator;
            return result;
        }

        public Fraction dividedBy(Fraction other)
        {
            if(other.numerator == 0)
            {
                throw new Exception("Divide by 0 error!");
            }
            Fraction result = new Fraction();
            result.numerator = this.numerator * other.denominator;
            result.denominator = this.denominator * other.numerator;
            return result;
        }

        public Fraction plus(Fraction other)
        {
            if (other.denominator == 0)
            {
                throw new Exception("Denominator can't be a 0!");
            }
            Fraction result = new Fraction();
            result.numerator = this.numerator * other.denominator + other.numerator * this.denominator;
            result.denominator = this.denominator * other.denominator;
            return result;
        }
        public Fraction minus(Fraction other)
        {
            if (other.denominator == 0)
            {
                throw new Exception("Denominator can't be a 0!");
            }
            Fraction result = new Fraction();
            result.numerator = this.numerator * other.denominator - other.numerator * this.denominator;
            result.denominator = this.denominator * other.denominator;
            return result;
        }

        int gcd(int numerator, int denominator)
        {
            int temp = 0;
            while (denominator != 0)
            {
                temp = denominator;
                denominator = numerator % denominator;
                numerator = temp;
            }
            return numerator;
        }

        public Fraction reduced()
        {
            Fraction result = new Fraction();
            int div = gcd(this.numerator, this.denominator);
            result.numerator = this.numerator / div;
            result.denominator = this.denominator / div;
            return result;
        }

        public override string ToString()
        {
            if (numerator == 0)
            {
                return "0";
            }
            else
            {
                return numerator + "/" + denominator;
            }
            
        }
    }
}
