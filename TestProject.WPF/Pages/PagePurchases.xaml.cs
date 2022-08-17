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
using TestProject.WPF.Classes;
using TestProject.WPF.Entities;

namespace TestProject.WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePurchases.xaml
    /// </summary>
    public partial class PagePurchases : Page
    {
        /// <summary>
        /// Инициализация конструктора.
        /// </summary>
        public PagePurchases()
        {
            InitializeComponent();
            UpdateDatas();
            cbCategory.ItemsSource = Global.DB.Categories.ToList();
            dpStart.DisplayDateEnd = dpEnd.DisplayDateEnd = dpStart.SelectedDate = dpEnd.SelectedDate = DateTime.Now;
        }

        /// <summary>
        /// Обработчик добавления новой покупки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Global.FrameMain.Navigate(new PagePurchase());
            UpdateDatas();
        }

        /// <summary>
        /// Обработчик удаления покупки/ок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var purchases = dgPurchases.SelectedItems.Cast<Purchase>().ToList();
            if (purchases.Count == 0) return;

            MessageBoxResult result = MessageBox.Show($"Вы точно хотите удалить {purchases.Count} покупок?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            Global.DB.Purchases.RemoveRange(purchases);
            Global.DB.SaveChanges();

            UpdateDatas();
        }

        /// <summary>
        /// Обработчик включения сортировки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var dateStart = dpStart.SelectedDate.Value;
            var dateEnd = dpEnd.SelectedDate.Value;
            var category = cbCategory.SelectedItem as Category;

            var purhcases = Global.DB.Purchases.ToList();
            purhcases = purhcases.Where(p => p.Date.Date >= dateEnd.Date && p.Date.Date <= dateStart.Date).ToList();
            if (category != null) purhcases = purhcases.Where(p => p.Category.ID == category.ID).ToList();

            dgPurchases.ItemsSource = purhcases;
        }

        /// <summary>
        /// Обработчик очистки сортировки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            UpdateDatas();
        }

        /// <summary>
        /// Обработчик генерации отчёта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            var purchases = dgPurchases.SelectedItems.Cast<Purchase>().ToList();
            if (purchases.Count == 0) return;
            Global.FrameMain.Navigate(new PageReport());
        }

        /// <summary>
        /// Обработчик обновления данных.
        /// </summary>
        private void UpdateDatas()
        {
            Global.DB.ChangeTracker.Entries().ToList().ForEach(r => r.Reload());
            dgPurchases.ItemsSource = Global.DB.Purchases.ToList();
        }
    }
}
