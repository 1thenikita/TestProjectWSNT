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
    /// Логика взаимодействия для PagePurchase.xaml
    /// </summary>
    public partial class PagePurchase : Page
    {
        private Purchase _purchase;

        /// <summary>
        /// Инициализация конструктора для создания покупки.
        /// </summary>
        public PagePurchase()
        {
            InitializeComponent();
            cbCategory.ItemsSource = Global.DB.Categories.ToList();
            Title = "Создание покупки";
            _purchase = new Purchase();
            DataContext = _purchase;
        }

        /// <summary>
        /// Инициализация конструктора для изменения покупки.
        /// </summary>
        /// <param name="purchase">Покупка</param>
        public PagePurchase(Purchase purchase)
        {
            InitializeComponent();
            cbCategory.ItemsSource = Global.DB.Categories.ToList();
            Title = "Изменение покупки";
            _purchase = purchase;
            DataContext = _purchase;
            btnDelete.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Обработчик добавления/изменения покупки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (String.IsNullOrWhiteSpace(_purchase.Name))
                errors.AppendLine("Укажите назначение платежа");
            if (_purchase.Count == null || _purchase.Count == 0)
                errors.AppendLine("Количество может быть только числом.");
            if (_purchase.Price == null || _purchase.Price == 0)
                errors.AppendLine("Стоимость может быть только числом.");

            if(errors.Length != 0)
            {
                MessageBox.Show($@"Устраните ошибки в заполнении:\n\n{errors}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(_purchase.ID == 0)
            {
                Title = "Изменение покупки";
                Global.DB.Purchases.Add(_purchase);
            }
            Global.DB.SaveChanges();
        }

        /// <summary>
        /// Обработчик закрытия окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Global.FrameMain.GoBack();
        }

        /// <summary>
        /// Обработчик удаления покупки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить покупку?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            Global.DB.Purchases.Remove(_purchase);
            Global.DB.SaveChanges();
            _purchase.ID = 0;
            btnDelete.Visibility = Visibility.Collapsed;
        }
    }
}
