using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        /// <summary>
        /// Инициализация конструктора.
        /// </summary>
        public PageAuth()
        {
            InitializeComponent();
            cbUsers.ItemsSource = Global.DB.Users.ToList();
        }

        /// <summary>
        /// Обработчик прохождения аутентификации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (cbUsers.SelectedItem == null ||
                String.IsNullOrWhiteSpace(pbPassword.Password)) return;

            string password = pbPassword.Password;
            var user = cbUsers.SelectedItem as User;
            if(user.PasswordHash != GetSHA256FromString(password) && user.PinCode != password)
            {
                MessageBox.Show("Проверьте ввод данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Global.FrameMain.Navigate(new PagePurchases());
        }

        /// <summary>
        /// Обработчик выхода из приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private string GetSHA256FromString(string import) 
        {
            return BitConverter.ToString(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(import))).Replace("-", "").ToUpper();
        }
    }
}
