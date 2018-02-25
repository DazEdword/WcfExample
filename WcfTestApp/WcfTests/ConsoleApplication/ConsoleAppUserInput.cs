using ConsoleTestBinding;
using NUnit.Framework;
using NSubstitute;
using RunHelper = WcfTests.UnitTestUtilities.RunHelper;
using Target = ConsoleTestBinding.CalcConsoleClient;


namespace WcfTests.ConsoleApplication {

    [TestFixture]
    public class ConsoleAppUserInput {

        [Test]
        public void GetUserNumericalInputReturnsIntegerWhenInputIsInteger() {
            // Arrange
            IGetInput InputMock = Substitute.For<IGetInput>();
            InputMock.GetUserInput().Returns(x => "5");
            int expected = 5;

            Target.Input = InputMock;

            // Act
            var result = RunHelper.RunStaticMethod(typeof(CalcConsoleClient), "GetUserNumericalInput", null);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetUserNumericalInputPrintsErrorMessageWhenInputIsOtherThanInteger() {
            // Arrange
            IGetInput InputMock = Substitute.For<IGetInput>();
            IPrintOutput OutputMock = Substitute.For<IPrintOutput>();

            // As the console stays in a loop if an invallid call is received, we are forcing a return with a second valid call
            InputMock.GetUserInput().Returns("h", "3");

            Target.Input = InputMock;
            Target.Output = OutputMock;

            // Act
            var result = RunHelper.RunStaticMethod(typeof(CalcConsoleClient), "GetUserNumericalInput", null);

            // Assert
            OutputMock.Received().PrintUserOutput("Please Enter a valid numerical value!");
        }

        [Test]
        public void GetUserNumericalInputBlocksExecutionUntilValidValueIsFound() {
            // Arrange
            IGetInput InputMock = Substitute.For<IGetInput>();
            IPrintOutput OutputMock = Substitute.For<IPrintOutput>();

            // As the console stays in a loop if an invallid call is received, we are forcing a return with a second valid call
            InputMock.GetUserInput().Returns("a", "b", "c", "&", "3");

            Target.Input = InputMock;
            Target.Output = OutputMock;

            // Act
            var result = RunHelper.RunStaticMethod(typeof(CalcConsoleClient), "GetUserNumericalInput", null);

            // Assert
            // Failed 4 times, one per invalid input
            OutputMock.Received(4);
            OutputMock.Received().PrintUserOutput("Please Enter a valid numerical value!");
        }

        [Test]
        public void GetUserNumericalInputPrintsErrorIfIntIsOutOfRange() {
            // Arrange
            IGetInput InputMock = Substitute.For<IGetInput>();
            IPrintOutput OutputMock = Substitute.For<IPrintOutput>();

            // As the console stays in a loop if an invalid call is received, we are forcing a return with a second valid call
            InputMock.GetUserInput().Returns("2147483999", "4");

            Target.Input = InputMock;
            Target.Output = OutputMock;

            // Act
            var result = RunHelper.RunStaticMethod(typeof(CalcConsoleClient), "GetUserNumericalInput", null);

            // Assert
            // Failed 4 times, one per invalid input
            OutputMock.Received(1);
            OutputMock.Received().PrintUserOutput("Please Enter a valid numerical value!");
        }

        [Test]
        public void GetUserOperationInputOnlyAcceptsValidOperations() {
            // Arrange
            IGetInput InputMock = Substitute.For<IGetInput>();
            IPrintOutput OutputMock = Substitute.For<IPrintOutput>();

            // As the console stays in a loop if an invallid call is received, we are forcing a return with a second valid call
            InputMock.GetUserInput().Returns("hello", "add");

            Target.Input = InputMock;
            Target.Output = OutputMock;

            // Act
            var result = RunHelper.RunStaticMethod(typeof(CalcConsoleClient), "GetUserOperationInput", null);

            // Assert
            // Failed 4 times, one per invalid input
            OutputMock.Received(1);
            OutputMock.Received().PrintUserOutput("Please Enter a valid operation!");
        }
    }
}