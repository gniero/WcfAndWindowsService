using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAndWindowsService
{
    [ServiceContract(Namespace = "WcfAndWindowsService")]
    public interface ICommunicator
    {
        [OperationContract]
        DullResult GetLastResult();

        [OperationContract]
        void SetMultiplier(int value);
    }
}
