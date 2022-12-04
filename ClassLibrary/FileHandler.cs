using System;
using System.IO;


namespace ClassLibrary
{
    public class FileHandler
    {
        //add logger instance
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void CopyFiles(string targetFile, string destination, string _readonly = "1")
        {
            try
            {
                logger.Info($"copying file {targetFile} to {destination}");
                //copy target file to destination, add filename to directory because of file.copy function
                if (_readonly == "1")
                {
                    //TODO: this part is not OS independant. linux = /, win = \
                    File.Copy(targetFile, destination + @"/" + Path.GetFileName(targetFile));
                }

                //create "copied" file per mkv file make sure it doesnt get copied again.
                using (FileStream fs = File.Create(targetFile + @"copied"))
                {
                    logger.Info($"Finished copying file {targetFile} to {destination}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"file: {targetFile} did not copy, error.");
                Console.WriteLine(ex.ToString());
                logger.Info($"FAILED copying file {targetFile} to {destination}");
            }
        }
    }
}
