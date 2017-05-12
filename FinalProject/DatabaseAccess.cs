using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace FinalProject
{
   public class DatabaseAccess
    {

        public void MemberDataTable(DataTable dt)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RetrieveMembers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
        }
        public void AddMemberToDb(Member obj)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AddMemberToDB", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FirstName", obj.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", obj.LastName));
                cmd.Parameters.Add(new SqlParameter("@Nickname", obj.Nickname));
                cmd.Parameters.Add(new SqlParameter("@Weight", obj.Weight));
                cmd.Parameters.Add(new SqlParameter("@Age", obj.Age));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", obj.PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@Email", obj.Email));
                cmd.Parameters.Add(new SqlParameter("@Nationality", obj.Nationality));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", obj.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@Status", obj.Status));
                cmd.Parameters.Add(new SqlParameter("@Adress", obj.Adress));
                cmd.Parameters.Add(new SqlParameter("@AmateurWins",obj.AmWins));
                cmd.Parameters.Add(new SqlParameter("@AmateurLosses",obj.AmLoss));
                cmd.Parameters.Add(new SqlParameter("@AmateurDraws",obj.AmDraw));
                cmd.Parameters.Add(new SqlParameter("@ProfessionalWins",obj.ProWins));
                cmd.Parameters.Add(new SqlParameter("@ProfessionalLosses",obj.ProLoss));
                cmd.Parameters.Add(new SqlParameter("@ProfessionalDraws",obj.ProDraw));
                cmd.ExecuteNonQuery();
            }

    }
}
}