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
    /// Логика взаимодействия для UserControlCreateEmployee.xaml
    /// </summary>
    public partial class UserControlCreateEmployee : UserControl
    {
    
        Game_CenterEntities context;
        public UserControlCreateEmployee()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            cmbPositions.ItemsSource = context.Position.ToList();
            cmbGender.ItemsSource = context.Gender.ToList();
        }

    

        private void btnSave_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
            var newEmp = new Employee();
            var newEmpInfo = new EmployeeInfo();
            context.Employee.Add(newEmp);
            context.EmployeeInfo.Add(newEmpInfo);
            newEmp.FName = txtFName.Text;
            newEmp.FName = txtFName.Text;
            newEmp.Panronymic = txtPName.Text;
            newEmp.Position = (Position)cmbPositions.SelectedItem;
            newEmpInfo.BirthDate = BirthDate.SelectedDate;
            newEmpInfo.Gender = (Gender)cmbGender.SelectedItem;
            newEmpInfo.Phone = Convert.ToInt32(txtPhone.Text);
            newEmpInfo.INN = Convert.ToInt32(txtINN.Text);
            newEmpInfo.DateOfStart = StarthDate.SelectedDate;
          
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка сохранения!: " + ex.ToString());
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtFName.Text = "";
            txtINN.Text = "";
            txtLName.Text = "";
            txtPhone.Text = "";
            BirthDate.SelectedDate = null;
            cmbGender.SelectedItem = null;
            cmbPositions.SelectedItem = null;
            StarthDate.SelectedDate = null;
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
