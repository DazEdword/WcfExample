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
        int Substract(int a, int b);
    }
}
