using System;
using System.Collections.Generic;
using System.IO;

namespace ClassLibrary
{
    public class SearchFolder
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void searchFolder(string[] subDirectories, List<ExtractFile> rarList, List<ExtractFile> mkvList)
        {
            foreach (var subDir in subDirectories)
            {
                string[] fileEntries = Directory.GetFiles(subDir);
                foreach (string searchFile in fileEntries)
                {
                    if (searchFile.EndsWith(".rar"))
                    {
                        if (File.Exists(subDir + @"\unrared"))
                        {
                            logger.Info($"file {subDir} already unrared.");
                        }
                        else
                        {
                            // creating new instance of the class extract file for the newly found .rar
                            ExtractFile newFile = new ExtractFile();
                            //adding the new instance of class to the list of classes for easier handling later.
                            rarList.Add(newFile);
                            // adding the rarfile name to the instance of a class.
                            newFile.fileName = searchFile;
                            newFile.filePath = subDir;
                        }

                    }
                    if (searchFile.EndsWith(".mkv"))
                    {
                        if (File.Exists(searchFile + @"copied"))
                        {
                            logger.Info($"file {subDir} already copied.");
                        }
                        else
                        {
                            ExtractFile newFile = new ExtractFile();
                            mkvList.Add(newFile);
                            newFile.fileName = searchFile;
                            newFile.filePath = subDir;
                        }
                    }
                }   
            }
        }
    }
}
