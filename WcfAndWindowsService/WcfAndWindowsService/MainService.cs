using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndWindowsService
{
    partial class MainService : ServiceBase
    {
        private DullWorker _worker;

        private ServiceHost _serviceHost = null;

        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnContinue()
        {
            _worker.Start();
            base.OnContinue();
        }

        protected override void OnPause()
        {
            _worker.Stop();
            base.OnPause();
        }

        protected override void OnStart(string[] args)
        {
            _worker = new DullWorker();
            _worker.Start();

            if (_serviceHost != null)
                _serviceHost.Close();

            _serviceHost = new ServiceHost(new Communicator(() => { return _worker.LastResult; }, x => { _worker.Multiplier = x; }));

            _serviceHost.Open();

        }

        protected override void OnStop()
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
                _serviceHost = null;
            }

            _worker.Stop();
            _worker = null;
        }
    }
}
