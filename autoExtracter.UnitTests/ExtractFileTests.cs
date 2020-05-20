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
        public void MediaType_TvShow_ReturnTrue()
        {
            var result = _destination.MediaTypeIsTvShow(@"C:\test\NCIS.S10E04.mkv");
            Assert.That(result, Is.True);
        }
        [Test]
        public void MediaType_Movie_ReturnFalse()
        {
            var result = _destination.MediaTypeIsTvShow(@"C:\test\Avengers");
            Assert.That(result, Is.False);
        }
        

        [Test]
        public void SortFile_WhenCalled_SortsFile()
        {
            var result = _destination.SortFile(@"C:\test\NCIS.S10E04.mkv");
            Assert.That(result, Is.EqualTo(@"\NCIS\S10\"));
        }

        [Test]
        [Ignore("Should be integration test")]
        public void CheckFolder_FolderExists_ReturnsTrue()
        {
            var result = _destination.CheckFolder(globalVar.destinationFolder);
            Assert.That(result, Is.True);
        }

        [Test]
        [Ignore("Should be integration test")]
        public void CheckFolder_FolderDoesNotExists_ReturnsFalse()
        {
            var result = _destination.CheckFolder(@"C:\ThisFolderDoesNotExist");
            Assert.That(result, Is.False);
        }

    }
}