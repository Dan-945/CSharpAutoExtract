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

namespace ClassLibrary
{
    class Unrar
    {
        //TODO: make reusable function for unraring. below code works when used in Program - main
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public void rarFunction( )
        {
            // extract files
            foreach (var item in files)
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
                        Console.WriteLine($"file: {item.fileName} unrared.");
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