using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalcService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CalcService.svc or CalcService.svc.cs at the Solution Explorer and start debugging.
    public class CalcService : ICalcService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public async Task<int> AddAsync(int a, int b)
        {
            var myTask = Task.Factory.StartNew(() => Add(a, b));
            var result = await myTask;
            return result;
        }

        //TODO Investigate: do async methods work in SOAP?
        public IAsyncResult BeginAdd(int a, int b, AsyncCallback callback, object state) {
            var tcs = new TaskCompletionSource<int>(state);
            var task = AddAsync(a, b);
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.InnerExceptions);
                else if (t.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(t.Result);

                if (callback != null)
                    callback(tcs.Task);
            });

            return tcs.Task;
        }

        public int EndAdd(IAsyncResult asyncResult)
        {
            return ((Task<int>)asyncResult).Result;
        }

        public int Substract(int a, int b)
        {
            return a - b;
        }
    }
}
