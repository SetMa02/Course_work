using CourseMM.Pages;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameManager.MainFrame = MainFrame;
            FrameManager.MainFrame.Navigate(new PageAufth());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(FrameManager.MainFrame.CanGoBack)
            {
                FrameManager.MainFrame.GoBack();
            }
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (!FrameManager.MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Hidden;
            }
            else
                btnBack.Visibility = Visibility.Visible;
        }
    }
}
