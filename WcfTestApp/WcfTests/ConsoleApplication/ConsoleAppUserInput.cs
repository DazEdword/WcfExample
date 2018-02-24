using ConsoleTestBinding;
using NUnit.Framework;
using NSubstitute;
using RunHelper = WcfTests.UnitTestUtilities.RunHelper;
using Target = ConsoleTestBinding.CalcConsoleClient;

namespace WcfTests.ConsoleApplication {

    [TestFixture]
    public class ConsoleAppUserInput {

        [SetUp]
        public void SetUp() {
            
        }

        [Test]
        public void GetUserNumericalInputReturnsIntegerWhenInputIsInteger() {
            //Arrange
            IGetInput InputMock = Substitute.For<IGetInput>();
            InputMock.GetUserInput().Returns(x => "5");
            int expected = 5;

            Target.Input = InputMock;

            //Act
            var result = RunHelper.RunStaticMethod(typeof(CalcConsoleClient), "GetUserNumericalInput", null);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetUserNumericalInputDoesNotReturnIfInputIsOtherThanInteger() {
            //Arrange
            IGetInput InputMock = Substitute.For<IGetInput>();
            InputMock.GetUserInput().Returns(x => "5");
            int expected = 5;

            Target.Input = InputMock;

            //Act
            var result = RunHelper.RunStaticMethod(typeof(CalcConsoleClient), "GetUserNumericalInput", null);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}