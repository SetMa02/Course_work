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
    /// Логика взаимодействия для UserControlOtchot.xaml
    /// </summary>
    public partial class UserControlOtchot : UserControl
    {

        Game_CenterEntities context;
        public UserControlOtchot()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            DataGridSales.ItemsSource = context.Sales;
            
        }
    }
}
