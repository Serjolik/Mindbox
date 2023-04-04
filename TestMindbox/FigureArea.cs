using System;
using System.Collections.Generic;
using System.Linq;

namespace TestMindbox
{
    public class FigureArea
    {
        private double area;

        private enum FigureType
        {
            Circle,
            RightTriangle,
            BaseTriangle
        };

        private FigureType type;

        double Max(double a, double b) => a > b ? a : b;
        double Max(double a, double b, double c) => Max(Max(a, b), c);
        double Min(double a, double b) => a < b ? a : b;
        double Sqr(double a) => a * a;


        private void CircleArea(double r)
        {
            Console.WriteLine("Circle area method selected");
            type = FigureType.Circle;

            if (r < 0)
            {
                throw new ArgumentException("radius cant be < 0");
            }

            area = Math.PI * r * r;

            Console.WriteLine(area);
        }

        private void TriangleArea(double a, double b, double c)
        {
            Console.WriteLine("Triangle area method selected");

            if (!isTriangle(a, b, c))
            {
                throw new ArgumentException("Isnt triangle");
            }

            if (RightTriangleTest(a, b, c))
            {
                type = FigureType.RightTriangle;
            }
            else
            {
                type = FigureType.BaseTriangle;
            }

            if (a < 0 && b < 0 && c < 0)
            {
                throw new ArgumentException("side cant be < 0");
            }

            double semi_perimeter = (a + b + c) / 2;
            area = Math.Sqrt(semi_perimeter * 
                (semi_perimeter - a) * 
                (semi_perimeter - b) * 
                (semi_perimeter - c)
                );

            Console.WriteLine(area);
        }

        private bool isTriangle(double a, double b, double c)
        {
            if (a + b < c)
                return false;
            if (a + c < b)
                return false;
            if (b + c < a)
                return false;
            return true;
        }

        private bool RightTriangleTest(double a, double b, double c)
        {
            if (Sqr(Min(a, b)) + Sqr(Min(a, c)) == Sqr(Max(a, b, c)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Start()
        {
            Console.WriteLine("Enter the data separated by a space");
            string input = Console.ReadLine();
            var digits = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<double> arr = new List<double>();

            foreach (var digit in digits)
            {
                bool isNumeric = double.TryParse(digit, out _);
                if (isNumeric)
                    arr.Add(Convert.ToDouble(digit));
            }

            try
            {
                switch (arr.Count)
                {
                    case 1:
                        CircleArea(arr[0]);
                        break;
                    case 3:
                        TriangleArea(arr[0], arr[1], arr[2]);
                        break;
                    default:
                        Console.WriteLine("Unknown method with this number of params");
                        break;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The numbers you entered is incorrect, please try again.");
            }

        }

    }
}
