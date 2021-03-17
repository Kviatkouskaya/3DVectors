using System;

namespace Vectors
{
    public class Vector
    {
        private readonly double x;
        private readonly double y;
        private readonly double z;
        public Vector(double[] vectors)
        {
            x = vectors[0];
            y = vectors[1];
            z = vectors[2];
        }
        public static bool operator ==(Vector first, Vector second)
        {
            return first.x == second.x &&
                   first.y == second.y &&
                   first.z == second.z;
        }
        public static bool operator !=(Vector first, Vector second)
        {
            return first.x != second.x ||
                   first.y != second.y ||
                   first.z != second.z;
        }
        public static Vector operator +(Vector first, Vector second)
        {
            double[] vector = {first.x + second.x,
                              first.y + second.y,
                              first.z + second.z };
            return new Vector(vector);
        }
        public static Vector operator -(Vector first, Vector second)
        {
            double[] vector = {first.x - second.x,
                              first.y - second.y,
                              first.z - second.z };
            return new Vector(vector);
        }
        public static Vector operator *(Vector first, double number)
        {
            double[] vector = {first.x * number,
                              first.y * number,
                              first.z * number };
            return new Vector(vector);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) && obj != null;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(x * y * z);
        }
        public static string ToString(Vector vector)
        {
            return $" {vector.x}, {vector.y}, {vector.z}";
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
        public static double[] ParseLine(string line)
        {
            string[] stringVector = line.Split(',');
            CheckStringArray(stringVector);
            double[] result = Array.ConvertAll(stringVector, double.Parse);
            return result;
        }
        static void Main()
        {
            Vector first = new(ParseLine(InputVector()));
            Vector second = new (ParseLine(InputVector()));
            Console.WriteLine($"\nMinus operation result is: {Vector.ToString(first - second)}");
            Console.WriteLine($"Plus operation result is: {Vector.ToString(first + second)}");
            Console.WriteLine($"Comparison result is: {first == second}");
        }
    }
}
