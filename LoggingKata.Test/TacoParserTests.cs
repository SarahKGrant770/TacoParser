using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            TacoParser sut = new TacoParser();

            //Act
            var actual = sut.Parse("34, 88, Taco Bell Atmore");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34,88,Taco Bell", 34, 88, "Taco Bell")]


        public void ShouldParse(string str, double latitude, double longitude, string name)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange

            TacoParser sut = new TacoParser();

            //Act

            var actual = sut.Parse(str);

            //Assert
            Assert.Equal(name, actual.Name);
            Assert.Equal(latitude, actual.Location.Latitude);
            Assert.Equal(longitude, actual.Location.Longitude);

        }


        //TODO: Complete Should Fail Parse
        [Theory]
        //[InLineData(null)]
        [InlineData("")]
        [InlineData("34.649837, -86.034065, Taco Bell Scottsbor..., Taco Bell")]
        [InlineData("34.649837")]
        public void ShouldFailParse(string str)
        {
            //Arrange
            TacoParser sut = new TacoParser();

            //Act
            var actual = sut.Parse(str);

            //Assert
            Assert.Null(actual);
            

        }
    }
}
