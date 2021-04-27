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
    /// Логика взаимодействия для WindowPlatform.xaml
    /// </summary>
    public partial class WindowPlatform : Window
    {
        Game_CenterEntities context;
        public WindowPlatform()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var newPlatform = new Platform();
            newPlatform.Name = txtPlatform.Text;
            context.Platform.Add(newPlatform);
            context.SaveChanges();
            this.Close();
        }
    }
}
