using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseMM.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControlOtchot.xaml
    /// </summary>
    /// 
    public class Res
    {
        public string Name { get; set; }
        public int Qty { get; set; }
    }

    public partial class UserControlOtchot : UserControl
    {

        Game_CenterEntities context;
        List<Sales> salesFound;
        
        List<(string Name, int Qty)> res;
        bool StopDoSelectedDateChanged = false;

        public UserControlOtchot()
        {
            InitializeComponent();
            context = new Game_CenterEntities();

            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            StopDoSelectedDateChanged = true;
            dateFirst.SelectedDate = startDate;
            dateSecond.SelectedDate = endDate;
            StopDoSelectedDateChanged = false;

           FormOtchot();


        }

        void FormOtchot()
        {
            if(dateFirst.SelectedDate != null && dateSecond.SelectedDate != null )
            {
                brnExport.IsEnabled = true;
                txtName.IsEnabled = true;
                salesFound = context.Sales.ToList();
                salesFound = salesFound.Where(a => a.DateofSale >= dateFirst.SelectedDate && a.DateofSale <= dateSecond.SelectedDate).ToList();
                if(txtName.Text != null)
                {
                    String Name = txtName.Text;
                    salesFound = salesFound.Where(a => a.Games.Name.ToLower().Contains(Name.ToLower())).ToList();
                }
                DataGridSales.Items.Clear();


                res = salesFound.GroupBy(x => x.Games.Name).Select(g => (Name: g.Key, Qty: (int)(g.Sum(k => k.Qty) ?? 0))).ToList();
                res = res.OrderBy(z => z.Qty).ToList();

                foreach (var item in res)
                {
                    Res newRow = new Res();
                    newRow.Name = item.Name;
                    newRow.Qty = item.Qty;
                    DataGridSales.Items.Add(newRow);
                }

            }

        }



        private void brnExport_Click(object sender, RoutedEventArgs e)
        {
            CreateOtchot();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            FormOtchot();
        }

        private void dateFirst_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(StopDoSelectedDateChanged == false)
                FormOtchot();
        }

        public void CreateOtchot()
        {
            if (res == null)
                return;

            int startRowIndex = 1;
            res = res.OrderBy(x => x.Qty).ToList();
            var application  = new  Microsoft.Office.Interop.Excel.Application();
            application.SheetsInNewWorkbook = 1;
            Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = application.Worksheets.Item[1];
            worksheet.Name = "Отчет";

            worksheet.Cells[1][startRowIndex] = "Наименование игры";
            worksheet.Cells[2][startRowIndex] = "Количество продаж";

            Microsoft.Office.Interop.Excel.Range ColHeaders = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[2][startRowIndex]];
            ColHeaders.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            ColHeaders.Font.Bold = true;
            ColHeaders.Font.Size = 15;
            ColHeaders.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            ColHeaders.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle =
            ColHeaders.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            ColHeaders.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            ColHeaders.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            ColHeaders.Interior.Color = XlRgbColor.rgbWheat;

            startRowIndex++;
            MessageBox.Show("Формирование отчета");
            bool AlternateRow = false;
            foreach (var Item in res)
            {
                Microsoft.Office.Interop.Excel.Range SelectedRow = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[2][startRowIndex]];

                SelectedRow.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
                SelectedRow.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle =
                SelectedRow.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                worksheet.Cells[1][startRowIndex] = Item.Name;
                worksheet.Cells[2][startRowIndex] = Item.Qty;
                startRowIndex++;
                if (AlternateRow) { AlternateRow = false; SelectedRow.Interior.Color = XlRgbColor.rgbAliceBlue; }
                else { AlternateRow = true; SelectedRow.Interior.Color = XlRgbColor.rgbWhite; }
            }

            string MinItems = "";
            int MinAmount = res.First().Qty;
            List<(string Name, int Qty)> MinItemsResult;
            MinItemsResult = res.Where(x => x.Qty == MinAmount).ToList();
            if (MinItemsResult.Count == 1) MinItems = MinItems + MinItemsResult.First().Name + " - " + MinItemsResult.First().Qty + "Шт";
            else
            {
                foreach (var item in MinItemsResult)
                {
                    if (item == MinItemsResult.Last())
                        MinItems = MinItems + item.Name + " - " + item.Qty + "Шт";
                    else
                        MinItems = MinItems + item.Name + " - " + item.Qty + "Шт\n";
                }
            }

            string MaxItems = "";
            int MaxAmount = res.Last().Qty;
            List<(string Name, int Qty)> MaxItemsResult;
            MaxItemsResult = res.Where(x => x.Qty == MaxAmount).ToList();
            if (MaxItemsResult.Count == 1) MaxItems = MaxItems + MaxItemsResult.First().Name + " - " + MaxItemsResult.First().Qty + "Шт";
            else
            {
                foreach (var item in MaxItemsResult)
                {
                    if (item == MaxItemsResult.Last())
                        MaxItems = MaxItems + item.Name + " - " + item.Qty + "Шт";
                    else
                        MaxItems = MaxItems + item.Name + " - " + item.Qty + "Шт\n";
                }
            }

            worksheet.Cells[1][startRowIndex] = "Самые продаваемые товары:";
            worksheet.Cells[1][startRowIndex].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
            worksheet.Cells[2][startRowIndex] = MaxItems;
            worksheet.Cells[2][startRowIndex].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

            startRowIndex++;
            worksheet.Cells[1][startRowIndex] = "Самые плохо продаваемые товары:";
            worksheet.Cells[1][startRowIndex].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
            worksheet.Cells[2][startRowIndex] = MinItems;
            worksheet.Cells[2][startRowIndex].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;


            Microsoft.Office.Interop.Excel.Range EndingOfTable = worksheet.Range[worksheet.Cells[1][startRowIndex - 1], worksheet.Cells[2][startRowIndex]];
            EndingOfTable.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            EndingOfTable.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle =
            EndingOfTable.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            EndingOfTable.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            EndingOfTable.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            EndingOfTable.Interior.Color = XlRgbColor.rgbWheat;
            worksheet.Columns.AutoFit();
            worksheet.Rows.AutoFit();
            application.Visible = true;
        }

    }
    
}
