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
        }

     

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
