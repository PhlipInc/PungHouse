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

namespace PungHouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string FormattedDated;
        public enum MenuState
        {
            EmployeeMenuActive,
            ScheduleMenuActive,
            CustomerMenuActive,
        };
        DateTime saveNow = DateTime.Now;
        Brush Active = new BrushConverter().ConvertFromString("#FF4CD137") as SolidColorBrush;
        Brush inActive = new BrushConverter().ConvertFromString("#FFE1B12C") as SolidColorBrush;
        MenuState menuState = MenuState.EmployeeMenuActive;
        Profile profileWindow = new Profile();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void MiniButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void EmployeeMenuCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            EmployeeMenuCanvas.Cursor = Cursors.Hand;
            FindSelectedMenu();
        }

        private void ScheduleMenuCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            ScheduleMenuCanvas.Cursor = Cursors.Hand;
            FindSelectedMenu();
        }

        private void CustomerMenuCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            CustomerMenuCanvas.Cursor = Cursors.Hand;
            FindSelectedMenu();
        }

        private void FindSelectedMenu()
        {
            switch (menuState)
            {
                case MenuState.EmployeeMenuActive:
                    EmployeeMenuCanvas.Cursor = Cursors.Arrow;
                    break;
                case MenuState.ScheduleMenuActive:
                    ScheduleMenuCanvas.Cursor = Cursors.Arrow;
                    break;
                case MenuState.CustomerMenuActive:
                    CustomerMenuCanvas.Cursor = Cursors.Arrow;
                    break;
                default:
                    this.Cursor = Cursors.Hand;
                    break;
            }
        }

        private void EmployeeMenuCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            menuState = MenuState.EmployeeMenuActive;
            switch (menuState)
            {
                case MenuState.EmployeeMenuActive:
                    EmployeePage.Visibility = Visibility.Visible;
                    EmployeeLink.BorderBrush = Active;
                    ScheduleLink.BorderBrush = inActive;
                    CustomerLink.BorderBrush = inActive;
                    SchedulePage.Visibility = Visibility.Collapsed;
                    CustomerPage.Visibility = Visibility.Collapsed;
                    break;
                case MenuState.ScheduleMenuActive:
                    SchedulePage.Visibility = Visibility.Collapsed;
                    break;
                case MenuState.CustomerMenuActive:
                    CustomerPage.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        private void ScheduleMenuCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuState = MenuState.ScheduleMenuActive;
            switch (menuState)
            {
                case MenuState.EmployeeMenuActive:
                    //Nothing Should happen
                    break;
                case MenuState.ScheduleMenuActive:
                    SetSchedulePageComponents();
                    break;
                case MenuState.CustomerMenuActive:
                    //nothing should happen
                    break;
                default:
                    break;
            }
        }

        private void SetSchedulePageComponents()
        {
            SchedulePage.Visibility = Visibility.Visible;
            ScheduleLink.BorderBrush = Active;
            CustomerLink.BorderBrush = inActive;
            EmployeeLink.BorderBrush = inActive;
            CustomerPage.Visibility = Visibility.Collapsed;
            EmployeePage.Visibility = Visibility.Collapsed;
            Schedule_ClockInLabel.Content = saveNow.ToString("dddd, MMMM dd, yyyy");
        }

        private void CustomerMenuCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuState = MenuState.CustomerMenuActive;
            switch (menuState)
            {
                case MenuState.EmployeeMenuActive:
                    EmployeePage.Visibility = Visibility.Collapsed;
                    break;
                case MenuState.ScheduleMenuActive:
                    SchedulePage.Visibility = Visibility.Collapsed;
                    break;
                case MenuState.CustomerMenuActive:
                    CustomerPage.Visibility = Visibility.Visible;
                    CustomerLink.BorderBrush = Active;
                    EmployeeLink.BorderBrush = inActive;
                    ScheduleLink.BorderBrush = inActive;
                    EmployeePage.Visibility = Visibility.Collapsed;
                    SchedulePage.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            profileWindow = new Profile();
            profileWindow.ShowDialog();
        }

        private void ControlBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TitleLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void IconImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Schedule_Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            FormattedDated = DateTime.Parse(Schedule_Calendar.SelectedDate.ToString()).ToString("dddd, MMMM dd, yyyy");
            Schedule_ClockInLabel.Content = FormattedDated;
        }

        private void Schedule_Calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Test");
        }
    }
}
