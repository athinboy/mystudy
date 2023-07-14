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

namespace WpfFW1
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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "btnOpenCommand":
                    CommandWindow commandWindow = new CommandWindow();
                    commandWindow.Owner = this;
                    commandWindow.Show();
                    break;
                case "btnOpenCacheModel":
                    CacheModeWindow001 cacheModeWindow001 = new CacheModeWindow001();
                    cacheModeWindow001.Owner = this;
                    cacheModeWindow001.Show();
                    break;
                default:
                    break;
            }

        }
    }
}
