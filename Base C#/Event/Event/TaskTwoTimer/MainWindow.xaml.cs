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

namespace TaskTwoTimer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer tim;


        public MainWindow()
        {
            InitializeComponent();
            InitialTimer();
        }

        private void Tim_Tick(object sender, EventArgs e)
        {
            ValueProgress.Text = ProgressField.Value.ToString();
            if (ProgressField.Value < 100) ProgressField.Value++;
        }

        public void InitialTimer()
        {
            tim = new DispatcherTimer();
            tim.Interval = new TimeSpan(1000000);
            tim.Tick += Tim_Tick;
            tim.Start();
            tim.IsEnabled = false;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            tim.IsEnabled = true;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            tim.IsEnabled = false;
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ProgressField.Value = 0;
        }
    }
}
