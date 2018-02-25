using NUnit.Framework;
using NSubstitute;
using WcfTestApp;

namespace CalcServiceTests {
    [TestFixture]
    public class CalcServiceTests {

        public CalcService service;

        [SetUp]
        public void SetUp() {
            service = new CalcService();
        }

        [Test]
        public void ProcessCallsAddMethodWhenRequestOperationIsAdd() {
            // Arrange

            var MockRequest = new WcfTestApp.Request() {
                operation = "add",
                a = 1,
                b = 1
            };

            // Act
            var response = service.Process(MockRequest);

            // Assert
            Assert.IsTrue(response.success);
            Assert.AreEqual(response.result, 2);
        }

        [Test]
        public void ProcessCallsSubtractMethodWhenRequestOperationIsSubtract() {
            // Arrange

            var MockRequest = new WcfTestApp.Request() {
                operation = "subtract",
                a = 1,
                b = 1
            };

            // Act
            var response = service.Process(MockRequest);

            // Assert
            Assert.IsTrue(response.success);
            Assert.AreEqual(response.result, 0);
        }
    }
}
