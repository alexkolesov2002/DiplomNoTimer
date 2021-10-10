using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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

namespace Invoice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string FilePath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
        OpenFileDialog();
          MailAddress mailAddress = new MailAddress("prof-probi-prog@ngknn.ru", "Тема");
            MailAddress toAdress = new MailAddress("alladin.kolesov@mail.ru", "Try");
            MailMessage message = new MailMessage(mailAddress, toAdress);
            message.Body = "Контрольный";
            message.Subject = "Контрольный";
            message.Attachments.Add(new Attachment(FilePath));
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.mail.ru";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(mailAddress.Address, "GBHJU6032w");
            smtpClient.SendMailAsync(message);
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {  
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Diplom");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
          
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Diplom");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }
    }
    }

