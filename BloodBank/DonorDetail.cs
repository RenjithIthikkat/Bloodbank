using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank
{
    /// <summary>
    /// Done by Vidhi Patel
    /// 
    /// This custom class is used to create a list and load data in table in ViewDonors screen.
    /// </summary>
    public class DonorDetail
    {
        private int no; // id of donor
        private string name; // name of donor
        public string phone; // phone number of donor
        public int? age; // age of donor
        public string gender; // gender of donor
        public string city; // city of donor
        public string province; // province of donor
        public string bloodGroup; // blood group of donor
        public string bloodAvailable; // donated blood is available or not
        public System.DateTime? date; // donation date-time

        // getter-setters
        public int No { get => no; set => no = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public int? Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public string City { get => city; set => city = value; }
        public string Province { get => province; set => province = value; }
        public string BloodGroup { get => bloodGroup; set => bloodGroup = value; }
        public string BloodAvailable { get => bloodAvailable; set => bloodAvailable = value; }
        public System.DateTime? Date { get => date; set => date = value; }

        public DonorDetail()
        {

        }
    }
}
