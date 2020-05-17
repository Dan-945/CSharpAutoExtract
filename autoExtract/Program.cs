using System;
using ClassLibrary;
using System.Collections.Generic;
using System.IO;

namespace autoExtract
{
    internal class Program
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            //declare vars
            List<ExtractFile> rarFiles = new List<ExtractFile>();
            List<ExtractFile> mkvFiles = new List<ExtractFile>();
            string[] subDirectories = Directory.GetDirectories(globalVar.searchFolder);

            //searching through folders to determine what files need extracting
            SearchFolder.searchFolder(subDirectories, rarFiles, mkvFiles);
            // loop through created items to assign destination before extracting / moving.
            foreach (var item in rarFiles)
            {
                //TODO: add regex in this function to properly sort all media.
                //item.fileDestination = destination.finalFolder(item.fileName);
                item.fileDestination = globalVar.destinationFolder;
            }
            foreach (var item in mkvFiles)
            {
                //TODO: add regex in this function to properly sort all media.
                //item.fileDestination = destination.finalFolder(item.fileName);
                item.fileDestination = globalVar.destinationFolder;
            }

            //extract files
            //Unrar.rarFunction(rarFiles);

            //copying mkv files
            // foreach (var item in mkvFiles)
            // {
            //     FileHandler.CopyFiles(item.fileName, item.fileDestination);
            // }

            // temp print function
            logger.Info($"rar files found: { rarFiles.Count}");
            logger.Info($"mkv files found: { mkvFiles.Count}");
            foreach (var item in rarFiles)
            {
                logger.Info($"fileName: { item.fileName}");
                logger.Info($"filePath: { item.filePath}");
                logger.Info($"fileDestination: {item.fileDestination}");
            }
            foreach (var item in mkvFiles)
            {
                logger.Info($"fileName: { item.fileName}");
                logger.Info($"filePath: { item.filePath}");
                logger.Info($"fileDestination: {item.fileDestination}");
            }

            //TODO: publish as executable
            //unstaged comment
            //v2:
            //TODO: add extracted / moved tvShows or movies to separate list "ready for delete"
            //so that torrent download folder can be deleteted
            //TODO: add config file for filepaths.
            //TODO: create config file function, low pri
            //TODO: determine download type and add correct filedestination, tvshow + name / movie.
        }
    }
}