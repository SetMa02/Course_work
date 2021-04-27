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
    /// Логика взаимодействия для WindowPublisher.xaml
    /// </summary>
    public partial class WindowPublisher : Window
    {
        Game_CenterEntities context;
        public WindowPublisher()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var newPublisher = new Publisher();
            newPublisher.PublisherName = txtGenre.Text;
            context.Publisher.Add(newPublisher);
            context.SaveChanges();
            this.Close();
        }
    }
}
