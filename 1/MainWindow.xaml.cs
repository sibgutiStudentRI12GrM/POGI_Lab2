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

namespace lab2_1 {
    
    
    public partial class MainWindow : Window {
        
        public MainWindow() {
            InitializeComponent();
        }

        private void calcBtnPlus_Click(object sender, RoutedEventArgs e) {
            resultTB.Text = Convert.ToString(float.Parse(firstOperandTB.Text) + float.Parse(secondOperandTB.Text));
        }

        private void calcBtnMinus_Click(object sender, RoutedEventArgs e) {
            resultTB.Text = Convert.ToString(float.Parse(firstOperandTB.Text) - float.Parse(secondOperandTB.Text));
        }

        private void calcBtnMultiply_Click(object sender, RoutedEventArgs e) {
            resultTB.Text = Convert.ToString(float.Parse(firstOperandTB.Text) * float.Parse(secondOperandTB.Text));
        }

        private void calcBtnDivide_Click(object sender, RoutedEventArgs e) {
            resultTB.Text = Convert.ToString(float.Parse(firstOperandTB.Text) / float.Parse(secondOperandTB.Text));
        }
    }
}
