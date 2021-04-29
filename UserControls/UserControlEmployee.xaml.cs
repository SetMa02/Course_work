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
    /// Логика взаимодействия для UserControlEmployee.xaml
    /// </summary>
    public partial class UserControlEmployee : UserControl
    {
        Game_CenterEntities context;
        public UserControlEmployee()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            DataGridEmployee.ItemsSource = context.EmployeeInfo.ToList();
        }

        private void DataGridEmployee_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGridEmployee.ItemsSource = context.EmployeeInfo.ToList();
        }
        
    }
}
