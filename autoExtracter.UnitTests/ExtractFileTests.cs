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
        [TestCase(@"C:\test\NCIS.S10E04.mkv", "NCIS")]
        [TestCase(@"Z:\2TBdisk\tvShows\NCIS\NCIS.S14E19.1080p.HEVC.x265 - MeGusta", "NCIS")]
        public void FindShowName_WhenCalled_ReturnsShowName(string input, string expectedResult)
        {
            var result = _destination.FindShowName(input);
            Assert.That(result, Is.EqualTo(expectedResult));
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