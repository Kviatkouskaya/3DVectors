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
            Vectors.Vector expected = new(x, y, z);
            Vectors.Vector actual = Vectors.Program.ParseLine(line);
            CollectionAssert.AreEqual(expected.vectorArray, actual.vectorArray);
        }

        [DataRow("1,2,3", 1, 3, 2)]
        [DataRow("5,3,1", 7, 2, 1)]
        [DataRow("8,3,2", 2, 3, 5)]
        [DataTestMethod]
        public void ParseLineTest2(string line, double x, double y, double z)
        {
            Vectors.Vector expected = new(x, y, z);
            Vectors.Vector actual = Vectors.Program.ParseLine(line);
            CollectionAssert.AreNotEqual(expected.vectorArray, actual.vectorArray);
        }
    }

    [TestClass]
    public class VectorClassTests
    {
        [DataRow(2, 2, 3, 2, 2, 3)]
        [DataRow(5, 6, 4, 5, 6, 4)]
        [DataRow(6, 5, 4, 6, 5, 4)]
        [DataTestMethod]
        public void CompareTest(double x1, double y1, double z1, double x, double y, double z)
        {
            Vectors.Vector first = new(x1, y1, z1);
            Vectors.Vector second = new(x, y, z);
            Assert.IsTrue(first == second);
        }

        [DataRow(2, 2, 3, 7, 2, 3)]
        [DataRow(5, 6, 4, 7, 6, 4)]
        [DataRow(2, 3, 4, 5, 6, 7)]
        [DataTestMethod]
        public void CompareTest2(double x1, double y1, double z1, double x, double y, double z)
        {
            Vectors.Vector first = new(x1, y1, z1);
            Vectors.Vector second = new(x, y, z);
            Assert.IsFalse(first == second);
        }

        [DataRow(2, 2, 3, 7, 2, 3)]
        [DataRow(5, 6, 4, 7, 6, 4)]
        [DataRow(2, 3, 4, 5, 6, 7)]
        [DataTestMethod]
        public void NotCompareTest(double x1, double y1, double z1, double x, double y, double z)
        {
            Vectors.Vector first = new(x1, y1, z1);
            Vectors.Vector second = new(x, y, z);
            Assert.IsTrue(first != second);
        }

        [DataRow(2, 2, 3, 2, 2, 3)]
        [DataRow(5, 6, 4, 5, 6, 4)]
        [DataRow(6, 5, 4, 6, 5, 4)]
        [DataTestMethod]
        public void NotCompareTest2(double x1, double y1, double z1, double x, double y, double z)
        {
            Vectors.Vector first = new(x1, y1, z1);
            Vectors.Vector second = new(x, y, z);
            Assert.IsFalse(first != second);
        }

        [DataRow(1, 2, 3, 1, 2, 3, 0, 0, 0)]
        [DataRow(3, 4, 5, 1, 2, 3, 2, 2, 2)]
        [DataRow(5, 5, 5, 3, 4, 1, 2, 1, 4)]
        [DataTestMethod]
        public void MinusOperatorTest(double x1, double y1, double z1, double x2, double y2, double z2, double x, double y, double z)
        {
            Vectors.Vector first = new(x1, y1, z1);
            Vectors.Vector second = new(x2, y2, z2);
            Vectors.Vector expected = new(x, y, z);
            Vectors.Vector actual = first - second;
            Assert.IsTrue(actual.vectorArray[0] == expected.vectorArray[0] &&
                          actual.vectorArray[1] == expected.vectorArray[1] &&
                          actual.vectorArray[2] == expected.vectorArray[2]);
        }

        [DataRow(1, 2, 3, 1, 2, 3, 2, 4, 6)]
        [DataRow(5, 5, 5, 3, 4, 1, 8, 9, 6)]
        [DataRow(1, 1, 1, 2, 2, 2, 3, 3, 3)]
        [DataTestMethod]
        public void PlusOperatorTest(double x1, double y1, double z1, double x2, double y2, double z2, double x, double y, double z)
        {
            Vectors.Vector first = new(x1, y1, z1);
            Vectors.Vector second = new(x2, y2, z2);
            Vectors.Vector expected = new(x, y, z);
            Vectors.Vector actual = first + second;
            Assert.IsTrue(actual.vectorArray[0] == expected.vectorArray[0] &&
                          actual.vectorArray[1] == expected.vectorArray[1] &&
                          actual.vectorArray[2] == expected.vectorArray[2]);
        }

        [DataRow(10, 1, 2, 3, 10, 20, 30)]
        [DataRow(5, 5, 5, 5, 25, 25, 25)]
        [DataRow(1, 1, 1, 1, 1, 1, 1)]
        [DataTestMethod]
        public void VectorAndNumberMultiplication(double number, double x1, double y1, double z1, double x, double y, double z)
        {
            Vectors.Vector first = new(x1, y1, z1);
            Vectors.Vector expected = new(x, y, z);
            Vectors.Vector actual = first * number;
            Assert.IsTrue(actual.vectorArray[0] == expected.vectorArray[0] &&
                          actual.vectorArray[1] == expected.vectorArray[1] &&
                          actual.vectorArray[2] == expected.vectorArray[2]);
        }

        [DataRow(1, 2, 3, 10, 20, 30, 140)]
        [DataRow(5, 5, 5, 2, 2, 2, 30)]
        [DataRow(1, 1, 1, 1, 1, 1, 3)]
        [DataTestMethod]
        public void VectorsMultiplication(double x1, double y1, double z1, double x2, double y2, double z2, double expected)
        {
            Vectors.Vector first = new(x1, y1, z1);
            Vectors.Vector second = new(x2, y2, z2);
            double actual = first * second;
            Assert.IsTrue(expected == actual);
        }
    }

    [TestClass]
    public class VectorAdditionalTests
    {
        [DataRow(1, 2, 3)]
        [DataRow(5, 5, 5)]
        [DataRow(1, 1, 1)]
        [DataTestMethod]
        public void VectorEquals(double x, double y, double z)
        {
            Vectors.Vector first = new(x, y, z);
            Vectors.Vector second = first;
            Assert.IsTrue(first.Equals(second));
        }

        [DataRow(1, 2, 3, 2, 3, 5)]
        [DataRow(5, 5, 5, 5, 5, 5)]
        [DataRow(1, 1, 1, 1, 1, 1)]
        [DataTestMethod]
        public void VectorEquals2(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            Vectors.Vector first = new(x1, y1, z1);
            Vectors.Vector second = new(x2, y2, z2);
            Assert.IsFalse(first.Equals(second));
        }

        [DataRow(1, 2, 3, 6)]
        [DataRow(5, 5, 5, 125)]
        [DataRow(1, 1, 1, 1)]
        [DataTestMethod]
        public void VectorGetHashCode(double x, double y, double z, int expected)
        {
            Vectors.Vector first = new(x, y, z);
            int actual = first.GetHashCode();
            Assert.IsTrue(actual == expected);
        }
    }
}
