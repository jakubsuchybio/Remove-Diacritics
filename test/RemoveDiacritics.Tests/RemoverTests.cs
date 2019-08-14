using System.ComponentModel;
using Xunit;

namespace RemoveDiacritics.Tests
{
    public class RemoverTests
    {
        [Fact]
        [Description("Tests all kind of diacritics, if they will get removed")]
        public void RemoveDiacriticsTest()
        {
            // Arrange
            const string data = "ÁČĎÉĚÍŇÓŘŠŤÚŮÝŽáčďéěíňóřšťúůýž";
            const string expected = "ACDEEINORSTUUYZacdeeinorstuuyz";

            // Act
            var actual = Remover.RemoveDiacritics(data);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
