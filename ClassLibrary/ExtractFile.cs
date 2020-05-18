using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class globalVar
    {
        //public static string searchFolder = @"C:\test\completed";
        public static string searchFolder = @"Z:\SeagateDisk\MediaFolder\completed";

        //public static string destinationFolder = @"C:\test\destination";
        public static string destinationFolder = @"Z:\2TBdisk\temp";
    }

    public class ExtractFile
    {
        public string fileName { get; set; }
        public string filePath { get; set; }
        public string fileDestination { get; set; }
    }

    public class Destination
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        //use regex to detemine if file contains SxxExx, if so, must be a tv show.
        public bool MediaTypeIsTvShow(string fileName)
        {
            try
            {
                Regex rx = new Regex(@".\d\d.\d\d",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var matches = rx.Matches(fileName);
                if (matches.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                logger.Info($"invalid input,{fileName} placed in movie folder.");
                return false;
            } 
        }

        public string SortFile(string fileName)
        {
           string FinalFolder = "";

           return FinalFolder;
        }
        public string CheckFolder(string fileName)
        {
            var checkFolder = "";
            //TODO: check if designated folder exists, if not, create it.

            return checkFolder;
        }
    }
}