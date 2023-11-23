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

namespace AMS.LecturerViews
{
    /// <summary>
    /// Interaction logic for LecturerView.xaml
    /// </summary>
    public partial class LecturerView : Window
    {
         LECTUR_AlterStudentGrades alterStudentGrades = new LECTUR_AlterStudentGrades();
        public LecturerView()
        {
            InitializeComponent();
            StudentDataGrid.ItemsSource = alterStudentGrades.dt.DefaultView;
        }

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

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        public void Read_Students()
        {
            StudentDataGrid.ItemsSource = null;
            alterStudentGrades.ReadGrade();
            StudentDataGrid.ItemsSource = alterStudentGrades.dt.DefaultView;
        }
        public void Create_Student()
        {
            alterStudentGrades.grade_id = gradeID.Text;
            alterStudentGrades.additional_info = IdTbx.Text;
            alterStudentGrades.student_id = studentID.Text;
            alterStudentGrades.AddGrade();
        }
        public void Update_Student()
        {
            alterStudentGrades.additional_info = IdTbx.Text;
            alterStudentGrades.UpdateGrade();
        }
        public void Delete_Student()
        {
            alterStudentGrades.id = IdTbx.Text;
            alterStudentGrades.DeleteGrade();
        }
    }

}
