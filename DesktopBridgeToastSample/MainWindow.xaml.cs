using System;
using System.Collections.Generic;
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
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using DesktopBridgeToastSample.Helper;

namespace DesktopBridgeToastSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbTips.Content = IsRunningAsUwp().ToString();
        }

        public bool IsRunningAsUwp()
        {
            var helpers = new DesktopBridge.Helpers();
            return helpers.IsRunningAsUwp();
        }

        private void ButtonBing_Click(object sender, RoutedEventArgs e)
        {
            string payload = $@"
                <toast activationType='protocol' launch='bingmaps:?q=1+Microsoft+Way,+98052'>
                    <visual>
                        <binding template='ToastGeneric'>
                            <text>Click to launch Bing Maps</text>
                            <text>Searches for ""1 Microsoft Way, 98052""</text>
                        </binding>
                    </visual>
                </toast>";
            ToastHelper.PopCustomToast(payload);

            //MessageBox.Show("Sent the toast!");
        }

        private void ButtonProtocol_Click(object sender, RoutedEventArgs e)
        {
            string payload = $@"
                <toast activationType='protocol' launch='mytoastsample:'>
                    <visual>
                        <binding template='ToastGeneric'>
                            <text>Click to launch DesktopBridgeToastSample</text>
                        </binding>
                    </visual>
                </toast>";
            ToastHelper.PopCustomToast(payload);
        }
    }
}
