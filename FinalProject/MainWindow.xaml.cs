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
            string ConString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RetrieveMembers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Members");
                sda.Fill(dt);
                MemberGrid.ItemsSource = dt.DefaultView;
            }
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
            obj.DateOfBirth = dObTB.Text;//DateTime.ParseExact(dObTB.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return obj;
            
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Member obj = BuildMember();
            string ConString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AddMemberToDB", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FirstName", obj.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LastName",obj.LastName));
                cmd.Parameters.Add(new SqlParameter("@Nickname", obj.Nickname));
                cmd.Parameters.Add(new SqlParameter("@Weight",obj.Weight));
                cmd.Parameters.Add(new SqlParameter("@Age",obj.Age));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber",obj.PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@Email",obj.Email));
                cmd.Parameters.Add(new SqlParameter("@Nationality", obj.Nationality));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth",obj.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@Status",obj.Status));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success");
            }
            FillDataGrid();
        }
        //private void MemberGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    CollectionViewSource itemCollectionViewSource;
        //    itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
        //    itemCollectionViewSource.Source = ObservableMemberList;
        //}


        // private void firstNameTB_TextChanged(object sender, TextChangedEventArgs e)
        // {
        //  firstNameTB.Text = string.Empty;//here can be an IF statement to check against a default one and only then to clear, like this you clear all the time he click on the box.
        //}
    }
}
