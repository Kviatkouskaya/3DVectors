using System;

namespace Vectors
{
    class Vector
    {
        private readonly double x;
        private readonly double y;
        private readonly double z;
        public Vector(double a, double b, double c)
        {
            x = a;
            y = b;
            z = c;
        }
        public static bool CheckEquals(Vector first, Vector second)
        {
            return first.x == second.x &&
                   first.y == second.y &&
                   first.z == second.z;
        }
        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector(first.x + second.x,
                              first.y + second.y,
                              first.z + second.z);
        }
        public static Vector operator -(Vector first, Vector second)
        {
            return new Vector(first.x - second.x,
                              first.y - second.y,
                              first.z - second.z);
        }
        public static Vector operator *(Vector first, double number)
        {
            return new Vector(first.x * number,
                              first.y * number, 
                              first.z * number);
        }
    }
    class Program
    {
        public static string InputVectors()
        {
            Console.WriteLine("Enter three coordinates of vector");
            return Console.ReadLine();
        }
        public static Vector ParseLine(string line)
        {
            string[] stringVector = line.Split(',');
            double[] vectors = Array.ConvertAll(stringVector, double.Parse);
            return new Vector(vectors[0], vectors[1], vectors[2]);
        }
        static void Main()
        {

        }
    }
}
