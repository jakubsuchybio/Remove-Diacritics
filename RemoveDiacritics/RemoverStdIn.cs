using System;

namespace RemoveDiacritics
{
    public static class RemoverStdIn
    {
        public static void StdInDiacriticsRemover()
        {
            var line = Console.ReadLine();
            while (line != null)
            {
                Console.WriteLine(Remover.RemoveDiacritics(line));
                line = Console.ReadLine();
            }
        }
    }
}
