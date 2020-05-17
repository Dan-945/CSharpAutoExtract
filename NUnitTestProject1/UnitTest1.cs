using NUnit.Framework;
using ClassLibrary;
using System;

namespace NUnitTestProject1
{
    [TestFixture]
    public class ExtractFileTests
    {
        [Test]
        public void SearchFolder_searchesFolders_ReturnsRARfiles()
        {
            //TODO: check if search function.... dette blir en integration test..?
        }
        //test of git
        [Test]
        public void FinalFolder_tvShow_FileNameEqualsToPathName()
        {
            var folderName = destination.finalFolder(
                "ncis.los.angeles.s11e22.1080p.hdtv.x264-twerk.rar");
            Assert.Contains(folderName, "\\");

        }
    }
}