using System;

namespace ConsoleTestBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new CalcServiceReference.CalcServiceClient())
            {
                var req = new CalcServiceReference.Request_Received()
                {
                    a = 1,
                    b = 4
                };

                var response = client.Process(req);
                Console.WriteLine(response.result);
                Console.ReadKey();
            }
        }
    }
}
