
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace CourseMM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAufth.xaml
    /// </summary>
    public partial class PageAufth : Page
    {
        Game_CenterEntities context;
        int tryCount = 0;
        //Timer timer;
        public PageAufth()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            
        }

        private void btnAufth_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text != null && txtPass.ToString() != null)
            {
                    Aufthoriz();
                if(tryCount == 5)
                {   
                    btnAufth.IsEnabled = false;
                    MessageBox.Show("Кнопка заблокирована на 5 секунд!");
                    Thread.Sleep(5000);
                    
                    tryCount = 0;
                    btnAufth.IsEnabled = true;
                }
            }
        }

        private void Aufthoriz()
        {
            string login = txtLogin.Text;
            string password = txtPass.Password.ToString();
            Position position = context.Position.FirstOrDefault(
                p => p.Login == login && p.Password == password);
            if (position != null)
            {
                switch(position.IdPosition)
                {
                    case 1:
                        FrameManager.MainFrame.Navigate(new PageAdmin());
                        break;
                }
            }
            else
            {
                tryCount++;
                MessageBox.Show("Неверный логин или пароль", "Ошибка входа!");
            }
        }
    }
  
}
