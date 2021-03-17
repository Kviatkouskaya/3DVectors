using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vectors3DTests
{
    [TestClass]
    public class ParseLineTests
    {
        [DataRow("1,2,3", 1, 2, 3)]
        [DataRow("3,7,1", 3, 7, 1)]
        [DataRow("6,1,2", 6, 1, 2)]
        [DataTestMethod]
        public void ParseLineTest(string line, double x, double y, double z)
        {
            double[] expected = { x, y, z };
            double[] actual = Vectors.Program.ParseLine(line);
            CollectionAssert.AreEqual(expected, actual);
        }

        [DataRow("1,2,3", 1, 3, 2)]
        [DataRow("5,3,1", 7, 2, 1)]
        [DataRow("8,3,2", 2, 3, 5)]
        [DataTestMethod]
        public void ParseLineTest2(string line, double x, double y, double z)
        {
            double[] expected = { x, y, z };
            double[] actual = Vectors.Program.ParseLine(line);
            CollectionAssert.AreNotEqual(expected, actual);
        }
    }
    [TestClass]
    public class VectorClassTests
    {
        [DataRow(1, 2, 3, 1, 2, 3, 0, 0, 0)]
        [DataRow(3, 4, 5, 1, 2, 3, 2, 2, 2)]
        [DataRow(5, 5, 5, 3, 4, 1, 2, 1, 4)]
        [DataTestMethod]
        public void MinusOperatorTest(double x1, double y1, double z1, double x2, double y2, double z2, double x, double y, double z)
        {
            double[] firstArray = { x1, y1, z1 };
            double[] secondArray = { x2, y2, z2 };
            double[] expectedArray = { x, y, z };
            Vectors.Vector first = new(firstArray);
            Vectors.Vector second = new(secondArray);
            Vectors.Vector expected = new(expectedArray);
            Vectors.Vector actual = first - second;
            Assert.IsTrue(expected == actual);
        }
    }
}
