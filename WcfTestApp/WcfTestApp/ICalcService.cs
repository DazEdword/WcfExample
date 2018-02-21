using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfTestApp
{
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        int Add(int a, int b);

        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginAdd(int a, int b, AsyncCallback callback, object state);
        int EndAdd(IAsyncResult asyncResult);

        [OperationContract]
        int Substract(int a, int b);
    }
}
