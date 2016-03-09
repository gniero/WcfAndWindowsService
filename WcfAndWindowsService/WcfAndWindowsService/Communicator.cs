using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAndWindowsService
{
    public delegate DullResult GetResultDelegate();
    public delegate void SetMultiplierDelegate(int value);

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Communicator" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Communicator : ICommunicator
    {
        private GetResultDelegate _getResult;
        private SetMultiplierDelegate _setMultiplier;
        
        public Communicator(GetResultDelegate getResult, SetMultiplierDelegate setMultiplier)
        {
            _setMultiplier = setMultiplier;
            _getResult = getResult;
        }
        public DullResult GetLastResult()
        {
            return _getResult();
        }

        public void SetMultiplier(int value)
        {
            _setMultiplier(value);
        }
    }
}
