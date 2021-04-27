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

namespace CourseMM.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControlGameCreate.xaml
    /// </summary>
    public partial class UserControlGameCreate : UserControl
    {
        Game_CenterEntities _context;
        

        public UserControlGameCreate(Game_CenterEntities context)
        {
            InitializeComponent();
            _context = context;
            cmbAgeLimit.ItemsSource = _context.AgeLimit.ToList();
            cmbGameGenre.ItemsSource = _context.Genre.ToList();
            cmbGamePlatform.ItemsSource = _context.Platform.ToList();
            cmbGamePublisher.ItemsSource = _context.Publisher.ToList();
            
        }

        private void txtQty_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newGame = new Games();
                var newGameInfo = new GameInfo();
                _context.Games.Add(newGame);
                _context.GameInfo.Add(newGameInfo);
                newGame.Name = txtNewGame.Text;
                newGameInfo.AgeLimit = (AgeLimit)cmbAgeLimit.SelectedItem;
                newGameInfo.Genre = (Genre)cmbGameGenre.SelectedItem;
                newGameInfo.Platform = (Platform)cmbGamePlatform.SelectedItem;
                newGameInfo.Publisher = (Publisher)cmbGamePublisher.SelectedItem;
                int qount = Int32.Parse(txtQty.Text);
                newGame.Qty = qount;
                decimal price = Convert.ToDecimal(txtPrice.Text);
                newGame.Price = price;
                newGame.DelDate = SupplyDate.SelectedDate;
                newGameInfo.Release = ReleaseDate.SelectedDate;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка сохранения!: " + ex.ToString());
            }
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
    }
}
