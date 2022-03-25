using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlchemyGetTransfersPageKeyError
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public Web3 _web3;
        public GetAssetTransfers _getAssetTransfers;
        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();

        private void InitClick(object sender, RoutedEventArgs e)
        {
            _web3 = new Web3(RpcBox.Text);
            _getAssetTransfers = new GetAssetTransfers(_web3.Client);
            Messages.Add($"Initialized Web3: {RpcBox.Text}");
        }

        private async void RunClick(object sender, RoutedEventArgs e)
        {
            Messages.Add("Running...");

            var requestInput = new AssetTransfersInput(new BlockParameter(new HexBigInteger(0)), BlockParameter.CreateLatest())
            {
                Category = AssetTransfersInput.AllEthAndErcCategorys,
                FromAddress = "0xAff1BF27f0aE7ce8AC0b7d3Ec7638933eDE0194E"
            };

            var allTransfers = new List<AssetTransfer>();

            while(true)
            {
                try
                {
                    var response = await _getAssetTransfers.SendRequestAsync(requestInput);

                    Messages.Add($"returned {response.Transfers.Count} transfers with PageKey: {response.PageKey}");

                    allTransfers.AddRange(response.Transfers);

                    requestInput.PageKey = response.PageKey;

                    if (response.PageKey is null)
                    {
                        break;
                    }
                }
                catch(RpcResponseException ex)
                {
                    Messages.Add($"returned error: {ex.Message}");

                    break;
                }
            }

            Messages.Add("Finished.");
        }
    }
}
