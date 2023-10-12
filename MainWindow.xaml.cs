using Microsoft.EntityFrameworkCore;
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

namespace Brighteye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declaratie  db context
        private NumberContext dbContext;

        public MainWindow()
        {
            InitializeComponent();
            // Initialiseren  dbcontext
            dbContext = new NumberContext();
        }

        private void btnFillTable1_Click(object sender, RoutedEventArgs e)
        {
            // Generate random nummers van 1 tot 10
            var randomNumbers = Enumerable.Range(1, 10).OrderBy(_ => Guid.NewGuid()).ToList();

            // nummers opslaan
            dbContext.Number.AddRange(randomNumbers.Select(n => new NumberEntity { Number = n }));
            dbContext.SaveChanges();
        }

        private void btnSortTable2_Click(object sender, RoutedEventArgs e)
        {
            // Gesorteede data opvragen van tabel 1
            var sortedNumbers = dbContext.Number.OrderBy(n => n.Number).ToList();

            // Data vullen in table 2
            dgTable2.ItemsSource = sortedNumbers;
        }
    }
}
