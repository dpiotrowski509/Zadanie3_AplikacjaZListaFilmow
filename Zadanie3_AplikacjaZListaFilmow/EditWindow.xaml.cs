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
    public partial class EditWindow : Window
    {
        private MovieModel _model;
        public EditWindow(MovieModel model)
        {
            InitializeComponent();
            _model = IsolateModel(model);
            DataContext = _model;
        }

        private void Save(object sender, RoutedEventArgs e)
        {

           if(MainWindow.exampleData.Any(x=>x.Id == _model.Id))
           {
               MainWindow.exampleData.RemoveAt(_model.Id-1);
               MainWindow.exampleData.Add(_model);
           }
           Close();
        }

        private MovieModel IsolateModel(MovieModel oldModel)
        {
            return  new MovieModel { Id = oldModel.Id, Director = oldModel.Director, Duration = oldModel.Duration, Medium = oldModel.Medium, Publisher = oldModel.Publisher, Title = oldModel.Title};
        }
    }
}
