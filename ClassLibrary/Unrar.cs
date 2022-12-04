using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ClassLibrary
{
    public class Unrar
    {
        //TODO: make reusable function for unraring. below code works when used in Program - main
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void rarFunction(List<ExtractFile> inputList, string _readonly = "1")
        {
            // extract files
            foreach (var item in inputList)
            {
                try
                {
                    if (_readonly == "1")
                    {
                        using (var archive = RarArchive.Open(item.fileName))
                        {
                            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                            {
                                entry.WriteToDirectory(item.fileDestination, new ExtractionOptions()
                                {
                                    ExtractFullPath = true,
                                    Overwrite = true
                                });
                            }
                        }
                    }

                    using (FileStream fs = File.Create(item.filePath + @"\unrared"))
                    {
                        logger.Info($"file: {item.fileName} unrared.");
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("fuckup");
                    Console.WriteLine($"file: {item.fileName} did not unrar, error.");
                    Console.WriteLine(ex.ToString());
                    logger.Info($"file: {item.fileName} did not unrar, error.");
                }
            }

        }
    }
}