using System;

namespace ConsoleTestBinding {
    public class CalcConsoleClient {
        public static string[] availableOperations = { "add", "subtract" };
        public static IGetInput Input = new Input();
        public static IPrintOutput Output = new Output();

        public static void Main(string[] args) {
            using (var client = new CalcServiceReference.CalcServiceClient()) {
                Console.WriteLine("Welcome to the WCF calculator. Please make sure to type your input and press enter when prompted.");
                Console.WriteLine(String.Format("Let's do some simple math. The available operations are: {0}", String.Join(", ", availableOperations)));
                Console.WriteLine("What operation would you like the app to perform?");

                string operation = GetUserOperationInput();
                Console.WriteLine("First digit?");

                int a = GetUserNumericalInput();

                Console.WriteLine("Second digit?");
                int b = GetUserNumericalInput();

                Console.WriteLine("Sending request to server...");
                var req = new CalcServiceReference.Request() {
                    operation = operation,
                    a = a,
                    b = b
                };

                var response = client.Process(req);

                if (response.success == true) {
                    Console.WriteLine(String.Format("Your result: {0}", response.result));
                } else {
                    Console.WriteLine("Operation failed.");
                }

                Console.ReadKey();
            }
        }

        //TODO limits of int32 apply, ranging -2,147,483,648 to 2,147,483,647
        static int GetUserNumericalInput() {
            int value;

            while (!int.TryParse(Input.GetUserInput(), out value)) {
                Output.PrintUserOutput("Please Enter a valid numerical value!");
            }

            return value;
        }

        static string GetUserOperationInput() {
            string userInput = null;

            bool valid = false;

            while (!valid) {
                userInput = Input.GetUserInput();

                switch (userInput) {
                    case "add":
                        valid = true;
                        break;
                    case "subtract":
                        valid = true;
                        break;
                    default:
                        Output.PrintUserOutput("Please Enter a valid operation!");
                        break;
                }
            }

            return userInput;
        }
    }

    /// <summary>
    /// Abstracting input and output for better testability. In practice, we are just using 
    /// Console.ReadLine and Console.WriteLine.
    /// </summary>
    public class Input : IGetInput {
        public string GetUserInput() {
            return Console.ReadLine();
        }
    }

    public class Output : IPrintOutput {
        public void PrintUserOutput(string message) {
            Console.WriteLine(message);
        }
    }

    public interface IGetInput {
        string GetUserInput();
    }

    public interface IPrintOutput {
        void PrintUserOutput(string message);
    }
}
