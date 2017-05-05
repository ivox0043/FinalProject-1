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
            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = ObservableMemberList;
        }
        static ObservableCollection<Member> ObservableMemberList = new ObservableCollection<Member>(addMembersList);
        public static List<Member> addMembersList = new List<Member>();
        private void btn_EditMbr_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_AddNew_Click(object sender, RoutedEventArgs exception)
        {
            try
            {
                Member obj =  BuildMember();
                addMembersList.Add(obj);
                MessageBox.Show("success");
                ClearTB();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         
            
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
            obj.Weight = Convert.ToInt16(weightTB.Text);
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
        private void DoNothing()
        {

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
