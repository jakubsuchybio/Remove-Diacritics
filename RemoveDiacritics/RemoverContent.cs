using System.Collections.Generic;
using System.IO;
using Serilog;

namespace RemoveDiacritics
{
    public static class RemoverContent
    {
        public static void ContentDiacriticsRemover(IEnumerable<string> files)
        {
            foreach (var fileName in files)
            {
                if (!File.Exists(fileName))
                {
                    Log.Warning($"File: {fileName} does not exist...");
                    continue;
                }

                try
                {
                    var strArray = File.ReadAllLines(fileName);
                    using (var streamWriter = new StreamWriter("nodiacritics_" + fileName.Replace("\\", "")))
                    {
                        foreach (var text in strArray)
                            streamWriter.WriteLine(Remover.RemoveDiacritics(text));
                    }

                    Log.Information($"Processed file {fileName}");
                }
                catch (IOException ex)
                {
                    Log.Error(ex, $"File {fileName} had IOException");
                }
            }
        }
    }
}
