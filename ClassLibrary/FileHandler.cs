using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace ClassLibrary
{
    public class FileHandler
    {
        //add logger instance
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void CopyFiles(string targetFile, string destination, string _readonly="1")
        {
            try
            {
                logger.Info($"copying file {targetFile} to {destination}");
                //copy target file to destination, add filename to directory because of file.copy function
                if (_readonly == "1")
                {
                    File.Copy(targetFile, destination + @"\" + Path.GetFileName(targetFile));
                }
                
                //create "copied" file per mkv file make sure it doesnt get copied again.
                using (FileStream fs = File.Create(targetFile + @"copied"))
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
