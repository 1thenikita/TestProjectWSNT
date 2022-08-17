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
        }

        /// <summary>
        /// Обработчик добавления новой покупки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            UpdateDatas();
        }

        /// <summary>
        /// Обработчик удаления покупки/ок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            UpdateDatas();
        }

        /// <summary>
        /// Обработчик включения сортировки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

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

        }

        /// <summary>
        /// Обработчик обновления данных.
        /// </summary>
        private void UpdateDatas()
        {

        }
    }
}
