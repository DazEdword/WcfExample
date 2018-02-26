using System.ServiceModel;
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
}
