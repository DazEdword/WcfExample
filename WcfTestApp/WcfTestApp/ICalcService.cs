using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestApp
{
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        int Add(int a, int b);

        [OperationContract(AsyncPattern = true)]
        Task<int> AddAsyncTest(int a, int b);

        [OperationContract]
        int Subtract(int a, int b);

        [OperationContract]
        Response Process(Request request);
    }

    public class Request
    {
        public int a;
        public int b;
    }

    public class Response
    {
        public bool success;
        public int result;
    }
}
