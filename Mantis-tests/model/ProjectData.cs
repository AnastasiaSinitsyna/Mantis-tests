using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Description.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Name;
        }
        public ProjectData()
        {
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public ProjectData(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
