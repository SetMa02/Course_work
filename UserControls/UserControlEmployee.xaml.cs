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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var row = (EmployeeInfo)DataGridEmployee.SelectedItem;
            var row1 = context.Employee.Where(x => x.IdEmployee == row.IdEmployee);
            if (row == null)
            {
                MessageBox.Show("Вебырите строуц на удаления");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить эту строку?", "Delete", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.EmployeeInfo.Remove(row);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления " + ex.ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowEmployeeCreate windowEmployeeCreate = new WindowEmployeeCreate(context);
            windowEmployeeCreate.Show();
        }
    }
}
