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
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            DataTable dt = new DataTable("Members");
            DatabaseAccess DbA = new DatabaseAccess();
            DbA.MemberDataTable(dt);
            MemberGrid.ItemsSource = dt.DefaultView;
        }
        private void btn_AddNew_Click(object sender, RoutedEventArgs exception)
        {
            ClearTB();
        }
        private void ClearTB()//clear the textboxes
        {
            firstNameTB.Clear();lastNameTB.Clear();nicknameTB.Clear(); nationalityTB.Clear(); emailTB.Clear();ageTB.Clear();weightTB.Clear();
            phoneNumberTB.Clear();adressTB.Clear();statusTB.Clear();amWTB.Clear();amLTB.Clear();amDTB.Clear();proWTB.Clear();proLTB.Clear();
            proDTB.Clear();dObTB.Clear();

        }
        private Member BuildMember()
        { 
            Member obj = new Member();
            obj.FirstName = firstNameTB.Text;
            obj.LastName = lastNameTB.Text;
            obj.Nickname = nicknameTB.Text;
            obj.Nationality = nationalityTB.Text;
            obj.Email = emailTB.Text;
            obj.Age = Convert.ToInt16(ageTB.Text);
            obj.Weight = float.Parse(weightTB.Text);
            obj.PhoneNumber = phoneNumberTB.Text;
            obj.Adress = adressTB.Text;
            obj.Status = statusTB.Text;
            obj.AmWins = Convert.ToInt16(amWTB.Text);
            obj.AmLoss = Convert.ToInt16(amLTB.Text);
            obj.AmDraw = Convert.ToInt16(amDTB.Text);
            obj.ProWins = Convert.ToInt16(proWTB.Text);
            obj.ProLoss = Convert.ToInt16(proLTB.Text);
            obj.ProDraw = Convert.ToInt16(proDTB.Text);
            obj.DateOfBirth = dObTB.Text;
            return obj;
            
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Member obj = BuildMember();
            DatabaseAccess dba = new DatabaseAccess();
            dba.AddMemberToDb(obj);
                MessageBox.Show("Success");
            FillDataGrid();
        }
    }
}
