using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace ClassLibrary
{
    public class FileHandler
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void CopyFiles(string targetFile, string destination)
        {
            try
            {
                logger.Info($"copying file {targetFile} to {destination}");
                File.Copy(targetFile, destination);
            }
            catch(Exception)
            {
                logger.Info($"FAILED copying file {targetFile} to {destination}");
            }
        }
    }
}
