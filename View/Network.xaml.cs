using AdapterChooser.ViewModel;
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
using System.Windows.Shapes;

namespace AdapterChooser.View
{
    /// <summary>
    /// Interaction logic for Network.xaml
    /// </summary>
    public partial class Network : Window
    {
        public Network()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as NetworkViewModel;
        }

        // To Debug the code
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var items = dataGrid.Items;

            foreach (var item in items)
            {
                var itemViewModel = item;            
            }


        }
    } 
}
