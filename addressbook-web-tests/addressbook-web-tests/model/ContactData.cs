using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name ="addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEMails;

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public ContactData()
        {
        }

        public static List<ContactData> GetAll()
        {
             using (AddressBookDB db = new AddressBookDB())
             {
                 return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
             }
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public ContactData(string v)
        {
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string SecondaryPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(SecondaryPhone)).Trim();
                }
            }
            set
            {
              allPhones = value;
            }
        }

        public string Homepage { get; set; }

        public string EMail { get; set; }

        public string EMail2 { get; set; }

        public string EMail3 { get; set; }

        public string AllEMails
        {
            get
            {
                 if (allEMails != null)
                {
                    return allEMails;
                }
                else
                {
                    return (CleanUp(EMail) + CleanUp(EMail2) + CleanUp(EMail3)).Trim();
                }
            }
            set
            {
                allEMails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
            //    return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
            
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + FirstName + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            //sort by first name then by last name
            //sort by first name
            var nameSortOrder = FirstName.CompareTo(other.FirstName);
            if (nameSortOrder != 0)
                return nameSortOrder;
            //if equal - sort by last name
            return LastName.CompareTo(other.LastName);
        }
    }

}

