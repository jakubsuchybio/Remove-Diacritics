using System.ComponentModel;
using Xunit;

namespace RemoveDiacritics.Tests
{
    public class RemoverTests
    {
        public const string DATA = "ÁČĎÉĚÍŇÓŘŠŤÚŮÝŽáčďéěíňóřšťúůýž";
        public const string EXPECTED = "ACDEEINORSTUUYZacdeeinorstuuyz";

        [Fact]
        [Description("Tests all kind of diacritics, if they will get removed")]
        public void RemoveDiacriticsTest()
        {
            // Arrange

            // Act
            var actual = Remover.RemoveDiacritics(DATA);

            // Assert
            Assert.Equal(EXPECTED, actual);
        }
    }
}
