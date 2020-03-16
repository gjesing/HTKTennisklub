using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTKTennisklub.Extensions;

namespace HTKTennisklub.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string GenderDescription { get => Gender.GetDescription(); }
        public AgeGroup AgeGroup { get; set; }
        public List<Classification> Classifications { get; set; }
        public Level Level { get; set; }
        public bool IsMember { get; set; }
    }
}
