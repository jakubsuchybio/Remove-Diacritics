using System.Collections.Generic;
using CommandLine;

namespace RemoveDiacritics
{
    public interface ICommonOptions
    {
        [Option("debug", HelpText = "Forces program to run in debug mode")]
        bool Debug { get; }
    }

    [Verb("stdin", HelpText = "Removes diacritics from stdin and outputs it to stdout")]
    public class StdInOptions : ICommonOptions
    {
        public StdInOptions(bool debug = false) =>
            Debug = debug;

        public bool Debug { get; }
    }

    [Verb("file-names", HelpText = "Removes diacritics from all files and directories")]
    public class FileNamesOptions : ICommonOptions
    {
        public FileNamesOptions(IEnumerable<string> dirs, bool debug = false)
        {
            Dirs = dirs;
            Debug = debug;
        }

        public bool Debug { get; }

        [Option('d', "directories", Required = true, HelpText = "Input directories where will diacritics be recursively removed in file/dir names")]
        public IEnumerable<string> Dirs { get; }
    }

    [Verb("content", HelpText = "Removes diacritics inside files")]
    public class ContentOptions : ICommonOptions
    {
        public ContentOptions(IEnumerable<string> files, bool debug = false)
        {
            Files = files;
            Debug = debug;
        }

        public bool Debug { get; }

        [Option('f', "files", Required = true, HelpText = "Input files where the diacritics be removed inside the file's content")]
        public IEnumerable<string> Files { get; }
    }
}
