using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace TypAnalyseWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _model;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            if(this.tbClass.Text == string.Empty)
            {
                MessageBox.Show("Es muss eine Klasse eingegeben werden", "TypAnalyseWPF", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this._model = FindResource("mvmodel") as MainViewModel;

                Type type = Type.GetType($"{Assembly.GetEntryAssembly().GetName().Name}.{this.tbClass.Text}");

                if (type == null)
                    MessageBox.Show("Dieser Typ existiert nicht", "TypAnalyseWPF", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    this._model.SelType = type;
            }
        }
    }
}
