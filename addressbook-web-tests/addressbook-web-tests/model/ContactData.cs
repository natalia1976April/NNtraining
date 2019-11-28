using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }


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

