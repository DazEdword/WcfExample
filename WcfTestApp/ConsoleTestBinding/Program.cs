using System;

namespace ConsoleTestBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new CalcServiceReference.CalcServiceClient())
            {
                Console.WriteLine("Let's add some numbers.");
                Console.WriteLine("Please type your first digit and press enter.");

                //TODO Improve user input robustness so that only integers are accepted
                int a = GetUserInput();

                Console.WriteLine("Please type your second digit and press enter.");
                int b = GetUserInput();

                Console.WriteLine("Sending request to server...");
                var req = new CalcServiceReference.Request()
                {
                    a = a,
                    b = b
                };

                var response = client.Process(req);

                if (response.success == true)
                {
                    Console.WriteLine(String.Format("Your result: {0}", response.result));
                }
                else
                {
                    Console.WriteLine("Operation failed.");
                }
                
                Console.ReadKey();
            }
        }

        static int GetUserInput()
        {
            int value;

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Please Enter a valid numerical value!");
            }

            return value;
        }
    }
}
