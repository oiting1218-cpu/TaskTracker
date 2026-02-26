using TaskTracker.Api.Helpers;

namespace TaskTracker.Tests
{
    public class PasswordHelperTests
    {
        [Theory]
        [InlineData("abcdef")]
        [InlineData("a1b2c3d4")]
        [InlineData("123456")]
        public void IsPasswordStrong_ShouldReturnTrue_WhenPasswordLengthIsAtLeast6(string password)
        {
            //Arrange
            var helper = new PasswordHelper();

            //Act
            var result = helper.IsPasswordStrong(password);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("")]
        [InlineData("123")]
        public void IsPasswordStrong_ShoudlReturnFalse_WhenPasswordLengthIsShort(string password)
        {
            //Arrange
            var helper = new PasswordHelper();

            //Act
            var result = helper.IsPasswordStrong(password);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("a2b")]
        [InlineData("1")]
        [InlineData("123")]
        public void IsPasswordContainsAtLeastOneDigit_ShouldReturnTrue_WhenContainsDigit(string password)
        {
            //Arrange
            var helper = new PasswordHelper();

            //Act
            var result = helper.IsPasswordContainsAtLeastOneDigit(password);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("")]
        public void IsPasswordContainsAtLeastOneDigit_ShouldReturnFalse_WhenNoDigit(string password)
        {
            //Arrange
            var helper = new PasswordHelper();

            //Act
            var result = helper.IsPasswordContainsAtLeastOneDigit(password);

            //Assert
            Assert.False(result);
        }
    }
}
