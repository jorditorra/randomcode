using Microsoft.VisualStudio.TestTools.UnitTesting;
using randomapp.Examples;
using System.Threading.Tasks;

namespace randomapp.tests.Examples
{
    [TestClass]
    public class DeterministicTests
    {
        protected static IDeterministic _sut;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _sut = new Deterministic();
        }

        [TestMethod]
        [DataRow(1, 2, 3 )]
        [DataRow(2, 2, 4)]
        [DataRow(0, 0, 0)]
        [DataRow(-1, 1, 0)]        
        public void TestAdd( int a, int b, int expected )
        {
            Assert.AreEqual<int>(expected, _sut.Add(a, b));
        }

        [TestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(2, 2, 4)]
        [DataRow(0, 0, 0)]
        [DataRow(-1, 1, 0)]
        public async Task TestAsyncHeavyOperation(int a, int b, int expected)
        {
            Assert.AreEqual<int>(expected, (await _sut.AsyncHeavyOperation(a, b)));
        }
    }
}
