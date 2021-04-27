using CourseMM.Windows;
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
    /// Логика взаимодействия для UserControlGameProperties.xaml
    /// </summary>
    public partial class UserControlGameProperties : UserControl
    {
        Game_CenterEntities context;
        public UserControlGameProperties()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            DGGenre.ItemsSource = context.Genre.ToList();
            DGPlatform.ItemsSource = context.Platform.ToList();
            DGPublisher.ItemsSource = context.Publisher.ToList();

        }

        private void btnAddGenre_Click(object sender, RoutedEventArgs e)
        {
            var newGenre = new Genre();
            WindowGenre windowGenre = new WindowGenre(DGGenre,newGenre);
            windowGenre.Show();
         
        }
       

        private void btnAddPublisher_Click(object sender, RoutedEventArgs e)
        {
            WindowPublisher windowPublisher = new WindowPublisher();
            windowPublisher.Show();
        }

        private void btnAddPublisher_Click_1(object sender, RoutedEventArgs e)
        {
            WindowPlatform windowPlatform = new WindowPlatform();
            windowPlatform.Show();
        }

        private void btnDelGenre_Click(object sender, RoutedEventArgs e)
        {
            var row = (Genre)DGGenre.SelectedItem;
            if(row == null)
            {
                MessageBox.Show("Выберите строку на удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Delete question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.Genre.Remove(row);
                    context.SaveChanges();
                    DGGenre.ItemsSource = context.Genre.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка удаления " + ex, "Error" , MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
        }

        private void DGGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGGenre.ItemsSource = context.Genre.ToList();
        }

        private void btnDelPublisher_Click(object sender, RoutedEventArgs e)
        {
            var row = (Publisher)DGPublisher.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Выберите строку на удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Delete question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.Publisher.Remove(row);
                    context.SaveChanges();
                    DGGenre.ItemsSource = context.Genre.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnDelPlatform_Click(object sender, RoutedEventArgs e)
        {
            var row = (Platform)DGPlatform.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Выберите строку на удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Delete question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.Platform.Remove(row);
                    context.SaveChanges();
                    DGGenre.ItemsSource = context.Genre.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DGPublisher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGPublisher.ItemsSource = context.Publisher.ToList();
        }

        private void DGPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           DGPlatform.ItemsSource = context.Platform.ToList();
        }
    }
}
