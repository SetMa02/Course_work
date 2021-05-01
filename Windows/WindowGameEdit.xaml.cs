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

namespace CourseMM.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowGameEdit.xaml
    /// </summary>
    public partial class WindowGameEdit : Window
    {
        
        Game_CenterEntities context;
        GameInfo newGame1;
        public WindowGameEdit(Game_CenterEntities context1, GameInfo newGame)
        {
            InitializeComponent();
            this.context = context1;
            cmbAgeLimit.ItemsSource = context.AgeLimit.ToList();
            cmbGameGenre.ItemsSource = context.Genre.ToList();
            cmbGamePlatform.ItemsSource = context.Platform.ToList();
            cmbGamePublisher.ItemsSource = context.Publisher.ToList();

        
   
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNewGame.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            cmbAgeLimit.Text = "";
            cmbGameGenre.Text = "";
            cmbGamePlatform.Text = "";
            cmbGamePublisher.Text = "";
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
