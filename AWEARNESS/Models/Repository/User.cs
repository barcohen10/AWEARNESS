using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AWEARNESS.Models.Repository
{
    public class User
    {
        [Key]
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Registration { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Medicines { get; set; }
        public string Diseases { get; set; }
        public string Allergies { get; set; }
        public string SpecialInstructions { get; set; }
        public virtual List<UserQRCodes> QRCodes { get; set; }
        public virtual List<UserEvents> Events { get; set; }
    }

    public class UserMng
    {
        private static UserMng m_Instance;
        private Dictionary<string, User> m_Users = new Dictionary<string, User>();
        private AwearnessDB m_DB = new AwearnessDB();

        private UserMng()
        {

            var usersList = m_DB.Users.ToList();

            foreach (var user in usersList)
            {
                this.m_Users.Add(user.PhoneNumber, user);
            }
        }

        public static UserMng Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new UserMng();
                }
                return m_Instance;
            }
        }

        public List<User> AllUsers
        {
            get
            {
                return m_Users.Values.ToList();
            }
        }

        public User GetUser(string i_PhoneNumber)
        {
            if (m_Users.ContainsKey(i_PhoneNumber))
            {
                return m_Users[i_PhoneNumber];
            }
            return null;
        }

        public User GetUserByQRCode(string i_QRCodeId)
        {
            User user = m_Users.Values.Where(x => x.QRCodes.All(z => z.QRCodeId == i_QRCodeId)).FirstOrDefault();
            return user;
        }


        public void CreateUser(User i_User)
        {
            if (!m_Users.ContainsKey(i_User.PhoneNumber))
            {
                m_Users.Add(i_User.PhoneNumber, i_User);
                m_DB.Users.Add(i_User);
                m_DB.SaveChanges();
            }
        }

        public void UpdateUser(User i_User)
        {
            User userFromDB = UserMng.Instance.GetUserFromDB(i_User.PhoneNumber);
            userFromDB.Allergies = i_User.Allergies;
            userFromDB.Birthday = i_User.Birthday;
            userFromDB.Email = i_User.Email;
            userFromDB.Password = i_User.Password;
            userFromDB.SpecialInstructions = i_User.SpecialInstructions;
            userFromDB.Diseases = i_User.Diseases;
            m_DB.Entry(userFromDB).State = EntityState.Modified;
            m_DB.SaveChanges();
        }

        public void DeleteUser(string i_PhoneNumber)
        {
            User user = m_DB.Users.Find(i_PhoneNumber);
            m_Users.Remove(i_PhoneNumber);
            m_DB.Users.Remove(user);
            m_DB.SaveChanges();
        }

        public User GetUserFromDB(string i_PhoneNumber)
        {
            User user = m_DB.Users.Find(i_PhoneNumber);
            return user;
        }
    }

}
