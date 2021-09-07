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
using System.Windows.Threading;

namespace lab2_5 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        class AppData {
            public static bool TimerIsRunning = false;
            public static bool IsFullTimeFormat = true;
            public static int TimerSeconds = 0;

            public static System.Windows.Threading.DispatcherTimer Timer;


            

        }

        // formats time to HH:MM:SS or S
        string FormatTime (int seconds, bool IsFullTimeFormat) {
            TimeSpan renderTimeSpan = TimeSpan.FromSeconds(seconds);
            string formatedTime = "";
            if (IsFullTimeFormat) {
                formatedTime += string.Format("{0:D2}:{1:D2}:{2:D2}",
                renderTimeSpan.Hours,
                renderTimeSpan.Minutes,
                renderTimeSpan.Seconds);
            } else {
                formatedTime = Convert.ToString(seconds) + " sec";
            }
            return formatedTime;
        }

        void UpdateTimer() {
            timerLabel.Content = FormatTime(AppData.TimerSeconds, AppData.IsFullTimeFormat);
        }

        
        public MainWindow() {
            InitializeComponent();
            
            

        }


        private void dispatcherTimer_Tick (object sender, EventArgs e) {
            AppData.TimerSeconds++;
            UpdateTimer();


        }

        
        private void startTimerBtn_Click(object sender, RoutedEventArgs e) {
            if (!AppData.TimerIsRunning) { // start only if not running
                System.Windows.Threading.DispatcherTimer Timer;
                AppData.Timer = new System.Windows.Threading.DispatcherTimer();
                AppData.Timer.Tick += new EventHandler(dispatcherTimer_Tick);



                AppData.Timer.Interval = new TimeSpan(0, 0, 1);
                AppData.Timer.Start();
                AppData.TimerIsRunning = true;


            }

        }

        private void keepTimerBtn_Click(object sender, RoutedEventArgs e) {
            string timeToKeep = "";
            timeToKeep += string.Format("Time {0}: ", timeStampsListBox.Items.Count+1);
            timeToKeep += FormatTime(AppData.TimerSeconds, AppData.IsFullTimeFormat);
            timeStampsListBox.Items.Add(timeToKeep);
        }

        private void isFulltimeCheckBox_Click(object sender, RoutedEventArgs e) {
            AppData.IsFullTimeFormat = !AppData.IsFullTimeFormat;
        }

        private void stopTimerBtn_Click(object sender, RoutedEventArgs e) {
            if (AppData.TimerIsRunning) {
                AppData.Timer.Stop();
                AppData.TimerSeconds = 0;
                UpdateTimer();
                
                AppData.TimerIsRunning = false;
            }
        }
    }
}
