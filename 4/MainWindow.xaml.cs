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

namespace lab2_4 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        
        public void setDates(int year, int month) {
            int daysIntmonth = DateTime.DaysInMonth(year, month);
            datesComboBox.Items.Clear();
            for (int day = 1; day<=daysIntmonth; day++) {
                datesComboBox.Items.Add(Convert.ToString(day));
            }
        }

        public void showDateDeltaMessageBox (int oldYear, int oldMonth, int oldDays) {
            try {
                DateTime zeroTime = new DateTime(1, 1, 1);

                DateTime oldTime = new DateTime(oldYear, oldMonth, oldDays);
                DateTime currentTime = DateTime.Now.ToLocalTime();

                TimeSpan tspan = currentTime - oldTime;

                int deltaYears = (zeroTime + tspan).Year - 1;
                int deltaMonths = (zeroTime + tspan).Month - 1;
                int deltaDays = (zeroTime + tspan).Day - 1;

                

                string deltaMessage = "Years: " + Convert.ToString(deltaYears) + "| ";
                
                
                deltaMessage += "Months: " + Convert.ToString(deltaMonths) + "| ";
                
                deltaMessage += "Days: " + deltaDays;
                deltaMessage += " is passed.";

                MessageBox.Show(deltaMessage);
            } catch (ArgumentOutOfRangeException){
                MessageBox.Show("Selected date in future!");
            }
        }


        
        public MainWindow() {
            InitializeComponent();
            

            // generating years

            int startYear = 1900;
            int endYear = DateTime.Now.Year; // current year
            for (int year = endYear; year >= startYear; year--) {
                yearsComboBox.Items.Add(Convert.ToString(year));
            }

            // adding months
            List<string> months = new List<string>() {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December",
            };

            foreach(string month in months) {
                monthsComboBox.Items.Add(month);
            }

            datesComboBox.IsEnabled = false;


        }

        private void yearsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if ( (monthsComboBox.SelectedIndex != -1) && (datesComboBox.IsEnabled == false) ) {
                datesComboBox.IsEnabled = true;
                setDates(Int32.Parse((string)yearsComboBox.SelectedItem), monthsComboBox.SelectedIndex+1);
            } else if (monthsComboBox.SelectedIndex != -1) {
                // only when both year and month CB selected generate month days
                setDates(Int32.Parse((string)yearsComboBox.SelectedItem), monthsComboBox.SelectedIndex + 1);
            }
            
        }

        private void monthsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if ( (yearsComboBox.SelectedIndex != -1) && (datesComboBox.IsEnabled == false) ) {
                datesComboBox.IsEnabled = true;
                setDates(Int32.Parse((string)yearsComboBox.SelectedItem), monthsComboBox.SelectedIndex + 1);
            } else if (yearsComboBox.SelectedIndex != -1) {
                // only when both year and month CB selected generate month days
                setDates(Int32.Parse((string)yearsComboBox.SelectedItem), monthsComboBox.SelectedIndex + 1);
            }

        }

        private void datesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (datesComboBox.SelectedIndex != -1) {
                showDateDeltaMessageBox(Int32.Parse((string)yearsComboBox.SelectedItem), monthsComboBox.SelectedIndex + 1, Int32.Parse((string)datesComboBox.SelectedItem));
            }
        }
    }
}
