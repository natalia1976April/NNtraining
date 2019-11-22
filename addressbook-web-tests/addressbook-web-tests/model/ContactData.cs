using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

 //       public bool Equals(ContactData other)
 //       {
 //           if (Object.ReferenceEquals(other, null))
 //           {
  //              return false;
   //         }
   //         if (Object.ReferenceEquals(this, other))
   //         {
   //             return true;
    //        }
    //        return Name == other.Name;
    //    }

    //    public override int GetHashCode()
   //     {
   //         return Name.GetHashCode();
   //     }

    //    public override string ToString()
    //    {
    //        return "name=" + Name;
     //   }

     //   public int CompareTo(GroupData other)
     //   {
     //       if (Object.ReferenceEquals(other, null))
     //       {
     //           return 1;
      //      }
       //     return Name.CompareTo(other.Name);
      //  }
    }

}

