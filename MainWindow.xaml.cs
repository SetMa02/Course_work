using CourseMM.Pages;
using System;
using System.Windows;

namespace CourseMM
{
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
