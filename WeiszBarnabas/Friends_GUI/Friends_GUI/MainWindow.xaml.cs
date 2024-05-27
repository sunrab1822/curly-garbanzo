using Friends_WPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Friends_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string tulajdonsagNev)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNev));
        }

        DataContext context = new DataContext();
        public ObservableCollection<Season> seasons { get; set; }
        public ObservableCollection<Episode> episodes { get; set; }
        private ObservableCollection<Episode> showedEpisodes;
        public ObservableCollection<Episode> ShowedEpisodes
        {
            get { return showedEpisodes; }
            set { showedEpisodes = value; OnPropertyChanged(nameof(ShowedEpisodes)); }
        }

        private Season selectedSeason;

        public Season SelectedSeason
        {
            get { return selectedSeason; }
            set { selectedSeason = value; OnPropertyChanged(nameof(SelectedSeason)); }
        }

        private Episode selectedEpisode;

        public Episode SelectedEpisode
        {
            get { return selectedEpisode; }
            set { selectedEpisode = value; OnPropertyChanged(nameof(SelectedEpisode)); }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            context.seasons.Load();
            context.episodes.Load();

            seasons = context.seasons.Local.ToObservableCollection();
            episodes = context.episodes.Local.ToObservableCollection();




        }

        private void seasons_CBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedSeason != null)
            {
                ShowedEpisodes = new ObservableCollection<Episode>( episodes.Where(x=> x.seasonId == SelectedSeason.id).ToList());

            }
        }
    }
}
