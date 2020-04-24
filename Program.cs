using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ClassLibrary;


namespace autoExtract
{
    class Program
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            //declare vars
            List<ExtractFile> files = new List<ExtractFile>();
            string[] subDirectories = Directory.GetDirectories(globalVar.searchFolder);

            //searching through folders to determine what files need extracting
            SearchFolder.searchFolder(subDirectories, files);
            
            // loop through created items to assign destination before extracting / moving.
            foreach (var item in files)
            {
                //TODO: add regex in this function to properly sort all media.
                //item.fileDestination = destination.finalFolder(item.fileName);
                item.fileDestination = globalVar.destinationFolder;
            }

            //extract files
            //Unrar.rarFunction(files);

            // temp print function
            Console.WriteLine($"rar files found: { files.Count}");
            foreach (var item in files)
            {
                logger.Info($"fileName: { item.fileName}");
                logger.Info($"filePath: { item.filePath}");
                logger.Info($"fileDestination: {item.fileDestination}");

                Console.WriteLine($"fileName: { item.fileName}");
                Console.WriteLine($"filePath: { item.filePath}");
                Console.WriteLine($"fileDestination: {item.fileDestination}");
                //logger.Info(item.fileDestination);
            }

            //TODO: publish as executable

            //v2:
            //TODO: add extracted / moved tvShows or movies to separate list "ready for delete"
            //so that torrent download folder can be deleteted
            //TODO: add config file for filepaths.
            //TODO: create config file function, low pri
            //TODO: determine download type and add correct filedestination, tvshow + name / movie. 
        }
    }
}
