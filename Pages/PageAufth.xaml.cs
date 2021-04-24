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
using System.Timers;

namespace CourseMM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAufth.xaml
    /// </summary>
    public partial class PageAufth : Page
    {
        Game_CenterEntities context;
        int tryCount = 0;
        Timer timer;
        public PageAufth()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            
        }

        private void btnAufth_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text != null && txtPass.Text != null)
            {
                    Aufthoriz();
                if(tryCount == 5)
                { 
                    btnAufth.IsEnabled = false;
                    timer = new Timer(5000);
                    timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
                    timer.Enabled = true;
                    timer.Start();
                    btnAufth.IsEnabled = true;
                }
            }
        }

        public void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            timer.Close();
            tryCount = 0;
           
        }

        private void Aufthoriz()
        {
            string login = txtLogin.Text;
            string password = txtPass.Text;

            Position position = context.Position.FirstOrDefault(
                p => p.Login == login && p.Password == password);
            if (position != null)
            {
                //переход на след. страницк
            }
            else
            {
                tryCount++;
                MessageBox.Show("Неверный логин или пароль", "Ошибка входа!");
            }


        }
    }
}
