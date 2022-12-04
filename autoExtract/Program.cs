using ClassLibrary;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace autoExtract
{
    //TODO: Upgrade solution to .net 6
    internal class Program
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            string _readOnly = ConfigurationManager.AppSettings.Get("_readOnly");
            //declare vars
            List<ExtractFile> rarFiles = new List<ExtractFile>();
            List<ExtractFile> mkvFiles = new List<ExtractFile>();

            //searching through folders to determine what files need extracting
            SearchFolder.searchFolder(globalVar.searchFolder, rarFiles, mkvFiles);
            // loop through created items to assign destination before extracting / moving.
            foreach (var item in rarFiles)
            {
                item.fileDestination = globalVar.destinationFolder;
            }
            foreach (var item in mkvFiles)
            {
                item.fileDestination = globalVar.destinationFolder;
            }

            //extract files
            Unrar.rarFunction(rarFiles, _readOnly);

            //copying mkv files
            foreach (var item in mkvFiles)
            {
                System.Console.WriteLine($"Copying file: {item.fileName}");
                FileHandler.CopyFiles(item.fileName, item.fileDestination, _readOnly);
            }

            logger.Info($"rar files found: {rarFiles.Count}");
            logger.Info($"mkv files found: {mkvFiles.Count}");
            foreach (var item in rarFiles)
            {
                logger.Info($"fileName: {item.fileName}");
                logger.Info($"filePath: {item.filePath}");
                logger.Info($"fileDestination: {item.fileDestination}");
            }
            foreach (var item in mkvFiles)
            {
                logger.Info($"fileName: {item.fileName}");
                logger.Info($"filePath: {item.filePath}");
                logger.Info($"fileDestination: {item.fileDestination}");
            }
        }
    }
}