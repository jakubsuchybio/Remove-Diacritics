using System;
using System.IO;
using Xunit;

namespace RemoveDiacritics.Tests
{
    public class RemoverContentTests : PerTestCleaner
    {
        [Fact]
        public void NonExistentFile()
        {
            // Arrange
            var content = RemoverTests.DATA; 
            var expected = RemoverTests.EXPECTED;
            var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var fileName = Guid.NewGuid().ToString();
            var tempFile = Path.Combine(tempDir, fileName);
            var actualFilePath = Path.Combine(tempDir, "nodiacritics_" + fileName);
            Directory.CreateDirectory(tempDir);
            File.WriteAllText(tempFile, content);
            AddCleanupAction(() => RemoverFile(tempFile));
            AddCleanupAction(() => RemoverFile(actualFilePath));
            AddCleanupAction(() => RemoverDirectory(tempDir));

            // Act
            RemoverContent.ContentDiacriticsRemover(tempFile, Guid.NewGuid().ToString());
            var actual = File.ReadAllText(actualFilePath).TrimEnd();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
