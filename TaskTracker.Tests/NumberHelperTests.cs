using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Api.Helpers;

namespace TaskTracker.Tests
{
    public class NumberHelperTests
    {
        [Fact]
        public void Divide_ShouldThrowException_WhenDividerIsZero()
        {
            //Arrange
            var helper = new NumberHelper();

            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                helper.Divide(10, 0);
            });
        }

        [Fact]
        public void Divide_ShouldReturnCorrectResult_WhenDividerIsNotZero()
        {
            //Arrange
            var helper = new NumberHelper();

            //Act
            var result = helper.Divide(10, 2);

            //Assert
            Assert.Equal(5, result);
        }
    }
}
