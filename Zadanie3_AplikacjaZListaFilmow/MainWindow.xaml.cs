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

namespace Zadanie3_AplikacjaZListaFilmow
{       
        /*
          Projekt na zaliczneie z programowania .NET
          Autor: Damian Piotrowski
          Grupa: ININ3_PR1
          Album: 63172
         */
    public partial class MainWindow : Window
    {
        public static ObservableCollection<MovieModel> exampleData = new ObservableCollection<MovieModel>();
        private int? lastSeletedId = null;
        public MainWindow()
        {
            InitializeComponent();
            PrepareExampleData();
            DataContext = exampleData;
        }



        private void PrepareExampleData()
        {
            AddNewRecord(new MovieModel { Title = "Zielona mila", Director = "Frank Darabont", Publisher = "Castle Rock Entertainment", Medium = "DVD", Duration = new TimeSpan(3,1,0) });
            AddNewRecord(new MovieModel { Title = "Skazani na Shawshank", Director = "Frank Darabont", Publisher = "Doubleday", Medium = "DVD", Duration = new TimeSpan(2,20,0) });
            AddNewRecord(new MovieModel { Title = "Joker", Director = "Todd Phillips", Publisher = "Warner Bros.", Medium = "DVD/Blu-ray", Duration = new TimeSpan(2,2,0) });

        }
        private void AddNewRecord(MovieModel model)
        {
            var lastId = exampleData.Any() ? exampleData.Max(x => x.Id) : 0;
            model.Id = lastId + 1;
            exampleData.Add(model);
        }

        private void ClickEditButton(object sender, RoutedEventArgs e)
        {
            if (lastSeletedId != null)
            {
                EditWindow editWindow = new EditWindow(exampleData.Where(x => x.Id == lastSeletedId.Value).FirstOrDefault());
                editWindow.Show();

            }
        }
        private void ClickAddButton(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        private void GetItemId(object sender, RoutedEventArgs e)
        {

            var list = (ListView)sender;
            var item = (MovieModel)list.SelectedItem;
            if(item != null)
            {
                lastSeletedId = item.Id;
            }
        }
    }
}
