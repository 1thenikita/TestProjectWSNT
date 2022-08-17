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
    /// Логика взаимодействия для PageReport.xaml
    /// </summary>
    public partial class PageReport : Page
    {
        List<Purchase> _purchases;
        public PageReport()
        {
            InitializeComponent();
            Title = "Список платежей";
        }

        private void GeneratePage()
        {
            var total = 0.0;
            foreach(var category in Global.DB.Categories.ToList())
            {
                var sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                Label labelCategory = new Label();
                labelCategory.FontSize = 18;
                labelCategory.Content = category.Name;
                sp.Children.Add(labelCategory);
                foreach(var purhase in category.Purchases)
                {
                    var spPurchase = new StackPanel();
                    spPurchase.Orientation = Orientation.Horizontal;
                    Label labelPurchase = new Label();
                    labelPurchase.Content = purhase.Name;
                    var labelTotal = new Label();
                    labelTotal.Content = purhase.Total + " р.";
                    spPurchase.Children.Add(labelPurchase);
                    spPurchase.Children.Add(labelTotal);
                    sp.Children.Add(spPurchase);
                    total += purhase.Total;
                }
                this.spMain.Children.Add(sp);
            }

            var spTotal = new StackPanel();
            spTotal.Orientation = Orientation.Horizontal;
            var labelTotalText = new Label();
            labelTotalText.Content = "ИТОГО: ";

            var labelTotalPrice = new Label();
            labelTotalPrice.Content = total + " р.";

            spTotal.Children.Add(labelTotalText);
            spTotal.Children.Add(labelTotalPrice);
            spMain.Children.Add(spTotal);
        }
    }
}
