using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassLibrary
{
    public class SearchFolder
    {
        public static void searchFolder(string[] subDirectories, List<ExtractFile> inputList)
        {
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
                            inputList.Add(newFile);
                            // adding the rarfile name to the instance of a class.
                            newFile.fileName = rarFile;
                            newFile.filePath = subDir;
                        }

                    }
                }
            }
        }
    }
}
