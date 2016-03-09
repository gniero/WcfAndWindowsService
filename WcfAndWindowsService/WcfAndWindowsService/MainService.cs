using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndWindowsService
{
    partial class MainService : ServiceBase
    {
        private DullWorker _worker;

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
        }

        protected override void OnStop()
        {
            _worker.Stop();
        }
    }
}
