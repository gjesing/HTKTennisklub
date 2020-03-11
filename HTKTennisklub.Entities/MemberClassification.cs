using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.Entities
{
    public class MemberClassification
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public Classification Classification { get; set; }
    }
}
