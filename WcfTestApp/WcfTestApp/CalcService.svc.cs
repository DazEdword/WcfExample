using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestApp
{
    public class CalcService : ICalcService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public async Task<int> AddAsyncTest(int a, int b)
        {
            var myTask = Task.Factory.StartNew(() => Add(a, b));
            var result = await myTask;
            return result;
        }

        public Response Process(Request request)
        {
            int? result;
            bool success;

            try
            {
                result = Add(request.a, request.b);
                success = true;
            }
            catch (System.FormatException)
            {
                result = null;
                success = false;
            }
           
            return new Response()
            {
                result = result,
                success = success
            };
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
