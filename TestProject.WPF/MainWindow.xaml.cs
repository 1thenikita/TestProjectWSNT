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
using TestProject.WPF.Pages;

namespace TestProject.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализация конструктора.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Global.FrameMain = frmMain;
            try
            {
                Global.DB = new Entities.DBEntities();
            }
            catch(Exception e)
            {
                MessageBox.Show($@"Работа программы невозможна!\nПроверьте подключение к БД!\n{e.Message}", "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
            Global.FrameMain.Navigate(new PageAuth());
        }

        /// <summary>
        /// Обработчик перехода на страницу назад.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Global.FrameMain.GoBack();
        }

        /// <summary>
        /// Обработчик рендеринга страницы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_ContentRendered(object sender, EventArgs e)
        {
            var page = (sender as Frame).Content as Page;
            if (page == null) return;

            this.Title = page.Title;
            btnBack.Visibility = Global.FrameMain.CanGoBack ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
