using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterChooser.ViewModel
{
    public class Configuration
    {

        public HostConfiguration[] Hosts { get; set; }


        public Configuration() 
        {
        }
    }

    public class HostConfiguration
    {
        public string Name { get; set; }

        public PhysicalAdapterConfiguration[] PhysicalAdapters { get; set; }

        public NetworkBridgeConfiguration[] NetworkBridges { get; set; }
    }

    public class NetworkBridgeConfiguration
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public bool IsReadOnly { get; set; }
    }

    public class PhysicalAdapterConfiguration
    {

        public string Name { get; set; }

        public string Id { get; set; }

        public string NetworkBridgeId { get; set; }

        public bool IsBound { get; set; }

        public bool IsPreconfigured { get; set; }
    }
}
