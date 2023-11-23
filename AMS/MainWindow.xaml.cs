using AMS.LecturerViews;
using AMS.MVVM.Model;
using AMS.StudentVIews;
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

namespace AMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Username = UsernameTbx.Text;
            string Password = PasswordPsb.Password;

            LogInLogic logInLogic = new LogInLogic();
            var RegistratingUser = logInLogic.LogValidation(Username, Password);

            if (RegistratingUser.getUserlevel() == "admin")
            {
                AdminView adminView = new AdminView();
                adminView.Show();
                this.Close();
            } 
            else if (RegistratingUser.getUserlevel() == "lecturer")
            {
                //
            }
            else if (RegistratingUser.getUserlevel() == "student")
            {
                //
            }
            else
            {
                MessageBox.Show("Something Went Wrong...");
                StudentViewButtonShotcut.Visibility = Visibility.Visible;
                LecturerViewButtonShotcut.Visibility= Visibility.Visible;
                AdminViewButtonShotcut.Visibility = Visibility.Visible;
                ShortcutsLabel.Visibility = Visibility.Visible;
            }
        }

        private void sClick(object sender, RoutedEventArgs e)
        {
            StudentView studentView = new StudentView();
            studentView.Show();
            this.Close();
        }
        private void lClick(object sender, RoutedEventArgs e)
        {
            LecturerView lecturer = new LecturerView();
            lecturer.Show();
            this.Close();
        }
        private void aClick(object sender, RoutedEventArgs e)
        {
            AdminView adminView = new AdminView();
            adminView.Show();
            this.Close();
        }
    }
}
