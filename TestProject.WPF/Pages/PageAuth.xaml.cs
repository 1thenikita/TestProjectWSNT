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
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (cbUsers.SelectedItem == null ||
                String.IsNullOrWhiteSpace(pbPassword.Password)) return;

            string password = pbPassword.Password;

            Global.FrameMain.Navigate(new PagePurchases());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
