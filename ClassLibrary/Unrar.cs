using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using SharpCompress.Common;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives;

namespace ClassLibrary
{
    public class Unrar
    {
        //TODO: make reusable function for unraring. below code works when used in Program - main
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void rarFunction(List<ExtractFile>inputList)
        {
            // extract files
            foreach (var item in inputList)
            {
                try
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
                    using (FileStream fs = File.Create(item.filePath + @"\unrared"))
                    {
                        logger.Info($"file: {item.fileName} unrared.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("fuckup");
                    logger.Info($"file: {item.fileName} did not unrar, error.");
                }
            }

        }
    }
}