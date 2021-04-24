using CourseMM.ViewModel;
using MaterialDesignThemes.Wpf;
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

namespace CourseMM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();

            var menuTables = new List<SubItem>();
            menuTables.Add(new SubItem("Товар на складе"));
            menuTables.Add(new SubItem("+ добавить товар"));
            menuTables.Add(new SubItem("Дополнительно"));
            var item0 = new ItemMenu("Товары", menuTables, PackIconKind.Table);

            var menuEmployee = new List<SubItem>();
            menuEmployee.Add(new SubItem("Список сотрудников"));
            menuEmployee.Add(new SubItem(" + добавить сотрудника"));
            menuEmployee.Add(new SubItem("Дополнительно"));
            var item1 = new ItemMenu("Сотрудники", menuEmployee, PackIconKind.CustomerService);

            var menuOtchot = new List<SubItem>();
            menuOtchot.Add(new SubItem("Отчет по продажам за месяц"));
            menuOtchot.Add(new SubItem("Отчет по продажам сегодня"));
            var item2 = new ItemMenu("Отчеты", menuOtchot, PackIconKind.FileDocument);

            var item3 = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(item0));   
            Menu.Children.Add(new UserControlMenuItem(item1));   
            Menu.Children.Add(new UserControlMenuItem(item2));   
            Menu.Children.Add(new UserControlMenuItem(item3));

        }
    }
}
