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
using System.IO;



namespace lab2_6 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void addLineBtn_Click(object sender, RoutedEventArgs e) {
            linesListBox.Items.Add(newLineTextBox.Text);
            newLineTextBox.Text = "";
        }

        private void removeLineBtn_Click(object sender, RoutedEventArgs e) {
            if (linesListBox.SelectedIndex != -1) {
                int previosIndex = linesListBox.SelectedIndex;
                linesListBox.Items.Remove(linesListBox.SelectedItem);
                linesListBox.SelectedIndex = previosIndex;
            }
        }

        private void menuItemSave_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.FileName = "Document";
            sfd.DefaultExt = ".txt";
            sfd.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = sfd.ShowDialog();
            if (result == true) {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8)) {
                    foreach(string line in linesListBox.Items) {
                        sw.WriteLine(line);
                    }
                }
            }

            



        }

        private void menuItemOpen_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.FileName = "Document";
            ofd.DefaultExt = ".txt";
            ofd.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = ofd.ShowDialog();
            if (result == true) {
                string line;
                StreamReader sr = new StreamReader(ofd.FileName);
                linesListBox.Items.Clear();
                while ((line = sr.ReadLine()) != null) {
                    linesListBox.Items.Add(line);
                }
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            linesListBox.Items.Clear();

            // cleans memory from keeped garbage
            System.GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
