using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank
{
    /// <summary>
    /// 
    /// Done by Vidhi Patel
    /// 
    /// This helper class is used to get donor detail collection.
    /// This class is used in ViewDonor screen.
    /// </summary>
    public class SearchHelper
    {
        // Database context to perform database operations
        private BloodBankDBDataContext DC;
        public SearchHelper()
        {
            DC = new BloodBankDBDataContext();
        }

        /// <summary>
        /// This returns all donors data
        /// </summary>
        public List<DonorDetail> GetAllData()
        {   
            var table = from D in DC.Donors
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new DonorDetail
                        {
                            No = D.Id,
                            Name = D.Name,
                            Phone = D.Phone,
                            Age = D.Age,
                            Gender = D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            Date = D.Date
                        };

             return table.ToList();
        }

        /// <summary>
        /// This returns donors data with filter by name
        /// </summary>
        public List<DonorDetail> FilterByName(string name, bool bloodAvailable)
        {
            var table = from D in DC.Donors
                        where D.Name.Contains(name)
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new DonorDetail
                        {
                            No = D.Id,
                            Name = D.Name,
                            Phone = D.Phone,
                            Age = D.Age,
                            Gender = D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            Date = D.Date
                        };

            return table.ToList();
        }

        /// <summary>
        /// This returns donors data with filter by phone
        /// </summary>
        public List<DonorDetail> FilterByPhone(string phone, bool bloodAvailable)
        {
            var table = from D in DC.Donors
                        where D.Phone.Contains(phone)
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new DonorDetail
                        {
                            No = D.Id,
                            Name = D.Name,
                            Phone = D.Phone,
                            Age = D.Age,
                            Gender = D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            Date = D.Date
                        };

            return table.ToList();
        }

        /// <summary>
        /// This returns donors data with filter by blood group
        /// </summary>
        public List<DonorDetail> FilterByBloodGroup(string bloodGroup, bool bloodAvailable)
        {
            var whereQuery = from BG in DC.BloodGroups where BG.Name == bloodGroup select BG.Id;
            var table = from D in DC.Donors
                        where whereQuery.ToArray().Contains(D.BloodGroup)
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new DonorDetail
                        {
                            No = D.Id,
                            Name = D.Name,
                            Phone = D.Phone,
                            Age = D.Age,
                            Gender = D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            Date = D.Date
                        };

            return table.ToList();
        }

        /// <summary>
        /// This returns donors data with filter by city
        /// </summary>
        public List<DonorDetail> FilterByCity(string city, bool bloodAvailable)
        {
            var whereQuery = from C in DC.Cities where C.CityName.Contains(city) select C.Id;
            var table = from D in DC.Donors
                        where whereQuery.ToArray().Contains(D.City)
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new DonorDetail
                        {
                            No = D.Id,
                            Name = D.Name,
                            Phone = D.Phone,
                            Age = D.Age,
                            Gender = D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            Date = D.Date
                        };

            return table.ToList();
        }

        /// <summary>
        /// This returns donors data with filter by province
        /// </summary>
        public List<DonorDetail> FilterByProvince(string province, bool bloodAvailable)
        {
            var whereQuery = from P in DC.Provinces where P.ProvinceName.Contains(province) select P.Id;
            var table = from D in DC.Donors
                        where whereQuery.ToArray().Contains(D.Province)
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new DonorDetail
                        {
                            No = D.Id,
                            Name = D.Name,
                            Phone = D.Phone,
                            Age = D.Age,
                            Gender = D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            Date = D.Date
                        };

            return table.ToList();
        }

        /// <summary>
        /// This returns donors data with filter by blood availibility
        /// </summary>
        public List<DonorDetail> FilterByBloodAvailable()
        {
            var table = from D in DC.Donors
                        where D.BloodAvailable == 1
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new DonorDetail
                        {
                            No = D.Id,
                            Name = D.Name,
                            Phone = D.Phone,
                            Age = D.Age,
                            Gender = D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            Date = D.Date
                        };

            return table.ToList();
        }
    }
}
