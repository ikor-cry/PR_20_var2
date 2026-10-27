using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PR_20_var2
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Film> AllFilms;

        public ObservableCollection<string> Genres { get; set; }

        public ObservableCollection<Film> FilteredFilms { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Заполняем базу фильмов
            AllFilms = new ObservableCollection<Film>
            {
                new Film { Title = "Интерстеллар", Genre = "Фантастика", Description = "Эпическая история о путешествии через черную дыру ради спасения человечества." },
                new Film { Title = "Начало", Genre = "Фантастика", Description = "Вор проникает в сны людей, чтобы украсть секреты, но получает задание внедрить идею." },
                new Film { Title = "1+1", Genre = "Комедия", Description = "Забавная история про двух чуваков один чёрный другой белый а ещё вторая чксть говно" },
                new Film { Title = "Зеленая миля", Genre = "Драма", Description = "История про большого тони и его друга, с которым он откал пол америки" },
                new Film { Title = "The Boys", Genre = "Комедия", Description = "Приключения консьержа и его лобби-боя в знаменитом европейском отеле." }
            };

            Genres = new ObservableCollection<string>();
            FilteredFilms = new ObservableCollection<Film>();

            foreach (var film in AllFilms)
            {
                if (!Genres.Contains(film.Genre))
                {
                    Genres.Add(film.Genre);
                }
            }

            DataContext = this;
        }

        private void GenreCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGenre = GenreCombo.SelectedItem as string;

            if (selectedGenre != null)
            {
                FilteredFilms.Clear();

                foreach (var film in AllFilms)
                {
                    if (film.Genre == selectedGenre)
                    {
                        FilteredFilms.Add(film);
                    }
                }
            }
        }

        private void ShowDescription_Click(object sender, RoutedEventArgs e)
        {
            if (FilmList.SelectedItem is Film selectedFilm)
            {
                DescriptionText.Text = selectedFilm.Description;
            }
            else
            {
                MessageBox.Show("Сначала выберите фильм из списка");
            }
        }
    }
}