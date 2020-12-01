using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PungHouse
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        string[] nigger = { "fdsfsad", "fdsaf", "fdsf", "fsdfasdf" };
        int test = 0;
        public Profile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DateTimeLabel_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateLabel.Content = dt.ToString("dddd, MMMM dd, yyyy");
            TimeLabel.Content = dt.ToString("hh:mm tt");
        }

        private void MainControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

        }
    }
}
