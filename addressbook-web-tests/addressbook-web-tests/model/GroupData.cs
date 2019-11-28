using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
 //       private string header = "";
//        private string footer = "";
        private string v1;
        private string v2;

        public GroupData(string name)
        {
            Name = name;
          }

        public GroupData(string name, string v1, string v2) : this(name)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }


        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

    }
}
