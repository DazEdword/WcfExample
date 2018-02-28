using System.Threading.Tasks;

namespace WcfTestApp {
    public class CalcService : ICalcService {

        public Response Process(Request request) {
            int? result;
            bool success;

            try {
                switch (request.operation) {
                    case "add":
                        result = Add(request.a, request.b);
                        break;

                    case "subtract":
                        result = Subtract(request.a, request.b);
                        break;

                    default:
                        result = null;
                        break;
                }

                success = true;
            } catch (System.Exception) {
                result = null;
                success = false;
            }

            return new Response() {
                result = result,
                success = success
            };
        }

        public int Add(int a, int b) {
            return a + b;
        }

        public async Task<int> AddAsyncTest(int a, int b) {
            var myTask = Task.Factory.StartNew(() => Add(a, b));
            var result = await myTask;
            return result;
        }

        public int Subtract(int a, int b) {
            return a - b;
        }

        public async Task<int> SubtractAsyncTest(int a, int b) {
            var myTask = Task.Factory.StartNew(() => Subtract(a, b));
            var result = await myTask;
            return result;
        }
    }
}