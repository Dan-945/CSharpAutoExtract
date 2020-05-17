using ClassLibrary;
using NUnit.Framework;

namespace autoExtracter.UnitTests
{    
    [TestFixture]
    public class Tests
    {
        private destination _destination;
        
        [SetUp]
        public void Setup()
        {
            _destination = new destination();
        }
        
        [Test]
        public void FinalFolder_FileFound_ReturnFormattedDestination()
        {
            var result = _destination.finalFolder(@"\test");
            Assert.That(result, Does.Contain("movie"));
        }
    }
}