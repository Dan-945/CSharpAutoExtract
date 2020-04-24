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
                File.Copy(targetFile, destination + @"\" + System.IO.Path.GetFileName(targetFile));
                using (FileStream fs = File.Create(System.IO.Path.GetDirectoryName(targetFile) + @"\copied"))
                {
                    logger.Info($"Finished copying file {targetFile} to {destination}");
                } 
            }
            catch (Exception)
            {
                logger.Info($"FAILED copying file {targetFile} to {destination}");
            }
        }
    }
}
