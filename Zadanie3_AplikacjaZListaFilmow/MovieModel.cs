using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3_AplikacjaZListaFilmow
{
    public class MovieModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string title;
        private string director;
        private string publisher;
        private string medium;
        private TimeSpan duration;

        public string Title { 
            get { return title; }
            set { title = value; OnPropertyChanged(); }
            }
        public string Director
        {
            get { return director; }
            set { director = value; OnPropertyChanged(); }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; OnPropertyChanged(); }
        }
        public string Medium
        {
            get { return medium; }
            set { medium = value; OnPropertyChanged(); }
        }
        public TimeSpan Duration
        {
            get { return duration; }
            set { 
                    try {
                            duration = value; 
                        } 
                    catch (Exception ex) { };
                    OnPropertyChanged(); 
                }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
