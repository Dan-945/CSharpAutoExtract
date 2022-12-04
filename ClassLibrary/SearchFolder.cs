using System.Collections.Generic;
using System.IO;

namespace ClassLibrary
{
    public class SearchFolder
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void searchFolder(string directory, List<ExtractFile> rarList, List<ExtractFile> mkvList)
        {
            var allMkv = Directory.GetFiles(directory, "*mkv");
            foreach (var mkv in allMkv)
            {
                if (File.Exists(mkv + @"copied"))
                {
                    logger.Info($"file {mkv} already copied.");
                }
                else
                {
                    ExtractFile newFile = new ExtractFile();
                    mkvList.Add(newFile);
                    newFile.fileName = mkv;
                    newFile.filePath = Path.GetDirectoryName(mkv);
                }

                var allRar = Directory.GetFiles(directory, "*rar");
                foreach (var rar in allRar)
                {
                    if (File.Exists(rar + @"\unrared"))
                    {
                        logger.Info($"file {rar} already copied.");
                    }
                    else
                    {
                        ExtractFile newFile = new ExtractFile();
                        rarList.Add(newFile);
                        newFile.fileName = rar;
                        newFile.filePath = Path.GetDirectoryName(rar);
                    }
                }

            }
        }

    }
}
