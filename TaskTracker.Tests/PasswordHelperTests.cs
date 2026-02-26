using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Api.Helpers;

namespace TaskTracker.Tests
{
    public class PasswordHelperTests
    {
        [Fact]
        public void IsPasswordStrong_ShouldReturnTrue_WhenPasswordLengthIsAtLeast6()
        {
            //Arrange
            var helper = new PasswordHelper();
            string password = "abcdef";

            //Act
            var result = helper.IsPasswordStrong(password);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPasswordStrong_ShoudlReturnFalse_WhenPasswordLengthIsShort()
        {
            //Arrange
            var helper = new PasswordHelper();
            var password = "abc";

            //Act
            var result = helper.IsPasswordStrong(password);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPasswordContainsAtLeastOneDigit_ShouldReturnTrue_WhenContainsDigit()
        {
            //Arrange
            var helper = new PasswordHelper();
            var password = "a2b";

            //Act
            var result = helper.IsPasswordContainsAtLeastOneDigit(password);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPasswordContainsAtLeastOneDigit_ShouldReturnFalse_WhenNoDigit()
        {
            //Arrange
            var helper = new PasswordHelper();
            var password = "abc";

            //Act
            var result = helper.IsPasswordContainsAtLeastOneDigit(password);

            //Assert
            Assert.False(result);
        }
    }
}
