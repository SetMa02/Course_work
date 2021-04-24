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

namespace CourseMM
{
    /// <summary>
    /// Логика взаимодействия для UserControlDashboard.xaml
    /// </summary>
    public partial class UserControlDashboard : UserControl
    {
        Game_CenterEntities context;
        public UserControlDashboard()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            DataGridGames.ItemsSource = context.GameInfo.ToList();
            cmbGenre.ItemsSource = context.Genre.ToList();
            cmbPlatform.ItemsSource = context.Platform.ToList();
        }

     

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string findText = txtName.Text;
            List<GameInfo> gameInfo = context.GameInfo.ToList();
            gameInfo = gameInfo.Where(x => x.Games.Name.ToLower().Contains(findText.ToLower())).ToList();
            DataGridGames.ItemsSource = gameInfo.ToList();
        }

        private void cmbGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbGenre == null)
                return;

            var currentGenre = (Genre)cmbGenre.SelectedItem;
            List<GameInfo> gameInfos = context.GameInfo.ToList();
            gameInfos = gameInfos.Where(a => a.Genre == currentGenre).ToList();
            DataGridGames.ItemsSource = gameInfos.ToList();
        }

        private void cmbPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPlatform == null)
                return;

            var currentPlatform = (Platform)cmbPlatform.SelectedItem;
            List<GameInfo> gameInfos1 = context.GameInfo.ToList();
            gameInfos1 = gameInfos1.Where(a => a.Platform == currentPlatform).ToList();
            DataGridGames.ItemsSource = gameInfos1.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            cmbPlatform.Text = "";
            cmbGenre.Text = "";
            DataGridGames.ItemsSource = context.GameInfo.ToList();
        }
    }
}
