﻿using CourseMM.Windows;
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

namespace CourseMM
{
    /// <summary>
    /// Логика взаимодействия для UserControlDashboard.xaml
    /// </summary>
    public partial class UserControlDashboard : UserControl
    {
        Game_CenterEntities context;
        public UserControlDashboard()
        {
            InitializeComponent();
            context = new Game_CenterEntities();
            DataGridGames.ItemsSource = context.GameInfo.ToList();
            cmbGenre.ItemsSource = context.Genre.ToList();
            cmbPlatform.ItemsSource = context.Platform.ToList();
        }

     

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string findText = txtName.Text;
            List<GameInfo> gameInfo = context.GameInfo.ToList();
            gameInfo = gameInfo.Where(x => x.Games.Name.ToLower().Contains(findText.ToLower())).ToList();
            DataGridGames.ItemsSource = gameInfo.ToList();
        }

        private void cmbGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbGenre == null)
                return;

            var currentGenre = (Genre)cmbGenre.SelectedItem;
            List<GameInfo> gameInfos = context.GameInfo.ToList();
            gameInfos = gameInfos.Where(a => a.Genre == currentGenre).ToList();
            DataGridGames.ItemsSource = gameInfos.ToList();
        }

        private void cmbPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPlatform == null)
                return;

            var currentPlatform = (Platform)cmbPlatform.SelectedItem;
            List<GameInfo> gameInfos1 = context.GameInfo.ToList();
            gameInfos1 = gameInfos1.Where(a => a.Platform == currentPlatform).ToList();
            DataGridGames.ItemsSource = gameInfos1.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Button btnEdit = (Button)sender;
            var newGame = (GameInfo)btnAdd.DataContext;
            WindowGameEdit windowGameEdit = new WindowGameEdit(context, newGame);
            windowGameEdit.Show();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            cmbPlatform.Text = "";
            cmbGenre.Text = "";
            DataGridGames.ItemsSource = context.GameInfo.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var row = (GameInfo)DataGridGames.SelectedItem;
            var row1 = context.Games.Where(x => x.IdGame == row.idGame);
            if(row == null)
            {
                MessageBox.Show("Вебырите строуц на удаления");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить эту строку?", "Delete", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.GameInfo.Remove(row);
                    
                    context.SaveChanges();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка удаления " + ex.ToString());
                }
            }
        }
    }
}
