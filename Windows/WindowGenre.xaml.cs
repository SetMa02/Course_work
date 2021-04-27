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
    /// Логика взаимодействия для WindowGenre.xaml
    /// </summary>
    public partial class WindowGenre : Window
    {
        Game_CenterEntities context;
        public WindowGenre(DataGrid DG, Genre genre)
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            DG.ItemsSource = context.Genre.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var newGenre = new Genre();
            newGenre.NameOfGenre = txtGenre.Text;
            context.Genre.Add(newGenre);
            context.SaveChanges();
            this.Close();
        }
    }
}
