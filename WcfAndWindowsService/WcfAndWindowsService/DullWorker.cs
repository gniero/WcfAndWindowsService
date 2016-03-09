using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WcfAndWindowsService
{
    public class DullWorker
    {
        private Thread _dataGeneratorThread;

        public DullResult LastResult { get; private set; }

        private volatile bool _running;

        public int Multiplier { get; set; }

        public void Start()
        {
            if (_dataGeneratorThread != null)
            {
                if (_dataGeneratorThread.IsAlive)
                {
                    return;
                }
            }
            _running = true;
            _dataGeneratorThread = new Thread(new ThreadStart(() =>
            {
                Random rdm = new Random();
                while (_running)
                {
                    var multiplicand = rdm.Next(500);
                    LastResult = new DullResult(Multiplier, multiplicand, Multiplier * multiplicand);
                    try
                    {
                        Thread.Sleep(8000);
                    }
                    catch { }
                }
            }));
            _dataGeneratorThread.Start();
        }

        public void Stop()
        {
            _running = false;
            _dataGeneratorThread.Abort();
            _dataGeneratorThread.Join();
        }

        public bool IsRunning
        {
            get { return _running; }
        }


    }
}
