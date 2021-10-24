using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class globalVar
    {
        //public static string searchFolder = @"C:\test\completed";
        //public static string searchFolder = @"U:\Media\TransmissionData\completed";
        public static string searchFolder = ConfigurationManager.AppSettings.Get("searchFolder");

        //public static string destinationFolder = @"C:\test\destination";
        //public static string destinationFolder = @"U:\Media\TransmissionData\temp";
        public static string destinationFolder = ConfigurationManager.AppSettings.Get("destinationFolder");
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

        public string FindShowName(string fileName)
        {
           string ShowName = "";
           // if (MediaTypeIsTvShow(fileName)==true)
           if(true)
           {
               var result = Regex.Match(fileName, @"[^\d\d.\d\d]*");

               //var result2 = Regex.Match(result.ToString(), @"[^C:\\w*]\w*\\\w*");
                var result2 = Regex.Match(result.ToString(), @"(?<=C:\\).*");
                var result3 = Regex.Match(result2.ToString(), @"(?<=\\).*");

                //TODO: lag ny result her for å få tekst etter sist \ skal da være kun "NCIS" igjen.
                //TODO: lag egen funksjon for å hente ut sessong av filnavn. 
                //TODO: til slutt egen funksjon for å sette sammen disse delene til endelig folder.
                ShowName = result3.ToString();
               return ShowName;
           }
           return ShowName;
        }
        public string CheckFolder(string fileName)
        {
            var checkFolder = "";
            //TODO: check if designated folder exists, if not, create it.

            return checkFolder;
        }
    }
}