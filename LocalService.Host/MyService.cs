using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using LocalService.Core;
namespace LocalService.Host
{
    public partial class MyService : ServiceBase
    {
        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ApplicationBoot.Start();
        }

        protected override void OnStop()
        {
            ApplicationBoot.Stop();
        }
    }
}
