using System.Collections.Generic;
using System.IO;
using System.Linq;
using Serilog;

namespace RemoveDiacritics
{
    public static class RemoverFileNames
    {
        public static void FileNamesDiacriticsRemover(IEnumerable<string> dirs)
        {
            foreach (var directory in dirs)
            {
                var directories = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories);
                foreach (var dir in directories.OrderByDescending(s => s.Length))
                {
                    var normalizedDir = Remover.RemoveDiacritics(dir);
                    if (dir == normalizedDir)
                        continue;

                    Directory.Move(dir, normalizedDir);
                    Log.Information($"Renaming {dir} -> {normalizedDir}");
                }

                directories = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories);
                foreach (var dir in directories)
                    FileNamesDiacriticsRemover(dir);

                FileNamesDiacriticsRemover(directory);
            }
        }

        private static void FileNamesDiacriticsRemover(string dir)
        {
            var files = Directory.GetFiles(dir);
            foreach (var file in files)
            {
                var normalizedFile = Remover.RemoveDiacritics(file);
                if (file == normalizedFile)
                    continue;

                Directory.Move(file, normalizedFile);
                Log.Information($"Renaming {file} -> {normalizedFile}");
            }
        }
    }
}
