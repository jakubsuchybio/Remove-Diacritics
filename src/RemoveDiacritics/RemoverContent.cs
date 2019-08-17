using System.IO;
using Serilog;

namespace RemoveDiacritics
{
    public static class RemoverContent
    {
        public static void ContentDiacriticsRemover(params string[] files)
        {
            foreach (var filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Log.Warning($"File: {filePath} does not exist...");
                    continue;
                }

                try
                {
                    var dirPath = Path.GetDirectoryName(filePath);
                    if(dirPath == null)
                        continue;

                    var fileName = Path.GetFileName(filePath);

                    var strArray = File.ReadAllLines(filePath);
                    using (var streamWriter = new StreamWriter(Path.Combine(dirPath, "nodiacritics_" + fileName)))
                    {
                        foreach (var text in strArray)
                            streamWriter.WriteLine(Remover.RemoveDiacritics(text));
                    }

                    Log.Information($"Processed file {filePath}");
                }
                catch (IOException ex)
                {
                    Log.Error(ex, $"File {filePath} had IOException");
                }
            }
        }
    }
}
