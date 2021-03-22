using System;

namespace Vectors
{
    public class Vector
    {
        public readonly double[] vectorArray = new double[3];
        public Vector(double a, double b, double c)
        {
            vectorArray[0] = a;
            vectorArray[1] = b;
            vectorArray[2] = c;
        }
        public static bool operator ==(Vector first, Vector second)
        {
            for (int i = 0; i < first.vectorArray.Length; i++)
            {
                if (first.vectorArray[i] != second.vectorArray[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator !=(Vector first, Vector second)
        {
            for (int i = 0; i < first.vectorArray.Length; i++)
            {
                if (first.vectorArray[i] != second.vectorArray[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static Vector operator +(Vector first, Vector second)
        {
            Vector vector = Clone(first);
            for (int i = 0; i < vector.vectorArray.Length; i++)
            {
                vector.vectorArray[i] += second.vectorArray[i];
            }
            return vector;
        }
        public static Vector operator -(Vector first, Vector second)
        {
            Vector vector = Clone(first);
            for (int i = 0; i < vector.vectorArray.Length; i++)
            {
                vector.vectorArray[i] -= second.vectorArray[i];
            }
            return vector;
        }
        public static Vector operator *(Vector first, double number)
        {
            Vector vector = Clone(first);
            for (int i = 0; i < vector.vectorArray.Length; i++)
            {
                vector.vectorArray[i] *= number;
            }
            return vector;
        }
        public static double operator *(Vector first, Vector second)
        {
            double multiplication = 0;
            for (int i = 0; i < first.vectorArray.Length; i++)
            {
                multiplication += first.vectorArray[i] * second.vectorArray[i];
            }
            return multiplication;
        }
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) && obj != null;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(vectorArray[0] * vectorArray[1] * vectorArray[2]);
        }
        public static string ToString(Vector vector)
        {
            return $" {vector.vectorArray[0]}, {vector.vectorArray[1]}, {vector.vectorArray[2]}";
        }
        public static Vector Clone(Vector value)
        {
            return new Vector(value.vectorArray[0], value.vectorArray[1], value.vectorArray[2]);
        }
    }
    public class Program
    {
        public static string InputVector()
        {
            Console.WriteLine("Enter three coordinates of vector");
            return Console.ReadLine();
        }
        public static void CheckStringArray(string[] stringVector)
        {
            if (stringVector.Length != 3)
            {
                throw new ArgumentException("Enter only three coordinates");
            }
            foreach (var item in stringVector)
            {
                if (!double.TryParse(item, out double x))
                {
                    throw new FormatException("Entered invalid symbol");
                }
            }
        }
        public static Vector ParseLine(string line)
        {
            string[] stringVector = line.Split(',');
            CheckStringArray(stringVector);
            double[] result = Array.ConvertAll(stringVector, double.Parse);
            return new Vector(result[0], result[1], result[2]);
        }
        static void Main()
        {
            Vector first = ParseLine(InputVector());
            Vector second = ParseLine(InputVector());
            Console.WriteLine("Enter number: ");
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine($"\nComparison result is: {first == second}");
            Console.WriteLine($"Not compare operation is: {first != second}");
            Console.WriteLine($"Plus operation result is: {Vector.ToString(first + second)}");
            Console.WriteLine($"Minus operation result is: {Vector.ToString(first - second)}");
            Console.WriteLine($"Vectors and number multiplication is: {Vector.ToString(first * number)}");
            Console.WriteLine($"Vectors multiplication is: {first * second}");
        }
    }
}
