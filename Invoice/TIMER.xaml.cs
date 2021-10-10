using System;
using System.Windows;
using System.Windows.Threading;

namespace Invoice
{
    /// <summary>
    /// Логика взаимодействия для TIMER.xaml
    /// </summary>
    public partial class TIMER : Window
    {
        DispatcherTimer timer1 = new DispatcherTimer();
        public TIMER()
        {
            InitializeComponent();
           
            timer1.Tick += new EventHandler(timerTick);
            timer1.Interval = new TimeSpan(0, 0,2);
            timer1.Start();
            

        }

        private void timerTick(object sender, EventArgs e)
        {
           
            var MainWindow = new MainWindow(228); 
            MainWindow.Show(); 
            this.Close();
            timer1.Stop();


        }
    }
}
