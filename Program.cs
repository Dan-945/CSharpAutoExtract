using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ClassLibrary;
using SharpCompress;
using SharpCompress.Common;
using SharpCompress.Readers;
using SharpCompress.Readers.Rar;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives;

namespace autoExtract
{
    class Program
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
             List<ExtractFile> files = new List<ExtractFile>();

            //searching through folders to determine what files need extracting
            string[] subDirectories = Directory.GetDirectories(globalVar.searchFolder);

            // extract this loop to a separate method ? should make for easier reading?
            foreach (var subDir in subDirectories)
                {
                string[] fileEntries = Directory.GetFiles(subDir);
                foreach (string rarFile in fileEntries)
                {
                    if (rarFile.EndsWith(".rar"))
                    {
                        if (File.Exists(subDir + @"\unrared"))
                        {
                            Console.WriteLine("already unrared");
                        }
                        else
                        {
                            // creating new instance of the class extract file for the newly found .rar
                            ExtractFile newFile = new ExtractFile();
                            //adding the new instance of class to the list of classes for easier handling later.
                            files.Add(newFile);
                            // adding the rarfile name to the instance of a class.
                            newFile.fileName = rarFile;
                            newFile.filePath = subDir;
                        }

                    }
                }
                }
            
            // loop through created items to assign destination before extracting / moving.
            foreach (var item in files)
            {
                //TODO: add regex in this function to properly sort all media.
                //item.fileDestination = destination.finalFolder(item.fileName);
                item.fileDestination = globalVar.destinationFolder;
            }

            Unrar.rarFunction(files);


            //// extract files
            //foreach (var item in files)
            //{
            //    try
            //    {
            //        using (var archive = RarArchive.Open(item.fileName))
            //        {
            //            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            //            {
            //                entry.WriteToDirectory(item.fileDestination, new ExtractionOptions()
            //                {
            //                    ExtractFullPath = true,
            //                    Overwrite = true
            //                });
            //            }
            //        }
            //        using (FileStream fs = File.Create(item.filePath + @"\unrared"))
            //        {
            //            Console.WriteLine($"file: {item.fileName} unrared.");
            //            logger.Info($"file: {item.fileName} unrared.");
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("fuckup");
            //        logger.Info($"file: {item.fileName} did not unrar, error.");
            //    }
            //}


            // temp print function
            Console.WriteLine(files.Count);
            foreach (var item in files)
            {
                Console.WriteLine($"fileName: { item.fileName}");
                Console.WriteLine($"filePath: { item.filePath}");
                Console.WriteLine($"fileDestination: {item.fileDestination}");
                //logger.Info(item.fileDestination);
            }


            //TODO: execute unraring

            //TODO: mount new hdd in server, use for finale storage and new PLEX media folder.
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
