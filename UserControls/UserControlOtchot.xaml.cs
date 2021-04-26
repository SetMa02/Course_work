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
using Excel = Microsoft.Office.Interop.Excel;

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
            DataGridSales.ItemsSource = context.Sales.ToList();
            
        }

        private void brnExport_Click(object sender, RoutedEventArgs e)
        {
            var allSales = context.Sales.ToList().OrderBy(p => p.DateofSale).ToList();
            var application = new Excel.Application();
            application.SheetsInNewWorkbook = allSales.Count();

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            int startRowIndex = 1;
            for(int i = 0; i < allSales.Count(); i++)
            {
                Excel.Worksheet worksheet = application.Worksheets.Item[i + 1];
                worksheet.Name = allSales[i].Games.Name;
                worksheet.Cells[1][startRowIndex] = "Название игры";
                worksheet.Cells[2][startRowIndex] = "Дата продажы";
                worksheet.Cells[3][startRowIndex] = "Количество";
                worksheet.Cells[4][startRowIndex] = "Сумма";

                startRowIndex++;

                foreach(var tov in context.Sales)
                {
                    //worksheet.Cells[1][startRowIndex] = 
                }
            }
            application.Visible = true;
        }
    }
}
