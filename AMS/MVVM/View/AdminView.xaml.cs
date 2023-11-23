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
using System.Windows.Shapes;
using AMS.MVVM.Model;
using MySql.Data.MySqlClient;

namespace AMS
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        ADMIN_AlterStudents alterStudents = new ADMIN_AlterStudents();
        ADMIN_AlterLecturers alterLecturers = new ADMIN_AlterLecturers();

        public AdminView()
        {
            InitializeComponent();
            StudentDataGrid.ItemsSource = alterStudents.dt.DefaultView;
            Read_Students();
            LecturerDataGrid.ItemsSource = alterLecturers.dt.DefaultView;
            read_Lecturer();
        }

        //Students altering
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Create_Student();
            Read_Students();
        }
        private void Updatebutton_Click(object sender, RoutedEventArgs e)
        {
            Update_Student();
            Read_Students();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete_Student();
            Read_Students();
        }

        public void Read_Students()
        {
            StudentDataGrid.ItemsSource = null;
            alterStudents.ReadStudents();
            StudentDataGrid.ItemsSource = alterStudents.dt.DefaultView;
        }
        public void Create_Student() 
        { 
            alterStudents.firstname = FirstNameTbx.Text;
            alterStudents.lastname = LastNameTbx.Text;
            alterStudents.groupSD = GroupTbx.Text;
            alterStudents.AddStudent();
        }
        public void Update_Student()
        {
            alterStudents.firstname = FirstNameTbx.Text;
            alterStudents.lastname = LastNameTbx.Text;
            alterStudents.groupSD = GroupTbx.Text;
            alterStudents.username = UsernameTbx.Text;
            alterStudents.passwordSD = PasswordTbx.Text;
            alterStudents.id = IdTbx.Text;
            alterStudents.UpdateStudent();
        }
        public void Delete_Student()
        {
            alterStudents.id = IdTbx.Text;
            alterStudents.DeleteStudent();
        }

        //Lecturers altering

        private void LSaveButton_Click(object sender, RoutedEventArgs e)
        {
            create_Lecturer();
            read_Lecturer();
        }

        private void LUpdatebutton_Click(object sender, RoutedEventArgs e)
        {
            update_Lecturer();
            read_Lecturer();
        }

        private void LDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            delete_Lecturer();
            read_Lecturer();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public void read_Lecturer()
        {
            LecturerDataGrid.ItemsSource = null;
            alterLecturers.ReadLecturers();
            LecturerDataGrid.ItemsSource = alterLecturers.dt.DefaultView;
        }

        public void create_Lecturer()
        {
            alterLecturers.firstname = FirstNameTbx_Copy.Text;
            alterLecturers.lastname = LastNameTbx_Copy.Text;
            alterLecturers.subjectLD = SubjectTbx.Text;
            alterLecturers.AddLecturer();
        }

        public void update_Lecturer()
        {
            alterLecturers.firstname = FirstNameTbx_Copy.Text;
            alterLecturers.lastname = LastNameTbx_Copy.Text;
            alterLecturers.subjectLD = SubjectTbx.Text;
            alterLecturers.username = UsernameTbx_Copy.Text;
            alterLecturers.passwordLD = PasswordTbx_Copy.Text;
            alterLecturers.id = IdTbx_Copy.Text;
            alterLecturers.UpdateLecturer();
        }

        public void delete_Lecturer()
        {
            alterLecturers.id = IdTbx_Copy.Text;
            alterLecturers.DeleteLecturer();
        }
    }
}
