using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace AdapterChooser.ViewModel
{
    public class HostViewModel : BindableBase
    {
        public string Name { get; set; }

        private BridgeViewModel[] _bindingSwitches;
        private BridgeViewModel[] _adapterSwitches;

        public AdapterViewModel[] PhysicalAdapters { get; set; }

        public BridgeViewModel[] AdapterSwitches
        {
            get => _adapterSwitches;
            set
            {
                _adapterSwitches = value;
                RaisePropertyChanged();
            }
        }

        public BridgeViewModel[] BindingSwitches
        {
            get => _bindingSwitches;
            set
            {
                _bindingSwitches = value;
                RaisePropertyChanged();
            }
        }
    }

    public class NetworkViewModel : BindableBase
    {
        public Configuration config { get; set; }

        public RelayCommand NetworkConfigAddLinuxBridgeCommand { get; set; }

        public RelayCommand NetworkConfigRemoveLinuxBridgeCommand { get; set; }

        public BridgeViewModel SelectedLinuxBridge { get; set; }

        public HostViewModel[] Hosts { get; set; }

        private HostViewModel _selectedHost = new HostViewModel();

        public HostViewModel SelectedHost
        {
            get { return _selectedHost; }
            set
            {
                _selectedHost = value;
                RaisePropertyChanged();
            }
        }



        public NetworkViewModel()
        {
            NetworkConfigAddLinuxBridgeCommand = new RelayCommand(NetworkConfigAddLinuxBridge);

            NetworkConfigRemoveLinuxBridgeCommand = new RelayCommand(NetworkConfigRemoveLinuxBridge);

            config = new Configuration();

            PopulateValues();
        }

        private void NetworkConfigRemoveLinuxBridge(object obj)
        {
            var linuxBridges =
                SelectedHost.AdapterSwitches
                .Where(lBridge => !string.Equals(lBridge.Id, SelectedLinuxBridge.Id, StringComparison.OrdinalIgnoreCase))
                .ToList();

            SelectedHost.AdapterSwitches = linuxBridges.ToArray();
            SelectedHost.BindingSwitches = linuxBridges.ToArray();
        }

        private void NetworkConfigAddLinuxBridge(object obj)
        {
            var linuxBridgeName = "vmbr" + (new Random()).Next(10, 50);

            var lBridge = new BridgeViewModel
            {
                Name = linuxBridgeName,
                Id = Guid.NewGuid().ToString().ToUpper(),
                IsReadOnly = false,
                PhysicalAdapters = SelectedHost.PhysicalAdapters,
                SelectedAdapters = new ObservableCollection<AdapterViewModel>(),
            };

            var linuxBridges = SelectedHost.AdapterSwitches.ToList();
            linuxBridges.Add(lBridge);
            SelectedHost.AdapterSwitches = linuxBridges.ToArray();
            SelectedHost.BindingSwitches = linuxBridges.ToArray();
        }

        public void PopulateValues()
        {
            config.Hosts = new HostConfiguration[]
            {
                new HostConfiguration()
                {
                    Name = "Prox-1",
                    PhysicalAdapters = new PhysicalAdapterConfiguration[]
                    {
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth0",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "vmbr0",
                            IsBound = true,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth1",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "vmbr1",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth2",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "vmbr2",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth3",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "vmbr3",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth4",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth5",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth6",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth7",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                    },
                    NetworkBridges = new NetworkBridgeConfiguration[]
                    {
                        new NetworkBridgeConfiguration()
                        {
                            Name = "vmbr0",
                            Id = Guid.NewGuid().ToString(),
                            IsReadOnly = true,
                        },
                        new NetworkBridgeConfiguration()
                        {
                            Name = "vmbr1",
                            Id = Guid.NewGuid().ToString(),
                            IsReadOnly = false,
                        },
                        new NetworkBridgeConfiguration()
                        {
                            Name = "vmbr2",
                            Id = Guid.NewGuid().ToString(),
                            IsReadOnly = false,
                        },
                        new NetworkBridgeConfiguration()
                        {
                            Name = "vmbr3",
                            Id = Guid.NewGuid().ToString(),
                            IsReadOnly = false,
                        },
                    }
                },

                new HostConfiguration()
                {
                    Name = "Prox-2",
                    PhysicalAdapters = new PhysicalAdapterConfiguration[]
                    {
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth0",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "vmbr0",
                            IsBound = true,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth1",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "vmbr1",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth2",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "vmbr2",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                        new PhysicalAdapterConfiguration()
                        {
                            Name = "eth3",
                            Id = Guid.NewGuid().ToString(),
                            NetworkBridgeId = "vmbr3",
                            IsBound = false,
                            IsPreconfigured = false,
                        },
                    },
                    NetworkBridges = new NetworkBridgeConfiguration[]
                    {
                        new NetworkBridgeConfiguration()
                        {
                            Name = "vmbr0",
                            Id = Guid.NewGuid().ToString(),
                            IsReadOnly = true,
                        },
                        new NetworkBridgeConfiguration()
                        {
                            Name = "vmbr1",
                            Id = Guid.NewGuid().ToString(),
                            IsReadOnly = false,
                        },
                        new NetworkBridgeConfiguration()
                        {
                            Name = "vmbr2",
                            Id = Guid.NewGuid().ToString(),
                            IsReadOnly = false,
                        },
                        new NetworkBridgeConfiguration()
                        {
                            Name = "vmbr3",
                            Id = Guid.NewGuid().ToString(),
                            IsReadOnly = false,
                        },
                    }
                },
            };

            var hosts = new List<HostViewModel>();
            foreach (var host in config.Hosts)
            {

                var hostAdapters = host.PhysicalAdapters
                   .OrderBy(adapter => adapter.Name)
                   .ToArray();

                var physicalAdapters = hostAdapters
                    .Select(adapter => new AdapterViewModel
                    {
                        Name = adapter.Name,
                        Id = adapter.Id,
                    })
                    .ToArray();

                var bridges = host.NetworkBridges
                        .Select(bridge =>
                        {
                            var adapters = hostAdapters
                                .Where(adapter => bridge.Name.Equals(adapter.NetworkBridgeId, StringComparison.OrdinalIgnoreCase));

                            var adaptersViewModel = physicalAdapters
                                .Where(x => adapters.Select(ad => ad.Name).Contains(x.Name))
                                .ToArray();

                            var linuxBridgeViewModel =
                                new BridgeViewModel
                                {
                                    Id = bridge.Id,
                                    Name = bridge.Name,
                                    IsReadOnly = bridge.IsReadOnly,
                                    PhysicalAdapters = adaptersViewModel,
                                    SelectedAdapters = new ObservableCollection<AdapterViewModel>(adaptersViewModel.ToList()), //new ObservableCollection<PhysicalAdapterViewModel>(),
                                };

                            return linuxBridgeViewModel;
                        })
                        .ToList();


                hosts.Add(new HostViewModel()
                {
                    Name = host.Name,
                    PhysicalAdapters = physicalAdapters,
                    BindingSwitches = bridges.ToArray(),
                    AdapterSwitches = bridges.ToArray(),
                });
            }

            Hosts = hosts.ToArray();

            SelectedHost = Hosts[0];
          
        }
    }

    public class AdapterViewModel : BindableBase
    {
        public string Name { get; set; }

        public string Id { get; set; }
    }

    public class BridgeViewModel : BindableBase
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool IsReadOnly { get; set; }
        public AdapterViewModel[] PhysicalAdapters { get; set; }

        private ObservableCollection<AdapterViewModel> _selectedAdapters { get; set; }
        public ObservableCollection<AdapterViewModel> SelectedAdapters
        {
            get => _selectedAdapters;
            set
            {
                if (_selectedAdapters != null)
                {
                    _selectedAdapters.CollectionChanged -= SelectedAdapters_CollectionChanged;
                }

                _selectedAdapters = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAdaptersDisplay));

                if (_selectedAdapters != null)
                {
                    _selectedAdapters.CollectionChanged += SelectedAdapters_CollectionChanged;
                }
            }
        }


        private void SelectedAdapters_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // This will refresh the text in UI whenever selection changes
            RaisePropertyChanged(nameof(SelectedAdaptersDisplay));
        }

        public string SelectedAdaptersDisplay
        {
            get
            {
                if (SelectedAdapters == null || SelectedAdapters.Count == 0)
                    return "Select adapters";

                return string.Join(" ", SelectedAdapters.Select(a => a.Name));
            }
        }
    }
}
