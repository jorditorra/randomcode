using Microsoft.VisualStudio.TestTools.UnitTesting;
using randomapp.Examples;
using System.Threading.Tasks;
using NSubstitute;

namespace randomapp.tests.Examples
{
    [TestClass]
    public class NonDeterministicTests
    {        
        [TestMethod]
        public async Task TestCalculationWithDependencies()
        {            
            var mockDep = Substitute.For<IDependency>();
            mockDep.AsyncExternalCall(Arg.Any<int>()).Returns(Task.FromResult(4));            
            var sut = new NonDeterministic(mockDep);

            var result = await sut.CalculationWithDependencies(2, 8);

            await mockDep.Received().AsyncExternalCall(2);
            Assert.AreEqual<int>(12, result);            
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), "no network")]
        public async Task TestCalculationWithDependenciesThrowsError()
        {
            var mockDep = Substitute.For<IDependency>();
            mockDep.When( x => x.AsyncExternalCall(Arg.Any<int>()) ).Do( y => { throw new System.Exception("no network"); });            
            var sut = new NonDeterministic(mockDep);

            var result = await sut.CalculationWithDependencies(2, 8);
        }
    }
}
