using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>
    {
        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name 
                && Description == other.Description;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Description.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Name + "\ndescription=" + Description;
        }
        public ProjectData()
        {
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectData(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
