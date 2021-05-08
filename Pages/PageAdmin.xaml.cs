using CourseMM.UserControls;
using CourseMM.ViewModel;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CourseMM.Pages
{
    public partial class PageAdmin : Page
    {
        Game_CenterEntities context;
        public PageAdmin()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            var menuTables = new List<SubItem>();
            menuTables.Add(new SubItem("Товар на складе", new UserControlDashboard()));
            menuTables.Add(new SubItem("+ добавить товар", new UserControlGameCreate(context)));
            menuTables.Add(new SubItem("Дополнительно", new UserControlGameProperties()));
            var item0 = new ItemMenu("Товары", menuTables, PackIconKind.Table);
            var menuEmployee = new List<SubItem>();
            menuEmployee.Add(new SubItem("Список сотрудников", new UserControlEmployee()));
            menuEmployee.Add(new SubItem(" + добавить сотрудника", new UserControlCreateEmployee()));
            var item1 = new ItemMenu("Сотрудники", menuEmployee, PackIconKind.CustomerService);
            var menuOtchot = new List<SubItem>();
            menuOtchot.Add(new SubItem("Отчет по продажам за месяц", new UserControlOtchot()));
            var item2 = new ItemMenu("Отчеты", menuOtchot, PackIconKind.FileDocument);
            Menu.Children.Add(new UserControlMenuItem(item0, this));   
            Menu.Children.Add(new UserControlMenuItem(item1, this));   
            Menu.Children.Add(new UserControlMenuItem(item2, this));   
        }
        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if(screen!=null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
    }
}
