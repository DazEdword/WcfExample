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
                int a = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please type your second digit and press enter.");
                int b = Convert.ToInt32(Console.ReadLine());

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
    }
}
