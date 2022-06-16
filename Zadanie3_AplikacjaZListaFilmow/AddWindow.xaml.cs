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

namespace Zadanie3_AplikacjaZListaFilmow
{
    /// <summary>
    /// Logika interakcji dla klasy EditWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private MovieModel _model;
        public AddWindow()
        {
            InitializeComponent();
            _model = new MovieModel();
            DataContext = _model;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var lastId = MainWindow.exampleData.Any() ? MainWindow.exampleData.Max(x => x.Id) : 0;
            _model.Id = lastId + 1;
            MainWindow.exampleData.Add(_model);
           Close();
        }
    }
}
