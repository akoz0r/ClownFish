using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Discovery;
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
using ClownFish.ServiceReference1;
using GameServerInterfaces;
using GameServerInterfaces.Enums;
using IChessGameService = GameServerInterfaces.IChessGameService;

namespace ClownFish
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

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            InstanceContext site = new InstanceContext(new ClientCallbackHandler());
            ChessGameServiceClient proxy = new ChessGameServiceClient(site);

            WSDualHttpBinding binding = proxy.Endpoint.Binding as WSDualHttpBinding;
            if (binding != null)
            {
                binding.ClientBaseAddress = new Uri(proxy.Endpoint.Address.Uri.Scheme + "://" + System.Environment.MachineName + ":8090/" + typeof(IChessGameService).Name);
                var game = proxy.CreateGame("ClownFish", ColorEnum.White, new TimeSpan(0, 30, 0), new TimeSpan(0, 0, 5));
                var games = proxy.GetGames();
                proxy.Subscribe(game.GameID);
                bool b = proxy.JoinGame(game.GameID, "ClownFish2");
            }
        }
    }
}
