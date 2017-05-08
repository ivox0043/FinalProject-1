namespace FinalProject
{

    public class Member
    {
        private string _firstN;
        private string _lastN;
        private string _nickname;
        private string _nationality;
        private string _dob;
        private int _age;
        private float _weight;
        private string _phoneNr;
        private string _email;
        private string _status;
        private int _proW;
        private int _proL;
        private int _proD;
        private int _amW;
        private int _amL;
        private int _amD;
        private string _adress;
        public string FirstName { get { return _firstN; } set { _firstN = value; } }
        public string LastName { get { return _lastN; } set { _lastN = value; } }
        public string Nickname { get { return _nickname; } set { _nickname = value; } }
        public string Nationality { get { return _nationality; } set { _nationality = value; } }
        public string DateOfBirth { get { return _dob; } set { _dob = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public float Weight { get { return _weight; } set { _weight = value; } }
        public string PhoneNumber { get { return _phoneNr; } set { _phoneNr = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Status { get { return _status; } set { _status = value; } }
        public int ProWins { get { return _proW; } set { _proW = value; } }
        public int ProLoss { get { return _proL; } set { _proL = value; } }
        public int ProDraw { get { return _proD; } set { _proD = value; } }
        public int AmWins { get { return _amW; } set { _amW = value; } }
        public int AmLoss { get { return _amL; } set { _amL = value; } }
        public int AmDraw { get { return _amD; } set { _amD = value; } }
        public string Adress { get { return _adress; } set { _adress = value; } }
        public Member() { }
        public Member(string firstN, string lastN, string nickname, string nationality, string dob, int age, float weight, string phoneNr, string email, string status, int proW, int proL, int proD, int amW, int amL, int amD, string adress)
        {
            FirstName = firstN;
            LastName = lastN;
            Nickname = nickname;
            Nationality = nationality;
            DateOfBirth = dob;
            Age = age;
            Weight = weight;
            PhoneNumber = phoneNr;
            Email = email;
            Status = status;
            ProWins = proW;
            ProLoss = proL;
            ProDraw = proD;
            AmDraw = amD;
            AmLoss = amL;
            AmDraw = amD;
            Adress = adress;
        }

    }

}
