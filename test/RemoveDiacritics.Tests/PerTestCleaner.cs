using System;
using System.Collections.Generic;
using System.IO;

namespace RemoveDiacritics.Tests
{
    public class PerTestCleaner : IDisposable
    {
        private readonly List<Action> _cleanupActions;

        protected PerTestCleaner()
        {
            _cleanupActions = new List<Action>();
        }

        public void Dispose()
        {
            foreach (var action in _cleanupActions)
                action();
        }

        protected void AddCleanupAction(Action action) =>
            _cleanupActions.Add(action);

        protected static void RemoverDirectory(string dir)
        {
            if (Directory.Exists(dir))
                Directory.Delete(dir, true);
        }

        protected static void RemoverFile(string file)
        {
            if (File.Exists(file))
                File.Delete(file);
        }
    }
}
