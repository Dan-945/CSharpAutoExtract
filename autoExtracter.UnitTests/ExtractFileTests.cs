using ClassLibrary;
using NUnit.Framework;

namespace autoExtracter.UnitTests
{    
    [TestFixture]
    public class Tests
    {
        private Destination _destination;
        
        [SetUp]
        public void Setup()
        {
            _destination = new Destination();
        }
        
        [Test]
        public void FinalFolder_FileFound_ReturnFormattedDestination()
        {
            var result = _destination.FinalFolder(@"C:\test\NCIS.S10E04.mkv");
            Assert.That(result, Does.Contain("NCIS"));
        }
    }
}