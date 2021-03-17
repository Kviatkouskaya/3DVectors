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
        [DataRow()]
        [DataTestMethod]
        public void MinusOperatorTest()
        {

        }
    }
}
